

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ItemsPreset : Preset
    {
        public const short Id = 517;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.ItemForPreset[] items;
        public bool mountEquipped;
        public Types.EntityLook look;
        
        public ItemsPreset()
        {
        }
        
        public ItemsPreset(short id, Types.ItemForPreset[] items, bool mountEquipped, Types.EntityLook look)
         : base(id)
        {
            this.items = items;
            this.mountEquipped = mountEquipped;
            this.look = look;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)items.Length);
            foreach (var entry in items)
            {
                 entry.Serialize(writer);
            }
            writer.WriteBoolean(mountEquipped);
            look.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            items = new Types.ItemForPreset[limit];
            for (int i = 0; i < limit; i++)
            {
                 items[i] = new Types.ItemForPreset();
                 items[i].Deserialize(reader);
            }
            mountEquipped = reader.ReadBoolean();
            look = new Types.EntityLook();
            look.Deserialize(reader);
        }
        
    }
    
}