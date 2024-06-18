

// Generated on 04/03/2020 21:59:08
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class AchievementAchievedRewardable : AchievementAchieved
    {
        public const short Id = 515;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public uint finishedlevel;
        
        public AchievementAchievedRewardable()
        {
        }
        
        public AchievementAchievedRewardable(uint id, double achievedBy, uint finishedlevel)
         : base(id, achievedBy)
        {
            this.finishedlevel = finishedlevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((int)finishedlevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            finishedlevel = reader.ReadVarUhShort();
        }
        
    }
    
}