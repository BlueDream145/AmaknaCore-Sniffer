

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ObjectItemToSell : Item
    {
        public const short Id = 120;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public uint objectGID;
        public Types.ObjectEffect[] effects;
        public uint objectUID;
        public uint quantity;
        public double objectPrice;
        
        public ObjectItemToSell()
        {
        }
        
        public ObjectItemToSell(uint objectGID, Types.ObjectEffect[] effects, uint objectUID, uint quantity, double objectPrice)
        {
            this.objectGID = objectGID;
            this.effects = effects;
            this.objectUID = objectUID;
            this.quantity = quantity;
            this.objectPrice = objectPrice;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((int)objectGID);
            writer.WriteShort((short)effects.Length);
            foreach (var entry in effects)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteVarInt((int)objectUID);
            writer.WriteVarInt((int)quantity);
            writer.WriteVarLong(objectPrice);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            objectGID = reader.ReadVarUhShort();
            var limit = (ushort)reader.ReadUShort();
            effects = new Types.ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                 effects[i] = ProtocolTypeManager.GetInstance<Types.ObjectEffect>(reader.ReadUShort());
                 effects[i].Deserialize(reader);
            }
            objectUID = reader.ReadVarUhInt();
            quantity = reader.ReadVarUhInt();
            objectPrice = reader.ReadVarUhLong();
        }
        
    }
    
}