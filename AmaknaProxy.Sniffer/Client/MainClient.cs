
using AmaknaProxy.API.Managers;
using AmaknaProxy.API.Network;
using AmaknaProxy.API.Utils.Logger;
using AmaknaProxy.Engine.Client.Network;
using AmaknaProxy.Engine.Managers;
using AmaknaProxy.Engine.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace AmaknaProxy.Engine.Client
{
    public class MainClient
    {

        #region Variables

        public ClientControl Control { get; set; }

        public ClientNetwork Network { get; set; }

        public DockContent Dock { get; set; }

        public string AccountName { get; set; }

        public bool Silent { get; set; }

        #endregion

        #region Builder

        public MainClient(Socket _sock, bool silent)
        {
            Silent = silent;
            Network = new ClientNetwork(_sock, this);
        }


        #endregion

        #region Methods

        public void LoadClient()
        {
            try
            {
                if (!Silent)
                {
                    LoadControl();
                }

                Network.OpenConnection();
            }
            catch (Exception ex)
            {
                WindowManager.MainWindow.Logger.Error("[LoadClient] " + ex.Message);
            }
        }

        public void UnloadClient(bool cancelEvent = false)
        {
            try
            {
                if(!cancelEvent)
                    OnClientUnloaded(new ClientEventArgs(this));

                if (Network != null && WindowManager.MainWindow.Logger != null)
                {
                    Network.StopConnection();

                    if (!Silent)
                        WindowManager.MainWindow.Logger.Info("Client déconnecté.");
                }

                if (Dock != null && Control != null && WindowManager.MainWindow != null && Dock.Controls.Contains((ClientControl)Control))
                    Dock.Invoke((MethodInvoker)delegate { Dock.Controls.Remove((ClientControl)Control); });

                if (Dock != null)
                {
                    Dock.Invoke((MethodInvoker)delegate
                    {
                        Dock.DockHandler.DockPanel = null;
                        Dock.Dispose();
                    });
                }

                if (Control != null)
                {
                    ((ClientControl)Control).Invoke((MethodInvoker)delegate { ((ClientControl)Control).Dispose(); });
                }

                Network = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                WindowManager.MainWindow.Logger.Error("[UnloadClient] " + ex.Message);
            }
        }

        public void LoadControl()
        {
            try
            {
                ClientControl control = new ClientControl(this);
                control.Dock = System.Windows.Forms.DockStyle.Fill;


                Dock = new DockContent();
                Dock.Text = AccountName;
                Dock.Controls.Add(control);
                Control = control;

                ((MainForm)WindowManager.MainWindow).Invoke((MethodInvoker)delegate { Dock.Show(((MainForm)WindowManager.MainWindow).DockPanel_Main, DockState.Document); });
            }
            catch (Exception ex)
            {
                WindowManager.MainWindow.Logger.Error("[LoadControl] " + ex.Message);
            }
        }

        #endregion

        #region Events

        public event EventHandler<ClientEventArgs> ClientUnloaded;

        private void OnClientUnloaded(ClientEventArgs e)
        {
            if (ClientUnloaded != null)
                ClientUnloaded(this, e);
        }

        public class ClientEventArgs
        {
            public MainClient Client;

            public ClientEventArgs(MainClient client)
            {
                Client = client;
            }
        }

        #endregion
    }
}
