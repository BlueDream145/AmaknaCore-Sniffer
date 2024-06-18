

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AllianceTaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionExtendedMessage
    {
        public const uint Id = 6445;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.BasicNamedAllianceInformations alliance;
        
        public AllianceTaxCollectorDialogQuestionExtendedMessage()
        {
        }
        
        public AllianceTaxCollectorDialogQuestionExtendedMessage(Types.BasicGuildInformations guildInfo, uint maxPods, uint prospecting, uint wisdom, sbyte taxCollectorsCount, int taxCollectorAttack, double kamas, double experience, uint pods, double itemsValue, Types.BasicNamedAllianceInformations alliance)
         : base(guildInfo, maxPods, prospecting, wisdom, taxCollectorsCount, taxCollectorAttack, kamas, experience, pods, itemsValue)
        {
            this.alliance = alliance;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            alliance.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            alliance = new Types.BasicNamedAllianceInformations();
            alliance.Deserialize(reader);
        }
        
    }
    
}