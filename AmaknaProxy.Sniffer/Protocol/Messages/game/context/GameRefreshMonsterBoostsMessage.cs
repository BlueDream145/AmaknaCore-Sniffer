

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameRefreshMonsterBoostsMessage : NetworkMessage
    {
        public const uint Id = 6618;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.MonsterBoosts[] monsterBoosts;
        public Types.MonsterBoosts[] familyBoosts;
        
        public GameRefreshMonsterBoostsMessage()
        {
        }
        
        public GameRefreshMonsterBoostsMessage(Types.MonsterBoosts[] monsterBoosts, Types.MonsterBoosts[] familyBoosts)
        {
            this.monsterBoosts = monsterBoosts;
            this.familyBoosts = familyBoosts;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)monsterBoosts.Length);
            foreach (var entry in monsterBoosts)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)familyBoosts.Length);
            foreach (var entry in familyBoosts)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            monsterBoosts = new Types.MonsterBoosts[limit];
            for (int i = 0; i < limit; i++)
            {
                 monsterBoosts[i] = new Types.MonsterBoosts();
                 monsterBoosts[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            familyBoosts = new Types.MonsterBoosts[limit];
            for (int i = 0; i < limit; i++)
            {
                 familyBoosts[i] = new Types.MonsterBoosts();
                 familyBoosts[i].Deserialize(reader);
            }
        }
        
    }
    
}