

// Generated on 04/03/2020 21:58:53
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameFightStartMessage : NetworkMessage
    {
        public const uint Id = 712;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.Idol[] idols;
        
        public GameFightStartMessage()
        {
        }
        
        public GameFightStartMessage(Types.Idol[] idols)
        {
            this.idols = idols;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)idols.Length);
            foreach (var entry in idols)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            idols = new Types.Idol[limit];
            for (int i = 0; i < limit; i++)
            {
                 idols[i] = new Types.Idol();
                 idols[i].Deserialize(reader);
            }
        }
        
    }
    
}