

// Generated on 04/03/2020 21:59:02
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeBidHouseGenericItemRemovedMessage : NetworkMessage
    {
        public const uint Id = 5948;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint objGenericId;
        
        public ExchangeBidHouseGenericItemRemovedMessage()
        {
        }
        
        public ExchangeBidHouseGenericItemRemovedMessage(uint objGenericId)
        {
            this.objGenericId = objGenericId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)objGenericId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            objGenericId = reader.ReadVarUhShort();
        }
        
    }
    
}