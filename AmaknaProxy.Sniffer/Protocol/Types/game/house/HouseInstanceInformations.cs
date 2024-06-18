

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class HouseInstanceInformations
    {
        public const short Id = 511;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public bool secondHand;
        public bool isLocked;
        public bool isSaleLocked;
        public int instanceId;
        public string ownerName;
        public double price;
        
        public HouseInstanceInformations()
        {
        }
        
        public HouseInstanceInformations(bool secondHand, bool isLocked, bool isSaleLocked, int instanceId, string ownerName, double price)
        {
            this.secondHand = secondHand;
            this.isLocked = isLocked;
            this.isSaleLocked = isSaleLocked;
            this.instanceId = instanceId;
            this.ownerName = ownerName;
            this.price = price;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, secondHand);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isLocked);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, isSaleLocked);
            writer.WriteByte(flag1);
            writer.WriteInt(instanceId);
            writer.WriteUTF(ownerName);
            writer.WriteVarLong(price);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            secondHand = BooleanByteWrapper.GetFlag(flag1, 0);
            isLocked = BooleanByteWrapper.GetFlag(flag1, 1);
            isSaleLocked = BooleanByteWrapper.GetFlag(flag1, 2);
            instanceId = reader.ReadInt();
            ownerName = reader.ReadUTF();
            price = reader.ReadVarLong();
        }
        
    }
    
}