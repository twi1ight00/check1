namespace x4adf554d20d941a6;

internal class xee65f8567b84ecd3 : x56410a8dd70087c5
{
	private int x823c6b25cc2689d8 = 1;

	private int xcba6747ccd6f360f;

	internal override int x5566e2d2acbd1fbe => 10754;

	internal override string xf9ad6fb78355fe13 => new string(' ', x1be93eed8950d961);

	internal override int x1be93eed8950d961 => x823c6b25cc2689d8;

	internal override int xdc1bf80853046136 => base.xdc1bf80853046136 + xcba6747ccd6f360f * x1be93eed8950d961;

	internal xee65f8567b84ecd3(int spanLength)
	{
		x823c6b25cc2689d8 = spanLength;
	}

	internal override x56410a8dd70087c5 x3df13c9311a0ba9b(int xa5e2f199f263bb67, xf3f447691ab38eee x250b730873d21d7e)
	{
		xee65f8567b84ecd3 xee65f8567b84ecd4 = new xee65f8567b84ecd3(xa5e2f199f263bb67);
		x823c6b25cc2689d8 -= xa5e2f199f263bb67;
		xcba6747ccd6f360f = 0;
		x177e1a50bb5d875e(xee65f8567b84ecd4, x250b730873d21d7e);
		return xee65f8567b84ecd4;
	}

	internal override bool xd5da23b762ce52a2()
	{
		if (!x6e4910c886fbecbd(xfc6971c7d8314663.x3e1feffd8ca6feb2))
		{
			return false;
		}
		x823c6b25cc2689d8 += base.x61712f0b4f5455af.x1be93eed8950d961;
		xb84f3af21cca2d16();
		return true;
	}

	internal override int xc7c6550a888abaf3(int xc0c4c459c6ccbd00)
	{
		int num = base.x705ed5f9769744e5.x7537b54a407680bd(base.x705ed5f9769744e5.xc2d4efc42998d87b.xbd8bafb15a2ab581(32), 1);
		return num + xcba6747ccd6f360f + xa89bfdfab6890022(xc0c4c459c6ccbd00);
	}

	internal override int x795e09a07e435cf4(int xc0c4c459c6ccbd00)
	{
		int num = ((xc0c4c459c6ccbd00 != 0) ? (xc0c4c459c6ccbd00 * xc7c6550a888abaf3(0)) : 0);
		if (0 < xc0c4c459c6ccbd00)
		{
			num += xa89bfdfab6890022(0);
		}
		return num;
	}

	internal override void x32854f318cf1c144(int xbcea506a33cf9111)
	{
		xcba6747ccd6f360f = xbcea506a33cf9111;
	}

	internal override void x77432db484f838c2()
	{
		x32854f318cf1c144(0);
		base.x77432db484f838c2();
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new xee65f8567b84ecd3(x1be93eed8950d961);
		}
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x783fd794a324ac5e(this);
	}
}
