

// Generated on 04/03/2020 21:59:08
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ServerSessionConstantString : ServerSessionConstant
    {
        public const short Id = 436;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public string value;
        
        public ServerSessionConstantString()
        {
        }
        
        public ServerSessionConstantString(uint id, string value)
         : base(id)
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