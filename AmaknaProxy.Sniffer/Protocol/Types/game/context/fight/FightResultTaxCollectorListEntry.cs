

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
    {
        public const short Id = 84;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public byte level;
        public Types.BasicGuildInformations guildInfo;
        public int experienceForGuild;
        
        public FightResultTaxCollectorListEntry()
        {
        }
        
        public FightResultTaxCollectorListEntry(uint outcome, sbyte wave, Types.FightLoot rewards, double id, bool alive, byte level, Types.BasicGuildInformations guildInfo, int experienceForGuild)
         : base(outcome, wave, rewards, id, alive)
        {
            this.level = level;
            this.guildInfo = guildInfo;
            this.experienceForGuild = experienceForGuild;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(level);
            guildInfo.Serialize(writer);
            writer.WriteInt(experienceForGuild);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            level = reader.ReadByte();
            guildInfo = new Types.BasicGuildInformations();
            guildInfo.Deserialize(reader);
            experienceForGuild = reader.ReadInt();
        }
        
    }
    
}