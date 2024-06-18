

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachRewardBoughtMessage : NetworkMessage
    {
        public const uint Id = 6797;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint id;
        public bool bought;
        
        public BreachRewardBoughtMessage()
        {
        }
        
        public BreachRewardBoughtMessage(uint id, bool bought)
        {
            this.id = id;
            this.bought = bought;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)id);
            writer.WriteBoolean(bought);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadVarUhInt();
            bought = reader.ReadBoolean();
        }
        
    }
    
}