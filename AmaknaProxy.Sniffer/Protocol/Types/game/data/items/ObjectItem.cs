

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ObjectItem : Item
    {
        public const short Id = 37;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short position;
        public uint objectGID;
        public Types.ObjectEffect[] effects;
        public uint objectUID;
        public uint quantity;
        
        public ObjectItem()
        {
        }
        
        public ObjectItem(short position, uint objectGID, Types.ObjectEffect[] effects, uint objectUID, uint quantity)
        {
            this.position = position;
            this.objectGID = objectGID;
            this.effects = effects;
            this.objectUID = objectUID;
            this.quantity = quantity;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(position);
            writer.WriteVarShort((int)objectGID);
            writer.WriteShort((short)effects.Length);
            foreach (var entry in effects)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteVarInt((int)objectUID);
            writer.WriteVarInt((int)quantity);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            position = reader.ReadShort();
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
        }
        
    }
    
}