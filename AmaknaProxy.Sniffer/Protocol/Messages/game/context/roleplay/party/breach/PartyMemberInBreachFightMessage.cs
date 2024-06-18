

// Generated on 04/03/2020 21:58:58
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PartyMemberInBreachFightMessage : AbstractPartyMemberInFightMessage
    {
        public const uint Id = 6824;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint floor;
        public sbyte room;
        
        public PartyMemberInBreachFightMessage()
        {
        }
        
        public PartyMemberInBreachFightMessage(uint partyId, sbyte reason, double memberId, int memberAccountId, string memberName, uint fightId, int timeBeforeFightStart, uint floor, sbyte room)
         : base(partyId, reason, memberId, memberAccountId, memberName, fightId, timeBeforeFightStart)
        {
            this.floor = floor;
            this.room = room;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)floor);
            writer.WriteSbyte(room);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            floor = reader.ReadVarUhInt();
            room = reader.ReadSbyte();
        }
        
    }
    
}