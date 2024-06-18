

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DareSubscribedMessage : NetworkMessage
    {
        public const uint Id = 6660;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool success;
        public bool subscribe;
        public double dareId;
        public Types.DareVersatileInformations dareVersatilesInfos;
        
        public DareSubscribedMessage()
        {
        }
        
        public DareSubscribedMessage(bool success, bool subscribe, double dareId, Types.DareVersatileInformations dareVersatilesInfos)
        {
            this.success = success;
            this.subscribe = subscribe;
            this.dareId = dareId;
            this.dareVersatilesInfos = dareVersatilesInfos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, success);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, subscribe);
            writer.WriteByte(flag1);
            writer.WriteDouble(dareId);
            dareVersatilesInfos.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            success = BooleanByteWrapper.GetFlag(flag1, 0);
            subscribe = BooleanByteWrapper.GetFlag(flag1, 1);
            dareId = reader.ReadDouble();
            dareVersatilesInfos = new Types.DareVersatileInformations();
            dareVersatilesInfos.Deserialize(reader);
        }
        
    }
    
}