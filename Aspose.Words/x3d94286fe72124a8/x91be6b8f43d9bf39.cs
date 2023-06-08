using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;

namespace x3d94286fe72124a8;

internal class x91be6b8f43d9bf39
{
	private RectangleF x81001503b442d908 = RectangleF.Empty;

	private readonly xfc96716110004aef x752ba8dd7eae2c2b;

	internal bool x77b539f715547c1c
	{
		get
		{
			if (x752ba8dd7eae2c2b != null)
			{
				return x752ba8dd7eae2c2b.x77b539f715547c1c;
			}
			return false;
		}
	}

	internal x91be6b8f43d9bf39(xfc96716110004aef textBuilder)
	{
		x752ba8dd7eae2c2b = textBuilder;
	}

	internal SizeF xdfaeeb042d114dff(xa37343ccb8cd8c70 x0f7b23d1c393aed9)
	{
		xb8e7e788f6d59708 x92ba3975b1e8ea = new xb8e7e788f6d59708();
		xe406325e56f74b46(x0f7b23d1c393aed9, x92ba3975b1e8ea);
		TextBox textBox = x0f7b23d1c393aed9.xa9993ed2e0c64574.TextBox;
		SizeF sizeF = x81001503b442d908.Size;
		float num = xd08732447aa791e7(x0f7b23d1c393aed9.xa9993ed2e0c64574);
		if (num == 90f || num == -90f)
		{
			sizeF = new SizeF(sizeF.Height, sizeF.Width);
		}
		float num2 = (float)((double)sizeF.Width + textBox.InternalMarginLeft + textBox.InternalMarginRight);
		float height = (float)((double)sizeF.Height + textBox.InternalMarginTop + textBox.InternalMarginBottom);
		return new SizeF((float)(((double)num2 > x0f7b23d1c393aed9.xa9993ed2e0c64574.Width) ? ((double)num2) : x0f7b23d1c393aed9.xa9993ed2e0c64574.Width), height);
	}

	internal void xe406325e56f74b46(xa37343ccb8cd8c70 x0f7b23d1c393aed9, xb8e7e788f6d59708 x92ba3975b1e8ea20)
	{
		if (x752ba8dd7eae2c2b != null && x752ba8dd7eae2c2b.xc368ac20e836d506(x0f7b23d1c393aed9.xa9993ed2e0c64574))
		{
			Shape xa9993ed2e0c = x0f7b23d1c393aed9.xa9993ed2e0c64574;
			float xc8822d77ef1841c = xd08732447aa791e7(xa9993ed2e0c);
			x81001503b442d908 = x03d870a6ff1ac3d3(x0f7b23d1c393aed9, xc8822d77ef1841c);
			float width = x81001503b442d908.Width;
			xb8e7e788f6d59708 xb8e7e788f6d = x72272b75f8ac8758(x0f7b23d1c393aed9);
			if (xb8e7e788f6d != null)
			{
				xb8e7e788f6d.x52dde376accdec7d = xcb052452979e3857(xc8822d77ef1841c);
				xa3e94d39710969ea xa3e94d39710969ea2 = x06143c3c273fbfa3(xa9993ed2e0c);
				xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(new RectangleF(0f - xa3e94d39710969ea2.x72d92bd1aff02e37, 0f, xa3e94d39710969ea2.x72d92bd1aff02e37 + xa3e94d39710969ea2.x419ba17a5322627b + width, x81001503b442d908.Height));
				x92ba3975b1e8ea20.xd6b6ed77479ef68c(xb8e7e788f6d);
			}
		}
	}

	private xa3e94d39710969ea x06143c3c273fbfa3(Shape x5770cdefd8931aa9)
	{
		TextBox textBox = x5770cdefd8931aa9.TextBox;
		float num;
		float num2;
		switch (textBox.LayoutFlow)
		{
		case LayoutFlow.TopToBottomIdeographic:
		case LayoutFlow.TopToBottom:
			num = (float)textBox.InternalMarginTop;
			num2 = (float)textBox.InternalMarginBottom;
			break;
		case LayoutFlow.BottomToTop:
			num = (float)textBox.InternalMarginBottom;
			num2 = (float)textBox.InternalMarginTop;
			break;
		default:
			num = (float)textBox.InternalMarginLeft;
			num2 = (float)textBox.InternalMarginRight;
			break;
		}
		float num3 = (float)(5.0 + x5770cdefd8931aa9.StrokeWeight);
		return new xa3e94d39710969ea(num + num3, num2 + num3);
	}

