

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
    {
        public const short Id = 160;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public bool keyRingBonus;
        public bool hasHardcoreDrop;
        public bool hasAVARewardToken;
        public Types.GroupMonsterStaticInformations staticInfos;
        public sbyte lootShare;
        public sbyte alignmentSide;
        
        public GameRolePlayGroupMonsterInformations()
        {
        }
        
        public GameRolePlayGroupMonsterInformations(double contextualId, Types.EntityDispositionInformations disposition, Types.EntityLook look, bool keyRingBonus, bool hasHardcoreDrop, bool hasAVARewardToken, Types.GroupMonsterStaticInformations staticInfos, sbyte lootShare, sbyte alignmentSide)
         : base(contextualId, disposition, look)
        {
            this.keyRingBonus = keyRingBonus;
            this.hasHardcoreDrop = hasHardcoreDrop;
            this.hasAVARewardToken = hasAVARewardToken;
            this.staticInfos = staticInfos;
            this.lootShare = lootShare;
            this.alignmentSide = alignmentSide;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, keyRingBonus);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, hasHardcoreDrop);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, hasAVARewardToken);
            writer.WriteByte(flag1);
            writer.WriteShort(staticInfos.TypeId);
            staticInfos.Serialize(writer);
            writer.WriteSbyte(lootShare);
            writer.WriteSbyte(alignmentSide);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            keyRingBonus = BooleanByteWrapper.GetFlag(flag1, 0);
            hasHardcoreDrop = BooleanByteWrapper.GetFlag(flag1, 1);
            hasAVARewardToken = BooleanByteWrapper.GetFlag(flag1, 2);
            staticInfos = ProtocolTypeManager.GetInstance<Types.GroupMonsterStaticInformations>(reader.ReadUShort());
            staticInfos.Deserialize(reader);
            lootShare = reader.ReadSbyte();
            alignmentSide = reader.ReadSbyte();
        }
        
    }
    
}