

// Generated on 04/03/2020 21:58:51
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ChatServerWithObjectMessage : ChatServerMessage
    {
        public const uint Id = 883;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.ObjectItem[] objects;
        
        public ChatServerWithObjectMessage()
        {
        }
        
        public ChatServerWithObjectMessage(sbyte channel, string content, int timestamp, string fingerprint, double senderId, string senderName, string prefix, int senderAccountId, Types.ObjectItem[] objects)
         : base(channel, content, timestamp, fingerprint, senderId, senderName, prefix, senderAccountId)
        {
            this.objects = objects;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)objects.Length);
            foreach (var entry in objects)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            objects = new Types.ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objects[i] = new Types.ObjectItem();
                 objects[i].Deserialize(reader);
            }
        }
        
    }
    
}