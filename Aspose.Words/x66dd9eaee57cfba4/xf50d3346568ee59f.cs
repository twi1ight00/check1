namespace x66dd9eaee57cfba4;

internal class xf50d3346568ee59f
{
	private readonly int x7cf290e345b9b3cf;

	private readonly int x7b7c4bf07166b4da;

	private readonly int x218a4759befebb5b;

	private readonly int x4793128548cee7a0;

	private readonly bool xa02877a072d04017;

	private readonly bool xa7f3b07545b2fa62;

	private bool x6c2281ca61418b93;

	public int x44f1cfb897de980b => x218a4759befebb5b;

	public int x42aa3d9493e9841e => x4793128548cee7a0;

	public int x8df91a2f90079e88 => x7cf290e345b9b3cf;

	public int xc821290d7ecc08bf => x7b7c4bf07166b4da;

	public bool x3608e1d09b3fd55d => xa02877a072d04017;

	public bool x4792a30c8e2cad0a => xa7f3b07545b2fa62;

	public bool xc5d85e3237ac7ff9
	{
		get
		{
			return x6c2281ca61418b93;
		}
		set
		{
			x6c2281ca61418b93 = value;
		}
	}

	internal xf50d3346568ee59f(int dx, int dy, int absoluteX, int absoluteY, bool isOnCurve, bool isEndOfContour)
	{
		x218a4759befebb5b = dx;
		x4793128548cee7a0 = dy;
		x7cf290e345b9b3cf = absoluteX;
		x7b7c4bf07166b4da = absoluteY;
		xa02877a072d04017 = isOnCurve;
		xa7f3b07545b2fa62 = isEndOfContour;
	}
}
