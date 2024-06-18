

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class JobBookSubscription
    {
        public const short Id = 500;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte jobId;
        public bool subscribed;
        
        public JobBookSubscription()
        {
        }
        
        public JobBookSubscription(sbyte jobId, bool subscribed)
        {
            this.jobId = jobId;
            this.subscribed = subscribed;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(jobId);
            writer.WriteBoolean(subscribed);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            jobId = reader.ReadSbyte();
            subscribed = reader.ReadBoolean();
        }
        
    }
    
}