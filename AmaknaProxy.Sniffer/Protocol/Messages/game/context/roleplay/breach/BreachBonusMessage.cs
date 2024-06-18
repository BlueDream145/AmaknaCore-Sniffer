

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachBonusMessage : NetworkMessage
    {
        public const uint Id = 6800;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.ObjectEffectInteger bonus;
        
        public BreachBonusMessage()
        {
        }
        
        public BreachBonusMessage(Types.ObjectEffectInteger bonus)
        {
            this.bonus = bonus;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            bonus.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            bonus = new Types.ObjectEffectInteger();
            bonus.Deserialize(reader);
        }
        
    }
    
}