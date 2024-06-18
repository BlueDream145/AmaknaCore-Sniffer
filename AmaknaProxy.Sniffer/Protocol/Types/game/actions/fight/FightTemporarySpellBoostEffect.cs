

// Generated on 04/03/2020 21:59:08
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class FightTemporarySpellBoostEffect : FightTemporaryBoostEffect
    {
        public const short Id = 207;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public uint boostedSpellId;
        
        public FightTemporarySpellBoostEffect()
        {
        }
        
        public FightTemporarySpellBoostEffect(uint uid, double targetId, short turnDuration, sbyte dispelable, uint spellId, uint effectId, uint parentBoostUid, int delta, uint boostedSpellId)
         : base(uid, targetId, turnDuration, dispelable, spellId, effectId, parentBoostUid, delta)
        {
            this.boostedSpellId = boostedSpellId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((int)boostedSpellId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            boostedSpellId = reader.ReadVarUhShort();
        }
        
    }
    
}