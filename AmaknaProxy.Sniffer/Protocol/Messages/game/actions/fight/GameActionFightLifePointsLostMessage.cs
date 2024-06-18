

// Generated on 04/03/2020 21:58:48
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameActionFightLifePointsLostMessage : AbstractGameActionMessage
    {
        public const uint Id = 6312;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double targetId;
        public uint loss;
        public uint permanentDamages;
        public int elementId;
        
        public GameActionFightLifePointsLostMessage()
        {
        }
        
        public GameActionFightLifePointsLostMessage(uint actionId, double sourceId, double targetId, uint loss, uint permanentDamages, int elementId)
         : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.loss = loss;
            this.permanentDamages = permanentDamages;
            this.elementId = elementId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(targetId);
            writer.WriteVarInt((int)loss);
            writer.WriteVarInt((int)permanentDamages);
            writer.WriteVarInt((int)elementId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadDouble();
            loss = reader.ReadVarUhInt();
            permanentDamages = reader.ReadVarUhInt();
            elementId = reader.ReadVarInt();
        }
        
    }
    
}