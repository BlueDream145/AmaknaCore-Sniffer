

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class TaxCollectorDialogQuestionBasicMessage : NetworkMessage
    {
        public const uint Id = 5619;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.BasicGuildInformations guildInfo;
        
        public TaxCollectorDialogQuestionBasicMessage()
        {
        }
        
        public TaxCollectorDialogQuestionBasicMessage(Types.BasicGuildInformations guildInfo)
        {
            this.guildInfo = guildInfo;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            guildInfo.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            guildInfo = new Types.BasicGuildInformations();
            guildInfo.Deserialize(reader);
        }
        
    }
    
}