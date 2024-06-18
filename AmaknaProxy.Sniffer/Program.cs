using AmaknaProxy.API.Managers;
using AmaknaProxy.API.Protocol;
using AmaknaProxy.API.Utils.Logger;
using AmaknaProxy.Engine.Managers;
using AmaknaProxy.Engine.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmaknaProxy.Sniffer
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (System.Diagnostics.Process.GetProcessesByName("AmaknaProxy.Sniffer").Length > 1)
                return;
            WindowManager.Init(new MainForm());
            Application.Run(((MainForm)WindowManager.MainWindow));
        }

        public static void LoadProgram(ContainerLogger logger)
        {
            int time = Environment.TickCount;

            ConsoleManager.InitLogger(logger);
            logger.Info("#Démarrage de la solution...");

            if (!ConfigurationManager.IsFileExists() || ConfigurationManager.GetEntryByName("GamePath") == null)
            {
                logger.Warning("Aucun fichier de configuration trouvé.");

                ConfigurationManager.SerializeConfig();

                Application.Run(new PathForm());

                if (ConfigurationManager.GetEntryByName("GamePath") == null)
                {
                    System.Environment.Exit(1);
                    return;
                }

                logger.Debug("Configuration définie.");
            }
            else
            {
                ConfigurationManager.DeserializeConfig();
                logger.Debug("Fichier de configuration chargé.");
            }

            ProtocolTypeManager.Initialize();
            MessageReceiver.Initialize();

            try
            {
                NetworkManager.StartServers();
                logger.Debug("Serveurs démarrés.");
            }
            catch (Exception ex)
            {
                logger.Error("[SERVERS] " + ex.Message);
                logger.Error("SERVERS - OFF");
            }

            logger.Debug(string.Format("{0}ms", Environment.TickCount - time));

            OnProgramLoaded(null);
        }

        #region Events

        public static event EventHandler<ProgramLoadedEventArgs> ProgramLoaded;

        private static void OnProgramLoaded(ProgramLoadedEventArgs e)
        {
            if (ProgramLoaded != null)
                ProgramLoaded(null, e);
        }

        public class ProgramLoadedEventArgs : EventArgs
        { }

        #endregion
    }
}
