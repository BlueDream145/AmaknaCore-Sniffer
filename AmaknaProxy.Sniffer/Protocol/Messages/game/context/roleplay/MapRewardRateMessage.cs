

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MapRewardRateMessage : NetworkMessage
    {
        public const uint Id = 6827;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int mapRate;
        public int subAreaRate;
        public int totalRate;
        
        public MapRewardRateMessage()
        {
        }
        
        public MapRewardRateMessage(int mapRate, int subAreaRate, int totalRate)
        {
            this.mapRate = mapRate;
            this.subAreaRate = subAreaRate;
            this.totalRate = totalRate;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)mapRate);
            writer.WriteVarShort((int)subAreaRate);
            writer.WriteVarShort((int)totalRate);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            mapRate = reader.ReadVarShort();
            subAreaRate = reader.ReadVarShort();
            totalRate = reader.ReadVarShort();
        }
        
    }
    
}