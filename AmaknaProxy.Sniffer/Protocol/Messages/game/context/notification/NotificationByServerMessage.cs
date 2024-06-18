

// Generated on 04/03/2020 21:58:53
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class NotificationByServerMessage : NetworkMessage
    {
        public const uint Id = 6103;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint id;
        public string[] parameters;
        public bool forceOpen;
        
        public NotificationByServerMessage()
        {
        }
        
        public NotificationByServerMessage(uint id, string[] parameters, bool forceOpen)
        {
            this.id = id;
            this.parameters = parameters;
            this.forceOpen = forceOpen;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)id);
            writer.WriteShort((short)parameters.Length);
            foreach (var entry in parameters)
            {
                 writer.WriteUTF(entry);
            }
            writer.WriteBoolean(forceOpen);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadVarUhShort();
            var limit = (ushort)reader.ReadUShort();
            parameters = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 parameters[i] = reader.ReadUTF();
            }
            forceOpen = reader.ReadBoolean();
        }
        
    }
    
}