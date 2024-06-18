

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class PartyInvitationMemberInformations : CharacterBaseInformations
    {
        public const short Id = 376;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short worldX;
        public short worldY;
        public double mapId;
        public uint subAreaId;
        public Types.PartyEntityBaseInformation[] entities;
        
        public PartyInvitationMemberInformations()
        {
        }
        
        public PartyInvitationMemberInformations(double id, string name, uint level, Types.EntityLook entityLook, sbyte breed, bool sex, short worldX, short worldY, double mapId, uint subAreaId, Types.PartyEntityBaseInformation[] entities)
         : base(id, name, level, entityLook, breed, sex)
        {
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
            this.entities = entities;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteDouble(mapId);
            writer.WriteVarShort((int)subAreaId);
            writer.WriteShort((short)entities.Length);
            foreach (var entry in entities)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            worldX = reader.ReadShort();
            worldY = reader.ReadShort();
            mapId = reader.ReadDouble();
            subAreaId = reader.ReadVarUhShort();
            var limit = (ushort)reader.ReadUShort();
            entities = new Types.PartyEntityBaseInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                 entities[i] = new Types.PartyEntityBaseInformation();
                 entities[i].Deserialize(reader);
            }
        }
        
    }
    
}