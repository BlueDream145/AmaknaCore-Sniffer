

// Generated on 04/03/2020 21:59:08
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class Achievement
    {
        public const short Id = 363;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint id;
        public Types.AchievementObjective[] finishedObjective;
        public Types.AchievementStartedObjective[] startedObjectives;
        
        public Achievement()
        {
        }
        
        public Achievement(uint id, Types.AchievementObjective[] finishedObjective, Types.AchievementStartedObjective[] startedObjectives)
        {
            this.id = id;
            this.finishedObjective = finishedObjective;
            this.startedObjectives = startedObjectives;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)id);
            writer.WriteShort((short)finishedObjective.Length);
            foreach (var entry in finishedObjective)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)startedObjectives.Length);
            foreach (var entry in startedObjectives)
            {
                 entry.Serialize(writer);
            }
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            id = reader.ReadVarUhShort();
            var limit = (ushort)reader.ReadUShort();
            finishedObjective = new Types.AchievementObjective[limit];
            for (int i = 0; i < limit; i++)
            {
                 finishedObjective[i] = new Types.AchievementObjective();
                 finishedObjective[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            startedObjectives = new Types.AchievementStartedObjective[limit];
            for (int i = 0; i < limit; i++)
            {
                 startedObjectives[i] = new Types.AchievementStartedObjective();
                 startedObjectives[i].Deserialize(reader);
            }
        }
        
    }
    
}