

// Generated on 04/03/2020 21:58:47
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
    {
        public const uint Id = 6118;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool silentCast;
        public bool verboseCast;
        public double targetId;
        public short destinationCellId;
        public sbyte critical;
        
        public AbstractGameActionFightTargetedAbilityMessage()
        {
        }
        
        public AbstractGameActionFightTargetedAbilityMessage(uint actionId, double sourceId, bool silentCast, bool verboseCast, double targetId, short destinationCellId, sbyte critical)
         : base(actionId, sourceId)
        {
            this.silentCast = silentCast;
            this.verboseCast = verboseCast;
            this.targetId = targetId;
            this.destinationCellId = destinationCellId;
            this.critical = critical;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, silentCast);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, verboseCast);
            writer.WriteByte(flag1);
            writer.WriteDouble(targetId);
            writer.WriteShort(destinationCellId);
            writer.WriteSbyte(critical);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            silentCast = BooleanByteWrapper.GetFlag(flag1, 0);
            verboseCast = BooleanByteWrapper.GetFlag(flag1, 1);
            targetId = reader.ReadDouble();
            destinationCellId = reader.ReadShort();
            critical = reader.ReadSbyte();
        }
        
    }
    
}