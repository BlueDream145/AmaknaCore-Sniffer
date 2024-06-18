

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FriendSpouseInformations
    {
        public const short Id = 77;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int spouseAccountId;
        public double spouseId;
        public string spouseName;
        public uint spouseLevel;
        public sbyte breed;
        public sbyte sex;
        public Types.EntityLook spouseEntityLook;
        public Types.GuildInformations guildInfo;
        public sbyte alignmentSide;
        
        public FriendSpouseInformations()
        {
        }
        
        public FriendSpouseInformations(int spouseAccountId, double spouseId, string spouseName, uint spouseLevel, sbyte breed, sbyte sex, Types.EntityLook spouseEntityLook, Types.GuildInformations guildInfo, sbyte alignmentSide)
        {
            this.spouseAccountId = spouseAccountId;
            this.spouseId = spouseId;
            this.spouseName = spouseName;
            this.spouseLevel = spouseLevel;
            this.breed = breed;
            this.sex = sex;
            this.spouseEntityLook = spouseEntityLook;
            this.guildInfo = guildInfo;
            this.alignmentSide = alignmentSide;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(spouseAccountId);
            writer.WriteVarLong(spouseId);
            writer.WriteUTF(spouseName);
            writer.WriteVarShort((int)spouseLevel);
            writer.WriteSbyte(breed);
            writer.WriteSbyte(sex);
            spouseEntityLook.Serialize(writer);
            guildInfo.Serialize(writer);
            writer.WriteSbyte(alignmentSide);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            spouseAccountId = reader.ReadInt();
            spouseId = reader.ReadVarUhLong();
            spouseName = reader.ReadUTF();
            spouseLevel = reader.ReadVarUhShort();
            breed = reader.ReadSbyte();
            sex = reader.ReadSbyte();
            spouseEntityLook = new Types.EntityLook();
            spouseEntityLook.Deserialize(reader);
            guildInfo = new Types.GuildInformations();
            guildInfo.Deserialize(reader);
            alignmentSide = reader.ReadSbyte();
        }
        
    }
    
}