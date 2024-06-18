

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PurchasableDialogMessage : NetworkMessage
    {
        public const uint Id = 5739;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool buyOrSell;
        public bool secondHand;
        public double purchasableId;
        public int purchasableInstanceId;
        public double price;
        
        public PurchasableDialogMessage()
        {
        }
        
        public PurchasableDialogMessage(bool buyOrSell, bool secondHand, double purchasableId, int purchasableInstanceId, double price)
        {
            this.buyOrSell = buyOrSell;
            this.secondHand = secondHand;
            this.purchasableId = purchasableId;
            this.purchasableInstanceId = purchasableInstanceId;
            this.price = price;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, buyOrSell);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, secondHand);
            writer.WriteByte(flag1);
            writer.WriteDouble(purchasableId);
            writer.WriteInt(purchasableInstanceId);
            writer.WriteVarLong(price);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            buyOrSell = BooleanByteWrapper.GetFlag(flag1, 0);
            secondHand = BooleanByteWrapper.GetFlag(flag1, 1);
            purchasableId = reader.ReadDouble();
            purchasableInstanceId = reader.ReadInt();
            price = reader.ReadVarUhLong();
        }
        
    }
    
}