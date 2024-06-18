

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class InteractiveElement
    {
        public const short Id = 80;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int elementId;
        public int elementTypeId;
        public Types.InteractiveElementSkill[] enabledSkills;
        public Types.InteractiveElementSkill[] disabledSkills;
        public bool onCurrentMap;
        
        public InteractiveElement()
        {
        }
        
        public InteractiveElement(int elementId, int elementTypeId, Types.InteractiveElementSkill[] enabledSkills, Types.InteractiveElementSkill[] disabledSkills, bool onCurrentMap)
        {
            this.elementId = elementId;
            this.elementTypeId = elementTypeId;
            this.enabledSkills = enabledSkills;
            this.disabledSkills = disabledSkills;
            this.onCurrentMap = onCurrentMap;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(elementId);
            writer.WriteInt(elementTypeId);
            writer.WriteShort((short)enabledSkills.Length);
            foreach (var entry in enabledSkills)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteShort((short)disabledSkills.Length);
            foreach (var entry in disabledSkills)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteBoolean(onCurrentMap);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            elementId = reader.ReadInt();
            elementTypeId = reader.ReadInt();
            var limit = (ushort)reader.ReadUShort();
            enabledSkills = new Types.InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                 enabledSkills[i] = ProtocolTypeManager.GetInstance<Types.InteractiveElementSkill>(reader.ReadUShort());
                 enabledSkills[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            disabledSkills = new Types.InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                 disabledSkills[i] = ProtocolTypeManager.GetInstance<Types.InteractiveElementSkill>(reader.ReadUShort());
                 disabledSkills[i].Deserialize(reader);
            }
            onCurrentMap = reader.ReadBoolean();
        }
        
    }
    
}