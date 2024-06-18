

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FightTeamLightInformations : AbstractFightTeamInformations
    {
        public const short Id = 115;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public bool hasFriend;
        public bool hasGuildMember;
        public bool hasAllianceMember;
        public bool hasGroupMember;
        public bool hasMyTaxCollector;
        public sbyte teamMembersCount;
        public uint meanLevel;
        
        public FightTeamLightInformations()
        {
        }
        
        public FightTeamLightInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves, bool hasFriend, bool hasGuildMember, bool hasAllianceMember, bool hasGroupMember, bool hasMyTaxCollector, sbyte teamMembersCount, uint meanLevel)
         : base(teamId, leaderId, teamSide, teamTypeId, nbWaves)
        {
            this.hasFriend = hasFriend;
            this.hasGuildMember = hasGuildMember;
            this.hasAllianceMember = hasAllianceMember;
            this.hasGroupMember = hasGroupMember;
            this.hasMyTaxCollector = hasMyTaxCollector;
            this.teamMembersCount = teamMembersCount;
            this.meanLevel = meanLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, hasFriend);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, hasGuildMember);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, hasAllianceMember);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, hasGroupMember);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 4, hasMyTaxCollector);
            writer.WriteByte(flag1);
            writer.WriteSbyte(teamMembersCount);
            writer.WriteVarInt((int)meanLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            hasFriend = BooleanByteWrapper.GetFlag(flag1, 0);
            hasGuildMember = BooleanByteWrapper.GetFlag(flag1, 1);
            hasAllianceMember = BooleanByteWrapper.GetFlag(flag1, 2);
            hasGroupMember = BooleanByteWrapper.GetFlag(flag1, 3);
            hasMyTaxCollector = BooleanByteWrapper.GetFlag(flag1, 4);
            teamMembersCount = reader.ReadSbyte();
            meanLevel = reader.ReadVarUhInt();
        }
        
    }
    
}