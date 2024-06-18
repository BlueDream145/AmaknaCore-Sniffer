

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class HouseInformationsInside : HouseInformations
    {
        public const short Id = 218;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.HouseInstanceInformations houseInfos;
        public short worldX;
        public short worldY;
        
        public HouseInformationsInside()
        {
        }
        
        public HouseInformationsInside(uint houseId, uint modelId, Types.HouseInstanceInformations houseInfos, short worldX, short worldY)
         : base(houseId, modelId)
        {
            this.houseInfos = houseInfos;
            this.worldX = worldX;
            this.worldY = worldY;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(houseInfos.TypeId);
            houseInfos.Serialize(writer);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            houseInfos = ProtocolTypeManager.GetInstance<Types.HouseInstanceInformations>(reader.ReadUShort());
            houseInfos.Deserialize(reader);
            worldX = reader.ReadShort();
            worldY = reader.ReadShort();
        }
        
    }
    
}