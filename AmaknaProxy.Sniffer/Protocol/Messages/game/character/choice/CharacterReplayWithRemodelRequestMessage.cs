

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class CharacterReplayWithRemodelRequestMessage : CharacterReplayRequestMessage
    {
        public const uint Id = 6551;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.RemodelingInformation remodel;
        
        public CharacterReplayWithRemodelRequestMessage()
        {
        }
        
        public CharacterReplayWithRemodelRequestMessage(double characterId, Types.RemodelingInformation remodel)
         : base(characterId)
        {
            this.remodel = remodel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            remodel.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            remodel = new Types.RemodelingInformation();
            remodel.Deserialize(reader);
        }
        
    }
    
}