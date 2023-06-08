using System;
using System.Drawing;

namespace x5794c252ba25e723;

internal class x5f55370cc09dd787 : xf022bb98711420db
{
	private double xf97d0c1597f1aa49;

	private x26d9ecb4bdf0456d xce74fe279b271ee4 = x26d9ecb4bdf0456d.x45260ad4b94166f2;

	private bool x93109288a153f7df;

	private RectangleF x0547642127c387f6 = RectangleF.Empty;

	private x26d9ecb4bdf0456d x14316cf167486494 = x26d9ecb4bdf0456d.x45260ad4b94166f2;

	public RectangleF x404d528fe2f10961
	{
		get
		{
			return x0547642127c387f6;
		}
		set
		{
			x0547642127c387f6 = value;
		}
	}

	public x26d9ecb4bdf0456d x7d2dc175c2f289c5
	{
		get
		{
			return x14316cf167486494;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			x14316cf167486494 = value;
		}
	}

	public x26d9ecb4bdf0456d xf3874816968aabd7
	{
		get
		{
			return xce74fe279b271ee4;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			xce74fe279b271ee4 = value;
		}
	}

	public bool xbeaac435f753b9e3
	{
		get
		{
			return x93109288a153f7df;
		}
		set
		{
			x93109288a153f7df = value;
		}
	}

	public double x6b1fe03343d9a6a4
	{
		get
		{
			return xf97d0c1597f1aa49;
		}
		set
		{
			xf97d0c1597f1aa49 = value;
		}
	}

	public x5f55370cc09dd787(RectangleF rect, x26d9ecb4bdf0456d startColor, x26d9ecb4bdf0456d endColor)
		: base(x0b257a9fb413b6c3.x37b6ad6b01d0c641)
	{
		if (rect.Width == 0f || rect.Height == 0f)
		{
			throw new ArgumentException($"Rectangle '{rect}' cannot have a width or height equal to 0.");
		}
		x404d528fe2f10961 = rect;
		x7d2dc175c2f289c5 = startColor;
		xf3874816968aabd7 = endColor;
	}

	public x5f55370cc09dd787(RectangleF rect)
		: this(rect, x26d9ecb4bdf0456d.x45260ad4b94166f2, x26d9ecb4bdf0456d.x45260ad4b94166f2)
	{
	}

	public x5f55370cc09dd787(RectangleF rect, double angle, bool isScaled)
		: this(rect, x26d9ecb4bdf0456d.x45260ad4b94166f2, x26d9ecb4bdf0456d.x45260ad4b94166f2)
	{
		xf97d0c1597f1aa49 = angle;
		x93109288a153f7df = isScaled;
	}
}
