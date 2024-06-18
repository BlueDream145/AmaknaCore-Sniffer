

// Generated on 04/03/2020 21:59:03
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeBidPriceMessage : NetworkMessage
    {
        public const uint Id = 5755;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint genericId;
        public double averagePrice;
        
        public ExchangeBidPriceMessage()
        {
        }
        
        public ExchangeBidPriceMessage(uint genericId, double averagePrice)
        {
            this.genericId = genericId;
            this.averagePrice = averagePrice;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)genericId);
            writer.WriteVarLong(averagePrice);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            genericId = reader.ReadVarUhShort();
            averagePrice = reader.ReadVarLong();
        }
        
    }
    
}