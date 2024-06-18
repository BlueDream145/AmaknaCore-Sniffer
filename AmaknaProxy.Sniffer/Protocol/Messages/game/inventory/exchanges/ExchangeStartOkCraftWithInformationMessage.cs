

// Generated on 04/03/2020 21:59:04
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeStartOkCraftWithInformationMessage : ExchangeStartOkCraftMessage
    {
        public const uint Id = 5941;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint skillId;
        
        public ExchangeStartOkCraftWithInformationMessage()
        {
        }
        
        public ExchangeStartOkCraftWithInformationMessage(uint skillId)
        {
            this.skillId = skillId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)skillId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            skillId = reader.ReadVarUhInt();
        }
        
    }
    
}