

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class TreasureHuntStepFollowDirectionToPOI : TreasureHuntStep
    {
        public const short Id = 461;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte direction;
        public uint poiLabelId;
        
        public TreasureHuntStepFollowDirectionToPOI()
        {
        }
        
        public TreasureHuntStepFollowDirectionToPOI(sbyte direction, uint poiLabelId)
        {
            this.direction = direction;
            this.poiLabelId = poiLabelId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSbyte(direction);
            writer.WriteVarShort((int)poiLabelId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            direction = reader.ReadSbyte();
            poiLabelId = reader.ReadVarUhShort();
        }
        
    }
    
}