using AmaknaProxy.API.Client.Enums;
using AmaknaProxy.API.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debug.Message
{
    public class MessageEntry
    {

        #region Variables

        public NetworkMessage Message;

        public uint Id;

        public string Name;

        public ConnectionDestination Origin;

        #endregion

        #region Builder

        public MessageEntry(NetworkMessage msg, ConnectionDestination origin)
        {
            Message = msg;
            Origin = origin;
            Id = msg.MessageId;
            Name = msg.ToString();
        }

        #endregion

    }
}
