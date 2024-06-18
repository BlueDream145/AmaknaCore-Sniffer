

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AcquaintancesListMessage : NetworkMessage
    {
        public const uint Id = 6820;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.AcquaintanceInformation[] acquaintanceList;
        
        public AcquaintancesListMessage()
        {
        }
        
        public AcquaintancesListMessage(Types.AcquaintanceInformation[] acquaintanceList)
        {
            this.acquaintanceList = acquaintanceList;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)acquaintanceList.Length);
            foreach (var entry in acquaintanceList)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            acquaintanceList = new Types.AcquaintanceInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                 acquaintanceList[i] = ProtocolTypeManager.GetInstance<Types.AcquaintanceInformation>(reader.ReadUShort());
                 acquaintanceList[i].Deserialize(reader);
            }
        }
        
    }
    
}