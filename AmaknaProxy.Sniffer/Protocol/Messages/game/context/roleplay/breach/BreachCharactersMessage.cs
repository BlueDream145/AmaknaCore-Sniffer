

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachCharactersMessage : NetworkMessage
    {
        public const uint Id = 6811;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double[] characters;
        
        public BreachCharactersMessage()
        {
        }
        
        public BreachCharactersMessage(double[] characters)
        {
            this.characters = characters;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)characters.Length);
            foreach (var entry in characters)
            {
                 writer.WriteVarLong(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            characters = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 characters[i] = reader.ReadVarUhLong();
            }
        }
        
    }
    
}