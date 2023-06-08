using System;
using System.Collections;
using System.Drawing;
using Aspose;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;

namespace xb3013071794e5415;

internal abstract class x81ac855fc7b54c66 : x43c3197706cb18d9
{
	protected float x6e74c79ac777f020;

	protected float xf995a7a9bffac1cf;

	protected float x2cede84e47db333b;

	protected float xf63c9a791cae8f48;

	protected float x35ce44b1ebc33c3e;

	protected float x70409a7a4ff83bbb;

	protected readonly float xa2ed805d5744f18d;

	protected readonly float x37f8fa4cd48bb8c5;

	protected readonly float x5df8b15d2a132e6f;

	protected readonly float x961e824d1ebea896;

	protected readonly float x77ca88a648804658;

	protected readonly float x44cb99f0551df91f;

	protected readonly xf6f80e59810bad00 x4bba99670c27bc08;

	protected readonly xf6f80e59810bad00 x5b95c6f825b826a0;

	protected readonly bool x725e13a501f0b741;

	protected readonly xcd7d6e7318ee6574 x8cedcaa9a62c6e39;

	protected readonly RectangleF xcfb00db5f2a96790;

	private bool xde295997daa287f2;

	private bool xefa4d73e2dcb566f;

	internal float x31f3192bdc025ca5 => xcfb00db5f2a96790.Width - (xc24e3e091abd3197 + xb50d6cb9d3b61d4d);

	internal float x89a1d2c0b93619bb => xcfb00db5f2a96790.Height - (xcdb214dfc38b1be3 + xd0fade446b8d532a);

	public float xc24e3e091abd3197 => x6e74c79ac777f020;

	public float xb50d6cb9d3b61d4d => xf995a7a9bffac1cf;

	public float xcdb214dfc38b1be3 => x2cede84e47db333b;

	public float xd0fade446b8d532a => xf63c9a791cae8f48;

	internal x81ac855fc7b54c66(xf6f80e59810bad00 x, xf6f80e59810bad00 y, xcd7d6e7318ee6574 context, RectangleF targetRect)
	{
		if (x.x456aa8157ebf3510 != y.xb1cd0e7571a46f8e)
		{
			throw new ArgumentException("Abscissa must cross ordinate.");
		}
		x8cedcaa9a62c6e39 = context;
		x725e13a501f0b741 = y.xe0fa967e49e5e7e4;
		x4bba99670c27bc08 = (x725e13a501f0b741 ? x : y);
		x5b95c6f825b826a0 = (x725e13a501f0b741 ? y : x);
		xcfb00db5f2a96790 = targetRect;
		x35ce44b1ebc33c3e = x318f74746d616ef0.xa9c9583c571d7dc3(x4bba99670c27bc08.x68955bfadd010132, x8cedcaa9a62c6e39, x461bfa5b6ec21819: false);
		x70409a7a4ff83bbb = x318f74746d616ef0.xa9c9583c571d7dc3(x5b95c6f825b826a0.x68955bfadd010132, x8cedcaa9a62c6e39, x461bfa5b6ec21819: false);
		xa2ed805d5744f18d = x35ce44b1ebc33c3e / 4f;
		x37f8fa4cd48bb8c5 = x70409a7a4ff83bbb / 4f;
		x961e824d1ebea896 = x70409a7a4ff83bbb / 2f;
		x5df8b15d2a132e6f = x35ce44b1ebc33c3e / 2f;
		x77ca88a648804658 = xa2ed805d5744f18d + x35ce44b1ebc33c3e * ((float)x4bba99670c27bc08.xda3b208c694708c9 / 200f);
		x44cb99f0551df91f = x37f8fa4cd48bb8c5 + x70409a7a4ff83bbb * ((float)x5b95c6f825b826a0.xda3b208c694708c9 / 200f);
	}

	public abstract PointF x2206903f9421fd4b(float xe13ad605e0d03723, float xfb4c1c76fc5d2a6f);

