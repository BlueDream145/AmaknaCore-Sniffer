

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ShortcutObjectIdolsPreset : ShortcutObject
    {
        public const short Id = 492;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short presetId;
        
        public ShortcutObjectIdolsPreset()
        {
        }
        
        public ShortcutObjectIdolsPreset(sbyte slot, short presetId)
         : base(slot)
        {
            this.presetId = presetId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(presetId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            presetId = reader.ReadShort();
        }
        
    }
    
}