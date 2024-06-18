using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AmaknaProxy.API.Extensions.Reflection;
using AmaknaProxy.API.Managers;

namespace AmaknaProxy.API.Protocol
{
    public static class MessageReceiver
    {

        #region Variables

        private static readonly Dictionary<uint, Func<NetworkMessage>> m_constructors = new Dictionary<uint, Func<NetworkMessage>>(800);
        private static readonly Dictionary<uint, Type> m_messages = new Dictionary<uint, Type>(800);

        #endregion

        #region Methods

        public static NetworkMessage BuildMessage(uint id, IDataReader reader)
        {
            try
            {
                if (!m_messages.ContainsKey(id))
                    throw new MessageNotFoundException(string.Format("NetworkMessage <id:{0}> doesn't exist", id));

                NetworkMessage message = m_constructors[id]();

                if (message == null)
                    throw new MessageNotFoundException(string.Format("Constructors[{0}] (delegate {1}) does not exist", id, m_messages[id]));

                try
                {
                    message.Unpack(reader);
                }
                catch (Exception ex)
                {
                    ConsoleManager.Error(string.Format("Can't deserialize message for id {0} ({1}).", id, ex.Message));
                    return message;
                }

                return message;
            }
            catch(Exception ex)
            {
                ConsoleManager.Error(string.Format("Can't BuildMessage for id {0} ({1}).", id, ex.Message));
                return null;
            }
        }

        public static void Initialize()
        {
            Assembly asm = Assembly.GetAssembly(typeof(MessageReceiver));

            foreach (Type type in asm.GetTypes())
            {
                if (!type.IsSubclassOf(typeof(NetworkMessage)))
                    continue;

                FieldInfo fieldId = type.GetField("Id");

                if (fieldId != null)
                {
                    uint id = (uint)fieldId.GetValue(type);
                    if (m_messages.ContainsKey(id))
                        throw new AmbiguousMatchException(
                            string.Format(
                                "MessageReceiver() => {0} item is already in the dictionary, old type is : {1}, new type is  {2}",
                                id, m_messages[id], type));

                    m_messages.Add(id, type);

                    ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);

                    if (ctor == null)
                        throw new System.Exception(
                            string.Format("'{0}' doesn't implemented a parameterless constructor",
                                          type));

                    m_constructors.Add(id, ctor.CreateDelegate<Func<NetworkMessage>>());
                }
            }
        }

        public static Type GetMessageType(uint id)
        {
            if (!m_messages.ContainsKey(id))
                throw new MessageNotFoundException(string.Format("NetworkMessage <id:{0}> doesn't exist", id));

            return m_messages[id];
        }

        #endregion

        #region Nested type: MessageNotFoundException

        [Serializable]
        public class MessageNotFoundException : System.Exception
        {
            public MessageNotFoundException()
            {
            }

            public MessageNotFoundException(string message)
                : base(message)
            {
            }

            public MessageNotFoundException(string message, System.Exception inner)
                : base(message, inner)
            {
            }

            protected MessageNotFoundException(
                SerializationInfo info,
                StreamingContext context)
                : base(info, context)
            {
            }
        }

        #endregion

    }
}
