

// Generated on 04/03/2020 21:58:58
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PartyMemberInStandardFightMessage : AbstractPartyMemberInFightMessage
    {
        public const uint Id = 6826;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.MapCoordinatesExtended fightMap;
        
        public PartyMemberInStandardFightMessage()
        {
        }
        
        public PartyMemberInStandardFightMessage(uint partyId, sbyte reason, double memberId, int memberAccountId, string memberName, uint fightId, int timeBeforeFightStart, Types.MapCoordinatesExtended fightMap)
         : base(partyId, reason, memberId, memberAccountId, memberName, fightId, timeBeforeFightStart)
        {
            this.fightMap = fightMap;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            fightMap.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            fightMap = new Types.MapCoordinatesExtended();
            fightMap.Deserialize(reader);
        }
        
    }
    
}