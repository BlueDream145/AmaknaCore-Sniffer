

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareInformationsRequestMessage : NetworkMessage
    {
        public const uint Id = 6659;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double dareId;
        
        public DareInformationsRequestMessage()
        {
        }
        
        public DareInformationsRequestMessage(double dareId)
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