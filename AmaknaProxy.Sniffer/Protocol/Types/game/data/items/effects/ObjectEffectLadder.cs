

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ObjectEffectLadder : ObjectEffectCreature
    {
        public const short Id = 81;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public uint monsterCount;
        
        public ObjectEffectLadder()
        {
        }
        
        public ObjectEffectLadder(uint actionId, uint monsterFamilyId, uint monsterCount)
         : base(actionId, monsterFamilyId)
        {
            this.monsterCount = monsterCount;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)monsterCount);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            monsterCount = reader.ReadVarUhInt();
        }
        
    }
    
}