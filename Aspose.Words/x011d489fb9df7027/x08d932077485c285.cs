using System.Drawing;

namespace x011d489fb9df7027;

internal class x08d932077485c285
{
	private readonly x06e4f09a90ca939a x7cf290e345b9b3cf;

	private readonly x06e4f09a90ca939a x7b7c4bf07166b4da;

	internal x06e4f09a90ca939a x8df91a2f90079e88 => x7cf290e345b9b3cf;

	internal x06e4f09a90ca939a xc821290d7ecc08bf => x7b7c4bf07166b4da;

	internal x08d932077485c285()
		: this(Point.Empty)
	{
	}

	internal x08d932077485c285(int x, int y)
		: this(new Point(x, y))
	{
	}

	internal x08d932077485c285(Point point)
		: this(new x06e4f09a90ca939a(point.X, isFormula: false), new x06e4f09a90ca939a(point.Y, isFormula: false))
	{
	}

	internal x08d932077485c285(x06e4f09a90ca939a x, x06e4f09a90ca939a y)
	{
		x7cf290e345b9b3cf = x;
		x7b7c4bf07166b4da = y;
	}

	public override string ToString()
	{
		return $"X:{x8df91a2f90079e88.ToString()}, Y:{xc821290d7ecc08bf.ToString()}";
	}
}
