

// Generated on 04/03/2020 21:58:53
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PaddockBuyRequestMessage : NetworkMessage
    {
        public const uint Id = 5951;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double proposedPrice;
        
        public PaddockBuyRequestMessage()
        {
        }
        
        public PaddockBuyRequestMessage(double proposedPrice)
        {
            this.proposedPrice = proposedPrice;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(proposedPrice);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            proposedPrice = reader.ReadVarUhLong();
        }
        
    }
    
}