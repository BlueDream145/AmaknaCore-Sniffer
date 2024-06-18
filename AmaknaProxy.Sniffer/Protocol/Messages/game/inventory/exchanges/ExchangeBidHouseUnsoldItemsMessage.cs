

// Generated on 04/03/2020 21:59:03
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeBidHouseUnsoldItemsMessage : NetworkMessage
    {
        public const uint Id = 6612;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.ObjectItemGenericQuantity[] items;
        
        public ExchangeBidHouseUnsoldItemsMessage()
        {
        }
        
        public ExchangeBidHouseUnsoldItemsMessage(Types.ObjectItemGenericQuantity[] items)
        {
            this.items = items;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)items.Length);
            foreach (var entry in items)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            items = new Types.ObjectItemGenericQuantity[limit];
            for (int i = 0; i < limit; i++)
            {
                 items[i] = new Types.ObjectItemGenericQuantity();
                 items[i].Deserialize(reader);
            }
        }
        
    }
    
}