

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class TaxCollectorListMessage : AbstractTaxCollectorListMessage
    {
        public const uint Id = 5930;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte nbcollectorMax;
        public Types.TaxCollectorFightersInformation[] fightersInformations;
        public sbyte infoType;
        
        public TaxCollectorListMessage()
        {
        }
        
        public TaxCollectorListMessage(Types.TaxCollectorInformations[] informations, sbyte nbcollectorMax, Types.TaxCollectorFightersInformation[] fightersInformations, sbyte infoType)
         : base(informations)
        {
            this.nbcollectorMax = nbcollectorMax;
            this.fightersInformations = fightersInformations;
            this.infoType = infoType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSbyte(nbcollectorMax);
            writer.WriteShort((short)fightersInformations.Length);
            foreach (var entry in fightersInformations)
            {
                 entry.Serialize(writer);
            }
            writer.WriteSbyte(infoType);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            nbcollectorMax = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            fightersInformations = new Types.TaxCollectorFightersInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                 fightersInformations[i] = new Types.TaxCollectorFightersInformation();
                 fightersInformations[i].Deserialize(reader);
            }
            infoType = reader.ReadSbyte();
        }
        
    }
    
}