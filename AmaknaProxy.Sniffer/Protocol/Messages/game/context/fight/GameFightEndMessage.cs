

// Generated on 04/03/2020 21:58:52
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class GameFightEndMessage : NetworkMessage
    {
        public const uint Id = 720;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int duration;
        public int rewardRate;
        public short lootShareLimitMalus;
        public Types.FightResultListEntry[] results;
        public Types.NamedPartyTeamWithOutcome[] namedPartyTeamsOutcomes;
        
        public GameFightEndMessage()
        {
        }
        
        public GameFightEndMessage(int duration, int rewardRate, short lootShareLimitMalus, Types.FightResultListEntry[] results, Types.NamedPartyTeamWithOutcome[] namedPartyTeamsOutcomes)
        {
            this.duration = duration;
            this.rewardRate = rewardRate;
            this.lootShareLimitMalus = lootShareLimitMalus;
            this.results = results;
            this.namedPartyTeamsOutcomes = namedPartyTeamsOutcomes;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(duration);
            writer.WriteVarShort((int)rewardRate);
            writer.WriteShort(lootShareLimitMalus);
            writer.WriteShort((short)results.Length);
            foreach (var entry in results)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)namedPartyTeamsOutcomes.Length);
            foreach (var entry in namedPartyTeamsOutcomes)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            duration = reader.ReadInt();
            rewardRate = reader.ReadVarShort();
            lootShareLimitMalus = reader.ReadShort();
            var limit = (ushort)reader.ReadUShort();
            results = new Types.FightResultListEntry[limit];
            for (int i = 0; i < limit; i++)
            {
                 results[i] = ProtocolTypeManager.GetInstance<Types.FightResultListEntry>(reader.ReadUShort());
                 results[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            namedPartyTeamsOutcomes = new Types.NamedPartyTeamWithOutcome[limit];
            for (int i = 0; i < limit; i++)
            {
                 namedPartyTeamsOutcomes[i] = new Types.NamedPartyTeamWithOutcome();
                 namedPartyTeamsOutcomes[i].Deserialize(reader);
            }
        }
        
    }
    
}