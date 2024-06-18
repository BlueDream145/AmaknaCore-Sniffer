

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class QuestValidatedMessage : NetworkMessage
    {
        public const uint Id = 6097;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint questId;
        
        public QuestValidatedMessage()
        {
        }
        
        public QuestValidatedMessage(uint questId)
        {
            this.questId = questId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)questId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            questId = reader.ReadVarUhShort();
        }
        
    }
    
}