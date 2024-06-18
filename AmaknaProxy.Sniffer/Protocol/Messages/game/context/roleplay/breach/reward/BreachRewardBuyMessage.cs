

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachRewardBuyMessage : NetworkMessage
    {
        public const uint Id = 6803;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint id;
        
        public BreachRewardBuyMessage()
        {
        }
        
        public BreachRewardBuyMessage(uint id)
        {
            this.id = id;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)id);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadVarUhInt();
        }
        
    }
    
}