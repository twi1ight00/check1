using System;
using System.Collections;
using Aspose.Words.Tables;

namespace x4adf554d20d941a6;

internal class x9b06ad624eb7857a
{
	internal const int x071080bf24a2e688 = 20;

	internal const int xf8d043784b9b8f56 = 31680;

	private const int x46b161552d0fa624 = 50;

	private readonly x10da90eb9c780c82 x0f62a530ebbd1b7d;

	internal int x6e1eb96b81362ebc => x0f62a530ebbd1b7d.x6e1eb96b81362ebc;

	internal int x1fb2a875e6411ef2 => x0f62a530ebbd1b7d.x1fb2a875e6411ef2;

	internal int x1e5325ab72cf7ec9 => x0f62a530ebbd1b7d.x1e5325ab72cf7ec9;

	internal x9b06ad624eb7857a(x7c1e2b821e8b8220 tableLayout)
	{
		x0f62a530ebbd1b7d = new x10da90eb9c780c82(tableLayout);
	}

	internal x5fe4b2f32948ed58 xcda9277b4d19fd44(int xbeb0e74fd1e3aefb)
	{
		return x0f62a530ebbd1b7d.xcda9277b4d19fd44(xbeb0e74fd1e3aefb);
	}

	internal void x30f8cb8a953e9256()
	{
		x009b2c96e049bf18(x0f62a530ebbd1b7d);
		xcfb26ddce70f6648(x0f62a530ebbd1b7d);
		x4f0b016c11753e5b(this, x0f62a530ebbd1b7d);
		xf185746e0807b3fc(x0f62a530ebbd1b7d);
	}

	internal void x6073b6af1e685b60()
	{
		x009b2c96e049bf18(x0f62a530ebbd1b7d);
		xcfb26ddce70f6648(x0f62a530ebbd1b7d);
		x4f0b016c11753e5b(this, x0f62a530ebbd1b7d);
	}

