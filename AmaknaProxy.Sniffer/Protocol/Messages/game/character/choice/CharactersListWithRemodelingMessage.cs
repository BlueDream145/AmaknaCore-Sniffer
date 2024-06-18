

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class CharactersListWithRemodelingMessage : CharactersListMessage
    {
        public const uint Id = 6550;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.CharacterToRemodelInformations[] charactersToRemodel;
        
        public CharactersListWithRemodelingMessage()
        {
        }
        
        public CharactersListWithRemodelingMessage(Types.CharacterBaseInformations[] characters, bool hasStartupActions, Types.CharacterToRemodelInformations[] charactersToRemodel)
         : base(characters, hasStartupActions)
        {
            this.charactersToRemodel = charactersToRemodel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)charactersToRemodel.Length);
            foreach (var entry in charactersToRemodel)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            charactersToRemodel = new Types.CharacterToRemodelInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 charactersToRemodel[i] = new Types.CharacterToRemodelInformations();
                 charactersToRemodel[i].Deserialize(reader);
            }
        }
        
    }
    
}