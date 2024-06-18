

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class ServerSettingsMessage : NetworkMessage
    {
        public const uint Id = 6340;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool isMonoAccount;
        public bool hasFreeAutopilot;
        public string lang;
        public sbyte community;
        public sbyte gameType;
        public uint arenaLeaveBanTime;
        public int itemMaxLevel;
        
        public ServerSettingsMessage()
        {
        }
        
        public ServerSettingsMessage(bool isMonoAccount, bool hasFreeAutopilot, string lang, sbyte community, sbyte gameType, uint arenaLeaveBanTime, int itemMaxLevel)
        {
            this.isMonoAccount = isMonoAccount;
            this.hasFreeAutopilot = hasFreeAutopilot;
            this.lang = lang;
            this.community = community;
            this.gameType = gameType;
            this.arenaLeaveBanTime = arenaLeaveBanTime;
            this.itemMaxLevel = itemMaxLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isMonoAccount);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, hasFreeAutopilot);
            writer.WriteByte(flag1);
            writer.WriteUTF(lang);
            writer.WriteSbyte(community);
            writer.WriteSbyte(gameType);
            writer.WriteVarShort((int)arenaLeaveBanTime);
            writer.WriteInt(itemMaxLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            isMonoAccount = BooleanByteWrapper.GetFlag(flag1, 0);
            hasFreeAutopilot = BooleanByteWrapper.GetFlag(flag1, 1);
            lang = reader.ReadUTF();
            community = reader.ReadSbyte();
            gameType = reader.ReadSbyte();
            arenaLeaveBanTime = reader.ReadVarUhShort();
            itemMaxLevel = reader.ReadInt();
        }
        
    }
    
}