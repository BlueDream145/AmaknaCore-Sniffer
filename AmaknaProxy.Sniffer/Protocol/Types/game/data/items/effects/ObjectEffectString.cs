

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ObjectEffectString : ObjectEffect
    {
        public const short Id = 74;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public string value;
        
        public ObjectEffectString()
        {
        }
        
        public ObjectEffectString(uint actionId, string value)
         : base(actionId)
        {
            this.value = value;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(value);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            value = reader.ReadUTF();
        }
        
    }
    
}