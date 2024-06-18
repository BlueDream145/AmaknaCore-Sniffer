

// Generated on 04/03/2020 21:58:56
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class JobDescriptionMessage : NetworkMessage
    {
        public const uint Id = 5655;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.JobDescription[] jobsDescription;
        
        public JobDescriptionMessage()
        {
        }
        
        public JobDescriptionMessage(Types.JobDescription[] jobsDescription)
        {
            this.jobsDescription = jobsDescription;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)jobsDescription.Length);
            foreach (var entry in jobsDescription)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            jobsDescription = new Types.JobDescription[limit];
            for (int i = 0; i < limit; i++)
            {
                 jobsDescription[i] = new Types.JobDescription();
                 jobsDescription[i].Deserialize(reader);
            }
        }
        
    }
    
}