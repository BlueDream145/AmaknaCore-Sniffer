

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BasicCharactersListMessage : NetworkMessage
    {
        public const uint Id = 6475;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.CharacterBaseInformations[] characters;
        
        public BasicCharactersListMessage()
        {
        }
        
        public BasicCharactersListMessage(Types.CharacterBaseInformations[] characters)
        {
            this.characters = characters;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)characters.Length);
            foreach (var entry in characters)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            characters = new Types.CharacterBaseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 characters[i] = ProtocolTypeManager.GetInstance<Types.CharacterBaseInformations>(reader.ReadUShort());
                 characters[i].Deserialize(reader);
            }
        }
        
    }
    
}