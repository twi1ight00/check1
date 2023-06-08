using ns18;

namespace ns47;

internal class Class1459
{
	internal string string_0;

	internal int int_0;

	internal int int_1;

	internal int int_2;

	internal Class1459(Class1393 class1393_0)
	{
		string_0 = new string(class1393_0.method_6(4));
		int_0 = class1393_0.method_1();
		int_1 = class1393_0.method_1();
		int_2 = class1393_0.method_1();
	}

	internal void Write(Class1394 class1394_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			class1394_0.WriteByte((byte)string_0[i]);
		}
		class1394_0.method_1(int_0);
		class1394_0.method_1(int_1);
		class1394_0.method_1(int_2);
	}

	internal static int smethod_0(byte[] byte_0, int int_3, int int_4)
	{
		int num = 0;
		int num2 = int_3;
		int num3 = int_4 / 4;
		int num4;
		int num5;
		int num6;
		int num7;
		for (int i = 0; i < num3; i++)
		{
			num4 = byte_0[num2++];
			num5 = byte_0[num2++];
			num6 = byte_0[num2++];
			num7 = byte_0[num2++];
			int num8 = num7 | (num6 << 8) | (num5 << 16) | (num4 << 24);
			num += num8;
		}
		num4 = ((num2 < int_4) ? byte_0[num2++] : 0);
		num5 = ((num2 < int_4) ? byte_0[num2++] : 0);
		num6 = ((num2 < int_4) ? byte_0[num2++] : 0);
		num7 = 0;
		int num9 = 0 | (num6 << 8) | (num5 << 16) | (num4 << 24);
		return num + num9;
	}
}
