

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildHouseRemoveMessage : NetworkMessage
    {
        public const uint Id = 6180;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint houseId;
        public int instanceId;
        public bool secondHand;
        
        public GuildHouseRemoveMessage()
        {
        }
        
        public GuildHouseRemoveMessage(uint houseId, int instanceId, bool secondHand)
        {
            this.houseId = houseId;
            this.instanceId = instanceId;
            this.secondHand = secondHand;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)houseId);
            writer.WriteInt(instanceId);
            writer.WriteBoolean(secondHand);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadVarUhInt();
            instanceId = reader.ReadInt();
            secondHand = reader.ReadBoolean();
        }
        
    }
    
}