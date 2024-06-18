

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameMapMovementMessage : NetworkMessage
    {
        public const uint Id = 951;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short[] keyMovements;
        public short forcedDirection;
        public double actorId;
        
        public GameMapMovementMessage()
        {
        }
        
        public GameMapMovementMessage(short[] keyMovements, short forcedDirection, double actorId)
        {
            this.keyMovements = keyMovements;
            this.forcedDirection = forcedDirection;
            this.actorId = actorId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)keyMovements.Length);
            foreach (var entry in keyMovements)
            {
                 writer.WriteShort(entry);
            }
            writer.WriteShort(forcedDirection);
            writer.WriteDouble(actorId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            keyMovements = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 keyMovements[i] = reader.ReadShort();
            }
            forcedDirection = reader.ReadShort();
            actorId = reader.ReadDouble();
        }
        
    }
    
}