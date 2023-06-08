using System.Collections;
using System.Text;
using xb1090543d168d647;

namespace x59d6a4fc5007b7a4;

internal class xf02702475fd1ff5e : xc2469d942acfbc3d
{
	private const x610f9b736060774c xe1a3be2431fe3bd8 = (x610f9b736060774c)256;

	private readonly xd557958daa1f35fe xfa75ef06a5df643f;

	private readonly bool x8cd30f32e8a599f8;

	private bool x915e365168cf1b8c;

	private readonly ArrayList x92e4b59a5496c035 = new ArrayList();

	internal xf02702475fd1ff5e(x91866f79774c2b6a shapingWorkspace)
		: base(shapingWorkspace)
	{
		xfa75ef06a5df643f = shapingWorkspace.xd557958daa1f35fe;
		x8cd30f32e8a599f8 = true;
	}

	internal override void x550781f8db1cf5f2()
	{
		x4165df4d746bc830();
		if (x915e365168cf1b8c && xf18f3b887970dbc4.x1be93eed8950d961 != 0)
		{
			x6012f43a148fc5cf();
		}
	}

	private void x4165df4d746bc830()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < xb14db7591535b378.x1be93eed8950d961; i++)
		{
			stringBuilder.Length = 0;
			x11f64aae12429e33(x8cd30f32e8a599f8, xb14db7591535b378.get_xe6d4b1b411ed94b5(i), stringBuilder);
			x92e4b59a5496c035.Add(1 - stringBuilder.Length);
			for (int j = 0; j < stringBuilder.Length; j++)
			{
				char c = stringBuilder[j];
				xfa75ef06a5df643f.xc5bc2583a94d87d8(c);
				x610f9b736060774c x610f9b736060774c = xd9a6b2b6ada137e6.xdcb014d94aea6e74(c);
				if (x610f9b736060774c != 0)
				{
					x915e365168cf1b8c = true;
				}
				int num = xf18f3b887970dbc4.x1be93eed8950d961;
				if (x610f9b736060774c != 0)
				{
					while (num > 0)
					{
						char x3c4da2980d043c = xf18f3b887970dbc4.get_xe6d4b1b411ed94b5(num - 1);
						if (xd9a6b2b6ada137e6.xdcb014d94aea6e74(x3c4da2980d043c) <= x610f9b736060774c)
						{
							break;
						}
						num--;
					}
				}
				xf18f3b887970dbc4.xef23aa45e7612fdd(num, c, i);
			}
		}
	}

	private static void x11f64aae12429e33(bool x2701c149a7daec31, char xb867a42da3ae686d, StringBuilder xd07ce4b74c5774a7)
	{
		string text = xd9a6b2b6ada137e6.x603bc1e3ce7f9a3a(xb867a42da3ae686d);
		if (text != null && (!x2701c149a7daec31 || xd9a6b2b6ada137e6.x41c856f7eceb7c62(xb867a42da3ae686d) == xe9104eca3968ec19.x4d0b9d4447ba7566))
		{
			for (int i = 0; i < text.Length; i++)
			{
				x11f64aae12429e33(x2701c149a7daec31, text[i], xd07ce4b74c5774a7);
			}
		}
		else
		{
			xd07ce4b74c5774a7.Append(xb867a42da3ae686d);
		}
	}

	private void x6012f43a148fc5cf()
	{
		int num = 0;
		int num2 = 1;
		char c = xf18f3b887970dbc4.get_xe6d4b1b411ed94b5(0);
		x92e4b59a5496c035[num] = (int)x92e4b59a5496c035[num] + 1;
		x610f9b736060774c x610f9b736060774c = xd9a6b2b6ada137e6.xdcb014d94aea6e74(c);
		if (x610f9b736060774c != 0)
		{
			x610f9b736060774c = (x610f9b736060774c)256;
		}
		int x1be93eed8950d = xf18f3b887970dbc4.x1be93eed8950d961;
		for (int i = num2; i < xf18f3b887970dbc4.x1be93eed8950d961; i++)
		{
			char c2 = xf18f3b887970dbc4.get_xe6d4b1b411ed94b5(i);
			x610f9b736060774c x610f9b736060774c2 = xd9a6b2b6ada137e6.xdcb014d94aea6e74(c2);
			char c3 = x2a5f0934ae62db3f(c, c2);
			if (xd9a6b2b6ada137e6.x41c856f7eceb7c62(c3) == xe9104eca3968ec19.x4d0b9d4447ba7566 && c3 != '\uffff' && (x610f9b736060774c < x610f9b736060774c2 || x610f9b736060774c == x610f9b736060774c.x48ce0d46d6b8c1d4))
			{
				xb6b8f962814600b2(num, c3);
				x92e4b59a5496c035[num] = (int)x92e4b59a5496c035[num] + 1;
				c = c3;
				continue;
			}
			if (x92e4b59a5496c035.Count - 1 >= num2)
			{
				if (x610f9b736060774c2 == x610f9b736060774c.x48ce0d46d6b8c1d4)
				{
					num = num2;
					c = c2;
				}
				x610f9b736060774c = x610f9b736060774c2;
				xf18f3b887970dbc4.set_xe6d4b1b411ed94b5(num2, c2);
				int j = num2;
				if ((int)x92e4b59a5496c035[j] < 0)
				{
					for (; (int)x92e4b59a5496c035[j] < 0; j++)
					{
						x92e4b59a5496c035[j] = (int)x92e4b59a5496c035[j] + 1;
						x92e4b59a5496c035.Insert(num2, 0);
					}
				}
				else
				{
					x92e4b59a5496c035[j] = (int)x92e4b59a5496c035[j] + 1;
				}
			}
			if (xf18f3b887970dbc4.x1be93eed8950d961 != x1be93eed8950d)
			{
				i += xf18f3b887970dbc4.x1be93eed8950d961 - x1be93eed8950d;
				x1be93eed8950d = xf18f3b887970dbc4.x1be93eed8950d961;
			}
			num2++;
		}
		xf18f3b887970dbc4.x1be93eed8950d961 = num2;
		if (x92e4b59a5496c035.Count - num2 > 0)
		{
			x92e4b59a5496c035.RemoveRange(num2, x92e4b59a5496c035.Count - num2);
		}
		xf18f3b887970dbc4.xcd5f7940e9d851bd();
	}

	private static char x2a5f0934ae62db3f(char x62584df2cb5d40dd, char xac08cf66a2c6510c)
	{
		return xd9a6b2b6ada137e6.x10d30c930a90ad82(x62584df2cb5d40dd.ToString() + xac08cf66a2c6510c);
	}
}
