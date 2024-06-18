

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class DareReward
    {
        public const short Id = 505;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte type;
        public uint monsterId;
        public double kamas;
        public double dareId;
        
        public DareReward()
        {
        }
        
        public DareReward(sbyte type, uint monsterId, double kamas, double dareId)
        {
            this.type = type;
            this.monsterId = monsterId;
            this.kamas = kamas;
            this.dareId = dareId;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(type);
            writer.WriteVarShort((int)monsterId);
            writer.WriteVarLong(kamas);
            writer.WriteDouble(dareId);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            type = reader.ReadSbyte();
            monsterId = reader.ReadVarUhShort();
            kamas = reader.ReadVarUhLong();
            dareId = reader.ReadDouble();
        }
        
    }
    
}