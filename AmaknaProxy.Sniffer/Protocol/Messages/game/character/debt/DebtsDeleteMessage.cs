

// Generated on 04/03/2020 21:58:51
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DebtsDeleteMessage : NetworkMessage
    {
        public const uint Id = 6866;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte reason;
        public double[] debts;
        
        public DebtsDeleteMessage()
        {
        }
        
        public DebtsDeleteMessage(sbyte reason, double[] debts)
        {
            this.reason = reason;
            this.debts = debts;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(reason);
            writer.WriteShort((short)debts.Length);
            foreach (var entry in debts)
            {
                 writer.WriteDouble(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            reason = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            debts = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 debts[i] = reader.ReadDouble();
            }
        }
        
    }
    
}