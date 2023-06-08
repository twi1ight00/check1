using System;
using System.Globalization;
using Aspose;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class x27cd5f9641d9eb15
{
	private x27cd5f9641d9eb15()
	{
	}

	public static bool Equals(string a, int indexA, string b, int indexB, int length)
	{
		return string.Compare(a, indexA, b, indexB, length) == 0;
	}

	public static bool x90637a473b1ceaaa(string x19218ffab70283ef, string xe7ebe10fa44d8d49)
	{
		return string.Compare(x19218ffab70283ef, xe7ebe10fa44d8d49, ignoreCase: true) == 0;
	}

	public static bool xa62d1d5c5f21cd20(string x19218ffab70283ef, string xe7ebe10fa44d8d49)
	{
		return xa62d1d5c5f21cd20(x19218ffab70283ef, xe7ebe10fa44d8d49, int.MaxValue);
	}

	public static bool x9c01925b84cc0a1b(string x337e217cb3ba0627, string x05bcae9c376a7a50)
	{
		return xa62d1d5c5f21cd20(x337e217cb3ba0627, x05bcae9c376a7a50, x05bcae9c376a7a50.Length);
	}

	private static bool xa62d1d5c5f21cd20(string x2aa38180328c2cfd, string xb96c6cf0d2cb5c05, int x961016a387451f05)
	{
		if (object.ReferenceEquals(x2aa38180328c2cfd, xb96c6cf0d2cb5c05))
		{
			return true;
		}
		if (x2aa38180328c2cfd == null || xb96c6cf0d2cb5c05 == null)
		{
			return false;
		}
		int num = Math.Min(x2aa38180328c2cfd.Length, x961016a387451f05);
		int num2 = Math.Min(xb96c6cf0d2cb5c05.Length, x961016a387451f05);
		if (num != num2)
		{
			return false;
		}
		int num3 = 0;
		int num4 = 0;
		while (num3 < num && num4 < num2)
		{
			int num5 = x2aa38180328c2cfd[num3];
			int num6 = xb96c6cf0d2cb5c05[num4];
			if ((num5 | num6) <= 127)
			{
				if (num5 >= 97 && num5 <= 122)
				{
					num5 ^= 0x20;
				}
				if (num6 >= 97 && num6 <= 122)
				{
					num6 ^= 0x20;
				}
				if (num5 != num6)
				{
					return false;
				}
			}
			else if (num5 != num6)
			{
				num5 = xebb9db61691ea142.x15d62484053869de((char)num5);
				num6 = xebb9db61691ea142.x15d62484053869de((char)num6);
				if (num5 != num6)
				{
					num5 = xebb9db61691ea142.x169b0f985985948a((char)num5);
					num6 = xebb9db61691ea142.x169b0f985985948a((char)num6);
					if (num5 != num6)
					{
						return false;
					}
				}
			}
			num3++;
			num4++;
		}
		return true;
	}

	public static int x33ea5871b3bcc794(string x19218ffab70283ef, string xe7ebe10fa44d8d49)
	{
		CompareInfo compareInfo = CultureInfo.CurrentCulture.CompareInfo;
		return compareInfo.Compare(x19218ffab70283ef, xe7ebe10fa44d8d49, CompareOptions.StringSort);
	}

	public static string xe1d286321be5f9a0(string x27cc23924cff08a3, string xd1703770efecef1c, int xc0c4c459c6ccbd00)
	{
		if (x27cc23924cff08a3 == null)
		{
			throw new NullReferenceException("sourceString");
		}
		if (xd1703770efecef1c == null)
		{
			throw new NullReferenceException("stringToInsert");
		}
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 > x27cc23924cff08a3.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return x27cc23924cff08a3.Insert(xc0c4c459c6ccbd00, xd1703770efecef1c);
	}

	public static string x52b190e626f65140(string x27cc23924cff08a3, int xc0c4c459c6ccbd00, int x10f4d88af727adbc)
	{
		if (x27cc23924cff08a3 == null)
		{
			throw new NullReferenceException("sourceString");
		}
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 > x27cc23924cff08a3.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (x10f4d88af727adbc < 0 || xc0c4c459c6ccbd00 + x10f4d88af727adbc > x27cc23924cff08a3.Length)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		return x27cc23924cff08a3.Remove(xc0c4c459c6ccbd00, x10f4d88af727adbc);
	}
}
