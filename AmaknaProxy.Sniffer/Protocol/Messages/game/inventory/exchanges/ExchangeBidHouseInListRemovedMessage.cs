

// Generated on 04/03/2020 21:59:02
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeBidHouseInListRemovedMessage : NetworkMessage
    {
        public const uint Id = 5950;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int itemUID;
        public uint objectGID;
        public int objectType;
        
        public ExchangeBidHouseInListRemovedMessage()
        {
        }
        
        public ExchangeBidHouseInListRemovedMessage(int itemUID, uint objectGID, int objectType)
        {
            this.itemUID = itemUID;
            this.objectGID = objectGID;
            this.objectType = objectType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(itemUID);
            writer.WriteVarShort((int)objectGID);
            writer.WriteInt(objectType);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            itemUID = reader.ReadInt();
            objectGID = reader.ReadVarUhShort();
            objectType = reader.ReadInt();
        }
        
    }
    
}