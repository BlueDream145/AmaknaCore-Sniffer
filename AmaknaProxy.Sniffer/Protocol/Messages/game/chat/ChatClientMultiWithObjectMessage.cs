

// Generated on 04/03/2020 21:58:51
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ChatClientMultiWithObjectMessage : ChatClientMultiMessage
    {
        public const uint Id = 862;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.ObjectItem[] objects;
        
        public ChatClientMultiWithObjectMessage()
        {
        }
        
        public ChatClientMultiWithObjectMessage(string content, sbyte channel, Types.ObjectItem[] objects)
         : base(content, channel)
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