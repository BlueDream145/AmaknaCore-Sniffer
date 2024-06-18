

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildInformationsMemberUpdateMessage : NetworkMessage
    {
        public const uint Id = 5597;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GuildMember member;
        
        public GuildInformationsMemberUpdateMessage()
        {
        }
        
        public GuildInformationsMemberUpdateMessage(Types.GuildMember member)
        {
            this.member = member;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            member.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            member = new Types.GuildMember();
            member.Deserialize(reader);
        }
        
    }
    
}