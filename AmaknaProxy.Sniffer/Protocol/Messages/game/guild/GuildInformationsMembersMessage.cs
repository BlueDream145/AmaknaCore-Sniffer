

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildInformationsMembersMessage : NetworkMessage
    {
        public const uint Id = 5558;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GuildMember[] members;
        
        public GuildInformationsMembersMessage()
        {
        }
        
        public GuildInformationsMembersMessage(Types.GuildMember[] members)
        {
            this.members = members;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)members.Length);
            foreach (var entry in members)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            members = new Types.GuildMember[limit];
            for (int i = 0; i < limit; i++)
            {
                 members[i] = new Types.GuildMember();
                 members[i].Deserialize(reader);
            }
        }
        
    }
    
}