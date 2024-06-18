

// Generated on 04/03/2020 21:59:02
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DecraftResultMessage : NetworkMessage
    {
        public const uint Id = 6569;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.DecraftedItemStackInfo[] results;
        
        public DecraftResultMessage()
        {
        }
        
        public DecraftResultMessage(Types.DecraftedItemStackInfo[] results)
        {
            this.results = results;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)results.Length);
            foreach (var entry in results)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            results = new Types.DecraftedItemStackInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 results[i] = new Types.DecraftedItemStackInfo();
                 results[i].Deserialize(reader);
            }
        }
        
    }
    
}