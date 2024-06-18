

// Generated on 04/03/2020 21:58:51
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ChatServerMessage : ChatAbstractServerMessage
    {
        public const uint Id = 881;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double senderId;
        public string senderName;
        public string prefix;
        public int senderAccountId;
        
        public ChatServerMessage()
        {
        }
        
        public ChatServerMessage(sbyte channel, string content, int timestamp, string fingerprint, double senderId, string senderName, string prefix, int senderAccountId)
         : base(channel, content, timestamp, fingerprint)
        {
            this.senderId = senderId;
            this.senderName = senderName;
            this.prefix = prefix;
            this.senderAccountId = senderAccountId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(senderId);
            writer.WriteUTF(senderName);
            writer.WriteUTF(prefix);
            writer.WriteInt(senderAccountId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            senderId = reader.ReadDouble();
            senderName = reader.ReadUTF();
            prefix = reader.ReadUTF();
            senderAccountId = reader.ReadInt();
        }
        
    }
    
}