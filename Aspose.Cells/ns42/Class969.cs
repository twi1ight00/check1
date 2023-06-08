using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ns42;

internal class Class969
{
	private MemoryStream memoryStream_0 = new MemoryStream();

	private byte byte_0;

	private byte byte_1 = byte.MaxValue;

	private byte[] byte_2;

	private int int_0;

	private MemoryStream memoryStream_1 = new MemoryStream();

	private Class968 class968_0;

	private Class968 class968_1;

	internal Class969(Class968 class968_2, byte[] byte_3, bool bool_0, bool bool_1)
	{
		if (bool_0 != bool_1)
		{
			byte_0 = byte_3[0];
			byte_1 = byte_3[1];
		}
		memoryStream_0.Write(byte_3, 0, byte_3.Length);
		if (method_0(byte_3))
		{
			int_0 = 10;
		}
		if (!class968_2.method_3())
		{
			class968_2.method_1(0);
		}
		class968_0 = class968_2;
	}

	internal bool method_0(byte[] byte_3)
	{
		byte_2 = new byte[byte_3.Length];
		for (int i = 0; i < byte_3.Length; i++)
		{
			byte_2[i] = (byte)(byte_3[i] & 0x80u);
			byte_2[i] |= 2;
		}
		return (byte_2[0] & 8) == 8;
	}

	internal bool method_1(byte[] byte_3, string string_0)
	{
		byte_3 = Encoding.Unicode.GetBytes(string_0);
		memoryStream_1.Write(byte_3, 0, byte_3.Length);
		method_5();
		if (memoryStream_1.Length < 16)
		{
			return true;
		}
		return false;
	}

	internal Class968 method_2(int[] int_1, Class968 class968_2)
	{
		class968_1 = class968_2;
		return class968_0;
	}

	internal void method_3(bool bool_0)
	{
		if (bool_0)
		{
			byte_0 = 0;
		}
		if (memoryStream_0.Length <= 0)
		{
			return;
		}
		int num = (int)memoryStream_0.Length / 2 + 1;
		byte[] array = memoryStream_0.ToArray();
		if (Class971.smethod_3() == 255)
		{
			Class971.smethod_4(128);
		}
		int num2 = array.Length - 1;
		for (int i = 0; i < num; i++)
		{
			if (array[num2] == byte.MaxValue)
			{
				int_0++;
			}
			if (array[num2] != (byte)class968_1.method_5()[num2])
			{
				Class971.smethod_2(128);
			}
			num2--;
		}
	}

	internal void method_4(string string_0, bool bool_0)
	{
		Class970 @class = new Class970(this);
		int[] array = @class.method_0(5u, 5u);
		if (array.Length >= 10)
		{
			byte_1 = (byte)array[9];
		}
	}

	private void method_5()
	{
		if (int_0 != 10)
		{
			int_0 += 5;
		}
		byte_0--;
	}

	[SpecialName]
	internal MemoryStream method_6()
	{
		return memoryStream_0;
	}

	[SpecialName]
	internal Class968 method_7()
	{
		return class968_1;
	}
}
