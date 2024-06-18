

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FightExternalInformations
    {
        public const short Id = 117;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint fightId;
        public sbyte fightType;
        public int fightStart;
        public bool fightSpectatorLocked;
        public Types.FightTeamLightInformations[] fightTeams;
        public Types.FightOptionsInformations[] fightTeamsOptions;
        
        public FightExternalInformations()
        {
        }
        
        public FightExternalInformations(uint fightId, sbyte fightType, int fightStart, bool fightSpectatorLocked, Types.FightTeamLightInformations[] fightTeams, Types.FightOptionsInformations[] fightTeamsOptions)
        {
            this.fightId = fightId;
            this.fightType = fightType;
            this.fightStart = fightStart;
            this.fightSpectatorLocked = fightSpectatorLocked;
            this.fightTeams = fightTeams;
            this.fightTeamsOptions = fightTeamsOptions;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)fightId);
            writer.WriteSbyte(fightType);
            writer.WriteInt(fightStart);
            writer.WriteBoolean(fightSpectatorLocked);
            writer.WriteShort((short)fightTeams.Length);
            foreach (var entry in fightTeams)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)fightTeamsOptions.Length);
            foreach (var entry in fightTeamsOptions)
            {
                 entry.Serialize(writer);
            }
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadVarUhShort();
            fightType = reader.ReadSbyte();
            fightStart = reader.ReadInt();
            fightSpectatorLocked = reader.ReadBoolean();
            var limit = (ushort)reader.ReadUShort();
            fightTeams = new Types.FightTeamLightInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fightTeams[i] = new Types.FightTeamLightInformations();
                 fightTeams[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            fightTeamsOptions = new Types.FightOptionsInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fightTeamsOptions[i] = new Types.FightOptionsInformations();
                 fightTeamsOptions[i].Deserialize(reader);
            }
        }
        
    }
    
}