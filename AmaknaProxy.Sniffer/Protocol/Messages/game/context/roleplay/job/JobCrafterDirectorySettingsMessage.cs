

// Generated on 04/03/2020 21:58:56
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class JobCrafterDirectorySettingsMessage : NetworkMessage
    {
        public const uint Id = 5652;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.JobCrafterDirectorySettings[] craftersSettings;
        
        public JobCrafterDirectorySettingsMessage()
        {
        }
        
        public JobCrafterDirectorySettingsMessage(Types.JobCrafterDirectorySettings[] craftersSettings)
        {
            this.craftersSettings = craftersSettings;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)craftersSettings.Length);
            foreach (var entry in craftersSettings)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            craftersSettings = new Types.JobCrafterDirectorySettings[limit];
            for (int i = 0; i < limit; i++)
            {
                 craftersSettings[i] = new Types.JobCrafterDirectorySettings();
                 craftersSettings[i].Deserialize(reader);
            }
        }
        
    }
    
}