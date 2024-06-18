

// Generated on 04/03/2020 21:58:53
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameFightSynchronizeMessage : NetworkMessage
    {
        public const uint Id = 5921;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GameFightFighterInformations[] fighters;
        
        public GameFightSynchronizeMessage()
        {
        }
        
        public GameFightSynchronizeMessage(Types.GameFightFighterInformations[] fighters)
        {
            this.fighters = fighters;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)fighters.Length);
            foreach (var entry in fighters)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            fighters = new Types.GameFightFighterInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fighters[i] = ProtocolTypeManager.GetInstance<Types.GameFightFighterInformations>(reader.ReadUShort());
                 fighters[i].Deserialize(reader);
            }
        }
        
    }
    
}