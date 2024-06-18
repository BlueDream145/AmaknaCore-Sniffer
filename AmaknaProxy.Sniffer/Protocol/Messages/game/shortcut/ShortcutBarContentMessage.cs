

// Generated on 04/03/2020 21:59:06
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ShortcutBarContentMessage : NetworkMessage
    {
        public const uint Id = 6231;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte barType;
        public Types.Shortcut[] shortcuts;
        
        public ShortcutBarContentMessage()
        {
        }
        
        public ShortcutBarContentMessage(sbyte barType, Types.Shortcut[] shortcuts)
        {
            this.barType = barType;
            this.shortcuts = shortcuts;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(barType);
            writer.WriteShort((short)shortcuts.Length);
            foreach (var entry in shortcuts)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            barType = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            shortcuts = new Types.Shortcut[limit];
            for (int i = 0; i < limit; i++)
            {
                 shortcuts[i] = ProtocolTypeManager.GetInstance<Types.Shortcut>(reader.ReadUShort());
                 shortcuts[i].Deserialize(reader);
            }
        }
        
    }
    
}