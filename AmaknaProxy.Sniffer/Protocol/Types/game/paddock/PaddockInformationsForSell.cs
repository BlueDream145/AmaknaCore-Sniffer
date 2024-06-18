

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class PaddockInformationsForSell
    {
        public const short Id = 222;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public string guildOwner;
        public short worldX;
        public short worldY;
        public uint subAreaId;
        public sbyte nbMount;
        public sbyte nbObject;
        public double price;
        
        public PaddockInformationsForSell()
        {
        }
        
        public PaddockInformationsForSell(string guildOwner, short worldX, short worldY, uint subAreaId, sbyte nbMount, sbyte nbObject, double price)
        {
            this.guildOwner = guildOwner;
            this.worldX = worldX;
            this.worldY = worldY;
            this.subAreaId = subAreaId;
            this.nbMount = nbMount;
            this.nbObject = nbObject;
            this.price = price;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(guildOwner);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteVarShort((int)subAreaId);
            writer.WriteSbyte(nbMount);
            writer.WriteSbyte(nbObject);
            writer.WriteVarLong(price);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            guildOwner = reader.ReadUTF();
            worldX = reader.ReadShort();
            worldY = reader.ReadShort();
            subAreaId = reader.ReadVarUhShort();
            nbMount = reader.ReadSbyte();
            nbObject = reader.ReadSbyte();
            price = reader.ReadVarUhLong();
        }
        
    }
    
}