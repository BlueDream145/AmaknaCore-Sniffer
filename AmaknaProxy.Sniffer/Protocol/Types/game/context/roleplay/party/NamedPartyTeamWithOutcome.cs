

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class NamedPartyTeamWithOutcome
    {
        public const short Id = 470;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public Types.NamedPartyTeam team;
        public uint outcome;
        
        public NamedPartyTeamWithOutcome()
        {
        }
        
        public NamedPartyTeamWithOutcome(Types.NamedPartyTeam team, uint outcome)
        {
            this.team = team;
            this.outcome = outcome;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            team.Serialize(writer);
            writer.WriteVarShort((int)outcome);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            team = new Types.NamedPartyTeam();
            team.Deserialize(reader);
            outcome = reader.ReadVarUhShort();
        }
        
    }
    
}