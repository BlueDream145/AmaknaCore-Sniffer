

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ObjectItemToSellInBid : ObjectItemToSell
    {
        public const short Id = 164;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public int unsoldDelay;
        
        public ObjectItemToSellInBid()
        {
        }
        
        public ObjectItemToSellInBid(uint objectGID, Types.ObjectEffect[] effects, uint objectUID, uint quantity, double objectPrice, int unsoldDelay)
         : base(objectGID, effects, objectUID, quantity, objectPrice)
        {
            this.unsoldDelay = unsoldDelay;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(unsoldDelay);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            unsoldDelay = reader.ReadInt();
        }
        
    }
    
}