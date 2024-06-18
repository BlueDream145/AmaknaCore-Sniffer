

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ExtendedBreachBranch : BreachBranch
    {
        public const short Id = 560;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.BreachReward[] rewards;
        public int modifier;
        public uint prize;
        
        public ExtendedBreachBranch()
        {
        }
        
        public ExtendedBreachBranch(sbyte room, int element, Types.MonsterInGroupLightInformations[] bosses, double map, short score, short relativeScore, Types.MonsterInGroupLightInformations[] monsters, Types.BreachReward[] rewards, int modifier, uint prize)
         : base(room, element, bosses, map, score, relativeScore, monsters)
        {
            this.rewards = rewards;
            this.modifier = modifier;
            this.prize = prize;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)rewards.Length);
            foreach (var entry in rewards)
            {
                 entry.Serialize(writer);
            }
            writer.WriteVarInt((int)modifier);
            writer.WriteVarInt((int)prize);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            rewards = new Types.BreachReward[limit];
            for (int i = 0; i < limit; i++)
            {
                 rewards[i] = new Types.BreachReward();
                 rewards[i].Deserialize(reader);
            }
            modifier = reader.ReadVarInt();
            prize = reader.ReadVarUhInt();
        }
        
    }
    
}