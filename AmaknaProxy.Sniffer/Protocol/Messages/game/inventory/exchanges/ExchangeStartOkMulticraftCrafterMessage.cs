

// Generated on 04/03/2020 21:59:04
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeStartOkMulticraftCrafterMessage : NetworkMessage
    {
        public const uint Id = 5818;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint skillId;
        
        public ExchangeStartOkMulticraftCrafterMessage()
        {
        }
        
        public ExchangeStartOkMulticraftCrafterMessage(uint skillId)
        {
            this.skillId = skillId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)skillId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            skillId = reader.ReadVarUhInt();
        }
        
    }
    
}