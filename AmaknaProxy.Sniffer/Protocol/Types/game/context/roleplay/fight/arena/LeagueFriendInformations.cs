

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class LeagueFriendInformations : AbstractContactInformations
    {
        public const short Id = 555;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public double playerId;
        public string playerName;
        public sbyte breed;
        public bool sex;
        public uint level;
        public int leagueId;
        public int totalLeaguePoints;
        public int ladderPosition;
        
        public LeagueFriendInformations()
        {
        }
        
        public LeagueFriendInformations(int accountId, string accountName, double playerId, string playerName, sbyte breed, bool sex, uint level, int leagueId, int totalLeaguePoints, int ladderPosition)
         : base(accountId, accountName)
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.breed = breed;
            this.sex = sex;
            this.level = level;
            this.leagueId = leagueId;
            this.totalLeaguePoints = totalLeaguePoints;
            this.ladderPosition = ladderPosition;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(playerId);
            writer.WriteUTF(playerName);
            writer.WriteSbyte(breed);
            writer.WriteBoolean(sex);
            writer.WriteVarShort((int)level);
            writer.WriteVarShort((int)leagueId);
            writer.WriteVarShort((int)totalLeaguePoints);
            writer.WriteInt(ladderPosition);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            playerId = reader.ReadVarUhLong();
            playerName = reader.ReadUTF();
            breed = reader.ReadSbyte();
            sex = reader.ReadBoolean();
            level = reader.ReadVarUhShort();
            leagueId = reader.ReadVarShort();
            totalLeaguePoints = reader.ReadVarShort();
            ladderPosition = reader.ReadInt();
        }
        
    }
    
}