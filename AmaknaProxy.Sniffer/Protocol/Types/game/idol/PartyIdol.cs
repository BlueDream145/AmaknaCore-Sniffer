

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class PartyIdol : Idol
    {
        public const short Id = 490;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public double[] ownersIds;
        
        public PartyIdol()
        {
        }
        
        public PartyIdol(uint id, uint xpBonusPercent, uint dropBonusPercent, double[] ownersIds)
         : base(id, xpBonusPercent, dropBonusPercent)
        {
            this.ownersIds = ownersIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)ownersIds.Length);
            foreach (var entry in ownersIds)
            {
                 writer.WriteVarLong(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            ownersIds = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 ownersIds[i] = reader.ReadVarUhLong();
            }
        }
        
    }
    
}