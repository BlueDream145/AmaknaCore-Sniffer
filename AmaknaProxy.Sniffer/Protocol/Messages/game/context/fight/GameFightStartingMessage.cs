

// Generated on 04/03/2020 21:58:53
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameFightStartingMessage : NetworkMessage
    {
        public const uint Id = 700;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte fightType;
        public uint fightId;
        public double attackerId;
        public double defenderId;
        
        public GameFightStartingMessage()
        {
        }
        
        public GameFightStartingMessage(sbyte fightType, uint fightId, double attackerId, double defenderId)
        {
            this.fightType = fightType;
            this.fightId = fightId;
            this.attackerId = attackerId;
            this.defenderId = defenderId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(fightType);
            writer.WriteVarShort((int)fightId);
            writer.WriteDouble(attackerId);
            writer.WriteDouble(defenderId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            fightType = reader.ReadSbyte();
            fightId = reader.ReadVarUhShort();
            attackerId = reader.ReadDouble();
            defenderId = reader.ReadDouble();
        }
        
    }
    
}