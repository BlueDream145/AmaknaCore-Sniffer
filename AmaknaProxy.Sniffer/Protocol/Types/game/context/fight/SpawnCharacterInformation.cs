

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class SpawnCharacterInformation : SpawnInformation
    {
        public const short Id = 574;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public string name;
        public uint level;
        
        public SpawnCharacterInformation()
        {
        }
        
        public SpawnCharacterInformation(string name, uint level)
        {
            this.name = name;
            this.level = level;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(name);
            writer.WriteVarShort((int)level);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            name = reader.ReadUTF();
            level = reader.ReadVarUhShort();
        }
        
    }
    
}