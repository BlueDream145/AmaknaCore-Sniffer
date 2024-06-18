

// Generated on 04/03/2020 21:58:56
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class HouseSellingUpdateMessage : NetworkMessage
    {
        public const uint Id = 6727;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint houseId;
        public int instanceId;
        public bool secondHand;
        public double realPrice;
        public string buyerName;
        
        public HouseSellingUpdateMessage()
        {
        }
        
        public HouseSellingUpdateMessage(uint houseId, int instanceId, bool secondHand, double realPrice, string buyerName)
        {
            this.houseId = houseId;
            this.instanceId = instanceId;
            this.secondHand = secondHand;
            this.realPrice = realPrice;
            this.buyerName = buyerName;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)houseId);
            writer.WriteInt(instanceId);
            writer.WriteBoolean(secondHand);
            writer.WriteVarLong(realPrice);
            writer.WriteUTF(buyerName);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadVarUhInt();
            instanceId = reader.ReadInt();
            secondHand = reader.ReadBoolean();
            realPrice = reader.ReadVarUhLong();
            buyerName = reader.ReadUTF();
        }
        
    }
    
}