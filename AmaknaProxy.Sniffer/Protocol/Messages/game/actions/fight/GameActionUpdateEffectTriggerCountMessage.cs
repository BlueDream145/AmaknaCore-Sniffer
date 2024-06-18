

// Generated on 04/03/2020 21:58:49
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameActionUpdateEffectTriggerCountMessage : NetworkMessage
    {
        public const uint Id = 6838;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GameFightEffectTriggerCount[] targetIds;
        
        public GameActionUpdateEffectTriggerCountMessage()
        {
        }
        
        public GameActionUpdateEffectTriggerCountMessage(Types.GameFightEffectTriggerCount[] targetIds)
        {
            this.targetIds = targetIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)targetIds.Length);
            foreach (var entry in targetIds)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            targetIds = new Types.GameFightEffectTriggerCount[limit];
            for (int i = 0; i < limit; i++)
            {
                 targetIds[i] = new Types.GameFightEffectTriggerCount();
                 targetIds[i].Deserialize(reader);
            }
        }
        
    }
    
}