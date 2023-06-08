using System.Collections;
using x6b8130194ad714f7;

namespace x7cd71466ce904867;

internal class x4b9a54c025a6dfc9 : xda0e2d3e80c66802
{
	private double x0be2e1701ee0682c;

	private int xa9de8b15d6d142ba;

	private double x4d440edd8b06519d;

	private ArrayList x047f3d74dc5f5da7;

	private double x52d613e82f2f0170;

	private ArrayList x1e58f3079b9b34b3;

	private int x9ba6e2d568cd6468;

	private bool x880b5692ede337f4
	{
		get
		{
			if (xa9de8b15d6d142ba == 0)
			{
				return false;
			}
			return ((xd1d18a01676074c6)x1e58f3079b9b34b3[xa9de8b15d6d142ba - 1]).x3146d638ec378671 == x644902f73993c0f3.xe6e4072a65065ef9;
		}
	}

	public ArrayList x5684e14bfcd27e00(ArrayList x64e1a5f40c1200c6, x149f0bd36fa2cea2 xb0a3951ddb0b2055)
	{
		x20aee281977480cf(x64e1a5f40c1200c6);
		while (xa9de8b15d6d142ba < x1e58f3079b9b34b3.Count)
		{
			x4d440edd8b06519d = xb0a3951ddb0b2055.xc12e7b7c206ba951();
			if (!xcf51aa681ed3c6be() && !xbb50c39b6de3f969())
			{
				x27e5a66fb9c46a36();
			}
			x49babf6761229eb5();
		}
		return x047f3d74dc5f5da7;
	}

	private void x20aee281977480cf(ArrayList x64e1a5f40c1200c6)
	{
		x047f3d74dc5f5da7 = new ArrayList();
		x1e58f3079b9b34b3 = x64e1a5f40c1200c6;
		x9ba6e2d568cd6468 = 0;
		xa9de8b15d6d142ba = 0;
		x0be2e1701ee0682c = 0.0;
		x52d613e82f2f0170 = 0.0;
	}

	private void x49babf6761229eb5()
	{
		x9725f23333d8c1d6 x9725f23333d8c1d = new x9725f23333d8c1d6(x1e58f3079b9b34b3);
		x9725f23333d8c1d.x761445bca289bae4 = x9ba6e2d568cd6468;
		x9725f23333d8c1d.xef557afa150f7cb2 = xa9de8b15d6d142ba;
		x944c43943c01324c value = new x944c43943c01324c(x4d440edd8b06519d, x9725f23333d8c1d);
		x047f3d74dc5f5da7.Add(value);
		x9ba6e2d568cd6468 = xa9de8b15d6d142ba;
		x0be2e1701ee0682c = 0.0;
		x52d613e82f2f0170 = 0.0;
	}

	private void x27e5a66fb9c46a36()
	{
		while (xa9de8b15d6d142ba < x1e58f3079b9b34b3.Count)
		{
			xd1d18a01676074c6 xd1d18a01676074c7 = (xd1d18a01676074c6)x1e58f3079b9b34b3[xa9de8b15d6d142ba];
			if (xd1d18a01676074c7.x3146d638ec378671 != x644902f73993c0f3.x3e1feffd8ca6feb2)
			{
				break;
			}
			x0be2e1701ee0682c += xd1d18a01676074c7.xbd07e3206ab4c3fa;
			xa9de8b15d6d142ba++;
		}
	}

	private bool xbb50c39b6de3f969()
	{
		while (xa9de8b15d6d142ba < x1e58f3079b9b34b3.Count)
		{
			xd1d18a01676074c6 xd1d18a01676074c7 = (xd1d18a01676074c6)x1e58f3079b9b34b3[xa9de8b15d6d142ba];
			if (xd1d18a01676074c7.x3146d638ec378671 == x644902f73993c0f3.xe6e4072a65065ef9)
			{
				xa9de8b15d6d142ba++;
				return true;
			}
			if (x0be2e1701ee0682c + xd1d18a01676074c7.xbd07e3206ab4c3fa > x4d440edd8b06519d)
			{
				return false;
			}
			x0be2e1701ee0682c += xd1d18a01676074c7.xbd07e3206ab4c3fa;
			x52d613e82f2f0170 += xd1d18a01676074c7.xbd07e3206ab4c3fa;
			xa9de8b15d6d142ba++;
		}
		return false;
	}

	private bool xcf51aa681ed3c6be()
	{
		while (xa9de8b15d6d142ba < x1e58f3079b9b34b3.Count)
		{
			xd1d18a01676074c6 xd1d18a01676074c7 = (xd1d18a01676074c6)x1e58f3079b9b34b3[xa9de8b15d6d142ba];
			x0be2e1701ee0682c += xd1d18a01676074c7.xbd07e3206ab4c3fa;
			x52d613e82f2f0170 += xd1d18a01676074c7.xbd07e3206ab4c3fa;
			if (xd1d18a01676074c7.x3146d638ec378671 == x644902f73993c0f3.xe6e4072a65065ef9)
			{
				xa9de8b15d6d142ba++;
				return true;
			}
			if (xd1d18a01676074c7.x3146d638ec378671 != x644902f73993c0f3.x3e1feffd8ca6feb2)
			{
				xa9de8b15d6d142ba++;
				return false;
			}
			xa9de8b15d6d142ba++;
		}
		return false;
	}
}
