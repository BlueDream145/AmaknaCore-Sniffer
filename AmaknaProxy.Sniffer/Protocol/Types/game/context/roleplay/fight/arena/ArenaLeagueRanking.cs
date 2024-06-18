

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ArenaLeagueRanking
    {
        public const short Id = 553;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint rank;
        public uint leagueId;
        public int leaguePoints;
        public int totalLeaguePoints;
        public int ladderPosition;
        
        public ArenaLeagueRanking()
        {
        }
        
        public ArenaLeagueRanking(uint rank, uint leagueId, int leaguePoints, int totalLeaguePoints, int ladderPosition)
        {
            this.rank = rank;
            this.leagueId = leagueId;
            this.leaguePoints = leaguePoints;
            this.totalLeaguePoints = totalLeaguePoints;
            this.ladderPosition = ladderPosition;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)rank);
            writer.WriteVarShort((int)leagueId);
            writer.WriteVarShort((int)leaguePoints);
            writer.WriteVarShort((int)totalLeaguePoints);
            writer.WriteInt(ladderPosition);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            rank = reader.ReadVarUhShort();
            leagueId = reader.ReadVarUhShort();
            leaguePoints = reader.ReadVarShort();
            totalLeaguePoints = reader.ReadVarShort();
            ladderPosition = reader.ReadInt();
        }
        
    }
    
}