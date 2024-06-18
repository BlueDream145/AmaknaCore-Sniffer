

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FriendInformations : AbstractContactInformations
    {
        public const short Id = 78;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte playerState;
        public uint lastConnection;
        public int achievementPoints;
        public int leagueId;
        public int ladderPosition;
        
        public FriendInformations()
        {
        }
        
        public FriendInformations(int accountId, string accountName, sbyte playerState, uint lastConnection, int achievementPoints, int leagueId, int ladderPosition)
         : base(accountId, accountName)
        {
            this.playerState = playerState;
            this.lastConnection = lastConnection;
            this.achievementPoints = achievementPoints;
            this.leagueId = leagueId;
            this.ladderPosition = ladderPosition;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSbyte(playerState);
            writer.WriteVarShort((int)lastConnection);
            writer.WriteInt(achievementPoints);
            writer.WriteVarShort((int)leagueId);
            writer.WriteInt(ladderPosition);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            playerState = reader.ReadSbyte();
            lastConnection = reader.ReadVarUhShort();
            achievementPoints = reader.ReadInt();
            leagueId = reader.ReadVarShort();
            ladderPosition = reader.ReadInt();
        }
        
    }
    
}