	public PointF[] x466c8609d8f6c6c1(x9b87766ad1dbe8d6 x7acb8518c8ed6133)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < x7acb8518c8ed6133.x2205bab75ecf5743; i++)
		{
			x86270791cf6a92b9 x86270791cf6a92b = x7acb8518c8ed6133.x3440cb7904436598.x2206903f9421fd4b(i);
			x86270791cf6a92b9 x86270791cf6a92b2 = x7acb8518c8ed6133.x141ab7d3c1198e04.x2206903f9421fd4b(i);
			if (x86270791cf6a92b != null && x86270791cf6a92b2 != null)
			{
				arrayList.Add(x2206903f9421fd4b(x86270791cf6a92b.FloatValue, x86270791cf6a92b2.FloatValue));
			}
		}
		PointF[] array = new PointF[arrayList.Count];
		arrayList.CopyTo(array, 0);
		return array;
	}

	public abstract PointF xeed202914e7c06d3();

	public void xac399403da6cb85d()
	{
		if (!xde295997daa287f2)
		{
			if (!x4bba99670c27bc08.xddae736767606eb7)
			{
				RenderAbscissaCore();
			}
			if (!x5b95c6f825b826a0.xddae736767606eb7)
			{
				RenderOrdinateCore();
			}
			xde295997daa287f2 = true;
		}
	}

	[JavaThrows(true)]
	protected abstract void RenderAbscissaCore();

	[JavaThrows(true)]
	protected abstract void RenderOrdinateCore();

	protected void x2aa9cfe9d4739314(x86270791cf6a92b9 x37cf7043760b312e, bool xbdf72c3946853da4)
	{
		xf6f80e59810bad00 xf6f80e59810bad = (xbdf72c3946853da4 ? x5b95c6f825b826a0 : x4bba99670c27bc08);
		if (!xf6f80e59810bad.x06518e3dac8eadee)
		{
			string text = xf6f80e59810bad.xd8b4d728ebd381eb(x37cf7043760b312e);
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				float labelWidth = x318f74746d616ef0.xce9adc25a876be06(text, xf6f80e59810bad.x68955bfadd010132, x8cedcaa9a62c6e39, x461bfa5b6ec21819: false);
				float labelHeight = x318f74746d616ef0.xa9c9583c571d7dc3(xf6f80e59810bad.x68955bfadd010132, x8cedcaa9a62c6e39, x461bfa5b6ec21819: false);
				RenderLabelCore(x37cf7043760b312e.FloatValue, text, labelWidth, labelHeight, xbdf72c3946853da4);
			}
		}
	}

	[JavaThrows(true)]
	protected abstract void RenderLabelCore(float val, string label, float labelWidth, float labelHeight, bool isRenderOrdinate);

	public void x5006720129e0cf11()
	{
		if (!xefa4d73e2dcb566f)
		{
			if (!x4bba99670c27bc08.xddae736767606eb7)
			{
				RenderAbscissaGridlinesCore();
			}
			if (!x5b95c6f825b826a0.xddae736767606eb7)
			{
				RenderOrdinateGridlinesCore();
			}
			xefa4d73e2dcb566f = true;
		}
	}

	[JavaThrows(true)]
	protected abstract void RenderAbscissaGridlinesCore();

	[JavaThrows(true)]
	protected abstract void RenderOrdinateGridlinesCore();

	protected void x2e726fc92e4398c6(bool x08b8b1b344c66023)
	{
		CalculateOffsetsCore();
		if (x08b8b1b344c66023)
		{
			x6e74c79ac777f020 = ((x6e74c79ac777f020 > xcfb00db5f2a96790.X) ? (x6e74c79ac777f020 - xcfb00db5f2a96790.X) : 0f);
			x2cede84e47db333b = ((x2cede84e47db333b > xcfb00db5f2a96790.Y) ? (x2cede84e47db333b - xcfb00db5f2a96790.Y) : 0f);
			xf995a7a9bffac1cf = ((xf995a7a9bffac1cf > x8cedcaa9a62c6e39.x43e348908d6e68da.Width - xcfb00db5f2a96790.Right) ? (xf995a7a9bffac1cf - (x8cedcaa9a62c6e39.x43e348908d6e68da.Width - xcfb00db5f2a96790.Right)) : 0f);
			xf63c9a791cae8f48 = ((xf63c9a791cae8f48 > x8cedcaa9a62c6e39.x43e348908d6e68da.Height - xcfb00db5f2a96790.Bottom) ? (xf63c9a791cae8f48 - (x8cedcaa9a62c6e39.x43e348908d6e68da.Height - xcfb00db5f2a96790.Bottom)) : 0f);
		}
	}

	[JavaThrows(true)]
	protected abstract void CalculateOffsetsCore();

	public void x9d75576ac28fd38a(float xa447fc54e41dfe06, float xfc2074a859a5db8c, float xc941868c59399d3e, float xaf9a0436a70689de)
	{
		x6e74c79ac777f020 = Math.Max(x6e74c79ac777f020, xa447fc54e41dfe06);
		xf995a7a9bffac1cf = Math.Max(xf995a7a9bffac1cf, xfc2074a859a5db8c);
		x2cede84e47db333b = Math.Max(x2cede84e47db333b, xc941868c59399d3e);
		xf63c9a791cae8f48 = Math.Max(xf63c9a791cae8f48, xaf9a0436a70689de);
	}

	public virtual RectangleF xb7d97a6d836eba66()
	{
		return new RectangleF(x6e74c79ac777f020, x2cede84e47db333b, x31f3192bdc025ca5, x89a1d2c0b93619bb);
	}

	protected void xabef526900561ce8(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, xbc46977eebea4733 x82f66163e01f713f)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(x10aaa7cdfa38f254, xca09b6c2b5b18485);
		xab391c46ff9a0a.x9e5d5f9128c69a8f = x318f74746d616ef0.x2f0c16e51db81725(x82f66163e01f713f, x8cedcaa9a62c6e39.x5e969e12ada2aab2.xa42a8eb21319f8e0, 0);
		x8cedcaa9a62c6e39.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xab391c46ff9a0a);
	}

	protected void xef7f37aedd224924(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, xbc46977eebea4733 x82f66163e01f713f)
	{
		xef7f37aedd224924(new PointF[2] { x10aaa7cdfa38f254, xca09b6c2b5b18485 }, x82f66163e01f713f);
	}

	protected void xef7f37aedd224924(PointF[] x6fa2570084b2ad39, xbc46977eebea4733 x82f66163e01f713f)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xa7b580afa8756d69(x6fa2570084b2ad39, x7a848427f2a9a3b5: false);
		xab391c46ff9a0a.x9e5d5f9128c69a8f = x318f74746d616ef0.x2f0c16e51db81725(x82f66163e01f713f, x8cedcaa9a62c6e39.x5e969e12ada2aab2.x3d64cd96ed6b6560, 0);
		x8cedcaa9a62c6e39.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xab391c46ff9a0a);
	}

	protected xb8e7e788f6d59708 x96cae28a54d522c4(string xf1ada4e1b58a331d, PointF x9c3c185e7046dc72, xbc46977eebea4733 x82f66163e01f713f, x4694a3400bb4849a x5d73ec97767a1b0c)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xcc8c7739d82c63ba xcc8c7739d82c63ba = x318f74746d616ef0.x67e197bbfa6da21d(xf1ada4e1b58a331d, x9c3c185e7046dc72, x5d73ec97767a1b0c, x8cedcaa9a62c6e39, x461bfa5b6ec21819: false);
		RectangleF x26545669838eb36e = new RectangleF(x9c3c185e7046dc72.X, x9c3c185e7046dc72.Y, x4574ea26106f0edb.x3aa08882c9feaf96(xcc8c7739d82c63ba.x437e3b626c0fdd43.Width), x4574ea26106f0edb.x3aa08882c9feaf96(xcc8c7739d82c63ba.x437e3b626c0fdd43.Height));
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(x26545669838eb36e);
		xab391c46ff9a0a.x60465f602599d327 = x318f74746d616ef0.xa3fa1ce4ffca3dc3(x82f66163e01f713f, x8cedcaa9a62c6e39.x5e969e12ada2aab2.x6fb6c0caf80d65aa, 0, xab391c46ff9a0a);
		if (xab391c46ff9a0a.x60465f602599d327 != null && !xab391c46ff9a0a.x60465f602599d327.IsEmpty)
		{
			xb8e7e788f6d.xd6b6ed77479ef68c(xab391c46ff9a0a);
		}
		xb8e7e788f6d.xd6b6ed77479ef68c(xcc8c7739d82c63ba);
		return xb8e7e788f6d;
	}
}
