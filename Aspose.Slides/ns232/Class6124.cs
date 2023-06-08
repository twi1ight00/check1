using ns226;
using ns227;
using ns230;

namespace ns232;

internal class Class6124
{
	private static int int_0 = 8;

	private static int int_1 = 2;

	public Class6017 method_0(Class6020 sourceFont)
	{
		Class6032 @class = (Class6032)sourceFont.method_6(Class6116.int_26);
		Class6034 class2 = (Class6034)sourceFont.method_6(Class6116.int_4);
		Class6035 class3 = (Class6035)sourceFont.method_6(Class6116.int_5);
		Class6031 class4 = (Class6031)sourceFont.method_6(Class6116.int_2);
		int num = class4.method_18();
		int num2 = @class.method_13();
		int num3 = class3.method_13();
		Class6129 class5 = new Class6129();
		for (int i = 0; i < num2; i++)
		{
			int num4 = @class.method_15(i);
			for (int j = 0; j < num3; j++)
			{
				int num5 = ((64 * num4 * class2.method_17(j) + num / 2) / num + 32) / 64;
				int value = @class.method_17(i, j) - num5;
				class5.method_1(value);
			}
		}
		class5.Flush();
		byte[] array = class5.method_2();
		int length = array.Length + int_0 + int_1 * num2;
		Class6017 class6 = Class6017.smethod_1(length);
		class6.method_37(0, 0);
		class6.method_37(2, num2);
		class6.method_43(4, @class.method_14());
		for (int k = 0; k < num2; k++)
		{
			class6.WriteByte(int_0 + int_1 * k, (byte)@class.method_15(k));
			class6.WriteByte(int_0 + int_1 * k + 1, (byte)@class.method_16(k));
		}
		class6.method_35(int_0 + int_1 * num2, array);
		return class6;
	}
}
