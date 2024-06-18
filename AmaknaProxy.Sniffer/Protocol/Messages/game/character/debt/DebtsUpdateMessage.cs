

// Generated on 04/03/2020 21:58:51
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class DebtsUpdateMessage : NetworkMessage
    {
        public const uint Id = 6865;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte action;
        public Types.DebtInformation[] debts;
        
        public DebtsUpdateMessage()
        {
        }
        
        public DebtsUpdateMessage(sbyte action, Types.DebtInformation[] debts)
        {
            this.action = action;
            this.debts = debts;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(action);
            writer.WriteShort((short)debts.Length);
            foreach (var entry in debts)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            action = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            debts = new Types.DebtInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                 debts[i] = ProtocolTypeManager.GetInstance<Types.DebtInformation>(reader.ReadUShort());
                 debts[i].Deserialize(reader);
            }
        }
        
    }
    
}