using System;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;

namespace xb3013071794e5415;

internal class x760100a488bf9b75 : x81ac855fc7b54c66
{
	internal float xc46af5788022f70e
	{
		get
		{
			if (!(base.x31f3192bdc025ca5 > base.x89a1d2c0b93619bb))
			{
				return base.x31f3192bdc025ca5 / 2f;
			}
			return base.x89a1d2c0b93619bb / 2f;
		}
	}

	private float xc288189192f8898f => xc46af5788022f70e / (float)(x5b95c6f825b826a0.x359943a385c4cbfd.Length - 1);

	private int xeb27643ba2c19bf7 => x318f74746d616ef0.x2e4333c9c4cb20bb(xc288189192f8898f, x5b95c6f825b826a0.x68955bfadd010132, x8cedcaa9a62c6e39);

	private float x8ae68d553bb09b1a => xc46af5788022f70e / x5b95c6f825b826a0.x03a7db85d0686f26;

	private float xa206d2388da25c62 => 360f / x4bba99670c27bc08.x03a7db85d0686f26;

	internal x760100a488bf9b75(xf6f80e59810bad00 x, xf6f80e59810bad00 y, xcd7d6e7318ee6574 context, RectangleF targetRect, bool isInner)
		: base(x, y, context, targetRect)
	{
		x2e726fc92e4398c6(isInner);
	}

	public override PointF x2206903f9421fd4b(float x56b7a81db87d2345, float x135b78187b928efe)
	{
		float x0d1ae4a53ce = (x725e13a501f0b741 ? x56b7a81db87d2345 : x135b78187b928efe);
		float xe8cee96c7b4bc2fa = (x725e13a501f0b741 ? x135b78187b928efe : x56b7a81db87d2345);
		return xcd948e02021d9af7(x0d1ae4a53ce, xe8cee96c7b4bc2fa);
	}

	private PointF xcd948e02021d9af7(float x0d1ae4a53ce31913, float xe8cee96c7b4bc2fa)
	{
		x0d1ae4a53ce31913 -= x4bba99670c27bc08.x32c37895c4f182b8;
		xe8cee96c7b4bc2fa -= x5b95c6f825b826a0.x32c37895c4f182b8;
		if (x15e971129fd80714.x5ab3b42bd288ad29(xe8cee96c7b4bc2fa))
		{
			return xeed202914e7c06d3();
		}
		float num = x0d1ae4a53ce31913 * xa206d2388da25c62;
		float num2 = xe8cee96c7b4bc2fa * x8ae68d553bb09b1a;
		PointF pointF = xeed202914e7c06d3();
		RectangleF bounds = new RectangleF(pointF.X - num2, pointF.Y - num2, num2 * 2f, num2 * 2f);
		x1fb5d45c2d0b868a x1fb5d45c2d0b868a = new x1fb5d45c2d0b868a(bounds, -90.0, num);
		return x1fb5d45c2d0b868a.x0f74da0eed3dd981();
	}

	public override PointF xeed202914e7c06d3()
	{
		return new PointF(x6e74c79ac777f020 + base.x31f3192bdc025ca5 / 2f, x2cede84e47db333b + base.x89a1d2c0b93619bb / 2f);
	}

	protected override void RenderAbscissaCore()
	{
		PointF x10aaa7cdfa38f = xeed202914e7c06d3();
		x86270791cf6a92b9[] x359943a385c4cbfd = x4bba99670c27bc08.x359943a385c4cbfd;
		foreach (x86270791cf6a92b9 x86270791cf6a92b in x359943a385c4cbfd)
		{
			PointF xca09b6c2b5b = xcd948e02021d9af7(x86270791cf6a92b.FloatValue, x5b95c6f825b826a0.xc5244ee5a7cd5b75);
			xabef526900561ce8(x10aaa7cdfa38f, xca09b6c2b5b, x5b95c6f825b826a0.xff13b489d81606b6);
			x2aa9cfe9d4739314(x86270791cf6a92b, xbdf72c3946853da4: false);
		}
	}

	protected override void RenderOrdinateCore()
	{
		for (int i = 0; i < x5b95c6f825b826a0.x359943a385c4cbfd.Length; i++)
		{
			if (i % xeb27643ba2c19bf7 == 0)
			{
				x2aa9cfe9d4739314(x5b95c6f825b826a0.x359943a385c4cbfd[i], xbdf72c3946853da4: true);
			}
		}
	}

