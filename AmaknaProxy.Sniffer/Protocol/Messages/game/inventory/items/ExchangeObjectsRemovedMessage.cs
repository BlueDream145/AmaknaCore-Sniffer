

// Generated on 04/03/2020 21:59:05
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ExchangeObjectsRemovedMessage : ExchangeObjectMessage
    {
        public const uint Id = 6532;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint[] objectUID;
        
        public ExchangeObjectsRemovedMessage()
        {
        }
        
        public ExchangeObjectsRemovedMessage(bool remote, uint[] objectUID)
         : base(remote)
        {
            this.objectUID = objectUID;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)objectUID.Length);
            foreach (var entry in objectUID)
            {
                 writer.WriteVarInt((int)entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort)reader.ReadUShort();
            objectUID = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectUID[i] = reader.ReadVarUhInt();
            }
        }
        
    }
    
}