

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareWonMessage : NetworkMessage
    {
        public const uint Id = 6681;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double dareId;
        
        public DareWonMessage()
        {
        }
        
        public DareWonMessage(double dareId)
        {
            this.dareId = dareId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(dareId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            dareId = reader.ReadDouble();
        }
        
    }
    
}