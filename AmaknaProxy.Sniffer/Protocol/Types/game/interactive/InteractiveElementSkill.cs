

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class InteractiveElementSkill
    {
        public const short Id = 219;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint skillId;
        public int skillInstanceUid;
        
        public InteractiveElementSkill()
        {
        }
        
        public InteractiveElementSkill(uint skillId, int skillInstanceUid)
        {
            this.skillId = skillId;
            this.skillInstanceUid = skillInstanceUid;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)skillId);
            writer.WriteInt(skillInstanceUid);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            skillId = reader.ReadVarUhInt();
            skillInstanceUid = reader.ReadInt();
        }
        
    }
    
}