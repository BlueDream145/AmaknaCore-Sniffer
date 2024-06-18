

// Generated on 04/03/2020 21:59:03
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeBuyMessage : NetworkMessage
    {
        public const uint Id = 5774;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint objectToBuyId;
        public uint quantity;
        
        public ExchangeBuyMessage()
        {
        }
        
        public ExchangeBuyMessage(uint objectToBuyId, uint quantity)
        {
            this.objectToBuyId = objectToBuyId;
            this.quantity = quantity;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)objectToBuyId);
            writer.WriteVarInt((int)quantity);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            objectToBuyId = reader.ReadVarUhInt();
            quantity = reader.ReadVarUhInt();
        }
        
    }
    
}