namespace ns167;

internal class Class4843
{
	private int int_0;

	private bool[] bool_0;

	private Class4783 class4783_0;

	internal Class4783 Source => class4783_0;

	internal Class4843(Class4783 source)
	{
		class4783_0 = source;
		int_0 = source.PageElementCount;
		bool_0 = new bool[int_0];
		for (int i = 0; i < int_0; i++)
		{
			bool_0[i] = false;
		}
	}

	internal bool method_0(int index)
	{
		method_2(index);
		return bool_0[index];
	}

	internal void method_1(int index)
	{
		method_2(index);
		bool_0[index] = true;
	}

	private void method_2(int index)
	{
	}
}
