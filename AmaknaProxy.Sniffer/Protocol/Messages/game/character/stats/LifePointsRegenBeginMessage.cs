

// Generated on 04/03/2020 21:58:51
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class LifePointsRegenBeginMessage : NetworkMessage
    {
        public const uint Id = 5684;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public byte regenRate;
        
        public LifePointsRegenBeginMessage()
        {
        }
        
        public LifePointsRegenBeginMessage(byte regenRate)
        {
            this.regenRate = regenRate;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(regenRate);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            regenRate = reader.ReadByte();
        }
        
    }
    
}