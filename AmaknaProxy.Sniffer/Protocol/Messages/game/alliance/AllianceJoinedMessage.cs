

// Generated on 04/03/2020 21:58:49
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AllianceJoinedMessage : NetworkMessage
    {
        public const uint Id = 6402;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.AllianceInformations allianceInfo;
        public bool enabled;
        public uint leadingGuildId;
        
        public AllianceJoinedMessage()
        {
        }
        
        public AllianceJoinedMessage(Types.AllianceInformations allianceInfo, bool enabled, uint leadingGuildId)
        {
            this.allianceInfo = allianceInfo;
            this.enabled = enabled;
            this.leadingGuildId = leadingGuildId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            allianceInfo.Serialize(writer);
            writer.WriteBoolean(enabled);
            writer.WriteVarInt((int)leadingGuildId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            allianceInfo = new Types.AllianceInformations();
            allianceInfo.Deserialize(reader);
            enabled = reader.ReadBoolean();
            leadingGuildId = reader.ReadVarUhInt();
        }
        
    }
    
}