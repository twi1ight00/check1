using System;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x32a884d842a34446;
using x5794c252ba25e723;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;

namespace xb3013071794e5415;

internal class x7f6e105e40e31dae : x81ac855fc7b54c66
{
	private float x39e4335d857f5840 = -1f;

	private float xa91284c2ff4a41ee = -1f;

	private float x53b5497e1889efbc => base.x89a1d2c0b93619bb / x5b95c6f825b826a0.x03a7db85d0686f26;

	private float x9ef4ea518c1e89de => base.x31f3192bdc025ca5 / x4bba99670c27bc08.x03a7db85d0686f26;

	private float x79a071bfba0c5e7d => Math.Abs((x5b95c6f825b826a0.x5e7a899338a3ee20.x2c5926113e101674 == x2c5926113e101674.x353abc6637d88c69) ? (x5b95c6f825b826a0.x97404861bd204bb6 - x5b95c6f825b826a0.x32c37895c4f182b8) : (x5b95c6f825b826a0.xc5244ee5a7cd5b75 - x5b95c6f825b826a0.x97404861bd204bb6));

	private float x887a0c79ecbe5ee3 => x5b95c6f825b826a0.x03a7db85d0686f26 - x79a071bfba0c5e7d;

	private float x72d92bd1aff02e37 => Math.Abs((x4bba99670c27bc08.x5e7a899338a3ee20.x2c5926113e101674 == x2c5926113e101674.x353abc6637d88c69) ? (x4bba99670c27bc08.x97404861bd204bb6 - x4bba99670c27bc08.x32c37895c4f182b8) : (x4bba99670c27bc08.xc5244ee5a7cd5b75 - x4bba99670c27bc08.x97404861bd204bb6));

	private float x419ba17a5322627b => x4bba99670c27bc08.x03a7db85d0686f26 - x72d92bd1aff02e37;

	private bool xf9d57d31ed9a6061 => x8ccf54acdf604e5b > x3d379d1e56cb34d9 * (float)x01b08d0b5847a2b7;

	private float x9b2bc1d145065ddb
	{
		get
		{
			if (xa91284c2ff4a41ee < 0f)
			{
				xa91284c2ff4a41ee = xfe7abba0705eedaf(x5b95c6f825b826a0.x359943a385c4cbfd, x5b95c6f825b826a0);
			}
			return xa91284c2ff4a41ee;
		}
	}

	private float x8ccf54acdf604e5b
	{
		get
		{
			if (x39e4335d857f5840 < 0f)
			{
				x39e4335d857f5840 = xfe7abba0705eedaf(x4bba99670c27bc08.x359943a385c4cbfd, x4bba99670c27bc08);
			}
			return x39e4335d857f5840;
		}
	}

	private float xccc418fd4e286235
	{
		get
		{
			if (!xf9d57d31ed9a6061)
			{
				return x35ce44b1ebc33c3e;
			}
			return x25b954f3af662e94(new SizeF(x8ccf54acdf604e5b, x35ce44b1ebc33c3e));
		}
	}

	private float x120062062ed0ae70 => base.x89a1d2c0b93619bb / (float)(x5b95c6f825b826a0.x359943a385c4cbfd.Length - 1);

	private int x63e5792faf29c998 => x318f74746d616ef0.x2e4333c9c4cb20bb(x120062062ed0ae70, x5b95c6f825b826a0.x68955bfadd010132, x8cedcaa9a62c6e39);

	private float x3d379d1e56cb34d9 => base.x31f3192bdc025ca5 / (float)(x4bba99670c27bc08.x359943a385c4cbfd.Length - 1);

	private int x01b08d0b5847a2b7 => x318f74746d616ef0.x2e4333c9c4cb20bb(x3d379d1e56cb34d9, x4bba99670c27bc08.x68955bfadd010132, x8cedcaa9a62c6e39);

	private float xd3eabf507a9d2e29
	{
		get
		{
			if (!x4bba99670c27bc08.x0db70f125cd5427f)
			{
				return 0f;
			}
			return x3d379d1e56cb34d9 / 2f;
		}
	}

