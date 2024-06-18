

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class FinishMoveSetRequestMessage : NetworkMessage
    {
        public const uint Id = 6703;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int finishMoveId;
        public bool finishMoveState;
        
        public FinishMoveSetRequestMessage()
        {
        }
        
        public FinishMoveSetRequestMessage(int finishMoveId, bool finishMoveState)
        {
            this.finishMoveId = finishMoveId;
            this.finishMoveState = finishMoveState;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(finishMoveId);
            writer.WriteBoolean(finishMoveState);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            finishMoveId = reader.ReadInt();
            finishMoveState = reader.ReadBoolean();
        }
        
    }
    
}