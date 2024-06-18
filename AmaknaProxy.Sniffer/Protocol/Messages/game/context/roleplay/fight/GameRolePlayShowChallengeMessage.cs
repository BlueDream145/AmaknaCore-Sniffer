

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameRolePlayShowChallengeMessage : NetworkMessage
    {
        public const uint Id = 301;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.FightCommonInformations commonsInfos;
        
        public GameRolePlayShowChallengeMessage()
        {
        }
        
        public GameRolePlayShowChallengeMessage(Types.FightCommonInformations commonsInfos)
        {
            this.commonsInfos = commonsInfos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            commonsInfos.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            commonsInfos = new Types.FightCommonInformations();
            commonsInfos.Deserialize(reader);
        }
        
    }
    
}