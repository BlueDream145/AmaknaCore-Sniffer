using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;
using AmaknaProxy.API.Protocol;
using AmaknaProxy.API.Protocol.Messages;
using AmaknaProxy.Engine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using AmaknaProxy.API.Managers;
using AmaknaProxy.Engine.Utils.Tickets;
using System.Net;
using AmaknaProxy.Sniffer;
using AmaknaProxy.API.Client.Enums;
using System.Windows.Forms;

namespace AmaknaProxy.Engine.Client.Network
{
    public class ClientNetwork
    {

        #region Variables

        public delegate void MonitorPacketDelegate(MainClient client, NetworkMessage message);

        public SimpleClient ClientConnection { get; set; }

        public SimpleClient ServerConnection { get; set; }

        public Socket Sock;
        
        public Dictionary<int, List<MonitorPacketDelegate>> Frames { get; set; }

        public bool Ticket;

        private MainClient Client;

        private Random Rnd;

        public uint Instance { get; set; }
        #endregion

        #region Builder

        public ClientNetwork(Socket sock, MainClient client, uint _instance = 0)
        {
            Sock = sock;
            Client = client;
            Frames = new Dictionary<int, List<MonitorPacketDelegate>>();
            Ticket = false;
            Instance = _instance;
            Rnd = new Random();
        }

        #endregion

        #region Methods

        public void OpenConnection()
        {
            try
            {

                ServerConnection = new SimpleClient();
                ClientConnection = new SimpleClient();

                ServerConnection.Disconnected += ServerDisconnected;
                ServerConnection.DataReceived += ServerDataReceived;
                ServerConnection.Error += SocketError;

                ClientConnection.Disconnected += ClientDisconnected;
                ClientConnection.DataReceived += ClientDataReceived;
                ClientConnection.Error += SocketError;

                ClientConnection.Start(Sock);
                if (Client.Silent)
                {
                    string address = Constants.LoginAddresses[Rnd.Next(0, Constants.LoginAddresses.Length)];
                    short port = (short)Constants.LoginPorts[Rnd.Next(0, Constants.LoginPorts.Length)];

                    ServerConnection.Start(address, port);
                }
                else
                {
                    TicketEntry msg = TicketsManager.GetTicket();

                    Client.AccountName = msg.AccountName;
                    Client.Network.Instance = msg.Instance;

                    string address = Dns.GetHostAddresses(msg.ServerMsg.address)[Rnd.Next(0, Dns.GetHostAddresses(msg.ServerMsg.address).Length)].ToString();
                    short port = (short)msg.ServerMsg.ports[Rnd.Next(0, msg.ServerMsg.ports.Length)];

                    ServerConnection.Start(address, port);
                }
            }
            catch(Exception ex)
            {
                WindowManager.MainWindow.Logger.Error("[Network] " + ex.Message);
            }
        }

        public void StopConnection()
        {
            try
            {
                if (ClientConnection != null)
                {
                    ClientConnection.Disconnected -= ClientDisconnected;
                    ClientConnection.DataReceived -= ClientDataReceived;
                    ClientConnection.Error -= SocketError;

                    if (ClientConnection.Runing)
                        ClientConnection.Stop();

                    ClientConnection = null;
                }

                if (ServerConnection != null)
                {
                    ServerConnection.Disconnected -= ServerDisconnected;
                    ServerConnection.DataReceived -= ServerDataReceived;
                    ServerConnection.Error -= SocketError;

                    if (ServerConnection.Runing)
                        ServerConnection.Stop();

                    ServerConnection = null;
                }
            }
            catch (Exception ex)
            {
                WindowManager.MainWindow.Logger.Error("[Network] " + ex.Message);
            }
        }

        public void Send(MessagePart part, ConnectionDestination destination)
        {
            try
            {
                BigEndianWriter writer = new BigEndianWriter();
                byte typeLen;
                if (part.Data.Length > 65535)
                    typeLen = 3;
                else if (part.Data.Length > 255)
                    typeLen = 2;
                else if (part.Data.Length > 0)
                    typeLen = 1;
                else
                    typeLen = 0;

                writer.WriteShort((short)(part.MessageId << 2 | typeLen));

                Instance += 1;
                if (destination == ConnectionDestination.Server)
                    writer.WriteUInt(Instance);

                switch (typeLen)
                {
                    case 0:
                        break;
                    case 1:
                        writer.WriteByte((byte)part.Data.Length);
                        break;
                    case 2:
                        writer.WriteShort((short)part.Data.Length);
                        break;
                    case 3:
                        writer.WriteByte((byte)(part.Data.Length >> 16 & 255));
                        writer.WriteShort((short)(part.Data.Length & 65535));
                        break;
                }

                writer.WriteBytes(part.Data);

                if (writer == null || writer.Data == null)
                    return;

                switch (destination)
                {
                    case ConnectionDestination.Client:
                        ClientConnection.Send(writer.Data);
                        break;
                    case ConnectionDestination.Server:
                        ServerConnection.Send(writer.Data);
                        break;
                }

                writer.Dispose();
                writer = null;
                part = null;
            }
            catch (Exception ex)
            {
                if (Client != null && WindowManager.MainWindow.Logger != null)
                   WindowManager.MainWindow.Logger.Error("[Network] Send Function -> " + ex.Message);
                else
                    WindowManager.MainWindow.Logger.Error("[Network] Send Function -> " + ex.Message);
            }
        }

