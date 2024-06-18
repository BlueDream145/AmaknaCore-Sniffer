

// Generated on 04/03/2020 21:59:02
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class InteractiveUsedMessage : NetworkMessage
    {
        public const uint Id = 5745;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double entityId;
        public uint elemId;
        public uint skillId;
        public uint duration;
        public bool canMove;
        
        public InteractiveUsedMessage()
        {
        }
        
        public InteractiveUsedMessage(double entityId, uint elemId, uint skillId, uint duration, bool canMove)
        {
            this.entityId = entityId;
            this.elemId = elemId;
            this.skillId = skillId;
            this.duration = duration;
            this.canMove = canMove;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(entityId);
            writer.WriteVarInt((int)elemId);
            writer.WriteVarShort((int)skillId);
            writer.WriteVarShort((int)duration);
            writer.WriteBoolean(canMove);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            entityId = reader.ReadVarUhLong();
            elemId = reader.ReadVarUhInt();
            skillId = reader.ReadVarUhShort();
            duration = reader.ReadVarUhShort();
            canMove = reader.ReadBoolean();
        }
        
    }
    
}