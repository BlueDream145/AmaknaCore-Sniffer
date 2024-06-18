

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage : GameRolePlayArenaUpdatePlayerInfosMessage
    {
        public const uint Id = 6728;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.ArenaRankInfos team;
        public Types.ArenaRankInfos duel;
        
        public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage()
        {
        }
        
        public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(Types.ArenaRankInfos solo, Types.ArenaRankInfos team, Types.ArenaRankInfos duel)
         : base(solo)
        {
            this.team = team;
            this.duel = duel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            team.Serialize(writer);
            duel.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            team = new Types.ArenaRankInfos();
            team.Deserialize(reader);
            duel = new Types.ArenaRankInfos();
            duel.Deserialize(reader);
        }
        
    }
    
}