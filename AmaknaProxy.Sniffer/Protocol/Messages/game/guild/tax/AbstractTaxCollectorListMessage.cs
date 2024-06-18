

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AbstractTaxCollectorListMessage : NetworkMessage
    {
        public const uint Id = 6568;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.TaxCollectorInformations[] informations;
        
        public AbstractTaxCollectorListMessage()
        {
        }
        
        public AbstractTaxCollectorListMessage(Types.TaxCollectorInformations[] informations)
        {
            this.informations = informations;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)informations.Length);
            foreach (var entry in informations)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            informations = new Types.TaxCollectorInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 informations[i] = ProtocolTypeManager.GetInstance<Types.TaxCollectorInformations>(reader.ReadUShort());
                 informations[i].Deserialize(reader);
            }
        }
        
    }
    
}