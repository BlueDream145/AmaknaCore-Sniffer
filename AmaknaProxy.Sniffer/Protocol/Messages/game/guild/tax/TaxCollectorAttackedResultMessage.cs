

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class TaxCollectorAttackedResultMessage : NetworkMessage
    {
        public const uint Id = 5635;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool deadOrAlive;
        public Types.TaxCollectorBasicInformations basicInfos;
        public Types.BasicGuildInformations guild;
        
        public TaxCollectorAttackedResultMessage()
        {
        }
        
        public TaxCollectorAttackedResultMessage(bool deadOrAlive, Types.TaxCollectorBasicInformations basicInfos, Types.BasicGuildInformations guild)
        {
            this.deadOrAlive = deadOrAlive;
            this.basicInfos = basicInfos;
            this.guild = guild;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(deadOrAlive);
            basicInfos.Serialize(writer);
            guild.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            deadOrAlive = reader.ReadBoolean();
            basicInfos = new Types.TaxCollectorBasicInformations();
            basicInfos.Deserialize(reader);
            guild = new Types.BasicGuildInformations();
            guild.Deserialize(reader);
        }
        
    }
    
}