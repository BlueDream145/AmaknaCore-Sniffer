

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class IdentifiedEntityDispositionInformations : EntityDispositionInformations
    {
        public const short Id = 107;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public double id;
        
        public IdentifiedEntityDispositionInformations()
        {
        }
        
        public IdentifiedEntityDispositionInformations(short cellId, sbyte direction, double id)
         : base(cellId, direction)
        {
            this.id = id;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(id);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            id = reader.ReadDouble();
        }
        
    }
    
}