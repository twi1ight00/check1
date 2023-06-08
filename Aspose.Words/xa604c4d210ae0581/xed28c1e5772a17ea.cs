using System;
using System.IO;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class xed28c1e5772a17ea
{
	private const int x5bd0c5c94b91162e = 1900;

	internal static DateTime x9a175459d1b055a7(int xe80eb5064bf66ae1)
	{
		if (xe80eb5064bf66ae1 == 0)
		{
			return DateTime.MinValue;
		}
		int xd088075e67f6ea = xe80eb5064bf66ae1 & 0x3F;
		int xcc7a3b596222b08a = (xe80eb5064bf66ae1 & 0x7C0) >> 6;
		int x36ccf2254f62ef4e = (xe80eb5064bf66ae1 & 0xF800) >> 11;
		int xea415cd5a0d = (xe80eb5064bf66ae1 & 0xF0000) >> 16;
		int x47418672747a = ((xe80eb5064bf66ae1 & 0x1FF00000) >> 20) + 1900;
		return x7546e38fbb25d738.xfde53ea35dfda4e6(x47418672747a, xea415cd5a0d, x36ccf2254f62ef4e, xcc7a3b596222b08a, xd088075e67f6ea, 0, 0);
	}

	internal static int x7c734cfcbb14646a(DateTime xb21f13a9707ad954)
	{
		if (xb21f13a9707ad954.Year < 1900)
		{
			return 0;
		}
		int num = 0;
		num |= xb21f13a9707ad954.Minute;
		num |= xb21f13a9707ad954.Hour << 6;
		num |= xb21f13a9707ad954.Day << 11;
		num |= xb21f13a9707ad954.Month << 16;
		num |= xb21f13a9707ad954.Year - 1900 << 20;
		return num | ((int)xb21f13a9707ad954.DayOfWeek << 29);
	}

	internal static DateTime x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75)
	{
		return x9a175459d1b055a7(xe134235b3526fa75.ReadInt32());
	}

	internal static void x6210059f049f0d48(DateTime xb21f13a9707ad954, BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x7c734cfcbb14646a(xb21f13a9707ad954));
	}

	internal static void xb7bb7be409813705(DateTime x49319ae48a34a19f, BinaryWriter xbdfb620b7167944b)
	{
		if (x49319ae48a34a19f == DateTime.MinValue)
		{
			x6210059f049f0d48(DateTime.MinValue, xbdfb620b7167944b);
		}
		else
		{
			x6210059f049f0d48(x49319ae48a34a19f.ToLocalTime(), xbdfb620b7167944b);
		}
	}
}
