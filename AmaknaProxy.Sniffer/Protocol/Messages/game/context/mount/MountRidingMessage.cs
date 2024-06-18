

// Generated on 04/03/2020 21:58:53
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MountRidingMessage : NetworkMessage
    {
        public const uint Id = 5967;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool isRiding;
        public bool isAutopilot;
        
        public MountRidingMessage()
        {
        }
        
        public MountRidingMessage(bool isRiding, bool isAutopilot)
        {
            this.isRiding = isRiding;
            this.isAutopilot = isAutopilot;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isRiding);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isAutopilot);
            writer.WriteByte(flag1);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            isRiding = BooleanByteWrapper.GetFlag(flag1, 0);
            isAutopilot = BooleanByteWrapper.GetFlag(flag1, 1);
        }
        
    }
    
}