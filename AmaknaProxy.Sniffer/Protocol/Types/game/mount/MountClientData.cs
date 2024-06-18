

// Generated on 04/03/2020 21:59:12
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class MountClientData
    {
        public const short Id = 178;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public bool sex;
        public bool isRideable;
        public bool isWild;
        public bool isFecondationReady;
        public bool useHarnessColors;
        public double id;
        public uint model;
        public int[] ancestor;
        public int[] behaviors;
        public string name;
        public int ownerId;
        public double experience;
        public double experienceForLevel;
        public double experienceForNextLevel;
        public sbyte level;
        public uint maxPods;
        public uint stamina;
        public uint staminaMax;
        public uint maturity;
        public uint maturityForAdult;
        public uint energy;
        public uint energyMax;
        public int serenity;
        public int aggressivityMax;
        public uint serenityMax;
        public uint love;
        public uint loveMax;
        public int fecondationTime;
        public int boostLimiter;
        public double boostMax;
        public int reproductionCount;
        public uint reproductionCountMax;
        public uint harnessGID;
        public Types.ObjectEffectInteger[] effectList;
        
        public MountClientData()
        {
        }
        
        public MountClientData(bool sex, bool isRideable, bool isWild, bool isFecondationReady, bool useHarnessColors, double id, uint model, int[] ancestor, int[] behaviors, string name, int ownerId, double experience, double experienceForLevel, double experienceForNextLevel, sbyte level, uint maxPods, uint stamina, uint staminaMax, uint maturity, uint maturityForAdult, uint energy, uint energyMax, int serenity, int aggressivityMax, uint serenityMax, uint love, uint loveMax, int fecondationTime, int boostLimiter, double boostMax, int reproductionCount, uint reproductionCountMax, uint harnessGID, Types.ObjectEffectInteger[] effectList)
        {
            this.sex = sex;
            this.isRideable = isRideable;
            this.isWild = isWild;
            this.isFecondationReady = isFecondationReady;
            this.useHarnessColors = useHarnessColors;
            this.id = id;
            this.model = model;
            this.ancestor = ancestor;
            this.behaviors = behaviors;
            this.name = name;
            this.ownerId = ownerId;
            this.experience = experience;
            this.experienceForLevel = experienceForLevel;
            this.experienceForNextLevel = experienceForNextLevel;
            this.level = level;
            this.maxPods = maxPods;
            this.stamina = stamina;
            this.staminaMax = staminaMax;
            this.maturity = maturity;
            this.maturityForAdult = maturityForAdult;
            this.energy = energy;
            this.energyMax = energyMax;
            this.serenity = serenity;
            this.aggressivityMax = aggressivityMax;
            this.serenityMax = serenityMax;
            this.love = love;
            this.loveMax = loveMax;
            this.fecondationTime = fecondationTime;
            this.boostLimiter = boostLimiter;
            this.boostMax = boostMax;
            this.reproductionCount = reproductionCount;
            this.reproductionCountMax = reproductionCountMax;
            this.harnessGID = harnessGID;
            this.effectList = effectList;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, sex);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isRideable);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, isWild);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, isFecondationReady);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 4, useHarnessColors);
            writer.WriteByte(flag1);
            writer.WriteDouble(id);
            writer.WriteVarInt((int)model);
            writer.WriteShort((short)ancestor.Length);
            foreach (var entry in ancestor)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteShort((short)behaviors.Length);
            foreach (var entry in behaviors)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteUTF(name);
            writer.WriteInt(ownerId);
            writer.WriteVarLong(experience);
            writer.WriteVarLong(experienceForLevel);
            writer.WriteDouble(experienceForNextLevel);
            writer.WriteSbyte(level);
            writer.WriteVarInt((int)maxPods);
            writer.WriteVarInt((int)stamina);
            writer.WriteVarInt((int)staminaMax);
            writer.WriteVarInt((int)maturity);
            writer.WriteVarInt((int)maturityForAdult);
            writer.WriteVarInt((int)energy);
            writer.WriteVarInt((int)energyMax);
            writer.WriteInt(serenity);
            writer.WriteInt(aggressivityMax);
            writer.WriteVarInt((int)serenityMax);
            writer.WriteVarInt((int)love);
            writer.WriteVarInt((int)loveMax);
            writer.WriteInt(fecondationTime);
            writer.WriteInt(boostLimiter);
            writer.WriteDouble(boostMax);
            writer.WriteInt(reproductionCount);
            writer.WriteVarInt((int)reproductionCountMax);
            writer.WriteVarShort((int)harnessGID);
            writer.WriteShort((short)effectList.Length);
            foreach (var entry in effectList)
            {
                 entry.Serialize(writer);
            }
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            sex = BooleanByteWrapper.GetFlag(flag1, 0);
            isRideable = BooleanByteWrapper.GetFlag(flag1, 1);
            isWild = BooleanByteWrapper.GetFlag(flag1, 2);
            isFecondationReady = BooleanByteWrapper.GetFlag(flag1, 3);
            useHarnessColors = BooleanByteWrapper.GetFlag(flag1, 4);
            id = reader.ReadDouble();
            model = reader.ReadVarUhInt();
            var limit = (ushort)reader.ReadUShort();
            ancestor = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 ancestor[i] = reader.ReadInt();
            }
            limit = (ushort)reader.ReadUShort();
            behaviors = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 behaviors[i] = reader.ReadInt();
            }
            name = reader.ReadUTF();
            ownerId = reader.ReadInt();
            experience = reader.ReadVarUhLong();
            experienceForLevel = reader.ReadVarUhLong();
            experienceForNextLevel = reader.ReadDouble();
            level = reader.ReadSbyte();
            maxPods = reader.ReadVarUhInt();
            stamina = reader.ReadVarUhInt();
            staminaMax = reader.ReadVarUhInt();
            maturity = reader.ReadVarUhInt();
            maturityForAdult = reader.ReadVarUhInt();
            energy = reader.ReadVarUhInt();
            energyMax = reader.ReadVarUhInt();
            serenity = reader.ReadInt();
            aggressivityMax = reader.ReadInt();
            serenityMax = reader.ReadVarUhInt();
            love = reader.ReadVarUhInt();
            loveMax = reader.ReadVarUhInt();
            fecondationTime = reader.ReadInt();
            boostLimiter = reader.ReadInt();
            boostMax = reader.ReadDouble();
            reproductionCount = reader.ReadInt();
            reproductionCountMax = reader.ReadVarUhInt();
            harnessGID = reader.ReadVarUhShort();
            limit = (ushort)reader.ReadUShort();
            effectList = new Types.ObjectEffectInteger[limit];
            for (int i = 0; i < limit; i++)
            {
                 effectList[i] = new Types.ObjectEffectInteger();
                 effectList[i].Deserialize(reader);
            }
        }
        
    }
    
}