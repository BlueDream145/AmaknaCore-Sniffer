

// Generated on 04/03/2020 21:59:05
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ObtainedItemWithBonusMessage : ObtainedItemMessage
    {
        public const uint Id = 6520;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint bonusQuantity;
        
        public ObtainedItemWithBonusMessage()
        {
        }
        
        public ObtainedItemWithBonusMessage(uint genericId, uint baseQuantity, uint bonusQuantity)
         : base(genericId, baseQuantity)
        {
            this.bonusQuantity = bonusQuantity;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)bonusQuantity);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            bonusQuantity = reader.ReadVarUhInt();
        }
        
    }
    
}