

// Generated on 04/03/2020 21:58:51
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ForgettableSpellEquipmentSlotsMessage : NetworkMessage
    {
        public const uint Id = 6870;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int quantity;
        
        public ForgettableSpellEquipmentSlotsMessage()
        {
        }
        
        public ForgettableSpellEquipmentSlotsMessage(int quantity)
        {
            this.quantity = quantity;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)quantity);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            quantity = reader.ReadVarShort();
        }
        
    }
    
}