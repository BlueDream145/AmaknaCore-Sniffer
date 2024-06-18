

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareInformationsMessage : NetworkMessage
    {
        public const uint Id = 6656;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.DareInformations dareFixedInfos;
        public Types.DareVersatileInformations dareVersatilesInfos;
        
        public DareInformationsMessage()
        {
        }
        
        public DareInformationsMessage(Types.DareInformations dareFixedInfos, Types.DareVersatileInformations dareVersatilesInfos)
        {
            this.dareFixedInfos = dareFixedInfos;
            this.dareVersatilesInfos = dareVersatilesInfos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            dareFixedInfos.Serialize(writer);
            dareVersatilesInfos.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            dareFixedInfos = new Types.DareInformations();
            dareFixedInfos.Deserialize(reader);
            dareVersatilesInfos = new Types.DareVersatileInformations();
            dareVersatilesInfos.Deserialize(reader);
        }
        
    }
    
}