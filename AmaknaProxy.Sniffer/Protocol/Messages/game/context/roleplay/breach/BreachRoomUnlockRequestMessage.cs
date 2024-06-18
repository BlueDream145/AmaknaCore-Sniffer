

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachRoomUnlockRequestMessage : NetworkMessage
    {
        public const uint Id = 6863;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte roomId;
        
        public BreachRoomUnlockRequestMessage()
        {
        }
        
        public BreachRoomUnlockRequestMessage(sbyte roomId)
        {
            this.roomId = roomId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(roomId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            roomId = reader.ReadSbyte();
        }
        
    }
    
}