	private float x0dfaea1d51984a0f
	{
		get
		{
			if (!x5b95c6f825b826a0.x0db70f125cd5427f)
			{
				return 0f;
			}
			return x120062062ed0ae70 / 2f;
		}
	}

	internal x7f6e105e40e31dae(xf6f80e59810bad00 x, xf6f80e59810bad00 y, xcd7d6e7318ee6574 context, RectangleF targetRect, bool isInner)
		: base(x, y, context, targetRect)
	{
		x2e726fc92e4398c6(isInner);
	}

	public override PointF xeed202914e7c06d3()
	{
		return xcd948e02021d9af7(x4bba99670c27bc08.x97404861bd204bb6, x5b95c6f825b826a0.x97404861bd204bb6);
	}

	public override PointF x2206903f9421fd4b(float x56b7a81db87d2345, float x135b78187b928efe)
	{
		float xd7f5411b444f868d = (x725e13a501f0b741 ? x56b7a81db87d2345 : x135b78187b928efe);
		float x0660987ed56d2e = (x725e13a501f0b741 ? x135b78187b928efe : x56b7a81db87d2345);
		PointF pointF = xcd948e02021d9af7(xd7f5411b444f868d, x0660987ed56d2e);
		return new PointF(pointF.X + xd3eabf507a9d2e29, pointF.Y - x0dfaea1d51984a0f);
	}

	private PointF xcd948e02021d9af7(float xd7f5411b444f868d, float x0660987ed56d2e61)
	{
		xd7f5411b444f868d -= x4bba99670c27bc08.x32c37895c4f182b8;
		x0660987ed56d2e61 -= x5b95c6f825b826a0.x32c37895c4f182b8;
		float num = ((x4bba99670c27bc08.x5e7a899338a3ee20.x2c5926113e101674 == x2c5926113e101674.x353abc6637d88c69) ? (xd7f5411b444f868d * x9ef4ea518c1e89de) : (base.x31f3192bdc025ca5 - xd7f5411b444f868d * x9ef4ea518c1e89de));
		num += x6e74c79ac777f020;
		float num2 = ((x5b95c6f825b826a0.x5e7a899338a3ee20.x2c5926113e101674 == x2c5926113e101674.xb89ee8a7212e25c8) ? (x0660987ed56d2e61 * x53b5497e1889efbc) : (base.x89a1d2c0b93619bb - x0660987ed56d2e61 * x53b5497e1889efbc));
		num2 += x2cede84e47db333b;
		return new PointF(num, num2);
	}

	protected override void RenderAbscissaGridlinesCore()
	{
		PointF pointF = xcd948e02021d9af7(x4bba99670c27bc08.x97404861bd204bb6, x5b95c6f825b826a0.x32c37895c4f182b8);
		PointF pointF2 = xcd948e02021d9af7(x4bba99670c27bc08.x97404861bd204bb6, x5b95c6f825b826a0.xc5244ee5a7cd5b75);
		x86270791cf6a92b9[] x359943a385c4cbfd = x4bba99670c27bc08.x359943a385c4cbfd;
		foreach (x86270791cf6a92b9 x86270791cf6a92b in x359943a385c4cbfd)
		{
			if (x4bba99670c27bc08.x3d64cd96ed6b6560 != null)
			{
				PointF pointF3 = xcd948e02021d9af7(x86270791cf6a92b.FloatValue, x5b95c6f825b826a0.x97404861bd204bb6);
				PointF x10aaa7cdfa38f = new PointF(pointF3.X, pointF.Y);
				PointF xca09b6c2b5b = new PointF(pointF3.X, pointF2.Y);
				xef7f37aedd224924(x10aaa7cdfa38f, xca09b6c2b5b, x4bba99670c27bc08.x3d64cd96ed6b6560);
			}
		}
	}

