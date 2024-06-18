

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class BasicNamedAllianceInformations : BasicAllianceInformations
    {
        public const short Id = 418;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public string allianceName;
        
        public BasicNamedAllianceInformations()
        {
        }
        
        public BasicNamedAllianceInformations(uint allianceId, string allianceTag, string allianceName)
         : base(allianceId, allianceTag)
        {
            this.allianceName = allianceName;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(allianceName);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            allianceName = reader.ReadUTF();
        }
        
    }
    
}