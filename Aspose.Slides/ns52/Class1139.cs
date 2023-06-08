using System.IO;
using System.Text;

namespace ns52;

internal class Class1139
{
	private MemoryStream memoryStream_0 = new MemoryStream();

	private byte byte_0;

	private byte byte_1 = byte.MaxValue;

	private byte[] byte_2;

	private int int_0;

	private MemoryStream memoryStream_1 = new MemoryStream();

	private Class1138 class1138_0;

	private Class1138 class1138_1;

	internal MemoryStream Buffer2Stream => memoryStream_0;

	internal byte DummyProperty1 => byte_0;

	internal byte DummyProperty2 => byte_1;

	internal MemoryStream DummyField5 => memoryStream_1;

	internal Class1138 DummyField6 => class1138_0;

	internal Class1138 Comparator1 => class1138_1;

	internal Class1139(Class1138 dummyParam1, byte[] buffer2, bool dummyParam2, bool dummyParam3)
	{
		if (dummyParam2 != dummyParam3)
		{
			byte_0 = buffer2[0];
			byte_1 = buffer2[1];
		}
		memoryStream_0.Write(buffer2, 0, buffer2.Length);
		if (method_0(buffer2))
		{
			int_0 = 10;
		}
		if (!dummyParam1.DummyField1)
		{
			dummyParam1.method_1(0);
		}
		class1138_0 = dummyParam1;
	}

	internal bool method_0(byte[] dummyParam1)
	{
		byte_2 = new byte[dummyParam1.Length];
		for (int i = 0; i < dummyParam1.Length; i++)
		{
			byte_2[i] = (byte)(dummyParam1[i] & 0x80u);
			byte_2[i] |= 2;
		}
		return (byte_2[0] & 8) == 8;
	}

	internal bool method_1(byte[] dummyParam1, string dummyParam2)
	{
		dummyParam1 = Encoding.Unicode.GetBytes(dummyParam2);
		memoryStream_1.Write(dummyParam1, 0, dummyParam1.Length);
		method_5();
		if (memoryStream_1.Length < 16L)
		{
			return true;
		}
		return false;
	}

	internal Class1138 method_2(int[] dummyParam1, Class1138 comparator1)
	{
		class1138_1 = comparator1;
		return class1138_0;
	}

	internal void method_3(bool dummyParam1)
	{
		if (dummyParam1)
		{
			byte_0 = 0;
		}
		if (memoryStream_0.Length <= 0L)
		{
			return;
		}
		int num = (int)memoryStream_0.Length / 2 + 1;
		byte[] array = memoryStream_0.ToArray();
		if (Class1141.MethodCalledFlag1 == 255)
		{
			Class1141.MethodCalledFlag1 = 128;
		}
		int num2 = array.Length - 1;
		for (int i = 0; i < num; i++)
		{
			if (array[num2] == byte.MaxValue)
			{
				int_0++;
			}
			if (array[num2] != (byte)class1138_1.Buffer1Int[num2])
			{
				Class1141.SignatureInvalidFlag = 128;
			}
			num2--;
		}
	}

	internal void method_4(string dummyParam1, bool isDummy)
	{
		Class1140 @class = new Class1140(this);
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
}
