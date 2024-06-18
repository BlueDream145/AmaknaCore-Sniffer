

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PaddockToSellFilterMessage : NetworkMessage
    {
        public const uint Id = 6161;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int areaId;
        public sbyte atLeastNbMount;
        public sbyte atLeastNbMachine;
        public double maxPrice;
        public sbyte orderBy;
        
        public PaddockToSellFilterMessage()
        {
        }
        
        public PaddockToSellFilterMessage(int areaId, sbyte atLeastNbMount, sbyte atLeastNbMachine, double maxPrice, sbyte orderBy)
        {
            this.areaId = areaId;
            this.atLeastNbMount = atLeastNbMount;
            this.atLeastNbMachine = atLeastNbMachine;
            this.maxPrice = maxPrice;
            this.orderBy = orderBy;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(areaId);
            writer.WriteSbyte(atLeastNbMount);
            writer.WriteSbyte(atLeastNbMachine);
            writer.WriteVarLong(maxPrice);
            writer.WriteSbyte(orderBy);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            areaId = reader.ReadInt();
            atLeastNbMount = reader.ReadSbyte();
            atLeastNbMachine = reader.ReadSbyte();
            maxPrice = reader.ReadVarUhLong();
            orderBy = reader.ReadSbyte();
        }
        
    }
    
}