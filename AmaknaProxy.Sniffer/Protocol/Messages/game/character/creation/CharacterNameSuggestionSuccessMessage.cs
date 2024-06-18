

// Generated on 04/03/2020 21:58:51
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class CharacterNameSuggestionSuccessMessage : NetworkMessage
    {
        public const uint Id = 5544;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string suggestion;
        
        public CharacterNameSuggestionSuccessMessage()
        {
        }
        
        public CharacterNameSuggestionSuccessMessage(string suggestion)
        {
            this.suggestion = suggestion;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(suggestion);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            suggestion = reader.ReadUTF();
        }
        
    }
    
}