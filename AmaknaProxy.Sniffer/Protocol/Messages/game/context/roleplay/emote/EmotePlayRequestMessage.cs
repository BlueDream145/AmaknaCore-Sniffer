

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class EmotePlayRequestMessage : NetworkMessage
    {
        public const uint Id = 5685;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public byte emoteId;
        
        public EmotePlayRequestMessage()
        {
        }
        
        public EmotePlayRequestMessage(byte emoteId)
        {
            this.emoteId = emoteId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(emoteId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            emoteId = reader.ReadByte();
        }
        
    }
    
}