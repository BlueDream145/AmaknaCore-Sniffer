

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameFightPlacementPositionRequestMessage : NetworkMessage
    {
        public const uint Id = 704;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint cellId;
        
        public GameFightPlacementPositionRequestMessage()
        {
        }
        
        public GameFightPlacementPositionRequestMessage(uint cellId)
        {
            this.cellId = cellId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)cellId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            cellId = reader.ReadVarUhShort();
        }
        
    }
    
}