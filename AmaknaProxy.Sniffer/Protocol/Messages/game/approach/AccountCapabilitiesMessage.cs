

// Generated on 04/03/2020 21:58:50
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class AccountCapabilitiesMessage : NetworkMessage
    {
        public const uint Id = 6216;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool tutorialAvailable;
        public bool canCreateNewCharacter;
        public int accountId;
        public uint breedsVisible;
        public uint breedsAvailable;
        public sbyte status;
        
        public AccountCapabilitiesMessage()
        {
        }
        
        public AccountCapabilitiesMessage(bool tutorialAvailable, bool canCreateNewCharacter, int accountId, uint breedsVisible, uint breedsAvailable, sbyte status)
        {
            this.tutorialAvailable = tutorialAvailable;
            this.canCreateNewCharacter = canCreateNewCharacter;
            this.accountId = accountId;
            this.breedsVisible = breedsVisible;
            this.breedsAvailable = breedsAvailable;
            this.status = status;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, tutorialAvailable);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, canCreateNewCharacter);
            writer.WriteByte(flag1);
            writer.WriteInt(accountId);
            writer.WriteVarInt((int)breedsVisible);
            writer.WriteVarInt((int)breedsAvailable);
            writer.WriteSbyte(status);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            tutorialAvailable = BooleanByteWrapper.GetFlag(flag1, 0);
            canCreateNewCharacter = BooleanByteWrapper.GetFlag(flag1, 1);
            accountId = reader.ReadInt();
            breedsVisible = reader.ReadVarUhInt();
            breedsAvailable = reader.ReadVarUhInt();
            status = reader.ReadSbyte();
        }
        
    }
    
}