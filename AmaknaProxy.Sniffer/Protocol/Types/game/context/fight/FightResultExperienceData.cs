

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FightResultExperienceData : FightResultAdditionalData
    {
        public const short Id = 192;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public bool showExperience;
        public bool showExperienceLevelFloor;
        public bool showExperienceNextLevelFloor;
        public bool showExperienceFightDelta;
        public bool showExperienceForGuild;
        public bool showExperienceForMount;
        public bool isIncarnationExperience;
        public double experience;
        public double experienceLevelFloor;
        public double experienceNextLevelFloor;
        public double experienceFightDelta;
        public double experienceForGuild;
        public double experienceForMount;
        public sbyte rerollExperienceMul;
        
        public FightResultExperienceData()
        {
        }
        
        public FightResultExperienceData(bool showExperience, bool showExperienceLevelFloor, bool showExperienceNextLevelFloor, bool showExperienceFightDelta, bool showExperienceForGuild, bool showExperienceForMount, bool isIncarnationExperience, double experience, double experienceLevelFloor, double experienceNextLevelFloor, double experienceFightDelta, double experienceForGuild, double experienceForMount, sbyte rerollExperienceMul)
        {
            this.showExperience = showExperience;
            this.showExperienceLevelFloor = showExperienceLevelFloor;
            this.showExperienceNextLevelFloor = showExperienceNextLevelFloor;
            this.showExperienceFightDelta = showExperienceFightDelta;
            this.showExperienceForGuild = showExperienceForGuild;
            this.showExperienceForMount = showExperienceForMount;
            this.isIncarnationExperience = isIncarnationExperience;
            this.experience = experience;
            this.experienceLevelFloor = experienceLevelFloor;
            this.experienceNextLevelFloor = experienceNextLevelFloor;
            this.experienceFightDelta = experienceFightDelta;
            this.experienceForGuild = experienceForGuild;
            this.experienceForMount = experienceForMount;
            this.rerollExperienceMul = rerollExperienceMul;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, showExperience);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, showExperienceLevelFloor);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, showExperienceNextLevelFloor);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, showExperienceFightDelta);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 4, showExperienceForGuild);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 5, showExperienceForMount);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 6, isIncarnationExperience);
            writer.WriteByte(flag1);
            writer.WriteVarLong(experience);
            writer.WriteVarLong(experienceLevelFloor);
            writer.WriteVarLong(experienceNextLevelFloor);
            writer.WriteVarLong(experienceFightDelta);
            writer.WriteVarLong(experienceForGuild);
            writer.WriteVarLong(experienceForMount);
            writer.WriteSbyte(rerollExperienceMul);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            showExperience = BooleanByteWrapper.GetFlag(flag1, 0);
            showExperienceLevelFloor = BooleanByteWrapper.GetFlag(flag1, 1);
            showExperienceNextLevelFloor = BooleanByteWrapper.GetFlag(flag1, 2);
            showExperienceFightDelta = BooleanByteWrapper.GetFlag(flag1, 3);
            showExperienceForGuild = BooleanByteWrapper.GetFlag(flag1, 4);
            showExperienceForMount = BooleanByteWrapper.GetFlag(flag1, 5);
            isIncarnationExperience = BooleanByteWrapper.GetFlag(flag1, 6);
            experience = reader.ReadVarUhLong();
            experienceLevelFloor = reader.ReadVarUhLong();
            experienceNextLevelFloor = reader.ReadVarUhLong();
            experienceFightDelta = reader.ReadVarUhLong();
            experienceForGuild = reader.ReadVarUhLong();
            experienceForMount = reader.ReadVarUhLong();
            rerollExperienceMul = reader.ReadSbyte();
        }
        
    }
    
}