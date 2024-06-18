

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareRewardWonMessage : NetworkMessage
    {
        public const uint Id = 6678;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.DareReward reward;
        
        public DareRewardWonMessage()
        {
        }
        
        public DareRewardWonMessage(Types.DareReward reward)
        {
            this.reward = reward;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            reward.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            reward = new Types.DareReward();
            reward.Deserialize(reader);
        }
        
    }
    
}