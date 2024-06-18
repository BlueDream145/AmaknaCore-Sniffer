

// Generated on 04/03/2020 21:59:06
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class UpdateMapPlayersAgressableStatusMessage : NetworkMessage
    {
        public const uint Id = 6454;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double[] playerIds;
        public sbyte[] enable;
        
        public UpdateMapPlayersAgressableStatusMessage()
        {
        }
        
        public UpdateMapPlayersAgressableStatusMessage(double[] playerIds, sbyte[] enable)
        {
            this.playerIds = playerIds;
            this.enable = enable;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)playerIds.Length);
            foreach (var entry in playerIds)
            {
                 writer.WriteVarLong(entry);
            }
            writer.WriteVarInt((int)(ushort)enable.Length);
            foreach (var entry in enable)
            {
                 writer.WriteSbyte(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            playerIds = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 playerIds[i] = reader.ReadVarUhLong();
            }
            limit = (ushort)reader.ReadVarInt();
            enable = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 enable[i] = reader.ReadSbyte();
            }
        }
        
    }
    
}