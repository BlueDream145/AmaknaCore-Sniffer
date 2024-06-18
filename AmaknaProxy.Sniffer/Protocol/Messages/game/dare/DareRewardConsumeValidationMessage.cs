

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareRewardConsumeValidationMessage : NetworkMessage
    {
        public const uint Id = 6675;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double dareId;
        public sbyte type;
        
        public DareRewardConsumeValidationMessage()
        {
        }
        
        public DareRewardConsumeValidationMessage(double dareId, sbyte type)
        {
            this.dareId = dareId;
            this.type = type;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(dareId);
            writer.WriteSbyte(type);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            dareId = reader.ReadDouble();
            type = reader.ReadSbyte();
        }
        
    }
    
}