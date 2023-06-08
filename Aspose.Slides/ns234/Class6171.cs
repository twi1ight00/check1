using System;
using System.IO;
using ns218;
using ns276;

namespace ns234;

internal static class Class6171
{
	public static byte[] smethod_0(byte[] srcBytes, int uncompressedLength, Enum794 method)
	{
		using MemoryStream srcStream = new MemoryStream(srcBytes);
		return smethod_1(srcStream, uncompressedLength, method);
	}

	public static byte[] smethod_1(Stream srcStream, int uncompressedLength, Enum794 method)
	{
		if (uncompressedLength == 0)
		{
			uncompressedLength = (int)srcStream.Length;
		}
		MemoryStream memoryStream = new MemoryStream(uncompressedLength);
		using (Stream srcStream2 = smethod_6(method, srcStream, Enum916.const_1))
		{
			Class5964.smethod_9(srcStream2, memoryStream);
		}
		return memoryStream.ToArray();
	}

	public static byte[] smethod_2(byte[] srcBytes, Enum794 method)
	{
		using MemoryStream srcStream = new MemoryStream(srcBytes);
		return smethod_3(srcStream, method);
	}

	public static byte[] smethod_3(Stream srcStream, Enum794 method)
	{
		using MemoryStream memoryStream = new MemoryStream();
		smethod_4(srcStream, memoryStream, method);
		return memoryStream.ToArray();
	}

	public static int smethod_4(Stream srcStream, MemoryStream dstStream, Enum794 method)
	{
		int num = (int)dstStream.Position;
		using (Stream dstStream2 = smethod_6(method, dstStream, Enum916.const_0))
		{
			Class5964.smethod_9(srcStream, dstStream2);
		}
		return (int)dstStream.Position - num;
	}

	public static int smethod_5(byte[] bytes, int offset, int count, Stream dstStream, Enum794 method)
	{
		int num = (int)dstStream.Position;
		using (Stream stream = smethod_6(method, dstStream, Enum916.const_0))
		{
			stream.Write(bytes, offset, count);
		}
		return (int)dstStream.Position - num;
	}

	private static Stream smethod_6(Enum794 method, Stream stream, Enum916 compressionMode)
	{
		return method switch
		{
			Enum794.const_0 => new Stream8(stream, compressionMode, leaveOpen: true), 
			Enum794.const_1 => new Stream12(stream, compressionMode, leaveOpen: true), 
			_ => throw new InvalidOperationException("Unknown compression method specified."), 
		};
	}
}