	private xb8e7e788f6d59708 x72272b75f8ac8758(xa37343ccb8cd8c70 x0f7b23d1c393aed9)
	{
		Shape xa9993ed2e0c = x0f7b23d1c393aed9.xa9993ed2e0c64574;
		float num = Math.Max(0f, x81001503b442d908.Width);
		float xb0f146032f47c24e = Math.Max(0f, x81001503b442d908.Height);
		x752ba8dd7eae2c2b.xdc1bf80853046136 = ((xa9993ed2e0c.TextBox.TextBoxWrapMode == TextBoxWrapMode.None && xa9993ed2e0c.TextBox.FitShapeToText) ? 0f : num);
		x752ba8dd7eae2c2b.xb0f146032f47c24e = xb0f146032f47c24e;
		object xc46371921b1b5eeb = x752ba8dd7eae2c2b.xc3819e13f60dd8e6(xa9993ed2e0c, new xd276f68a96277a27());
		float y = x81001503b442d908.Y;
		x2194edf7a5d21ccb(x0f7b23d1c393aed9.xa9993ed2e0c64574.TextBox.x69aaa2975337eae6);
		Color x1872d0ea7fb = ((xa9993ed2e0c.Filled && xa9993ed2e0c.Fill.xeba92971120d3e5a == xeba92971120d3e5a.xb8751dec55f64252) ? xa9993ed2e0c.FillColor : Color.Empty);
		if (xa9993ed2e0c.x3ffbaff53e6d8618 && !x77b539f715547c1c)
		{
			x81001503b442d908 = new RectangleF(x81001503b442d908.Location, new SizeF(x752ba8dd7eae2c2b.xdc1bf80853046136, x752ba8dd7eae2c2b.xb0f146032f47c24e));
		}
		else if (x752ba8dd7eae2c2b.xdc1bf80853046136 > x81001503b442d908.Width)
		{
			x81001503b442d908 = new RectangleF(x81001503b442d908.Location, new SizeF(x752ba8dd7eae2c2b.xdc1bf80853046136, x81001503b442d908.Height));
		}
		return x752ba8dd7eae2c2b.xe406325e56f74b46(xc46371921b1b5eeb, new SizeF(x752ba8dd7eae2c2b.xdc1bf80853046136, x752ba8dd7eae2c2b.xb0f146032f47c24e), x81001503b442d908.Height - x81001503b442d908.Y + y, x1872d0ea7fb);
	}

	private void x2194edf7a5d21ccb(x69aaa2975337eae6 xf0f5907c77eeefed)
	{
		PointF location = xef5fccc4b0e258e6(x81001503b442d908, new SizeF(x752ba8dd7eae2c2b.xdc1bf80853046136, x752ba8dd7eae2c2b.xb0f146032f47c24e), xf0f5907c77eeefed);
		x81001503b442d908 = new RectangleF(location, x81001503b442d908.Size);
	}

	internal static RectangleF x03d870a6ff1ac3d3(xa37343ccb8cd8c70 x0f7b23d1c393aed9, float xc8822d77ef1841c7)
	{
		RectangleF x22346b9b537191fa = x0f7b23d1c393aed9.x22346b9b537191fa;
		xa99f8d94adfe1070 xaeddb4fe9ae94a6a = x0f7b23d1c393aed9.xaeddb4fe9ae94a6a;
		Shape xa9993ed2e0c = x0f7b23d1c393aed9.xa9993ed2e0c64574;
		float num = (float)xa9993ed2e0c.StrokeWeight;
		if (num <= 1f || !xa9993ed2e0c.Stroked)
		{
			num = 0f;
		}
		float num2 = num * 0.5f;
		float x = x22346b9b537191fa.X;
		float y = x22346b9b537191fa.Y;
		float width = x22346b9b537191fa.Width;
		float height = x22346b9b537191fa.Height;
		float num3 = x + width;
		float num4 = y + height;
		float width2 = x0f7b23d1c393aed9.xe90b7db0328556d9.Width;
		float height2 = x0f7b23d1c393aed9.xe90b7db0328556d9.Height;
		float num5 = (float)xa9993ed2e0c.TextBox.InternalMarginLeft + num2;
		float num6 = (float)xa9993ed2e0c.TextBox.InternalMarginTop + num2;
		float num7 = (float)xa9993ed2e0c.TextBox.InternalMarginRight + num2;
		float num8 = (float)xa9993ed2e0c.TextBox.InternalMarginBottom + num2;
		float num9 = xa9993ed2e0c.x133d653c1b9b01f2;
		float num10 = xa9993ed2e0c.xc97e136f0019c237;
		float num11 = width2 - num5 - num7;
		float num12 = height2 - num6 - num8;
		float num13 = x / num9;
		float num14 = num3 / num9;
		float num15 = y / num10;
		float num16 = num4 / num10;
		float num17 = num11 * num13 + num5;
		float num18 = num11 * num14 + num5;
		float num19 = num12 * num15 + num6;
		float num20 = num12 * num16 + num6;
		float num21 = ((width2 == 0f) ? 1f : (num9 / width2));
		float num22 = ((height2 == 0f) ? 1f : (num10 / height2));
		x = num17 * num21 + num2;
		num3 = num18 * num21 + num2;
		y = num19 * num22 - num2;
		num4 = num20 * num22 - num2;
		PointF[] array = new PointF[2]
		{
			new PointF(x, y),
			new PointF(num3, num4)
		};
		xaeddb4fe9ae94a6a.xa4b699bd47eb7372(array, x16aef18841fa33ad: true);
		width = array[1].X - array[0].X;
		height = array[1].Y - array[0].Y;
		SizeF size = x6ee5d0ab317078eb(xa9993ed2e0c, width, height, xc8822d77ef1841c7);
		PointF location = array[0];
		if (xa99f8d94adfe1070.x45fb8e49520ded21(xa9993ed2e0c))
		{
			float num23 = (height - width) * 0.5f;
			location = new PointF(location.X - num23, location.Y + num23);
		}
		return new RectangleF(location, size);
	}

