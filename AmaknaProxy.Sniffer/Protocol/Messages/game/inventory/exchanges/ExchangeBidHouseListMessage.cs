

// Generated on 04/03/2020 21:59:03
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeBidHouseListMessage : NetworkMessage
    {
        public const uint Id = 5807;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint id;
        public bool follow;
        
        public ExchangeBidHouseListMessage()
        {
        }
        
        public ExchangeBidHouseListMessage(uint id, bool follow)
        {
            this.id = id;
            this.follow = follow;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)id);
            writer.WriteBoolean(follow);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadVarUhShort();
            follow = reader.ReadBoolean();
        }
        
    }
    
}