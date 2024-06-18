

// Generated on 04/03/2020 21:59:03
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeMountsTakenFromPaddockMessage : NetworkMessage
    {
        public const uint Id = 6554;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string name;
        public short worldX;
        public short worldY;
        public string ownername;
        
        public ExchangeMountsTakenFromPaddockMessage()
        {
        }
        
        public ExchangeMountsTakenFromPaddockMessage(string name, short worldX, short worldY, string ownername)
        {
            this.name = name;
            this.worldX = worldX;
            this.worldY = worldY;
            this.ownername = ownername;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(name);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteUTF(ownername);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            name = reader.ReadUTF();
            worldX = reader.ReadShort();
            worldY = reader.ReadShort();
            ownername = reader.ReadUTF();
        }
        
    }
    
}