

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class DareVersatileInformations
    {
        public const short Id = 504;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public double dareId;
        public int countEntrants;
        public int countWinners;
        
        public DareVersatileInformations()
        {
        }
        
        public DareVersatileInformations(double dareId, int countEntrants, int countWinners)
        {
            this.dareId = dareId;
            this.countEntrants = countEntrants;
            this.countWinners = countWinners;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(dareId);
            writer.WriteInt(countEntrants);
            writer.WriteInt(countWinners);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            dareId = reader.ReadDouble();
            countEntrants = reader.ReadInt();
            countWinners = reader.ReadInt();
        }
        
    }
    
}