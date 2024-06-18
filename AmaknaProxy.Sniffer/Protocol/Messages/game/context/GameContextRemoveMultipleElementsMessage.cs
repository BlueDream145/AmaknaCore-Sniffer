

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameContextRemoveMultipleElementsMessage : NetworkMessage
    {
        public const uint Id = 252;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double[] elementsIds;
        
        public GameContextRemoveMultipleElementsMessage()
        {
        }
        
        public GameContextRemoveMultipleElementsMessage(double[] elementsIds)
        {
            this.elementsIds = elementsIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)elementsIds.Length);
            foreach (var entry in elementsIds)
            {
                 writer.WriteDouble(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            elementsIds = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 elementsIds[i] = reader.ReadDouble();
            }
        }
        
    }
    
}