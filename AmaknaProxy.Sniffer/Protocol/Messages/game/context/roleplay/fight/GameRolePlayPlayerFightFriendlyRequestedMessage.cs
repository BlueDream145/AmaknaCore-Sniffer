

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameRolePlayPlayerFightFriendlyRequestedMessage : NetworkMessage
    {
        public const uint Id = 5937;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint fightId;
        public double sourceId;
        public double targetId;
        
        public GameRolePlayPlayerFightFriendlyRequestedMessage()
        {
        }
        
        public GameRolePlayPlayerFightFriendlyRequestedMessage(uint fightId, double sourceId, double targetId)
        {
            this.fightId = fightId;
            this.sourceId = sourceId;
            this.targetId = targetId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)fightId);
            writer.WriteVarLong(sourceId);
            writer.WriteVarLong(targetId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadVarUhShort();
            sourceId = reader.ReadVarUhLong();
            targetId = reader.ReadVarUhLong();
        }
        
    }
    
}