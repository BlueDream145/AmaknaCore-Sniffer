

// Generated on 04/03/2020 21:58:53
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MountHarnessColorsUpdateRequestMessage : NetworkMessage
    {
        public const uint Id = 6697;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool useHarnessColors;
        
        public MountHarnessColorsUpdateRequestMessage()
        {
        }
        
        public MountHarnessColorsUpdateRequestMessage(bool useHarnessColors)
        {
            this.useHarnessColors = useHarnessColors;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(useHarnessColors);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            useHarnessColors = reader.ReadBoolean();
        }
        
    }
    
}