	private static PointF xef5fccc4b0e258e6(RectangleF x3cf9a16575993fad, SizeF x411c9be51e5febde, x69aaa2975337eae6 xf0f5907c77eeefed)
	{
		SizeF size = x3cf9a16575993fad.Size;
		PointF result = x3cf9a16575993fad.Location;
		if (size.Height <= x411c9be51e5febde.Height)
		{
			return result;
		}
		switch (xf0f5907c77eeefed)
		{
		case x69aaa2975337eae6.x83e8265cdba541b5:
			result = new PointF(result.X, result.Y + (size.Height - x411c9be51e5febde.Height) * 0.5f);
			break;
		case x69aaa2975337eae6.x9bcb07e204e30218:
			result = new PointF(result.X, result.Y + (size.Height - x411c9be51e5febde.Height));
			break;
		default:
			throw new ArgumentOutOfRangeException();
		case x69aaa2975337eae6.xe360b1885d8d4a41:
		case x69aaa2975337eae6.xa5763279521240b7:
		case x69aaa2975337eae6.x8e358f314152e440:
		case x69aaa2975337eae6.xfa798f7bb6dc8d92:
		case x69aaa2975337eae6.x946b76d5c7ef8750:
		case x69aaa2975337eae6.x059f1dd73be50f8c:
		case x69aaa2975337eae6.x1494baafc1649b28:
		case x69aaa2975337eae6.x15f2109d58807311:
			break;
		}
		return result;
	}

	internal static float xd08732447aa791e7(Shape x5770cdefd8931aa9)
	{
		switch (x5770cdefd8931aa9.TextBox.LayoutFlow)
		{
		case LayoutFlow.TopToBottomIdeographic:
		case LayoutFlow.TopToBottom:
			return 90f;
		case LayoutFlow.BottomToTop:
			return -90f;
		default:
			return 0f;
		}
	}

	private static SizeF x6ee5d0ab317078eb(Shape x5770cdefd8931aa9, float x9b0739496f8b5475, float x4d5aabc7a55b12ba, float xcb83cdf6822fc99d)
	{
		float width = x9b0739496f8b5475;
		float height = x4d5aabc7a55b12ba;
		if ((xcb83cdf6822fc99d != 0f) ^ xa99f8d94adfe1070.x45fb8e49520ded21(x5770cdefd8931aa9))
		{
			width = x4d5aabc7a55b12ba;
			height = x9b0739496f8b5475;
		}
		return new SizeF(width, height);
	}

	private x54366fa5f75a02f7 xcb052452979e3857(float xc8822d77ef1841c7)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xa77087bb05d9ef76(xc8822d77ef1841c7, MatrixOrder.Append);
		if (xc8822d77ef1841c7 == 90f)
		{
			x54366fa5f75a02f.xce92de628aa023cf(x81001503b442d908.Height, 0f, MatrixOrder.Append);
		}
		else if (xc8822d77ef1841c7 == -90f)
		{
			x54366fa5f75a02f.xce92de628aa023cf(0f, x81001503b442d908.Width, MatrixOrder.Append);
		}
		x54366fa5f75a02f.xce92de628aa023cf(x81001503b442d908.X, x81001503b442d908.Y, MatrixOrder.Append);
		return x54366fa5f75a02f;
	}
}
