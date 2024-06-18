

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachInvitationRequestMessage : NetworkMessage
    {
        public const uint Id = 6794;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double[] guests;
        
        public BreachInvitationRequestMessage()
        {
        }
        
        public BreachInvitationRequestMessage(double[] guests)
        {
            this.guests = guests;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)guests.Length);
            foreach (var entry in guests)
            {
                 writer.WriteVarLong(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            guests = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 guests[i] = reader.ReadVarUhLong();
            }
        }
        
    }
    
}