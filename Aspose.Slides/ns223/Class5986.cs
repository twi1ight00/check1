namespace ns223;

internal class Class5986
{
	internal Class5975 class5975_0;

	internal Class5975 class5975_1;

	public Class5975 Modulus => class5975_0;

	public Class5975 Exponent => class5975_1;

	public Class5986(byte[] modulusBytes, byte[] exponentBytes)
	{
		class5975_0 = new Class5975(modulusBytes);
		class5975_1 = new Class5975(exponentBytes);
	}

	public byte[] Encrypt(byte[] inputBytes)
	{
		Class5975 @class = new Class5975(inputBytes);
		Class5975 class2 = @class.method_11(class5975_1, class5975_0);
		byte[] result = class2.method_7();
		@class.Clear();
		class2.Clear();
		return result;
	}
}
