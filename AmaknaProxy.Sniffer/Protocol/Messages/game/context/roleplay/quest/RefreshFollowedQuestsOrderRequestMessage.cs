

// Generated on 04/03/2020 21:58:59
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class RefreshFollowedQuestsOrderRequestMessage : NetworkMessage
    {
        public const uint Id = 6722;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint[] quests;
        
        public RefreshFollowedQuestsOrderRequestMessage()
        {
        }
        
        public RefreshFollowedQuestsOrderRequestMessage(uint[] quests)
        {
            this.quests = quests;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)quests.Length);
            foreach (var entry in quests)
            {
                 writer.WriteVarShort((int)entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            quests = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 quests[i] = reader.ReadVarUhShort();
            }
        }
        
    }
    
}