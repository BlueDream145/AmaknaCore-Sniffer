using AmaknaProxy.API.Managers;
using AmaknaProxy.API.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.Engine.Managers
{
    public class NetworkManager
    {

        #region Variables

        private static SimpleServer Login_Server;

        private static SimpleServer Game_Server;

        public static bool Running;

        #endregion

        #region Builder

        static NetworkManager()
        {
            Running = false;
        }

        #endregion

        #region Methods

        public static void StartServers()
        {
            if (Running == true)
                return;

            try
            {
                Login_Server = new SimpleServer();
                Game_Server = new SimpleServer();

                Login_Server.ConnectionAccepted += Login_ConnectionAccepted;
                Game_Server.ConnectionAccepted += Game_ConnectionAccepted;

                Login_Server.Start(5555);
                Game_Server.Start((short)443);

                Running = true;
            }
            catch(Exception ex)
            {
                WindowManager.MainWindow.Logger.Error("[Network] " + ex.Message);
            }
        }

        public static void StopServers()
        {
            if (Running == false)
                return;

            try
            {
                Login_Server.Stop();
                Login_Server = null;

                Game_Server.Stop();
                Game_Server = null;

                Running = false;
            }
            catch (Exception ex)
            {
                WindowManager.MainWindow.Logger.Error("[Network] " + ex.Message);
            }
        }

        #endregion

        #region Events

        private static void Login_ConnectionAccepted(Socket sender)
        {
            WindowManager.MainWindow.Logger.Info("Nouveau client sur le serveur d'authentification.");
            ClientsManager.RegisterClient(sender, true);
        }

        private static void Game_ConnectionAccepted(Socket sender)
        {
            WindowManager.MainWindow.Logger.Info("Nouveau client sur le serveur de jeu.");
            ClientsManager.RegisterClient(sender, false);
        }

        #endregion
    }
}
