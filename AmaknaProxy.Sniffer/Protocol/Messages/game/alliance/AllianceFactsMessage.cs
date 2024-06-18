

// Generated on 04/03/2020 21:58:49
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AllianceFactsMessage : NetworkMessage
    {
        public const uint Id = 6414;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.AllianceFactSheetInformations infos;
        public Types.GuildInAllianceInformations[] guilds;
        public uint[] controlledSubareaIds;
        public double leaderCharacterId;
        public string leaderCharacterName;
        
        public AllianceFactsMessage()
        {
        }
        
        public AllianceFactsMessage(Types.AllianceFactSheetInformations infos, Types.GuildInAllianceInformations[] guilds, uint[] controlledSubareaIds, double leaderCharacterId, string leaderCharacterName)
        {
            this.infos = infos;
            this.guilds = guilds;
            this.controlledSubareaIds = controlledSubareaIds;
            this.leaderCharacterId = leaderCharacterId;
            this.leaderCharacterName = leaderCharacterName;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(infos.TypeId);
            infos.Serialize(writer);
            writer.WriteShort((short)guilds.Length);
            foreach (var entry in guilds)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)controlledSubareaIds.Length);
            foreach (var entry in controlledSubareaIds)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteVarLong(leaderCharacterId);
            writer.WriteUTF(leaderCharacterName);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            infos = ProtocolTypeManager.GetInstance<Types.AllianceFactSheetInformations>(reader.ReadUShort());
            infos.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            guilds = new Types.GuildInAllianceInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 guilds[i] = new Types.GuildInAllianceInformations();
                 guilds[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            controlledSubareaIds = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 controlledSubareaIds[i] = reader.ReadVarUhShort();
            }
            leaderCharacterId = reader.ReadVarUhLong();
            leaderCharacterName = reader.ReadUTF();
        }
        
    }
    
}