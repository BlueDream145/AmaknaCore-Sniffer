

// Generated on 04/03/2020 21:58:48
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameActionFightNoSpellCastMessage : NetworkMessage
    {
        public const uint Id = 6132;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint spellLevelId;
        
        public GameActionFightNoSpellCastMessage()
        {
        }
        
        public GameActionFightNoSpellCastMessage(uint spellLevelId)
        {
            this.spellLevelId = spellLevelId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)spellLevelId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            spellLevelId = reader.ReadVarUhInt();
        }
        
    }
    
}