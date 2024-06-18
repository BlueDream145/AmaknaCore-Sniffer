using AmaknaProxy.API.IO;
using AmaknaProxy.API.Managers;
using AmaknaProxy.API.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.API.Network
{
    public class SimpleClient
    {

        #region Variables

        public Socket Socket;
        public bool Runing { get; private set; }
        private byte[] sendBuffer, receiveBuffer;
        private BigEndianReader buffer;
        const int bufferLength = 8192;
        private MessagePart currentMessage;

        #endregion

        #region Builder

        public SimpleClient(string ip, short port)
        {
            Init();
            Start(ip, port);
        }

        public SimpleClient(Socket socket)
        {
            Init();
            Start(socket);
        }

        public SimpleClient()
        {
            Init();
        }

        #endregion

        #region Methods

        public void Start(Socket socket)
        {
            try
            {
                Runing = true;
                Socket = socket;
                Socket.BeginReceive(receiveBuffer, 0, bufferLength, SocketFlags.None, new AsyncCallback(ReceiveCallBack), Socket);
            }
            catch (System.Exception ex)
            {
                OnError(new ErrorEventArgs(ex));
            }
        }

        public void Start(string ip, short port)
        {
            try
            {
                Socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ip), port), new AsyncCallback(ConnectionCallBack), Socket);
            }
            catch (System.Exception ex)
            {
                OnError(new ErrorEventArgs(ex));
            }
        }

        public void Start(IPEndPoint endPoint)
        {
            try
            {
                Socket.BeginConnect(endPoint, new AsyncCallback(ConnectionCallBack), Socket);
            }
            catch (System.Exception ex)
            {
                OnError(new ErrorEventArgs(ex));
            }
        }

        public void Stop()
        {
            try
            {
                if(Socket.Connected == true)
                    Socket.BeginDisconnect(false, DisconectedCallBack, Socket);
            }
            catch (System.Exception ex)
            {
                OnError(new ErrorEventArgs(ex));
            }
        }

        public void Send(byte[] data)
        {
            try
            {
                if (Socket.Connected == false)
                    Runing = false;
                if (Runing)
                {
                    if (data.Length == 0)
                        return;
                    sendBuffer = data;
                    Socket.BeginSend(sendBuffer, 0, sendBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallBack), Socket);
                }
                //else
                   // ConsoleManager.Error("Send " + data.Length + " bytes but not runing");
            }
            catch (System.Exception ex)
            {
                OnError(new ErrorEventArgs(ex));
            }
        }

        public void Dispose()
        {
            // Dispose

            if(Socket != null)
                Socket.Dispose();

            if (buffer != null)
                buffer.Dispose();

            // Clean

            Socket = null;
            sendBuffer = null;
            receiveBuffer = null;
            buffer = null;
            currentMessage = null;
        }

        #endregion

        #region Private Methods

        private void Init()
        {
            try
            {
                buffer = new BigEndianReader();
                receiveBuffer = new byte[bufferLength];
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (System.Exception ex)
            {
                OnError(new ErrorEventArgs(ex));
            }
        }

        private void ThreatBuffer()
        {
            if (currentMessage == null)
                currentMessage = new MessagePart();
            long pos = buffer.Position;

            string ip = ((IPEndPoint)Socket.RemoteEndPoint).Address.ToString();
            bool isClient = false;

            if (ip.StartsWith("127.0.0.1"))
                isClient = true;

            if (currentMessage.Build(buffer, isClient))
            {
                OnDataReceived(new DataReceivedEventArgs(currentMessage));
                currentMessage = null;
                ThreatBuffer();
            }
        }

        #endregion

        #region CallBack

        private void ConnectionCallBack(IAsyncResult asyncResult)
        {
            try
            {
                Runing = true;
                Socket client = (Socket)asyncResult.AsyncState;
                client.EndConnect(asyncResult);
                client.BeginReceive(receiveBuffer, 0, bufferLength, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);
                OnConnected(new ConnectedEventArgs());
            }
            catch (System.Exception ex)
            {
                OnError(new ErrorEventArgs(ex));
            }
        }

        private void DisconectedCallBack(IAsyncResult asyncResult)
        {
            try
            {
                Runing = false;
                Socket client = (Socket)asyncResult.AsyncState;
                client.EndDisconnect(asyncResult);
                OnDisconnected(new DisconnectedEventArgs(Socket));
            }
            catch (System.Exception ex)
            {
                OnError(new ErrorEventArgs(ex));
            }
        }

        private void ReceiveCallBack(IAsyncResult asyncResult)
        {
            Socket client = (Socket)asyncResult.AsyncState;
            if (client.Connected == false)
            {
                Runing = false;
                return;
            }
            if (Runing)
            {
                int bytesRead = 0;

                try
                {
                    bytesRead = client.EndReceive(asyncResult);
                }
                catch (System.Exception ex)
                {
                    OnError(new ErrorEventArgs(ex));
                }

                if (bytesRead == 0)
                {
                    Runing = false;
                    OnDisconnected(new DisconnectedEventArgs(Socket));
                    return;
                }
                byte[] data = new byte[bytesRead];
                Array.Copy(receiveBuffer, data, bytesRead);
                buffer.Add(data, 0, data.Length);
                ThreatBuffer();
                try
                {
                    client.BeginReceive(receiveBuffer, 0, bufferLength, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);
                }
                catch (System.Exception ex)
                {
                    OnError(new ErrorEventArgs(ex));
                }
            }
        }

        private void SendCallBack(IAsyncResult asyncResult)
        {
            try
            {
                if (Runing == true)
                {
                    Socket client = (Socket)asyncResult.AsyncState;
                    client.EndSend(asyncResult);
                    OnDataSended(new DataSendedEventArgs());
                }
            }
            catch (System.Exception ex)
            {
                OnError(new ErrorEventArgs(ex));
            }
        }

        #endregion

        #region Events

        public event EventHandler<ConnectedEventArgs> Connected;
        public event EventHandler<DisconnectedEventArgs> Disconnected;
        public event EventHandler<DataReceivedEventArgs> DataReceived;
        public event EventHandler<DataSendedEventArgs> DataSended;
        public event EventHandler<ErrorEventArgs> Error;

        private void OnConnected(ConnectedEventArgs e)
        {
            if (Connected != null)
                Connected(this, e);
        }

        private void OnDisconnected(DisconnectedEventArgs e)
        {
            if (Disconnected != null)
                Disconnected(this, e);
        }

        private void OnDataReceived(DataReceivedEventArgs e)
        {
            if (DataReceived != null)
                DataReceived(this, e);
        }

        private void OnDataSended(DataSendedEventArgs e)
        {
            if (DataSended != null)
                DataSended(this, e);
        }

        private void OnError(ErrorEventArgs e)
        {
            if (Error != null)
                Error(this, e);
        }

        #endregion

        #region EventArgs

        public class ConnectedEventArgs : EventArgs
        {
        }

        public class DisconnectedEventArgs : EventArgs
        {
            public Socket Socket { get; private set; }

            public DisconnectedEventArgs(Socket socket)
            {
                Socket = socket;
            }
        }

        public class DataSendedEventArgs : EventArgs
        {
        }

        public class DataReceivedEventArgs : EventArgs
        {
            public MessagePart Data { get; private set; }

            public DataReceivedEventArgs(MessagePart data)
            {
                Data = data;
            }
        }

        public class ErrorEventArgs : EventArgs
        {
            public System.Exception Ex { get; private set; }

            public ErrorEventArgs(System.Exception ex)
            {
                Ex = ex;
            }
        }

        #endregion

    }
}
