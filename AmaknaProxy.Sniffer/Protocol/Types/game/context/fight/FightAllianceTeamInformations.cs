

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FightAllianceTeamInformations : FightTeamInformations
    {
        public const short Id = 439;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte relation;
        
        public FightAllianceTeamInformations()
        {
        }
        
        public FightAllianceTeamInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves, Types.FightTeamMemberInformations[] teamMembers, sbyte relation)
         : base(teamId, leaderId, teamSide, teamTypeId, nbWaves, teamMembers)
        {
            this.relation = relation;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSbyte(relation);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            relation = reader.ReadSbyte();
        }
        
    }
    
}