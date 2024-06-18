

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildListMessage : NetworkMessage
    {
        public const uint Id = 6413;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GuildInformations[] guilds;
        
        public GuildListMessage()
        {
        }
        
        public GuildListMessage(Types.GuildInformations[] guilds)
        {
            this.guilds = guilds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)guilds.Length);
            foreach (var entry in guilds)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            guilds = new Types.GuildInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 guilds[i] = new Types.GuildInformations();
                 guilds[i].Deserialize(reader);
            }
        }
        
    }
    
}