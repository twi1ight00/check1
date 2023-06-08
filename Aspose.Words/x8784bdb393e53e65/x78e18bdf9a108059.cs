using System.Drawing;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;
using x6b8130194ad714f7;

namespace x8784bdb393e53e65;

internal class x78e18bdf9a108059
{
	private bool xcffcac4e12774914;

	private double x823c6b25cc2689d8;

	private xd4583a58cd9d2194 xd947a1427e8fd0f4 = new xd4583a58cd9d2194();

	private bool xdfe3dc4f1022a95b;

	private double xd74c65b8d28b1740;

	private double x7cf290e345b9b3cf;

	private double x7b7c4bf07166b4da;

	public bool x1a31c5dbe3231791
	{
		get
		{
			return xcffcac4e12774914;
		}
		set
		{
			xcffcac4e12774914 = value;
		}
	}

	public bool xaf2abb0b85eac4e2
	{
		get
		{
			return xdfe3dc4f1022a95b;
		}
		set
		{
			xdfe3dc4f1022a95b = value;
		}
	}

	public xd4583a58cd9d2194 xa00ce09851f40ee5
	{
		get
		{
			return xd947a1427e8fd0f4;
		}
		set
		{
			xd947a1427e8fd0f4 = value;
		}
	}

	public double xdc1bf80853046136
	{
		get
		{
			return xd74c65b8d28b1740;
		}
		set
		{
			xd74c65b8d28b1740 = value;
		}
	}

	public double x1be93eed8950d961
	{
		get
		{
			return x823c6b25cc2689d8;
		}
		set
		{
			x823c6b25cc2689d8 = value;
		}
	}

	public double x8df91a2f90079e88
	{
		get
		{
			return x7cf290e345b9b3cf;
		}
		set
		{
			x7cf290e345b9b3cf = value;
		}
	}

	public double xc821290d7ecc08bf
	{
		get
		{
			return x7b7c4bf07166b4da;
		}
		set
		{
			x7b7c4bf07166b4da = value;
		}
	}

	public PointF xc3ae914e60da748f
	{
		get
		{
			return new PointF((float)x8df91a2f90079e88, (float)xc821290d7ecc08bf);
		}
		set
		{
			x8df91a2f90079e88 = value.X;
			xc821290d7ecc08bf = value.Y;
		}
	}

	public RectangleF x2727839aafc09868 => new RectangleF((float)x8df91a2f90079e88, (float)xc821290d7ecc08bf, (float)xdc1bf80853046136, (float)x1be93eed8950d961);

	public virtual PointF OriginalCenterPoint => new PointF((float)(xdc1bf80853046136 / 2.0), (float)(x1be93eed8950d961 / 2.0));

	public virtual PointF CenterPoint => new PointF((float)(x8df91a2f90079e88 + xdc1bf80853046136 / 2.0), (float)(xc821290d7ecc08bf + x1be93eed8950d961 / 2.0));

	public virtual float XScale => 1f;

	public virtual float YScale => 1f;

	public virtual double XOffset => x8df91a2f90079e88;

	public virtual double YOffset => xc821290d7ecc08bf;

	public SizeF x5bc9adfc9699501f()
	{
		return new SizeF((float)xdc1bf80853046136, (float)x1be93eed8950d961);
	}

	public virtual x54366fa5f75a02f7 CreateFitTransformation()
	{
		return new x54366fa5f75a02f7(1f, 0f, 0f, 1f, (float)x8df91a2f90079e88, (float)xc821290d7ecc08bf);
	}

	public virtual x54366fa5f75a02f7 CreateRenderTransform()
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = CreateFitTransformation();
		x54366fa5f75a02f7 x470ecea91abfd1aa = CreateRotateFlipTransformation();
		x54366fa5f75a02f.x490e30087768649f(x470ecea91abfd1aa, MatrixOrder.Append);
		return x54366fa5f75a02f;
	}

	public virtual x54366fa5f75a02f7 CreateRotateFlipTransformation()
	{
		PointF centerPoint = CenterPoint;
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(0f - centerPoint.X, 0f - centerPoint.Y, MatrixOrder.Append);
		float xb5c369f64ea369e = (x1a31c5dbe3231791 ? (-1f) : 1f);
		float x9b8af180a4e21ec = (xaf2abb0b85eac4e2 ? (-1f) : 1f);
		x54366fa5f75a02f.x5152a5707921c783(xb5c369f64ea369e, x9b8af180a4e21ec, MatrixOrder.Append);
		x54366fa5f75a02f.xa77087bb05d9ef76((float)xa00ce09851f40ee5.x95bb1b6b5e161bbe, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(centerPoint.X, centerPoint.Y, MatrixOrder.Append);
		return x54366fa5f75a02f;
	}

	public virtual void Scale(double xscale, double yscale)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		PointF centerPoint = CenterPoint;
		x54366fa5f75a02f.xce92de628aa023cf(0f - centerPoint.X, 0f - centerPoint.Y, MatrixOrder.Append);
		x54366fa5f75a02f.x5152a5707921c783((float)xscale, (float)yscale, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(centerPoint.X, centerPoint.Y, MatrixOrder.Append);
		xc3ae914e60da748f = x54366fa5f75a02f.x5c785f1d561da269(xc3ae914e60da748f);
		xd74c65b8d28b1740 *= xscale;
		x823c6b25cc2689d8 *= yscale;
	}

	public virtual void Offset(float dx, float dy)
	{
		x7cf290e345b9b3cf += dx;
		x7b7c4bf07166b4da += dy;
	}

	public virtual x78e18bdf9a108059 Clone()
	{
		x78e18bdf9a108059 x78e18bdf9a108060 = new x78e18bdf9a108059();
		x0fe4f26e70030075(x78e18bdf9a108060);
		return x78e18bdf9a108060;
	}

	protected void x0fe4f26e70030075(x78e18bdf9a108059 x11d58b056c032b03)
	{
		x11d58b056c032b03.xcffcac4e12774914 = xcffcac4e12774914;
		x11d58b056c032b03.x823c6b25cc2689d8 = x823c6b25cc2689d8;
		x11d58b056c032b03.xd947a1427e8fd0f4 = xd947a1427e8fd0f4;
		x11d58b056c032b03.xdfe3dc4f1022a95b = xdfe3dc4f1022a95b;
		x11d58b056c032b03.xd74c65b8d28b1740 = xd74c65b8d28b1740;
		x11d58b056c032b03.x7cf290e345b9b3cf = x7cf290e345b9b3cf;
		x11d58b056c032b03.x7b7c4bf07166b4da = x7b7c4bf07166b4da;
	}
}
