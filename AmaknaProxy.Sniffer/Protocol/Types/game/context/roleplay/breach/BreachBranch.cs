

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class BreachBranch
    {
        public const short Id = 558;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte room;
        public int element;
        public Types.MonsterInGroupLightInformations[] bosses;
        public double map;
        public short score;
        public short relativeScore;
        public Types.MonsterInGroupLightInformations[] monsters;
        
        public BreachBranch()
        {
        }
        
        public BreachBranch(sbyte room, int element, Types.MonsterInGroupLightInformations[] bosses, double map, short score, short relativeScore, Types.MonsterInGroupLightInformations[] monsters)
        {
            this.room = room;
            this.element = element;
            this.bosses = bosses;
            this.map = map;
            this.score = score;
            this.relativeScore = relativeScore;
            this.monsters = monsters;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(room);
            writer.WriteInt(element);
            writer.WriteShort((short)bosses.Length);
            foreach (var entry in bosses)
            {
                 entry.Serialize(writer);
            }
            writer.WriteDouble(map);
            writer.WriteShort(score);
            writer.WriteShort(relativeScore);
            writer.WriteShort((short)monsters.Length);
            foreach (var entry in monsters)
            {
                 entry.Serialize(writer);
            }
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            room = reader.ReadSbyte();
            element = reader.ReadInt();
            var limit = (ushort)reader.ReadUShort();
            bosses = new Types.MonsterInGroupLightInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 bosses[i] = new Types.MonsterInGroupLightInformations();
                 bosses[i].Deserialize(reader);
            }
            map = reader.ReadDouble();
            score = reader.ReadShort();
            relativeScore = reader.ReadShort();
            limit = (ushort)reader.ReadUShort();
            monsters = new Types.MonsterInGroupLightInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 monsters[i] = new Types.MonsterInGroupLightInformations();
                 monsters[i].Deserialize(reader);
            }
        }
        
    }
    
}