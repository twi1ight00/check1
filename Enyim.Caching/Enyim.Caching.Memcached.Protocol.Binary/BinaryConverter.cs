using System;
using System.Text;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public static class BinaryConverter
{
	public static ushort DecodeUInt16(byte[] buffer, int offset)
	{
		return (ushort)((buffer[offset] << 8) + buffer[offset + 1]);
	}

	public unsafe static ushort DecodeUInt16(byte* buffer, int offset)
	{
		return (ushort)((buffer[offset] << 8) + buffer[offset + 1]);
	}

	public unsafe static int DecodeInt32(ArraySegment<byte> segment, int offset)
	{
		fixed (byte* buffer = segment.Array)
		{
			_ = segment.Offset;
			return DecodeInt32(buffer, 0);
		}
	}

	public unsafe static int DecodeInt32(byte* buffer, int offset)
	{
		buffer += offset;
		return (*buffer << 24) | (buffer[1] << 16) | (buffer[2] << 8) | buffer[3];
	}

	public static int DecodeInt32(byte[] buffer, int offset)
	{
		return (buffer[offset] << 24) | (buffer[offset + 1] << 16) | (buffer[offset + 2] << 8) | buffer[offset + 3];
	}

	public unsafe static ulong DecodeUInt64(byte[] buffer, int offset)
	{
		fixed (byte* ptr = buffer)
		{
			return DecodeUInt64(ptr, offset);
		}
	}

	public unsafe static ulong DecodeUInt64(byte* buffer, int offset)
	{
		buffer += offset;
		uint part1 = (uint)((*buffer << 24) | (buffer[1] << 16) | (buffer[2] << 8) | buffer[3]);
		uint part2 = (uint)((buffer[4] << 24) | (buffer[5] << 16) | (buffer[6] << 8) | buffer[7]);
		return ((ulong)part1 << 32) | part2;
	}

	public unsafe static void EncodeUInt16(uint value, byte[] buffer, int offset)
	{
		fixed (byte* bufferPtr = buffer)
		{
			EncodeUInt16(value, bufferPtr, offset);
		}
	}

	public unsafe static void EncodeUInt16(uint value, byte* buffer, int offset)
	{
		byte* ptr = buffer + offset;
		*ptr = (byte)(value >> 8);
		ptr[1] = (byte)(value & 0xFFu);
	}

	public unsafe static void EncodeUInt32(uint value, byte[] buffer, int offset)
	{
		fixed (byte* bufferPtr = buffer)
		{
			EncodeUInt32(value, bufferPtr, offset);
		}
	}

	public unsafe static void EncodeUInt32(uint value, byte* buffer, int offset)
	{
		byte* ptr = buffer + offset;
		*ptr = (byte)(value >> 24);
		ptr[1] = (byte)(value >> 16);
		ptr[2] = (byte)(value >> 8);
		ptr[3] = (byte)(value & 0xFFu);
	}

	public unsafe static void EncodeUInt64(ulong value, byte[] buffer, int offset)
	{
		fixed (byte* bufferPtr = buffer)
		{
			EncodeUInt64(value, bufferPtr, offset);
		}
	}

	public unsafe static void EncodeUInt64(ulong value, byte* buffer, int offset)
	{
		byte* ptr = buffer + offset;
		*ptr = (byte)(value >> 56);
		ptr[1] = (byte)(value >> 48);
		ptr[2] = (byte)(value >> 40);
		ptr[3] = (byte)(value >> 32);
		ptr[4] = (byte)(value >> 24);
		ptr[5] = (byte)(value >> 16);
		ptr[6] = (byte)(value >> 8);
		ptr[7] = (byte)(value & 0xFF);
	}

	public static byte[] EncodeKey(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return null;
		}
		return Encoding.UTF8.GetBytes(key);
	}

	public static string DecodeKey(byte[] data)
	{
		if (data == null || data.Length == 0)
		{
			return null;
		}
		return Encoding.UTF8.GetString(data);
	}

	public static string DecodeKey(byte[] data, int index, int count)
	{
		if (data == null || data.Length == 0 || count == 0)
		{
			return null;
		}
		return Encoding.UTF8.GetString(data, index, count);
	}
}
