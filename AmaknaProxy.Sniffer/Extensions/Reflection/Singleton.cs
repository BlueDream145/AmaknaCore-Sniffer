﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.API.Extensions.Reflection
{
    public abstract class Singleton<T> where T : class
    {
        /// <summary>
        ///   Returns the singleton instance.
        /// </summary>
        public static T Instance
        {
            get { return SingletonAllocator.instance; }
            protected set { SingletonAllocator.instance = value; }
        }

        #region Nested type: SingletonAllocator

        internal static class SingletonAllocator
        {
            internal static T instance;

            static SingletonAllocator()
            {
                CreateInstance(typeof(T));
            }

            public static T CreateInstance(Type type)
            {
                ConstructorInfo[] ctorsPublic = type.GetConstructors(
                    BindingFlags.Instance | BindingFlags.Public);

                if (ctorsPublic.Length > 0)
                    return instance = (T)Activator.CreateInstance(type);

                ConstructorInfo ctorNonPublic = type.GetConstructor(
                    BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, new ParameterModifier[0]);

                if (ctorNonPublic == null)
                {
                    throw new System.Exception(
                        type.FullName +
                        " doesn't have a private/protected constructor so the property cannot be enforced.");
                }

                try
                {
                    return instance = (T)ctorNonPublic.Invoke(new object[0]);
                }
                catch (System.Exception e)
                {
                    throw new System.Exception(
                        "The Singleton couldnt be constructed, check if " + type.FullName + " has a default constructor",
                        e);
                }
            }
        }

        #endregion
    }
}
