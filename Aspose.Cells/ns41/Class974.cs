using System.Runtime.CompilerServices;

namespace ns41;

internal class Class974
{
	internal Class963 class963_0;

	internal Class963 class963_1;

	public Class974(byte[] byte_0, byte[] byte_1)
	{
		class963_0 = new Class963(byte_0);
		class963_1 = new Class963(byte_1);
	}

	public byte[] method_0(byte[] byte_0)
	{
		Class963 @class = new Class963(byte_0);
		Class963 class2 = @class.method_4(class963_1, class963_0);
		byte[] result = class2.method_2();
		@class.Clear();
		class2.Clear();
		return result;
	}

	[SpecialName]
	public Class963 method_1()
	{
		return class963_0;
	}
}
