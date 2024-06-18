

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class StatedElement
    {
        public const short Id = 108;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int elementId;
        public uint elementCellId;
        public uint elementState;
        public bool onCurrentMap;
        
        public StatedElement()
        {
        }
        
        public StatedElement(int elementId, uint elementCellId, uint elementState, bool onCurrentMap)
        {
            this.elementId = elementId;
            this.elementCellId = elementCellId;
            this.elementState = elementState;
            this.onCurrentMap = onCurrentMap;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(elementId);
            writer.WriteVarShort((int)elementCellId);
            writer.WriteVarInt((int)elementState);
            writer.WriteBoolean(onCurrentMap);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            elementId = reader.ReadInt();
            elementCellId = reader.ReadVarUhShort();
            elementState = reader.ReadVarUhInt();
            onCurrentMap = reader.ReadBoolean();
        }
        
    }
    
}