

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class AcquaintanceInformation : AbstractContactInformations
    {
        public const short Id = 561;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte playerState;
        
        public AcquaintanceInformation()
        {
        }
        
        public AcquaintanceInformation(int accountId, string accountName, sbyte playerState)
         : base(accountId, accountName)
        {
            this.playerState = playerState;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSbyte(playerState);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            playerState = reader.ReadSbyte();
        }
        
    }
    
}