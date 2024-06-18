

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GuildInsiderFactSheetInformations : GuildFactSheetInformations
    {
        public const short Id = 423;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public string leaderName;
        public uint nbConnectedMembers;
        public sbyte nbTaxCollectors;
        public int lastActivity;
        
        public GuildInsiderFactSheetInformations()
        {
        }
        
        public GuildInsiderFactSheetInformations(uint guildId, string guildName, byte guildLevel, Types.GuildEmblem guildEmblem, double leaderId, uint nbMembers, string leaderName, uint nbConnectedMembers, sbyte nbTaxCollectors, int lastActivity)
         : base(guildId, guildName, guildLevel, guildEmblem, leaderId, nbMembers)
        {
            this.leaderName = leaderName;
            this.nbConnectedMembers = nbConnectedMembers;
            this.nbTaxCollectors = nbTaxCollectors;
            this.lastActivity = lastActivity;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(leaderName);
            writer.WriteVarShort((int)nbConnectedMembers);
            writer.WriteSbyte(nbTaxCollectors);
            writer.WriteInt(lastActivity);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            leaderName = reader.ReadUTF();
            nbConnectedMembers = reader.ReadVarUhShort();
            nbTaxCollectors = reader.ReadSbyte();
            lastActivity = reader.ReadInt();
        }
        
    }
    
}