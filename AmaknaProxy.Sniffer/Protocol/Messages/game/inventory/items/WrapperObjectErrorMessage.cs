

// Generated on 04/03/2020 21:59:05
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class WrapperObjectErrorMessage : SymbioticObjectErrorMessage
    {
        public const uint Id = 6529;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        
        public WrapperObjectErrorMessage()
        {
        }
        
        public WrapperObjectErrorMessage(sbyte reason, sbyte errorCode)
         : base(reason, errorCode)
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