

// Generated on 04/03/2020 21:58:49
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class SequenceEndMessage : NetworkMessage
    {
        public const uint Id = 956;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint actionId;
        public double authorId;
        public sbyte sequenceType;
        
        public SequenceEndMessage()
        {
        }
        
        public SequenceEndMessage(uint actionId, double authorId, sbyte sequenceType)
        {
            this.actionId = actionId;
            this.authorId = authorId;
            this.sequenceType = sequenceType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)actionId);
            writer.WriteDouble(authorId);
            writer.WriteSbyte(sequenceType);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            actionId = reader.ReadVarUhShort();
            authorId = reader.ReadDouble();
            sequenceType = reader.ReadSbyte();
        }
        
    }
    
}