

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MapRunningFightListMessage : NetworkMessage
    {
        public const uint Id = 5743;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.FightExternalInformations[] fights;
        
        public MapRunningFightListMessage()
        {
        }
        
        public MapRunningFightListMessage(Types.FightExternalInformations[] fights)
        {
            this.fights = fights;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)fights.Length);
            foreach (var entry in fights)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            fights = new Types.FightExternalInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fights[i] = new Types.FightExternalInformations();
                 fights[i].Deserialize(reader);
            }
        }
        
    }
    
}