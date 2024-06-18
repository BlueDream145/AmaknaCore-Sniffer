

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class AllianceVersatileInformations
    {
        public const short Id = 432;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint allianceId;
        public uint nbGuilds;
        public uint nbMembers;
        public uint nbSubarea;
        
        public AllianceVersatileInformations()
        {
        }
        
        public AllianceVersatileInformations(uint allianceId, uint nbGuilds, uint nbMembers, uint nbSubarea)
        {
            this.allianceId = allianceId;
            this.nbGuilds = nbGuilds;
            this.nbMembers = nbMembers;
            this.nbSubarea = nbSubarea;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)allianceId);
            writer.WriteVarShort((int)nbGuilds);
            writer.WriteVarShort((int)nbMembers);
            writer.WriteVarShort((int)nbSubarea);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            allianceId = reader.ReadVarUhInt();
            nbGuilds = reader.ReadVarUhShort();
            nbMembers = reader.ReadVarUhShort();
            nbSubarea = reader.ReadVarUhShort();
        }
        
    }
    
}