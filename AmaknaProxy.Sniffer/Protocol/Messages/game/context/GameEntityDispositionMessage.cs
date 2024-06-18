

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameEntityDispositionMessage : NetworkMessage
    {
        public const uint Id = 5693;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.IdentifiedEntityDispositionInformations disposition;
        
        public GameEntityDispositionMessage()
        {
        }
        
        public GameEntityDispositionMessage(Types.IdentifiedEntityDispositionInformations disposition)
        {
            this.disposition = disposition;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            disposition.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            disposition = new Types.IdentifiedEntityDispositionInformations();
            disposition.Deserialize(reader);
        }
        
    }
    
}