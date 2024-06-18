

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class NumericWhoIsMessage : NetworkMessage
    {
        public const uint Id = 6297;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double playerId;
        public int accountId;
        
        public NumericWhoIsMessage()
        {
        }
        
        public NumericWhoIsMessage(double playerId, int accountId)
        {
            this.playerId = playerId;
            this.accountId = accountId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(playerId);
            writer.WriteInt(accountId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            playerId = reader.ReadVarUhLong();
            accountId = reader.ReadInt();
        }
        
    }
    
}