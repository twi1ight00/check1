using System;

namespace ns130;

internal class Class4597
{
	public static byte[] smethod_0(byte[] data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		Class4579 @class = new Class4579();
		return @class.method_0(data);
	}

	public static byte[] smethod_1(byte[] data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		Class4580 @class = new Class4580();
		return @class.method_0(data);
	}

	public static byte[] smethod_2(byte[] data, int maxCopyDistance)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		if (maxCopyDistance < 1)
		{
			throw new ArgumentException("Max copy distance must be at least 1", "maxCopyDistance");
		}
		Class4580 @class = new Class4580(maxCopyDistance);
		return @class.method_0(data);
	}
}
