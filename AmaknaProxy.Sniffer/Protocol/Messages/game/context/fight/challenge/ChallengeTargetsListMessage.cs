

// Generated on 04/03/2020 21:58:53
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ChallengeTargetsListMessage : NetworkMessage
    {
        public const uint Id = 5613;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double[] targetIds;
        public short[] targetCells;
        
        public ChallengeTargetsListMessage()
        {
        }
        
        public ChallengeTargetsListMessage(double[] targetIds, short[] targetCells)
        {
            this.targetIds = targetIds;
            this.targetCells = targetCells;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)targetIds.Length);
            foreach (var entry in targetIds)
            {
                 writer.WriteDouble(entry);
            }
            writer.WriteShort((short)targetCells.Length);
            foreach (var entry in targetCells)
            {
                 writer.WriteShort(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            targetIds = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 targetIds[i] = reader.ReadDouble();
            }
            limit = (ushort)reader.ReadUShort();
            targetCells = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 targetCells[i] = reader.ReadShort();
            }
        }
        
    }
    
}