using AmaknaProxy.API.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.Engine.Utils.Config
{
    public class ConfigEntry
    {

        #region Variables

        public object Value;

        public ConfigType Type;

        public string Name;

        #endregion

        #region Builder

        public ConfigEntry()
        { }

        public ConfigEntry(object value, ConfigType type, string name)
        {
            Value = value;
            Type = type;
            Name = name;
        }

        #endregion

        #region Methods

        public void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteInt((int)Type);
            
            switch(Type)
            {
                case ConfigType.INTEGER:
                    writer.WriteInt((int)Value);
                    break;
                case ConfigType.STRING:
                    writer.WriteUTF((string)Value);
                    break;
                case ConfigType.BOOLEAN:
                    writer.WriteBoolean((bool)Value);
                    break;
            }
        }

        public void Deserialize(BigEndianReader reader)
        {
            Name = reader.ReadUTF();
            Type = (ConfigType)reader.ReadInt();

            switch (Type)
            {
                case ConfigType.INTEGER:
                    Value = reader.ReadInt();
                    break;
                case ConfigType.STRING:
                    Value = reader.ReadUTF();
                    break;
                case ConfigType.BOOLEAN:
                    Value = reader.ReadBoolean();
                    break;
            }
        }

        #endregion

    }
}
