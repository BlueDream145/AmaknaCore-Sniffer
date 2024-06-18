

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class HouseInformations
    {
        public const short Id = 111;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint houseId;
        public uint modelId;
        
        public HouseInformations()
        {
        }
        
        public HouseInformations(uint houseId, uint modelId)
        {
            this.houseId = houseId;
            this.modelId = modelId;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)houseId);
            writer.WriteVarShort((int)modelId);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadVarUhInt();
            modelId = reader.ReadVarUhShort();
        }
        
    }
    
}