

// Generated on 04/03/2020 21:59:09
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GameFightMinimalStats
    {
        public const short Id = 31;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint lifePoints;
        public uint maxLifePoints;
        public uint baseMaxLifePoints;
        public uint permanentDamagePercent;
        public uint shieldPoints;
        public int actionPoints;
        public int maxActionPoints;
        public int movementPoints;
        public int maxMovementPoints;
        public double summoner;
        public bool summoned;
        public int neutralElementResistPercent;
        public int earthElementResistPercent;
        public int waterElementResistPercent;
        public int airElementResistPercent;
        public int fireElementResistPercent;
        public int neutralElementReduction;
        public int earthElementReduction;
        public int waterElementReduction;
        public int airElementReduction;
        public int fireElementReduction;
        public int criticalDamageFixedResist;
        public int pushDamageFixedResist;
        public int pvpNeutralElementResistPercent;
        public int pvpEarthElementResistPercent;
        public int pvpWaterElementResistPercent;
        public int pvpAirElementResistPercent;
        public int pvpFireElementResistPercent;
        public int pvpNeutralElementReduction;
        public int pvpEarthElementReduction;
        public int pvpWaterElementReduction;
        public int pvpAirElementReduction;
        public int pvpFireElementReduction;
        public uint dodgePALostProbability;
        public uint dodgePMLostProbability;
        public int tackleBlock;
        public int tackleEvade;
        public int fixedDamageReflection;
        public sbyte invisibilityState;
        public uint meleeDamageReceivedPercent;
        public uint rangedDamageReceivedPercent;
        public uint weaponDamageReceivedPercent;
        public uint spellDamageReceivedPercent;
        
        public GameFightMinimalStats()
        {
        }
        
        public GameFightMinimalStats(uint lifePoints, uint maxLifePoints, uint baseMaxLifePoints, uint permanentDamagePercent, uint shieldPoints, int actionPoints, int maxActionPoints, int movementPoints, int maxMovementPoints, double summoner, bool summoned, int neutralElementResistPercent, int earthElementResistPercent, int waterElementResistPercent, int airElementResistPercent, int fireElementResistPercent, int neutralElementReduction, int earthElementReduction, int waterElementReduction, int airElementReduction, int fireElementReduction, int criticalDamageFixedResist, int pushDamageFixedResist, int pvpNeutralElementResistPercent, int pvpEarthElementResistPercent, int pvpWaterElementResistPercent, int pvpAirElementResistPercent, int pvpFireElementResistPercent, int pvpNeutralElementReduction, int pvpEarthElementReduction, int pvpWaterElementReduction, int pvpAirElementReduction, int pvpFireElementReduction, uint dodgePALostProbability, uint dodgePMLostProbability, int tackleBlock, int tackleEvade, int fixedDamageReflection, sbyte invisibilityState, uint meleeDamageReceivedPercent, uint rangedDamageReceivedPercent, uint weaponDamageReceivedPercent, uint spellDamageReceivedPercent)
        {
            this.lifePoints = lifePoints;
            this.maxLifePoints = maxLifePoints;
            this.baseMaxLifePoints = baseMaxLifePoints;
            this.permanentDamagePercent = permanentDamagePercent;
            this.shieldPoints = shieldPoints;
            this.actionPoints = actionPoints;
            this.maxActionPoints = maxActionPoints;
            this.movementPoints = movementPoints;
            this.maxMovementPoints = maxMovementPoints;
            this.summoner = summoner;
            this.summoned = summoned;
            this.neutralElementResistPercent = neutralElementResistPercent;
            this.earthElementResistPercent = earthElementResistPercent;
            this.waterElementResistPercent = waterElementResistPercent;
            this.airElementResistPercent = airElementResistPercent;
            this.fireElementResistPercent = fireElementResistPercent;
            this.neutralElementReduction = neutralElementReduction;
            this.earthElementReduction = earthElementReduction;
            this.waterElementReduction = waterElementReduction;
            this.airElementReduction = airElementReduction;
            this.fireElementReduction = fireElementReduction;
            this.criticalDamageFixedResist = criticalDamageFixedResist;
            this.pushDamageFixedResist = pushDamageFixedResist;
            this.pvpNeutralElementResistPercent = pvpNeutralElementResistPercent;
            this.pvpEarthElementResistPercent = pvpEarthElementResistPercent;
            this.pvpWaterElementResistPercent = pvpWaterElementResistPercent;
            this.pvpAirElementResistPercent = pvpAirElementResistPercent;
            this.pvpFireElementResistPercent = pvpFireElementResistPercent;
            this.pvpNeutralElementReduction = pvpNeutralElementReduction;
            this.pvpEarthElementReduction = pvpEarthElementReduction;
            this.pvpWaterElementReduction = pvpWaterElementReduction;
            this.pvpAirElementReduction = pvpAirElementReduction;
            this.pvpFireElementReduction = pvpFireElementReduction;
            this.dodgePALostProbability = dodgePALostProbability;
            this.dodgePMLostProbability = dodgePMLostProbability;
            this.tackleBlock = tackleBlock;
            this.tackleEvade = tackleEvade;
            this.fixedDamageReflection = fixedDamageReflection;
            this.invisibilityState = invisibilityState;
            this.meleeDamageReceivedPercent = meleeDamageReceivedPercent;
            this.rangedDamageReceivedPercent = rangedDamageReceivedPercent;
            this.weaponDamageReceivedPercent = weaponDamageReceivedPercent;
            this.spellDamageReceivedPercent = spellDamageReceivedPercent;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)lifePoints);
            writer.WriteVarInt((int)maxLifePoints);
            writer.WriteVarInt((int)baseMaxLifePoints);
            writer.WriteVarInt((int)permanentDamagePercent);
            writer.WriteVarInt((int)shieldPoints);
            writer.WriteVarShort((int)actionPoints);
            writer.WriteVarShort((int)maxActionPoints);
            writer.WriteVarShort((int)movementPoints);
            writer.WriteVarShort((int)maxMovementPoints);
            writer.WriteDouble(summoner);
            writer.WriteBoolean(summoned);
            writer.WriteVarShort((int)neutralElementResistPercent);
            writer.WriteVarShort((int)earthElementResistPercent);
            writer.WriteVarShort((int)waterElementResistPercent);
            writer.WriteVarShort((int)airElementResistPercent);
            writer.WriteVarShort((int)fireElementResistPercent);
            writer.WriteVarShort((int)neutralElementReduction);
            writer.WriteVarShort((int)earthElementReduction);
            writer.WriteVarShort((int)waterElementReduction);
            writer.WriteVarShort((int)airElementReduction);
            writer.WriteVarShort((int)fireElementReduction);
            writer.WriteVarShort((int)criticalDamageFixedResist);
            writer.WriteVarShort((int)pushDamageFixedResist);
            writer.WriteVarShort((int)pvpNeutralElementResistPercent);
            writer.WriteVarShort((int)pvpEarthElementResistPercent);
            writer.WriteVarShort((int)pvpWaterElementResistPercent);
            writer.WriteVarShort((int)pvpAirElementResistPercent);
            writer.WriteVarShort((int)pvpFireElementResistPercent);
            writer.WriteVarShort((int)pvpNeutralElementReduction);
            writer.WriteVarShort((int)pvpEarthElementReduction);
            writer.WriteVarShort((int)pvpWaterElementReduction);
            writer.WriteVarShort((int)pvpAirElementReduction);
            writer.WriteVarShort((int)pvpFireElementReduction);
            writer.WriteVarShort((int)dodgePALostProbability);
            writer.WriteVarShort((int)dodgePMLostProbability);
            writer.WriteVarShort((int)tackleBlock);
            writer.WriteVarShort((int)tackleEvade);
            writer.WriteVarShort((int)fixedDamageReflection);
            writer.WriteSbyte(invisibilityState);
            writer.WriteVarShort((int)meleeDamageReceivedPercent);
            writer.WriteVarShort((int)rangedDamageReceivedPercent);
            writer.WriteVarShort((int)weaponDamageReceivedPercent);
            writer.WriteVarShort((int)spellDamageReceivedPercent);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            lifePoints = reader.ReadVarUhInt();
            maxLifePoints = reader.ReadVarUhInt();
            baseMaxLifePoints = reader.ReadVarUhInt();
            permanentDamagePercent = reader.ReadVarUhInt();
            shieldPoints = reader.ReadVarUhInt();
            actionPoints = reader.ReadVarShort();
            maxActionPoints = reader.ReadVarShort();
            movementPoints = reader.ReadVarShort();
            maxMovementPoints = reader.ReadVarShort();
            summoner = reader.ReadDouble();
            summoned = reader.ReadBoolean();
            neutralElementResistPercent = reader.ReadVarShort();
            earthElementResistPercent = reader.ReadVarShort();
            waterElementResistPercent = reader.ReadVarShort();
            airElementResistPercent = reader.ReadVarShort();
            fireElementResistPercent = reader.ReadVarShort();
            neutralElementReduction = reader.ReadVarShort();
            earthElementReduction = reader.ReadVarShort();
            waterElementReduction = reader.ReadVarShort();
            airElementReduction = reader.ReadVarShort();
            fireElementReduction = reader.ReadVarShort();
            criticalDamageFixedResist = reader.ReadVarShort();
            pushDamageFixedResist = reader.ReadVarShort();
            pvpNeutralElementResistPercent = reader.ReadVarShort();
            pvpEarthElementResistPercent = reader.ReadVarShort();
            pvpWaterElementResistPercent = reader.ReadVarShort();
            pvpAirElementResistPercent = reader.ReadVarShort();
            pvpFireElementResistPercent = reader.ReadVarShort();
            pvpNeutralElementReduction = reader.ReadVarShort();
            pvpEarthElementReduction = reader.ReadVarShort();
            pvpWaterElementReduction = reader.ReadVarShort();
            pvpAirElementReduction = reader.ReadVarShort();
            pvpFireElementReduction = reader.ReadVarShort();
            dodgePALostProbability = reader.ReadVarUhShort();
            dodgePMLostProbability = reader.ReadVarUhShort();
            tackleBlock = reader.ReadVarShort();
            tackleEvade = reader.ReadVarShort();
            fixedDamageReflection = reader.ReadVarShort();
            invisibilityState = reader.ReadSbyte();
            meleeDamageReceivedPercent = reader.ReadVarUhShort();
            rangedDamageReceivedPercent = reader.ReadVarUhShort();
            weaponDamageReceivedPercent = reader.ReadVarUhShort();
            spellDamageReceivedPercent = reader.ReadVarUhShort();
        }
        
    }
    
}