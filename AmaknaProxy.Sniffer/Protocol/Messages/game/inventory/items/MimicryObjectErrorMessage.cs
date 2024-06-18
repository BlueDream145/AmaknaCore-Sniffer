

// Generated on 04/03/2020 21:59:05
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MimicryObjectErrorMessage : SymbioticObjectErrorMessage
    {
        public const uint Id = 6461;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool preview;
        
        public MimicryObjectErrorMessage()
        {
        }
        
        public MimicryObjectErrorMessage(sbyte reason, sbyte errorCode, bool preview)
         : base(reason, errorCode)
        {
            this.preview = preview;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(preview);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            preview = reader.ReadBoolean();
        }
        
    }
    
}