	protected override void RenderLabelCore(float val, string label, float labelWidth, float labelHeight, bool isRenderOrdinate)
	{
		float x0d1ae4a53ce = (isRenderOrdinate ? x4bba99670c27bc08.xc5244ee5a7cd5b75 : val);
		float xe8cee96c7b4bc2fa = (isRenderOrdinate ? val : x5b95c6f825b826a0.xc5244ee5a7cd5b75);
		PointF pointF = xcd948e02021d9af7(x0d1ae4a53ce, xe8cee96c7b4bc2fa);
		PointF x9c3c185e7046dc = pointF;
		if (isRenderOrdinate)
		{
			x9c3c185e7046dc = new PointF(pointF.X - (labelWidth + x44cb99f0551df91f), pointF.Y - labelHeight / 2f);
		}
		else
		{
			float num = (val - x4bba99670c27bc08.x32c37895c4f182b8) * xa206d2388da25c62;
			if (num == 0f)
			{
				x9c3c185e7046dc = new PointF(pointF.X - labelWidth / 2f, pointF.Y - (labelHeight + x77ca88a648804658));
			}
			else if (num > 0f && num < 180f)
			{
				x9c3c185e7046dc = new PointF(pointF.X + x77ca88a648804658, pointF.Y - labelHeight / 2f);
			}
			else if (num == 180f)
			{
				x9c3c185e7046dc = new PointF(pointF.X - labelWidth / 2f, pointF.Y + x77ca88a648804658);
			}
			else if (num > 180f && num < 360f)
			{
				x9c3c185e7046dc = new PointF(pointF.X - labelWidth - x77ca88a648804658, pointF.Y - labelHeight / 2f);
			}
		}
		xf6f80e59810bad00 xf6f80e59810bad = (isRenderOrdinate ? x5b95c6f825b826a0 : x4bba99670c27bc08);
		xb8e7e788f6d59708 xda5bf54deb817e = x96cae28a54d522c4(label, x9c3c185e7046dc, xf6f80e59810bad.xff13b489d81606b6, xf6f80e59810bad.x68955bfadd010132);
		x8cedcaa9a62c6e39.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xda5bf54deb817e);
	}

	protected override void RenderAbscissaGridlinesCore()
	{
	}

	protected override void RenderOrdinateGridlinesCore()
	{
		if (x5b95c6f825b826a0.x3d64cd96ed6b6560 == null)
		{
			return;
		}
		x86270791cf6a92b9[] x359943a385c4cbfd = x5b95c6f825b826a0.x359943a385c4cbfd;
		foreach (x86270791cf6a92b9 x86270791cf6a92b in x359943a385c4cbfd)
		{
			PointF[] array = new PointF[x4bba99670c27bc08.x359943a385c4cbfd.Length];
			for (int j = 0; j < x4bba99670c27bc08.x359943a385c4cbfd.Length; j++)
			{
				x86270791cf6a92b9 x86270791cf6a92b2 = x4bba99670c27bc08.x359943a385c4cbfd[j];
				PointF pointF = x2206903f9421fd4b(x86270791cf6a92b2.FloatValue, x86270791cf6a92b.FloatValue);
				array[j] = pointF;
			}
			xef7f37aedd224924(array, x5b95c6f825b826a0.x3d64cd96ed6b6560);
		}
	}

	protected override void CalculateOffsetsCore()
	{
		float num = (x2cede84e47db333b = x35ce44b1ebc33c3e + x77ca88a648804658);
		x86270791cf6a92b9[] x359943a385c4cbfd = x4bba99670c27bc08.x359943a385c4cbfd;
		foreach (x86270791cf6a92b9 x86270791cf6a92b in x359943a385c4cbfd)
		{
			float num2 = (x86270791cf6a92b.FloatValue - x4bba99670c27bc08.x32c37895c4f182b8) * xa206d2388da25c62;
			double num3 = x15e971129fd80714.xcdc7b29a812dd7df(num2);
			string xb41faee6912a = x4bba99670c27bc08.xd8b4d728ebd381eb(x86270791cf6a92b);
			float num4 = x318f74746d616ef0.xce9adc25a876be06(xb41faee6912a, x4bba99670c27bc08.x68955bfadd010132, x8cedcaa9a62c6e39, x461bfa5b6ec21819: false) + x77ca88a648804658;
			if (num2 == 0f || num2 == 180f)
			{
				x6e74c79ac777f020 = Math.Max(x6e74c79ac777f020, num4 / 2f - xc46af5788022f70e);
				xf995a7a9bffac1cf = Math.Max(x6e74c79ac777f020, num4 / 2f - xc46af5788022f70e);
			}
			float val = num4 - (xc46af5788022f70e - (float)Math.Abs(Math.Sin(num3)) * xc46af5788022f70e);
			if (num2 > 0f && num2 < 180f)
			{
				xf995a7a9bffac1cf = Math.Max(xf995a7a9bffac1cf, val);
			}
			else if (num2 > 180f && num2 < 360f)
			{
				x6e74c79ac777f020 = Math.Max(x6e74c79ac777f020, val);
			}
			float val2 = num - (xc46af5788022f70e + (float)Math.Cos(num3) * xc46af5788022f70e);
			xf63c9a791cae8f48 = Math.Max(xf63c9a791cae8f48, val2);
		}
		x3b2183a6ac31c143();
	}

	private void x3b2183a6ac31c143()
	{
		float num = (xcfb00db5f2a96790.Width - xc46af5788022f70e * 2f) / 2f;
		float num2 = (xcfb00db5f2a96790.Height - xc46af5788022f70e * 2f) / 2f;
		if (x6e74c79ac777f020 < num && xf995a7a9bffac1cf < num)
		{
			x6e74c79ac777f020 = num;
			xf995a7a9bffac1cf = num;
		}
		if (x2cede84e47db333b < num2 && xf63c9a791cae8f48 < num2)
		{
			x2cede84e47db333b = num2;
			xf63c9a791cae8f48 = num2;
		}
	}
}