	private static void x009b2c96e049bf18(x10da90eb9c780c82 x1ec770899c98a268)
	{
		x1ec770899c98a268.x973206e6579fce8f = new ArrayList();
		bool flag = true;
		for (int i = 0; i < x1ec770899c98a268.x6e1eb96b81362ebc; i++)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(i);
			xd9db44bb47d1be90 xd9db44bb47d1be91 = null;
			xd9db44bb47d1be90 xd9db44bb47d1be92 = null;
			for (int j = 0; j < x1ec770899c98a268.xb5024700d83d02f9; j++)
			{
				xd9db44bb47d1be90 xd9db44bb47d1be93 = x1ec770899c98a268.xfeb19f1007c0b581(j, -i);
				if (xd9db44bb47d1be93 == null || xd9db44bb47d1be93.x45b7703476a8d6f3)
				{
					continue;
				}
				x5fe4b2f32948ed59.x1fb2a875e6411ef2 = Math.Max(x5fe4b2f32948ed59.x1fb2a875e6411ef2, 20);
				x5fe4b2f32948ed59.x1e5325ab72cf7ec9 = Math.Max(x5fe4b2f32948ed59.x1e5325ab72cf7ec9, 20);
				if (1 >= xd9db44bb47d1be93.x6e1eb96b81362ebc)
				{
					x5fe4b2f32948ed59.x1fb2a875e6411ef2 = Math.Max(xd9db44bb47d1be93.x1fb2a875e6411ef2, x5fe4b2f32948ed59.x1fb2a875e6411ef2);
					if (xd9db44bb47d1be93.x1e5325ab72cf7ec9 > x5fe4b2f32948ed59.x1e5325ab72cf7ec9)
					{
						x5fe4b2f32948ed59.x1e5325ab72cf7ec9 = xd9db44bb47d1be93.x1e5325ab72cf7ec9;
						xd9db44bb47d1be92 = xd9db44bb47d1be93;
					}
					PreferredWidth preferredWidth = xd9db44bb47d1be93.x9962ec7871050cbf;
					if (preferredWidth.x7680505e84ce0354 > 31680)
					{
						preferredWidth = PreferredWidth.xf6bcf515ffcb5cc9(31680);
					}
					if (preferredWidth.x7680505e84ce0354 < 0)
					{
						preferredWidth = PreferredWidth.Auto;
					}
					switch (preferredWidth.Type)
					{
					case PreferredWidthType.Points:
						if (preferredWidth.x7680505e84ce0354 > 0 && !x5fe4b2f32948ed59.x9962ec7871050cbf.x368bd9f7b8c336b4)
						{
							int num = Math.Max(preferredWidth.x7680505e84ce0354, Math.Max(xd9db44bb47d1be93.x92e7e5f35452590d / 2, xd9db44bb47d1be93.xcad2e59522947ede) + Math.Max(xd9db44bb47d1be93.x0924cade9dc2d296 / 2, xd9db44bb47d1be93.x41c99cca24bc80be));
							if (!x5fe4b2f32948ed59.x9962ec7871050cbf.x08428aa3999da322 || num > x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354 || (num == x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354 && xd9db44bb47d1be92 == xd9db44bb47d1be93))
							{
								x5fe4b2f32948ed59.x9962ec7871050cbf = PreferredWidth.xf6bcf515ffcb5cc9(num);
								xd9db44bb47d1be91 = xd9db44bb47d1be93;
							}
						}
						break;
					case PreferredWidthType.Percent:
						x1ec770899c98a268.x31487d0887f08f2b = true;
						if (0 < preferredWidth.x7680505e84ce0354 && (!x5fe4b2f32948ed59.x9962ec7871050cbf.x368bd9f7b8c336b4 || preferredWidth.x7680505e84ce0354 > x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354))
						{
							x5fe4b2f32948ed59.x9962ec7871050cbf = preferredWidth;
						}
						break;
					}
				}
				else
				{
					x1ec770899c98a268.x973206e6579fce8f.Add(xd9db44bb47d1be93);
				}
			}
			if (x5fe4b2f32948ed59.x9962ec7871050cbf.x08428aa3999da322 && x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354 < x5fe4b2f32948ed59.x1e5325ab72cf7ec9 && xd9db44bb47d1be91 != xd9db44bb47d1be92)
			{
				x5fe4b2f32948ed59.x9962ec7871050cbf = PreferredWidth.Auto;
			}
			x5fe4b2f32948ed59.x1e5325ab72cf7ec9 = Math.Max(x5fe4b2f32948ed59.x1e5325ab72cf7ec9, x5fe4b2f32948ed59.x1fb2a875e6411ef2);
			if (x5fe4b2f32948ed59.x9962ec7871050cbf.x08428aa3999da322 && x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354 > x5fe4b2f32948ed59.x1e5325ab72cf7ec9)
			{
				x5fe4b2f32948ed59.x1e5325ab72cf7ec9 = x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354;
			}
			if (!x5fe4b2f32948ed59.x9962ec7871050cbf.x08428aa3999da322 || 0 >= x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354)
			{
				flag = false;
			}
		}
		if (flag)
		{
			for (int k = 0; k < x1ec770899c98a268.x6e1eb96b81362ebc; k++)
			{
				x5fe4b2f32948ed58 x5fe4b2f32948ed60 = x1ec770899c98a268.xcda9277b4d19fd44(k);
				x5fe4b2f32948ed60.x1e5325ab72cf7ec9 = Math.Max(x5fe4b2f32948ed60.x1e5325ab72cf7ec9, x5fe4b2f32948ed60.x9962ec7871050cbf.xdf4645c89f0e47f6);
				x5fe4b2f32948ed60.x1e5325ab72cf7ec9 = Math.Max(x5fe4b2f32948ed60.x1e5325ab72cf7ec9, x5fe4b2f32948ed60.x1fb2a875e6411ef2);
			}
		}
	}

	private static void xcfb26ddce70f6648(x10da90eb9c780c82 x1ec770899c98a268)
	{
		int xb2960ba3959be = 0;
		x44d4eda09fbbdf81(x1ec770899c98a268);
		x1ec770899c98a268.x973206e6579fce8f.Sort();
		x675379b03fd9557c x675379b03fd9557c2 = new x675379b03fd9557c();
		for (int i = 0; i < x1ec770899c98a268.x973206e6579fce8f.Count; i++)
		{
			xd9db44bb47d1be90 xd9db44bb47d1be91 = (xd9db44bb47d1be90)x1ec770899c98a268.x973206e6579fce8f[i];
			if (xd9db44bb47d1be91.x9962ec7871050cbf.x7680505e84ce0354 == 0)
			{
				xd9db44bb47d1be91.x9962ec7871050cbf = PreferredWidth.Auto;
			}
			int x59bc0096de = xd9db44bb47d1be91.x59bc0096de497989;
			int num = x59bc0096de + xd9db44bb47d1be91.x6e1eb96b81362ebc;
			x6edba18498a2fefa(x1ec770899c98a268, xd9db44bb47d1be91, x675379b03fd9557c2);
			if (xd9db44bb47d1be91.x9962ec7871050cbf.x368bd9f7b8c336b4)
			{
				xb952f2d8694c5582(x1ec770899c98a268, xd9db44bb47d1be91, x59bc0096de, num, x675379b03fd9557c2.x923c17a94d496cf2, x675379b03fd9557c2.x4d48c1e6cc5f707c, x675379b03fd9557c2.x488943e28fd3b397, x675379b03fd9557c2.x2300920651296553, ref xb2960ba3959be);
			}
			if (x675379b03fd9557c2.xf439212a1625cb13)
			{
				xd534560a41034912(x1ec770899c98a268, x59bc0096de, num, x675379b03fd9557c2.xb731c2c4a0b66307, x675379b03fd9557c2.x631c3ed14927c9d2, x675379b03fd9557c2.x0bab496ebb47661a);
			}
			else if (x675379b03fd9557c2.x30a8e7ec442445eb)
			{
				x8b7e7fe87fc907ef(x1ec770899c98a268, x59bc0096de, num, x675379b03fd9557c2.xb731c2c4a0b66307, x675379b03fd9557c2.x4d48c1e6cc5f707c, x675379b03fd9557c2.x631c3ed14927c9d2, x675379b03fd9557c2.x0bab496ebb47661a);
			}
			if (xd9db44bb47d1be91.x9962ec7871050cbf.x368bd9f7b8c336b4)
			{
				for (int j = x59bc0096de; j < num; j++)
				{
					x1ec770899c98a268.xcda9277b4d19fd44(j).x0c2e942d8a80f9a2();
				}
			}
			else if (x675379b03fd9557c2.x923c17a94d496cf2 > x675379b03fd9557c2.x4d48c1e6cc5f707c)
			{
				int num2 = x59bc0096de;
				while (x675379b03fd9557c2.x4d48c1e6cc5f707c >= 0 && num2 < num)
				{
					x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(num2);
					int num3 = Math.Max(x5fe4b2f32948ed59.x97831d623b125b19, (int)((x675379b03fd9557c2.x4d48c1e6cc5f707c != 0) ? ((float)x675379b03fd9557c2.x923c17a94d496cf2 * (float)x5fe4b2f32948ed59.x97831d623b125b19 / (float)x675379b03fd9557c2.x4d48c1e6cc5f707c) : ((float)x675379b03fd9557c2.x923c17a94d496cf2)));
					x675379b03fd9557c2.x4d48c1e6cc5f707c -= x5fe4b2f32948ed59.x97831d623b125b19;
					x675379b03fd9557c2.x923c17a94d496cf2 -= num3;
					x5fe4b2f32948ed59.x97831d623b125b19 = num3;
					num2++;
				}
			}
		}
		x1ec770899c98a268.x1e5325ab72cf7ec9 = Math.Min(xb2960ba3959be, 31680);
	}

	private static void x4f0b016c11753e5b(x9b06ad624eb7857a xe01b23a4b3485562, x10da90eb9c780c82 x1ec770899c98a268)
	{
		int val = x1ec770899c98a268.x1e5325ab72cf7ec9;
		x1ec770899c98a268.x1e5325ab72cf7ec9 = (x1ec770899c98a268.x1fb2a875e6411ef2 = 0);
		int num = 0;
		int num2 = 0;
		bool flag = false;
		int num3 = 50;
		int num4 = 100 * num3;
		for (int i = 0; i < x1ec770899c98a268.x6e1eb96b81362ebc; i++)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(i);
			x1ec770899c98a268.x1fb2a875e6411ef2 += x5fe4b2f32948ed59.x338567793328a5a6;
			x1ec770899c98a268.x1e5325ab72cf7ec9 += x5fe4b2f32948ed59.x97831d623b125b19;
			if (flag)
			{
				if (x5fe4b2f32948ed59.x30db1c48b3c56061.x368bd9f7b8c336b4)
				{
					int num5 = Math.Min(x5fe4b2f32948ed59.x30db1c48b3c56061.x7680505e84ce0354, num4);
					int val2 = (int)((double)x5fe4b2f32948ed59.x97831d623b125b19 * 100.0 * (double)num3 / (double)Math.Max(num5, 1));
					num = Math.Max(val2, num);
					num4 -= num5;
				}
				else
				{
					num2 += x5fe4b2f32948ed59.x97831d623b125b19;
				}
			}
		}
		if (flag)
		{
			num2 = (int)((double)num2 * 100.0 * (double)num3 / (double)Math.Max(num4, 1));
			num2 = Math.Min(num2, 31680);
			num = Math.Min(num, 31680);
			x1ec770899c98a268.x1e5325ab72cf7ec9 = Math.Max(x1ec770899c98a268.x1e5325ab72cf7ec9, num2);
			x1ec770899c98a268.x1e5325ab72cf7ec9 = Math.Max(x1ec770899c98a268.x1e5325ab72cf7ec9, num);
		}
		x1ec770899c98a268.x1e5325ab72cf7ec9 = Math.Max(x1ec770899c98a268.x1e5325ab72cf7ec9, val);
		int x40a8cd925e306f1b = x1ec770899c98a268.x40a8cd925e306f1b;
		x1ec770899c98a268.x1fb2a875e6411ef2 += x40a8cd925e306f1b;
		x1ec770899c98a268.x1e5325ab72cf7ec9 += x40a8cd925e306f1b;
		PreferredWidth x9962ec7871050cbf = x1ec770899c98a268.x9962ec7871050cbf;
		if (x9962ec7871050cbf.x08428aa3999da322 && x9962ec7871050cbf.x40aae25d22abf007)
		{
			x1ec770899c98a268.x1fb2a875e6411ef2 = Math.Max(x1ec770899c98a268.x1fb2a875e6411ef2, x9962ec7871050cbf.x7680505e84ce0354);
			x1ec770899c98a268.x1e5325ab72cf7ec9 = x1ec770899c98a268.x1fb2a875e6411ef2;
		}
	}

	private static void xf185746e0807b3fc(x10da90eb9c780c82 x1ec770899c98a268)
	{
		int x3b3c76521f668fcb = x1ec770899c98a268.xe23673a90a622986(x1ec770899c98a268.x1fb2a875e6411ef2, x1ec770899c98a268.x1e5325ab72cf7ec9);
		xb691fbf4e2a72c64 xb691fbf4e2a72c65 = new xb691fbf4e2a72c64();
		xb691fbf4e2a72c65.xd99ce1688879db11(x1ec770899c98a268, x1ec770899c98a268.x31487d0887f08f2b, x3b3c76521f668fcb);
		for (int i = 0; i < x1ec770899c98a268.xb5024700d83d02f9; i++)
		{
			for (int j = 0; j < x1ec770899c98a268.x6e1eb96b81362ebc; j++)
			{
				xd9db44bb47d1be90 xd9db44bb47d1be91 = x1ec770899c98a268.xfeb19f1007c0b581(i, -j);
				if (xd9db44bb47d1be91 != null)
				{
					int xdc1bf80853046136 = Math.Min(xc454e3b37cf5cc39(x1ec770899c98a268, xd9db44bb47d1be91), 31680);
					xd9db44bb47d1be91.xdc1bf80853046136 = xdc1bf80853046136;
				}
			}
		}
	}

	private static int xc454e3b37cf5cc39(x10da90eb9c780c82 x1ec770899c98a268, xd9db44bb47d1be90 xe6de5e5fa2d44af5)
	{
		if (1 >= xe6de5e5fa2d44af5.x6e1eb96b81362ebc)
		{
			return x1ec770899c98a268.xcda9277b4d19fd44(xe6de5e5fa2d44af5.x59bc0096de497989).xdc1bf80853046136;
		}
		int num = 0;
		for (int i = 0; i < xe6de5e5fa2d44af5.x6e1eb96b81362ebc; i++)
		{
			num += x1ec770899c98a268.xcda9277b4d19fd44(xe6de5e5fa2d44af5.x59bc0096de497989 + i).xdc1bf80853046136;
		}
		return num;
	}

	private static void xd534560a41034912(x10da90eb9c780c82 x1ec770899c98a268, int x449a501e816ef2df, int x29a1bfa53e2fa8bf, int xb731c2c4a0b66307, int x631c3ed14927c9d2, int x0bab496ebb47661a)
	{
		if (x631c3ed14927c9d2 > xb731c2c4a0b66307)
		{
			int num = x449a501e816ef2df;
			while (x0bab496ebb47661a > 0 && num < x29a1bfa53e2fa8bf)
			{
				x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(num);
				int num2 = Math.Max(x5fe4b2f32948ed59.x338567793328a5a6, x631c3ed14927c9d2 * x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354 / x0bab496ebb47661a);
				x0bab496ebb47661a -= x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354;
				x631c3ed14927c9d2 -= num2;
				x5fe4b2f32948ed59.x338567793328a5a6 = num2;
				num++;
			}
		}
	}

	private static void x8b7e7fe87fc907ef(x10da90eb9c780c82 x1ec770899c98a268, int x449a501e816ef2df, int x29a1bfa53e2fa8bf, int xb731c2c4a0b66307, int x4d48c1e6cc5f707c, int x631c3ed14927c9d2, int x0bab496ebb47661a)
	{
		if (x631c3ed14927c9d2 <= xb731c2c4a0b66307)
		{
			return;
		}
		int num = x449a501e816ef2df;
		while (x4d48c1e6cc5f707c >= 0 && num < x29a1bfa53e2fa8bf)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(num);
			if (x5fe4b2f32948ed59.x9962ec7871050cbf.x08428aa3999da322)
			{
				if (x0bab496ebb47661a > x631c3ed14927c9d2)
				{
					break;
				}
				int num2 = Math.Max(x5fe4b2f32948ed59.x338567793328a5a6, x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354);
				x0bab496ebb47661a -= x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354;
				xb731c2c4a0b66307 -= x5fe4b2f32948ed59.x338567793328a5a6;
				x4d48c1e6cc5f707c -= x5fe4b2f32948ed59.x97831d623b125b19;
				x631c3ed14927c9d2 -= num2;
				x5fe4b2f32948ed59.x338567793328a5a6 = num2;
			}
			num++;
		}
		for (int i = x449a501e816ef2df; i < x29a1bfa53e2fa8bf; i++)
		{
			if (0 > x4d48c1e6cc5f707c)
			{
				break;
			}
			if (xb731c2c4a0b66307 >= x631c3ed14927c9d2)
			{
				break;
			}
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(i);
			if (!x5fe4b2f32948ed59.x9962ec7871050cbf.x08428aa3999da322)
			{
				if (x631c3ed14927c9d2 < x0bab496ebb47661a)
				{
					break;
				}
				int num2 = Math.Max(x5fe4b2f32948ed59.x338567793328a5a6, (int)((x4d48c1e6cc5f707c != 0) ? ((float)x631c3ed14927c9d2 * (float)x5fe4b2f32948ed59.x97831d623b125b19 / (float)x4d48c1e6cc5f707c) : ((float)x631c3ed14927c9d2)));
				num2 = Math.Min(x5fe4b2f32948ed59.x338567793328a5a6 + (x631c3ed14927c9d2 - xb731c2c4a0b66307), num2);
				x4d48c1e6cc5f707c -= x5fe4b2f32948ed59.x97831d623b125b19;
				xb731c2c4a0b66307 -= x5fe4b2f32948ed59.x338567793328a5a6;
				x631c3ed14927c9d2 -= num2;
				x5fe4b2f32948ed59.x338567793328a5a6 = num2;
			}
		}
	}

	private static void xb952f2d8694c5582(x10da90eb9c780c82 x1ec770899c98a268, xd9db44bb47d1be90 xe6de5e5fa2d44af5, int x449a501e816ef2df, int x29a1bfa53e2fa8bf, int x923c17a94d496cf2, int x4d48c1e6cc5f707c, bool x488943e28fd3b397, int x2300920651296553, ref int xb2960ba3959be802)
	{
		if (x2300920651296553 > xe6de5e5fa2d44af5.x9962ec7871050cbf.x7680505e84ce0354 || x488943e28fd3b397)
		{
			xe6de5e5fa2d44af5.x9962ec7871050cbf = PreferredWidth.Auto;
			return;
		}
		int num = Math.Max(x4d48c1e6cc5f707c, x923c17a94d496cf2);
		xb2960ba3959be802 = Math.Max(xb2960ba3959be802, (int)Math.Ceiling((float)num * 100f * 50f / (float)xe6de5e5fa2d44af5.x9962ec7871050cbf.x7680505e84ce0354));
		int num2 = xe6de5e5fa2d44af5.x9962ec7871050cbf.x7680505e84ce0354 - x2300920651296553;
		int num3 = 0;
		for (int i = x449a501e816ef2df; i < x29a1bfa53e2fa8bf; i++)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(i);
			if (!x5fe4b2f32948ed59.x30db1c48b3c56061.x368bd9f7b8c336b4)
			{
				num3 += x5fe4b2f32948ed59.x97831d623b125b19;
			}
		}
		for (int j = x449a501e816ef2df; j < x29a1bfa53e2fa8bf; j++)
		{
			if (num3 <= 0)
			{
				break;
			}
			x5fe4b2f32948ed58 x5fe4b2f32948ed60 = x1ec770899c98a268.xcda9277b4d19fd44(j);
			if (!x5fe4b2f32948ed60.x30db1c48b3c56061.x368bd9f7b8c336b4)
			{
				int num4 = (int)((float)num2 * (float)x5fe4b2f32948ed60.x97831d623b125b19 / (float)num3);
				num3 -= x5fe4b2f32948ed60.x97831d623b125b19;
				num2 -= num4;
				if (num4 > 0)
				{
					x5fe4b2f32948ed60.x30db1c48b3c56061 = PreferredWidth.x6b44e3efc21fd5b4(PreferredWidthType.Percent, num4);
				}
				else
				{
					x5fe4b2f32948ed60.x30db1c48b3c56061 = PreferredWidth.Auto;
				}
			}
		}
	}

	private static void x6edba18498a2fefa(x10da90eb9c780c82 x1ec770899c98a268, xd9db44bb47d1be90 xe6de5e5fa2d44af5, x675379b03fd9557c x7d95d971d8923f4c)
	{
		x7d95d971d8923f4c.x74f5a1ef3906e23c();
		int num = 0;
		x7d95d971d8923f4c.x631c3ed14927c9d2 = xe6de5e5fa2d44af5.x1fb2a875e6411ef2 + num;
		x7d95d971d8923f4c.x923c17a94d496cf2 = xe6de5e5fa2d44af5.x1e5325ab72cf7ec9 + num;
		int num2 = x1ec770899c98a268.x6e1eb96b81362ebc;
		int num3 = xe6de5e5fa2d44af5.x59bc0096de497989;
		int num4 = xe6de5e5fa2d44af5.x6e1eb96b81362ebc;
		while (num3 < num2 && num4 > 0)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(num3);
			switch (x5fe4b2f32948ed59.x9962ec7871050cbf.Type)
			{
			case PreferredWidthType.Percent:
				x7d95d971d8923f4c.x2300920651296553 += x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354;
				x7d95d971d8923f4c.xf439212a1625cb13 = false;
				break;
			case PreferredWidthType.Points:
				if (x5fe4b2f32948ed59.x9962ec7871050cbf.x40aae25d22abf007)
				{
					x7d95d971d8923f4c.x0bab496ebb47661a += x5fe4b2f32948ed59.x9962ec7871050cbf.x7680505e84ce0354;
					x7d95d971d8923f4c.x488943e28fd3b397 = false;
				}
				else
				{
					x46c0563ede443173(x5fe4b2f32948ed59, x7d95d971d8923f4c);
				}
				break;
			case PreferredWidthType.Auto:
				x7d95d971d8923f4c.x30a8e7ec442445eb = true;
				x46c0563ede443173(x5fe4b2f32948ed59, x7d95d971d8923f4c);
				break;
			default:
				x46c0563ede443173(x5fe4b2f32948ed59, x7d95d971d8923f4c);
				break;
			}
			num4--;
			x7d95d971d8923f4c.xb731c2c4a0b66307 += x5fe4b2f32948ed59.x338567793328a5a6;
			x7d95d971d8923f4c.x4d48c1e6cc5f707c += x5fe4b2f32948ed59.x97831d623b125b19;
			num3++;
			x7d95d971d8923f4c.x631c3ed14927c9d2 -= num;
			x7d95d971d8923f4c.x923c17a94d496cf2 -= num;
		}
	}

	private static void x46c0563ede443173(x5fe4b2f32948ed58 xe3e287548b3d01f5, x675379b03fd9557c x7d95d971d8923f4c)
	{
		if (!xe3e287548b3d01f5.x30db1c48b3c56061.x368bd9f7b8c336b4)
		{
			xe3e287548b3d01f5.x30db1c48b3c56061 = PreferredWidth.Auto;
			x7d95d971d8923f4c.x488943e28fd3b397 = false;
		}
		else
		{
			x7d95d971d8923f4c.x2300920651296553 += xe3e287548b3d01f5.x30db1c48b3c56061.x7680505e84ce0354;
		}
		x7d95d971d8923f4c.xf439212a1625cb13 = false;
	}

	private static void x44d4eda09fbbdf81(x10da90eb9c780c82 x1ec770899c98a268)
	{
		int num = x1ec770899c98a268.x6e1eb96b81362ebc;
		for (int i = 0; i < num; i++)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(i);
			x5fe4b2f32948ed59.x30db1c48b3c56061 = x5fe4b2f32948ed59.x9962ec7871050cbf;
			x5fe4b2f32948ed59.x338567793328a5a6 = x5fe4b2f32948ed59.x1fb2a875e6411ef2;
			x5fe4b2f32948ed59.x97831d623b125b19 = x5fe4b2f32948ed59.x1e5325ab72cf7ec9;
		}
	}
}
