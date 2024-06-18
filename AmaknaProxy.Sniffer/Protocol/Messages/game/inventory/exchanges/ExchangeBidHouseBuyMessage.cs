

// Generated on 04/03/2020 21:59:02
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeBidHouseBuyMessage : NetworkMessage
    {
        public const uint Id = 5804;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint uid;
        public uint qty;
        public double price;
        
        public ExchangeBidHouseBuyMessage()
        {
        }
        
        public ExchangeBidHouseBuyMessage(uint uid, uint qty, double price)
        {
            this.uid = uid;
            this.qty = qty;
            this.price = price;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)uid);
            writer.WriteVarInt((int)qty);
            writer.WriteVarLong(price);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            uid = reader.ReadVarUhInt();
            qty = reader.ReadVarUhInt();
            price = reader.ReadVarUhLong();
        }
        
    }
    
}