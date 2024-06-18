

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class EntityLook
    {
        public const short Id = 55;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint bonesId;
        public uint[] skins;
        public int[] indexedColors;
        public int[] scales;
        public Types.SubEntity[] subentities;
        
        public EntityLook()
        {
        }
        
        public EntityLook(uint bonesId, uint[] skins, int[] indexedColors, int[] scales, Types.SubEntity[] subentities)
        {
            this.bonesId = bonesId;
            this.skins = skins;
            this.indexedColors = indexedColors;
            this.scales = scales;
            this.subentities = subentities;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)bonesId);
            writer.WriteShort((short)skins.Length);
            foreach (var entry in skins)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteShort((short)indexedColors.Length);
            foreach (var entry in indexedColors)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteShort((short)scales.Length);
            foreach (var entry in scales)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteShort((short)subentities.Length);
            foreach (var entry in subentities)
            {
                 entry.Serialize(writer);
            }
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            bonesId = reader.ReadVarUhShort();
            var limit = (ushort)reader.ReadUShort();
            skins = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 skins[i] = reader.ReadVarUhShort();
            }
            limit = (ushort)reader.ReadUShort();
            indexedColors = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 indexedColors[i] = reader.ReadInt();
            }
            limit = (ushort)reader.ReadUShort();
            scales = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 scales[i] = reader.ReadVarShort();
            }
            limit = (ushort)reader.ReadUShort();
            subentities = new Types.SubEntity[limit];
            for (int i = 0; i < limit; i++)
            {
                 subentities[i] = new Types.SubEntity();
                 subentities[i].Deserialize(reader);
            }
        }
        
    }
    
}