

// Generated on 04/03/2020 21:58:53
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class SlaveSwitchContextMessage : NetworkMessage
    {
        public const uint Id = 6214;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double masterId;
        public double slaveId;
        public Types.SpellItem[] slaveSpells;
        public Types.CharacterCharacteristicsInformations slaveStats;
        public Types.Shortcut[] shortcuts;
        
        public SlaveSwitchContextMessage()
        {
        }
        
        public SlaveSwitchContextMessage(double masterId, double slaveId, Types.SpellItem[] slaveSpells, Types.CharacterCharacteristicsInformations slaveStats, Types.Shortcut[] shortcuts)
        {
            this.masterId = masterId;
            this.slaveId = slaveId;
            this.slaveSpells = slaveSpells;
            this.slaveStats = slaveStats;
            this.shortcuts = shortcuts;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(masterId);
            writer.WriteDouble(slaveId);
            writer.WriteShort((short)slaveSpells.Length);
            foreach (var entry in slaveSpells)
            {
                 entry.Serialize(writer);
            }
            slaveStats.Serialize(writer);
            writer.WriteShort((short)shortcuts.Length);
            foreach (var entry in shortcuts)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            masterId = reader.ReadDouble();
            slaveId = reader.ReadDouble();
            var limit = (ushort)reader.ReadUShort();
            slaveSpells = new Types.SpellItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 slaveSpells[i] = new Types.SpellItem();
                 slaveSpells[i].Deserialize(reader);
            }
            slaveStats = new Types.CharacterCharacteristicsInformations();
            slaveStats.Deserialize(reader);
            limit = (ushort)reader.ReadUShort();
            shortcuts = new Types.Shortcut[limit];
            for (int i = 0; i < limit; i++)
            {
                 shortcuts[i] = ProtocolTypeManager.GetInstance<Types.Shortcut>(reader.ReadUShort());
                 shortcuts[i].Deserialize(reader);
            }
        }
        
    }
    
}