using System;

namespace ns68;

internal sealed class Class3018
{
	private Struct155[] struct155_0;

	private int int_0;

	private int int_1;

	internal int Count => int_1;

	internal Struct155 First => struct155_0[int_0];

	internal Class3018(int initialSize)
	{
		struct155_0 = new Struct155[initialSize];
		int_0 = 0;
		int_1 = 0;
	}

	internal void method_0(ref Struct155 r)
	{
		if (int_1 + int_0 == struct155_0.Length)
		{
			Struct155[] destinationArray = new Struct155[2 * struct155_0.Length];
			Array.Copy(struct155_0, int_0, destinationArray, 0, int_1);
			struct155_0 = destinationArray;
			int_0 = 0;
		}
		ref Struct155 reference = ref struct155_0[int_0 + int_1++];
		reference = r;
	}

	internal Struct155 method_1()
	{
		Struct155 result = default(Struct155);
		if (int_1 > 0)
		{
			result = struct155_0[int_0];
			struct155_0[int_0] = default(Struct155);
			int_0++;
			int_1--;
		}
		return result;
	}
}
