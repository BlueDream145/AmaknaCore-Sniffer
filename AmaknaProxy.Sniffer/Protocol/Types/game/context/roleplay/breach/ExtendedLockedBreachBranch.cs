

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ExtendedLockedBreachBranch : ExtendedBreachBranch
    {
        public const short Id = 578;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public uint unlockPrice;
        
        public ExtendedLockedBreachBranch()
        {
        }
        
        public ExtendedLockedBreachBranch(sbyte room, int element, Types.MonsterInGroupLightInformations[] bosses, double map, short score, short relativeScore, Types.MonsterInGroupLightInformations[] monsters, Types.BreachReward[] rewards, int modifier, uint prize, uint unlockPrice)
         : base(room, element, bosses, map, score, relativeScore, monsters, rewards, modifier, prize)
        {
            this.unlockPrice = unlockPrice;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)unlockPrice);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            unlockPrice = reader.ReadVarUhInt();
        }
        
    }
    
}