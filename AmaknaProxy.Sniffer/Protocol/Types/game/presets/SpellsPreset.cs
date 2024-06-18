

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class SpellsPreset : Preset
    {
        public const short Id = 519;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.SpellForPreset[] spells;
        
        public SpellsPreset()
        {
        }
        
        public SpellsPreset(short id, Types.SpellForPreset[] spells)
         : base(id)
        {
            this.spells = spells;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)spells.Length);
            foreach (var entry in spells)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            spells = new Types.SpellForPreset[limit];
            for (int i = 0; i < limit; i++)
            {
                 spells[i] = new Types.SpellForPreset();
                 spells[i].Deserialize(reader);
            }
        }
        
    }
    
}