

// Generated on 04/03/2020 21:59:07
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class StartupActionsListMessage : NetworkMessage
    {
        public const uint Id = 1301;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.StartupActionAddObject[] actions;
        
        public StartupActionsListMessage()
        {
        }
        
        public StartupActionsListMessage(Types.StartupActionAddObject[] actions)
        {
            this.actions = actions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)actions.Length);
            foreach (var entry in actions)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            actions = new Types.StartupActionAddObject[limit];
            for (int i = 0; i < limit; i++)
            {
                 actions[i] = new Types.StartupActionAddObject();
                 actions[i].Deserialize(reader);
            }
        }
        
    }
    
}