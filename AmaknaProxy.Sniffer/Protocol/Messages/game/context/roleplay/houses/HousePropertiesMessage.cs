

// Generated on 04/03/2020 21:58:56
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class HousePropertiesMessage : NetworkMessage
    {
        public const uint Id = 5734;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint houseId;
        public int[] doorsOnMap;
        public Types.HouseInstanceInformations properties;
        
        public HousePropertiesMessage()
        {
        }
        
        public HousePropertiesMessage(uint houseId, int[] doorsOnMap, Types.HouseInstanceInformations properties)
        {
            this.houseId = houseId;
            this.doorsOnMap = doorsOnMap;
            this.properties = properties;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)houseId);
            writer.WriteShort((short)doorsOnMap.Length);
            foreach (var entry in doorsOnMap)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteShort(properties.TypeId);
            properties.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadVarUhInt();
            var limit = (ushort)reader.ReadUShort();
            doorsOnMap = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 doorsOnMap[i] = reader.ReadInt();
            }
            properties = ProtocolTypeManager.GetInstance<Types.HouseInstanceInformations>(reader.ReadUShort());
            properties.Deserialize(reader);
        }
        
    }
    
}