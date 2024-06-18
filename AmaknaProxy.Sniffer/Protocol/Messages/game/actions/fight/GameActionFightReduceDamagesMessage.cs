

// Generated on 04/03/2020 21:58:48
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameActionFightReduceDamagesMessage : AbstractGameActionMessage
    {
        public const uint Id = 5526;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double targetId;
        public uint amount;
        
        public GameActionFightReduceDamagesMessage()
        {
        }
        
        public GameActionFightReduceDamagesMessage(uint actionId, double sourceId, double targetId, uint amount)
         : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.amount = amount;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(targetId);
            writer.WriteVarInt((int)amount);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadDouble();
            amount = reader.ReadVarUhInt();
        }
        
    }
    
}