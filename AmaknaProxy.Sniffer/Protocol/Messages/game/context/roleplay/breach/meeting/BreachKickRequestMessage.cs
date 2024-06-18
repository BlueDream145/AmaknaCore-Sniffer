

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachKickRequestMessage : NetworkMessage
    {
        public const uint Id = 6804;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double target;
        
        public BreachKickRequestMessage()
        {
        }
        
        public BreachKickRequestMessage(double target)
        {
            this.target = target;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(target);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            target = reader.ReadVarUhLong();
        }
        
    }
    
}