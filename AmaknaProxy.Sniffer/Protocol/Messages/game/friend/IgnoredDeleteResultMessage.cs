

// Generated on 04/03/2020 21:59:00
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class IgnoredDeleteResultMessage : NetworkMessage
    {
        public const uint Id = 5677;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool success;
        public bool session;
        public string name;
        
        public IgnoredDeleteResultMessage()
        {
        }
        
        public IgnoredDeleteResultMessage(bool success, bool session, string name)
        {
            this.success = success;
            this.session = session;
            this.name = name;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, success);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, session);
            writer.WriteByte(flag1);
            writer.WriteUTF(name);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            success = BooleanByteWrapper.GetFlag(flag1, 0);
            session = BooleanByteWrapper.GetFlag(flag1, 1);
            name = reader.ReadUTF();
        }
        
    }
    
}