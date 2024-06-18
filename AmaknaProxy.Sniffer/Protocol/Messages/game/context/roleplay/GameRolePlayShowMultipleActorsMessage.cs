

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameRolePlayShowMultipleActorsMessage : NetworkMessage
    {
        public const uint Id = 6712;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GameRolePlayActorInformations[] informationsList;
        
        public GameRolePlayShowMultipleActorsMessage()
        {
        }
        
        public GameRolePlayShowMultipleActorsMessage(Types.GameRolePlayActorInformations[] informationsList)
        {
            this.informationsList = informationsList;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)informationsList.Length);
            foreach (var entry in informationsList)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            informationsList = new Types.GameRolePlayActorInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 informationsList[i] = ProtocolTypeManager.GetInstance<Types.GameRolePlayActorInformations>(reader.ReadUShort());
                 informationsList[i].Deserialize(reader);
            }
        }
        
    }
    
}