

// Generated on 04/03/2020 21:59:06
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PopupWarningMessage : NetworkMessage
    {
        public const uint Id = 6134;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public byte lockDuration;
        public string author;
        public string content;
        
        public PopupWarningMessage()
        {
        }
        
        public PopupWarningMessage(byte lockDuration, string author, string content)
        {
            this.lockDuration = lockDuration;
            this.author = author;
            this.content = content;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(lockDuration);
            writer.WriteUTF(author);
            writer.WriteUTF(content);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            lockDuration = reader.ReadByte();
            author = reader.ReadUTF();
            content = reader.ReadUTF();
        }
        
    }
    
}