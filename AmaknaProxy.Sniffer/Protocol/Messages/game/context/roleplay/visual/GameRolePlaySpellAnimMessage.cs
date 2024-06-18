

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameRolePlaySpellAnimMessage : NetworkMessage
    {
        public const uint Id = 6114;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double casterId;
        public uint targetCellId;
        public uint spellId;
        public short spellLevel;
        
        public GameRolePlaySpellAnimMessage()
        {
        }
        
        public GameRolePlaySpellAnimMessage(double casterId, uint targetCellId, uint spellId, short spellLevel)
        {
            this.casterId = casterId;
            this.targetCellId = targetCellId;
            this.spellId = spellId;
            this.spellLevel = spellLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(casterId);
            writer.WriteVarShort((int)targetCellId);
            writer.WriteVarShort((int)spellId);
            writer.WriteShort(spellLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            casterId = reader.ReadVarUhLong();
            targetCellId = reader.ReadVarUhShort();
            spellId = reader.ReadVarUhShort();
            spellLevel = reader.ReadShort();
        }
        
    }
    
}