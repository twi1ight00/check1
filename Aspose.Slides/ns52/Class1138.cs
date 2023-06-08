using System.IO;

namespace ns52;

internal class Class1138
{
	private bool bool_0;

	private byte[] byte_0;

	private int[] int_0;

	internal bool DummyField1
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	internal byte[] DummyField2 => byte_0;

	internal int[] Buffer1Int
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal Class1138(byte[] dummyParam)
	{
		for (int i = 0; i < dummyParam.Length; i++)
		{
			if (dummyParam[i] > 128 && dummyParam[i] < 192)
			{
				bool_0 = true;
				break;
			}
		}
		byte_0 = dummyParam;
	}

	internal void method_0(int dummyParam1, int dummyParam2, bool dummyParam3)
	{
		if (byte_0.Length >= 16)
		{
			if (byte_0[3] == dummyParam1)
			{
				byte_0[15] = (byte)method_1(dummyParam2);
			}
			for (int i = 0; i < 10; i++)
			{
				byte_0[i] = (byte)(dummyParam3 ? 3 : 54);
			}
		}
	}

	internal int method_1(int dummyParam)
	{
		return dummyParam * dummyParam + 10;
	}

	internal bool method_2(MemoryStream dummyParam1, byte[] buffer1, int dummyParam2)
	{
		if (dummyParam2 > 100)
		{
			bool_0 = !bool_0;
		}
		if (dummyParam1 != null && dummyParam1.CanWrite)
		{
			dummyParam1.Write(buffer1, 0, buffer1.Length);
		}
		int_0 = new int[buffer1.Length];
		for (int i = 0; i < buffer1.Length; i++)
		{
			int_0[i] = buffer1[i];
		}
		if (Class1141.MethodCalledFlag1 == 48)
		{
			Class1141.MethodCalledFlag1 = 255;
		}
		return buffer1.Length == 65535;
	}
}
