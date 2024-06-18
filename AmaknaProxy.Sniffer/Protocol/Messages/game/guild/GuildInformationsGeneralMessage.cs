

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildInformationsGeneralMessage : NetworkMessage
    {
        public const uint Id = 5557;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool abandonnedPaddock;
        public byte level;
        public double expLevelFloor;
        public double experience;
        public double expNextLevelFloor;
        public int creationDate;
        public uint nbTotalMembers;
        public uint nbConnectedMembers;
        
        public GuildInformationsGeneralMessage()
        {
        }
        
        public GuildInformationsGeneralMessage(bool abandonnedPaddock, byte level, double expLevelFloor, double experience, double expNextLevelFloor, int creationDate, uint nbTotalMembers, uint nbConnectedMembers)
        {
            this.abandonnedPaddock = abandonnedPaddock;
            this.level = level;
            this.expLevelFloor = expLevelFloor;
            this.experience = experience;
            this.expNextLevelFloor = expNextLevelFloor;
            this.creationDate = creationDate;
            this.nbTotalMembers = nbTotalMembers;
            this.nbConnectedMembers = nbConnectedMembers;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(abandonnedPaddock);
            writer.WriteByte(level);
            writer.WriteVarLong(expLevelFloor);
            writer.WriteVarLong(experience);
            writer.WriteVarLong(expNextLevelFloor);
            writer.WriteInt(creationDate);
            writer.WriteVarShort((int)nbTotalMembers);
            writer.WriteVarShort((int)nbConnectedMembers);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            abandonnedPaddock = reader.ReadBoolean();
            level = reader.ReadByte();
            expLevelFloor = reader.ReadVarUhLong();
            experience = reader.ReadVarUhLong();
            expNextLevelFloor = reader.ReadVarUhLong();
            creationDate = reader.ReadInt();
            nbTotalMembers = reader.ReadVarUhShort();
            nbConnectedMembers = reader.ReadVarUhShort();
        }
        
    }
    
}