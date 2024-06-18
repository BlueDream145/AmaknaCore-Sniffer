

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildFactsMessage : NetworkMessage
    {
        public const uint Id = 6415;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GuildFactSheetInformations infos;
        public int creationDate;
        public uint nbTaxCollectors;
        public Types.CharacterMinimalGuildPublicInformations[] members;
        
        public GuildFactsMessage()
        {
        }
        
        public GuildFactsMessage(Types.GuildFactSheetInformations infos, int creationDate, uint nbTaxCollectors, Types.CharacterMinimalGuildPublicInformations[] members)
        {
            this.infos = infos;
            this.creationDate = creationDate;
            this.nbTaxCollectors = nbTaxCollectors;
            this.members = members;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(infos.TypeId);
            infos.Serialize(writer);
            writer.WriteInt(creationDate);
            writer.WriteVarShort((int)nbTaxCollectors);
            writer.WriteShort((short)members.Length);
            foreach (var entry in members)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            infos = ProtocolTypeManager.GetInstance<Types.GuildFactSheetInformations>(reader.ReadUShort());
            infos.Deserialize(reader);
            creationDate = reader.ReadInt();
            nbTaxCollectors = reader.ReadVarUhShort();
            var limit = (ushort)reader.ReadUShort();
            members = new Types.CharacterMinimalGuildPublicInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 members[i] = new Types.CharacterMinimalGuildPublicInformations();
                 members[i].Deserialize(reader);
            }
        }
        
    }
    
}