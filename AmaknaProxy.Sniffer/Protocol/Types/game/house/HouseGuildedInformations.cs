

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class HouseGuildedInformations : HouseInstanceInformations
    {
        public const short Id = 512;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.GuildInformations guildInfo;
        
        public HouseGuildedInformations()
        {
        }
        
        public HouseGuildedInformations(bool secondHand, bool isLocked, bool isSaleLocked, int instanceId, string ownerName, double price, Types.GuildInformations guildInfo)
         : base(secondHand, isLocked, isSaleLocked, instanceId, ownerName, price)
        {
            this.guildInfo = guildInfo;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            guildInfo.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            guildInfo = new Types.GuildInformations();
            guildInfo.Deserialize(reader);
        }
        
    }
    
}