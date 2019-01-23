using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client
{
    public abstract class PacketStructure
    {
        private byte[] buffer;
        public PacketStructure(ushort length,ushort type)
        {
            buffer = new byte[length];
            WriteUShort(length, 0);
            WriteUShort(type, 2);
        }
        public PacketStructure(byte[] packet)
        {
            buffer = packet;
        }
        public void WriteUShort(ushort value,int offset)
        {
            byte[] tempBuf = new byte[2];
            tempBuf = BitConverter.GetBytes(value);
            Buffer.BlockCopy(tempBuf, 0, buffer, offset, 2);
        }
        public ushort ReadUShort(int offset)
        {
            return BitConverter.ToUInt16(buffer,offset);
        }
        public void WriteUInt(ushort value, int offset)
        {
            byte[] tempBuf = new byte[4];
            tempBuf = BitConverter.GetBytes(value);
            Buffer.BlockCopy(tempBuf, 0, buffer, offset, 4);
        }
        public void WriteString(string value,int offset)
        {
            byte[] tempBuf = new byte[value.Length];
            tempBuf = Encoding.ASCII.GetBytes(value);
            Buffer.BlockCopy(tempBuf, 0, buffer, offset,value.Length);
        }
        public string ReadString(int offset,int count)
        {
            return Encoding.UTF8.GetString(buffer,offset,count);
        }
        public void RewriteHeader(ushort length,ushort type)
        {
            WriteUShort(length, 0);
            WriteUShort(type, 2);
        }
        public byte[] Data { get { return buffer; } }
    }
}
