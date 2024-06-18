

// Generated on 04/03/2020 21:58:49
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AllianceInsiderInfoMessage : NetworkMessage
    {
        public const uint Id = 6403;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.AllianceFactSheetInformations allianceInfos;
        public Types.GuildInsiderFactSheetInformations[] guilds;
        public Types.PrismSubareaEmptyInfo[] prisms;
        
        public AllianceInsiderInfoMessage()
        {
        }
        
        public AllianceInsiderInfoMessage(Types.AllianceFactSheetInformations allianceInfos, Types.GuildInsiderFactSheetInformations[] guilds, Types.PrismSubareaEmptyInfo[] prisms)
        {
            this.allianceInfos = allianceInfos;
            this.guilds = guilds;
            this.prisms = prisms;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            allianceInfos.Serialize(writer);
            writer.WriteShort((short)guilds.Length);
            foreach (var entry in guilds)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)prisms.Length);
            foreach (var entry in prisms)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            allianceInfos = new Types.AllianceFactSheetInformations();
            allianceInfos.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            guilds = new Types.GuildInsiderFactSheetInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 guilds[i] = new Types.GuildInsiderFactSheetInformations();
                 guilds[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            prisms = new Types.PrismSubareaEmptyInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 prisms[i] = ProtocolTypeManager.GetInstance<Types.PrismSubareaEmptyInfo>(reader.ReadUShort());
                 prisms[i].Deserialize(reader);
            }
        }
        
    }
    
}