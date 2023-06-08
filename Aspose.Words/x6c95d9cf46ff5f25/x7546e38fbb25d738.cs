using System;

namespace x6c95d9cf46ff5f25;

internal class x7546e38fbb25d738
{
	private const bool xae920e0c716e7e6a = false;

	private const long x50b8d4c0326bc0a4 = 504911232000000000L;

	private static readonly DateTime xa0d32262a521ee8b = new DateTime(2006, 1, 5, 19, 9, 1);

	private x7546e38fbb25d738()
	{
	}

	public static void x392c33ba8e976198()
	{
	}

	public static DateTime xfde53ea35dfda4e6(int x47418672747a4865, int xea415cd5a0d61607, int x36ccf2254f62ef4e, int xcc7a3b596222b08a, int xd088075e67f6ea91, int x7468108b15101a6d, int xe1cee3598b7b8c89)
	{
		try
		{
			return new DateTime(x47418672747a4865, xea415cd5a0d61607, x36ccf2254f62ef4e, xcc7a3b596222b08a, xd088075e67f6ea91, x7468108b15101a6d, xe1cee3598b7b8c89);
		}
		catch (Exception)
		{
			return DateTime.MinValue;
		}
	}

	public static DateTime xede8042111f14852(long x2208ef2cfa19b26b, string xae050273e3024171)
	{
		if (x2208ef2cfa19b26b < 0)
		{
			throw new ArgumentOutOfRangeException(xae050273e3024171);
		}
		long ticks = x2208ef2cfa19b26b + 504911232000000000L;
		return new DateTime(ticks, DateTimeKind.Utc);
	}

	public static long xb78c684ef88c5aa4(DateTime xbcea506a33cf9111, string xae050273e3024171)
	{
		long num = xbcea506a33cf9111.Ticks - 504911232000000000L;
		if (num < 0)
		{
			throw new ArgumentOutOfRangeException(xae050273e3024171);
		}
		return num;
	}

	public static DateTime xc044302ca1c0d3c7()
	{
		return DateTime.Now;
	}

	public static DateTime x7d1987e3dfb4c2fb(DateTime xb21f13a9707ad954)
	{
		return xb21f13a9707ad954.ToLocalTime();
	}
}
