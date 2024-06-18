

// Generated on 04/03/2020 21:58:48
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameActionFightSlideMessage : AbstractGameActionMessage
    {
        public const uint Id = 5525;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double targetId;
        public short startCellId;
        public short endCellId;
        
        public GameActionFightSlideMessage()
        {
        }
        
        public GameActionFightSlideMessage(uint actionId, double sourceId, double targetId, short startCellId, short endCellId)
         : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.startCellId = startCellId;
            this.endCellId = endCellId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(targetId);
            writer.WriteShort(startCellId);
            writer.WriteShort(endCellId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadDouble();
            startCellId = reader.ReadShort();
            endCellId = reader.ReadShort();
        }
        
    }
    
}