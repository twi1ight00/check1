using System.Drawing;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;

namespace x8784bdb393e53e65;

internal class xb4fb73d10814e223
{
	private double xf89e4d8c0c78c87a;

	private double x425cabd105044908 = 1.0;

	private double xd1e8cd9beb054133 = 1.0;

	private x54366fa5f75a02f7 xca77ffeb1de872f5 = new x54366fa5f75a02f7();

	private x54366fa5f75a02f7 xbea94eec28fbd339 = new x54366fa5f75a02f7();

	private x78e18bdf9a108059 xde29b59fc6ffae80;

	private x78e18bdf9a108059 x435b26849f0d2436;

	private double x9af19d42414858cf = 1.0;

	private double x17f5bac459fd57c8 = 1.0;

	public double xcc745f39151d4b3d
	{
		get
		{
			return x9af19d42414858cf;
		}
		set
		{
			x9af19d42414858cf = value;
		}
	}

	public double x04b11f6a17897427
	{
		get
		{
			return x17f5bac459fd57c8;
		}
		set
		{
			x17f5bac459fd57c8 = value;
		}
	}

	public double x35f14aa562a2e9af
	{
		get
		{
			return x425cabd105044908;
		}
		set
		{
			x425cabd105044908 = value;
		}
	}

	public double x22322986c328aaf6
	{
		get
		{
			return xd1e8cd9beb054133;
		}
		set
		{
			xd1e8cd9beb054133 = value;
		}
	}

	public double x97b5d85eee58ec89
	{
		get
		{
			return xf89e4d8c0c78c87a;
		}
		set
		{
			xf89e4d8c0c78c87a = value;
		}
	}

	public x78e18bdf9a108059 x9d09fa9b8ac3889f
	{
		get
		{
			if (xde29b59fc6ffae80 == null)
			{
				xde29b59fc6ffae80 = new x78e18bdf9a108059();
			}
			return xde29b59fc6ffae80;
		}
		set
		{
			xde29b59fc6ffae80 = value;
		}
	}

	public x78e18bdf9a108059 xaccac17571a8d9fa
	{
		get
		{
			if (x435b26849f0d2436 == null)
			{
				x435b26849f0d2436 = new x78e18bdf9a108059();
			}
			return x435b26849f0d2436;
		}
		set
		{
			x435b26849f0d2436 = value;
		}
	}

	public x54366fa5f75a02f7 xe394e5cd36f52dce
	{
		get
		{
			return xbea94eec28fbd339;
		}
		set
		{
			xbea94eec28fbd339 = value;
		}
	}

	public x54366fa5f75a02f7 x286ed2596143aca1
	{
		get
		{
			return xca77ffeb1de872f5;
		}
		set
		{
			xca77ffeb1de872f5 = value;
		}
	}

	public xb4fb73d10814e223()
		: this(new x78e18bdf9a108059())
	{
	}

	private xb4fb73d10814e223(x78e18bdf9a108059 transform)
	{
		x9d09fa9b8ac3889f = transform;
		xaccac17571a8d9fa = transform.Clone();
	}

	public x54366fa5f75a02f7 x779d03b9e20d92f5()
	{
		PointF centerPoint = x9d09fa9b8ac3889f.CenterPoint;
		PointF centerPoint2 = xaccac17571a8d9fa.CenterPoint;
		centerPoint2 = x286ed2596143aca1.x5c785f1d561da269(centerPoint2);
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(centerPoint2.X - centerPoint.X, centerPoint2.Y - centerPoint.Y);
		float x = x9d09fa9b8ac3889f.OriginalCenterPoint.X;
		float y = x9d09fa9b8ac3889f.OriginalCenterPoint.Y;
		x54366fa5f75a02f.xce92de628aa023cf(centerPoint.X - x, centerPoint.Y - y);
		return x54366fa5f75a02f;
	}

	public x54366fa5f75a02f7 x5abbd23972d570a2()
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		float x = x9d09fa9b8ac3889f.OriginalCenterPoint.X;
		float y = x9d09fa9b8ac3889f.OriginalCenterPoint.Y;
		x54366fa5f75a02f.xce92de628aa023cf(0f - x, 0f - y, MatrixOrder.Append);
		x54366fa5f75a02f.x5152a5707921c783((float)xcc745f39151d4b3d, (float)x04b11f6a17897427, MatrixOrder.Append);
		x54366fa5f75a02f.x5152a5707921c783((float)x35f14aa562a2e9af, (float)x22322986c328aaf6, MatrixOrder.Append);
		x54366fa5f75a02f.xa77087bb05d9ef76((float)x15e971129fd80714.xc9211137ad7bfa2a(x97b5d85eee58ec89), MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(x, y, MatrixOrder.Append);
		return x54366fa5f75a02f;
	}

	public xb4fb73d10814e223 xe96b59ccb9e69142(x78e18bdf9a108059 x678241938de24d81)
	{
		xb4fb73d10814e223 xb4fb73d10814e224 = new xb4fb73d10814e223(x678241938de24d81);
		xb4fb73d10814e224.x76d9a7c8e7de4afb(this);
		xb4fb73d10814e224.x5152a5707921c783(this);
		xb4fb73d10814e224.x61c27549393ee901();
		xb4fb73d10814e224.x6965188a0c332110(this);
		return xb4fb73d10814e224;
	}

