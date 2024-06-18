

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
    {
        public const short Id = 148;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.TaxCollectorStaticInformations identification;
        public byte guildLevel;
        public int taxCollectorAttack;
        
        public GameRolePlayTaxCollectorInformations()
        {
        }
        
        public GameRolePlayTaxCollectorInformations(double contextualId, Types.EntityDispositionInformations disposition, Types.EntityLook look, Types.TaxCollectorStaticInformations identification, byte guildLevel, int taxCollectorAttack)
         : base(contextualId, disposition, look)
        {
            this.identification = identification;
            this.guildLevel = guildLevel;
            this.taxCollectorAttack = taxCollectorAttack;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(identification.TypeId);
            identification.Serialize(writer);
            writer.WriteByte(guildLevel);
            writer.WriteInt(taxCollectorAttack);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            identification = ProtocolTypeManager.GetInstance<Types.TaxCollectorStaticInformations>(reader.ReadUShort());
            identification.Deserialize(reader);
            guildLevel = reader.ReadByte();
            taxCollectorAttack = reader.ReadInt();
        }
        
    }
    
}