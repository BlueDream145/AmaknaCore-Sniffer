

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareSubscribedListMessage : NetworkMessage
    {
        public const uint Id = 6658;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.DareInformations[] daresFixedInfos;
        public Types.DareVersatileInformations[] daresVersatilesInfos;
        
        public DareSubscribedListMessage()
        {
        }
        
        public DareSubscribedListMessage(Types.DareInformations[] daresFixedInfos, Types.DareVersatileInformations[] daresVersatilesInfos)
        {
            this.daresFixedInfos = daresFixedInfos;
            this.daresVersatilesInfos = daresVersatilesInfos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)daresFixedInfos.Length);
            foreach (var entry in daresFixedInfos)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)daresVersatilesInfos.Length);
            foreach (var entry in daresVersatilesInfos)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            daresFixedInfos = new Types.DareInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 daresFixedInfos[i] = new Types.DareInformations();
                 daresFixedInfos[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            daresVersatilesInfos = new Types.DareVersatileInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 daresVersatilesInfos[i] = new Types.DareVersatileInformations();
                 daresVersatilesInfos[i].Deserialize(reader);
            }
        }
        
    }
    
}