        public void Send(NetworkMessage message, ConnectionDestination destination = ConnectionDestination.Server)
        {
            if (message is BasicStatMessage || message.Cancel)
                return;

            try
            {
                if (Client.Network == null)
                    return;

                Instance += 1;
                BigEndianWriter writer = new BigEndianWriter();

                switch (destination)
                {
                    case ConnectionDestination.Client:
                        message.Pack(writer, 0);
                        Client.Network.ClientConnection.Send(writer.Data);
                        SaveMsg(message, ConnectionDestination.Client);
                        if (ServerMessageReceived != null)
                            OnServerMessageReceived(new MessageReceivedEventArgs(message));
                        break;
                    case ConnectionDestination.Server:
                        message.Pack(writer, Instance);
                        Client.Network.ServerConnection.Send(writer.Data);
                        SaveMsg(message, ConnectionDestination.Server);
                        if (ClientMessageReceived != null)
                            OnClientMessageReceived(new MessageReceivedEventArgs(message));
                        break;
                }

                writer.Dispose();
                writer = null;
                message = null;
            }
            catch (Exception ex)
            {
                if(Client != null &&WindowManager.MainWindow.Logger != null)
                   WindowManager.MainWindow.Logger.Error("[Network] Send Function -> " + ex.Message);
                else
                    WindowManager.MainWindow.Logger.Error("[Network] Send Function -> " + ex.Message);
            }
        }

        public void MonitorPacket(int packetId, MonitorPacketDelegate deleg)
        {
            if (Frames.ContainsKey(packetId))
                Frames[packetId].Add(deleg);
            else
                Frames.Add(packetId, new List<MonitorPacketDelegate> { deleg });
        }

        public void CleanPackets(string _namespace)
        {
            List<KeyValuePair<int, List<MonitorPacketDelegate>>> pairsToDelete = new List<KeyValuePair<int, List<MonitorPacketDelegate>>>();
            foreach(KeyValuePair<int, List<MonitorPacketDelegate>> pair in Frames)
            {
                List<MonitorPacketDelegate> itemsToDelete = new List<MonitorPacketDelegate>();

                foreach(MonitorPacketDelegate deleg in pair.Value)
                {
                    if (deleg.Method.DeclaringType.FullName.StartsWith(_namespace))
                        itemsToDelete.Add(deleg);
                }

                foreach (MonitorPacketDelegate dele in itemsToDelete)
                    pair.Value.Remove(dele);

                if (pair.Value.Count == 0)
                    pairsToDelete.Add(pair);
            }

            foreach (KeyValuePair<int, List<MonitorPacketDelegate>> pair in pairsToDelete)
                Frames.Remove(pair.Key);
        }

