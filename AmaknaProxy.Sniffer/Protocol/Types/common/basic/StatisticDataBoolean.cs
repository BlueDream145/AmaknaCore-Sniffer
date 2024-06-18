

// Generated on 04/03/2020 21:59:08
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class StatisticDataBoolean : StatisticData
    {
        public const short Id = 482;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public bool value;
        
        public StatisticDataBoolean()
        {
        }
        
        public StatisticDataBoolean(bool value)
        {
            this.value = value;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(value);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            value = reader.ReadBoolean();
        }
        
    }
    
}