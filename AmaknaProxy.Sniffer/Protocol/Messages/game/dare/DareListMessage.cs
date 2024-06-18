

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareListMessage : NetworkMessage
    {
        public const uint Id = 6661;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.DareInformations[] dares;
        
        public DareListMessage()
        {
        }
        
        public DareListMessage(Types.DareInformations[] dares)
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
            dares = new Types.DareInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 dares[i] = new Types.DareInformations();
                 dares[i].Deserialize(reader);
            }
        }
        
    }
    
}