

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareCreatedMessage : NetworkMessage
    {
        public const uint Id = 6668;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.DareInformations dareInfos;
        public bool needNotifications;
        
        public DareCreatedMessage()
        {
        }
        
        public DareCreatedMessage(Types.DareInformations dareInfos, bool needNotifications)
        {
            this.dareInfos = dareInfos;
            this.needNotifications = needNotifications;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            dareInfos.Serialize(writer);
            writer.WriteBoolean(needNotifications);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            dareInfos = new Types.DareInformations();
            dareInfos.Deserialize(reader);
            needNotifications = reader.ReadBoolean();
        }
        
    }
    
}