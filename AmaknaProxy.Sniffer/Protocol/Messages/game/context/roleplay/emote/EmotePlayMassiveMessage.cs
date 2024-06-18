

// Generated on 04/03/2020 21:58:55
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
    {
        public const uint Id = 5691;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double[] actorIds;
        
        public EmotePlayMassiveMessage()
        {
        }
        
        public EmotePlayMassiveMessage(byte emoteId, double emoteStartTime, double[] actorIds)
         : base(emoteId, emoteStartTime)
        {
            this.actorIds = actorIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)actorIds.Length);
            foreach (var entry in actorIds)
            {
                 writer.WriteDouble(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            actorIds = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 actorIds[i] = reader.ReadDouble();
            }
        }
        
    }
    
}