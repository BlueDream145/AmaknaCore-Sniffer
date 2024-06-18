

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameRolePlayMonsterAngryAtPlayerMessage : NetworkMessage
    {
        public const uint Id = 6741;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double playerId;
        public double monsterGroupId;
        public double angryStartTime;
        public double attackTime;
        
        public GameRolePlayMonsterAngryAtPlayerMessage()
        {
        }
        
        public GameRolePlayMonsterAngryAtPlayerMessage(double playerId, double monsterGroupId, double angryStartTime, double attackTime)
        {
            this.playerId = playerId;
            this.monsterGroupId = monsterGroupId;
            this.angryStartTime = angryStartTime;
            this.attackTime = attackTime;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(playerId);
            writer.WriteDouble(monsterGroupId);
            writer.WriteDouble(angryStartTime);
            writer.WriteDouble(attackTime);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            playerId = reader.ReadVarUhLong();
            monsterGroupId = reader.ReadDouble();
            angryStartTime = reader.ReadDouble();
            attackTime = reader.ReadDouble();
        }
        
    }
    
}