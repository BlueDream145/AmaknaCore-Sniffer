

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GameFightTaxCollectorInformations : GameFightAIInformations
    {
        public const short Id = 48;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public uint firstNameId;
        public uint lastNameId;
        public byte level;
        
        public GameFightTaxCollectorInformations()
        {
        }
        
        public GameFightTaxCollectorInformations(double contextualId, Types.EntityDispositionInformations disposition, Types.EntityLook look, Types.GameContextBasicSpawnInformation spawnInfo, sbyte wave, Types.GameFightMinimalStats stats, uint[] previousPositions, uint firstNameId, uint lastNameId, byte level)
         : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions)
        {
            this.firstNameId = firstNameId;
            this.lastNameId = lastNameId;
            this.level = level;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((int)firstNameId);
            writer.WriteVarShort((int)lastNameId);
            writer.WriteByte(level);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            firstNameId = reader.ReadVarUhShort();
            lastNameId = reader.ReadVarUhShort();
            level = reader.ReadByte();
        }
        
    }
    
}