using AmaknaProxy.API.Utils.Logger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.API.Managers
{
    public static class ConsoleManager
    {

        private static ContainerLogger Logger;

        static ConsoleManager()
        {
            Logger = null;
        }

        public static void InitLogger(ContainerLogger logger)
        {
            Logger = logger;
        }

        public static void Info(string Text)
        {
            if (Logger != null)
                Logger.Info(Text);
        }

        public static void Error(string Text)
        {
            if (Logger != null)
                Logger.Error(Text);
        }

        public static void Warning(string Text)
        {
            if (Logger != null)
                Logger.Warning(Text);
        }

        public static void Debug(string Text)
        {
            if (Logger != null)
                Logger.Debug(Text);
        }

        public static void Chat(string Text, string Prefix, Color Color)
        {
            if (Logger != null)
                Logger.Chat(Text, Prefix, Color);
        }


    }
}
