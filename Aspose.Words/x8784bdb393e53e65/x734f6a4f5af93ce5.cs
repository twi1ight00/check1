using System.Drawing;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;

namespace x8784bdb393e53e65;

internal class x734f6a4f5af93ce5 : x78e18bdf9a108059
{
	private double x3b7ba7523a2a3512;

	private double x5a54c62d4a928f23;

	private double x0ef5792af4b59d66;

	private double x28c38f7f3940bdb7;

	public double xa4b584449f2f99a5
	{
		get
		{
			return x5a54c62d4a928f23;
		}
		set
		{
			x5a54c62d4a928f23 = value;
		}
	}

	public double x33b0ce0cc41139fc
	{
		get
		{
			return x3b7ba7523a2a3512;
		}
		set
		{
			x3b7ba7523a2a3512 = value;
		}
	}

	public PointF x3ca0c542d15331bc
	{
		get
		{
			return new PointF((float)xe1376456f5ae028e, (float)x0e806ec110cd1956);
		}
		set
		{
			xe1376456f5ae028e = value.X;
			x0e806ec110cd1956 = value.Y;
		}
	}

	public double xe1376456f5ae028e
	{
		get
		{
			return x0ef5792af4b59d66;
		}
		set
		{
			x0ef5792af4b59d66 = value;
		}
	}

	public double x0e806ec110cd1956
	{
		get
		{
			return x28c38f7f3940bdb7;
		}
		set
		{
			x28c38f7f3940bdb7 = value;
		}
	}

	public override double XOffset => base.x8df91a2f90079e88 - xe1376456f5ae028e;

	public override double YOffset => base.xc821290d7ecc08bf - x0e806ec110cd1956;

	public override float XScale
	{
		get
		{
			float num = 1f;
			return num * x7b2d8319b9e8806c();
		}
	}

	public override float YScale
	{
		get
		{
			float num = 1f;
			return num * x5823696a050733fd();
		}
	}

	public PointF x5843a3d73b66bc0a => new PointF((float)(xe1376456f5ae028e + xa4b584449f2f99a5 / 2.0), (float)(x0e806ec110cd1956 + x33b0ce0cc41139fc / 2.0));

	public x54366fa5f75a02f7 xedfb925876619deb(double xb5c369f64ea369e5, double x9b8af180a4e21ec1)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		PointF pointF = x5843a3d73b66bc0a;
		PointF centerPoint = CenterPoint;
		x54366fa5f75a02f.xce92de628aa023cf(0f - pointF.X, 0f - pointF.Y, MatrixOrder.Append);
		x54366fa5f75a02f.x5152a5707921c783((float)xb5c369f64ea369e5, (float)x9b8af180a4e21ec1, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(centerPoint.X, centerPoint.Y, MatrixOrder.Append);
		return x54366fa5f75a02f;
	}

	public override x54366fa5f75a02f7 CreateRenderTransform()
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = CreateFitTransformation();
		x54366fa5f75a02f7 x470ecea91abfd1aa = CreateRotateFlipTransformation();
		x54366fa5f75a02f.x490e30087768649f(x470ecea91abfd1aa, MatrixOrder.Append);
		return x54366fa5f75a02f;
	}

	public override x54366fa5f75a02f7 CreateFitTransformation()
	{
		float num = x5823696a050733fd();
		float num2 = x7b2d8319b9e8806c();
		float m = (float)(base.x8df91a2f90079e88 - (double)num2 * xe1376456f5ae028e);
		float m2 = (float)(base.xc821290d7ecc08bf - (double)num * x0e806ec110cd1956);
		return new x54366fa5f75a02f7(num2, 0f, 0f, num, m, m2);
	}

	private float x5823696a050733fd()
	{
		if (base.x1be93eed8950d961 == 0.0 || x33b0ce0cc41139fc == 0.0)
		{
			return 1f;
		}
		return (float)(base.x1be93eed8950d961 / x33b0ce0cc41139fc);
	}

	private float x7b2d8319b9e8806c()
	{
		if (base.xdc1bf80853046136 == 0.0 || xa4b584449f2f99a5 == 0.0)
		{
			return 1f;
		}
		return (float)(base.xdc1bf80853046136 / xa4b584449f2f99a5);
	}

	public void xde1832b26664bc29()
	{
		xa4b584449f2f99a5 = base.xdc1bf80853046136;
		x33b0ce0cc41139fc = base.x1be93eed8950d961;
		xe1376456f5ae028e = base.x8df91a2f90079e88;
		x0e806ec110cd1956 = base.xc821290d7ecc08bf;
	}

	public override void Scale(double xscale, double yscale)
	{
		base.Scale(xscale, yscale);
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		PointF centerPoint = CenterPoint;
		x54366fa5f75a02f.xce92de628aa023cf(0f - centerPoint.X, 0f - centerPoint.Y, MatrixOrder.Append);
		x54366fa5f75a02f.x5152a5707921c783((float)xscale, (float)yscale, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(centerPoint.X, centerPoint.Y, MatrixOrder.Append);
		x3ca0c542d15331bc = x54366fa5f75a02f.x5c785f1d561da269(x3ca0c542d15331bc);
		x5a54c62d4a928f23 *= xscale;
		x3b7ba7523a2a3512 *= yscale;
	}

	public override x78e18bdf9a108059 Clone()
	{
		x734f6a4f5af93ce5 x734f6a4f5af93ce6 = new x734f6a4f5af93ce5();
		x0fe4f26e70030075(x734f6a4f5af93ce6);
		return x734f6a4f5af93ce6;
	}

	public override void Offset(float dx, float dy)
	{
		base.Offset(dx, dy);
		x0ef5792af4b59d66 += dx;
		x28c38f7f3940bdb7 += dy;
	}

	protected void x0fe4f26e70030075(x734f6a4f5af93ce5 x11d58b056c032b03)
	{
		x0fe4f26e70030075((x78e18bdf9a108059)x11d58b056c032b03);
		x11d58b056c032b03.x3b7ba7523a2a3512 = x3b7ba7523a2a3512;
		x11d58b056c032b03.x5a54c62d4a928f23 = x5a54c62d4a928f23;
		x11d58b056c032b03.x0ef5792af4b59d66 = x0ef5792af4b59d66;
		x11d58b056c032b03.x28c38f7f3940bdb7 = x28c38f7f3940bdb7;
	}
}
