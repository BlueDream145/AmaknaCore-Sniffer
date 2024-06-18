

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class DecraftedItemStackInfo
    {
        public const short Id = 481;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint objectUID;
        public double bonusMin;
        public double bonusMax;
        public uint[] runesId;
        public uint[] runesQty;
        
        public DecraftedItemStackInfo()
        {
        }
        
        public DecraftedItemStackInfo(uint objectUID, double bonusMin, double bonusMax, uint[] runesId, uint[] runesQty)
        {
            this.objectUID = objectUID;
            this.bonusMin = bonusMin;
            this.bonusMax = bonusMax;
            this.runesId = runesId;
            this.runesQty = runesQty;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)objectUID);
            writer.WriteFloat((float)bonusMin);
            writer.WriteFloat((float)bonusMax);
            writer.WriteShort((short)runesId.Length);
            foreach (var entry in runesId)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteShort((short)runesQty.Length);
            foreach (var entry in runesQty)
            {
                 writer.WriteVarInt((int)entry);
            }
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            objectUID = reader.ReadVarUhInt();
            bonusMin = reader.ReadFloat();
            bonusMax = reader.ReadFloat();
            var limit = (ushort)reader.ReadUShort();
            runesId = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 runesId[i] = reader.ReadVarUhShort();
            }
            limit = (ushort)reader.ReadUShort();
            runesQty = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 runesQty[i] = reader.ReadVarUhInt();
            }
        }
        
    }
    
}