#region License GNU GPL
// FastLittleEndianReader.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#endregion

using System;
using System.IO;
using System.Text;

namespace AmaknaProxy.API.IO
{
    public unsafe class LittleEndianReader
    {
        private long position = 0;
        private readonly byte[] buffer;

        public byte[] Buffer
        {
            get { return buffer; }
        }

        public LittleEndianReader(byte[] buffer)
        {
            this.buffer = buffer;
        }

        public byte ReadByte()
        {
            fixed (byte* pbyte = &buffer[position++])
            {
                return *pbyte;
            }
        }

        public sbyte ReadSByte()
        {
            fixed (byte* pbyte = &buffer[position++])
            {
                return (sbyte)*pbyte;
            }
        }

        public long Position
        {
            get { return position; }
        }

        public long BytesAvailable
        {
            get { return buffer.Length - position; }
        }

        public short ReadShort()
        {
            var position = this.position;
            this.position += 2;
            fixed (byte* pbyte = &buffer[position])
            {
                    return (short)((*pbyte) | (*(pbyte + 1) << 8)) ; 
            }
        }

        public int ReadInt()
        {
            var position = this.position;
            this.position += 4;
            fixed (byte* pbyte = &buffer[position])
            {
                return ( *pbyte ) | ( *( pbyte + 1 ) << 8 ) | ( *( pbyte + 2 ) << 16 ) | ( *( pbyte + 3 ) << 24 );
            }
        }

        public long ReadLong()
        {
            var position = this.position;
            this.position += 8;
            fixed (byte* pbyte = &buffer[position])
            {
                int i1 = ( *pbyte ) | ( *( pbyte + 1 ) << 8 ) | ( *( pbyte + 2 ) << 16 ) | ( *( pbyte + 3 ) << 24 );
                int i2  = ( *( pbyte + 4 ) ) | ( *( pbyte + 5 ) << 8 ) | ( *( pbyte + 6 ) << 16 ) | ( *( pbyte + 7 ) << 24 );
                return (uint)i1 | ( (long)i2 << 32 ); 
            }
        }

        public ushort ReadUShort()
        {
            return (ushort)ReadShort();
        }

        public uint ReadUInt()
        {
            return (uint)ReadInt();
        }

        public ulong ReadULong()
        {
            return (ulong)ReadLong();
        }

        public byte[] ReadBytes(int n)
        {
            var dst = new byte[n];
            fixed (byte* pSrc = &buffer[position], pDst = dst)
            {
                byte* ps = pSrc;
                byte* pd = pDst;

                // Loop over the count in blocks of 4 bytes, copying an integer (4 bytes) at a time:
                for (int i = 0; i < n / 4; i++)
                {
                    *( (int*)pd ) = *( (int*)ps );
                    pd += 4;
                    ps += 4;
                }

                // Complete the copy by moving any bytes that weren't moved in blocks of 4:
                for (int i = 0; i < n % 4; i++)
                {
                    *pd = *ps;
                    pd++;
                    ps++;
                }
            }

            position += n;

            return dst;
        }

        public bool ReadBoolean()
        {
            return ReadByte() != 0;
        }

        public char ReadChar()
        {
            return (char)ReadShort();
        }

        public float ReadFloat()
        {
            int val = ReadInt();
            return *(float*)&val;
        }

        public double ReadDouble()
        {
            long val = ReadLong();
            return *(double*)&val;
        }

        public string ReadUTF()
        {
            ushort length = ReadUShort();

            byte[] bytes = ReadBytes(length);
            return Encoding.UTF8.GetString(bytes);
        }

        public string ReadUTFBytes(ushort len)
        {
            byte[] bytes = ReadBytes(len);
            return Encoding.UTF8.GetString(bytes);
        }

        public void Seek(int offset, SeekOrigin seekOrigin)
        {
            if (seekOrigin == SeekOrigin.Begin)
                position = offset;
            else if (seekOrigin == SeekOrigin.End)
                position = buffer.Length + offset;
            else if (seekOrigin == SeekOrigin.Current)
                position += offset;
        }

        public void SkipBytes(int n)
        {
            position += n;
        }

        public void Dispose()
        {
            
        }
    }
}