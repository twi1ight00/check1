using System;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class x2f70f4b50b541c08
{
	private x2f70f4b50b541c08()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, xeedad81aaed42a76 x789564759d365819)
	{
		string xa66385d80d4d296f = xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f;
		Shape shape = new Shape(xe134235b3526fa75.x2c8c6741422a1298);
		x789564759d365819?.xab3af626b1405ee8(shape.xeedad81aaed42a76);
		xf7125312c7ee115c xf7125312c7ee115c = new xf7125312c7ee115c();
		xf7125312c7ee115c xf7125312c7ee115c2 = new xf7125312c7ee115c();
		xf7125312c7ee115c2.xae20093bed1e48a8(4155, ShapeType.Line);
		x1989ad42a196d646(xe134235b3526fa75, xf7125312c7ee115c2);
		x253dc1c25dfd49a2.x0c1288d16c9571df(xe134235b3526fa75, xf7125312c7ee115c);
		shape.xf7125312c7ee115c = xf7125312c7ee115c;
		xf7125312c7ee115c2.xab3af626b1405ee8(shape.xf7125312c7ee115c);
		xf4ad35a4c681d85d(xe134235b3526fa75, xa66385d80d4d296f, xf7125312c7ee115c2);
		x8b2c3c076d5a7daf.AppendChild(shape);
	}

	private static void xf4ad35a4c681d85d(xf871da68decec406 xe134235b3526fa75, string x121383aa64985888, xf7125312c7ee115c xb1b96b4a406833d8)
	{
		while (xe134235b3526fa75.xca994afbcb9073a2.x152cbadbfa8061b1(x121383aa64985888))
		{
			if (!xe134235b3526fa75.xb18e918c8e329f66(xb1b96b4a406833d8))
			{
				xe134235b3526fa75.xca994afbcb9073a2.IgnoreElement();
			}
		}
	}

	internal static void x1989ad42a196d646(xf871da68decec406 xe134235b3526fa75, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		double x6650a9a61c6142e = 0.0;
		double xaa76c33ed453ba = 0.0;
		double xe75e43d266eef = 0.0;
		double x9b9be9a08b5115a = 0.0;
		string x8b0a6a8c69ab5cff = "";
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xf871da68decec406.x46e6752379e6650e(xe134235b3526fa75, xa5e8b8b5991a4e1d) && !xf871da68decec406.xec2649804854d946(xe134235b3526fa75, xa5e8b8b5991a4e1d))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "type":
					xa5e8b8b5991a4e1d.xae20093bed1e48a8(771, x0eb9a864413f34de.x445ccf57cde58615(xca994afbcb9073a.xd2f68ee6f47e9dfb));
					break;
				case "x1":
					x6650a9a61c6142e = xbb857c9fc36f5054.xc42baa2576960ea5(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					break;
				case "y1":
					xaa76c33ed453ba = xbb857c9fc36f5054.xc42baa2576960ea5(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					break;
				case "x2":
					xe75e43d266eef = xbb857c9fc36f5054.xc42baa2576960ea5(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					break;
				case "y2":
					x9b9be9a08b5115a = xbb857c9fc36f5054.xc42baa2576960ea5(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					break;
				case "transform":
					x8b0a6a8c69ab5cff = xca994afbcb9073a.xd2f68ee6f47e9dfb;
					break;
				}
			}
		}
		xf871da68decec406.xc8cbf0c64adea241(xa5e8b8b5991a4e1d, x8b0a6a8c69ab5cff);
		xc6b4c0fd353e4c10(xa5e8b8b5991a4e1d, x6650a9a61c6142e, xaa76c33ed453ba, xe75e43d266eef, x9b9be9a08b5115a);
	}

	private static void xc6b4c0fd353e4c10(xf7125312c7ee115c xa5e8b8b5991a4e1d, double x6650a9a61c6142e3, double xaa76c33ed453ba57, double xe75e43d266eef799, double x9b9be9a08b5115a8)
	{
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(4129, Math.Min(x6650a9a61c6142e3, xe75e43d266eef799));
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(4130, Math.Min(xaa76c33ed453ba57, x9b9be9a08b5115a8));
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(4131, Math.Abs(x6650a9a61c6142e3 - xe75e43d266eef799));
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(4132, Math.Abs(xaa76c33ed453ba57 - x9b9be9a08b5115a8));
		if (x6650a9a61c6142e3 > xe75e43d266eef799 && xaa76c33ed453ba57 > x9b9be9a08b5115a8)
		{
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4096, FlipOrientation.Both);
		}
		else if (x6650a9a61c6142e3 > xe75e43d266eef799)
		{
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4096, FlipOrientation.Horizontal);
		}
		else if (xaa76c33ed453ba57 > x9b9be9a08b5115a8)
		{
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4096, FlipOrientation.Vertical);
		}
	}
}
