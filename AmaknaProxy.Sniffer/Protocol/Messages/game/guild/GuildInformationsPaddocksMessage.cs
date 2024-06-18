

// Generated on 04/03/2020 21:59:01
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GuildInformationsPaddocksMessage : NetworkMessage
    {
        public const uint Id = 5959;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte nbPaddockMax;
        public Types.PaddockContentInformations[] paddocksInformations;
        
        public GuildInformationsPaddocksMessage()
        {
        }
        
        public GuildInformationsPaddocksMessage(sbyte nbPaddockMax, Types.PaddockContentInformations[] paddocksInformations)
        {
            this.nbPaddockMax = nbPaddockMax;
            this.paddocksInformations = paddocksInformations;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(nbPaddockMax);
            writer.WriteShort((short)paddocksInformations.Length);
            foreach (var entry in paddocksInformations)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            nbPaddockMax = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            paddocksInformations = new Types.PaddockContentInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 paddocksInformations[i] = new Types.PaddockContentInformations();
                 paddocksInformations[i].Deserialize(reader);
            }
        }
        
    }
    
}