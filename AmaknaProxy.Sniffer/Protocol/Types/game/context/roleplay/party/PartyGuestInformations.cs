

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class PartyGuestInformations
    {
        public const short Id = 374;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public double guestId;
        public double hostId;
        public string name;
        public Types.EntityLook guestLook;
        public sbyte breed;
        public bool sex;
        public Types.PlayerStatus status;
        public Types.PartyEntityBaseInformation[] entities;
        
        public PartyGuestInformations()
        {
        }
        
        public PartyGuestInformations(double guestId, double hostId, string name, Types.EntityLook guestLook, sbyte breed, bool sex, Types.PlayerStatus status, Types.PartyEntityBaseInformation[] entities)
        {
            this.guestId = guestId;
            this.hostId = hostId;
            this.name = name;
            this.guestLook = guestLook;
            this.breed = breed;
            this.sex = sex;
            this.status = status;
            this.entities = entities;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(guestId);
            writer.WriteVarLong(hostId);
            writer.WriteUTF(name);
            guestLook.Serialize(writer);
            writer.WriteSbyte(breed);
            writer.WriteBoolean(sex);
            writer.WriteShort(status.TypeId);
            status.Serialize(writer);
            writer.WriteShort((short)entities.Length);
            foreach (var entry in entities)
            {
                 entry.Serialize(writer);
            }
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            guestId = reader.ReadVarUhLong();
            hostId = reader.ReadVarUhLong();
            name = reader.ReadUTF();
            guestLook = new Types.EntityLook();
            guestLook.Deserialize(reader);
            breed = reader.ReadSbyte();
            sex = reader.ReadBoolean();
            status = ProtocolTypeManager.GetInstance<Types.PlayerStatus>(reader.ReadUShort());
            status.Deserialize(reader);
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