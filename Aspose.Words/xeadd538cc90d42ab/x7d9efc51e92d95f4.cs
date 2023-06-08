using System;

namespace xeadd538cc90d42ab;

internal class x7d9efc51e92d95f4 : xc68387e4ac42bd67
{
	private x577b8069226d6050 x32fdffc6bd919408;

	private string x7cf290e345b9b3cf;

	private string x7b7c4bf07166b4da;

	private string x66a07f4e5b3cbf17;

	public string x8df91a2f90079e88 => x7cf290e345b9b3cf;

	public string xc821290d7ecc08bf => x7b7c4bf07166b4da;

	public string xe7189024fdf97d87 => x66a07f4e5b3cbf17;

	public x7d9efc51e92d95f4(string[] formulaParts, x577b8069226d6050 callback)
	{
		if (formulaParts.Length < 4)
		{
			throw new ArgumentOutOfRangeException("formulaParts", "Wrong number of formula parts.");
		}
		x7cf290e345b9b3cf = formulaParts[1];
		x7b7c4bf07166b4da = formulaParts[2];
		x66a07f4e5b3cbf17 = formulaParts[3];
		x32fdffc6bd919408 = callback;
	}

	public double xb1de1ba20faeeff8(x97e2c177c8bba32e x14a1b987a366146a)
	{
		double x08db3aeabb253cb = x77107e7903878ce0.x3f88a25febd23896(x8df91a2f90079e88, x14a1b987a366146a);
		double x1e218ceaee1bb = x77107e7903878ce0.x3f88a25febd23896(xc821290d7ecc08bf, x14a1b987a366146a);
		double x8cfbc105c29e356f = x77107e7903878ce0.x3f88a25febd23896(xe7189024fdf97d87, x14a1b987a366146a);
		return x32fdffc6bd919408.xb1de1ba20faeeff8(x08db3aeabb253cb, x1e218ceaee1bb, x8cfbc105c29e356f);
	}
}
