

// Generated on 04/03/2020 21:58:48
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameActionFightExchangePositionsMessage : AbstractGameActionMessage
    {
        public const uint Id = 5527;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double targetId;
        public short casterCellId;
        public short targetCellId;
        
        public GameActionFightExchangePositionsMessage()
        {
        }
        
        public GameActionFightExchangePositionsMessage(uint actionId, double sourceId, double targetId, short casterCellId, short targetCellId)
         : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.casterCellId = casterCellId;
            this.targetCellId = targetCellId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(targetId);
            writer.WriteShort(casterCellId);
            writer.WriteShort(targetCellId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadDouble();
            casterCellId = reader.ReadShort();
            targetCellId = reader.ReadShort();
        }
        
    }
    
}