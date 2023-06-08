using System.Runtime.CompilerServices;
using ns18;

namespace ns47;

internal class Class1073
{
	private readonly Class1393 class1393_0;

	internal Class1073(Class1393 class1393_1)
	{
		class1393_0 = class1393_1;
	}

	internal short method_0()
	{
		return class1393_0.ReadByte();
	}

	internal ushort method_1()
	{
		return class1393_0.method_4();
	}

	internal short method_2()
	{
		return class1393_0.ReadByte();
	}

	internal int[] method_3(short short_0, int int_0)
	{
		int[] array = new int[int_0];
		byte[] array2 = class1393_0.method_5(short_0 * int_0);
		for (int i = 0; i < int_0; i++)
		{
			for (int j = 0; j < short_0; j++)
			{
				array[i] |= array2[i * short_0 + j];
				if (short_0 - j - 1 > 0)
				{
					array[i] <<= 8;
				}
			}
		}
		return array;
	}

	[SpecialName]
	internal Class1393 method_4()
	{
		return class1393_0;
	}

	internal Class1072 method_5()
	{
		return new Class1072(this);
	}
}
