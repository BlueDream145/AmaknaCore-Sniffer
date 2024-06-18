

// Generated on 04/03/2020 21:59:05
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ObjectDeleteMessage : NetworkMessage
    {
        public const uint Id = 3022;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint objectUID;
        public uint quantity;
        
        public ObjectDeleteMessage()
        {
        }
        
        public ObjectDeleteMessage(uint objectUID, uint quantity)
        {
            this.objectUID = objectUID;
            this.quantity = quantity;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)objectUID);
            writer.WriteVarInt((int)quantity);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            objectUID = reader.ReadVarUhInt();
            quantity = reader.ReadVarUhInt();
        }
        
    }
    
}