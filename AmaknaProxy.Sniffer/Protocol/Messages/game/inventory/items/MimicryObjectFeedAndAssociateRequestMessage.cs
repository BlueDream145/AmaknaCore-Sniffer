

// Generated on 04/03/2020 21:59:05
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MimicryObjectFeedAndAssociateRequestMessage : SymbioticObjectAssociateRequestMessage
    {
        public const uint Id = 6460;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint foodUID;
        public byte foodPos;
        public bool preview;
        
        public MimicryObjectFeedAndAssociateRequestMessage()
        {
        }
        
        public MimicryObjectFeedAndAssociateRequestMessage(uint symbioteUID, byte symbiotePos, uint hostUID, byte hostPos, uint foodUID, byte foodPos, bool preview)
         : base(symbioteUID, symbiotePos, hostUID, hostPos)
        {
            this.foodUID = foodUID;
            this.foodPos = foodPos;
            this.preview = preview;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)foodUID);
            writer.WriteByte(foodPos);
            writer.WriteBoolean(preview);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            foodUID = reader.ReadVarUhInt();
            foodPos = reader.ReadByte();
            preview = reader.ReadBoolean();
        }
        
    }
    
}