        private void SaveMsg(NetworkMessage msg, ConnectionDestination destination)
        {
            if (Client.Silent)
                return;

            try
            {
                if (!Directory.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Logs\")))
                    Directory.CreateDirectory(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Logs\"));

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Logs\Network.txt"), true))
                {
                    if (destination == ConnectionDestination.Server)
                        file.WriteLine(string.Format("({0}) Received <- Name={1}; Id={2};", DateTime.Now.ToString("HH:mm:ss"), msg.ToString(), msg.MessageId));
                    else if (destination == ConnectionDestination.Client)
                        file.WriteLine(string.Format("({0}) Sent     -> Name={1}; Id={2};", DateTime.Now.ToString("HH:mm:ss"), msg.ToString(), msg.MessageId));

                    file.Close();
                    file.Dispose();
                }
            }
            catch (Exception) {}
        }

        #endregion

        #region Events

        #region DataReceived

        private void ClientDataReceived(object sender, SimpleClient.DataReceivedEventArgs e)
        {
            try
            {
                var messageDataReader = new BigEndianReader(e.Data.Data);
                
                NetworkMessage message = MessageReceiver.BuildMessage((uint)e.Data.MessageId.Value, messageDataReader);
                
                SaveMsg(message, ConnectionDestination.Client);
                if (ClientMessageReceived != null)
                    OnClientMessageReceived(new MessageReceivedEventArgs(message));

                if (message == null)
                {
                    Send(e.Data, ConnectionDestination.Server);
                    return;
                }
                
               
                // here


                if (!message.Cancel)
                {
                    Send(e.Data, ConnectionDestination.Server);
                    messageDataReader.Dispose();
                    message = null;
                }
            }
            catch (Exception ex)
            {
                if (Client != null &&WindowManager.MainWindow.Logger != null)
                   WindowManager.MainWindow.Logger.Error("[Network] ClientDataReceived Function -> " + ex.Message);
                else
                    WindowManager.MainWindow.Logger.Error("[Network] ClientDataReceived Function -> " + ex.Message);
            }
        }

        private void ServerDataReceived(object sender, SimpleClient.DataReceivedEventArgs e)
        {
            try
            {
                var messageDataReader = new BigEndianReader(e.Data.Data);

                NetworkMessage message = MessageReceiver.BuildMessage((uint)e.Data.MessageId.Value, messageDataReader);
                
                SaveMsg(message, ConnectionDestination.Server);
                if (ServerMessageReceived != null)
                    OnServerMessageReceived(new MessageReceivedEventArgs(message));

                if (message == null)
                {
                    Send(e.Data, ConnectionDestination.Client);
                    return;
                }

                // here

                if (message.MessageId == 6469 || message.MessageId == 42)
                {
                    SelectedServerDataMessage msg = (SelectedServerDataMessage)message;
                    TicketsManager.RegisterTicket(Client.AccountName, Client.Network.Instance, msg);

                    ((ClientNetwork)Client.Network).Ticket = true;
                    Client.Network.Send(new SelectedServerDataMessage(msg.serverId, "127.0.0.1", new uint[] { 443 }, msg.canCreateNewCharacter, msg.ticket), ConnectionDestination.Client);
                    message.Cancel = true;
                    Client.UnloadClient();
                }

                if (message.MessageId == 22)
                {
                    IdentificationSuccessMessage msg = (IdentificationSuccessMessage)message;
                    Client.AccountName = msg.login;
                }

                if (message.MessageId == 153)
                {
                    CharacterSelectedSuccessMessage msg = (CharacterSelectedSuccessMessage)message;

                    Client.Dock.Invoke((MethodInvoker)delegate
                    {
                        Client.Dock.Text = msg.infos.name + " (" + Client.AccountName + ")";
                    });
                }

                if (!message.Cancel)
                {
                    Send(e.Data, ConnectionDestination.Client);
                    messageDataReader.Dispose();
                    message = null;
                }
            }
            catch (Exception ex)
            {
                if (Client != null &&WindowManager.MainWindow.Logger != null)
                   WindowManager.MainWindow.Logger.Error("[Network] ServerDataReceived Function -> " + ex.Message);
            }
        }

        #endregion

        #region Disconnected

        private void ClientDisconnected(object sender, SimpleClient.DisconnectedEventArgs e)
        {
            Client.UnloadClient();
        }

        private void ServerDisconnected(object sender, SimpleClient.DisconnectedEventArgs e)
        {
            if(!Client.Silent)
                Client.UnloadClient();
        }

        #endregion

        #region Error

        private void SocketError(object sender, SimpleClient.ErrorEventArgs e)
        {
            if(Client != null &&WindowManager.MainWindow.Logger != null)
               WindowManager.MainWindow.Logger.Error("[Network] " + e.Ex.Message);
        }

        #endregion

        #endregion

        #region Emits Events

        public event EventHandler<MessageReceivedEventArgs> ServerMessageReceived;
        public event EventHandler<MessageReceivedEventArgs> ClientMessageReceived;

        private void OnServerMessageReceived(MessageReceivedEventArgs e)
        {
            if (ServerMessageReceived != null)
                ServerMessageReceived(this, e);
        }

        private void OnClientMessageReceived(MessageReceivedEventArgs e)
        {
            if (ClientMessageReceived != null)
                ClientMessageReceived(this, e);
        }


        public class MessageReceivedEventArgs
        {
            public NetworkMessage Msg;

            public MessageReceivedEventArgs(NetworkMessage msg)
            {
                Msg = msg;
            }
        }

        #endregion

    }
}
