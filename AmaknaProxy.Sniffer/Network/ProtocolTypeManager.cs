using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AmaknaProxy.API.Extensions.Reflection;
using System.Runtime.Serialization;
using AmaknaProxy.API.Managers;

namespace AmaknaProxy.API.Protocol
{
    public static class ProtocolTypeManager
    {

        private static readonly Dictionary<short, Type> types = new Dictionary<short, Type>(200);
        private static readonly Dictionary<short, Func<object>> typesConstructors = new Dictionary<short, Func<object>>(200);

        public static void Initialize()
        {
            Assembly asm = Assembly.GetAssembly(typeof(ProtocolTypeManager));

            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == null || !type.Namespace.StartsWith(typeof(AmaknaProxy.API.Protocol.Types.GameServerInformations).Namespace))
                    continue;

                FieldInfo field = type.GetField("Id");

                if (field != null)
                {
                    // le cast uint est obligatoire car l'objet n'a pas de type
                    short id = (short)(field.GetValue(type));

                    types.Add(id, type);

                    ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);

                    if (ctor == null)
                        throw new System.Exception(string.Format("'{0}' doesn't implemented a parameterless constructor", type));

                    typesConstructors.Add(id, ctor.CreateDelegate<Func<object>>());
                }
            }
        }

        public static T GetInstance<T>(ushort id) where T : class
        {
            if (!types.ContainsKey((short)id))
            {
                ConsoleManager.Error(string.Format("Type <id:{0}> doesn't exist", id));
            }

            return typesConstructors[(short)id]() as T;
        }

        [Serializable]
        public class ProtocolTypeNotFoundException : System.Exception
        {
            public ProtocolTypeNotFoundException()
            {
            }

            public ProtocolTypeNotFoundException(string message)
                : base(message)
            {
            }

            public ProtocolTypeNotFoundException(string message, System.Exception inner)
                : base(message, inner)
            {
            }

            protected ProtocolTypeNotFoundException(
                SerializationInfo info,
                StreamingContext context)
                : base(info, context)
            {
            }
        }

    }
}
