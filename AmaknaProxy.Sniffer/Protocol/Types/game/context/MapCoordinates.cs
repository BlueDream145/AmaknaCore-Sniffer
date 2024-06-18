

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class MapCoordinates
    {
        public const short Id = 174;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public short worldX;
        public short worldY;
        
        public MapCoordinates()
        {
        }
        
        public MapCoordinates(short worldX, short worldY)
        {
            this.worldX = worldX;
            this.worldY = worldY;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            worldX = reader.ReadShort();
            worldY = reader.ReadShort();
        }
        
    }
    
}