

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MapObstacleUpdateMessage : NetworkMessage
    {
        public const uint Id = 6051;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.MapObstacle[] obstacles;
        
        public MapObstacleUpdateMessage()
        {
        }
        
        public MapObstacleUpdateMessage(Types.MapObstacle[] obstacles)
        {
            this.obstacles = obstacles;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)obstacles.Length);
            foreach (var entry in obstacles)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            obstacles = new Types.MapObstacle[limit];
            for (int i = 0; i < limit; i++)
            {
                 obstacles[i] = new Types.MapObstacle();
                 obstacles[i].Deserialize(reader);
            }
        }
        
    }
    
}