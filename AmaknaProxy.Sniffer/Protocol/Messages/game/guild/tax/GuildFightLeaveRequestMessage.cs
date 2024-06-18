

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildFightLeaveRequestMessage : NetworkMessage
    {
        public const uint Id = 5715;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double taxCollectorId;
        public double characterId;
        
        public GuildFightLeaveRequestMessage()
        {
        }
        
        public GuildFightLeaveRequestMessage(double taxCollectorId, double characterId)
        {
            this.taxCollectorId = taxCollectorId;
            this.characterId = characterId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(taxCollectorId);
            writer.WriteVarLong(characterId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            taxCollectorId = reader.ReadDouble();
            characterId = reader.ReadVarUhLong();
        }
        
    }
    
}