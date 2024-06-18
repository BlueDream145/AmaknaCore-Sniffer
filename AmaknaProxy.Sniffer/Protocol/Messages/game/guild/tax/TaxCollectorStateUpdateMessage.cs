

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class TaxCollectorStateUpdateMessage : NetworkMessage
    {
        public const uint Id = 6455;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double uniqueId;
        public sbyte state;
        
        public TaxCollectorStateUpdateMessage()
        {
        }
        
        public TaxCollectorStateUpdateMessage(double uniqueId, sbyte state)
        {
            this.uniqueId = uniqueId;
            this.state = state;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(uniqueId);
            writer.WriteSbyte(state);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            uniqueId = reader.ReadDouble();
            state = reader.ReadSbyte();
        }
        
    }
    
}