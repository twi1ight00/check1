using System.Drawing;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using xf9a9481c3f63a419;

namespace x120d4bb5c80fb10c;

internal class x225ce39bf4d3057e
{
	private const int x508eb6d9f33a22d1 = -1;

	private float x42e5c99daad7b47e;

	private float xc870c20d40920a8c;

	internal static x1ae70714edec817d xa78bd34efc70ec90(byte[] x43e181e083db6cdf, RectangleF xda73fcb97c77d998)
	{
		if (xdd1b8f14cc8ba86d.x94d6c004900d4806(x43e181e083db6cdf))
		{
			return new x1ae70714edec817d(new x03d68de1c2f74051(xda73fcb97c77d998));
		}
		x225ce39bf4d3057e x225ce39bf4d3057e2 = new x225ce39bf4d3057e();
		x1ae70714edec817d x1ae70714edec817d2 = x225ce39bf4d3057e2.x86d515adc7a0a302(x43e181e083db6cdf);
		if (x1ae70714edec817d2.xe9e87df45862c20a == 0)
		{
			return new x1ae70714edec817d();
		}
		float num = x225ce39bf4d3057e2.x42e5c99daad7b47e;
		float num2 = x225ce39bf4d3057e2.xc870c20d40920a8c;
		if ((xda73fcb97c77d998.Width == num && xda73fcb97c77d998.Height == num2) || num == 0f || num2 == 0f)
		{
			return x1ae70714edec817d2;
		}
		if (xda73fcb97c77d998 != RectangleF.Empty)
		{
			x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
			x54366fa5f75a02f.x5152a5707921c783(xda73fcb97c77d998.Width / num, xda73fcb97c77d998.Height / num2);
			x54366fa5f75a02f.xce92de628aa023cf(xda73fcb97c77d998.X, xda73fcb97c77d998.Y);
			for (int i = 0; i < x1ae70714edec817d2.xe9e87df45862c20a; i++)
			{
				x1ae70714edec817d2.get_xe6d4b1b411ed94b5(i).x4fdf47a12306c1b7(x54366fa5f75a02f);
			}
		}
		return x1ae70714edec817d2;
	}

	private x1ae70714edec817d x86d515adc7a0a302(byte[] x43e181e083db6cdf)
	{
		using x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(x43e181e083db6cdf);
		xedbd1996b60ba29c x1037b05dde2943fa = x3cd5d648729cd9b.xd611027d44ab2966();
		x1ae70714edec817d result = x2b619d8b9957d836(x1037b05dde2943fa, x3cd5d648729cd9b.xdc1bf80853046136, x3cd5d648729cd9b.xb0f146032f47c24e);
		x42e5c99daad7b47e = x3cd5d648729cd9b.xdc1bf80853046136;
		xc870c20d40920a8c = x3cd5d648729cd9b.xb0f146032f47c24e;
		return result;
	}

	private static x1ae70714edec817d x2b619d8b9957d836(xedbd1996b60ba29c x1037b05dde2943fa, int x9b0739496f8b5475, int x4d5aabc7a55b12ba)
	{
		if (!x1037b05dde2943fa.x24585bc9b0b1d9e9)
		{
			return new x1ae70714edec817d(new x03d68de1c2f74051(new PointF[4]
			{
				new PointF(0f, 0f),
				new PointF(x9b0739496f8b5475, 0f),
				new PointF(x9b0739496f8b5475, x4d5aabc7a55b12ba),
				new PointF(0f, x4d5aabc7a55b12ba)
			}));
		}
		int[] xc93ec65b537aa2c = new int[x4d5aabc7a55b12ba];
		int[] array = new int[x4d5aabc7a55b12ba];
		x29cb1df5ef3b9f06(x1037b05dde2943fa, x9b0739496f8b5475, x4d5aabc7a55b12ba, xc93ec65b537aa2c, array);
		x1ae70714edec817d x1ae70714edec817d2 = new x1ae70714edec817d();
		x03d68de1c2f74051 x03d68de1c2f74052 = new x03d68de1c2f74051();
		int x5f5db3825f958cc = x4d5aabc7a55b12ba;
		bool flag = true;
		for (int num = x4d5aabc7a55b12ba - 1; num >= 0; num--)
		{
			if (array[num] != -1)
			{
				x6f9bc98dc9a9da1a(x03d68de1c2f74052, new PointF(array[num], num));
				if (!flag)
				{
					x5f5db3825f958cc = num + 1;
				}
				flag = true;
				if (num == 0)
				{
					x814ee8a852d4b540(x03d68de1c2f74052, xc93ec65b537aa2c, num, x5f5db3825f958cc);
				}
			}
			else if (flag)
			{
				flag = false;
				x814ee8a852d4b540(x03d68de1c2f74052, xc93ec65b537aa2c, num, x5f5db3825f958cc);
				x1ae70714edec817d2.xcacd30c6b3be9db7(x03d68de1c2f74052);
				x03d68de1c2f74052 = new x03d68de1c2f74051();
			}
		}
		if (x03d68de1c2f74052.xe161fd465603c384 > 0)
		{
			x1ae70714edec817d2.xcacd30c6b3be9db7(x03d68de1c2f74052);
		}
		return x1ae70714edec817d2;
	}

