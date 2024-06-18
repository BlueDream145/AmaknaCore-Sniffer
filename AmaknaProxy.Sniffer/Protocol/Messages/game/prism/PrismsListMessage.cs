

// Generated on 04/03/2020 21:59:06
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PrismsListMessage : NetworkMessage
    {
        public const uint Id = 6440;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.PrismSubareaEmptyInfo[] prisms;
        
        public PrismsListMessage()
        {
        }
        
        public PrismsListMessage(Types.PrismSubareaEmptyInfo[] prisms)
        {
            this.prisms = prisms;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)prisms.Length);
            foreach (var entry in prisms)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            prisms = new Types.PrismSubareaEmptyInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 prisms[i] = ProtocolTypeManager.GetInstance<Types.PrismSubareaEmptyInfo>(reader.ReadUShort());
                 prisms[i].Deserialize(reader);
            }
        }
        
    }
    
}