

// Generated on 04/03/2020 21:59:02
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeBidHouseInListAddedMessage : NetworkMessage
    {
        public const uint Id = 5949;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int itemUID;
        public uint objectGID;
        public int objectType;
        public Types.ObjectEffect[] effects;
        public double[] prices;
        
        public ExchangeBidHouseInListAddedMessage()
        {
        }
        
        public ExchangeBidHouseInListAddedMessage(int itemUID, uint objectGID, int objectType, Types.ObjectEffect[] effects, double[] prices)
        {
            this.itemUID = itemUID;
            this.objectGID = objectGID;
            this.objectType = objectType;
            this.effects = effects;
            this.prices = prices;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(itemUID);
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
        
        public override void Deserialize(IDataReader reader)
        {
            itemUID = reader.ReadInt();
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