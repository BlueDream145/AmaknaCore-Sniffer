

// Generated on 04/03/2020 21:58:54
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.Protocol.Types;
using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;

namespace AmaknaProxy.API.Protocol.Messages
{
    public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
    {
        public const uint Id = 6130;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.HouseInformationsInside currentHouse;
        
        public MapComplementaryInformationsDataInHouseMessage()
        {
        }
        
        public MapComplementaryInformationsDataInHouseMessage(uint subAreaId, double mapId, Types.HouseInformations[] houses, Types.GameRolePlayActorInformations[] actors, Types.InteractiveElement[] interactiveElements, Types.StatedElement[] statedElements, Types.MapObstacle[] obstacles, Types.FightCommonInformations[] fights, bool hasAggressiveMonsters, Types.FightStartingPositions fightStartPositions, Types.HouseInformationsInside currentHouse)
         : base(subAreaId, mapId, houses, actors, interactiveElements, statedElements, obstacles, fights, hasAggressiveMonsters, fightStartPositions)
        {
            this.currentHouse = currentHouse;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            currentHouse.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            currentHouse = new Types.HouseInformationsInside();
            currentHouse.Deserialize(reader);
        }
        
    }
    
}