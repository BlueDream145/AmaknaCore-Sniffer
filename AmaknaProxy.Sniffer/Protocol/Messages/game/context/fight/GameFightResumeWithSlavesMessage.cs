

// Generated on 04/03/2020 21:58:53
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameFightResumeWithSlavesMessage : GameFightResumeMessage
    {
        public const uint Id = 6215;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GameFightResumeSlaveInfo[] slavesInfo;
        
        public GameFightResumeWithSlavesMessage()
        {
        }
        
        public GameFightResumeWithSlavesMessage(Types.FightDispellableEffectExtendedInformations[] effects, Types.GameActionMark[] marks, uint gameTurn, int fightStart, Types.Idol[] idols, Types.GameFightEffectTriggerCount[] fxTriggerCounts, Types.GameFightSpellCooldown[] spellCooldowns, sbyte summonCount, sbyte bombCount, Types.GameFightResumeSlaveInfo[] slavesInfo)
         : base(effects, marks, gameTurn, fightStart, idols, fxTriggerCounts, spellCooldowns, summonCount, bombCount)
        {
            this.slavesInfo = slavesInfo;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)slavesInfo.Length);
            foreach (var entry in slavesInfo)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            slavesInfo = new Types.GameFightResumeSlaveInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 slavesInfo[i] = new Types.GameFightResumeSlaveInfo();
                 slavesInfo[i].Deserialize(reader);
            }
        }
        
    }
    
}