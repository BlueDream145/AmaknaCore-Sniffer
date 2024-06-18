

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class HumanOptionObjectUse : HumanOption
    {
        public const short Id = 449;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte delayTypeId;
        public double delayEndTime;
        public uint objectGID;
        
        public HumanOptionObjectUse()
        {
        }
        
        public HumanOptionObjectUse(sbyte delayTypeId, double delayEndTime, uint objectGID)
        {
            this.delayTypeId = delayTypeId;
            this.delayEndTime = delayEndTime;
            this.objectGID = objectGID;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSbyte(delayTypeId);
            writer.WriteDouble(delayEndTime);
            writer.WriteVarShort((int)objectGID);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            delayTypeId = reader.ReadSbyte();
            delayEndTime = reader.ReadDouble();
            objectGID = reader.ReadVarUhShort();
        }
        
    }
    
}