

// Generated on 04/03/2020 21:59:07
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class HaapiApiKeyMessage : NetworkMessage
    {
        public const uint Id = 6649;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string token;
        
        public HaapiApiKeyMessage()
        {
        }
        
        public HaapiApiKeyMessage(string token)
        {
            this.token = token;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(token);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            token = reader.ReadUTF();
        }
        
    }
    
}