	private static void x814ee8a852d4b540(x03d68de1c2f74051 xe41c5c767887b961, int[] xc93ec65b537aa2c2, int xc67c166b559043d6, int x5f5db3825f958cc5)
	{
		for (int i = xc67c166b559043d6; i < x5f5db3825f958cc5; i++)
		{
			if (xc93ec65b537aa2c2[i] != -1)
			{
				x6f9bc98dc9a9da1a(xe41c5c767887b961, new PointF(xc93ec65b537aa2c2[i], i));
			}
		}
	}

	private static void x29cb1df5ef3b9f06(xedbd1996b60ba29c x1037b05dde2943fa, int x9b0739496f8b5475, int x4d5aabc7a55b12ba, int[] xc93ec65b537aa2c2, int[] xa0531cdb2ce09a12)
	{
		for (int i = 0; i < x4d5aabc7a55b12ba; i++)
		{
			xc93ec65b537aa2c2[i] = xc029ce3509844a8e(i, x9b0739496f8b5475, x1037b05dde2943fa);
			if (xc93ec65b537aa2c2[i] != -1)
			{
				xa0531cdb2ce09a12[i] = xc01b45efb84b51ac(i, x9b0739496f8b5475, x1037b05dde2943fa);
			}
			else
			{
				xa0531cdb2ce09a12[i] = -1;
			}
		}
	}

	private static int xc029ce3509844a8e(int xa806b754814b9ae0, int x9b0739496f8b5475, xedbd1996b60ba29c x1037b05dde2943fa)
	{
		for (int i = 0; i < x9b0739496f8b5475; i++)
		{
			if (x1037b05dde2943fa.x3c5747a5ee1946d5[xa806b754814b9ae0 * x9b0739496f8b5475 + i] != 0)
			{
				return i;
			}
		}
		return -1;
	}

	private static int xc01b45efb84b51ac(int xa806b754814b9ae0, int x9b0739496f8b5475, xedbd1996b60ba29c x1037b05dde2943fa)
	{
		for (int num = x9b0739496f8b5475 - 1; num > -1; num--)
		{
			if (x1037b05dde2943fa.x3c5747a5ee1946d5[xa806b754814b9ae0 * x9b0739496f8b5475 + num] != 0)
			{
				return num;
			}
		}
		return -1;
	}

	private static void x6f9bc98dc9a9da1a(x03d68de1c2f74051 xe41c5c767887b961, PointF x2f7096dac971d6ec)
	{
		int xe161fd465603c = xe41c5c767887b961.xe161fd465603c384;
		if (xe161fd465603c < 2)
		{
			xe41c5c767887b961.x9e8a4f197cec3cdd(x2f7096dac971d6ec);
			return;
		}
		PointF x755f16bdf92ce7c = xe41c5c767887b961.get_xe6d4b1b411ed94b5(xe161fd465603c - 2).x755f16bdf92ce7c4;
		PointF x755f16bdf92ce7c2 = xe41c5c767887b961.get_xe6d4b1b411ed94b5(xe161fd465603c - 1).x755f16bdf92ce7c4;
		if (x755f16bdf92ce7c.X == x755f16bdf92ce7c2.X && x755f16bdf92ce7c2.X == x2f7096dac971d6ec.X)
		{
			xe41c5c767887b961.set_xe6d4b1b411ed94b5(xe161fd465603c - 1, new x319a5291e0303fb7(x2f7096dac971d6ec));
		}
		else
		{
			xe41c5c767887b961.x9e8a4f197cec3cdd(x2f7096dac971d6ec);
		}
	}
}
