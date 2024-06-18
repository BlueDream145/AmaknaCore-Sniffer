

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class BidExchangerObjectInfo
    {
        public const short Id = 122;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint objectUID;
        public uint objectGID;
        public int objectType;
        public Types.ObjectEffect[] effects;
        public double[] prices;
        
        public BidExchangerObjectInfo()
        {
        }
        
        public BidExchangerObjectInfo(uint objectUID, uint objectGID, int objectType, Types.ObjectEffect[] effects, double[] prices)
        {
            this.objectUID = objectUID;
            this.objectGID = objectGID;
            this.objectType = objectType;
            this.effects = effects;
            this.prices = prices;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)objectUID);
            writer.WriteVarShort((int)objectGID);
            writer.WriteInt(objectType);
            writer.WriteShort((short)effects.Length);
            foreach (var entry in effects)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)prices.Length);
            foreach (var entry in prices)
            {
                 writer.WriteVarLong(entry);
            }
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            objectUID = reader.ReadVarUhInt();
            objectGID = reader.ReadVarUhShort();
            objectType = reader.ReadInt();
            var limit = (ushort)reader.ReadUShort();
            effects = new Types.ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                 effects[i] = ProtocolTypeManager.GetInstance<Types.ObjectEffect>(reader.ReadUShort());
                 effects[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            prices = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 prices[i] = reader.ReadVarUhLong();
            }
        }
        
    }
    
}