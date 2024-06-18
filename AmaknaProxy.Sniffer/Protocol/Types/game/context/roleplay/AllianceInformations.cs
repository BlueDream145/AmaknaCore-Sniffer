

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class AllianceInformations : BasicNamedAllianceInformations
    {
        public const short Id = 417;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.GuildEmblem allianceEmblem;
        
        public AllianceInformations()
        {
        }
        
        public AllianceInformations(uint allianceId, string allianceTag, string allianceName, Types.GuildEmblem allianceEmblem)
         : base(allianceId, allianceTag, allianceName)
        {
            this.allianceEmblem = allianceEmblem;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            allianceEmblem.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            allianceEmblem = new Types.GuildEmblem();
            allianceEmblem.Deserialize(reader);
        }
        
    }
    
}