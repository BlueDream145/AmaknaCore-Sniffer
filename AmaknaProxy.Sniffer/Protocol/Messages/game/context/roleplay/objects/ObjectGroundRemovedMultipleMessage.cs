

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ObjectGroundRemovedMultipleMessage : NetworkMessage
    {
        public const uint Id = 5944;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint[] cells;
        
        public ObjectGroundRemovedMultipleMessage()
        {
        }
        
        public ObjectGroundRemovedMultipleMessage(uint[] cells)
        {
            this.cells = cells;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)cells.Length);
            foreach (var entry in cells)
            {
                 writer.WriteVarShort((int)entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            cells = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 cells[i] = reader.ReadVarUhShort();
            }
        }
        
    }
    
}