

// Generated on 04/03/2020 21:58:51
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ForgettableSpellDeleteMessage : NetworkMessage
    {
        public const uint Id = 6867;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte reason;
        public int[] spells;
        
        public ForgettableSpellDeleteMessage()
        {
        }
        
        public ForgettableSpellDeleteMessage(sbyte reason, int[] spells)
        {
            this.reason = reason;
            this.spells = spells;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(reason);
            writer.WriteShort((short)spells.Length);
            foreach (var entry in spells)
            {
                 writer.WriteInt(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            reason = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            spells = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 spells[i] = reader.ReadInt();
            }
        }
        
    }
    
}