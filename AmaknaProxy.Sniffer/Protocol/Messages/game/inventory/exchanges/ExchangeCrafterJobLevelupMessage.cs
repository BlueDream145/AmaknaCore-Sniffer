

// Generated on 04/03/2020 21:59:03
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeCrafterJobLevelupMessage : NetworkMessage
    {
        public const uint Id = 6598;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public byte crafterJobLevel;
        
        public ExchangeCrafterJobLevelupMessage()
        {
        }
        
        public ExchangeCrafterJobLevelupMessage(byte crafterJobLevel)
        {
            this.crafterJobLevel = crafterJobLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(crafterJobLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            crafterJobLevel = reader.ReadByte();
        }
        
    }
    
}