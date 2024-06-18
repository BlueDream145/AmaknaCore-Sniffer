

// Generated on 04/03/2020 21:58:57
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MapNpcsQuestStatusUpdateMessage : NetworkMessage
    {
        public const uint Id = 5642;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double mapId;
        public int[] npcsIdsWithQuest;
        public Types.GameRolePlayNpcQuestFlag[] questFlags;
        public int[] npcsIdsWithoutQuest;
        
        public MapNpcsQuestStatusUpdateMessage()
        {
        }
        
        public MapNpcsQuestStatusUpdateMessage(double mapId, int[] npcsIdsWithQuest, Types.GameRolePlayNpcQuestFlag[] questFlags, int[] npcsIdsWithoutQuest)
        {
            this.mapId = mapId;
            this.npcsIdsWithQuest = npcsIdsWithQuest;
            this.questFlags = questFlags;
            this.npcsIdsWithoutQuest = npcsIdsWithoutQuest;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(mapId);
            writer.WriteShort((short)npcsIdsWithQuest.Length);
            foreach (var entry in npcsIdsWithQuest)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteShort((short)questFlags.Length);
            foreach (var entry in questFlags)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)npcsIdsWithoutQuest.Length);
            foreach (var entry in npcsIdsWithoutQuest)
            {
                 writer.WriteInt(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            mapId = reader.ReadDouble();
            var limit = (ushort)reader.ReadUShort();
            npcsIdsWithQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 npcsIdsWithQuest[i] = reader.ReadInt();
            }
            limit = (ushort)reader.ReadUShort();
            questFlags = new Types.GameRolePlayNpcQuestFlag[limit];
            for (int i = 0; i < limit; i++)
            {
                 questFlags[i] = new Types.GameRolePlayNpcQuestFlag();
                 questFlags[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            npcsIdsWithoutQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 npcsIdsWithoutQuest[i] = reader.ReadInt();
            }
        }
        
    }
    
}