

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class MonsterInGroupInformations : MonsterInGroupLightInformations
    {
        public const short Id = 144;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.EntityLook look;
        
        public MonsterInGroupInformations()
        {
        }
        
        public MonsterInGroupInformations(int genericId, sbyte grade, short level, Types.EntityLook look)
         : base(genericId, grade, level)
        {
            this.look = look;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            look.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            look = new Types.EntityLook();
            look.Deserialize(reader);
        }
        
    }
    
}