

// Generated on 04/03/2020 21:59:02
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class StatedMapUpdateMessage : NetworkMessage
    {
        public const uint Id = 5716;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.StatedElement[] statedElements;
        
        public StatedMapUpdateMessage()
        {
        }
        
        public StatedMapUpdateMessage(Types.StatedElement[] statedElements)
        {
            this.statedElements = statedElements;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)statedElements.Length);
            foreach (var entry in statedElements)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            statedElements = new Types.StatedElement[limit];
            for (int i = 0; i < limit; i++)
            {
                 statedElements[i] = new Types.StatedElement();
                 statedElements[i].Deserialize(reader);
            }
        }
        
    }
    
}