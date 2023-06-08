using System;

namespace x5f3520a4b31ea90f;

internal class x66cdafe77e7aa42b
{
	public static Guid x8341ba999ffebb91(byte[] xf9a0d04800d70471)
	{
		return x8341ba999ffebb91(xf9a0d04800d70471, 0, xf9a0d04800d70471.Length);
	}

	public static Guid x8341ba999ffebb91(byte[] xf9a0d04800d70471, int x374ea4fe62468d0f, int x961016a387451f05)
	{
		x283d2b8b16fdc457 x283d2b8b16fdc458 = new x283d2b8b16fdc457();
		return new Guid(x283d2b8b16fdc458.xc6df3c48d7ea1182(xf9a0d04800d70471, x374ea4fe62468d0f, x961016a387451f05));
	}

	public static int x7c2b31520f6497cc(string xf6987a1745781d6f)
	{
		int num = 352654597;
		int num2 = num;
		int num3 = 0;
		for (int num4 = xf6987a1745781d6f.Length; num4 > 0; num4 -= 4)
		{
			int num5 = xf6987a1745781d6f[num3];
			int num6 = ((num4 > 1) ? xf6987a1745781d6f[num3 + 1] : '\0');
			int num7 = ((num4 > 2) ? xf6987a1745781d6f[num3 + 2] : '\0');
			int num8 = ((num4 > 3) ? xf6987a1745781d6f[num3 + 3] : '\0');
			int num9 = num6;
			num9 <<= 16;
			num9 += num5;
			int num10 = num8;
			num10 <<= 16;
			num10 += num7;
			num = ((num << 5) + num + (num >> 27)) ^ num9;
			if (num4 <= 2)
			{
				break;
			}
			num2 = ((num2 << 5) + num2 + (num2 >> 27)) ^ num10;
			num3 += 4;
		}
		return num + num2 * 1566083941;
	}
}
