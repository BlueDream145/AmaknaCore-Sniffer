

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class PaddockInformations
    {
        public const short Id = 132;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint maxOutdoorMount;
        public uint maxItems;
        
        public PaddockInformations()
        {
        }
        
        public PaddockInformations(uint maxOutdoorMount, uint maxItems)
        {
            this.maxOutdoorMount = maxOutdoorMount;
            this.maxItems = maxItems;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)maxOutdoorMount);
            writer.WriteVarShort((int)maxItems);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            maxOutdoorMount = reader.ReadVarUhShort();
            maxItems = reader.ReadVarUhShort();
        }
        
    }
    
}