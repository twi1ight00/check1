namespace ns52;

internal class Class1140
{
	private Class1139 class1139_0;

	internal Class1139 Comparator2
	{
		get
		{
			return class1139_0;
		}
		set
		{
			class1139_0 = value;
		}
	}

	internal Class1140(Class1139 comparator2)
	{
		class1139_0 = comparator2;
	}

	internal int[] method_0(uint dummyParam1, uint dummyParam2)
	{
		int[] array = new int[class1139_0.Buffer2Stream.Length];
		array[0] = (int)(dummyParam1 + dummyParam2);
		if (class1139_0.Buffer2Stream.Length > 0L && class1139_0.Buffer2Stream.CanRead)
		{
			int num = (int)class1139_0.Buffer2Stream.Length / 2 + 1;
			byte[] array2 = class1139_0.Buffer2Stream.ToArray();
			for (int i = 0; i < num; i++)
			{
				if (array2[i] != (byte)class1139_0.Comparator1.Buffer1Int[i])
				{
					Class1141.SignatureInvalidFlag = 150;
				}
				array[i] = array2[i];
			}
			Class1141.MethodCalledFlag2 = false;
		}
		return array;
	}
}
