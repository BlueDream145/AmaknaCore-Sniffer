

// Generated on 04/03/2020 21:58:58
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PartyJoinMessage : AbstractPartyMessage
    {
        public const uint Id = 5576;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte partyType;
        public double partyLeaderId;
        public sbyte maxParticipants;
        public Types.PartyMemberInformations[] members;
        public Types.PartyGuestInformations[] guests;
        public bool restricted;
        public string partyName;
        
        public PartyJoinMessage()
        {
        }
        
        public PartyJoinMessage(uint partyId, sbyte partyType, double partyLeaderId, sbyte maxParticipants, Types.PartyMemberInformations[] members, Types.PartyGuestInformations[] guests, bool restricted, string partyName)
         : base(partyId)
        {
            this.partyType = partyType;
            this.partyLeaderId = partyLeaderId;
            this.maxParticipants = maxParticipants;
            this.members = members;
            this.guests = guests;
            this.restricted = restricted;
            this.partyName = partyName;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSbyte(partyType);
            writer.WriteVarLong(partyLeaderId);
            writer.WriteSbyte(maxParticipants);
            writer.WriteShort((short)members.Length);
            foreach (var entry in members)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)guests.Length);
            foreach (var entry in guests)
            {
                 entry.Serialize(writer);
            }
            writer.WriteBoolean(restricted);
            writer.WriteUTF(partyName);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            partyType = reader.ReadSbyte();
            partyLeaderId = reader.ReadVarUhLong();
            maxParticipants = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            members = new Types.PartyMemberInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 members[i] = ProtocolTypeManager.GetInstance<Types.PartyMemberInformations>(reader.ReadUShort());
                 members[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            guests = new Types.PartyGuestInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 guests[i] = new Types.PartyGuestInformations();
                 guests[i].Deserialize(reader);
            }
            restricted = reader.ReadBoolean();
            partyName = reader.ReadUTF();
        }
        
    }
    
}