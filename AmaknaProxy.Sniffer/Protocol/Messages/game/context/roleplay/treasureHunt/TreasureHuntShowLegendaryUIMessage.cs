

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class TreasureHuntShowLegendaryUIMessage : NetworkMessage
    {
        public const uint Id = 6498;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint[] availableLegendaryIds;
        
        public TreasureHuntShowLegendaryUIMessage()
        {
        }
        
        public TreasureHuntShowLegendaryUIMessage(uint[] availableLegendaryIds)
        {
            this.availableLegendaryIds = availableLegendaryIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)availableLegendaryIds.Length);
            foreach (var entry in availableLegendaryIds)
            {
                 writer.WriteVarShort((int)entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            availableLegendaryIds = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 availableLegendaryIds[i] = reader.ReadVarUhShort();
            }
        }
        
    }
    
}