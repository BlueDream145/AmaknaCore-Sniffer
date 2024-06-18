

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareVersatileListMessage : NetworkMessage
    {
        public const uint Id = 6657;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.DareVersatileInformations[] dares;
        
        public DareVersatileListMessage()
        {
        }
        
        public DareVersatileListMessage(Types.DareVersatileInformations[] dares)
        {
            this.dares = dares;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)dares.Length);
            foreach (var entry in dares)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            dares = new Types.DareVersatileInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 dares[i] = new Types.DareVersatileInformations();
                 dares[i].Deserialize(reader);
            }
        }
        
    }
    
}