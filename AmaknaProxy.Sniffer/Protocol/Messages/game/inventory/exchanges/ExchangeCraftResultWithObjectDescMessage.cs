

// Generated on 04/03/2020 21:59:03
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage
    {
        public const uint Id = 5999;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.ObjectItemNotInContainer objectInfo;
        
        public ExchangeCraftResultWithObjectDescMessage()
        {
        }
        
        public ExchangeCraftResultWithObjectDescMessage(sbyte craftResult, Types.ObjectItemNotInContainer objectInfo)
         : base(craftResult)
        {
            this.objectInfo = objectInfo;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            objectInfo.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            objectInfo = new Types.ObjectItemNotInContainer();
            objectInfo.Deserialize(reader);
        }
        
    }
    
}