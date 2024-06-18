

// Generated on 04/03/2020 21:58:56
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class JobCrafterDirectoryListMessage : NetworkMessage
    {
        public const uint Id = 6046;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.JobCrafterDirectoryListEntry[] listEntries;
        
        public JobCrafterDirectoryListMessage()
        {
        }
        
        public JobCrafterDirectoryListMessage(Types.JobCrafterDirectoryListEntry[] listEntries)
        {
            this.listEntries = listEntries;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)listEntries.Length);
            foreach (var entry in listEntries)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            listEntries = new Types.JobCrafterDirectoryListEntry[limit];
            for (int i = 0; i < limit; i++)
            {
                 listEntries[i] = new Types.JobCrafterDirectoryListEntry();
                 listEntries[i].Deserialize(reader);
            }
        }
        
    }
    
}