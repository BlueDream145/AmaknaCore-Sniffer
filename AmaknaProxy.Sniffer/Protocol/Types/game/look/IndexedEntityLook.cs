

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class IndexedEntityLook
    {
        public const short Id = 405;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public Types.EntityLook look;
        public sbyte index;
        
        public IndexedEntityLook()
        {
        }
        
        public IndexedEntityLook(Types.EntityLook look, sbyte index)
        {
            this.look = look;
            this.index = index;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            look.Serialize(writer);
            writer.WriteSbyte(index);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            look = new Types.EntityLook();
            look.Deserialize(reader);
            index = reader.ReadSbyte();
        }
        
    }
    
}