

// Generated on 04/03/2020 21:59:07
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class CheckIntegrityMessage : NetworkMessage
    {
        public const uint Id = 6372;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte[] data;
        
        public CheckIntegrityMessage()
        {
        }
        
        public CheckIntegrityMessage(sbyte[] data)
        {
            this.data = data;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)(ushort)data.Length);
            foreach (var entry in data)
            {
                 writer.WriteSbyte(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadVarInt();
            data = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 data[i] = reader.ReadSbyte();
            }
        }
        
    }
    
}