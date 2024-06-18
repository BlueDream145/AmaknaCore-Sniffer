

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class KohUpdateMessage : NetworkMessage
    {
        public const uint Id = 6439;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.AllianceInformations[] alliances;
        public uint[] allianceNbMembers;
        public uint[] allianceRoundWeigth;
        public sbyte[] allianceMatchScore;
        public Types.BasicAllianceInformations[] allianceMapWinners;
        public uint allianceMapWinnerScore;
        public uint allianceMapMyAllianceScore;
        public double nextTickTime;
        
        public KohUpdateMessage()
        {
        }
        
        public KohUpdateMessage(Types.AllianceInformations[] alliances, uint[] allianceNbMembers, uint[] allianceRoundWeigth, sbyte[] allianceMatchScore, Types.BasicAllianceInformations[] allianceMapWinners, uint allianceMapWinnerScore, uint allianceMapMyAllianceScore, double nextTickTime)
        {
            this.alliances = alliances;
            this.allianceNbMembers = allianceNbMembers;
            this.allianceRoundWeigth = allianceRoundWeigth;
            this.allianceMatchScore = allianceMatchScore;
            this.allianceMapWinners = allianceMapWinners;
            this.allianceMapWinnerScore = allianceMapWinnerScore;
            this.allianceMapMyAllianceScore = allianceMapMyAllianceScore;
            this.nextTickTime = nextTickTime;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)alliances.Length);
            foreach (var entry in alliances)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)allianceNbMembers.Length);
            foreach (var entry in allianceNbMembers)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteShort((short)allianceRoundWeigth.Length);
            foreach (var entry in allianceRoundWeigth)
            {
                 writer.WriteVarInt((int)entry);
            }
            writer.WriteVarInt((int)(ushort)allianceMatchScore.Length);
            foreach (var entry in allianceMatchScore)
            {
                 writer.WriteSbyte(entry);
            }
            writer.WriteShort((short)allianceMapWinners.Length);
            foreach (var entry in allianceMapWinners)
            {
                 entry.Serialize(writer);
            }
            writer.WriteVarInt((int)allianceMapWinnerScore);
            writer.WriteVarInt((int)allianceMapMyAllianceScore);
            writer.WriteDouble(nextTickTime);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            alliances = new Types.AllianceInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 alliances[i] = new Types.AllianceInformations();
                 alliances[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            allianceNbMembers = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 allianceNbMembers[i] = reader.ReadVarUhShort();
            }
            limit = (ushort)reader.ReadUShort();
            allianceRoundWeigth = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 allianceRoundWeigth[i] = reader.ReadVarUhInt();
            }
            limit = (ushort)reader.ReadVarInt();
            allianceMatchScore = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 allianceMatchScore[i] = reader.ReadSbyte();
            }
            limit = (ushort)reader.ReadUShort();
            allianceMapWinners = new Types.BasicAllianceInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 allianceMapWinners[i] = new Types.BasicAllianceInformations();
                 allianceMapWinners[i].Deserialize(reader);
            }
            allianceMapWinnerScore = reader.ReadVarUhInt();
            allianceMapMyAllianceScore = reader.ReadVarUhInt();
            nextTickTime = reader.ReadDouble();
        }
        
    }
    
}