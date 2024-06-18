

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ObjectItemMinimalInformation : Item
    {
        public const short Id = 124;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public uint objectGID;
        public Types.ObjectEffect[] effects;
        
        public ObjectItemMinimalInformation()
        {
        }
        
        public ObjectItemMinimalInformation(uint objectGID, Types.ObjectEffect[] effects)
        {
            this.objectGID = objectGID;
            this.effects = effects;
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
        }
        
    }
    
}