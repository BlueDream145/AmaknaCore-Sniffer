

// Generated on 04/03/2020 21:59:08
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GameServerInformations
    {
        public const short Id = 25;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public bool isMonoAccount;
        public bool isSelectable;
        public uint id;
        public sbyte type;
        public sbyte status;
        public sbyte completion;
        public sbyte charactersCount;
        public sbyte charactersSlots;
        public double date;
        
        public GameServerInformations()
        {
        }
        
        public GameServerInformations(bool isMonoAccount, bool isSelectable, uint id, sbyte type, sbyte status, sbyte completion, sbyte charactersCount, sbyte charactersSlots, double date)
        {
            this.isMonoAccount = isMonoAccount;
            this.isSelectable = isSelectable;
            this.id = id;
            this.type = type;
            this.status = status;
            this.completion = completion;
            this.charactersCount = charactersCount;
            this.charactersSlots = charactersSlots;
            this.date = date;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isMonoAccount);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isSelectable);
            writer.WriteByte(flag1);
            writer.WriteVarShort((int)id);
            writer.WriteSbyte(type);
            writer.WriteSbyte(status);
            writer.WriteSbyte(completion);
            writer.WriteSbyte(charactersCount);
            writer.WriteSbyte(charactersSlots);
            writer.WriteDouble(date);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            isMonoAccount = BooleanByteWrapper.GetFlag(flag1, 0);
            isSelectable = BooleanByteWrapper.GetFlag(flag1, 1);
            id = reader.ReadVarUhShort();
            type = reader.ReadSbyte();
            status = reader.ReadSbyte();
            completion = reader.ReadSbyte();
            charactersCount = reader.ReadSbyte();
            charactersSlots = reader.ReadSbyte();
            date = reader.ReadDouble();
        }
        
    }
    
}