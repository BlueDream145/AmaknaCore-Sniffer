

// Generated on 04/03/2020 21:59:04
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage
    {
        public const uint Id = 5979;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.MountClientData[] paddockedMountsDescription;
        
        public ExchangeStartOkMountMessage()
        {
        }
        
        public ExchangeStartOkMountMessage(Types.MountClientData[] stabledMountsDescription, Types.MountClientData[] paddockedMountsDescription)
         : base(stabledMountsDescription)
        {
            this.paddockedMountsDescription = paddockedMountsDescription;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)paddockedMountsDescription.Length);
            foreach (var entry in paddockedMountsDescription)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            paddockedMountsDescription = new Types.MountClientData[limit];
            for (int i = 0; i < limit; i++)
            {
                 paddockedMountsDescription[i] = new Types.MountClientData();
                 paddockedMountsDescription[i].Deserialize(reader);
            }
        }
        
    }
    
}