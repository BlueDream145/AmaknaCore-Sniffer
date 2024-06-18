

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class CharactersListMessage : BasicCharactersListMessage
    {
        public const uint Id = 151;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool hasStartupActions;
        
        public CharactersListMessage()
        {
        }
        
        public CharactersListMessage(Types.CharacterBaseInformations[] characters, bool hasStartupActions)
         : base(characters)
        {
            this.hasStartupActions = hasStartupActions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(hasStartupActions);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            hasStartupActions = reader.ReadBoolean();
        }
        
    }
    
}