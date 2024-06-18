

// Generated on 04/03/2020 21:59:05
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ObtainedItemMessage : NetworkMessage
    {
        public const uint Id = 6519;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint genericId;
        public uint baseQuantity;
        
        public ObtainedItemMessage()
        {
        }
        
        public ObtainedItemMessage(uint genericId, uint baseQuantity)
        {
            this.genericId = genericId;
            this.baseQuantity = baseQuantity;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)genericId);
            writer.WriteVarInt((int)baseQuantity);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            genericId = reader.ReadVarUhShort();
            baseQuantity = reader.ReadVarUhInt();
        }
        
    }
    
}