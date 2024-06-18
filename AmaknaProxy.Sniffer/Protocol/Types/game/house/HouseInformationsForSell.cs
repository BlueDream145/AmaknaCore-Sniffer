

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class HouseInformationsForSell
    {
        public const short Id = 221;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int instanceId;
        public bool secondHand;
        public uint modelId;
        public string ownerName;
        public bool ownerConnected;
        public short worldX;
        public short worldY;
        public uint subAreaId;
        public sbyte nbRoom;
        public sbyte nbChest;
        public int[] skillListIds;
        public bool isLocked;
        public double price;
        
        public HouseInformationsForSell()
        {
        }
        
        public HouseInformationsForSell(int instanceId, bool secondHand, uint modelId, string ownerName, bool ownerConnected, short worldX, short worldY, uint subAreaId, sbyte nbRoom, sbyte nbChest, int[] skillListIds, bool isLocked, double price)
        {
            this.instanceId = instanceId;
            this.secondHand = secondHand;
            this.modelId = modelId;
            this.ownerName = ownerName;
            this.ownerConnected = ownerConnected;
            this.worldX = worldX;
            this.worldY = worldY;
            this.subAreaId = subAreaId;
            this.nbRoom = nbRoom;
            this.nbChest = nbChest;
            this.skillListIds = skillListIds;
            this.isLocked = isLocked;
            this.price = price;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(instanceId);
            writer.WriteBoolean(secondHand);
            writer.WriteVarInt((int)modelId);
            writer.WriteUTF(ownerName);
            writer.WriteBoolean(ownerConnected);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteVarShort((int)subAreaId);
            writer.WriteSbyte(nbRoom);
            writer.WriteSbyte(nbChest);
            writer.WriteShort((short)skillListIds.Length);
            foreach (var entry in skillListIds)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteBoolean(isLocked);
            writer.WriteVarLong(price);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            instanceId = reader.ReadInt();
            secondHand = reader.ReadBoolean();
            modelId = reader.ReadVarUhInt();
            ownerName = reader.ReadUTF();
            ownerConnected = reader.ReadBoolean();
            worldX = reader.ReadShort();
            worldY = reader.ReadShort();
            subAreaId = reader.ReadVarUhShort();
            nbRoom = reader.ReadSbyte();
            nbChest = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            skillListIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 skillListIds[i] = reader.ReadInt();
            }
            isLocked = reader.ReadBoolean();
            price = reader.ReadVarUhLong();
        }
        
    }
    
}