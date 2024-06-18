

// Generated on 04/03/2020 21:58:56
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AccountHouseMessage : NetworkMessage
    {
        public const uint Id = 6315;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.AccountHouseInformations[] houses;
        
        public AccountHouseMessage()
        {
        }
        
        public AccountHouseMessage(Types.AccountHouseInformations[] houses)
        {
            this.houses = houses;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)houses.Length);
            foreach (var entry in houses)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            houses = new Types.AccountHouseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 houses[i] = new Types.AccountHouseInformations();
                 houses[i].Deserialize(reader);
            }
        }
        
    }
    
}