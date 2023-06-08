using System.Drawing;
using System.Drawing.Drawing2D;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x996431aaaaf00543;

internal class xe56ce0e761e4e9ea
{
	private RectangleF x18847e4f94b14ff7;

	private xb8e7e788f6d59708 x9b1777152cf410e1;

	public xb8e7e788f6d59708 xa1eafe7821eb4aab
	{
		get
		{
			return x9b1777152cf410e1;
		}
		set
		{
			x9b1777152cf410e1 = value;
		}
	}

	public RectangleF x2727839aafc09868
	{
		get
		{
			return x18847e4f94b14ff7;
		}
		set
		{
			x18847e4f94b14ff7 = value;
		}
	}

	internal xe56ce0e761e4e9ea(xb8e7e788f6d59708 canvas, RectangleF boundingBox)
	{
		x9b1777152cf410e1 = canvas;
		x18847e4f94b14ff7 = boundingBox;
	}

	public void xd73aad34130a5d8c(x56ef2519e07fdbb4 x10154c16e21df88a)
	{
		xeb74be576dcd2dd2 xeb74be576dcd2dd = new xeb74be576dcd2dd2();
		xeb74be576dcd2dd.x5152a5707921c783(xa1eafe7821eb4aab, x56ef2519e07fdbb4.x47af1ea15cab9bcc, x10154c16e21df88a);
		x2727839aafc09868 = xeb74be576dcd2dd.x15757bad678c94c4(x2727839aafc09868);
	}

	public void x1601b59463fd995a(SizeF x1fdaf3ec82d4585f)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = xba90bf0e4e89f21a(x2727839aafc09868, x1fdaf3ec82d4585f);
		xa1eafe7821eb4aab.x52dde376accdec7d.x490e30087768649f(x54366fa5f75a02f, MatrixOrder.Append);
		x2727839aafc09868 = x15757bad678c94c4(x2727839aafc09868, x54366fa5f75a02f);
	}

	public void xf866d88e8aa6d4a3(float x2f9aa2aec94ad2fb, float x55a22ee0f14038b3, SizeF x18083f4304fe7f89)
	{
		float xb5c369f64ea369e = ((x2f9aa2aec94ad2fb == 0f) ? 1f : (x18083f4304fe7f89.Width / x2f9aa2aec94ad2fb));
		float x9b8af180a4e21ec = ((x55a22ee0f14038b3 == 0f) ? 1f : (x18083f4304fe7f89.Height / x55a22ee0f14038b3));
		if (xa1eafe7821eb4aab.x52dde376accdec7d == null)
		{
			xa1eafe7821eb4aab.x52dde376accdec7d = new x54366fa5f75a02f7();
		}
		xa1eafe7821eb4aab.x52dde376accdec7d.x5152a5707921c783(xb5c369f64ea369e, x9b8af180a4e21ec, MatrixOrder.Append);
	}

	private static RectangleF x15757bad678c94c4(RectangleF xa688a683bf2cfced, x54366fa5f75a02f7 x7b9139c2243148be)
	{
		PointF[] array = new PointF[2]
		{
			new PointF(xa688a683bf2cfced.Left, xa688a683bf2cfced.Top),
			new PointF(xa688a683bf2cfced.Right, xa688a683bf2cfced.Bottom)
		};
		x7b9139c2243148be.xa4b699bd47eb7372(array);
		float width = array[1].X - array[0].X;
		float height = array[1].Y - array[0].Y;
		return new RectangleF(array[0], new SizeF(width, height));
	}

	private static x54366fa5f75a02f7 xba90bf0e4e89f21a(RectangleF x3c5961d0baf2cbd4, SizeF x1fdaf3ec82d4585f)
	{
		double num = (float)x4574ea26106f0edb.x3aa08882c9feaf96(x1fdaf3ec82d4585f.Width) / x3c5961d0baf2cbd4.Width;
		double num2 = (float)x4574ea26106f0edb.x3aa08882c9feaf96(x1fdaf3ec82d4585f.Height) / x3c5961d0baf2cbd4.Height;
		return new x54366fa5f75a02f7((float)num, 0f, 0f, (float)num2, 0f, 0f);
	}
}
