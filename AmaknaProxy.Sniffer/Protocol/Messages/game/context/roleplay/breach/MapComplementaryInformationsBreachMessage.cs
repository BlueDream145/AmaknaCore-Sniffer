

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MapComplementaryInformationsBreachMessage : MapComplementaryInformationsDataMessage
    {
        public const uint Id = 6791;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint floor;
        public sbyte room;
        public short infinityMode;
        public Types.BreachBranch[] branches;
        
        public MapComplementaryInformationsBreachMessage()
        {
        }
        
        public MapComplementaryInformationsBreachMessage(uint subAreaId, double mapId, Types.HouseInformations[] houses, Types.GameRolePlayActorInformations[] actors, Types.InteractiveElement[] interactiveElements, Types.StatedElement[] statedElements, Types.MapObstacle[] obstacles, Types.FightCommonInformations[] fights, bool hasAggressiveMonsters, Types.FightStartingPositions fightStartPositions, uint floor, sbyte room, short infinityMode, Types.BreachBranch[] branches)
         : base(subAreaId, mapId, houses, actors, interactiveElements, statedElements, obstacles, fights, hasAggressiveMonsters, fightStartPositions)
        {
            this.floor = floor;
            this.room = room;
            this.infinityMode = infinityMode;
            this.branches = branches;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)floor);
            writer.WriteSbyte(room);
            writer.WriteShort(infinityMode);
            writer.WriteShort((short)branches.Length);
            foreach (var entry in branches)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            floor = reader.ReadVarUhInt();
            room = reader.ReadSbyte();
            infinityMode = reader.ReadShort();
            var limit = (ushort)reader.ReadUShort();
            branches = new Types.BreachBranch[limit];
            for (int i = 0; i < limit; i++)
            {
                 branches[i] = ProtocolTypeManager.GetInstance<Types.BreachBranch>(reader.ReadUShort());
                 branches[i].Deserialize(reader);
            }
        }
        
    }
    
}