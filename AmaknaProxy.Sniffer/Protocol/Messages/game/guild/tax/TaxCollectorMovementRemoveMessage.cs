

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class TaxCollectorMovementRemoveMessage : NetworkMessage
    {
        public const uint Id = 5915;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double collectorId;
        
        public TaxCollectorMovementRemoveMessage()
        {
        }
        
        public TaxCollectorMovementRemoveMessage(double collectorId)
        {
            this.collectorId = collectorId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(collectorId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            collectorId = reader.ReadDouble();
        }
        
    }
    
}