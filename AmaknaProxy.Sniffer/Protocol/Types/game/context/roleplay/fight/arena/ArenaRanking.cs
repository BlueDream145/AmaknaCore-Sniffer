

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ArenaRanking
    {
        public const short Id = 554;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint rank;
        public uint bestRank;
        
        public ArenaRanking()
        {
        }
        
        public ArenaRanking(uint rank, uint bestRank)
        {
            this.rank = rank;
            this.bestRank = bestRank;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)rank);
            writer.WriteVarShort((int)bestRank);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            rank = reader.ReadVarUhShort();
            bestRank = reader.ReadVarUhShort();
        }
        
    }
    
}