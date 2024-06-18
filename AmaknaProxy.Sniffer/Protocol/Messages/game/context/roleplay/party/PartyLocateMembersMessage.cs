

// Generated on 04/03/2020 21:58:58
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PartyLocateMembersMessage : AbstractPartyMessage
    {
        public const uint Id = 5595;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.PartyMemberGeoPosition[] geopositions;
        
        public PartyLocateMembersMessage()
        {
        }
        
        public PartyLocateMembersMessage(uint partyId, Types.PartyMemberGeoPosition[] geopositions)
         : base(partyId)
        {
            this.geopositions = geopositions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)geopositions.Length);
            foreach (var entry in geopositions)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            geopositions = new Types.PartyMemberGeoPosition[limit];
            for (int i = 0; i < limit; i++)
            {
                 geopositions[i] = new Types.PartyMemberGeoPosition();
                 geopositions[i].Deserialize(reader);
            }
        }
        
    }
    
}