	protected override void RenderOrdinateGridlinesCore()
	{
		PointF pointF = xcd948e02021d9af7(x4bba99670c27bc08.x32c37895c4f182b8, x5b95c6f825b826a0.x97404861bd204bb6);
		PointF pointF2 = xcd948e02021d9af7(x4bba99670c27bc08.xc5244ee5a7cd5b75, x5b95c6f825b826a0.x97404861bd204bb6);
		x86270791cf6a92b9[] x359943a385c4cbfd = x5b95c6f825b826a0.x359943a385c4cbfd;
		foreach (x86270791cf6a92b9 x86270791cf6a92b in x359943a385c4cbfd)
		{
			if (x5b95c6f825b826a0.x3d64cd96ed6b6560 != null)
			{
				PointF pointF3 = xcd948e02021d9af7(x4bba99670c27bc08.x97404861bd204bb6, x86270791cf6a92b.FloatValue);
				PointF x10aaa7cdfa38f = new PointF(pointF.X, pointF3.Y);
				PointF xca09b6c2b5b = new PointF(pointF2.X, pointF3.Y);
				xef7f37aedd224924(x10aaa7cdfa38f, xca09b6c2b5b, x5b95c6f825b826a0.x3d64cd96ed6b6560);
			}
		}
	}

	protected override void RenderAbscissaCore()
	{
		PointF x10aaa7cdfa38f = xcd948e02021d9af7(x4bba99670c27bc08.x32c37895c4f182b8, x5b95c6f825b826a0.x97404861bd204bb6);
		PointF xca09b6c2b5b = xcd948e02021d9af7(x4bba99670c27bc08.xc5244ee5a7cd5b75, x5b95c6f825b826a0.x97404861bd204bb6);
		xabef526900561ce8(x10aaa7cdfa38f, xca09b6c2b5b, x4bba99670c27bc08.xff13b489d81606b6);
		for (int i = 0; i < x4bba99670c27bc08.x359943a385c4cbfd.Length; i++)
		{
			x86270791cf6a92b9 x86270791cf6a92b = x4bba99670c27bc08.x359943a385c4cbfd[i];
			PointF xca09b6c2b5b2 = xcd948e02021d9af7(x86270791cf6a92b.FloatValue, x5b95c6f825b826a0.x97404861bd204bb6);
			float y = ((x4bba99670c27bc08.x81597796c74b4b6b == x3b984189a2549b3f.xe360b1885d8d4a41) ? (xca09b6c2b5b2.Y - xa2ed805d5744f18d) : (xca09b6c2b5b2.Y + xa2ed805d5744f18d));
			PointF x10aaa7cdfa38f2 = new PointF(xca09b6c2b5b2.X, y);
			xabef526900561ce8(x10aaa7cdfa38f2, xca09b6c2b5b2, x4bba99670c27bc08.xff13b489d81606b6);
			if (i % x01b08d0b5847a2b7 == 0)
			{
				x2aa9cfe9d4739314(x86270791cf6a92b, xbdf72c3946853da4: false);
			}
		}
	}

	protected override void RenderOrdinateCore()
	{
		PointF x10aaa7cdfa38f = xcd948e02021d9af7(x4bba99670c27bc08.x97404861bd204bb6, x5b95c6f825b826a0.x32c37895c4f182b8);
		PointF xca09b6c2b5b = xcd948e02021d9af7(x4bba99670c27bc08.x97404861bd204bb6, x5b95c6f825b826a0.xc5244ee5a7cd5b75);
		xabef526900561ce8(x10aaa7cdfa38f, xca09b6c2b5b, x5b95c6f825b826a0.xff13b489d81606b6);
		for (int i = 0; i < x5b95c6f825b826a0.x359943a385c4cbfd.Length; i++)
		{
			x86270791cf6a92b9 x86270791cf6a92b = x5b95c6f825b826a0.x359943a385c4cbfd[i];
			PointF xca09b6c2b5b2 = xcd948e02021d9af7(x4bba99670c27bc08.x97404861bd204bb6, x86270791cf6a92b.FloatValue);
			float x = ((x5b95c6f825b826a0.x81597796c74b4b6b == x3b984189a2549b3f.x72d92bd1aff02e37) ? (xca09b6c2b5b2.X - x37f8fa4cd48bb8c5) : (xca09b6c2b5b2.X + x37f8fa4cd48bb8c5));
			PointF x10aaa7cdfa38f2 = new PointF(x, xca09b6c2b5b2.Y);
			xabef526900561ce8(x10aaa7cdfa38f2, xca09b6c2b5b2, x5b95c6f825b826a0.xff13b489d81606b6);
			if (i % x63e5792faf29c998 == 0)
			{
				x2aa9cfe9d4739314(x86270791cf6a92b, xbdf72c3946853da4: true);
			}
		}
	}

