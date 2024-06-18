

// Generated on 04/03/2020 21:59:10
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
    {
        public const short Id = 154;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public string name;
        
        public GameRolePlayNamedActorInformations()
        {
        }
        
        public GameRolePlayNamedActorInformations(double contextualId, Types.EntityDispositionInformations disposition, Types.EntityLook look, string name)
         : base(contextualId, disposition, look)
        {
            this.name = name;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(name);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            name = reader.ReadUTF();
        }
        
    }
    
}