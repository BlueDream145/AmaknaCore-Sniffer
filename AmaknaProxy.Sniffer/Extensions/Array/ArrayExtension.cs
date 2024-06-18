using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.API.Extensions.Array
{
    public static class ArrayExtension
    {
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                System.Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                System.Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }

    }
}
