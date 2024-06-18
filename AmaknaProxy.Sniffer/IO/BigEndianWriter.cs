using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AmaknaProxy.API.IO
{
    public class BigEndianWriter : IDataWriter, IDisposable
    {
        #region Properties

        private BinaryWriter m_writer;

        public Stream BaseStream
        {
            get { return m_writer.BaseStream; }
        }

        /// <summary>
        ///   Gets available bytes number in the buffer
        /// </summary>
        public long BytesAvailable
        {
            get { return m_writer.BaseStream.Length - m_writer.BaseStream.Position; }
        }

        public long Position
        {
            get { return m_writer.BaseStream.Position; }
            set
            {
                m_writer.BaseStream.Position = value;
            }
        }

        public byte[] Data
        {
            get
            {
                var pos = m_writer.BaseStream.Position;

                var data = new byte[m_writer.BaseStream.Length];
                m_writer.BaseStream.Position = 0;
                m_writer.BaseStream.Read(data, 0, (int)m_writer.BaseStream.Length);

                m_writer.BaseStream.Position = pos;

                return data;
            }
        }

        #endregion

        #region Initialisation

        /// <summary>
        /// Initializes a new instance of the <see cref="BigEndianWriter"/> class.
        /// </summary>
        public BigEndianWriter()
        {
            m_writer = new BinaryWriter(new MemoryStream(), Encoding.UTF8);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BigEndianWriter"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public BigEndianWriter(Stream stream)
        {
            m_writer = new BinaryWriter(stream, Encoding.UTF8);
        }

        public BigEndianWriter(byte[] buffer)
        {
            m_writer = new BinaryWriter(new MemoryStream(buffer));
        }
        #endregion

        #region Private Methods

        /// <summary>
        ///   Reverse bytes and write them into the buffer
        /// </summary>
        private void WriteBigEndianBytes(byte[] endianBytes)
        {
            for (int i = endianBytes.Length - 1; i >= 0; i--)
            {
                m_writer.Write(endianBytes[i]);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///   Write a Short into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteShort(short @short)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@short));
        }

        /// <summary>
        ///   Write a int into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteInt(int @int)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@int));
        }

        /// <summary>
        ///   Write a long into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteLong(Int64 @long)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@long));
        }

        /// <summary>
        ///   Write a UShort into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteUShort(ushort @ushort)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@ushort));
        }

        /// <summary>
        ///   Write a int into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteUInt(UInt32 @uint)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@uint));
        }

        /// <summary>
        ///   Write a long into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteULong(UInt64 @ulong)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@ulong));
        }

        /// <summary>
        ///   Write a byte into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteByte(byte @byte)
        {
            m_writer.Write(@byte);
        }

        public void WriteSByte(sbyte @byte)
        {
            WriteSbyte(@byte);
        }

        public void WriteSbyte(sbyte @byte)
        {
            m_writer.Write(@byte);
        }
        /// <summary>
        ///   Write a Float into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteFloat(float @float)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@float));
        }

        /// <summary>
        ///   Write a Boolean into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteBoolean(Boolean @bool)
        {
            if (@bool)
            {
                m_writer.Write((byte)1);
            }
            else
            {
                m_writer.Write((byte)0);
            }
        }

        /// <summary>
        ///   Write a Char into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteChar(Char @char)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@char));
        }

        /// <summary>
        ///   Write a Double into the buffer
        /// </summary>
        public void WriteDouble(Double @double)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@double));
        }

        /// <summary>
        ///   Write a Single into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteSingle(Single @single)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@single));
        }

        /// <summary>
        ///   Write a string into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteUTF(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var len = (ushort)bytes.Length;
            WriteUShort(len);

            int i;
            for (i = 0; i < len; i++)
                m_writer.Write(bytes[i]);
        }

        /// <summary>
        ///   Write a string into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteUTFBytes(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var len = bytes.Length;
            int i;
            for (i = 0; i < len; i++)
                m_writer.Write(bytes[i]);
        }

        /// <summary>
        ///   Write a bytes array into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteBytes(byte[] data)
        {
            m_writer.Write(data);
        }

        /// <summary>
        ///   Write a bytes array into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteBytes(byte[] data, uint offset, uint length)
        {
            byte[] array = new byte[length];
            Array.Copy(data, offset, array, 0, length);
            m_writer.Write(array);
        }


        public void Seek(int offset, SeekOrigin seekOrigin)
        {
            m_writer.BaseStream.Seek(offset, seekOrigin);
        }


        public void Clear()
        {
            m_writer = new BinaryWriter(new MemoryStream(), Encoding.UTF8);
        }

        #endregion

        #region Custom Methods

        private const int INT_SIZE = 32;
        private const int SHORT_SIZE = 16;
        private const int SHORT_MIN_VALUE = -32768;
        private const int SHORT_MAX_VALUE = 32767;
        private const int UNSIGNED_SHORT_MAX_VALUE = 65536;
        private const int CHUNCK_BIT_SIZE = 7;

        private const int MASK_1 = 128;
        private const int MASK_0 = 127;

        public void WriteVarInt(int @int)
        {
            var local_5 = 0;
            BigEndianWriter local_2 = new BigEndianWriter();

            if(@int >= 0 && @int <= MASK_0)
            {
                local_2.WriteByte((byte)@int);
                WriteBytes(local_2.Data);
                return;
            }

            int local_3 = @int;
            BigEndianWriter local_4 = new BigEndianWriter();

            while (local_3 != 0)
            {
                local_4.WriteByte((byte)(local_3 & MASK_0));

                BigEndianReader local_4_reader = new BigEndianReader(local_4.Data);
                local_5 = local_4_reader.ReadByte();
                local_4 = new BigEndianWriter(local_4_reader.Data);

                local_3 = (int)((uint)local_3 >> CHUNCK_BIT_SIZE);
                if(local_3 > 0)
                {
                    local_5 = local_5 | MASK_1;
                }
                local_2.WriteByte((byte)local_5);
            }

            WriteBytes(local_2.Data);
        }
        
        public void WriteVarShort(int @int)
        {
            var local_5 = 0;
            if(@int > SHORT_MAX_VALUE || @int < SHORT_MIN_VALUE)
            {
                throw new System.Exception("Forbidden value");
            }
            else
            {
                BigEndianWriter local_2 = new BigEndianWriter();
                if(@int >= 0 && @int <= MASK_0)
                {
                    local_2.WriteByte((byte)@int);
                    WriteBytes(local_2.Data);
                    return;
                }

                var local_3 = @int & 65535;
                BigEndianWriter local_4 = new BigEndianWriter();

                while (local_3 != 0)
                {
                    local_4.WriteByte((byte)(local_3 & MASK_0));
                    BigEndianReader local_4_reader = new BigEndianReader(local_4.Data);
                    local_5 = local_4_reader.ReadByte();
                    local_4 = new BigEndianWriter(local_4_reader.Data);

                    local_3 = (int)((uint)local_3 >> CHUNCK_BIT_SIZE);
                    if(local_3 > 0)
                    {
                        local_5 = local_5 | MASK_1;
                    }
                    local_2.WriteByte((byte)local_5);
                }
                WriteBytes(local_2.Data);
                return;
            }
        }

        public void WriteVarLong(double @double)
        {
            uint local_3 = 0;
            FinalInt64 local_2 = FinalInt64.FromNumber(@double);
            if(local_2.High == 0)
            {
                WriteInt32((uint)local_2.Low);
            }
            else
            {
                local_3 = 0;
                while(local_3 < 4)
                {
                    WriteByte((byte)((uint)local_2.Low & 127 | 128));
                    local_2.Low = (long)local_2.Low >> 7;
                    local_3++;
                }
                if(((uint)local_2.High & 268435455 << 3) == 0)
                {
                    WriteByte((byte)((uint)local_2.High << 4 | (uint)local_2.Low));
                }
                else
                {
                    WriteByte((byte)(((uint)local_2.High << 4 | (uint)local_2.Low) & 127 | 128));
                    WriteInt32((uint)(local_2.High >> 3));
                }
            }
        }

        public void WriteInt32(uint param1)
        {
            while(param1 >= 128)
            {
                WriteByte((byte)(param1 & 127 | 128));
                param1 = param1 >> 7;
            }
            WriteByte((byte)param1);
        }


        #endregion

        #region Dispose

        public void Dispose()
        {
            m_writer.Dispose();
            m_writer = null;
        }

        #endregion
    }
}
