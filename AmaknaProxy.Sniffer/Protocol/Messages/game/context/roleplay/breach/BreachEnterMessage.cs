

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachEnterMessage : NetworkMessage
    {
        public const uint Id = 6810;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double owner;
        
        public BreachEnterMessage()
        {
        }
        
        public BreachEnterMessage(double owner)
        {
            this.owner = owner;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(owner);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            owner = reader.ReadVarUhLong();
        }
        
    }
    
}