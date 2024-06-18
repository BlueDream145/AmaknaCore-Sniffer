using AmaknaProxy.Engine.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static AmaknaProxy.Engine.Client.MainClient;

namespace AmaknaProxy.Engine.Managers
{
    public class ClientsManager
    {

        #region Variables

        public static List<Client.MainClient> GameClients;

        public static List<Client.MainClient> LoginClients;

        public static Dictionary<string, int> LastPlayers;

        private static object CheckLock;

        #endregion

        #region Builder

        static ClientsManager()
        {
            GameClients = new List<Client.MainClient>();
            LoginClients = new List<Client.MainClient>();
            LastPlayers = new Dictionary<string, int>();
            CheckLock = new object();
        }

        #endregion

        #region Methods

        public static void RegisterLastPlayer(string accountName, int playerIndex)
        {
            lock(CheckLock)
            {
                if (LastPlayers.ContainsKey(accountName))
                    LastPlayers.Remove(accountName);

                LastPlayers.Add(accountName, playerIndex);
            }
        }

        public static int GetPlayerIndex(string accountName)
        {
            if (!LastPlayers.ContainsKey(accountName))
                return 0;
            else
            {
                int _out = 0;
                if (LastPlayers.TryGetValue(accountName, out _out))
                    return _out;
                else
                    return 0;
            }
        }

        public static MainClient RegisterClient(Socket sock, bool silent)
        {
            lock(CheckLock)
            {
                MainClient client = new MainClient(sock, silent);
                client.ClientUnloaded += ClientUnloaded;
                client.LoadClient();

                if (silent)
                    LoginClients.Add(client);
                else
                    GameClients.Add(client);
                
                return client;
            }
        }

        public static void UnloadAll()
        {
            lock (CheckLock)
            {
                foreach (MainClient client in GameClients)
                    client.UnloadClient(true);

                foreach (MainClient client in LoginClients)
                    client.UnloadClient(true);
            }
        }

        #endregion

        #region Events

        private static void ClientUnloaded(object sender, ClientEventArgs e)
        {
            e.Client.ClientUnloaded -= ClientUnloaded;

            if(!e.Client.Silent)
                OnClientUnloaded(e.Client.AccountName);

            lock (CheckLock)
            {
                if (LoginClients.Contains(e.Client))
                    LoginClients.Remove(e.Client);
                else if (GameClients.Contains(e.Client))
                    GameClients.Remove(e.Client);
            }
        }

        #endregion

        #region Events
        
        public static event EventHandler<MainClient> ClientLoaded_Event;
        public static event EventHandler<string> ClientUnloaded_Event;

        public static void OnClientLoaded(MainClient c)
        {
            if (ClientLoaded_Event != null)
                ClientLoaded_Event(null, c);
        }

        private static void OnClientUnloaded(string c)
        {
            if (ClientUnloaded_Event != null)
                ClientUnloaded_Event(null, c);
        }

        #endregion

    }
}
