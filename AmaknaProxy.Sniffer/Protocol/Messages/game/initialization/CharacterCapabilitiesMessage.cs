

// Generated on 04/03/2020 21:59:02
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class CharacterCapabilitiesMessage : NetworkMessage
    {
        public const uint Id = 6339;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint guildEmblemSymbolCategories;
        
        public CharacterCapabilitiesMessage()
        {
        }
        
        public CharacterCapabilitiesMessage(uint guildEmblemSymbolCategories)
        {
            this.guildEmblemSymbolCategories = guildEmblemSymbolCategories;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)guildEmblemSymbolCategories);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            guildEmblemSymbolCategories = reader.ReadVarUhInt();
        }
        
    }
    
}