

// Generated on 04/03/2020 21:58:56
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class InviteInHavenBagClosedMessage : NetworkMessage
    {
        public const uint Id = 6645;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.CharacterMinimalInformations hostInformations;
        
        public InviteInHavenBagClosedMessage()
        {
        }
        
        public InviteInHavenBagClosedMessage(Types.CharacterMinimalInformations hostInformations)
        {
            this.hostInformations = hostInformations;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            hostInformations.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            hostInformations = new Types.CharacterMinimalInformations();
            hostInformations.Deserialize(reader);
        }
        
    }
    
}