

// Generated on 04/03/2020 21:59:04
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class FocusedExchangeReadyMessage : ExchangeReadyMessage
    {
        public const uint Id = 6701;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint focusActionId;
        
        public FocusedExchangeReadyMessage()
        {
        }
        
        public FocusedExchangeReadyMessage(bool ready, uint step, uint focusActionId)
         : base(ready, step)
        {
            this.focusActionId = focusActionId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)focusActionId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            focusActionId = reader.ReadVarUhInt();
        }
        
    }
    
}