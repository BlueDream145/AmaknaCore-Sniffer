

// Generated on 04/03/2020 21:59:04
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeShopStockStartedMessage : NetworkMessage
    {
        public const uint Id = 5910;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.ObjectItemToSell[] objectsInfos;
        
        public ExchangeShopStockStartedMessage()
        {
        }
        
        public ExchangeShopStockStartedMessage(Types.ObjectItemToSell[] objectsInfos)
        {
            this.objectsInfos = objectsInfos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)objectsInfos.Length);
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            objectsInfos = new Types.ObjectItemToSell[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos[i] = new Types.ObjectItemToSell();
                 objectsInfos[i].Deserialize(reader);
            }
        }
        
    }
    
}