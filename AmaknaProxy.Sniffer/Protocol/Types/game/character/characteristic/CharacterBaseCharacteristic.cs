

// Generated on 04/03/2020 21:59:08
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class CharacterBaseCharacteristic
    {
        public const short Id = 4;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int @base;
        public int additionnal;
        public int objectsAndMountBonus;
        public int alignGiftBonus;
        public int contextModif;
        
        public CharacterBaseCharacteristic()
        {
        }
        
        public CharacterBaseCharacteristic(int @base, int additionnal, int objectsAndMountBonus, int alignGiftBonus, int contextModif)
        {
            this.@base = @base;
            this.additionnal = additionnal;
            this.objectsAndMountBonus = objectsAndMountBonus;
            this.alignGiftBonus = alignGiftBonus;
            this.contextModif = contextModif;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)@base);
            writer.WriteVarShort((int)additionnal);
            writer.WriteVarShort((int)objectsAndMountBonus);
            writer.WriteVarShort((int)alignGiftBonus);
            writer.WriteVarShort((int)contextModif);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            @base = reader.ReadVarShort();
            additionnal = reader.ReadVarShort();
            objectsAndMountBonus = reader.ReadVarShort();
            alignGiftBonus = reader.ReadVarShort();
            contextModif = reader.ReadVarShort();
        }
        
    }
    
}