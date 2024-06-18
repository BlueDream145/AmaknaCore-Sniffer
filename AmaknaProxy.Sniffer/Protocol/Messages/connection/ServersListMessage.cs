

// Generated on 04/03/2020 21:58:47
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ServersListMessage : NetworkMessage
    {
        public const uint Id = 30;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GameServerInformations[] servers;
        public uint alreadyConnectedToServerId;
        public bool canCreateNewCharacter;
        
        public ServersListMessage()
        {
        }
        
        public ServersListMessage(Types.GameServerInformations[] servers, uint alreadyConnectedToServerId, bool canCreateNewCharacter)
        {
            this.servers = servers;
            this.alreadyConnectedToServerId = alreadyConnectedToServerId;
            this.canCreateNewCharacter = canCreateNewCharacter;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)servers.Length);
            foreach (var entry in servers)
            {
                 entry.Serialize(writer);
            }
            writer.WriteVarShort((int)alreadyConnectedToServerId);
            writer.WriteBoolean(canCreateNewCharacter);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            servers = new Types.GameServerInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 servers[i] = new Types.GameServerInformations();
                 servers[i].Deserialize(reader);
            }
            alreadyConnectedToServerId = reader.ReadVarUhShort();
            canCreateNewCharacter = reader.ReadBoolean();
        }
        
    }
    
}