

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class SimpleCharacterCharacteristicForPreset
    {
        public const short Id = 541;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public string keyword;
        public int @base;
        public int additionnal;
        
        public SimpleCharacterCharacteristicForPreset()
        {
        }
        
        public SimpleCharacterCharacteristicForPreset(string keyword, int @base, int additionnal)
        {
            this.keyword = keyword;
            this.@base = @base;
            this.additionnal = additionnal;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(keyword);
            writer.WriteVarShort((int)@base);
            writer.WriteVarShort((int)additionnal);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            keyword = reader.ReadUTF();
            @base = reader.ReadVarShort();
            additionnal = reader.ReadVarShort();
        }
        
    }
    
}