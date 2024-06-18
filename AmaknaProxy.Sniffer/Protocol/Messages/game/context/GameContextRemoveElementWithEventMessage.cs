

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameContextRemoveElementWithEventMessage : GameContextRemoveElementMessage
    {
        public const uint Id = 6412;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte elementEventId;
        
        public GameContextRemoveElementWithEventMessage()
        {
        }
        
        public GameContextRemoveElementWithEventMessage(double id, sbyte elementEventId)
         : base(id)
        {
            this.elementEventId = elementEventId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSbyte(elementEventId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            elementEventId = reader.ReadSbyte();
        }
        
    }
    
}