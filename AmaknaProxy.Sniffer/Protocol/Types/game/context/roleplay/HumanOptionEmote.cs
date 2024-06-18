

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class HumanOptionEmote : HumanOption
    {
        public const short Id = 407;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public byte emoteId;
        public double emoteStartTime;
        
        public HumanOptionEmote()
        {
        }
        
        public HumanOptionEmote(byte emoteId, double emoteStartTime)
        {
            this.emoteId = emoteId;
            this.emoteStartTime = emoteStartTime;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(emoteId);
            writer.WriteDouble(emoteStartTime);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            emoteId = reader.ReadByte();
            emoteStartTime = reader.ReadDouble();
        }
        
    }
    
}