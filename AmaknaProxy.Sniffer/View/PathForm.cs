using AmaknaProxy.Engine.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmaknaProxy.Engine.View
{
    public partial class PathForm : Form
    {
        #region Builder

        public PathForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Components

        private void Button_Apply_Click(object sender, EventArgs e)
        {
            if (TextBox_Path.Text.Contains("dofus") == false)
            {
                MessageBox.Show("Répertoire invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConfigurationManager.AddEntry(new Utils.Config.ConfigEntry(TextBox_Path.Text, Utils.Config.ConfigType.STRING, "GamePath"));
            ConfigurationManager.SerializeConfig();

            this.Invoke((MethodInvoker)delegate
            {
                Close();
                Dispose();
            });
        }

        private void Button_Browse_Click(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
