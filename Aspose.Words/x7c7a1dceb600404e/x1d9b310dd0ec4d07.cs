using System.Collections;
using System.Text;
using x011d489fb9df7027;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x7c7a1dceb600404e;

internal class x1d9b310dd0ec4d07
{
	private enum xa3d1c40137907d7d
	{
		x228f1eaab545bdd4,
		x7a274f60ab25f2b9,
		x81f32aac56c46f24,
		x8c0d22e4c133799d
	}

	private readonly StringBuilder x800085dd555f7711 = new StringBuilder();

	private readonly ArrayList x98e93df7a11f1d5f = new ArrayList();

	private readonly ArrayList x078146c1d2b45387 = new ArrayList();

	private readonly x44f2b8bf33b16275[] x8981fd81e0974d02;

	private readonly x08d932077485c285[] xc72926de6b6361e2;

	private int x9653fe3e399d9cb4;

	private bool xeee0f336feec5bee;

	private int x1cb80fa02d5d5f2c;

	private int x0caf457ecb5a9d97;

	internal x44f2b8bf33b16275[] x703b3c5072b7f42e => x8981fd81e0974d02;

	internal x08d932077485c285[] x4d7474e8f1849803 => xc72926de6b6361e2;

	internal x1d9b310dd0ec4d07(string path)
	{
		xaf15971281c9936b(path);
		x8981fd81e0974d02 = new x44f2b8bf33b16275[x98e93df7a11f1d5f.Count];
		for (int i = 0; i < x98e93df7a11f1d5f.Count; i++)
		{
			x8981fd81e0974d02[i] = (x44f2b8bf33b16275)x98e93df7a11f1d5f[i];
		}
		xc72926de6b6361e2 = new x08d932077485c285[x078146c1d2b45387.Count / 2];
		for (int j = 0; j < x078146c1d2b45387.Count / 2; j++)
		{
			xc72926de6b6361e2[j] = new x08d932077485c285((x06e4f09a90ca939a)x078146c1d2b45387[2 * j], (x06e4f09a90ca939a)x078146c1d2b45387[2 * j + 1]);
		}
	}

	private void xaf15971281c9936b(string xe125219852864557)
	{
		xa3d1c40137907d7d xa3d1c40137907d7d = xa3d1c40137907d7d.x7a274f60ab25f2b9;
		foreach (char c in xe125219852864557)
		{
			if (char.IsDigit(c) || c == '-')
			{
				switch (xa3d1c40137907d7d)
				{
				case xa3d1c40137907d7d.x228f1eaab545bdd4:
					xa3d1c40137907d7d = xa3d1c40137907d7d.x8c0d22e4c133799d;
					break;
				case xa3d1c40137907d7d.x7a274f60ab25f2b9:
					xf999f2991a1e3a2c();
					xa3d1c40137907d7d = xa3d1c40137907d7d.x8c0d22e4c133799d;
					break;
				}
				x800085dd555f7711.Append(c);
				continue;
			}
			if (char.IsLower(c))
			{
				switch (xa3d1c40137907d7d)
				{
				case xa3d1c40137907d7d.x228f1eaab545bdd4:
					x4163d524eca80ee7();
					break;
				case xa3d1c40137907d7d.x7a274f60ab25f2b9:
					if (xec5b51d1226855dc(x800085dd555f7711.ToString()))
					{
						xf999f2991a1e3a2c();
					}
					break;
				case xa3d1c40137907d7d.x81f32aac56c46f24:
				case xa3d1c40137907d7d.x8c0d22e4c133799d:
					x4163d524eca80ee7();
					break;
				}
				xa3d1c40137907d7d = xa3d1c40137907d7d.x7a274f60ab25f2b9;
				x800085dd555f7711.Append(c);
				continue;
			}
			switch (c)
			{
			case ',':
				switch (xa3d1c40137907d7d)
				{
				case xa3d1c40137907d7d.x7a274f60ab25f2b9:
					xf999f2991a1e3a2c();
					break;
				}
				x4163d524eca80ee7();
				xa3d1c40137907d7d = xa3d1c40137907d7d.x228f1eaab545bdd4;
				break;
			case '@':
				switch (xa3d1c40137907d7d)
				{
				case xa3d1c40137907d7d.x7a274f60ab25f2b9:
					xf999f2991a1e3a2c();
					break;
				case xa3d1c40137907d7d.x81f32aac56c46f24:
				case xa3d1c40137907d7d.x8c0d22e4c133799d:
					x4163d524eca80ee7();
					break;
				}
				xa3d1c40137907d7d = xa3d1c40137907d7d.x81f32aac56c46f24;
				x800085dd555f7711.Append(c);
				break;
			default:
				_ = 32;
				break;
			}
		}
		x24ca649db389c043(xa3d1c40137907d7d);
	}

