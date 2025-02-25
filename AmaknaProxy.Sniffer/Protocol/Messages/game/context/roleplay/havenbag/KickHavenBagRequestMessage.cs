

// Generated on 04/03/2020 21:58:56
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class KickHavenBagRequestMessage : NetworkMessage
    {
        public const uint Id = 6652;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double guestId;
        
        public KickHavenBagRequestMessage()
        {
        }
        
        public KickHavenBagRequestMessage(double guestId)
        {
            this.guestId = guestId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(guestId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            guestId = reader.ReadVarUhLong();
        }
        
    }
    
}