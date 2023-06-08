using System.IO;
using System.Runtime.CompilerServices;

namespace ns42;

internal class Class968
{
	private bool bool_0;

	private byte[] byte_0;

	private int[] int_0;

	internal Class968(byte[] byte_1)
	{
		for (int i = 0; i < byte_1.Length; i++)
		{
			if (byte_1[i] > 128 && byte_1[i] < 192)
			{
				bool_0 = true;
				break;
			}
		}
		byte_0 = byte_1;
	}

	internal void method_0(int int_1, int int_2, bool bool_1)
	{
		if (byte_0.Length >= 16)
		{
			if (byte_0[3] == int_1)
			{
				byte_0[15] = (byte)method_1(int_2);
			}
			for (int i = 0; i < 10; i++)
			{
				byte_0[i] = (byte)(bool_1 ? 3 : 54);
			}
		}
	}

	internal int method_1(int int_1)
	{
		return int_1 * int_1 + 10;
	}

	internal bool method_2(MemoryStream memoryStream_0, byte[] byte_1, int int_1)
	{
		if (int_1 > 100)
		{
			bool_0 = !bool_0;
		}
		if (memoryStream_0 != null && memoryStream_0.CanWrite)
		{
			memoryStream_0.Write(byte_1, 0, byte_1.Length);
		}
		int_0 = new int[byte_1.Length];
		for (int i = 0; i < byte_1.Length; i++)
		{
			int_0[i] = byte_1[i];
		}
		if (Class971.smethod_3() == 48)
		{
			Class971.smethod_4(255);
		}
		return byte_1.Length == 65535;
	}

	[SpecialName]
	internal bool method_3()
	{
		return bool_0;
	}

	[SpecialName]
	internal void method_4(bool bool_1)
	{
		bool_0 = bool_1;
	}

	[SpecialName]
	internal int[] method_5()
	{
		return int_0;
	}
}
