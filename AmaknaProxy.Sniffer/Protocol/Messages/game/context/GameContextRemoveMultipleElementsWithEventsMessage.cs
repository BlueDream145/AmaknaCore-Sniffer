

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameContextRemoveMultipleElementsWithEventsMessage : GameContextRemoveMultipleElementsMessage
    {
        public const uint Id = 6416;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte[] elementEventIds;
        
        public GameContextRemoveMultipleElementsWithEventsMessage()
        {
        }
        
        public GameContextRemoveMultipleElementsWithEventsMessage(double[] elementsIds, sbyte[] elementEventIds)
         : base(elementsIds)
        {
            this.elementEventIds = elementEventIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)(ushort)elementEventIds.Length);
            foreach (var entry in elementEventIds)
            {
                 writer.WriteSbyte(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadVarInt();
            elementEventIds = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 elementEventIds[i] = reader.ReadSbyte();
            }
        }
        
    }
    
}