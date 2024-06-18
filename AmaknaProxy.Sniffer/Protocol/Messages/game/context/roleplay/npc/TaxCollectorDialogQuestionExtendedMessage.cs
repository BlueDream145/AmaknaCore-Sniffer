

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage
    {
        public const uint Id = 5615;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public uint maxPods;
        public uint prospecting;
        public uint wisdom;
        public sbyte taxCollectorsCount;
        public int taxCollectorAttack;
        public double kamas;
        public double experience;
        public uint pods;
        public double itemsValue;
        
        public TaxCollectorDialogQuestionExtendedMessage()
        {
        }
        
        public TaxCollectorDialogQuestionExtendedMessage(Types.BasicGuildInformations guildInfo, uint maxPods, uint prospecting, uint wisdom, sbyte taxCollectorsCount, int taxCollectorAttack, double kamas, double experience, uint pods, double itemsValue)
         : base(guildInfo)
        {
            this.maxPods = maxPods;
            this.prospecting = prospecting;
            this.wisdom = wisdom;
            this.taxCollectorsCount = taxCollectorsCount;
            this.taxCollectorAttack = taxCollectorAttack;
            this.kamas = kamas;
            this.experience = experience;
            this.pods = pods;
            this.itemsValue = itemsValue;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((int)maxPods);
            writer.WriteVarShort((int)prospecting);
            writer.WriteVarShort((int)wisdom);
            writer.WriteSbyte(taxCollectorsCount);
            writer.WriteInt(taxCollectorAttack);
            writer.WriteVarLong(kamas);
            writer.WriteVarLong(experience);
            writer.WriteVarInt((int)pods);
            writer.WriteVarLong(itemsValue);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            maxPods = reader.ReadVarUhShort();
            prospecting = reader.ReadVarUhShort();
            wisdom = reader.ReadVarUhShort();
            taxCollectorsCount = reader.ReadSbyte();
            taxCollectorAttack = reader.ReadInt();
            kamas = reader.ReadVarUhLong();
            experience = reader.ReadVarUhLong();
            pods = reader.ReadVarUhInt();
            itemsValue = reader.ReadVarUhLong();
        }
        
    }
    
}