

// Generated on 04/03/2020 21:59:07
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ContactLookRequestMessage : NetworkMessage
    {
        public const uint Id = 5932;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public byte requestId;
        public sbyte contactType;
        
        public ContactLookRequestMessage()
        {
        }
        
        public ContactLookRequestMessage(byte requestId, sbyte contactType)
        {
            this.requestId = requestId;
            this.contactType = contactType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(requestId);
            writer.WriteSbyte(contactType);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            requestId = reader.ReadByte();
            contactType = reader.ReadSbyte();
        }
        
    }
    
}