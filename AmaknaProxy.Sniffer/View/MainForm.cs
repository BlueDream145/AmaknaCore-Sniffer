using AmaknaProxy.API.Utils.Logger;
using AmaknaProxy.Engine.Managers;
using AmaknaProxy.Engine.Utils.Config;
using AmaknaProxy.Engine.Utils.Injector;
using AmaknaProxy.Sniffer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace AmaknaProxy.Engine.View
{
    public partial class MainForm : DockContent
    {

        #region Variables

        public ContainerLogger Logger { get; set; }

        public RichTextBox Container;

        public AutoInjector Injector;

        public bool Debug { get; set; }

        #endregion

        #region Builder

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void LoadUI()
        {
            // Console

            Container = new RichTextBox();
            Container.Dock = DockStyle.Fill;
            Container.ReadOnly = true;

            DockContent f = new DockContent();
            f.Text = "Console";
            f.Controls.Add(Container);
            f.CloseButtonVisible = false;
            f.Show(DockPanel_Main, DockState.DockBottom);
        }

        private void LoadInjector()
        {
            try
            {
                Injector = new AutoInjector("Dofus", Path.Combine(System.Windows.Forms.Application.StartupPath, "AmaknaProxy.Hooks.dll"), (ContainerLogger)Logger);
                Injector.Start();
                this.Invoke((MethodInvoker)delegate { ToolStripMenuItem_Proxy.Text = "Proxy: Activé"; });
            }
            catch (Exception ex)
            {
                Logger.Error(" (LoadInjector) " + ex.Message);
            }
        }

        #endregion

        #region Components

        #region Form

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadUI();

            Logger = new ContainerLogger(Container, true, false);
            Program.ProgramLoaded += OnProgramLoaded;

            this.Invoke((MethodInvoker)delegate { this.Text += " - Build "; });
            BackgroundWorker_Load.RunWorkerAsync();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetworkManager.StopServers();
            ClientsManager.UnloadAll();
        }

        #endregion

        #region BackGroundWorker

        private void BackgroundWorker_Load_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.LoadProgram((ContainerLogger)Logger);
            LoadInjector();
        }

        #endregion

        #region Program

        private void OnProgramLoaded(object sender, object e)
        {
        }

        #endregion

        #region ToolStripMenuItem

        private void ToolStripMenuItem_Proxy_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuItem_Proxy.Text.Contains("Chargement"))
                return;

            this.Invoke((MethodInvoker)delegate
            {
                if (Injector.Running)
                {
                    Injector.Stop();
                    ToolStripMenuItem_Proxy.Text = "Proxy: Désactivé";
                }
                else
                {
                    Injector.Start();
                    ToolStripMenuItem_Proxy.Text = "Proxy: Activé";
                }
            });
        }

        private void ToolStripMenuItem_Game_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Path.Combine((string)ConfigurationManager.GetEntryByName("GamePath").Value, @"Dofus.exe"));
            }
            catch (Exception)
            { }
        }

        private void ToolStripMenuItem_Minimise_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Visible = false;
                NotifyIcon_Proxy.Visible = true;
            });
        }

        private void ToolStripMenuItem_DebugMod_Click(object sender, EventArgs e)
        {
            if(Debug)
            {
                Debug = false;
                this.Invoke((MethodInvoker)delegate { ToolStripMenuItem_DebugMod.Text = "Debug: Désactivé"; });
                ConfigurationManager.AddEntry(new ConfigEntry(false, ConfigType.BOOLEAN, "DebugMod"));
            }
            else
            {
                Debug = true;
                this.Invoke((MethodInvoker)delegate { ToolStripMenuItem_DebugMod.Text = "Debug: Activé"; });
                ConfigurationManager.AddEntry(new ConfigEntry(true, ConfigType.BOOLEAN, "DebugMod"));
            }
        }

        #endregion

        #region NotifyIcon

        private void NotifyIcon_Proxy_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Visible = true;
                NotifyIcon_Proxy.Visible = false;
            });
        }

        #endregion

        #endregion

        #region Events

        #endregion
    }
}
