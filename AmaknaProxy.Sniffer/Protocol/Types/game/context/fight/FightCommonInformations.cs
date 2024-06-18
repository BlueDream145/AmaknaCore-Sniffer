

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FightCommonInformations
    {
        public const short Id = 43;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint fightId;
        public sbyte fightType;
        public Types.FightTeamInformations[] fightTeams;
        public uint[] fightTeamsPositions;
        public Types.FightOptionsInformations[] fightTeamsOptions;
        
        public FightCommonInformations()
        {
        }
        
        public FightCommonInformations(uint fightId, sbyte fightType, Types.FightTeamInformations[] fightTeams, uint[] fightTeamsPositions, Types.FightOptionsInformations[] fightTeamsOptions)
        {
            this.fightId = fightId;
            this.fightType = fightType;
            this.fightTeams = fightTeams;
            this.fightTeamsPositions = fightTeamsPositions;
            this.fightTeamsOptions = fightTeamsOptions;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)fightId);
            writer.WriteSbyte(fightType);
            writer.WriteShort((short)fightTeams.Length);
            foreach (var entry in fightTeams)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)fightTeamsPositions.Length);
            foreach (var entry in fightTeamsPositions)
            {
                 writer.WriteVarShort((int)entry);
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
            var limit = (ushort)reader.ReadUShort();
            fightTeams = new Types.FightTeamInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fightTeams[i] = ProtocolTypeManager.GetInstance<Types.FightTeamInformations>(reader.ReadUShort());
                 fightTeams[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            fightTeamsPositions = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 fightTeamsPositions[i] = reader.ReadVarUhShort();
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