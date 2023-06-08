using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns59;

internal class Class1723
{
	internal MemoryStream memoryStream_0;

	private bool bool_0;

	internal long Position => memoryStream_0.Position;

	[SpecialName]
	internal bool method_0()
	{
		return bool_0;
	}

	internal Class1723(MemoryStream memoryStream_1)
	{
		memoryStream_0 = memoryStream_1;
	}

	internal int method_1(byte[] byte_0)
	{
		if (bool_0)
		{
			throw new Exception("End of stream reached.");
		}
		int num = memoryStream_0.Read(byte_0, 0, byte_0.Length);
		if (num < byte_0.Length)
		{
			bool_0 = true;
		}
		return num;
	}

	internal ushort method_2(byte[] byte_0)
	{
		if (bool_0)
		{
			throw new Exception("End of stream reached.");
		}
		int num = memoryStream_0.Read(byte_0, 0, 2);
		if (num < 2)
		{
			bool_0 = true;
		}
		return BitConverter.ToUInt16(byte_0, 0);
	}

	internal void Seek(int int_0)
	{
		memoryStream_0.Seek(int_0, SeekOrigin.Begin);
	}

	internal void method_3(int int_0)
	{
		memoryStream_0.Seek(int_0, SeekOrigin.Current);
	}
}
