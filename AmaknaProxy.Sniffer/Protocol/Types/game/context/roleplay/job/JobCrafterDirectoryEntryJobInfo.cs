

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class JobCrafterDirectoryEntryJobInfo
    {
        public const short Id = 195;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte jobId;
        public byte jobLevel;
        public bool free;
        public byte minLevel;
        
        public JobCrafterDirectoryEntryJobInfo()
        {
        }
        
        public JobCrafterDirectoryEntryJobInfo(sbyte jobId, byte jobLevel, bool free, byte minLevel)
        {
            this.jobId = jobId;
            this.jobLevel = jobLevel;
            this.free = free;
            this.minLevel = minLevel;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(jobId);
            writer.WriteByte(jobLevel);
            writer.WriteBoolean(free);
            writer.WriteByte(minLevel);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            jobId = reader.ReadSbyte();
            jobLevel = reader.ReadByte();
            free = reader.ReadBoolean();
            minLevel = reader.ReadByte();
        }
        
    }
    
}