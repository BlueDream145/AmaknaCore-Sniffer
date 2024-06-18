

// Generated on 04/03/2020 21:59:08
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class HaapiBufferListMessage : NetworkMessage
    {
        public const uint Id = 6845;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.BufferInformation[] buffers;
        
        public HaapiBufferListMessage()
        {
        }
        
        public HaapiBufferListMessage(Types.BufferInformation[] buffers)
        {
            this.buffers = buffers;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)buffers.Length);
            foreach (var entry in buffers)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            buffers = new Types.BufferInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                 buffers[i] = new Types.BufferInformation();
                 buffers[i].Deserialize(reader);
            }
        }
        
    }
    
}