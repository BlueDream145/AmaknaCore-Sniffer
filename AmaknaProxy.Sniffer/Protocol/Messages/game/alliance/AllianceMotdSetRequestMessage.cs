

// Generated on 04/03/2020 21:58:49
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AllianceMotdSetRequestMessage : SocialNoticeSetRequestMessage
    {
        public const uint Id = 6687;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string content;
        
        public AllianceMotdSetRequestMessage()
        {
        }
        
        public AllianceMotdSetRequestMessage(string content)
        {
            this.content = content;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(content);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            content = reader.ReadUTF();
        }
        
    }
    
}