

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AllianceVersatileInfoListMessage : NetworkMessage
    {
        public const uint Id = 6436;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.AllianceVersatileInformations[] alliances;
        
        public AllianceVersatileInfoListMessage()
        {
        }
        
        public AllianceVersatileInfoListMessage(Types.AllianceVersatileInformations[] alliances)
        {
            this.alliances = alliances;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)alliances.Length);
            foreach (var entry in alliances)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            alliances = new Types.AllianceVersatileInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 alliances[i] = new Types.AllianceVersatileInformations();
                 alliances[i].Deserialize(reader);
            }
        }
        
    }
    
}