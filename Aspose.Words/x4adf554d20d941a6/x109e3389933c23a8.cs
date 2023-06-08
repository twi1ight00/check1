using System;
using System.Drawing;
using Aspose;
using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal abstract class x109e3389933c23a8
{
	private object xd86e4bac41e028b8;

	private x398b3bd0acd94b61 x749f8493ad444bdb;

	private x398b3bd0acd94b61 x576773fbf9307688;

	private x8e3db3d2a7fdbd41 x66c02128fdc6436a;

	private Point[] x7e860e67e98d3221;

	private x1073233de8252b3e x437fa02210b98bec;

	private xae532cfb203d8406 x01dbeb0555bc8277;

	private Rectangle x930e7264e89b1eb5;

	private Rectangle xdb0b773293f55917;

	private bool xda9811b1693213e4;

	internal abstract int xf8c20af9fe5edca0 { get; }

	internal abstract int x5c43f9b06667f51f { get; }

	internal bool x4550657b0784ece4
	{
		get
		{
			if (!xf684fc5abe7ca67a)
			{
				return !x752cfab9af626fd5;
			}
			return false;
		}
	}

	internal bool xd9e330ee07e17ece
	{
		get
		{
			if (x66c02128fdc6436a.x0fcdf9c7f9f2eb9e == RelativeHorizontalPosition.Character)
			{
				return true;
			}
			switch (x66c02128fdc6436a.x5d0ebb82ae68cc43)
			{
			case RelativeVerticalPosition.Paragraph:
			case RelativeVerticalPosition.Line:
				return true;
			default:
				return false;
			}
		}
	}

	protected virtual bool XMustBeInsidePage => false;

	protected abstract bool YMustBeInsidePage { get; }

	internal x398b3bd0acd94b61 x38ced5a01a389303 => x749f8493ad444bdb;

	internal x398b3bd0acd94b61 xed3e432f7c9bf846
	{
		get
		{
			return x576773fbf9307688;
		}
		set
		{
			x576773fbf9307688 = value;
		}
	}

	internal object x1452024de1251c74 => xd86e4bac41e028b8;

	internal xae532cfb203d8406 xb6ef83a1238c066c
	{
		get
		{
			if (x01dbeb0555bc8277 == xae532cfb203d8406.x236cb0a4295bc034)
			{
				x01dbeb0555bc8277 = xa7a98231d4a67a0f.xe7480f4a43f6f00f(xd86e4bac41e028b8);
			}
			return x01dbeb0555bc8277;
		}
	}

	internal bool x5a3440516914ae4b
	{
		get
		{
			if (xb6ef83a1238c066c != xae532cfb203d8406.x53111d6596d16a99)
			{
				return xb6ef83a1238c066c == xae532cfb203d8406.x11db8fc7f469a2fc;
			}
			return true;
		}
	}

	internal bool x752cfab9af626fd5
	{
		get
		{
			switch (xb6ef83a1238c066c)
			{
			case xae532cfb203d8406.xb3f85ba4541b1ea9:
			case xae532cfb203d8406.x11db8fc7f469a2fc:
				return true;
			case xae532cfb203d8406.x56ef522aac8e098b:
			case xae532cfb203d8406.x53111d6596d16a99:
				return false;
			default:
				throw new InvalidOperationException("Unexpected floater impact value.");
			}
		}
	}

	internal bool xf684fc5abe7ca67a => x749f8493ad444bdb.x53111d6596d16a99.xf684fc5abe7ca67a;

	internal bool xbd46d5308b22d9fd
	{
		get
		{
			if (!xda9811b1693213e4 && x59a4bd4122a28877)
			{
				xda9811b1693213e4 = true;
			}
			return xda9811b1693213e4;
		}
	}

	private bool x59a4bd4122a28877
	{
		get
		{
			if (!(x1452024de1251c74 is xc63cc34daaa2e2d9) || ((xc63cc34daaa2e2d9)x1452024de1251c74).x332a8eedb847940d != null)
			{
				if (x1452024de1251c74 is xa67197c42bddc7dc)
				{
					return ((xa67197c42bddc7dc)x1452024de1251c74).x332a8eedb847940d == null;
				}
				return false;
			}
			return true;
		}
	}

	internal Rectangle x6ae4612a8469678e
	{
		get
		{
			if (x930e7264e89b1eb5.X == int.MinValue)
			{
				xdded4dd43a273f1e();
			}
			return x930e7264e89b1eb5;
		}
	}

	internal Rectangle x4b6965fe04aaacd8
	{
		get
		{
			if (xdb0b773293f55917.X == int.MinValue)
			{
				xdb0b773293f55917 = GetWrapBoundsImpl(x6ae4612a8469678e);
			}
			return xdb0b773293f55917;
		}
	}

	internal virtual Rectangle x7835973da2834a1b => x4b6965fe04aaacd8;

	internal virtual int xc13bc3847813c8aa => x705ed5f9769744e5.xc9ee264fd8d7484e;

	internal virtual int x330b27a3d588a781 => x705ed5f9769744e5.xb5465b18223f6375;

	internal Point[] xdbed53246e7dd53a
	{
		get
		{
			if (x7e860e67e98d3221 == null)
			{
				x7e860e67e98d3221 = GetVerticesImpl();
			}
			return x7e860e67e98d3221;
		}
	}

	internal x8e3db3d2a7fdbd41 x705ed5f9769744e5 => x66c02128fdc6436a;

	internal x1073233de8252b3e xc255c495fd9232ca
	{
		get
		{
			if (x437fa02210b98bec == null)
			{
				x437fa02210b98bec = xb8f59e47e556e4de();
			}
			return x437fa02210b98bec;
		}
	}

	protected xc7f90d9c7c51cede xa65184d44a47025b => (xc7f90d9c7c51cede)x38ced5a01a389303.xce4443deee105995(x954503abc583f675.xa65184d44a47025b);

	internal static x109e3389933c23a8 xa04178fab0d78eb2(x398b3bd0acd94b61 xcc36986f44d69e8f)
	{
		if (!xcc36986f44d69e8f.x53111d6596d16a99.x31fecf0961487c73)
		{
			return null;
		}
		x109e3389933c23a8 x109e3389933c23a9 = x455088ba2e479f69.xdef7f68a22ec051d(xcc36986f44d69e8f);
		if (x109e3389933c23a9 == null)
		{
			x109e3389933c23a9 = xa4342d41912fa853.xdef7f68a22ec051d(xcc36986f44d69e8f);
			if (x109e3389933c23a9 != null && x109e3389933c23a9.x752cfab9af626fd5)
			{
				return null;
			}
		}
		if (x109e3389933c23a9 == null)
		{
			x109e3389933c23a9 = xa38dda099d71aefb.xdef7f68a22ec051d(xcc36986f44d69e8f);
		}
		return x109e3389933c23a9;
	}

	[JavaThrows(true)]
	internal abstract void xc3819e13f60dd8e6();

	internal virtual bool xd62fa8ace7cbc0c9()
	{
		return x3d1ad8ce75f0db3a.xc0f5b459c8092d6e(x38ced5a01a389303, xed3e432f7c9bf846.xf432ece93e450408());
	}

	[JavaThrows(true)]
	internal abstract int xcc69ae5a5063e790();

	protected virtual int FixNegativeOrigin(int origin)
	{
		return Math.Max(origin, 0);
	}

	protected virtual int GetYCorrectionBottom()
	{
		return xa65184d44a47025b.xb0f146032f47c24e;
	}

	internal void x58c5f64a4ef63e88(x109e3389933c23a8 xdcf7b74ddd6caa25)
	{
		if (this != xdcf7b74ddd6caa25)
		{
			xdcf7b74ddd6caa25.x930e7264e89b1eb5 = x930e7264e89b1eb5;
			xdcf7b74ddd6caa25.xdb0b773293f55917 = xdb0b773293f55917;
			xdcf7b74ddd6caa25.x437fa02210b98bec = x437fa02210b98bec;
			xdcf7b74ddd6caa25.x01dbeb0555bc8277 = x01dbeb0555bc8277;
			xdcf7b74ddd6caa25.x66c02128fdc6436a = x66c02128fdc6436a;
			xdcf7b74ddd6caa25.x7e860e67e98d3221 = x7e860e67e98d3221;
			xda9811b1693213e4 = true;
		}
	}

	internal bool xa8337de37ecaeb68(x109e3389933c23a8 xdcf7b74ddd6caa25)
	{
		if (xdcf7b74ddd6caa25 != null)
		{
			return x1452024de1251c74 == xdcf7b74ddd6caa25.x1452024de1251c74;
		}
		return false;
	}

	internal Rectangle x15e4666f7a70d07b()
	{
		Rectangle boundsImpl = GetBoundsImpl();
		return GetWrapBoundsImpl(boundsImpl);
	}

	internal void x2e6c3c7a54659350()
	{
		xdded4dd43a273f1e();
		xdb0b773293f55917 = GetWrapBoundsImpl(x930e7264e89b1eb5);
	}

	internal Rectangle x3a116ea4a0f97ab2(Rectangle x26545669838eb36e)
	{
		return Rectangle.Intersect(x4b6965fe04aaacd8, x26545669838eb36e);
	}

	internal static Point x2206903f9421fd4b(x398b3bd0acd94b61 xd7e5673853e47af4, bool x6ee567696ab44a53)
	{
		Point result = xd7e5673853e47af4.x588d7683a6d1fbd5();
		if (x6ee567696ab44a53)
		{
			Point point = xd7e5673853e47af4.xc255c495fd9232ca.x588d7683a6d1fbd5();
			result = new Point(result.X - point.X, result.Y - point.Y);
		}
		return result;
	}

	protected virtual Point GetColumnReference()
	{
		x398b3bd0acd94b61 x398b3bd0acd94b62 = (x38ced5a01a389303.x53111d6596d16a99.xf684fc5abe7ca67a ? x38ced5a01a389303.xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad) : x38ced5a01a389303.x53111d6596d16a99.x8b8a0a04b3aeaf3a);
		int x = x588d7683a6d1fbd5(x398b3bd0acd94b62).X;
		int y = x + x398b3bd0acd94b62.xdc1bf80853046136;
		return new Point(x, y);
	}

	protected static Point x588d7683a6d1fbd5(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		return x398b3bd0acd94b61.xce92de628aa023cf(xd7e5673853e47af4, Point.Empty, x954503abc583f675.xa65184d44a47025b);
	}

	internal void x379ae16af0ba8e51()
	{
		for (x398b3bd0acd94b61 x398b3bd0acd94b62 = x38ced5a01a389303; x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.xf432ece93e450408())
		{
			x398b3bd0acd94b62.x379ae16af0ba8e51(x6fcedf7742596b6c.x7da8495344a79eb8);
			if (x398b3bd0acd94b62 == xed3e432f7c9bf846)
			{
				break;
			}
		}
	}

	internal x398b3bd0acd94b61 x11cf6ba103816bb7()
	{
		x398b3bd0acd94b61 x398b3bd0acd94b62 = ((xf8c20af9fe5edca0 == 25604) ? x38ced5a01a389303.xc255c495fd9232ca : x38ced5a01a389303);
		if (xb6ef83a1238c066c != xae532cfb203d8406.x11db8fc7f469a2fc && x38ced5a01a389303.xce4443deee105995(x954503abc583f675.x11db8fc7f469a2fc) != null)
		{
			return xa7a98231d4a67a0f.x783e7024d38a8439(x398b3bd0acd94b62);
		}
		return x398b3bd0acd94b62;
	}

	protected virtual Point[] GetVerticesImpl()
	{
		return x6e1e967452d5d93b(x6ae4612a8469678e);
	}

	[JavaThrows(true)]
	protected abstract Rectangle GetBoundsImpl();

	private void xdded4dd43a273f1e()
	{
		x930e7264e89b1eb5 = GetBoundsImpl();
		xb491148c73c04cc5().x2a0cb95ab84ba877(this);
	}

	protected Rectangle x0db3a2811a364ada(Rectangle xda73fcb97c77d998)
	{
		Rectangle wrapBoundsImpl = GetWrapBoundsImpl(xda73fcb97c77d998);
		Rectangle rectangle = x133db4697114502f(wrapBoundsImpl);
		int num = rectangle.X - wrapBoundsImpl.X;
		int num2 = rectangle.Y - wrapBoundsImpl.Y;
		if (num == 0 && num2 == 0)
		{
			return xda73fcb97c77d998;
		}
		return new Rectangle(xda73fcb97c77d998.X + num, xda73fcb97c77d998.Y + num2, xda73fcb97c77d998.Width, xda73fcb97c77d998.Height);
	}

	protected Rectangle x133db4697114502f(Rectangle xda73fcb97c77d998)
	{
		xd6dfbe8f46b4e709 xd6dfbe8f46b4e710 = xb491148c73c04cc5();
		return xd6dfbe8f46b4e710.x133db4697114502f(this, xda73fcb97c77d998);
	}

	private xd6dfbe8f46b4e709 xb491148c73c04cc5()
	{
		return xb6ef83a1238c066c switch
		{
			xae532cfb203d8406.x53111d6596d16a99 => ((xc7f90d9c7c51cede)xc255c495fd9232ca).x9f0adc3a990eec79, 
			xae532cfb203d8406.x11db8fc7f469a2fc => ((x86accec882b7012a)xc255c495fd9232ca).x9f0adc3a990eec79, 
			xae532cfb203d8406.x56ef522aac8e098b => ((xc7f90d9c7c51cede)xc255c495fd9232ca).x358167681e04eecb, 
			xae532cfb203d8406.xb3f85ba4541b1ea9 => ((x86accec882b7012a)xc255c495fd9232ca).x358167681e04eecb, 
			_ => throw new InvalidOperationException("Unexpected floater impact value."), 
		};
	}

	[JavaThrows(true)]
	protected abstract Rectangle GetWrapBoundsImpl(Rectangle bounds);

	protected x109e3389933c23a8(object anchor, x8e3db3d2a7fdbd41 pr, x398b3bd0acd94b61 first, x398b3bd0acd94b61 last)
	{
		xd86e4bac41e028b8 = anchor;
		x66c02128fdc6436a = pr;
		x749f8493ad444bdb = first;
		x576773fbf9307688 = last;
		x01dbeb0555bc8277 = xae532cfb203d8406.x236cb0a4295bc034;
		x930e7264e89b1eb5 = new Rectangle(int.MinValue, int.MinValue, int.MinValue, int.MinValue);
		xdb0b773293f55917 = new Rectangle(int.MinValue, int.MinValue, int.MinValue, int.MinValue);
	}

	protected int x795e09a07e435cf4(int x9b0739496f8b5475)
	{
		Point point = x5c0fc42285b6da88();
		int x = point.X;
		int y = point.Y;
		int num;
		if (!x752cfab9af626fd5)
		{
			switch (x66c02128fdc6436a.xab67cb9464a3325b)
			{
			case HorizontalAlignment.Inside:
				return x2754dfc1abcbef7c() ? x : (y - x9b0739496f8b5475);
			case (HorizontalAlignment)(-1):
				return x;
			case (HorizontalAlignment)(-2):
				return x - x9b0739496f8b5475;
			case HorizontalAlignment.Left:
				return (x66c02128fdc6436a.x0fcdf9c7f9f2eb9e == RelativeHorizontalPosition.Page) ? Math.Max(0, y - x9b0739496f8b5475) : x;
			case HorizontalAlignment.Center:
				return (x + y - x9b0739496f8b5475) / 2;
			case HorizontalAlignment.Outside:
				return x2754dfc1abcbef7c() ? (y - x9b0739496f8b5475) : x;
			case HorizontalAlignment.Right:
				return (x66c02128fdc6436a.x0fcdf9c7f9f2eb9e == RelativeHorizontalPosition.Page) ? Math.Min(x, y - x9b0739496f8b5475) : (y - x9b0739496f8b5475);
			default:
				num = x + x66c02128fdc6436a.x72d92bd1aff02e37;
				if (XMustBeInsidePage)
				{
					num = x569e60f0e9e2838b(num, x9b0739496f8b5475, xa65184d44a47025b.xdc1bf80853046136);
				}
				return FixNegativeOrigin(num);
			}
		}
		num = x66c02128fdc6436a.xab67cb9464a3325b switch
		{
			HorizontalAlignment.Inside => x2754dfc1abcbef7c() ? x : (y - x9b0739496f8b5475), 
			HorizontalAlignment.Left => x, 
			HorizontalAlignment.Center => (x + y - x9b0739496f8b5475) / 2, 
			HorizontalAlignment.Outside => x2754dfc1abcbef7c() ? (y - x9b0739496f8b5475) : x, 
			HorizontalAlignment.Right => y - x9b0739496f8b5475, 
			_ => x + x66c02128fdc6436a.x72d92bd1aff02e37, 
		};
		return (xb6ef83a1238c066c == xae532cfb203d8406.x11db8fc7f469a2fc) ? Math.Max(0, num) : num;
	}

	private static int x569e60f0e9e2838b(int x9c3c185e7046dc72, int x961016a387451f05, int x362993ef901691f7)
	{
		if (x9c3c185e7046dc72 + x961016a387451f05 <= x362993ef901691f7)
		{
			return x9c3c185e7046dc72;
		}
		return x362993ef901691f7 - x961016a387451f05;
	}

	private bool x2754dfc1abcbef7c()
	{
		return !x0d299f323d241756.x7e32f71c3f39b6bc(xa65184d44a47025b.x5138ebdd7c56c151());
	}

	internal Point x5c0fc42285b6da88()
	{
		RelativeHorizontalPosition relativeHorizontalPosition = x66c02128fdc6436a.x0fcdf9c7f9f2eb9e;
		if (relativeHorizontalPosition == RelativeHorizontalPosition.OutsideMargin && !x2754dfc1abcbef7c())
		{
			relativeHorizontalPosition = RelativeHorizontalPosition.InsideMargin;
		}
		else if (relativeHorizontalPosition == RelativeHorizontalPosition.InsideMargin && !x2754dfc1abcbef7c())
		{
			relativeHorizontalPosition = RelativeHorizontalPosition.OutsideMargin;
		}
		int num;
		int y;
		if (x752cfab9af626fd5)
		{
			x86accec882b7012a x86accec882b7012a2 = (x86accec882b7012a)xc255c495fd9232ca;
			switch (relativeHorizontalPosition)
			{
			case RelativeHorizontalPosition.LeftMargin:
			case RelativeHorizontalPosition.OutsideMargin:
				num = 0;
				y = x86accec882b7012a2.x5c392d6ad6fe7e28;
				break;
			case RelativeHorizontalPosition.RightMargin:
			case RelativeHorizontalPosition.InsideMargin:
				num = x86accec882b7012a2.xdc1bf80853046136 - x86accec882b7012a2.xf159a68356fd5b23;
				y = x86accec882b7012a2.xdc1bf80853046136;
				break;
			case RelativeHorizontalPosition.Page:
				num = 0;
				y = x86accec882b7012a2.xdc1bf80853046136;
				break;
			case RelativeHorizontalPosition.Character:
				num = x588d7683a6d1fbd5((xa67197c42bddc7dc)x1452024de1251c74).X - x588d7683a6d1fbd5(x86accec882b7012a2).X;
				y = num;
				break;
			default:
				num = x86accec882b7012a2.x5c392d6ad6fe7e28;
				y = x86accec882b7012a2.xdc1bf80853046136 - x86accec882b7012a2.xf159a68356fd5b23;
				break;
			}
		}
		else
		{
			xc7f90d9c7c51cede xc7f90d9c7c51cede2 = (xc7f90d9c7c51cede)x38ced5a01a389303.xce4443deee105995(x954503abc583f675.xa65184d44a47025b);
			xf6689e0eed33812c xf6689e0eed33812c2 = (x38ced5a01a389303.x53111d6596d16a99.xf684fc5abe7ca67a ? ((xf6689e0eed33812c)x38ced5a01a389303.x332a8eedb847940d.x5c76a7629364cf4d(x5a5e07e9fa12451a.x10d7a1cae426b158)) : xc7f90d9c7c51cede2.x3c1c340351d94fbd);
			if (relativeHorizontalPosition == RelativeHorizontalPosition.Page)
			{
				switch (x66c02128fdc6436a.xab67cb9464a3325b)
				{
				case HorizontalAlignment.Left:
					relativeHorizontalPosition = RelativeHorizontalPosition.LeftMargin;
					break;
				case HorizontalAlignment.Right:
					relativeHorizontalPosition = RelativeHorizontalPosition.RightMargin;
					break;
				}
			}
			Point point = xf6689e0eed33812c2.x8f752b61013f63db(xc7f90d9c7c51cede2);
			switch (relativeHorizontalPosition)
			{
			case RelativeHorizontalPosition.LeftMargin:
			case RelativeHorizontalPosition.OutsideMargin:
				num = 0;
				y = point.X;
				break;
			case RelativeHorizontalPosition.RightMargin:
			case RelativeHorizontalPosition.InsideMargin:
				num = point.Y;
				y = xf6689e0eed33812c2.xf48cd6e82340ac70.x3114e27f80122981;
				break;
			case RelativeHorizontalPosition.Margin:
				num = point.X;
				y = point.Y;
				break;
			case RelativeHorizontalPosition.Page:
				num = 0;
				y = xf6689e0eed33812c2.xf48cd6e82340ac70.x3114e27f80122981;
				break;
			case RelativeHorizontalPosition.Character:
				num = x588d7683a6d1fbd5((xa67197c42bddc7dc)x1452024de1251c74).X;
				y = num;
				break;
			default:
			{
				Point columnReference = GetColumnReference();
				num = columnReference.X;
				y = columnReference.Y;
				break;
			}
			}
		}
		return new Point(num, y);
	}

	protected int x29b834e8e9ff09ed(int x4d5aabc7a55b12ba)
	{
		Point point = x2b0a23f494142521();
		int x = point.X;
		int y = point.Y;
		VerticalAlignment verticalAlignment = x66c02128fdc6436a.xf6ce0e8106e6a1d8;
		if (x752cfab9af626fd5 && verticalAlignment != 0)
		{
			verticalAlignment = VerticalAlignment.Top;
		}
		switch (verticalAlignment)
		{
		case VerticalAlignment.Top:
		case VerticalAlignment.Inside:
			return x;
		case VerticalAlignment.Center:
			return (x + y - x4d5aabc7a55b12ba) / 2;
		case VerticalAlignment.Bottom:
		case VerticalAlignment.Outside:
			return y - x4d5aabc7a55b12ba;
		default:
		{
			int num = x + x66c02128fdc6436a.xe360b1885d8d4a41;
			if (xb6ef83a1238c066c != xae532cfb203d8406.x11db8fc7f469a2fc && YMustBeInsidePage)
			{
				num = x569e60f0e9e2838b(num, x4d5aabc7a55b12ba, GetYCorrectionBottom());
			}
			return FixNegativeOrigin(num);
		}
		}
	}

	private Point x2b0a23f494142521()
	{
		bool flag = !x752cfab9af626fd5 && xf8c20af9fe5edca0 == 25604 && ((xa67197c42bddc7dc)x1452024de1251c74).xce4443deee105995(x954503abc583f675.x11db8fc7f469a2fc) != null && (x66c02128fdc6436a.x0fcdf9c7f9f2eb9e == RelativeHorizontalPosition.Character || x66c02128fdc6436a.x5d0ebb82ae68cc43 == RelativeVerticalPosition.Line);
		int num;
		int num2;
		if (x752cfab9af626fd5 || flag)
		{
			x86accec882b7012a x86accec882b7012a2 = (x86accec882b7012a)x38ced5a01a389303.xce4443deee105995(x954503abc583f675.x11db8fc7f469a2fc);
			switch (x66c02128fdc6436a.x5d0ebb82ae68cc43)
			{
			case RelativeVerticalPosition.Margin:
			case RelativeVerticalPosition.Page:
			case RelativeVerticalPosition.TopMargin:
			case RelativeVerticalPosition.BottomMargin:
			case RelativeVerticalPosition.InsideMargin:
			case RelativeVerticalPosition.OutsideMargin:
				num = x86accec882b7012a2.x3dcafc2d758260e1;
				num2 = num;
				break;
			case RelativeVerticalPosition.Line:
			{
				xf6937c72cebe4ad1 xf6937c72cebe4ad2 = (xf6937c72cebe4ad1)x38ced5a01a389303.xce4443deee105995(x954503abc583f675.x48cc0c3eaf9f5f05);
				num = xa7a98231d4a67a0f.x80ac9fd414d4713b(xf6937c72cebe4ad2) + xf6937c72cebe4ad2.xe36d690dfc898f25 + xf6937c72cebe4ad2.x147605d3f215e4c9.xd72444cc04207b76;
				num2 = num;
				break;
			}
			default:
				num = xcc69ae5a5063e790();
				num2 = num;
				break;
			}
			if (flag)
			{
				Point point = x86accec882b7012a2.x588d7683a6d1fbd5();
				num += point.Y;
				num2 += point.Y;
			}
		}
		else
		{
			RelativeVerticalPosition relativeVerticalPosition = x66c02128fdc6436a.x5d0ebb82ae68cc43;
			xc7f90d9c7c51cede xc7f90d9c7c51cede2 = (xc7f90d9c7c51cede)x38ced5a01a389303.xce4443deee105995(x954503abc583f675.xa65184d44a47025b);
			if (x0d299f323d241756.x7e32f71c3f39b6bc(xc7f90d9c7c51cede2.x5138ebdd7c56c151()))
			{
				switch (relativeVerticalPosition)
				{
				case RelativeVerticalPosition.InsideMargin:
				case RelativeVerticalPosition.OutsideMargin:
					relativeVerticalPosition = RelativeVerticalPosition.BottomMargin;
					break;
				}
			}
			switch (relativeVerticalPosition)
			{
			case RelativeVerticalPosition.TopMargin:
			case RelativeVerticalPosition.InsideMargin:
			case RelativeVerticalPosition.OutsideMargin:
				num = 0;
				num2 = xc7f90d9c7c51cede2.xd985b37e5f570f69;
				break;
			case RelativeVerticalPosition.BottomMargin:
				num = xc7f90d9c7c51cede2.xd7fab63fabd0a319;
				num2 = xc7f90d9c7c51cede2.xb0f146032f47c24e;
				break;
			case RelativeVerticalPosition.Margin:
				num = xc7f90d9c7c51cede2.xd985b37e5f570f69;
				num2 = xc7f90d9c7c51cede2.xd7fab63fabd0a319;
				break;
			case RelativeVerticalPosition.Line:
			{
				xf6937c72cebe4ad1 x5a7799e1836857e = ((xa67197c42bddc7dc)x1452024de1251c74).x5a7799e1836857e3;
				num = xa7a98231d4a67a0f.x80ac9fd414d4713b(x5a7799e1836857e) + x588d7683a6d1fbd5(x5a7799e1836857e.xc255c495fd9232ca).Y;
				num2 = num;
				break;
			}
			case RelativeVerticalPosition.Page:
				if (x66c02128fdc6436a.xf6ce0e8106e6a1d8 == VerticalAlignment.Inside || x66c02128fdc6436a.xf6ce0e8106e6a1d8 == VerticalAlignment.Outside)
				{
					num = xc7f90d9c7c51cede2.x3c1c340351d94fbd.xf48cd6e82340ac70.x2cdd18500759ef24 / 2;
					num2 = xc7f90d9c7c51cede2.xb0f146032f47c24e - x38ced5a01a389303.x776fd7c2f7270172().x3c1c340351d94fbd.xf48cd6e82340ac70.x9c94a32b8fac5210 / 2;
				}
				else
				{
					num = 0;
					num2 = xc7f90d9c7c51cede2.xb0f146032f47c24e;
				}
				break;
			default:
				if (xf8c20af9fe5edca0 == 25604)
				{
					x694f001896973fe3 x694f001896973fe4 = (x694f001896973fe3)x38ced5a01a389303.xce4443deee105995(x954503abc583f675.xa19781cfbe8b4961);
					if (x694f001896973fe4 != null)
					{
						while (x694f001896973fe4.xc255c495fd9232ca.x954503abc583f675 == x954503abc583f675.x11db8fc7f469a2fc)
						{
							x694f001896973fe4 = (x694f001896973fe3)x694f001896973fe4.xc255c495fd9232ca.xce4443deee105995(x954503abc583f675.xa19781cfbe8b4961);
						}
						num = x588d7683a6d1fbd5(x694f001896973fe4).Y;
						num2 = num + x694f001896973fe4.xb0f146032f47c24e;
						break;
					}
				}
				num = xcc69ae5a5063e790();
				num2 = num;
				break;
			}
		}
		return new Point(num, num2);
	}

	private x1073233de8252b3e xb8f59e47e556e4de()
	{
		if (!x752cfab9af626fd5)
		{
			return x38ced5a01a389303.x776fd7c2f7270172();
		}
		return x38ced5a01a389303.xfeb19f1007c0b581();
	}

	private static Point[] x6e1e967452d5d93b(Rectangle x26545669838eb36e)
	{
		return new Point[4]
		{
			new Point(x26545669838eb36e.Left, x26545669838eb36e.Top),
			new Point(x26545669838eb36e.Right, x26545669838eb36e.Top),
			new Point(x26545669838eb36e.Right, x26545669838eb36e.Bottom),
			new Point(x26545669838eb36e.Left, x26545669838eb36e.Bottom)
		};
	}
}
