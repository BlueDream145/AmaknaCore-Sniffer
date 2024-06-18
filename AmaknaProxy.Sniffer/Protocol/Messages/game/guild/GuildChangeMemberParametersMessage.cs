

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildChangeMemberParametersMessage : NetworkMessage
    {
        public const uint Id = 5549;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double memberId;
        public uint rank;
        public sbyte experienceGivenPercent;
        public uint rights;
        
        public GuildChangeMemberParametersMessage()
        {
        }
        
        public GuildChangeMemberParametersMessage(double memberId, uint rank, sbyte experienceGivenPercent, uint rights)
        {
            this.memberId = memberId;
            this.rank = rank;
            this.experienceGivenPercent = experienceGivenPercent;
            this.rights = rights;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(memberId);
            writer.WriteVarShort((int)rank);
            writer.WriteSbyte(experienceGivenPercent);
            writer.WriteVarInt((int)rights);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            memberId = reader.ReadVarUhLong();
            rank = reader.ReadVarUhShort();
            experienceGivenPercent = reader.ReadSbyte();
            rights = reader.ReadVarUhInt();
        }
        
    }
    
}