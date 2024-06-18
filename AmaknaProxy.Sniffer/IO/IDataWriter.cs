using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.API.IO
{
    public interface IDataWriter
    {
        byte[] Data
        {
            get;
        }

        /// <summary>
        ///   Write a Short into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteShort(short @short);

        /// <summary>
        ///   Write a int into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteInt(int @int);

        /// <summary>
        ///   Write a long into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteLong(Int64 @long);

        /// <summary>
        ///   Write a UShort into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteUShort(ushort @ushort);

        /// <summary>
        ///   Write a int into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteUInt(UInt32 @uint);

        /// <summary>
        ///   Write a long into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteULong(UInt64 @ulong);

        /// <summary>
        ///   Write a byte into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteByte(byte @byte);
        void WriteSByte(sbyte @byte);
        void WriteSbyte(sbyte @byte);

        /// <summary>
        ///   Write a Float into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteFloat(float @float);

        /// <summary>
        ///   Write a Boolean into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteBoolean(Boolean @bool);

        /// <summary>
        ///   Write a Char into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteChar(Char @char);

        /// <summary>
        ///   Write a Double into the buffer
        /// </summary>
        void WriteDouble(Double @double);

        /// <summary>
        ///   Write a Single into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteSingle(Single @single);

        /// <summary>
        ///   Write a string into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteUTF(string str);

        /// <summary>
        ///   Write a string into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteUTFBytes(string str);

        /// <summary>
        ///   Write bytes array into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteBytes(byte[] data);
        
        /// <summary>
        ///   Write bytes array into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteBytes(byte[] data, uint offset, uint length);

        /// <summary>
        ///   Write a int array into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteVarInt(int @int);

        /// <summary>
        ///   Write a int array into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteVarShort(int @int);

        /// <summary>
        ///   Write a double array into the buffer
        /// </summary>
        /// <returns></returns>
        void WriteVarLong(double @double);

        void Clear();
    }
}
