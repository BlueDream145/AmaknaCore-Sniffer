

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AlignmentWarEffortDonatePreviewMessage : NetworkMessage
    {
        public const uint Id = 6853;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double xp;
        
        public AlignmentWarEffortDonatePreviewMessage()
        {
        }
        
        public AlignmentWarEffortDonatePreviewMessage(double xp)
        {
            this.xp = xp;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(xp);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            xp = reader.ReadDouble();
        }
        
    }
    
}