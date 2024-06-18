using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.API.IO
{
    public interface IDataReader : IDisposable
    {
        long Position
        {
            get;
        }

        long BytesAvailable
        {
            get;
        }

        /// <summary>
        ///   Read a Short from the Buffer
        /// </summary>
        /// <returns></returns>
        short ReadShort();

        /// <summary>
        ///   Read a int from the Buffer
        /// </summary>
        /// <returns></returns>
        int ReadInt();

        /// <summary>
        ///   Read a long from the Buffer
        /// </summary>
        /// <returns></returns>
        Int64 ReadLong();


        /// <summary>
        ///   Read a UShort from the Buffer
        /// </summary>
        /// <returns></returns>
        ushort ReadUShort();

        /// <summary>
        ///   Read a int from the Buffer
        /// </summary>
        /// <returns></returns>
        UInt32 ReadUInt();

        /// <summary>
        ///   Read a long from the Buffer
        /// </summary>
        /// <returns></returns>
        UInt64 ReadULong();

        /// <summary>
        ///   Read a byte from the Buffer
        /// </summary>
        /// <returns></returns>
        byte ReadByte();
        sbyte ReadSByte();
        sbyte ReadSbyte();

        /// <summary>
        ///   Returns N bytes from the buffer
        /// </summary>
        /// <param name = "n">Number of read bytes.</param>
        /// <returns></returns>
        byte[] ReadBytes(int n);

        /// <summary>
        ///   Read a Boolean from the Buffer
        /// </summary>
        /// <returns></returns>
        Boolean ReadBoolean();

        /// <summary>
        ///   Read a Char from the Buffer
        /// </summary>
        /// <returns></returns>
        Char ReadChar();

        /// <summary>
        ///   Read a Double from the Buffer
        /// </summary>
        /// <returns></returns>
        Double ReadDouble();

        /// <summary>
        ///   Read a Float from the Buffer
        /// </summary>
        /// <returns></returns>
        float ReadFloat();

        /// <summary>
        ///   Read a string from the Buffer
        /// </summary>
        /// <returns></returns>
        string ReadUTF();

        /// <summary>
        ///   Read a string from the Buffer
        /// </summary>
        /// <returns></returns>
        string ReadUTFBytes(ushort len);

        /// <summary>
        ///   Read a int from the Buffer
        /// </summary>
        /// <returns></returns>
        int ReadVarInt();

        /// <summary>
        ///   Read a uint from the Buffer
        /// </summary>
        /// <returns></returns>
        uint ReadVarUhInt();

        /// <summary>
        ///   Read a int from the Buffer
        /// </summary>
        /// <returns></returns>
        int ReadVarShort();

        /// <summary>
        ///   Read a uint from the Buffer
        /// </summary>
        /// <returns></returns>
        uint ReadVarUhShort();

        /// <summary>
        ///   Read a double from the Buffer
        /// </summary>
        /// <returns></returns>
        double ReadVarLong();

        /// <summary>
        ///   Read a double from the Buffer
        /// </summary>
        /// <returns></returns>
        double ReadVarUhLong();

        void Seek(int offset, SeekOrigin seekOrigin);
        void SkipBytes(int n);
    }
}
