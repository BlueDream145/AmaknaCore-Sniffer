

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MapComplementaryInformationsDataMessage : NetworkMessage
    {
        public const uint Id = 226;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint subAreaId;
        public double mapId;
        public Types.HouseInformations[] houses;
        public Types.GameRolePlayActorInformations[] actors;
        public Types.InteractiveElement[] interactiveElements;
        public Types.StatedElement[] statedElements;
        public Types.MapObstacle[] obstacles;
        public Types.FightCommonInformations[] fights;
        public bool hasAggressiveMonsters;
        public Types.FightStartingPositions fightStartPositions;
        
        public MapComplementaryInformationsDataMessage()
        {
        }
        
        public MapComplementaryInformationsDataMessage(uint subAreaId, double mapId, Types.HouseInformations[] houses, Types.GameRolePlayActorInformations[] actors, Types.InteractiveElement[] interactiveElements, Types.StatedElement[] statedElements, Types.MapObstacle[] obstacles, Types.FightCommonInformations[] fights, bool hasAggressiveMonsters, Types.FightStartingPositions fightStartPositions)
        {
            this.subAreaId = subAreaId;
            this.mapId = mapId;
            this.houses = houses;
            this.actors = actors;
            this.interactiveElements = interactiveElements;
            this.statedElements = statedElements;
            this.obstacles = obstacles;
            this.fights = fights;
            this.hasAggressiveMonsters = hasAggressiveMonsters;
            this.fightStartPositions = fightStartPositions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)subAreaId);
            writer.WriteDouble(mapId);
            writer.WriteShort((short)houses.Length);
            foreach (var entry in houses)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)actors.Length);
            foreach (var entry in actors)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)interactiveElements.Length);
            foreach (var entry in interactiveElements)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)statedElements.Length);
            foreach (var entry in statedElements)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)obstacles.Length);
            foreach (var entry in obstacles)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)fights.Length);
            foreach (var entry in fights)
            {
                 entry.Serialize(writer);
            }
            writer.WriteBoolean(hasAggressiveMonsters);
            fightStartPositions.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            subAreaId = reader.ReadVarUhShort();
            mapId = reader.ReadDouble();
            var limit = (ushort)reader.ReadUShort();
            houses = new Types.HouseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 houses[i] = ProtocolTypeManager.GetInstance<Types.HouseInformations>(reader.ReadUShort());
                 houses[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            actors = new Types.GameRolePlayActorInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 actors[i] = ProtocolTypeManager.GetInstance<Types.GameRolePlayActorInformations>(reader.ReadUShort());
                 actors[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            interactiveElements = new Types.InteractiveElement[limit];
            for (int i = 0; i < limit; i++)
            {
                 interactiveElements[i] = ProtocolTypeManager.GetInstance<Types.InteractiveElement>(reader.ReadUShort());
                 interactiveElements[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            statedElements = new Types.StatedElement[limit];
            for (int i = 0; i < limit; i++)
            {
                 statedElements[i] = new Types.StatedElement();
                 statedElements[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            obstacles = new Types.MapObstacle[limit];
            for (int i = 0; i < limit; i++)
            {
                 obstacles[i] = new Types.MapObstacle();
                 obstacles[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            fights = new Types.FightCommonInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fights[i] = new Types.FightCommonInformations();
                 fights[i].Deserialize(reader);
            }
            hasAggressiveMonsters = reader.ReadBoolean();
            fightStartPositions = new Types.FightStartingPositions();
            fightStartPositions.Deserialize(reader);
        }
        
    }
    
}