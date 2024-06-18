

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ShortcutObjectPreset : ShortcutObject
    {
        public const short Id = 370;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short presetId;
        
        public ShortcutObjectPreset()
        {
        }
        
        public ShortcutObjectPreset(sbyte slot, short presetId)
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