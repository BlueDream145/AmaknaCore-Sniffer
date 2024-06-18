

// Generated on 04/03/2020 21:59:06
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class StorageObjectsUpdateMessage : NetworkMessage
    {
        public const uint Id = 6036;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.ObjectItem[] objectList;
        
        public StorageObjectsUpdateMessage()
        {
        }
        
        public StorageObjectsUpdateMessage(Types.ObjectItem[] objectList)
        {
            this.objectList = objectList;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)objectList.Length);
            foreach (var entry in objectList)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            objectList = new Types.ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectList[i] = new Types.ObjectItem();
                 objectList[i].Deserialize(reader);
            }
        }
        
    }
    
}