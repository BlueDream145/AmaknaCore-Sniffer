using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.API.Client.Enums
{
    public enum ClientStateEnum
    {
        NOTHING = 0,
        MOVING = 1,
        GATHER = 2,
        FIGHTING = 3,
        DIALOG = 4,
        EXCHANGE = 5,
        STORAGE = 6,
        CRAFT = 7,
        InteractiveMoving = 8,
    }
}
