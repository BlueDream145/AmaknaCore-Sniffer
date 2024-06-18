

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareSubscribeRequestMessage : NetworkMessage
    {
        public const uint Id = 6666;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double dareId;
        public bool subscribe;
        
        public DareSubscribeRequestMessage()
        {
        }
        
        public DareSubscribeRequestMessage(double dareId, bool subscribe)
        {
            this.dareId = dareId;
            this.subscribe = subscribe;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(dareId);
            writer.WriteBoolean(subscribe);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            dareId = reader.ReadDouble();
            subscribe = reader.ReadBoolean();
        }
        
    }
    
}