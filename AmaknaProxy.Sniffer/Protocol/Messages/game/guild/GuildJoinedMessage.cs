

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildJoinedMessage : NetworkMessage
    {
        public const uint Id = 5564;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GuildInformations guildInfo;
        public uint memberRights;
        
        public GuildJoinedMessage()
        {
        }
        
        public GuildJoinedMessage(Types.GuildInformations guildInfo, uint memberRights)
        {
            this.guildInfo = guildInfo;
            this.memberRights = memberRights;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            guildInfo.Serialize(writer);
            writer.WriteVarInt((int)memberRights);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            guildInfo = new Types.GuildInformations();
            guildInfo.Deserialize(reader);
            memberRights = reader.ReadVarUhInt();
        }
        
    }
    
}