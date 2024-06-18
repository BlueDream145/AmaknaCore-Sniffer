

// Generated on 04/03/2020 21:58:58
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PartyMemberRemoveMessage : AbstractPartyEventMessage
    {
        public const uint Id = 5579;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double leavingPlayerId;
        
        public PartyMemberRemoveMessage()
        {
        }
        
        public PartyMemberRemoveMessage(uint partyId, double leavingPlayerId)
         : base(partyId)
        {
            this.leavingPlayerId = leavingPlayerId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(leavingPlayerId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            leavingPlayerId = reader.ReadVarUhLong();
        }
        
    }
    
}