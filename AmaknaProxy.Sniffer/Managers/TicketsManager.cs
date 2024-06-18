using AmaknaProxy.API.Protocol.Messages;
using AmaknaProxy.Engine.Utils.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.Engine.Managers
{
    public class TicketsManager
    {

        #region Variables

        public static List<TicketEntry> Tickets;

        private static object CheckLock;

        #endregion

        #region Builder

        static TicketsManager()
        {
            Tickets = new List<Utils.Tickets.TicketEntry>();
            CheckLock = new object();
        }

        #endregion

        #region Methods

        public static void RegisterTicket(string accountName, uint instance, SelectedServerDataMessage serverMsg)
        {
            lock(CheckLock) { Tickets.Add(new TicketEntry(accountName, instance, serverMsg)); }
        } 

        public static TicketEntry GetTicket()
        {
            if (Tickets.Count == 0)
                return null;

            TicketEntry entry = Tickets[Tickets.Count - 1];
            lock (CheckLock) { Tickets.Remove(entry); }
            return entry;

        }

        #endregion
    }
}
