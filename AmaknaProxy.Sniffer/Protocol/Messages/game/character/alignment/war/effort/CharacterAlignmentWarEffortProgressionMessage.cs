

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class CharacterAlignmentWarEffortProgressionMessage : NetworkMessage
    {
        public const uint Id = 6851;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double alignmentWarEffortDailyLimit;
        public double alignmentWarEffortDailyDonation;
        public double alignmentWarEffortPersonalDonation;
        
        public CharacterAlignmentWarEffortProgressionMessage()
        {
        }
        
        public CharacterAlignmentWarEffortProgressionMessage(double alignmentWarEffortDailyLimit, double alignmentWarEffortDailyDonation, double alignmentWarEffortPersonalDonation)
        {
            this.alignmentWarEffortDailyLimit = alignmentWarEffortDailyLimit;
            this.alignmentWarEffortDailyDonation = alignmentWarEffortDailyDonation;
            this.alignmentWarEffortPersonalDonation = alignmentWarEffortPersonalDonation;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(alignmentWarEffortDailyLimit);
            writer.WriteVarLong(alignmentWarEffortDailyDonation);
            writer.WriteVarLong(alignmentWarEffortPersonalDonation);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            alignmentWarEffortDailyLimit = reader.ReadVarUhLong();
            alignmentWarEffortDailyDonation = reader.ReadVarUhLong();
            alignmentWarEffortPersonalDonation = reader.ReadVarUhLong();
        }
        
    }
    
}