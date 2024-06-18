

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class FollowQuestObjectiveRequestMessage : NetworkMessage
    {
        public const uint Id = 6724;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint questId;
        public short objectiveId;
        
        public FollowQuestObjectiveRequestMessage()
        {
        }
        
        public FollowQuestObjectiveRequestMessage(uint questId, short objectiveId)
        {
            this.questId = questId;
            this.objectiveId = objectiveId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)questId);
            writer.WriteShort(objectiveId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            questId = reader.ReadVarUhShort();
            objectiveId = reader.ReadShort();
        }
        
    }
    
}