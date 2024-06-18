

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class SkillActionDescriptionCollect : SkillActionDescriptionTimed
    {
        public const short Id = 99;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public uint min;
        public uint max;
        
        public SkillActionDescriptionCollect()
        {
        }
        
        public SkillActionDescriptionCollect(uint skillId, byte time, uint min, uint max)
         : base(skillId, time)
        {
            this.min = min;
            this.max = max;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((int)min);
            writer.WriteVarShort((int)max);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            min = reader.ReadVarUhShort();
            max = reader.ReadVarUhShort();
        }
        
    }
    
}