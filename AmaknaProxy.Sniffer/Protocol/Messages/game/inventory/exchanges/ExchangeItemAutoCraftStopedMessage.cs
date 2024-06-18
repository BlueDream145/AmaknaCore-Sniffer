

// Generated on 04/03/2020 21:59:03
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeItemAutoCraftStopedMessage : NetworkMessage
    {
        public const uint Id = 5810;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte reason;
        
        public ExchangeItemAutoCraftStopedMessage()
        {
        }
        
        public ExchangeItemAutoCraftStopedMessage(sbyte reason)
        {
            this.reason = reason;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(reason);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            reason = reader.ReadSbyte();
        }
        
    }
    
}