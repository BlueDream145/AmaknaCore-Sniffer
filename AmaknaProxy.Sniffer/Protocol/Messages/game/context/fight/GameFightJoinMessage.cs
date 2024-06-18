

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameFightJoinMessage : NetworkMessage
    {
        public const uint Id = 702;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool isTeamPhase;
        public bool canBeCancelled;
        public bool canSayReady;
        public bool isFightStarted;
        public short timeMaxBeforeFightStart;
        public sbyte fightType;
        
        public GameFightJoinMessage()
        {
        }
        
        public GameFightJoinMessage(bool isTeamPhase, bool canBeCancelled, bool canSayReady, bool isFightStarted, short timeMaxBeforeFightStart, sbyte fightType)
        {
            this.isTeamPhase = isTeamPhase;
            this.canBeCancelled = canBeCancelled;
            this.canSayReady = canSayReady;
            this.isFightStarted = isFightStarted;
            this.timeMaxBeforeFightStart = timeMaxBeforeFightStart;
            this.fightType = fightType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isTeamPhase);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, canBeCancelled);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, canSayReady);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, isFightStarted);
            writer.WriteByte(flag1);
            writer.WriteShort(timeMaxBeforeFightStart);
            writer.WriteSbyte(fightType);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            isTeamPhase = BooleanByteWrapper.GetFlag(flag1, 0);
            canBeCancelled = BooleanByteWrapper.GetFlag(flag1, 1);
            canSayReady = BooleanByteWrapper.GetFlag(flag1, 2);
            isFightStarted = BooleanByteWrapper.GetFlag(flag1, 3);
            timeMaxBeforeFightStart = reader.ReadShort();
            fightType = reader.ReadSbyte();
        }
        
    }
    
}