

// Generated on 04/03/2020 21:58:47
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class IdentificationMessage : NetworkMessage
    {
        public const uint Id = 4;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool autoconnect;
        public bool useCertificate;
        public bool useLoginToken;
        public Types.Version version;
        public string lang;
        public sbyte[] credentials;
        public short serverId;
        public double sessionOptionalSalt;
        public uint[] failedAttempts;
        
        public IdentificationMessage()
        {
        }
        
        public IdentificationMessage(bool autoconnect, bool useCertificate, bool useLoginToken, Types.Version version, string lang, sbyte[] credentials, short serverId, double sessionOptionalSalt, uint[] failedAttempts)
        {
            this.autoconnect = autoconnect;
            this.useCertificate = useCertificate;
            this.useLoginToken = useLoginToken;
            this.version = version;
            this.lang = lang;
            this.credentials = credentials;
            this.serverId = serverId;
            this.sessionOptionalSalt = sessionOptionalSalt;
            this.failedAttempts = failedAttempts;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, autoconnect);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, useCertificate);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, useLoginToken);
            writer.WriteByte(flag1);
            version.Serialize(writer);
            writer.WriteUTF(lang);
            writer.WriteVarInt((int)(ushort)credentials.Length);
            foreach (var entry in credentials)
            {
                 writer.WriteSbyte(entry);
            }
            writer.WriteShort(serverId);
            writer.WriteVarLong(sessionOptionalSalt);
            writer.WriteShort((short)failedAttempts.Length);
            foreach (var entry in failedAttempts)
            {
                 writer.WriteVarShort((int)entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            autoconnect = BooleanByteWrapper.GetFlag(flag1, 0);
            useCertificate = BooleanByteWrapper.GetFlag(flag1, 1);
            useLoginToken = BooleanByteWrapper.GetFlag(flag1, 2);
            version = new Types.Version();
            version.Deserialize(reader);
            lang = reader.ReadUTF();
            var limit = (ushort)reader.ReadVarInt();
            credentials = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 credentials[i] = reader.ReadSbyte();
            }
            serverId = reader.ReadShort();
            sessionOptionalSalt = reader.ReadVarLong();
            limit = (ushort)reader.ReadUShort();
            failedAttempts = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 failedAttempts[i] = reader.ReadVarUhShort();
            }
        }
        
    }
    
}