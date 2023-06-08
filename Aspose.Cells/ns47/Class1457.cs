using ns18;

namespace ns47;

internal class Class1457
{
	internal Struct91[] struct91_0;

	internal short[] short_0;

	internal Class1457(Class1393 class1393_0, int int_0, int int_1)
	{
		struct91_0 = new Struct91[int_0];
		for (int i = 0; i < struct91_0.Length; i++)
		{
			struct91_0[i].ushort_0 = class1393_0.method_4();
			struct91_0[i].short_0 = class1393_0.method_3();
		}
		int num = int_1 - int_0;
		short_0 = new short[num];
		for (int j = 0; j < short_0.Length; j++)
		{
			short_0[j] = class1393_0.method_3();
		}
	}

	internal Struct91 method_0(int int_0)
	{
		if (int_0 < struct91_0.Length)
		{
			return struct91_0[int_0];
		}
		Struct91 @struct = struct91_0[struct91_0.Length - 1];
		if (int_0 - struct91_0.Length < short_0.Length)
		{
			short short_ = short_0[int_0 - struct91_0.Length];
			return new Struct91(@struct.ushort_0, short_);
		}
		return new Struct91(@struct.ushort_0, 0);
	}
}
