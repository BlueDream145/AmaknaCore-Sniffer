

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameFightPlacementSwapPositionsMessage : NetworkMessage
    {
        public const uint Id = 6544;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.IdentifiedEntityDispositionInformations[] dispositions;
        
        public GameFightPlacementSwapPositionsMessage()
        {
        }
        
        public GameFightPlacementSwapPositionsMessage(Types.IdentifiedEntityDispositionInformations[] dispositions)
        {
            this.dispositions = dispositions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)dispositions.Length);
            foreach (var entry in dispositions)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            dispositions = new Types.IdentifiedEntityDispositionInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 dispositions[i] = new Types.IdentifiedEntityDispositionInformations();
                 dispositions[i].Deserialize(reader);
            }
        }
        
    }
    
}