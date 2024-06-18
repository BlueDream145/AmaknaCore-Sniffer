

// Generated on 04/03/2020 21:59:06
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class PrismFightAttackerRemoveMessage : NetworkMessage
    {
        public const uint Id = 5897;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint subAreaId;
        public uint fightId;
        public double fighterToRemoveId;
        
        public PrismFightAttackerRemoveMessage()
        {
        }
        
        public PrismFightAttackerRemoveMessage(uint subAreaId, uint fightId, double fighterToRemoveId)
        {
            this.subAreaId = subAreaId;
            this.fightId = fightId;
            this.fighterToRemoveId = fighterToRemoveId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort((int)subAreaId);
            writer.WriteVarShort((int)fightId);
            writer.WriteVarLong(fighterToRemoveId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            subAreaId = reader.ReadVarUhShort();
            fightId = reader.ReadVarUhShort();
            fighterToRemoveId = reader.ReadVarUhLong();
        }
        
    }
    
}