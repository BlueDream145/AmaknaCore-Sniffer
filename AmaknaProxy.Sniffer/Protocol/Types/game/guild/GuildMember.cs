

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GuildMember : CharacterMinimalInformations
    {
        public const short Id = 88;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public bool sex;
        public bool havenBagShared;
        public sbyte breed;
        public uint rank;
        public double givenExperience;
        public sbyte experienceGivenPercent;
        public uint rights;
        public sbyte connected;
        public sbyte alignmentSide;
        public ushort hoursSinceLastConnection;
        public uint moodSmileyId;
        public int accountId;
        public int achievementPoints;
        public Types.PlayerStatus status;
        
        public GuildMember()
        {
        }
        
        public GuildMember(double id, string name, uint level, bool sex, bool havenBagShared, sbyte breed, uint rank, double givenExperience, sbyte experienceGivenPercent, uint rights, sbyte connected, sbyte alignmentSide, ushort hoursSinceLastConnection, uint moodSmileyId, int accountId, int achievementPoints, Types.PlayerStatus status)
         : base(id, name, level)
        {
            this.sex = sex;
            this.havenBagShared = havenBagShared;
            this.breed = breed;
            this.rank = rank;
            this.givenExperience = givenExperience;
            this.experienceGivenPercent = experienceGivenPercent;
            this.rights = rights;
            this.connected = connected;
            this.alignmentSide = alignmentSide;
            this.hoursSinceLastConnection = hoursSinceLastConnection;
            this.moodSmileyId = moodSmileyId;
            this.accountId = accountId;
            this.achievementPoints = achievementPoints;
            this.status = status;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, sex);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, havenBagShared);
            writer.WriteByte(flag1);
            writer.WriteSbyte(breed);
            writer.WriteVarShort((int)rank);
            writer.WriteVarLong(givenExperience);
            writer.WriteSbyte(experienceGivenPercent);
            writer.WriteVarInt((int)rights);
            writer.WriteSbyte(connected);
            writer.WriteSbyte(alignmentSide);
            writer.WriteUShort(hoursSinceLastConnection);
            writer.WriteVarShort((int)moodSmileyId);
            writer.WriteInt(accountId);
            writer.WriteInt(achievementPoints);
            writer.WriteShort(status.TypeId);
            status.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            sex = BooleanByteWrapper.GetFlag(flag1, 0);
            havenBagShared = BooleanByteWrapper.GetFlag(flag1, 1);
            breed = reader.ReadSbyte();
            rank = reader.ReadVarUhShort();
            givenExperience = reader.ReadVarUhLong();
            experienceGivenPercent = reader.ReadSbyte();
            rights = reader.ReadVarUhInt();
            connected = reader.ReadSbyte();
            alignmentSide = reader.ReadSbyte();
            hoursSinceLastConnection = reader.ReadUShort();
            moodSmileyId = reader.ReadVarUhShort();
            accountId = reader.ReadInt();
            achievementPoints = reader.ReadInt();
            status = ProtocolTypeManager.GetInstance<Types.PlayerStatus>(reader.ReadUShort());
            status.Deserialize(reader);
        }
        
    }
    
}