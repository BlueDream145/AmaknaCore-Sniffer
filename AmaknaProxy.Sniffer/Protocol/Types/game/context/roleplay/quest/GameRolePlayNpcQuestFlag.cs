

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GameRolePlayNpcQuestFlag
    {
        public const short Id = 384;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public uint[] questsToValidId;
        public uint[] questsToStartId;
        
        public GameRolePlayNpcQuestFlag()
        {
        }
        
        public GameRolePlayNpcQuestFlag(uint[] questsToValidId, uint[] questsToStartId)
        {
            this.questsToValidId = questsToValidId;
            this.questsToStartId = questsToStartId;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)questsToValidId.Length);
            foreach (var entry in questsToValidId)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteShort((short)questsToStartId.Length);
            foreach (var entry in questsToStartId)
            {
                 writer.WriteVarShort((int)entry);
            }
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            var limit = (ushort)reader.ReadUShort();
            questsToValidId = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 questsToValidId[i] = reader.ReadVarUhShort();
            }
            limit = (ushort)reader.ReadUShort();
            questsToStartId = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 questsToStartId[i] = reader.ReadVarUhShort();
            }
        }
        
    }
    
}