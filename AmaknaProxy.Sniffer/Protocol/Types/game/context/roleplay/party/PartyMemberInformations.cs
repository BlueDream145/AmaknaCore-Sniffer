

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class PartyMemberInformations : CharacterBaseInformations
    {
        public const short Id = 90;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public uint lifePoints;
        public uint maxLifePoints;
        public uint prospecting;
        public byte regenRate;
        public uint initiative;
        public sbyte alignmentSide;
        public short worldX;
        public short worldY;
        public double mapId;
        public uint subAreaId;
        public Types.PlayerStatus status;
        public Types.PartyEntityBaseInformation[] entities;
        
        public PartyMemberInformations()
        {
        }
        
        public PartyMemberInformations(double id, string name, uint level, Types.EntityLook entityLook, sbyte breed, bool sex, uint lifePoints, uint maxLifePoints, uint prospecting, byte regenRate, uint initiative, sbyte alignmentSide, short worldX, short worldY, double mapId, uint subAreaId, Types.PlayerStatus status, Types.PartyEntityBaseInformation[] entities)
         : base(id, name, level, entityLook, breed, sex)
        {
            this.lifePoints = lifePoints;
            this.maxLifePoints = maxLifePoints;
            this.prospecting = prospecting;
            this.regenRate = regenRate;
            this.initiative = initiative;
            this.alignmentSide = alignmentSide;
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
            this.status = status;
            this.entities = entities;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)lifePoints);
            writer.WriteVarInt((int)maxLifePoints);
            writer.WriteVarShort((int)prospecting);
            writer.WriteByte(regenRate);
            writer.WriteVarShort((int)initiative);
            writer.WriteSbyte(alignmentSide);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteDouble(mapId);
            writer.WriteVarShort((int)subAreaId);
            writer.WriteShort(status.TypeId);
            status.Serialize(writer);
            writer.WriteShort((short)entities.Length);
            foreach (var entry in entities)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            lifePoints = reader.ReadVarUhInt();
            maxLifePoints = reader.ReadVarUhInt();
            prospecting = reader.ReadVarUhShort();
            regenRate = reader.ReadByte();
            initiative = reader.ReadVarUhShort();
            alignmentSide = reader.ReadSbyte();
            worldX = reader.ReadShort();
            worldY = reader.ReadShort();
            mapId = reader.ReadDouble();
            subAreaId = reader.ReadVarUhShort();
            status = ProtocolTypeManager.GetInstance<Types.PlayerStatus>(reader.ReadUShort());
            status.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            entities = new Types.PartyEntityBaseInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                 entities[i] = ProtocolTypeManager.GetInstance<Types.PartyEntityBaseInformation>(reader.ReadUShort());
                 entities[i].Deserialize(reader);
            }
        }
        
    }
    
}