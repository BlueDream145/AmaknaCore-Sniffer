

// Generated on 04/03/2020 21:58:47
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ServerSelectionMessage : NetworkMessage
    {
        public const uint Id = 40;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint serverId;
        
        public ServerSelectionMessage()
        {
        }
        
        public ServerSelectionMessage(uint serverId)
        {
            this.serverId = serverId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)serverId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            serverId = reader.ReadVarUhShort();
        }
        
    }
    
}