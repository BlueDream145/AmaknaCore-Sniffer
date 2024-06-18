

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildLevelUpMessage : NetworkMessage
    {
        public const uint Id = 6062;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public byte newLevel;
        
        public GuildLevelUpMessage()
        {
        }
        
        public GuildLevelUpMessage(byte newLevel)
        {
            this.newLevel = newLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(newLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            newLevel = reader.ReadByte();
        }
        
    }
    
}