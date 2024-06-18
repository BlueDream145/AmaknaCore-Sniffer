

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachInvitationResponseMessage : NetworkMessage
    {
        public const uint Id = 6792;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.CharacterMinimalInformations guest;
        public bool accept;
        
        public BreachInvitationResponseMessage()
        {
        }
        
        public BreachInvitationResponseMessage(Types.CharacterMinimalInformations guest, bool accept)
        {
            this.guest = guest;
            this.accept = accept;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            guest.Serialize(writer);
            writer.WriteBoolean(accept);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            guest = new Types.CharacterMinimalInformations();
            guest.Deserialize(reader);
            accept = reader.ReadBoolean();
        }
        
    }
    
}