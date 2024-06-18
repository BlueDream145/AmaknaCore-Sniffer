

// Generated on 04/03/2020 21:59:05
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ObjectJobAddedMessage : NetworkMessage
    {
        public const uint Id = 6014;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte jobId;
        
        public ObjectJobAddedMessage()
        {
        }
        
        public ObjectJobAddedMessage(sbyte jobId)
        {
            this.jobId = jobId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(jobId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            jobId = reader.ReadSbyte();
        }
        
    }
    
}