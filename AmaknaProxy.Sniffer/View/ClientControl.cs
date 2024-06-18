using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AmaknaProxy.Engine.Client;
using AmaknaProxy.Engine.Managers;
using AmaknaProxy.API.Managers;
using static AmaknaProxy.Engine.Client.Network.ClientNetwork;
using Debug.Message;
using AmaknaProxy.API.Client.Enums;
using System.Reflection;

namespace AmaknaProxy.Engine.View
{
    public partial class ClientControl : UserControl
    {
        #region Variables

        private MainClient Client;

        public List<MessageEntry> Messages;

        private object CheckLock = new object();

        private delegate void AddMessageDelegate(MessageEntry msg);

        #endregion

        #region Builder

        public ClientControl(MainClient client)
        {
            Messages = new List<MessageEntry>();
            Client = client;
            InitializeComponent();
            Client.Network.ClientMessageReceived += ClientMessageReceived;
            Client.Network.ServerMessageReceived += ServerMessageReceived;
        }

        #endregion

        public void ClearMessages()
        {
            lock (CheckLock)
            {
                Messages = new List<MessageEntry>();
                DataGridView_PacketsList.Rows.Clear();
            }
        }
        private void ShowProperties(object msg, TreeNodeCollection node)
        {
            if (msg == null)
                return;

            try
            {
                foreach (FieldInfo field in msg.GetType().GetFields())
                {
                    string fieldValue = field.GetValue(msg).ToString();

                    if (field.Name != "Id")
                        node.Add(string.Format("{0} = {1}", field.Name, fieldValue));

                    if (field.Name == "Cancel")
                        continue;

                    if (fieldValue.Contains("[]"))
                    {
                        int index = 0;
                        foreach (object obj in (dynamic)field.GetValue(msg))
                        {
                            ShowProperties(obj, node[node.Count - 1].Nodes.Add(string.Format("Element {0} = {1}", index.ToString(), obj.ToString())).Nodes);
                            index++;
                        }
                    }
                    else if (fieldValue.Contains("AmaknaProxy"))
                    {
                        ShowProperties(field.GetValue(msg), node[node.Count - 1].Nodes);
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void AddMessage(MessageEntry msg)
        {
            try
            {
                if (Messages.Count >= 500)
                    ClearMessages();

                lock (CheckLock)
                {
                    Messages.Add(msg);

                    int firstDisplayed = DataGridView_PacketsList.FirstDisplayedScrollingRowIndex;
                    int displayed = DataGridView_PacketsList.DisplayedRowCount(true);
                    int lastVisible = (firstDisplayed + displayed) - 1;
                    int lastIndex = DataGridView_PacketsList.RowCount - 1;

                    DataGridView_PacketsList.Rows.Add(DateTime.Now.ToString("HH:mm:ss"), msg.Origin.ToString(), msg.Id.ToString(), msg.Name);

                    foreach (DataGridViewCell cell in DataGridView_PacketsList.Rows[DataGridView_PacketsList.Rows.Count - 1].Cells)
                    {
                        switch (msg.Origin)
                        {
                            case ConnectionDestination.Client:
                                cell.Style.BackColor = Color.DeepSkyBlue;
                                break;
                            case ConnectionDestination.Server:
                                cell.Style.BackColor = Color.Salmon;
                                break;
                        }
                    }

                    if (lastVisible == lastIndex)
                    {
                        DataGridView_PacketsList.FirstDisplayedScrollingRowIndex = firstDisplayed + 1;
                    }

                }
            }
            catch (Exception ex)
            {
                WindowManager.MainWindow.Logger.Error("(Debug) Can't add message -> " + ex.Message);
            }
        }


        private void ServerMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            if (CheckBox_Enable.Checked == false)
                return;

            MessageEntry entry = new MessageEntry(e.Msg, AmaknaProxy.API.Client.Enums.ConnectionDestination.Server);
            BeginInvoke(new AddMessageDelegate(AddMessage), entry);
        }

        private void ClientMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            if (CheckBox_Enable.Checked == false)
                return;

            MessageEntry entry = new MessageEntry(e.Msg, AmaknaProxy.API.Client.Enums.ConnectionDestination.Client);
            BeginInvoke(new AddMessageDelegate(AddMessage), entry);
        }

        private void DataGridView_PacketsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (DataGridView_PacketsList.SelectedRows.Count <= 0)
                return;

            try
            {
                TreeView_InfosPacket.Nodes.Clear();

                lock (CheckLock)
                {
                    MessageEntry message = Messages[DataGridView_PacketsList.SelectedRows[0].Index];
                    ShowProperties(message.Message, TreeView_InfosPacket.Nodes);
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        private void Button_Clean_Click(object sender, EventArgs e)
        {
            ClearMessages();
        }
    }
}
