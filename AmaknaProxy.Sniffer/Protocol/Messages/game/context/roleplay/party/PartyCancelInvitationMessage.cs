

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PartyCancelInvitationMessage : AbstractPartyMessage
    {
        public const uint Id = 6254;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double guestId;
        
        public PartyCancelInvitationMessage()
        {
        }
        
        public PartyCancelInvitationMessage(uint partyId, double guestId)
         : base(partyId)
        {
            this.guestId = guestId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(guestId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            guestId = reader.ReadVarUhLong();
        }
        
    }
    
}