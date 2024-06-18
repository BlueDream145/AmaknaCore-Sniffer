

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class PrismGeolocalizedInformation : PrismSubareaEmptyInfo
    {
        public const short Id = 434;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short worldX;
        public short worldY;
        public double mapId;
        public Types.PrismInformation prism;
        
        public PrismGeolocalizedInformation()
        {
        }
        
        public PrismGeolocalizedInformation(uint subAreaId, uint allianceId, short worldX, short worldY, double mapId, Types.PrismInformation prism)
         : base(subAreaId, allianceId)
        {
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.prism = prism;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteDouble(mapId);
            writer.WriteShort(prism.TypeId);
            prism.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            worldX = reader.ReadShort();
            worldY = reader.ReadShort();
            mapId = reader.ReadDouble();
            prism = ProtocolTypeManager.GetInstance<Types.PrismInformation>(reader.ReadUShort());
            prism.Deserialize(reader);
        }
        
    }
    
}