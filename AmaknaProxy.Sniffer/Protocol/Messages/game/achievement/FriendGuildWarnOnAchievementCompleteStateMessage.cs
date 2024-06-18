

// Generated on 04/03/2020 21:58:47
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class FriendGuildWarnOnAchievementCompleteStateMessage : NetworkMessage
    {
        public const uint Id = 6383;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool enable;
        
        public FriendGuildWarnOnAchievementCompleteStateMessage()
        {
        }
        
        public FriendGuildWarnOnAchievementCompleteStateMessage(bool enable)
        {
            this.enable = enable;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(enable);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            enable = reader.ReadBoolean();
        }
        
    }
    
}