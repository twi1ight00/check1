using ns50;

namespace ns52;

internal class Class1137
{
	internal Class1128 class1128_0;

	internal Class1128 class1128_1;

	internal Class1128 Modulus => class1128_0;

	internal Class1128 Exponent => class1128_1;

	internal Class1137(byte[] modulusBytes, byte[] exponentBytes)
	{
		class1128_0 = new Class1128(modulusBytes);
		class1128_1 = new Class1128(exponentBytes);
	}

	internal byte[] Encrypt(byte[] inputBytes)
	{
		Class1128 @class = new Class1128(inputBytes);
		Class1128 class2 = @class.method_11(class1128_1, class1128_0);
		byte[] result = class2.method_7();
		@class.Clear();
		class2.Clear();
		return result;
	}
}
