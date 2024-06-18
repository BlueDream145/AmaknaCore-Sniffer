

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class FriendAddRequestMessage : NetworkMessage
    {
        public const uint Id = 4004;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string name;
        
        public FriendAddRequestMessage()
        {
        }
        
        public FriendAddRequestMessage(string name)
        {
            this.name = name;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(name);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            name = reader.ReadUTF();
        }
        
    }
    
}