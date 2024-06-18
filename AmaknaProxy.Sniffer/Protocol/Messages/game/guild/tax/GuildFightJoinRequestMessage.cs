

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildFightJoinRequestMessage : NetworkMessage
    {
        public const uint Id = 5717;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double taxCollectorId;
        
        public GuildFightJoinRequestMessage()
        {
        }
        
        public GuildFightJoinRequestMessage(double taxCollectorId)
        {
            this.taxCollectorId = taxCollectorId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(taxCollectorId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            taxCollectorId = reader.ReadDouble();
        }
        
    }
    
}