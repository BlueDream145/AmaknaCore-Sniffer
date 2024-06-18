

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class BreachBranchesMessage : NetworkMessage
    {
        public const uint Id = 6812;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.ExtendedBreachBranch[] branches;
        
        public BreachBranchesMessage()
        {
        }
        
        public BreachBranchesMessage(Types.ExtendedBreachBranch[] branches)
        {
            this.branches = branches;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)branches.Length);
            foreach (var entry in branches)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            branches = new Types.ExtendedBreachBranch[limit];
            for (int i = 0; i < limit; i++)
            {
                 branches[i] = ProtocolTypeManager.GetInstance<Types.ExtendedBreachBranch>(reader.ReadUShort());
                 branches[i].Deserialize(reader);
            }
        }
        
    }
    
}