	private void x5152a5707921c783(xb4fb73d10814e223 x8a34179fa80a5b4e)
	{
		if (x6f634058fa8aeb42(x9d09fa9b8ac3889f.xa00ce09851f40ee5))
		{
			xcc745f39151d4b3d = x8a34179fa80a5b4e.x04b11f6a17897427 * (double)x9d09fa9b8ac3889f.XScale;
			x04b11f6a17897427 = x8a34179fa80a5b4e.xcc745f39151d4b3d * (double)x9d09fa9b8ac3889f.YScale;
		}
		else
		{
			xcc745f39151d4b3d = x8a34179fa80a5b4e.xcc745f39151d4b3d * (double)x9d09fa9b8ac3889f.XScale;
			x04b11f6a17897427 = x8a34179fa80a5b4e.x04b11f6a17897427 * (double)x9d09fa9b8ac3889f.YScale;
		}
	}

	private void x76d9a7c8e7de4afb(xb4fb73d10814e223 x8a34179fa80a5b4e)
	{
		PointF centerPoint = xaccac17571a8d9fa.CenterPoint;
		PointF pointF = x8a34179fa80a5b4e.xe394e5cd36f52dce.x5c785f1d561da269(centerPoint);
		xaccac17571a8d9fa.Offset(pointF.X - centerPoint.X, pointF.Y - centerPoint.Y);
		if (x6f634058fa8aeb42(x9d09fa9b8ac3889f.xa00ce09851f40ee5))
		{
			xaccac17571a8d9fa.Scale(x8a34179fa80a5b4e.x04b11f6a17897427, x8a34179fa80a5b4e.xcc745f39151d4b3d);
		}
		else
		{
			xaccac17571a8d9fa.Scale(x8a34179fa80a5b4e.xcc745f39151d4b3d, x8a34179fa80a5b4e.x04b11f6a17897427);
		}
	}

	public bool x6f634058fa8aeb42(xd4583a58cd9d2194 xcb83cdf6822fc99d)
	{
		double x95bb1b6b5e161bbe = xcb83cdf6822fc99d.x95bb1b6b5e161bbe;
		if (!(x95bb1b6b5e161bbe >= 45.0) || !(x95bb1b6b5e161bbe < 135.0))
		{
			if (x95bb1b6b5e161bbe >= 225.0)
			{
				return x95bb1b6b5e161bbe < 315.0;
			}
			return false;
		}
		return true;
	}

	private void x6965188a0c332110(xb4fb73d10814e223 x8a34179fa80a5b4e)
	{
		x54366fa5f75a02f7 x470ecea91abfd1aa = xaccac17571a8d9fa.CreateRotateFlipTransformation();
		x286ed2596143aca1 = x8a34179fa80a5b4e.x286ed2596143aca1.x8b61531c8ea35b85();
		x286ed2596143aca1.x490e30087768649f(x470ecea91abfd1aa, MatrixOrder.Prepend);
		x97b5d85eee58ec89 = x8a34179fa80a5b4e.x97b5d85eee58ec89 + x9d09fa9b8ac3889f.xa00ce09851f40ee5.xb99590eecb6a46e1;
		x35f14aa562a2e9af = x8a34179fa80a5b4e.x35f14aa562a2e9af * (x9d09fa9b8ac3889f.x1a31c5dbe3231791 ? (-1.0) : 1.0);
		x22322986c328aaf6 = x8a34179fa80a5b4e.x22322986c328aaf6 * (x9d09fa9b8ac3889f.xaf2abb0b85eac4e2 ? (-1.0) : 1.0);
	}

	private void x61c27549393ee901()
	{
		x78e18bdf9a108059 x78e18bdf9a108060 = xaccac17571a8d9fa;
		if (x78e18bdf9a108060 is x734f6a4f5af93ce5)
		{
			x734f6a4f5af93ce5 x734f6a4f5af93ce6 = (x734f6a4f5af93ce5)x78e18bdf9a108060;
			x734f6a4f5af93ce5 x734f6a4f5af93ce7 = (x734f6a4f5af93ce5)x9d09fa9b8ac3889f;
			float x3758cf4ee715d = x734f6a4f5af93ce6.x5843a3d73b66bc0a.X - x734f6a4f5af93ce7.x5843a3d73b66bc0a.X;
			float x6842879318972d9e = x734f6a4f5af93ce6.x5843a3d73b66bc0a.Y - x734f6a4f5af93ce7.x5843a3d73b66bc0a.Y;
			xe394e5cd36f52dce = x734f6a4f5af93ce6.xedfb925876619deb(xcc745f39151d4b3d, x04b11f6a17897427);
			xe394e5cd36f52dce.xce92de628aa023cf(x3758cf4ee715d, x6842879318972d9e, MatrixOrder.Prepend);
			x734f6a4f5af93ce6.xde1832b26664bc29();
		}
	}
}
