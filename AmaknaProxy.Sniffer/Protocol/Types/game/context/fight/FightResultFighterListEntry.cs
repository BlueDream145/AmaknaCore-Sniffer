

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FightResultFighterListEntry : FightResultListEntry
    {
        public const short Id = 189;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public double id;
        public bool alive;
        
        public FightResultFighterListEntry()
        {
        }
        
        public FightResultFighterListEntry(uint outcome, sbyte wave, Types.FightLoot rewards, double id, bool alive)
         : base(outcome, wave, rewards)
        {
            this.id = id;
            this.alive = alive;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(id);
            writer.WriteBoolean(alive);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            id = reader.ReadDouble();
            alive = reader.ReadBoolean();
        }
        
    }
    
}