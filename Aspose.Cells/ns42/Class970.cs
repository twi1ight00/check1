namespace ns42;

internal class Class970
{
	private Class969 class969_0;

	internal Class970(Class969 class969_1)
	{
		class969_0 = class969_1;
	}

	internal int[] method_0(uint uint_0, uint uint_1)
	{
		int[] array = new int[class969_0.method_6().Length];
		array[0] = (int)(uint_0 + uint_1);
		if (class969_0.method_6().Length > 0 && class969_0.method_6().CanRead)
		{
			int num = (int)class969_0.method_6().Length / 2 + 1;
			byte[] array2 = class969_0.method_6().ToArray();
			for (int i = 0; i < num; i++)
			{
				if (array2[i] != (byte)class969_0.method_7().method_5()[i])
				{
					Class971.smethod_2(150);
				}
				array[i] = array2[i];
			}
			Class971.smethod_5(bool_1: false);
		}
		return array;
	}
}
