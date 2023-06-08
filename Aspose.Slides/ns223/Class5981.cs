using System;

namespace ns223;

internal static class Class5981
{
	public static Guid smethod_0(byte[] bytes)
	{
		return smethod_1(bytes, 0, bytes.Length);
	}

	public static Guid smethod_1(byte[] bytes, int offset, int length)
	{
		Class5982 @class = new Class5982();
		return new Guid(@class.method_1(bytes, offset, length));
	}
}
