

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class HouseInformationsForGuild : HouseInformations
    {
        public const short Id = 170;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public int instanceId;
        public bool secondHand;
        public string ownerName;
        public short worldX;
        public short worldY;
        public double mapId;
        public uint subAreaId;
        public int[] skillListIds;
        public uint guildshareParams;
        
        public HouseInformationsForGuild()
        {
        }
        
        public HouseInformationsForGuild(uint houseId, uint modelId, int instanceId, bool secondHand, string ownerName, short worldX, short worldY, double mapId, uint subAreaId, int[] skillListIds, uint guildshareParams)
         : base(houseId, modelId)
        {
            this.instanceId = instanceId;
            this.secondHand = secondHand;
            this.ownerName = ownerName;
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
            this.skillListIds = skillListIds;
            this.guildshareParams = guildshareParams;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(instanceId);
            writer.WriteBoolean(secondHand);
            writer.WriteUTF(ownerName);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteDouble(mapId);
            writer.WriteVarShort((int)subAreaId);
            writer.WriteShort((short)skillListIds.Length);
            foreach (var entry in skillListIds)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteVarInt((int)guildshareParams);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            instanceId = reader.ReadInt();
            secondHand = reader.ReadBoolean();
            ownerName = reader.ReadUTF();
            worldX = reader.ReadShort();
            worldY = reader.ReadShort();
            mapId = reader.ReadDouble();
            subAreaId = reader.ReadVarUhShort();
            var limit = (ushort)reader.ReadUShort();
            skillListIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 skillListIds[i] = reader.ReadInt();
            }
            guildshareParams = reader.ReadVarUhInt();
        }
        
    }
    
}