

// Generated on 04/03/2020 21:58:47
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AchievementDetailedListRequestMessage : NetworkMessage
    {
        public const uint Id = 6357;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint categoryId;
        
        public AchievementDetailedListRequestMessage()
        {
        }
        
        public AchievementDetailedListRequestMessage(uint categoryId)
        {
            this.categoryId = categoryId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)categoryId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            categoryId = reader.ReadVarUhShort();
        }
        
    }
    
}