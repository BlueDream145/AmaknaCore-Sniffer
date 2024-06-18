

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameDataPlayFarmObjectAnimationMessage : NetworkMessage
    {
        public const uint Id = 6026;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint[] cellId;
        
        public GameDataPlayFarmObjectAnimationMessage()
        {
        }
        
        public GameDataPlayFarmObjectAnimationMessage(uint[] cellId)
        {
            this.cellId = cellId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)cellId.Length);
            foreach (var entry in cellId)
            {
                 writer.WriteVarShort((int)entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            cellId = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 cellId[i] = reader.ReadVarUhShort();
            }
        }
        
    }
    
}