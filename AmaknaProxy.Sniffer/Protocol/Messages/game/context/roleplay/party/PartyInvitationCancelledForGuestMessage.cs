

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PartyInvitationCancelledForGuestMessage : AbstractPartyMessage
    {
        public const uint Id = 6256;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double cancelerId;
        
        public PartyInvitationCancelledForGuestMessage()
        {
        }
        
        public PartyInvitationCancelledForGuestMessage(uint partyId, double cancelerId)
         : base(partyId)
        {
            this.cancelerId = cancelerId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(cancelerId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            cancelerId = reader.ReadVarUhLong();
        }
        
    }
    
}