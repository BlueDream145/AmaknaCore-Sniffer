

// Generated on 04/03/2020 21:58:49
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameActionFightTriggerEffectMessage : GameActionFightDispellEffectMessage
    {
        public const uint Id = 6147;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        
        public GameActionFightTriggerEffectMessage()
        {
        }
        
        public GameActionFightTriggerEffectMessage(uint actionId, double sourceId, double targetId, bool verboseCast, int boostUID)
         : base(actionId, sourceId, targetId, verboseCast, boostUID)
        {
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
        
    }
    
}