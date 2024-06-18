

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class EmoteListMessage : NetworkMessage
    {
        public const uint Id = 5689;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public byte[] emoteIds;
        
        public EmoteListMessage()
        {
        }
        
        public EmoteListMessage(byte[] emoteIds)
        {
            this.emoteIds = emoteIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)(ushort)emoteIds.Length);
            foreach (var entry in emoteIds)
            {
                 writer.WriteByte(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadVarInt();
            emoteIds = new byte[limit];
            for (int i = 0; i < limit; i++)
            {
                 emoteIds[i] = reader.ReadByte();
            }
        }
        
    }
    
}