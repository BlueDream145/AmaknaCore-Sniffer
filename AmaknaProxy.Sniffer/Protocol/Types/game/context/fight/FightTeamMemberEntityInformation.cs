

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FightTeamMemberEntityInformation : FightTeamMemberInformations
    {
        public const short Id = 549;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte entityModelId;
        public uint level;
        public double masterId;
        
        public FightTeamMemberEntityInformation()
        {
        }
        
        public FightTeamMemberEntityInformation(double id, sbyte entityModelId, uint level, double masterId)
         : base(id)
        {
            this.entityModelId = entityModelId;
            this.level = level;
            this.masterId = masterId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSbyte(entityModelId);
            writer.WriteVarShort((int)level);
            writer.WriteDouble(masterId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            entityModelId = reader.ReadSbyte();
            level = reader.ReadVarUhShort();
            masterId = reader.ReadDouble();
        }
        
    }
    
}