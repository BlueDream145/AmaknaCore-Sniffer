

// Generated on 04/03/2020 21:58:53
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachGameFightEndMessage : GameFightEndMessage
    {
        public const uint Id = 6809;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int budget;
        
        public BreachGameFightEndMessage()
        {
        }
        
        public BreachGameFightEndMessage(int duration, int rewardRate, short lootShareLimitMalus, Types.FightResultListEntry[] results, Types.NamedPartyTeamWithOutcome[] namedPartyTeamsOutcomes, int budget)
         : base(duration, rewardRate, lootShareLimitMalus, results, namedPartyTeamsOutcomes)
        {
            this.budget = budget;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(budget);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            budget = reader.ReadInt();
        }
        
    }
    
}