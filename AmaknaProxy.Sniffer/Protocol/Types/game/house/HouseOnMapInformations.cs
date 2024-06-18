

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class HouseOnMapInformations : HouseInformations
    {
        public const short Id = 510;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public int[] doorsOnMap;
        public Types.HouseInstanceInformations[] houseInstances;
        
        public HouseOnMapInformations()
        {
        }
        
        public HouseOnMapInformations(uint houseId, uint modelId, int[] doorsOnMap, Types.HouseInstanceInformations[] houseInstances)
         : base(houseId, modelId)
        {
            this.doorsOnMap = doorsOnMap;
            this.houseInstances = houseInstances;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)doorsOnMap.Length);
            foreach (var entry in doorsOnMap)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteShort((short)houseInstances.Length);
            foreach (var entry in houseInstances)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            doorsOnMap = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 doorsOnMap[i] = reader.ReadInt();
            }
            limit = (ushort)reader.ReadUShort();
            houseInstances = new Types.HouseInstanceInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 houseInstances[i] = new Types.HouseInstanceInformations();
                 houseInstances[i].Deserialize(reader);
            }
        }
        
    }
    
}