

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class FinishMoveListMessage : NetworkMessage
    {
        public const uint Id = 6704;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.FinishMoveInformations[] finishMoves;
        
        public FinishMoveListMessage()
        {
        }
        
        public FinishMoveListMessage(Types.FinishMoveInformations[] finishMoves)
        {
            this.finishMoves = finishMoves;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)finishMoves.Length);
            foreach (var entry in finishMoves)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            finishMoves = new Types.FinishMoveInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 finishMoves[i] = new Types.FinishMoveInformations();
                 finishMoves[i].Deserialize(reader);
            }
        }
        
    }
    
}