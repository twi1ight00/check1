using System;
using System.Collections;
using x13f1efc79617a47b;

namespace x4adf554d20d941a6;

internal class x3923a5fd933905d6
{
	private static readonly object xdac3dfe986ba3c33 = new object();

	private readonly Hashtable xf78e6f768c337829;

	private x591c1d6e66408377 xb98a60faee9bf68f;

	private int xa6783d35566f8810;

	internal x591c1d6e66408377 x29e7ace4c90f74cd
	{
		get
		{
			return xb98a60faee9bf68f;
		}
		set
		{
			xb98a60faee9bf68f = value;
		}
	}

	internal bool xbfff49744222e934 => null == xf78e6f768c337829;

	public int xc1bae07e5c2f641d => xa6783d35566f8810;

	internal x3923a5fd933905d6(bool isEasy)
	{
		xb98a60faee9bf68f = new x591c1d6e66408377(this);
		xf78e6f768c337829 = (isEasy ? null : new Hashtable());
	}

	internal x591c1d6e66408377 x02b56011810c316c(object xf377779f33c1c51a)
	{
		if (xbfff49744222e934)
		{
			return null;
		}
		if (xf377779f33c1c51a == null)
		{
			xf377779f33c1c51a = xdac3dfe986ba3c33;
		}
		object obj = xf78e6f768c337829[xf377779f33c1c51a];
		if (obj == null)
		{
			return null;
		}
		if (obj is x591c1d6e66408377)
		{
			return (x591c1d6e66408377)obj;
		}
		if (obj is ArrayList)
		{
			return (x591c1d6e66408377)((ArrayList)obj)[0];
		}
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("imahinhhnnohfnfianmiondjhikjgnbkgmikfmpkemgllmnljmemhllmbmcnmgjnclaojlhodgoockfppkmpjkdackkajjbbpjibmfpb", 164262009)));
	}

	internal void x2a0cb95ab84ba877(x591c1d6e66408377 xda5bf54deb817e37)
	{
		if (xbfff49744222e934)
		{
			return;
		}
		object x02ebdc12ebf = xda5bf54deb817e37.x02ebdc12ebf86805;
		if (x02ebdc12ebf == null)
		{
			x02ebdc12ebf = xdac3dfe986ba3c33;
		}
		object obj = xf78e6f768c337829[x02ebdc12ebf];
		if (obj == null)
		{
			xf78e6f768c337829.Add(x02ebdc12ebf, xda5bf54deb817e37);
		}
		else if (obj is x591c1d6e66408377)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(obj);
			arrayList.Add(xda5bf54deb817e37);
			xf78e6f768c337829[x02ebdc12ebf] = arrayList;
		}
		else
		{
			if (!(obj is ArrayList))
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mkagmlhgbmogjlfhelmhcmdilgkiklbjkkijjkpjikgkpknknkelljllfkcmafjmgjannjhnheongifodjmonidpgikpnhbadiiaaepa", 370827357)));
			}
			((ArrayList)obj).Add(xda5bf54deb817e37);
		}
	}

	internal void xde11bc5d740d3ee3(x591c1d6e66408377 xda5bf54deb817e37)
	{
		if (xbfff49744222e934)
		{
			return;
		}
		object x02ebdc12ebf = xda5bf54deb817e37.x02ebdc12ebf86805;
		if (x02ebdc12ebf == null)
		{
			x02ebdc12ebf = xdac3dfe986ba3c33;
		}
		object obj = xf78e6f768c337829[x02ebdc12ebf];
		if (obj is x591c1d6e66408377)
		{
			xf78e6f768c337829.Remove(x02ebdc12ebf);
			return;
		}
		if (obj is ArrayList)
		{
			ArrayList arrayList = (ArrayList)obj;
			arrayList.Remove(xda5bf54deb817e37);
			if (1 == arrayList.Count)
			{
				xf78e6f768c337829[x02ebdc12ebf] = arrayList[0];
			}
			return;
		}
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hbipfdpphcgafcnanndbmclbmbcclbjckbadbchdpbodnafehbmecmcfiakfpabgjlhgipogfaghppmhipdipokifpbjclij", 991688649)));
	}

	internal x591c1d6e66408377 xc45b21733534efc0(int x10aaa7cdfa38f254, out int x959806ebd6fe6e4d, out int xd73c8df7888d6823)
	{
		x591c1d6e66408377 x591c1d6e66408378 = xb98a60faee9bf68f;
		x959806ebd6fe6e4d = 0;
		xd73c8df7888d6823 = 0;
		while (!x591c1d6e66408378.xf065f1542d0d16e9)
		{
			if (x591c1d6e66408378.x782bb6538e64cacf.x1be93eed8950d961 + x959806ebd6fe6e4d - 1 < x10aaa7cdfa38f254)
			{
				x959806ebd6fe6e4d += x591c1d6e66408378.x782bb6538e64cacf.x1be93eed8950d961;
				xd73c8df7888d6823 += x591c1d6e66408378.x782bb6538e64cacf.xd44988f225497f3a;
				x591c1d6e66408378 = x591c1d6e66408378.x0ea8d41798209f7f;
			}
			else
			{
				x591c1d6e66408378 = x591c1d6e66408378.x782bb6538e64cacf;
			}
		}
		return x591c1d6e66408378;
	}

	internal x591c1d6e66408377 xe8e30285aadb80e2(int xc0c4c459c6ccbd00, out int x959806ebd6fe6e4d)
	{
		x591c1d6e66408377 x591c1d6e66408378 = xb98a60faee9bf68f;
		int num = 0;
		int num2 = 0;
		while (!x591c1d6e66408378.xf065f1542d0d16e9)
		{
			if (x591c1d6e66408378.x782bb6538e64cacf.xd44988f225497f3a + num - 1 < xc0c4c459c6ccbd00)
			{
				num += x591c1d6e66408378.x782bb6538e64cacf.xd44988f225497f3a;
				num2 += x591c1d6e66408378.x782bb6538e64cacf.x1be93eed8950d961;
				x591c1d6e66408378 = x591c1d6e66408378.x0ea8d41798209f7f;
			}
			else
			{
				x591c1d6e66408378 = x591c1d6e66408378.x782bb6538e64cacf;
			}
		}
		x959806ebd6fe6e4d = num2;
		return x591c1d6e66408378;
	}

	internal void x34c9e5c6515a01be(x591c1d6e66408377 xda5bf54deb817e37, out int x959806ebd6fe6e4d, out int xd73c8df7888d6823)
	{
		x959806ebd6fe6e4d = 0;
		xd73c8df7888d6823 = 0;
		x591c1d6e66408377 x591c1d6e66408378 = xda5bf54deb817e37;
		while (x591c1d6e66408378.x332a8eedb847940d != null)
		{
			if (x591c1d6e66408378.x332a8eedb847940d.x0ea8d41798209f7f == x591c1d6e66408378)
			{
				x959806ebd6fe6e4d += x591c1d6e66408378.x332a8eedb847940d.x782bb6538e64cacf.x1be93eed8950d961;
				xd73c8df7888d6823 += x591c1d6e66408378.x332a8eedb847940d.x782bb6538e64cacf.xd44988f225497f3a;
			}
			x591c1d6e66408378 = x591c1d6e66408378.x332a8eedb847940d;
		}
	}

	internal void xe88ab84767e8fb69()
	{
		xa6783d35566f8810++;
	}
}
