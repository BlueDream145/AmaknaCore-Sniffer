

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DungeonKeyRingUpdateMessage : NetworkMessage
    {
        public const uint Id = 6296;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint dungeonId;
        public bool available;
        
        public DungeonKeyRingUpdateMessage()
        {
        }
        
        public DungeonKeyRingUpdateMessage(uint dungeonId, bool available)
        {
            this.dungeonId = dungeonId;
            this.available = available;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)dungeonId);
            writer.WriteBoolean(available);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            dungeonId = reader.ReadVarUhShort();
            available = reader.ReadBoolean();
        }
        
    }
    
}