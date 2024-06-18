

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameRolePlayPlayerFightFriendlyAnswerMessage : NetworkMessage
    {
        public const uint Id = 5732;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint fightId;
        public bool accept;
        
        public GameRolePlayPlayerFightFriendlyAnswerMessage()
        {
        }
        
        public GameRolePlayPlayerFightFriendlyAnswerMessage(uint fightId, bool accept)
        {
            this.fightId = fightId;
            this.accept = accept;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)fightId);
            writer.WriteBoolean(accept);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadVarUhShort();
            accept = reader.ReadBoolean();
        }
        
    }
    
}