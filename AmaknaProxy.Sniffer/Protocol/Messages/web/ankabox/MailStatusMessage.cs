

// Generated on 04/03/2020 21:59:07
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MailStatusMessage : NetworkMessage
    {
        public const uint Id = 6275;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint unread;
        public uint total;
        
        public MailStatusMessage()
        {
        }
        
        public MailStatusMessage(uint unread, uint total)
        {
            this.unread = unread;
            this.total = total;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)unread);
            writer.WriteVarShort((int)total);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            unread = reader.ReadVarUhShort();
            total = reader.ReadVarUhShort();
        }
        
    }
    
}