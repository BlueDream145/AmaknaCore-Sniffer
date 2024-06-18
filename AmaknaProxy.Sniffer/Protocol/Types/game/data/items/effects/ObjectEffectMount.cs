

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ObjectEffectMount : ObjectEffect
    {
        public const short Id = 179;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public bool sex;
        public bool isRideable;
        public bool isFeconded;
        public bool isFecondationReady;
        public double id;
        public double expirationDate;
        public uint model;
        public string name;
        public string owner;
        public sbyte level;
        public int reproductionCount;
        public uint reproductionCountMax;
        public Types.ObjectEffectInteger[] effects;
        public uint[] capacities;
        
        public ObjectEffectMount()
        {
        }
        
        public ObjectEffectMount(uint actionId, bool sex, bool isRideable, bool isFeconded, bool isFecondationReady, double id, double expirationDate, uint model, string name, string owner, sbyte level, int reproductionCount, uint reproductionCountMax, Types.ObjectEffectInteger[] effects, uint[] capacities)
         : base(actionId)
        {
            this.sex = sex;
            this.isRideable = isRideable;
            this.isFeconded = isFeconded;
            this.isFecondationReady = isFecondationReady;
            this.id = id;
            this.expirationDate = expirationDate;
            this.model = model;
            this.name = name;
            this.owner = owner;
            this.level = level;
            this.reproductionCount = reproductionCount;
            this.reproductionCountMax = reproductionCountMax;
            this.effects = effects;
            this.capacities = capacities;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, sex);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isRideable);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, isFeconded);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, isFecondationReady);
            writer.WriteByte(flag1);
            writer.WriteVarLong(id);
            writer.WriteVarLong(expirationDate);
            writer.WriteVarInt((int)model);
            writer.WriteUTF(name);
            writer.WriteUTF(owner);
            writer.WriteSbyte(level);
            writer.WriteVarInt((int)reproductionCount);
            writer.WriteVarInt((int)reproductionCountMax);
            writer.WriteShort((short)effects.Length);
            foreach (var entry in effects)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)capacities.Length);
            foreach (var entry in capacities)
            {
                 writer.WriteVarInt((int)entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            sex = BooleanByteWrapper.GetFlag(flag1, 0);
            isRideable = BooleanByteWrapper.GetFlag(flag1, 1);
            isFeconded = BooleanByteWrapper.GetFlag(flag1, 2);
            isFecondationReady = BooleanByteWrapper.GetFlag(flag1, 3);
            id = reader.ReadVarUhLong();
            expirationDate = reader.ReadVarUhLong();
            model = reader.ReadVarUhInt();
            name = reader.ReadUTF();
            owner = reader.ReadUTF();
            level = reader.ReadSbyte();
            reproductionCount = reader.ReadVarInt();
            reproductionCountMax = reader.ReadVarUhInt();
            var limit = (ushort)reader.ReadUShort();
            effects = new Types.ObjectEffectInteger[limit];
            for (int i = 0; i < limit; i++)
            {
                 effects[i] = new Types.ObjectEffectInteger();
                 effects[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            capacities = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 capacities[i] = reader.ReadVarUhInt();
            }
        }
        
    }
    
}