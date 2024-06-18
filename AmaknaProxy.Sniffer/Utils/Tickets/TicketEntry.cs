using AmaknaProxy.API.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.Engine.Utils.Tickets
{
    public class TicketEntry
    {
        public string AccountName;
        public uint Instance;
        public SelectedServerDataMessage ServerMsg;

        public TicketEntry(string _accountName, uint _instance, SelectedServerDataMessage _serverMsg)
        {
            AccountName = _accountName;
            Instance = _instance;
            ServerMsg = _serverMsg;
        }
    }
}
