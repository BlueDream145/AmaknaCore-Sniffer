

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ObjectEffect
    {
        public const short Id = 76;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint actionId;
        
        public ObjectEffect()
        {
        }
        
        public ObjectEffect(uint actionId)
        {
            this.actionId = actionId;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)actionId);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            actionId = reader.ReadVarUhShort();
        }
        
    }
    
}