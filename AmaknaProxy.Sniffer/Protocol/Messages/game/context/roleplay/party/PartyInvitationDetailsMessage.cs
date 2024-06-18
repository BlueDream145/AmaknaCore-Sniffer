

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PartyInvitationDetailsMessage : AbstractPartyMessage
    {
        public const uint Id = 6263;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte partyType;
        public string partyName;
        public double fromId;
        public string fromName;
        public double leaderId;
        public Types.PartyInvitationMemberInformations[] members;
        public Types.PartyGuestInformations[] guests;
        
        public PartyInvitationDetailsMessage()
        {
        }
        
        public PartyInvitationDetailsMessage(uint partyId, sbyte partyType, string partyName, double fromId, string fromName, double leaderId, Types.PartyInvitationMemberInformations[] members, Types.PartyGuestInformations[] guests)
         : base(partyId)
        {
            this.partyType = partyType;
            this.partyName = partyName;
            this.fromId = fromId;
            this.fromName = fromName;
            this.leaderId = leaderId;
            this.members = members;
            this.guests = guests;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSbyte(partyType);
            writer.WriteUTF(partyName);
            writer.WriteVarLong(fromId);
            writer.WriteUTF(fromName);
            writer.WriteVarLong(leaderId);
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
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            partyType = reader.ReadSbyte();
            partyName = reader.ReadUTF();
            fromId = reader.ReadVarUhLong();
            fromName = reader.ReadUTF();
            leaderId = reader.ReadVarUhLong();
            var limit = (ushort)reader.ReadUShort();
            members = new Types.PartyInvitationMemberInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 members[i] = ProtocolTypeManager.GetInstance<Types.PartyInvitationMemberInformations>(reader.ReadUShort());
                 members[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            guests = new Types.PartyGuestInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 guests[i] = new Types.PartyGuestInformations();
                 guests[i].Deserialize(reader);
            }
        }
        
    }
    
}