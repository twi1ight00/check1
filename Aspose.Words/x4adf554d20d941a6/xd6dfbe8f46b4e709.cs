using System.Drawing;
using Aspose.Words.Drawing;

namespace x4adf554d20d941a6;

internal class xd6dfbe8f46b4e709
{
	private readonly xeae7c7333b3d6e96 xba505b457f56974b = new xeae7c7333b3d6e96();

	internal void x2a0cb95ab84ba877(x109e3389933c23a8 xdcf7b74ddd6caa25)
	{
		xeae7c7333b3d6e96 xeae7c7333b3d6e97 = xba505b457f56974b;
		xeae7c7333b3d6e97.x73f63188bdafaeb6();
		xeae7c7333b3d6e97.x2a0cb95ab84ba877(xdcf7b74ddd6caa25);
	}

	internal Rectangle x133db4697114502f(x109e3389933c23a8 xdcf7b74ddd6caa25, Rectangle xda73fcb97c77d998)
	{
		Point point = xdcf7b74ddd6caa25.x5c0fc42285b6da88();
		int x046c3c7f1587ec = point.X;
		int x8daa78cf95eabc = point.Y;
		if (xdcf7b74ddd6caa25.xf684fc5abe7ca67a && xdcf7b74ddd6caa25.x705ed5f9769744e5.x0fcdf9c7f9f2eb9e == RelativeHorizontalPosition.Column && !xdcf7b74ddd6caa25.x752cfab9af626fd5)
		{
			x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xdcf7b74ddd6caa25.x38ced5a01a389303.xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad);
			x046c3c7f1587ec = x852fe8bb5ac31099.x8df91a2f90079e88 + x852fe8bb5ac31099.x5c392d6ad6fe7e28;
			x8daa78cf95eabc = x852fe8bb5ac31099.x419ba17a5322627b - x852fe8bb5ac31099.xf159a68356fd5b23;
		}
		Rectangle rectangle = xda73fcb97c77d998;
		bool flag;
		do
		{
			flag = false;
			foreach (object item in xba505b457f56974b)
			{
				x109e3389933c23a8 x109e3389933c23a9 = (x109e3389933c23a8)item;
				Rectangle x7835973da2834a1b = x109e3389933c23a9.x7835973da2834a1b;
				if (!xdcf7b74ddd6caa25.xa8337de37ecaeb68(x109e3389933c23a9) && rectangle.IntersectsWith(x7835973da2834a1b) && !xa3a454d5dfb5b9a5(xdcf7b74ddd6caa25, x109e3389933c23a9))
				{
					rectangle = x133db4697114502f(xdcf7b74ddd6caa25, xda73fcb97c77d998, rectangle, x7835973da2834a1b, x046c3c7f1587ec, x8daa78cf95eabc);
					flag = true;
					break;
				}
			}
		}
		while (flag);
		return rectangle;
	}

	private static Rectangle x133db4697114502f(x109e3389933c23a8 xdcf7b74ddd6caa25, Rectangle x4e36d49fd6fec1a1, Rectangle x34f7739f7f0e6d1b, Rectangle xa41b56b585247c0a, int x046c3c7f1587ec21, int x8daa78cf95eabc80)
	{
		Rectangle result = Rectangle.Empty;
		bool flag;
		if (xdcf7b74ddd6caa25.xf8c20af9fe5edca0 == 21595 && xdcf7b74ddd6caa25.x705ed5f9769744e5.xab67cb9464a3325b == HorizontalAlignment.Right)
		{
			flag = x046c3c7f1587ec21 + x4e36d49fd6fec1a1.Width - xdcf7b74ddd6caa25.xc13bc3847813c8aa < xa41b56b585247c0a.X;
			if (flag)
			{
				result = new Rectangle(xa41b56b585247c0a.X - x34f7739f7f0e6d1b.Width, x34f7739f7f0e6d1b.Y, x4e36d49fd6fec1a1.Width, x4e36d49fd6fec1a1.Height);
			}
		}
		else
		{
			flag = xa41b56b585247c0a.Right + x34f7739f7f0e6d1b.Width - xdcf7b74ddd6caa25.x330b27a3d588a781 < x8daa78cf95eabc80;
			if (flag)
			{
				result = new Rectangle(xa41b56b585247c0a.Right, x34f7739f7f0e6d1b.Y, x4e36d49fd6fec1a1.Width, x4e36d49fd6fec1a1.Height);
			}
		}
		if (!flag)
		{
			result = new Rectangle(x4e36d49fd6fec1a1.X, xa41b56b585247c0a.Bottom, x4e36d49fd6fec1a1.Width, x4e36d49fd6fec1a1.Height);
		}
		return result;
	}

	internal static bool xa3a454d5dfb5b9a5(x109e3389933c23a8 x19218ffab70283ef, x109e3389933c23a8 xe7ebe10fa44d8d49)
	{
		if (x19218ffab70283ef == null || xe7ebe10fa44d8d49 == null)
		{
			return true;
		}
		x46bd7081dec08b8e x46bd7081dec08b8e2 = (x46bd7081dec08b8e)x19218ffab70283ef.x38ced5a01a389303.xce4443deee105995(x954503abc583f675.x924e4e3967c494db);
		if (x46bd7081dec08b8e2 != null)
		{
			return x84a02529e10f0508(x19218ffab70283ef, x46bd7081dec08b8e2, xe7ebe10fa44d8d49);
		}
		x46bd7081dec08b8e x46bd7081dec08b8e3 = (x46bd7081dec08b8e)xe7ebe10fa44d8d49.x38ced5a01a389303.xce4443deee105995(x954503abc583f675.x924e4e3967c494db);
		if (x46bd7081dec08b8e3 == null)
		{
			if (x19218ffab70283ef.x705ed5f9769744e5.xed344a170caf7ac3)
			{
				return xe7ebe10fa44d8d49.x705ed5f9769744e5.xed344a170caf7ac3;
			}
			return false;
		}
		return x9765f1a28279e320(xe7ebe10fa44d8d49, x19218ffab70283ef);
	}

	private static bool x84a02529e10f0508(x109e3389933c23a8 xdf6745d7ac96791e, x46bd7081dec08b8e x03e7e66b1eecc96f, x109e3389933c23a8 xe7ebe10fa44d8d49)
	{
		x46bd7081dec08b8e x46bd7081dec08b8e2 = (x46bd7081dec08b8e)xe7ebe10fa44d8d49.x38ced5a01a389303.xce4443deee105995(x954503abc583f675.x924e4e3967c494db);
		if (x46bd7081dec08b8e2 == x03e7e66b1eecc96f)
		{
			if (xdf6745d7ac96791e.x705ed5f9769744e5.xed344a170caf7ac3)
			{
				return xe7ebe10fa44d8d49.x705ed5f9769744e5.xed344a170caf7ac3;
			}
			return false;
		}
		if (x46bd7081dec08b8e2 != null)
		{
			return true;
		}
		return x9765f1a28279e320(xdf6745d7ac96791e, xe7ebe10fa44d8d49);
	}

	private static bool x9765f1a28279e320(x109e3389933c23a8 xdf6745d7ac96791e, x109e3389933c23a8 xf3283297b39c9a6b)
	{
		if (!xdf6745d7ac96791e.x5a3440516914ae4b)
		{
			return true;
		}
		if (!xf3283297b39c9a6b.x705ed5f9769744e5.xed344a170caf7ac3)
		{
			return xa74dda1d6cb1f283(xf3283297b39c9a6b);
		}
		return true;
	}

	private static bool xa74dda1d6cb1f283(x109e3389933c23a8 xf3283297b39c9a6b)
	{
		if (xf3283297b39c9a6b.xf8c20af9fe5edca0 != 25604)
		{
			return xf3283297b39c9a6b.x705ed5f9769744e5.x5d0ebb82ae68cc43 == RelativeVerticalPosition.Paragraph;
		}
		return false;
	}
}
