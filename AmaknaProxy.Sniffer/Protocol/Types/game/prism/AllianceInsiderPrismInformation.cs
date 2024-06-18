

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class AllianceInsiderPrismInformation : PrismInformation
    {
        public const short Id = 431;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public int lastTimeSlotModificationDate;
        public uint lastTimeSlotModificationAuthorGuildId;
        public double lastTimeSlotModificationAuthorId;
        public string lastTimeSlotModificationAuthorName;
        public Types.ObjectItem[] modulesObjects;
        
        public AllianceInsiderPrismInformation()
        {
        }
        
        public AllianceInsiderPrismInformation(sbyte typeId, sbyte state, int nextVulnerabilityDate, int placementDate, uint rewardTokenCount, int lastTimeSlotModificationDate, uint lastTimeSlotModificationAuthorGuildId, double lastTimeSlotModificationAuthorId, string lastTimeSlotModificationAuthorName, Types.ObjectItem[] modulesObjects)
         : base(typeId, state, nextVulnerabilityDate, placementDate, rewardTokenCount)
        {
            this.lastTimeSlotModificationDate = lastTimeSlotModificationDate;
            this.lastTimeSlotModificationAuthorGuildId = lastTimeSlotModificationAuthorGuildId;
            this.lastTimeSlotModificationAuthorId = lastTimeSlotModificationAuthorId;
            this.lastTimeSlotModificationAuthorName = lastTimeSlotModificationAuthorName;
            this.modulesObjects = modulesObjects;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(lastTimeSlotModificationDate);
            writer.WriteVarInt((int)lastTimeSlotModificationAuthorGuildId);
            writer.WriteVarLong(lastTimeSlotModificationAuthorId);
            writer.WriteUTF(lastTimeSlotModificationAuthorName);
            writer.WriteShort((short)modulesObjects.Length);
            foreach (var entry in modulesObjects)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            lastTimeSlotModificationDate = reader.ReadInt();
            lastTimeSlotModificationAuthorGuildId = reader.ReadVarUhInt();
            lastTimeSlotModificationAuthorId = reader.ReadVarUhLong();
            lastTimeSlotModificationAuthorName = reader.ReadUTF();
            var limit = (ushort)reader.ReadUShort();
            modulesObjects = new Types.ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 modulesObjects[i] = new Types.ObjectItem();
                 modulesObjects[i].Deserialize(reader);
            }
        }
        
    }
    
}