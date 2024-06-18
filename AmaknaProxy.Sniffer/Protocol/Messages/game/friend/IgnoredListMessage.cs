

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class IgnoredListMessage : NetworkMessage
    {
        public const uint Id = 5674;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.IgnoredInformations[] ignoredList;
        
        public IgnoredListMessage()
        {
        }
        
        public IgnoredListMessage(Types.IgnoredInformations[] ignoredList)
        {
            this.ignoredList = ignoredList;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)ignoredList.Length);
            foreach (var entry in ignoredList)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            ignoredList = new Types.IgnoredInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 ignoredList[i] = ProtocolTypeManager.GetInstance<Types.IgnoredInformations>(reader.ReadUShort());
                 ignoredList[i].Deserialize(reader);
            }
        }
        
    }
    
}