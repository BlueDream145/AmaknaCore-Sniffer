

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameRolePlayRemoveChallengeMessage : NetworkMessage
    {
        public const uint Id = 300;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint fightId;
        
        public GameRolePlayRemoveChallengeMessage()
        {
        }
        
        public GameRolePlayRemoveChallengeMessage(uint fightId)
        {
            this.fightId = fightId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)fightId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadVarUhShort();
        }
        
    }
    
}