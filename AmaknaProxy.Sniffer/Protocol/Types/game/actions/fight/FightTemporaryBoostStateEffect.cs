

// Generated on 04/03/2020 21:59:08
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FightTemporaryBoostStateEffect : FightTemporaryBoostEffect
    {
        public const short Id = 214;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short stateId;
        
        public FightTemporaryBoostStateEffect()
        {
        }
        
        public FightTemporaryBoostStateEffect(uint uid, double targetId, short turnDuration, sbyte dispelable, uint spellId, uint effectId, uint parentBoostUid, int delta, short stateId)
         : base(uid, targetId, turnDuration, dispelable, spellId, effectId, parentBoostUid, delta)
        {
            this.stateId = stateId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(stateId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            stateId = reader.ReadShort();
        }
        
    }
    
}