	private void x24ca649db389c043(xa3d1c40137907d7d x01b557925841ae51)
	{
		switch (x01b557925841ae51)
		{
		case xa3d1c40137907d7d.x81f32aac56c46f24:
		case xa3d1c40137907d7d.x8c0d22e4c133799d:
			x4163d524eca80ee7();
			x800085dd555f7711.Append('e');
			break;
		}
		xf999f2991a1e3a2c();
	}

	private void xf999f2991a1e3a2c()
	{
		if (x98e93df7a11f1d5f.Count > 0)
		{
			x44f2b8bf33b16275 x44f2b8bf33b = (x44f2b8bf33b16275)x98e93df7a11f1d5f[x98e93df7a11f1d5f.Count - 1];
			x98e93df7a11f1d5f[x98e93df7a11f1d5f.Count - 1] = new x44f2b8bf33b16275(x44f2b8bf33b.x4dd8a59ec8974a5f, xf071591f4401fea8(x44f2b8bf33b, x9653fe3e399d9cb4 / 2));
		}
		string xbcea506a33cf = x800085dd555f7711.ToString();
		x800085dd555f7711.Length = 0;
		x44f2b8bf33b16275 value = new x44f2b8bf33b16275(xe8c6c9911baaa42f(xbcea506a33cf), 0);
		x98e93df7a11f1d5f.Add(value);
		xeee0f336feec5bee = xecef48a8307ef693(xbcea506a33cf);
		x9653fe3e399d9cb4 = 0;
	}

	private static int xf071591f4401fea8(x44f2b8bf33b16275 x37169c88a38f2f9b, int xae12ed90fbb541c2)
	{
		x4dd8a59ec8974a5f x4dd8a59ec8974a5f = x37169c88a38f2f9b.x4dd8a59ec8974a5f;
		if (x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x8ffe90e7fbccfccd)
		{
			return 1;
		}
		int num = x37169c88a38f2f9b.xf7666fb96d286b7d();
		if (num <= 0)
		{
			return 0;
		}
		return xae12ed90fbb541c2 / num;
	}

	private static bool xec5b51d1226855dc(string xbcea506a33cf9111)
	{
		return xe8c6c9911baaa42f(xbcea506a33cf9111) != x4dd8a59ec8974a5f.xf6c17f648b65c793;
	}

	private static x4dd8a59ec8974a5f xe8c6c9911baaa42f(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"r" => x4dd8a59ec8974a5f.xd0baff30d99dc152, 
			"v" => x4dd8a59ec8974a5f.x102c43569e36d6d1, 
			"t" => x4dd8a59ec8974a5f.x01b2723108ff3dfe, 
			_ => xf4107e64edda7fac.xb68adb532c2a7aef(xbcea506a33cf9111), 
		};
	}

	private static bool xecef48a8307ef693(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "r":
		case "v":
		case "t":
			return true;
		default:
			return false;
		}
	}

	private void x4163d524eca80ee7()
	{
		string xbcea506a33cf = x800085dd555f7711.ToString();
		x800085dd555f7711.Length = 0;
		x06e4f09a90ca939a x06e4f09a90ca939a = x1bce28f95074665d(xbcea506a33cf);
		bool flag = x0d299f323d241756.x7e32f71c3f39b6bc(x9653fe3e399d9cb4);
		if (xeee0f336feec5bee)
		{
			x06e4f09a90ca939a = ((!flag) ? new x06e4f09a90ca939a(x06e4f09a90ca939a.xd2f68ee6f47e9dfb + x1cb80fa02d5d5f2c) : new x06e4f09a90ca939a(x06e4f09a90ca939a.xd2f68ee6f47e9dfb + x0caf457ecb5a9d97));
		}
		else if (flag)
		{
			x0caf457ecb5a9d97 = x06e4f09a90ca939a.xd2f68ee6f47e9dfb;
		}
		else
		{
			x1cb80fa02d5d5f2c = x06e4f09a90ca939a.xd2f68ee6f47e9dfb;
		}
		x078146c1d2b45387.Add(x06e4f09a90ca939a);
		x9653fe3e399d9cb4++;
	}

	internal static x06e4f09a90ca939a x1bce28f95074665d(string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			bool isFormula = false;
			if (xbcea506a33cf9111.StartsWith("@"))
			{
				isFormula = true;
				xbcea506a33cf9111 = xbcea506a33cf9111.TrimStart('@');
			}
			return new x06e4f09a90ca939a(xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111), isFormula);
		}
		return new x06e4f09a90ca939a();
	}
}
