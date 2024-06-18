

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GameFightMonsterInformations : GameFightAIInformations
    {
        public const short Id = 29;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public uint creatureGenericId;
        public sbyte creatureGrade;
        public short creatureLevel;
        
        public GameFightMonsterInformations()
        {
        }
        
        public GameFightMonsterInformations(double contextualId, Types.EntityDispositionInformations disposition, Types.EntityLook look, Types.GameContextBasicSpawnInformation spawnInfo, sbyte wave, Types.GameFightMinimalStats stats, uint[] previousPositions, uint creatureGenericId, sbyte creatureGrade, short creatureLevel)
         : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions)
        {
            this.creatureGenericId = creatureGenericId;
            this.creatureGrade = creatureGrade;
            this.creatureLevel = creatureLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((int)creatureGenericId);
            writer.WriteSbyte(creatureGrade);
            writer.WriteShort(creatureLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            creatureGenericId = reader.ReadVarUhShort();
            creatureGrade = reader.ReadSbyte();
            creatureLevel = reader.ReadShort();
        }
        
    }
    
}