

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class TreasureHuntStepFollowDirectionToHint : TreasureHuntStep
    {
        public const short Id = 472;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte direction;
        public uint npcId;
        
        public TreasureHuntStepFollowDirectionToHint()
        {
        }
        
        public TreasureHuntStepFollowDirectionToHint(sbyte direction, uint npcId)
        {
            this.direction = direction;
            this.npcId = npcId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSbyte(direction);
            writer.WriteVarShort((int)npcId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            direction = reader.ReadSbyte();
            npcId = reader.ReadVarUhShort();
        }
        
    }
    
}