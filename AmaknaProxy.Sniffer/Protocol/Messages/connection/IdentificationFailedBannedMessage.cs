

// Generated on 04/03/2020 21:58:47
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class IdentificationFailedBannedMessage : IdentificationFailedMessage
    {
        public const uint Id = 6174;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double banEndDate;
        
        public IdentificationFailedBannedMessage()
        {
        }
        
        public IdentificationFailedBannedMessage(sbyte reason, double banEndDate)
         : base(reason)
        {
            this.banEndDate = banEndDate;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(banEndDate);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            banEndDate = reader.ReadDouble();
        }
        
    }
    
}