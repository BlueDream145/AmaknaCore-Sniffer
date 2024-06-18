

// Generated on 04/03/2020 21:59:04
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeWaitingResultMessage : NetworkMessage
    {
        public const uint Id = 5786;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool bwait;
        
        public ExchangeWaitingResultMessage()
        {
        }
        
        public ExchangeWaitingResultMessage(bool bwait)
        {
            this.bwait = bwait;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(bwait);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            bwait = reader.ReadBoolean();
        }
        
    }
    
}