

// Generated on 04/03/2020 21:59:04
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeWeightMessage : NetworkMessage
    {
        public const uint Id = 5793;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint currentWeight;
        public uint maxWeight;
        
        public ExchangeWeightMessage()
        {
        }
        
        public ExchangeWeightMessage(uint currentWeight, uint maxWeight)
        {
            this.currentWeight = currentWeight;
            this.maxWeight = maxWeight;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)currentWeight);
            writer.WriteVarInt((int)maxWeight);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            currentWeight = reader.ReadVarUhInt();
            maxWeight = reader.ReadVarUhInt();
        }
        
    }
    
}