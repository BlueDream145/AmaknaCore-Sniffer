

// Generated on 04/03/2020 21:59:08
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class CharacterSpellModification
    {
        public const short Id = 215;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte modificationType;
        public uint spellId;
        public Types.CharacterBaseCharacteristic value;
        
        public CharacterSpellModification()
        {
        }
        
        public CharacterSpellModification(sbyte modificationType, uint spellId, Types.CharacterBaseCharacteristic value)
        {
            this.modificationType = modificationType;
            this.spellId = spellId;
            this.value = value;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(modificationType);
            writer.WriteVarShort((int)spellId);
            value.Serialize(writer);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            modificationType = reader.ReadSbyte();
            spellId = reader.ReadVarUhShort();
            value = new Types.CharacterBaseCharacteristic();
            value.Deserialize(reader);
        }
        
    }
    
}