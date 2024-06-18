

// Generated on 04/03/2020 21:58:47
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BasicStatWithDataMessage : BasicStatMessage
    {
        public const uint Id = 6573;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.StatisticData[] datas;
        
        public BasicStatWithDataMessage()
        {
        }
        
        public BasicStatWithDataMessage(double timeSpent, uint statId, Types.StatisticData[] datas)
         : base(timeSpent, statId)
        {
            this.datas = datas;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)datas.Length);
            foreach (var entry in datas)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            datas = new Types.StatisticData[limit];
            for (int i = 0; i < limit; i++)
            {
                 datas[i] = ProtocolTypeManager.GetInstance<Types.StatisticData>(reader.ReadUShort());
                 datas[i].Deserialize(reader);
            }
        }
        
    }
    
}