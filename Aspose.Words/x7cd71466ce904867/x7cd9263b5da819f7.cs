using System;

namespace x7cd71466ce904867;

internal class x7cd9263b5da819f7 : x5725b63233877cf4
{
	private double xb2481c788615bc4f;

	private double x11782780fcf0fd17;

	private double xa05ac4bc2dfd6d7b;

	public double x3f80ed349f729542
	{
		get
		{
			return xb2481c788615bc4f;
		}
		set
		{
			xb2481c788615bc4f = value;
		}
	}

	public double x84bbacdc1fc0efd2
	{
		get
		{
			return xa05ac4bc2dfd6d7b;
		}
		set
		{
			xa05ac4bc2dfd6d7b = value;
		}
	}

	public double xc9f7bec53c29c691
	{
		get
		{
			return x11782780fcf0fd17;
		}
		set
		{
			x11782780fcf0fd17 = value;
		}
	}

	public double xb0f146032f47c24e => xb2481c788615bc4f + x11782780fcf0fd17;

	public x7cd9263b5da819f7()
	{
	}

	public x7cd9263b5da819f7(double ascent, double descent, double lineSpacing)
	{
		x3f80ed349f729542 = ascent;
		xc9f7bec53c29c691 = descent;
		x84bbacdc1fc0efd2 = lineSpacing;
	}

	public void xd6b6ed77479ef68c(x5725b63233877cf4 x1278dfc3e46eefff)
	{
		if (x1278dfc3e46eefff != null)
		{
			x3f80ed349f729542 = Math.Max(xb2481c788615bc4f, x1278dfc3e46eefff.x3f80ed349f729542);
			xc9f7bec53c29c691 = Math.Max(x11782780fcf0fd17, x1278dfc3e46eefff.xc9f7bec53c29c691);
			x84bbacdc1fc0efd2 = Math.Max(xa05ac4bc2dfd6d7b, x1278dfc3e46eefff.x84bbacdc1fc0efd2);
		}
	}

	public void x74f5a1ef3906e23c()
	{
		x3f80ed349f729542 = 0.0;
		xc9f7bec53c29c691 = 0.0;
		x84bbacdc1fc0efd2 = 0.0;
	}
}
