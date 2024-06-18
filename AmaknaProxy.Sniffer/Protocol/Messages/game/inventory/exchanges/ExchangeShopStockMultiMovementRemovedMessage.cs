

// Generated on 04/03/2020 21:59:04
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeShopStockMultiMovementRemovedMessage : NetworkMessage
    {
        public const uint Id = 6037;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint[] objectIdList;
        
        public ExchangeShopStockMultiMovementRemovedMessage()
        {
        }
        
        public ExchangeShopStockMultiMovementRemovedMessage(uint[] objectIdList)
        {
            this.objectIdList = objectIdList;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)objectIdList.Length);
            foreach (var entry in objectIdList)
            {
                 writer.WriteVarInt((int)entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            objectIdList = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectIdList[i] = reader.ReadVarUhInt();
            }
        }
        
    }
    
}