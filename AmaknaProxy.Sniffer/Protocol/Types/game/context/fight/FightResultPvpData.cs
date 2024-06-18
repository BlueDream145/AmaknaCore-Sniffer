

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FightResultPvpData : FightResultAdditionalData
    {
        public const short Id = 190;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public byte grade;
        public uint minHonorForGrade;
        public uint maxHonorForGrade;
        public uint honor;
        public int honorDelta;
        
        public FightResultPvpData()
        {
        }
        
        public FightResultPvpData(byte grade, uint minHonorForGrade, uint maxHonorForGrade, uint honor, int honorDelta)
        {
            this.grade = grade;
            this.minHonorForGrade = minHonorForGrade;
            this.maxHonorForGrade = maxHonorForGrade;
            this.honor = honor;
            this.honorDelta = honorDelta;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(grade);
            writer.WriteVarShort((int)minHonorForGrade);
            writer.WriteVarShort((int)maxHonorForGrade);
            writer.WriteVarShort((int)honor);
            writer.WriteVarShort((int)honorDelta);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            grade = reader.ReadByte();
            minHonorForGrade = reader.ReadVarUhShort();
            maxHonorForGrade = reader.ReadVarUhShort();
            honor = reader.ReadVarUhShort();
            honorDelta = reader.ReadVarShort();
        }
        
    }
    
}