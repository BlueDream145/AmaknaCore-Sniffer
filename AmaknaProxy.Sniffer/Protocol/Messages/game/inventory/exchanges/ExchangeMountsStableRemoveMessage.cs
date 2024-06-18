

// Generated on 04/03/2020 21:59:03
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeMountsStableRemoveMessage : NetworkMessage
    {
        public const uint Id = 6556;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int[] mountsId;
        
        public ExchangeMountsStableRemoveMessage()
        {
        }
        
        public ExchangeMountsStableRemoveMessage(int[] mountsId)
        {
            this.mountsId = mountsId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)mountsId.Length);
            foreach (var entry in mountsId)
            {
                 writer.WriteVarInt((int)entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            mountsId = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 mountsId[i] = reader.ReadVarInt();
            }
        }
        
    }
    
}