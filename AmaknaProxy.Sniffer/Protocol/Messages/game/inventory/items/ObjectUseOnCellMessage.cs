

// Generated on 04/03/2020 21:59:05
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ObjectUseOnCellMessage : ObjectUseMessage
    {
        public const uint Id = 3013;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint cells;
        
        public ObjectUseOnCellMessage()
        {
        }
        
        public ObjectUseOnCellMessage(uint objectUID, uint cells)
         : base(objectUID)
        {
            this.cells = cells;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((int)cells);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            cells = reader.ReadVarUhShort();
        }
        
    }
    
}