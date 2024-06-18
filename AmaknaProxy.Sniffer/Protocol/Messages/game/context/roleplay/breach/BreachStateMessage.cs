

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachStateMessage : NetworkMessage
    {
        public const uint Id = 6799;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.CharacterMinimalInformations owner;
        public Types.ObjectEffectInteger[] bonuses;
        public uint bugdet;
        public bool saved;
        
        public BreachStateMessage()
        {
        }
        
        public BreachStateMessage(Types.CharacterMinimalInformations owner, Types.ObjectEffectInteger[] bonuses, uint bugdet, bool saved)
        {
            this.owner = owner;
            this.bonuses = bonuses;
            this.bugdet = bugdet;
            this.saved = saved;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            owner.Serialize(writer);
            writer.WriteShort((short)bonuses.Length);
            foreach (var entry in bonuses)
            {
                 entry.Serialize(writer);
            }
            writer.WriteVarInt((int)bugdet);
            writer.WriteBoolean(saved);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            owner = new Types.CharacterMinimalInformations();
            owner.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            bonuses = new Types.ObjectEffectInteger[limit];
            for (int i = 0; i < limit; i++)
            {
                 bonuses[i] = new Types.ObjectEffectInteger();
                 bonuses[i].Deserialize(reader);
            }
            bugdet = reader.ReadVarUhInt();
            saved = reader.ReadBoolean();
        }
        
    }
    
}