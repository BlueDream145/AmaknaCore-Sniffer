

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildModificationEmblemValidMessage : NetworkMessage
    {
        public const uint Id = 6328;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GuildEmblem guildEmblem;
        
        public GuildModificationEmblemValidMessage()
        {
        }
        
        public GuildModificationEmblemValidMessage(Types.GuildEmblem guildEmblem)
        {
            this.guildEmblem = guildEmblem;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            guildEmblem.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            guildEmblem = new Types.GuildEmblem();
            guildEmblem.Deserialize(reader);
        }
        
    }
    
}