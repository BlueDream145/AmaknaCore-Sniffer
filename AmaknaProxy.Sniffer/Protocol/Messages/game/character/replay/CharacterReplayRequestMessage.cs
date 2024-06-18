

// Generated on 04/03/2020 21:58:51
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class CharacterReplayRequestMessage : NetworkMessage
    {
        public const uint Id = 167;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double characterId;
        
        public CharacterReplayRequestMessage()
        {
        }
        
        public CharacterReplayRequestMessage(double characterId)
        {
            this.characterId = characterId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(characterId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            characterId = reader.ReadVarUhLong();
        }
        
    }
    
}