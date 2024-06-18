using AmaknaProxy.Engine.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmaknaProxy.API.Managers
{
    public class WindowManager
    {

        #region Variables

        public static MainForm MainWindow;

        public static List<Form> ActiveForms;

        private static bool IsInit;

        private static object CheckLock;

        #endregion

        #region Builder

        static WindowManager()
        {
            IsInit = false;
            CheckLock = new object();
            ActiveForms = new List<Form>();
        }

        #endregion

        #region Methods

        public static void Init(MainForm window)
        {
            MainWindow = window;
            IsInit = true;
        }

        public static void AddForm(Form form, bool thread = false)
        {
            if (IsInit == false)
                return;
            
            form.FormClosing += FormClosing;
            lock (CheckLock) { ActiveForms.Add(form); }

            if (!thread)
                form.Show();
            else
                ShowInThread(form);
        }

        public static void ShowInThread(Form form)
        {
            Thread newThread = new Thread(new ThreadStart(() => ProcessForm(form)));
            newThread.Start();
        }

        private static void ProcessForm(Form form)
        {
            if (IsInit == false)
                return;

            form.Invoke((MethodInvoker)delegate
            {
                Application.Run((Form)form);
            });

            lock (CheckLock)
            {
                if (ActiveForms.Contains(form))
                    ActiveForms.Remove(form);
            }
        }

        #endregion

        #region Events

        private static void FormClosing(object sender, System.EventArgs e)
        {
            if (sender == null || sender is Form == false || IsInit == false)
                return;

            lock (CheckLock)
            {
                if (ActiveForms.Contains(sender))
                    ActiveForms.Remove((Form)sender);
            }
        }

        #endregion

    }
}
