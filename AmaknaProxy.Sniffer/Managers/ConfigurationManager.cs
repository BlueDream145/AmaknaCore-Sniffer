using AmaknaProxy.API.IO;
using AmaknaProxy.API.Managers;
using AmaknaProxy.Engine.Utils.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.Engine.Managers
{
    public class ConfigurationManager
    {

        #region Variables

        public static List<ConfigEntry> ConfigsList;

        public static object CheckLock;

        private static bool Loaded;

        #endregion

        #region Builder

        static ConfigurationManager()
        {
            ConfigsList = new List<ConfigEntry>();
            CheckLock = new object();
            Loaded = false;
        }

        #endregion

        #region Methods

        public static ConfigEntry GetEntryByName(string name)
        {
            if (!Loaded)
                DeserializeConfig();

            return ConfigsList.FirstOrDefault(f => f.Name == name);
        }

        public static void AddEntry(ConfigEntry entry)
        {
            if (!Loaded)
                DeserializeConfig();

            List<ConfigEntry> Trash = ConfigsList.FindAll(f => f.Name == entry.Name);
            while(Trash.Count > 0)
            {
                ConfigsList.Remove(Trash[0]);
                Trash.Remove(Trash[0]);
            }

            ConfigsList.Add(entry);
            SerializeConfig();
        }

        public static bool IsFileExists()
        {
            if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, "config.ap")))
                return true;
            else
                return false;
        }

        public static bool DeserializeConfig()
        {
            if (IsFileExists() == false)
                return false;

            lock(CheckLock)
            {
                try
                {
                    BigEndianReader reader = new BigEndianReader(File.ReadAllBytes(Path.Combine(System.Windows.Forms.Application.StartupPath, "config.ap")));
                    int count = reader.ReadInt();

                    ConfigsList = new List<ConfigEntry>();

                    for (int i = 0; i < count; i++)
                    {
                        ConfigEntry entry = new ConfigEntry();
                        entry.Deserialize(reader);
                        ConfigsList.Add(entry);
                    }

                    Loaded = true;
                    reader.Close();
                    reader.Dispose();

                    return true;
                }
                catch (Exception ex)
                {
                    WindowManager.MainWindow.Logger.Error("Read file error -> " + ex.Message);
                    return false;
                }
            }
        }

        public static bool SerializeConfig()
        {
            lock (CheckLock)
            {
                try
                {
                    BigEndianWriter writer = new BigEndianWriter();

                    writer.WriteInt(ConfigsList.Count);

                    foreach (ConfigEntry entry in ConfigsList)
                        entry.Serialize(writer);

                    File.WriteAllBytes(Path.Combine(System.Windows.Forms.Application.StartupPath, "config.ap"), writer.Data);
                    writer.Dispose();

                    return true;
                }
                catch (Exception ex)
                {
                    WindowManager.MainWindow.Logger.Error("Write file error -> " + ex.Message);
                    return false;
                }
            }
        }

        #endregion

    }
}
