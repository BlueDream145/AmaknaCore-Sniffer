

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class EntitiesInformationMessage : NetworkMessage
    {
        public const uint Id = 6775;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.EntityInformation[] entities;
        
        public EntitiesInformationMessage()
        {
        }
        
        public EntitiesInformationMessage(Types.EntityInformation[] entities)
        {
            this.entities = entities;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)entities.Length);
            foreach (var entry in entities)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            entities = new Types.EntityInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                 entities[i] = new Types.EntityInformation();
                 entities[i].Deserialize(reader);
            }
        }
        
    }
    
}