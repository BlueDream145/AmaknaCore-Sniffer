

// Generated on 04/03/2020 21:59:02
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class HouseTeleportRequestMessage : NetworkMessage
    {
        public const uint Id = 6726;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint houseId;
        public int houseInstanceId;
        
        public HouseTeleportRequestMessage()
        {
        }
        
        public HouseTeleportRequestMessage(uint houseId, int houseInstanceId)
        {
            this.houseId = houseId;
            this.houseInstanceId = houseInstanceId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)houseId);
            writer.WriteInt(houseInstanceId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadVarUhInt();
            houseInstanceId = reader.ReadInt();
        }
        
    }
    
}