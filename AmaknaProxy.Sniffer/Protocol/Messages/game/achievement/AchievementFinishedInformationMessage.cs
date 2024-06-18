

// Generated on 04/03/2020 21:58:47
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AchievementFinishedInformationMessage : AchievementFinishedMessage
    {
        public const uint Id = 6381;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string name;
        public double playerId;
        
        public AchievementFinishedInformationMessage()
        {
        }
        
        public AchievementFinishedInformationMessage(Types.AchievementAchievedRewardable achievement, string name, double playerId)
         : base(achievement)
        {
            this.name = name;
            this.playerId = playerId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(name);
            writer.WriteVarLong(playerId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            name = reader.ReadUTF();
            playerId = reader.ReadVarUhLong();
        }
        
    }
    
}