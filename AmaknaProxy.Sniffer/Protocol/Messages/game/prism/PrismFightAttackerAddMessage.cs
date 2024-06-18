

// Generated on 04/03/2020 21:59:06
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PrismFightAttackerAddMessage : NetworkMessage
    {
        public const uint Id = 5893;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint subAreaId;
        public uint fightId;
        public Types.CharacterMinimalPlusLookInformations attacker;
        
        public PrismFightAttackerAddMessage()
        {
        }
        
        public PrismFightAttackerAddMessage(uint subAreaId, uint fightId, Types.CharacterMinimalPlusLookInformations attacker)
        {
            this.subAreaId = subAreaId;
            this.fightId = fightId;
            this.attacker = attacker;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)subAreaId);
            writer.WriteVarShort((int)fightId);
            writer.WriteShort(attacker.TypeId);
            attacker.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            subAreaId = reader.ReadVarUhShort();
            fightId = reader.ReadVarUhShort();
            attacker = ProtocolTypeManager.GetInstance<Types.CharacterMinimalPlusLookInformations>(reader.ReadUShort());
            attacker.Deserialize(reader);
        }
        
    }
    
}