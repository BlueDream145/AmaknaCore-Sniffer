

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareWonListMessage : NetworkMessage
    {
        public const uint Id = 6682;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double[] dareId;
        
        public DareWonListMessage()
        {
        }
        
        public DareWonListMessage(double[] dareId)
        {
            this.dareId = dareId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)dareId.Length);
            foreach (var entry in dareId)
            {
                 writer.WriteDouble(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            dareId = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 dareId[i] = reader.ReadDouble();
            }
        }
        
    }
    
}