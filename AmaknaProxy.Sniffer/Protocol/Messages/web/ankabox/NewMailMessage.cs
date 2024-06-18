

// Generated on 04/03/2020 21:59:07
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class NewMailMessage : MailStatusMessage
    {
        public const uint Id = 6292;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int[] sendersAccountId;
        
        public NewMailMessage()
        {
        }
        
        public NewMailMessage(uint unread, uint total, int[] sendersAccountId)
         : base(unread, total)
        {
            this.sendersAccountId = sendersAccountId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)sendersAccountId.Length);
            foreach (var entry in sendersAccountId)
            {
                 writer.WriteInt(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            sendersAccountId = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 sendersAccountId[i] = reader.ReadInt();
            }
        }
        
    }
    
}