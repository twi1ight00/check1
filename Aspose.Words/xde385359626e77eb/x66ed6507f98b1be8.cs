using System;

namespace xde385359626e77eb;

internal class x66ed6507f98b1be8
{
	private double x4e9cab8231980d71;

	private double xf62c92dc7d224a98;

	internal double xf41d956c067e2b4d
	{
		get
		{
			return x4e9cab8231980d71;
		}
		set
		{
			x4e9cab8231980d71 = value;
		}
	}

	internal double x9f4c543928c73298
	{
		get
		{
			return xf62c92dc7d224a98;
		}
		set
		{
			xf62c92dc7d224a98 = value;
		}
	}

	internal void xd6b6ed77479ef68c(double xbcea506a33cf9111)
	{
		x4e9cab8231980d71 += xbcea506a33cf9111;
		xf62c92dc7d224a98 += xbcea506a33cf9111;
	}

	internal void x295cb4a1df7a5add(x66ed6507f98b1be8 x6e304abf38447e30)
	{
		x4e9cab8231980d71 = Math.Max(x4e9cab8231980d71, x6e304abf38447e30.xf41d956c067e2b4d);
		xf62c92dc7d224a98 = Math.Max(xf62c92dc7d224a98, x6e304abf38447e30.x9f4c543928c73298);
	}

	internal x66ed6507f98b1be8 x8b61531c8ea35b85()
	{
		x66ed6507f98b1be8 x66ed6507f98b1be9 = new x66ed6507f98b1be8();
		x66ed6507f98b1be9.xf41d956c067e2b4d = x4e9cab8231980d71;
		x66ed6507f98b1be9.x9f4c543928c73298 = xf62c92dc7d224a98;
		return x66ed6507f98b1be9;
	}
}
