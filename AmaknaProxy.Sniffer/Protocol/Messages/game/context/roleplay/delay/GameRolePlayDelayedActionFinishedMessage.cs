

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameRolePlayDelayedActionFinishedMessage : NetworkMessage
    {
        public const uint Id = 6150;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double delayedCharacterId;
        public sbyte delayTypeId;
        
        public GameRolePlayDelayedActionFinishedMessage()
        {
        }
        
        public GameRolePlayDelayedActionFinishedMessage(double delayedCharacterId, sbyte delayTypeId)
        {
            this.delayedCharacterId = delayedCharacterId;
            this.delayTypeId = delayTypeId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(delayedCharacterId);
            writer.WriteSbyte(delayTypeId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            delayedCharacterId = reader.ReadDouble();
            delayTypeId = reader.ReadSbyte();
        }
        
    }
    
}