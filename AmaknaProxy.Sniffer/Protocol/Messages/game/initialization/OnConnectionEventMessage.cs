

// Generated on 04/03/2020 21:59:02
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class OnConnectionEventMessage : NetworkMessage
    {
        public const uint Id = 5726;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte eventType;
        
        public OnConnectionEventMessage()
        {
        }
        
        public OnConnectionEventMessage(sbyte eventType)
        {
            this.eventType = eventType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(eventType);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            eventType = reader.ReadSbyte();
        }
        
    }
    
}