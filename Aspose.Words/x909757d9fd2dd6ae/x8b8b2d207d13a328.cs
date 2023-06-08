using System;
using System.IO;
using x4b4f8b01ec4cb4b2;
using x6c95d9cf46ff5f25;

namespace x909757d9fd2dd6ae;

internal class x8b8b2d207d13a328
{
	private const int xe78f4155e7063b10 = 32;

	private x8b8b2d207d13a328()
	{
	}

	internal static string x91eaf487186d6fb0(x393d198b88cf5ed5 x18c8cfcf0ea5f3c7, Stream xf823f0edaa261f3b)
	{
		byte[] x6b73aa01aa019d3a = x18c8cfcf0ea5f3c7.x6b73aa01aa019d3a;
		if (x6b73aa01aa019d3a == null)
		{
			throw new ArgumentNullException("fontData");
		}
		byte[] array = new byte[Math.Min(x6b73aa01aa019d3a.Length, 32)];
		Array.Copy(x6b73aa01aa019d3a, array, array.Length);
		Guid xb51cd75f17ace1ec = xa19c1513d8b80a8b.xdf7c5a607de91fb9(x6b73aa01aa019d3a);
		xc150d3a8b086bb4d(array, xb51cd75f17ace1ec);
		xf823f0edaa261f3b.Write(array, 0, array.Length);
		xf823f0edaa261f3b.Write(x6b73aa01aa019d3a, array.Length, x18c8cfcf0ea5f3c7.x6b73aa01aa019d3a.Length - array.Length);
		return xb51cd75f17ace1ec.ToString("B").ToUpper();
	}

	internal static void xd793f79da39af8af(byte[] x0db5e88527e18b81, string x6c3036a79ee5e35b)
	{
		if (x0db5e88527e18b81 == null)
		{
			throw new ArgumentNullException("fontData");
		}
		Guid xb51cd75f17ace1ec = new Guid(x6c3036a79ee5e35b);
		xc150d3a8b086bb4d(x0db5e88527e18b81, xb51cd75f17ace1ec);
	}

	private static void xc150d3a8b086bb4d(byte[] x0db5e88527e18b81, Guid xb51cd75f17ace1ec)
	{
		int num = 0;
		byte[] array = x0d299f323d241756.x90000f01e9f4b628(xb51cd75f17ace1ec);
		for (int i = 0; i < 2; i++)
		{
			int num2 = array.Length - 1;
			while (num2 >= 0 && num < x0db5e88527e18b81.Length)
			{
				x0db5e88527e18b81[num++] ^= array[num2];
				num2--;
			}
		}
	}
}