	protected override void RenderLabelCore(float val, string label, float labelWidth, float labelHeight, bool isRenderOrdinate)
	{
		float xd7f5411b444f868d = (isRenderOrdinate ? x4bba99670c27bc08.xbe7a16767b722b2d : val);
		float x0660987ed56d2e = (isRenderOrdinate ? val : x5b95c6f825b826a0.xbe7a16767b722b2d);
		xf6f80e59810bad00 xf6f80e59810bad = (isRenderOrdinate ? x5b95c6f825b826a0 : x4bba99670c27bc08);
		PointF pointF = xcd948e02021d9af7(xd7f5411b444f868d, x0660987ed56d2e);
		float y = pointF.Y;
		float x = pointF.X;
		if (isRenderOrdinate)
		{
			y += 0f - x0dfaea1d51984a0f - labelHeight / 2f;
			x += (xf6f80e59810bad.x45f76d92ae4739c8 ? (0f - (labelWidth + x44cb99f0551df91f)) : x44cb99f0551df91f);
		}
		else
		{
			y += (xf6f80e59810bad.x45f76d92ae4739c8 ? x77ca88a648804658 : (0f - (labelHeight + x77ca88a648804658)));
			x = ((!xf9d57d31ed9a6061) ? (x + (xd3eabf507a9d2e29 - labelWidth / 2f)) : (x + (xf6f80e59810bad.x45f76d92ae4739c8 ? (xd3eabf507a9d2e29 - labelWidth) : xd3eabf507a9d2e29)));
		}
		PointF x9c3c185e7046dc = new PointF(x, y);
		xb8e7e788f6d59708 xb8e7e788f6d = x96cae28a54d522c4(label, x9c3c185e7046dc, xf6f80e59810bad.xff13b489d81606b6, xf6f80e59810bad.x68955bfadd010132);
		if (!isRenderOrdinate && xf9d57d31ed9a6061)
		{
			float x2 = (xf6f80e59810bad.x45f76d92ae4739c8 ? (x9c3c185e7046dc.X + labelWidth) : x9c3c185e7046dc.X);
			float y2 = (xf6f80e59810bad.x45f76d92ae4739c8 ? (x9c3c185e7046dc.Y + labelHeight) : x9c3c185e7046dc.Y);
			xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7();
			xb8e7e788f6d.x52dde376accdec7d.x49d618948c467be6(-45f, new PointF(x2, y2));
		}
		x8cedcaa9a62c6e39.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xb8e7e788f6d);
	}

	internal float x156bf83d1a77efc1(int xd71c81d0299f95b0, int x5c50d7bccc5430a8)
	{
		return (x725e13a501f0b741 ? x3d379d1e56cb34d9 : x120062062ed0ae70) / ((float)xd71c81d0299f95b0 + (float)x5c50d7bccc5430a8 / 100f);
	}

	protected override void CalculateOffsetsCore()
	{
		xf3ff03f2144648a1();
		x597272dfd06930f0();
		x3b2183a6ac31c143();
	}

	private void x3b2183a6ac31c143()
	{
		if (x4bba99670c27bc08.xff3487ce5e12277d)
		{
			if (x4bba99670c27bc08.x45f76d92ae4739c8)
			{
				xf63c9a791cae8f48 = x83fd9702ffe1bf13(xf63c9a791cae8f48, xcfb00db5f2a96790.Height, x79a071bfba0c5e7d, x5b95c6f825b826a0.x03a7db85d0686f26, x5df8b15d2a132e6f);
			}
			else
			{
				x2cede84e47db333b = x83fd9702ffe1bf13(x2cede84e47db333b, xcfb00db5f2a96790.Height, x887a0c79ecbe5ee3, x5b95c6f825b826a0.x03a7db85d0686f26, x5df8b15d2a132e6f);
			}
		}
		if (x5b95c6f825b826a0.xff3487ce5e12277d)
		{
			if (x5b95c6f825b826a0.x45f76d92ae4739c8)
			{
				x6e74c79ac777f020 = x83fd9702ffe1bf13(x6e74c79ac777f020, xcfb00db5f2a96790.Width, x72d92bd1aff02e37, x4bba99670c27bc08.x03a7db85d0686f26, xe8624ea937a5141c(x1e7c83d33cd142dd: true));
			}
			else
			{
				xf995a7a9bffac1cf = x83fd9702ffe1bf13(xf995a7a9bffac1cf, xcfb00db5f2a96790.Width, x419ba17a5322627b, x4bba99670c27bc08.x03a7db85d0686f26, xe8624ea937a5141c(x1e7c83d33cd142dd: false));
			}
		}
		x806586e60c999cae();
	}

	private void x806586e60c999cae()
	{
		x6e74c79ac777f020 = Math.Max(x6e74c79ac777f020, x961e824d1ebea896);
		xf995a7a9bffac1cf = Math.Max(xf995a7a9bffac1cf, x961e824d1ebea896);
		x2cede84e47db333b = Math.Max(x2cede84e47db333b, x5df8b15d2a132e6f);
		xf63c9a791cae8f48 = Math.Max(xf63c9a791cae8f48, x5df8b15d2a132e6f);
	}

	private static float x83fd9702ffe1bf13(float x374ea4fe62468d0f, float x4238f10ce9c84067, float x8729261cfd62438d, float x576f6559b84ec3d3, float x369a35162f00af54)
	{
		float num = x374ea4fe62468d0f / x4238f10ce9c84067;
		float num2 = x8729261cfd62438d / x576f6559b84ec3d3;
		if (!(num <= num2))
		{
			return (1f - num2) * x374ea4fe62468d0f;
		}
		return x369a35162f00af54;
	}

	private void x597272dfd06930f0()
	{
		if (!x4bba99670c27bc08.xddae736767606eb7 && !x4bba99670c27bc08.x06518e3dac8eadee)
		{
			float num = xccc418fd4e286235 + x77ca88a648804658;
			x2cede84e47db333b = (x4bba99670c27bc08.x45f76d92ae4739c8 ? x5df8b15d2a132e6f : num);
			xf63c9a791cae8f48 = (x4bba99670c27bc08.x45f76d92ae4739c8 ? num : x5df8b15d2a132e6f);
		}
	}

	private void xf3ff03f2144648a1()
	{
		if (!x5b95c6f825b826a0.xddae736767606eb7 && !x5b95c6f825b826a0.x06518e3dac8eadee)
		{
			float num = x9b2bc1d145065ddb + x44cb99f0551df91f;
			x6e74c79ac777f020 = (x5b95c6f825b826a0.x45f76d92ae4739c8 ? num : x961e824d1ebea896);
			xf995a7a9bffac1cf = (x5b95c6f825b826a0.x45f76d92ae4739c8 ? x961e824d1ebea896 : num);
		}
		float num2 = xe8624ea937a5141c(x1e7c83d33cd142dd: true);
		float num3 = xe8624ea937a5141c(x1e7c83d33cd142dd: false);
		while (x6e74c79ac777f020 < num2 || xf995a7a9bffac1cf < num3)
		{
			x6e74c79ac777f020 = Math.Max(x6e74c79ac777f020, num2);
			xf995a7a9bffac1cf = Math.Max(xf995a7a9bffac1cf, num3);
			num2 = xe8624ea937a5141c(x1e7c83d33cd142dd: true);
			num3 = xe8624ea937a5141c(x1e7c83d33cd142dd: false);
		}
	}

	private float xe8624ea937a5141c(bool x1e7c83d33cd142dd)
	{
		if (x4bba99670c27bc08.xddae736767606eb7 || x4bba99670c27bc08.x06518e3dac8eadee)
		{
			return 0f;
		}
		bool x70e701cee22724e = (x1e7c83d33cd142dd ? (x4bba99670c27bc08.x5e7a899338a3ee20.x2c5926113e101674 == x2c5926113e101674.x353abc6637d88c69) : (x4bba99670c27bc08.x5e7a899338a3ee20.x2c5926113e101674 == x2c5926113e101674.xb89ee8a7212e25c8));
		SizeF x411c9be51e5febde = x4138ee6c434e0538(x70e701cee22724e);
		if (!xf9d57d31ed9a6061)
		{
			if (!x4bba99670c27bc08.x0db70f125cd5427f)
			{
				return x411c9be51e5febde.Width / 2f;
			}
			return 0f;
		}
		float num = x25b954f3af662e94(x411c9be51e5febde);
		if ((x4bba99670c27bc08.x45f76d92ae4739c8 && x1e7c83d33cd142dd) || (!x4bba99670c27bc08.x45f76d92ae4739c8 && !x1e7c83d33cd142dd))
		{
			if (!x4bba99670c27bc08.x0db70f125cd5427f)
			{
				return num;
			}
			return num - x3d379d1e56cb34d9 / 2f;
		}
		return 0f;
	}

	private SizeF x4138ee6c434e0538(bool x70e701cee22724e3)
	{
		int num = ((!x70e701cee22724e3) ? (x4bba99670c27bc08.x359943a385c4cbfd.Length - 1) : 0);
		x86270791cf6a92b9 x86270791cf6a92b = x4bba99670c27bc08.x359943a385c4cbfd[num];
		if (x70e701cee22724e3)
		{
			while (x86270791cf6a92b.x2bd4228892f25674 == xd620087af5172910.x4d0b9d4447ba7566)
			{
				x86270791cf6a92b = x4bba99670c27bc08.x359943a385c4cbfd[num++];
			}
		}
		else
		{
			while (x86270791cf6a92b.x2bd4228892f25674 == xd620087af5172910.x4d0b9d4447ba7566)
			{
				x86270791cf6a92b = x4bba99670c27bc08.x359943a385c4cbfd[num--];
			}
		}
		float width = x318f74746d616ef0.xce9adc25a876be06(x4bba99670c27bc08.xd8b4d728ebd381eb(x86270791cf6a92b), x4bba99670c27bc08.x68955bfadd010132, x8cedcaa9a62c6e39, x461bfa5b6ec21819: false);
		return new SizeF(width, x35ce44b1ebc33c3e);
	}

	private float xfe7abba0705eedaf(x86270791cf6a92b9[] x0788cd5a9865fc16, xf6f80e59810bad00 x5f12ae7e2f404c29)
	{
		float num = 0f;
		for (int i = 0; i < x0788cd5a9865fc16.Length; i++)
		{
			string xb41faee6912a = x5f12ae7e2f404c29.xd8b4d728ebd381eb(x0788cd5a9865fc16[i]);
			float val = x318f74746d616ef0.xce9adc25a876be06(xb41faee6912a, x5f12ae7e2f404c29.x68955bfadd010132, x8cedcaa9a62c6e39, x461bfa5b6ec21819: false);
			num = Math.Max(num, val);
		}
		return num;
	}

	private static float x25b954f3af662e94(SizeF x411c9be51e5febde)
	{
		float num = (float)Math.Sqrt(x411c9be51e5febde.Width * x411c9be51e5febde.Width / 2f);
		float num2 = (float)Math.Sqrt(x411c9be51e5febde.Height * x411c9be51e5febde.Height / 2f);
		return num + num2;
	}

	internal float xfbaea77d2f5322dc(x86270791cf6a92b9 xbcea506a33cf9111, float x6aa5e507d99bd7b2)
	{
		return 2f * base.x31f3192bdc025ca5 * xbcea506a33cf9111.FloatValue / x6aa5e507d99bd7b2;
	}
}
