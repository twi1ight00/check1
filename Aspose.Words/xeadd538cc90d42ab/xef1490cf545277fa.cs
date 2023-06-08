using System;

namespace xeadd538cc90d42ab;

internal class xef1490cf545277fa : xc68387e4ac42bd67
{
	private xf30d4e32a2d88aad x32fdffc6bd919408;

	private string x7cf290e345b9b3cf;

	public string x8df91a2f90079e88 => x7cf290e345b9b3cf;

	public xef1490cf545277fa(string[] formulaParts, xf30d4e32a2d88aad callback)
	{
		if (formulaParts.Length < 2)
		{
			throw new ArgumentOutOfRangeException("formulaParts", "Wrong number of formula parts.");
		}
		x7cf290e345b9b3cf = formulaParts[1];
		x32fdffc6bd919408 = callback;
	}

	public double xb1de1ba20faeeff8(x97e2c177c8bba32e x14a1b987a366146a)
	{
		double x08db3aeabb253cb = x77107e7903878ce0.x3f88a25febd23896(x8df91a2f90079e88, x14a1b987a366146a);
		return x32fdffc6bd919408.xb1de1ba20faeeff8(x08db3aeabb253cb);
	}
}
