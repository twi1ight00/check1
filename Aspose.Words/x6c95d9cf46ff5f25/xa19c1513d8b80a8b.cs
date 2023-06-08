using System;
using x5f3520a4b31ea90f;

namespace x6c95d9cf46ff5f25;

internal class xa19c1513d8b80a8b
{
	private xa19c1513d8b80a8b()
	{
	}

	public static Guid xdf7c5a607de91fb9(params object[] x218802253ac0a4dd)
	{
		return Guid.NewGuid();
	}

	private static int x99c2a23deecf16f7(object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 is byte[])
		{
			byte[] array = (byte[])xbcea506a33cf9111;
			xbcea506a33cf9111 = xcd4bd3abd72ff2da.xd20e56ce95eb96ff(array, 0, Math.Min(256, array.Length));
		}
		if (xbcea506a33cf9111 is string)
		{
			return x66cdafe77e7aa42b.x7c2b31520f6497cc((string)xbcea506a33cf9111);
		}
		if (xbcea506a33cf9111 is int)
		{
			return (int)xbcea506a33cf9111;
		}
		if (xbcea506a33cf9111 is Enum)
		{
			return (int)xbcea506a33cf9111;
		}
		throw new NotImplementedException("Type of object is not supported.");
	}
}
