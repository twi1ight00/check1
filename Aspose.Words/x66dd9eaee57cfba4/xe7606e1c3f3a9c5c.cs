using System;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class xe7606e1c3f3a9c5c
{
	private const short x2cb4d3ceee75b737 = 64;

	private const short x1b17ca724f8a4fe8 = 65;

	private const short x80b71f1e907a13c3 = 176;

	private const short x78f7940e0118b971 = 183;

	private const short xfb2ddf75629c7a9d = 184;

	private const short x0eba06ebab783ed3 = 191;

	internal static int[] x98fc02dd6e5c5fc9(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		xd8cce4761dc846ee xd8cce4761dc846ee = new xd8cce4761dc846ee();
		while (true)
		{
			short num = xe134235b3526fa75.x672ed37ee25c078c();
			bool flag;
			int num2;
			switch (num)
			{
			case 64:
				flag = false;
				num2 = xe134235b3526fa75.x672ed37ee25c078c();
				break;
			case 65:
				flag = true;
				num2 = xe134235b3526fa75.x672ed37ee25c078c();
				break;
			case 176:
			case 177:
			case 178:
			case 179:
			case 180:
			case 181:
			case 182:
			case 183:
				flag = false;
				num2 = num - 176 + 1;
				break;
			default:
				if (num >= 184 && num <= 191)
				{
					flag = true;
					num2 = num - 184 + 1;
					break;
				}
				xe134235b3526fa75.x9e418ad9a56d1cf5.Position--;
				return xd8cce4761dc846ee.x543681a74a4a8026();
			}
			for (int i = 0; i < num2; i++)
			{
				xd8cce4761dc846ee.xd6b6ed77479ef68c(flag ? xe134235b3526fa75.x2e6b89ad8001e18f() : xe134235b3526fa75.x672ed37ee25c078c());
			}
		}
	}

	public static void x6edb0a9b31af09ae(x73087173962e3778 xbdfb620b7167944b, short[] x6951f18dfa6468bf)
	{
		int num = 0;
		while (num < x6951f18dfa6468bf.Length)
		{
			int num2 = Math.Min(255, x6951f18dfa6468bf.Length - num);
			x91408a14719d5d7e(xbdfb620b7167944b, num2);
			for (int i = 0; i < num2; i++)
			{
				xbdfb620b7167944b.xb0c682b9901a2443(x6951f18dfa6468bf[num++]);
			}
		}
	}

	private static void x91408a14719d5d7e(x73087173962e3778 xbdfb620b7167944b, int x57e9faf3ffdc07cc)
	{
		xbdfb620b7167944b.xc351d479ff7ee789(65);
		xbdfb620b7167944b.xc351d479ff7ee789((byte)x57e9faf3ffdc07cc);
	}
}
