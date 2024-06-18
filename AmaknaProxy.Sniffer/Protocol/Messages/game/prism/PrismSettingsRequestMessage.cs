

// Generated on 04/03/2020 21:59:06
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PrismSettingsRequestMessage : NetworkMessage
    {
        public const uint Id = 6437;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint subAreaId;
        public sbyte startDefenseTime;
        
        public PrismSettingsRequestMessage()
        {
        }
        
        public PrismSettingsRequestMessage(uint subAreaId, sbyte startDefenseTime)
        {
            this.subAreaId = subAreaId;
            this.startDefenseTime = startDefenseTime;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)subAreaId);
            writer.WriteSbyte(startDefenseTime);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            subAreaId = reader.ReadVarUhShort();
            startDefenseTime = reader.ReadSbyte();
        }
        
    }
    
}