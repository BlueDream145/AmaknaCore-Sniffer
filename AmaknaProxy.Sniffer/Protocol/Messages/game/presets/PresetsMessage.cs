

// Generated on 04/03/2020 21:59:06
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PresetsMessage : NetworkMessage
    {
        public const uint Id = 6750;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.Preset[] presets;
        
        public PresetsMessage()
        {
        }
        
        public PresetsMessage(Types.Preset[] presets)
        {
            this.presets = presets;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)presets.Length);
            foreach (var entry in presets)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            presets = new Types.Preset[limit];
            for (int i = 0; i < limit; i++)
            {
                 presets[i] = ProtocolTypeManager.GetInstance<Types.Preset>(reader.ReadUShort());
                 presets[i].Deserialize(reader);
            }
        }
        
    }
    
}