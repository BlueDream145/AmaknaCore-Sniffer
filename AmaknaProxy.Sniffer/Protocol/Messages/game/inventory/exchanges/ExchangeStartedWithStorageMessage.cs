

// Generated on 04/03/2020 21:59:04
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeStartedWithStorageMessage : ExchangeStartedMessage
    {
        public const uint Id = 6236;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint storageMaxSlot;
        
        public ExchangeStartedWithStorageMessage()
        {
        }
        
        public ExchangeStartedWithStorageMessage(sbyte exchangeType, uint storageMaxSlot)
         : base(exchangeType)
        {
            this.storageMaxSlot = storageMaxSlot;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)storageMaxSlot);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            storageMaxSlot = reader.ReadVarUhInt();
        }
        
    }
    
}