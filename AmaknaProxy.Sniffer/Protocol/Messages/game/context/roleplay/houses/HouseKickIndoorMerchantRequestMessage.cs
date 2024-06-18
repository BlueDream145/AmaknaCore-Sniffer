

// Generated on 04/03/2020 21:58:56
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class HouseKickIndoorMerchantRequestMessage : NetworkMessage
    {
        public const uint Id = 5661;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint cellId;
        
        public HouseKickIndoorMerchantRequestMessage()
        {
        }
        
        public HouseKickIndoorMerchantRequestMessage(uint cellId)
        {
            this.cellId = cellId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)cellId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            cellId = reader.ReadVarUhShort();
        }
        
    }
    
}