

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildInfosUpgradeMessage : NetworkMessage
    {
        public const uint Id = 5636;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte maxTaxCollectorsCount;
        public sbyte taxCollectorsCount;
        public uint taxCollectorLifePoints;
        public uint taxCollectorDamagesBonuses;
        public uint taxCollectorPods;
        public uint taxCollectorProspecting;
        public uint taxCollectorWisdom;
        public uint boostPoints;
        public uint[] spellId;
        public short[] spellLevel;
        
        public GuildInfosUpgradeMessage()
        {
        }
        
        public GuildInfosUpgradeMessage(sbyte maxTaxCollectorsCount, sbyte taxCollectorsCount, uint taxCollectorLifePoints, uint taxCollectorDamagesBonuses, uint taxCollectorPods, uint taxCollectorProspecting, uint taxCollectorWisdom, uint boostPoints, uint[] spellId, short[] spellLevel)
        {
            this.maxTaxCollectorsCount = maxTaxCollectorsCount;
            this.taxCollectorsCount = taxCollectorsCount;
            this.taxCollectorLifePoints = taxCollectorLifePoints;
            this.taxCollectorDamagesBonuses = taxCollectorDamagesBonuses;
            this.taxCollectorPods = taxCollectorPods;
            this.taxCollectorProspecting = taxCollectorProspecting;
            this.taxCollectorWisdom = taxCollectorWisdom;
            this.boostPoints = boostPoints;
            this.spellId = spellId;
            this.spellLevel = spellLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(maxTaxCollectorsCount);
            writer.WriteSbyte(taxCollectorsCount);
            writer.WriteVarShort((int)taxCollectorLifePoints);
            writer.WriteVarShort((int)taxCollectorDamagesBonuses);
            writer.WriteVarShort((int)taxCollectorPods);
            writer.WriteVarShort((int)taxCollectorProspecting);
            writer.WriteVarShort((int)taxCollectorWisdom);
            writer.WriteVarShort((int)boostPoints);
            writer.WriteShort((short)spellId.Length);
            foreach (var entry in spellId)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteShort((short)spellLevel.Length);
            foreach (var entry in spellLevel)
            {
                 writer.WriteShort(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            maxTaxCollectorsCount = reader.ReadSbyte();
            taxCollectorsCount = reader.ReadSbyte();
            taxCollectorLifePoints = reader.ReadVarUhShort();
            taxCollectorDamagesBonuses = reader.ReadVarUhShort();
            taxCollectorPods = reader.ReadVarUhShort();
            taxCollectorProspecting = reader.ReadVarUhShort();
            taxCollectorWisdom = reader.ReadVarUhShort();
            boostPoints = reader.ReadVarUhShort();
            var limit = (ushort)reader.ReadUShort();
            spellId = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 spellId[i] = reader.ReadVarUhShort();
            }
            limit = (ushort)reader.ReadUShort();
            spellLevel = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 spellLevel[i] = reader.ReadShort();
            }
        }
        
    }
    
}