using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns59;

internal class Class1725
{
	protected Stream stream_0;

	protected byte[] byte_0;

	internal Class1725(Stream stream_1)
	{
		stream_0 = stream_1;
	}

	[SpecialName]
	internal Stream method_0()
	{
		return stream_0;
	}

	internal void method_1(byte[] byte_1, int int_0)
	{
		stream_0.Write(byte_1, 0, int_0);
	}

	internal void method_2(byte[] byte_1, int int_0, int int_1)
	{
		stream_0.Write(byte_1, int_0, int_1);
	}

	internal void method_3(byte[] byte_1)
	{
		stream_0.Write(byte_1, 0, byte_1.Length);
	}

	internal void WriteByte(byte byte_1)
	{
		stream_0.WriteByte(byte_1);
	}

	internal void method_4(uint uint_0)
	{
		byte_0 = BitConverter.GetBytes(uint_0);
		method_3(byte_0);
	}

	internal void method_5(int int_0)
	{
		byte_0 = BitConverter.GetBytes(int_0);
		method_3(byte_0);
	}

	internal void method_6(ushort ushort_0)
	{
		byte_0 = BitConverter.GetBytes(ushort_0);
		method_3(byte_0);
	}

	internal void method_7(short short_0)
	{
		byte_0 = BitConverter.GetBytes(short_0);
		method_3(byte_0);
	}

	internal void method_8(int int_0)
	{
		byte_0 = BitConverter.GetBytes((short)int_0);
		method_3(byte_0);
	}

	internal void method_9(double double_0)
	{
		byte_0 = BitConverter.GetBytes(double_0);
		method_3(byte_0);
	}

	internal long method_10()
	{
		return stream_0.Position;
	}

	internal void Seek(long long_0)
	{
		stream_0.Seek(long_0, SeekOrigin.Begin);
	}
}
