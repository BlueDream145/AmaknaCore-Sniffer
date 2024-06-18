

// Generated on 04/03/2020 21:58:48
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameActionFightDispellEffectMessage : GameActionFightDispellMessage
    {
        public const uint Id = 6113;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int boostUID;
        
        public GameActionFightDispellEffectMessage()
        {
        }
        
        public GameActionFightDispellEffectMessage(uint actionId, double sourceId, double targetId, bool verboseCast, int boostUID)
         : base(actionId, sourceId, targetId, verboseCast)
        {
            this.boostUID = boostUID;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(boostUID);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            boostUID = reader.ReadInt();
        }
        
    }
    
}