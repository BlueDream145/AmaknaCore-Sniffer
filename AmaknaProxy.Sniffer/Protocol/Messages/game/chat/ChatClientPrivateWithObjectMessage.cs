

// Generated on 04/03/2020 21:58:51
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ChatClientPrivateWithObjectMessage : ChatClientPrivateMessage
    {
        public const uint Id = 852;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.ObjectItem[] objects;
        
        public ChatClientPrivateWithObjectMessage()
        {
        }
        
        public ChatClientPrivateWithObjectMessage(string content, string receiver, Types.ObjectItem[] objects)
         : base(content, receiver)
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