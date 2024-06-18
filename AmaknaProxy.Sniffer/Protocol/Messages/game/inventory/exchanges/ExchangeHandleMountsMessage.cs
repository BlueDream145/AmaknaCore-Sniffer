

// Generated on 04/03/2020 21:59:03
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeHandleMountsMessage : NetworkMessage
    {
        public const uint Id = 6752;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte actionType;
        public uint[] ridesId;
        
        public ExchangeHandleMountsMessage()
        {
        }
        
        public ExchangeHandleMountsMessage(sbyte actionType, uint[] ridesId)
        {
            this.actionType = actionType;
            this.ridesId = ridesId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(actionType);
            writer.WriteShort((short)ridesId.Length);
            foreach (var entry in ridesId)
            {
                 writer.WriteVarInt((int)entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            actionType = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            ridesId = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 ridesId[i] = reader.ReadVarUhInt();
            }
        }
        
    }
    
}