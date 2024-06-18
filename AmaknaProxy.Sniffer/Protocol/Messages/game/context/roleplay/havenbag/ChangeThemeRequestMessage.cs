

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ChangeThemeRequestMessage : NetworkMessage
    {
        public const uint Id = 6639;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte theme;
        
        public ChangeThemeRequestMessage()
        {
        }
        
        public ChangeThemeRequestMessage(sbyte theme)
        {
            this.theme = theme;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(theme);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            theme = reader.ReadSbyte();
        }
        
    }
    
}