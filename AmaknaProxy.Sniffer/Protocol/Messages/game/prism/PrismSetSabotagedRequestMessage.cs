

// Generated on 04/03/2020 21:59:06
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PrismSetSabotagedRequestMessage : NetworkMessage
    {
        public const uint Id = 6468;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint subAreaId;
        
        public PrismSetSabotagedRequestMessage()
        {
        }
        
        public PrismSetSabotagedRequestMessage(uint subAreaId)
        {
            this.subAreaId = subAreaId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)subAreaId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            subAreaId = reader.ReadVarUhShort();
        }
        
    }
    
}