

// Generated on 04/03/2020 21:59:02
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class IdolFightPreparationUpdateMessage : NetworkMessage
    {
        public const uint Id = 6586;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte idolSource;
        public Types.Idol[] idols;
        
        public IdolFightPreparationUpdateMessage()
        {
        }
        
        public IdolFightPreparationUpdateMessage(sbyte idolSource, Types.Idol[] idols)
        {
            this.idolSource = idolSource;
            this.idols = idols;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(idolSource);
            writer.WriteShort((short)idols.Length);
            foreach (var entry in idols)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            idolSource = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            idols = new Types.Idol[limit];
            for (int i = 0; i < limit; i++)
            {
                 idols[i] = ProtocolTypeManager.GetInstance<Types.Idol>(reader.ReadUShort());
                 idols[i].Deserialize(reader);
            }
        }
        
    }
    
}