

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class TreasureHuntDigRequestAnswerMessage : NetworkMessage
    {
        public const uint Id = 6484;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte questType;
        public sbyte result;
        
        public TreasureHuntDigRequestAnswerMessage()
        {
        }
        
        public TreasureHuntDigRequestAnswerMessage(sbyte questType, sbyte result)
        {
            this.questType = questType;
            this.result = result;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(questType);
            writer.WriteSbyte(result);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            questType = reader.ReadSbyte();
            result = reader.ReadSbyte();
        }
        
    }
    
}