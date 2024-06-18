

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class NpcGenericActionRequestMessage : NetworkMessage
    {
        public const uint Id = 5898;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int npcId;
        public sbyte npcActionId;
        public double npcMapId;
        
        public NpcGenericActionRequestMessage()
        {
        }
        
        public NpcGenericActionRequestMessage(int npcId, sbyte npcActionId, double npcMapId)
        {
            this.npcId = npcId;
            this.npcActionId = npcActionId;
            this.npcMapId = npcMapId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(npcId);
            writer.WriteSbyte(npcActionId);
            writer.WriteDouble(npcMapId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            npcId = reader.ReadInt();
            npcActionId = reader.ReadSbyte();
            npcMapId = reader.ReadDouble();
        }
        
    }
    
}