

// Generated on 04/03/2020 21:58:56
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class JobCrafterDirectoryEntryRequestMessage : NetworkMessage
    {
        public const uint Id = 6043;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double playerId;
        
        public JobCrafterDirectoryEntryRequestMessage()
        {
        }
        
        public JobCrafterDirectoryEntryRequestMessage(double playerId)
        {
            this.playerId = playerId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(playerId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            playerId = reader.ReadVarUhLong();
        }
        
    }
    
}