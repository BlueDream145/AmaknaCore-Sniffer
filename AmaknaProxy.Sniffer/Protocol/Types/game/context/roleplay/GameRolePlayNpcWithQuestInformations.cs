

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations
    {
        public const short Id = 383;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.GameRolePlayNpcQuestFlag questFlag;
        
        public GameRolePlayNpcWithQuestInformations()
        {
        }
        
        public GameRolePlayNpcWithQuestInformations(double contextualId, Types.EntityDispositionInformations disposition, Types.EntityLook look, uint npcId, bool sex, uint specialArtworkId, Types.GameRolePlayNpcQuestFlag questFlag)
         : base(contextualId, disposition, look, npcId, sex, specialArtworkId)
        {
            this.questFlag = questFlag;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            questFlag.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            questFlag = new Types.GameRolePlayNpcQuestFlag();
            questFlag.Deserialize(reader);
        }
        
    }
    
}