

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachExitResponseMessage : NetworkMessage
    {
        public const uint Id = 6814;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool exited;
        
        public BreachExitResponseMessage()
        {
        }
        
        public BreachExitResponseMessage(bool exited)
        {
            this.exited = exited;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(exited);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            exited = reader.ReadBoolean();
        }
        
    }
    
}