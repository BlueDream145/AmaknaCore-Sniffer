

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BasicAckMessage : NetworkMessage
    {
        public const uint Id = 6362;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint seq;
        public uint lastPacketId;
        
        public BasicAckMessage()
        {
        }
        
        public BasicAckMessage(uint seq, uint lastPacketId)
        {
            this.seq = seq;
            this.lastPacketId = lastPacketId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)seq);
            writer.WriteVarShort((int)lastPacketId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            seq = reader.ReadVarUhInt();
            lastPacketId = reader.ReadVarUhShort();
        }
        
    }
    
}