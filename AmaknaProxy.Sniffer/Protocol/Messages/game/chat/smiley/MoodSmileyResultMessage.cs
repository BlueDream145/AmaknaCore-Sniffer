

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MoodSmileyResultMessage : NetworkMessage
    {
        public const uint Id = 6196;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte resultCode;
        public uint smileyId;
        
        public MoodSmileyResultMessage()
        {
        }
        
        public MoodSmileyResultMessage(sbyte resultCode, uint smileyId)
        {
            this.resultCode = resultCode;
            this.smileyId = smileyId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(resultCode);
            writer.WriteVarShort((int)smileyId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            resultCode = reader.ReadSbyte();
            smileyId = reader.ReadVarUhShort();
        }
        
    }
    
}