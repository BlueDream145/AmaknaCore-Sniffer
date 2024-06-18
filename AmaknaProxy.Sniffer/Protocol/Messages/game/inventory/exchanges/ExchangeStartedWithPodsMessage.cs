

// Generated on 04/03/2020 21:59:04
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeStartedWithPodsMessage : ExchangeStartedMessage
    {
        public const uint Id = 6129;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double firstCharacterId;
        public uint firstCharacterCurrentWeight;
        public uint firstCharacterMaxWeight;
        public double secondCharacterId;
        public uint secondCharacterCurrentWeight;
        public uint secondCharacterMaxWeight;
        
        public ExchangeStartedWithPodsMessage()
        {
        }
        
        public ExchangeStartedWithPodsMessage(sbyte exchangeType, double firstCharacterId, uint firstCharacterCurrentWeight, uint firstCharacterMaxWeight, double secondCharacterId, uint secondCharacterCurrentWeight, uint secondCharacterMaxWeight)
         : base(exchangeType)
        {
            this.firstCharacterId = firstCharacterId;
            this.firstCharacterCurrentWeight = firstCharacterCurrentWeight;
            this.firstCharacterMaxWeight = firstCharacterMaxWeight;
            this.secondCharacterId = secondCharacterId;
            this.secondCharacterCurrentWeight = secondCharacterCurrentWeight;
            this.secondCharacterMaxWeight = secondCharacterMaxWeight;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(firstCharacterId);
            writer.WriteVarInt((int)firstCharacterCurrentWeight);
            writer.WriteVarInt((int)firstCharacterMaxWeight);
            writer.WriteDouble(secondCharacterId);
            writer.WriteVarInt((int)secondCharacterCurrentWeight);
            writer.WriteVarInt((int)secondCharacterMaxWeight);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            firstCharacterId = reader.ReadDouble();
            firstCharacterCurrentWeight = reader.ReadVarUhInt();
            firstCharacterMaxWeight = reader.ReadVarUhInt();
            secondCharacterId = reader.ReadDouble();
            secondCharacterCurrentWeight = reader.ReadVarUhInt();
            secondCharacterMaxWeight = reader.ReadVarUhInt();
        }
        
    }
    
}