

// Generated on 04/03/2020 21:59:07
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ProtocolRequired : NetworkMessage
    {
        public const uint Id = 1;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int requiredVersion;
        public int currentVersion;
        
        public ProtocolRequired()
        {
        }
        
        public ProtocolRequired(int requiredVersion, int currentVersion)
        {
            this.requiredVersion = requiredVersion;
            this.currentVersion = currentVersion;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(requiredVersion);
            writer.WriteInt(currentVersion);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            requiredVersion = reader.ReadInt();
            currentVersion = reader.ReadInt();
        }
        
    }
    
}