using AmaknaProxy.API.Managers;
using AmaknaProxy.API.Utils.Logger;
using AmaknaProxy.Engine.Managers;
using AmaknaProxy.Hooks;
using AmaknaProxy.Sniffer;
using EasyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.Remoting;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace AmaknaProxy.Engine.Utils.Injector
{
    public class AutoInjector
    {

        #region Variables

        // Local

        public List<int> PatchedClients;

        //private Timer timer;

        public bool Running;

        public ContainerLogger Logger;

        private Object thisLock = new Object();

        private WqlEventQuery query;
        private ManagementEventWatcher watcher;

        // Data

        private string ProcessName;

        private string FilePath;

        static string ChannelName = null;

        #endregion

        #region Builder

        public AutoInjector(string processName, string filePath, ContainerLogger logger)
        {
            RemoteHooking.IpcCreateServer<HookInterface>(ref ChannelName, WellKnownObjectMode.Singleton);
            PatchedClients = new List<int>();
            ProcessName = processName;
            FilePath = filePath;
            Running = false;
            Logger = logger;

            try
            {
                ExistingProcessInjection();
            }
            catch (Exception ex) { Logger.Error("(ProcessInjector) " + ex.Message); }
        }

        #endregion

        #region Methods

        public void Start()
        {
            if (Running == true)
                return;

            Running = true;
            ActiveListeningForDofus();
        }

        private void ActiveListeningForDofus()
        {
            query = new WqlEventQuery("__InstanceCreationEvent", new TimeSpan(0, 0, 1), "TargetInstance isa \"Win32_Process\"");
            watcher = new ManagementEventWatcher(query);
            watcher.EventArrived += new EventArrivedEventHandler(Watcher_EventArrived);
            watcher.Start();
        }

        public void Stop()
        {
            if (Running == false)
                return;

            Running = false;
            watcher.EventArrived -= Watcher_EventArrived;
            watcher.Stop();
            watcher.Dispose();
        }

        private void ExistingProcessInjection()
        {

            lock (thisLock)
            {
                List<Process> processList = Process.GetProcessesByName(ProcessName).ToList<Process>();

                foreach (Process prc in processList)
                {
                    //PatchedClients n'est plus utilisé
                    prc.WaitForInputIdle();

                    string result;
                    try
                    {
                        RemoteHooking.Inject(prc.Id, FilePath, FilePath, ChannelName, Constants.LoginAddresses.ToList(), 5555);
                        result = "Success";

                    }
                    catch (Exception ex)
                    {
                        Logger.Error("(ProcessInjector) " + ex.Message);
                        result = "Failed";
                    }

                    ConsoleManager.Debug(string.Format("Existing Process Injection Result: ID={0}; RESULT={1};", prc.Id, result.ToString()));
                }
            }
        }

        private void SingleProcessInjection(int processId)
        {
            string result;

            try
            {
                RemoteHooking.Inject(processId, FilePath, FilePath, ChannelName, Constants.LoginAddresses.ToList(), 5555);
                result = "Success";

            }
            catch (Exception ex)
            {
                Logger.Error("(SingleProcessInjection) " + ex.Message);
                result = "Failed";
            }

            ConsoleManager.Debug(string.Format("Single Process Injection Result: ID={0}; RESULT={1};", processId, result.ToString()));
        }

        /// <summary>
        /// Evenement d'ecoute de l'ouverture d'un nouveau client dofus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject TargetInstance = ((ManagementBaseObject)e.NewEvent["TargetInstance"]);
            string instanceName = TargetInstance.GetPropertyValue("Name").ToString();
            if (instanceName.ToLower() == "dofus.exe")
            {
                //try
                //{
                    int ProessID = Convert.ToInt32(TargetInstance.GetPropertyValue("ProcessId"));
                    Process ClientProcess = Process.GetProcessById(ProessID);
                    Thread.Sleep(3000);
                    SingleProcessInjection(ProessID);
                //}
                //catch (Exception) { }
            }
        }
        #endregion

    }
}
