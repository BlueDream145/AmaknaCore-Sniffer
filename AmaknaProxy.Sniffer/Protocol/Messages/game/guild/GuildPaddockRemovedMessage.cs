

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildPaddockRemovedMessage : NetworkMessage
    {
        public const uint Id = 5955;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double paddockId;
        
        public GuildPaddockRemovedMessage()
        {
        }
        
        public GuildPaddockRemovedMessage(double paddockId)
        {
            this.paddockId = paddockId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(paddockId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            paddockId = reader.ReadDouble();
        }
        
    }
    
}