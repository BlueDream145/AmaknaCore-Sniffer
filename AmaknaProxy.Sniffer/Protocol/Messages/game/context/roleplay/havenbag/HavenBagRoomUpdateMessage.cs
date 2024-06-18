

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class HavenBagRoomUpdateMessage : NetworkMessage
    {
        public const uint Id = 6860;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte action;
        public Types.HavenBagRoomPreviewInformation[] roomsPreview;
        
        public HavenBagRoomUpdateMessage()
        {
        }
        
        public HavenBagRoomUpdateMessage(sbyte action, Types.HavenBagRoomPreviewInformation[] roomsPreview)
        {
            this.action = action;
            this.roomsPreview = roomsPreview;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(action);
            writer.WriteShort((short)roomsPreview.Length);
            foreach (var entry in roomsPreview)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            action = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            roomsPreview = new Types.HavenBagRoomPreviewInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                 roomsPreview[i] = new Types.HavenBagRoomPreviewInformation();
                 roomsPreview[i].Deserialize(reader);
            }
        }
        
    }
    
}