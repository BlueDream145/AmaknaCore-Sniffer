

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class DareInformations
    {
        public const short Id = 502;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public double dareId;
        public Types.CharacterBasicMinimalInformations creator;
        public double subscriptionFee;
        public double jackpot;
        public ushort maxCountWinners;
        public double endDate;
        public bool isPrivate;
        public uint guildId;
        public uint allianceId;
        public Types.DareCriteria[] criterions;
        public double startDate;
        
        public DareInformations()
        {
        }
        
        public DareInformations(double dareId, Types.CharacterBasicMinimalInformations creator, double subscriptionFee, double jackpot, ushort maxCountWinners, double endDate, bool isPrivate, uint guildId, uint allianceId, Types.DareCriteria[] criterions, double startDate)
        {
            this.dareId = dareId;
            this.creator = creator;
            this.subscriptionFee = subscriptionFee;
            this.jackpot = jackpot;
            this.maxCountWinners = maxCountWinners;
            this.endDate = endDate;
            this.isPrivate = isPrivate;
            this.guildId = guildId;
            this.allianceId = allianceId;
            this.criterions = criterions;
            this.startDate = startDate;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(dareId);
            creator.Serialize(writer);
            writer.WriteVarLong(subscriptionFee);
            writer.WriteVarLong(jackpot);
            writer.WriteUShort(maxCountWinners);
            writer.WriteDouble(endDate);
            writer.WriteBoolean(isPrivate);
            writer.WriteVarInt((int)guildId);
            writer.WriteVarInt((int)allianceId);
            writer.WriteShort((short)criterions.Length);
            foreach (var entry in criterions)
            {
                 entry.Serialize(writer);
            }
            writer.WriteDouble(startDate);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            dareId = reader.ReadDouble();
            creator = new Types.CharacterBasicMinimalInformations();
            creator.Deserialize(reader);
            subscriptionFee = reader.ReadVarUhLong();
            jackpot = reader.ReadVarUhLong();
            maxCountWinners = reader.ReadUShort();
            endDate = reader.ReadDouble();
            isPrivate = reader.ReadBoolean();
            guildId = reader.ReadVarUhInt();
            allianceId = reader.ReadVarUhInt();
            var limit = (ushort)reader.ReadUShort();
            criterions = new Types.DareCriteria[limit];
            for (int i = 0; i < limit; i++)
            {
                 criterions[i] = new Types.DareCriteria();
                 criterions[i].Deserialize(reader);
            }
            startDate = reader.ReadDouble();
        }
        
    }
    
}