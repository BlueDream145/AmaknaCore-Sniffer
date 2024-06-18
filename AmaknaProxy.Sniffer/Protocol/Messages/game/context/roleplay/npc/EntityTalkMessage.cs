

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class EntityTalkMessage : NetworkMessage
    {
        public const uint Id = 6110;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double entityId;
        public uint textId;
        public string[] parameters;
        
        public EntityTalkMessage()
        {
        }
        
        public EntityTalkMessage(double entityId, uint textId, string[] parameters)
        {
            this.entityId = entityId;
            this.textId = textId;
            this.parameters = parameters;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(entityId);
            writer.WriteVarShort((int)textId);
            writer.WriteShort((short)parameters.Length);
            foreach (var entry in parameters)
            {
                 writer.WriteUTF(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            entityId = reader.ReadDouble();
            textId = reader.ReadVarUhShort();
            var limit = (ushort)reader.ReadUShort();
            parameters = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 parameters[i] = reader.ReadUTF();
            }
        }
        
    }
    
}