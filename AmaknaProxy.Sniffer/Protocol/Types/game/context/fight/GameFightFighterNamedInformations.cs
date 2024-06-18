

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GameFightFighterNamedInformations : GameFightFighterInformations
    {
        public const short Id = 158;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public string name;
        public Types.PlayerStatus status;
        public int leagueId;
        public int ladderPosition;
        public bool hiddenInPrefight;
        
        public GameFightFighterNamedInformations()
        {
        }
        
        public GameFightFighterNamedInformations(double contextualId, Types.EntityDispositionInformations disposition, Types.EntityLook look, Types.GameContextBasicSpawnInformation spawnInfo, sbyte wave, Types.GameFightMinimalStats stats, uint[] previousPositions, string name, Types.PlayerStatus status, int leagueId, int ladderPosition, bool hiddenInPrefight)
         : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions)
        {
            this.name = name;
            this.status = status;
            this.leagueId = leagueId;
            this.ladderPosition = ladderPosition;
            this.hiddenInPrefight = hiddenInPrefight;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(name);
            status.Serialize(writer);
            writer.WriteVarShort((int)leagueId);
            writer.WriteInt(ladderPosition);
            writer.WriteBoolean(hiddenInPrefight);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            name = reader.ReadUTF();
            status = new Types.PlayerStatus();
            status.Deserialize(reader);
            leagueId = reader.ReadVarShort();
            ladderPosition = reader.ReadInt();
            hiddenInPrefight = reader.ReadBoolean();
        }
        
    }
    
}