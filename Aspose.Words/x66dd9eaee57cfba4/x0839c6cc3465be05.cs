using System;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x0839c6cc3465be05 : xba15250b3f24fd3a
{
	private const int xfd66141ae953d810 = 131070;

	private readonly xd8cce4761dc846ee x2b378328508af41b = new xd8cce4761dc846ee();

	private bool x631b392d1f9f57ae;

	public bool x3ac3494a627eff42
	{
		get
		{
			return x631b392d1f9f57ae;
		}
		set
		{
			x631b392d1f9f57ae = value;
		}
	}

	public xd8cce4761dc846ee x959ba539d7cca7fe => x2b378328508af41b;

	public x0839c6cc3465be05()
	{
	}

	public x0839c6cc3465be05(bool isLocaShort)
	{
		x631b392d1f9f57ae = isLocaShort;
	}

	public static x0839c6cc3465be05 x06b0e25aa6ad68a9(xa8866d7566da0aa2 xe134235b3526fa75, uint x845d1395dde08c9f, bool xc36cba6b806504dc)
	{
		x0839c6cc3465be05 x0839c6cc3465be6 = new x0839c6cc3465be05(xc36cba6b806504dc);
		if (xc36cba6b806504dc)
		{
			int num = (int)(x845d1395dde08c9f / 2u);
			for (int i = 0; i < num; i++)
			{
				x0839c6cc3465be6.x959ba539d7cca7fe.xd6b6ed77479ef68c(xe134235b3526fa75.xdb264d863790ee7b() * 2);
			}
		}
		else
		{
			int num2 = (int)(x845d1395dde08c9f / 4u);
			for (int j = 0; j < num2; j++)
			{
				x0839c6cc3465be6.x959ba539d7cca7fe.xd6b6ed77479ef68c(xe134235b3526fa75.x95ea7d23cc8ee04d());
			}
		}
		return x0839c6cc3465be6;
	}

	internal override void x6210059f049f0d48(x73087173962e3778 xbdfb620b7167944b)
	{
		for (int i = 0; i < x959ba539d7cca7fe.xd44988f225497f3a; i++)
		{
			if (x3ac3494a627eff42)
			{
				xbdfb620b7167944b.xab5f6b7526efa5be(x959ba539d7cca7fe.get_xe6d4b1b411ed94b5(i) / 2);
			}
			else
			{
				xbdfb620b7167944b.x6ff7c65ed4805c27(x959ba539d7cca7fe.get_xe6d4b1b411ed94b5(i));
			}
		}
	}

	public void x6889630987e71a3d()
	{
		int num = 0;
		for (int i = 0; i < x959ba539d7cca7fe.xd44988f225497f3a; i++)
		{
			if (x959ba539d7cca7fe.get_xe6d4b1b411ed94b5(i) % 2 != 0)
			{
				x3ac3494a627eff42 = false;
				return;
			}
			num = Math.Max(num, x959ba539d7cca7fe.get_xe6d4b1b411ed94b5(i));
		}
		x3ac3494a627eff42 = num <= 131070;
	}
}
