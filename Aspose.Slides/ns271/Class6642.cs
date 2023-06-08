using ns218;

namespace ns271;

internal class Class6642
{
	private readonly Class5950 class5950_0;

	internal Class5950 BaseReader => class5950_0;

	internal Class6642(Class5950 reader)
	{
		class5950_0 = reader;
	}

	internal short method_0()
	{
		return class5950_0.ReadByte();
	}

	internal ushort method_1()
	{
		return class5950_0.method_3();
	}

	internal short method_2()
	{
		return class5950_0.ReadByte();
	}

	internal int[] method_3(short offSize, int count)
	{
		int[] array = new int[count];
		byte[] array2 = class5950_0.method_8(offSize * count);
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < offSize; j++)
			{
				array[i] |= array2[i * offSize + j];
				if (offSize - j - 1 > 0)
				{
					array[i] <<= 8;
				}
			}
		}
		return array;
	}

	internal Class6641 method_4()
	{
		return new Class6641(this);
	}
}
