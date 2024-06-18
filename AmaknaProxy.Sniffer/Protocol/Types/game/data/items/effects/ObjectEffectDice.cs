

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class ObjectEffectDice : ObjectEffect
    {
        public const short Id = 73;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public uint diceNum;
        public uint diceSide;
        public uint diceConst;
        
        public ObjectEffectDice()
        {
        }
        
        public ObjectEffectDice(uint actionId, uint diceNum, uint diceSide, uint diceConst)
         : base(actionId)
        {
            this.diceNum = diceNum;
            this.diceSide = diceSide;
            this.diceConst = diceConst;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)diceNum);
            writer.WriteVarInt((int)diceSide);
            writer.WriteVarInt((int)diceConst);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            diceNum = reader.ReadVarUhInt();
            diceSide = reader.ReadVarUhInt();
            diceConst = reader.ReadVarUhInt();
        }
        
    }
    
}