using System;
using System.Collections;
using System.Drawing;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x1495530f35d79681;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x7c7a1dceb600404e;

internal class xcb00358ab5144003
{
	private const string xf340e6292967b718 = "Import of element '{0}' is not supported upon VML import by Aspose.Words.";

	private static readonly char[] xa99d268ef36b300a = new char[2] { ',', ';' };

	private xcb00358ab5144003()
	{
	}

	internal static void x466976bbae34cc54(x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		Shape shape = new Shape(x0f7b23d1c393aed9.x2c8c6741422a1298, ShapeType.Rectangle);
		x0f7b23d1c393aed9.x2c8c6741422a1298.xffc75a489655380b(shape);
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "color":
			{
				x26d9ecb4bdf0456d x26d9ecb4bdf0456d = xd76179d16486fd56.xe74389aafc9d4795(x3bcd232d01c.xd2f68ee6f47e9dfb);
				if (x26d9ecb4bdf0456d != x26d9ecb4bdf0456d.x8f02f53f1587477d)
				{
					shape.x0817d5cde9e19bf6(385, x26d9ecb4bdf0456d);
				}
				break;
			}
			case "themeColor":
				shape.x0817d5cde9e19bf6(4147, x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			case "themeShade":
				shape.x0817d5cde9e19bf6(4148, x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			case "themeTint":
				shape.x0817d5cde9e19bf6(4149, x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			}
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("background"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "background")
			{
				xfe4f7dca36c0076c(x0f7b23d1c393aed9, shape);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	internal static void x6ba34f1965cf9ac5(x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		Shape x5770cdefd8931aa = new Shape(x0f7b23d1c393aed9.x2c8c6741422a1298, ShapeType.Rectangle);
		x0f7b23d1c393aed9.x2c8c6741422a1298.xffc75a489655380b(x5770cdefd8931aa);
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("bgPict"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "binData":
				x0f7b23d1c393aed9.x2b6e606d842be5f3();
				break;
			case "background":
				if (x3bcd232d01c.xd8a1c7c41bfbcde0 == "w")
				{
					x2f43fecf92745a82(x0f7b23d1c393aed9, x5770cdefd8931aa);
				}
				else if (x3bcd232d01c.xd8a1c7c41bfbcde0 == "v")
				{
					xfe4f7dca36c0076c(x0f7b23d1c393aed9, x5770cdefd8931aa);
				}
				break;
			}
		}
	}

	private static void x2f43fecf92745a82(x874ec168cb1feb74 x0f7b23d1c393aed9, ShapeBase x5770cdefd8931aa9)
	{
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = x3bcd232d01c.xd2f68ee6f47e9dfb;
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "bgcolor":
				if (xd2f68ee6f47e9dfb != "white")
				{
					x5770cdefd8931aa9.x0817d5cde9e19bf6(385, xd76179d16486fd56.xe74389aafc9d4795(xd2f68ee6f47e9dfb));
				}
				break;
			case "background":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4111, x0f7b23d1c393aed9.x7b29fad09d9101c5(xd2f68ee6f47e9dfb));
				break;
			}
		}
	}

	internal static xf7125312c7ee115c xdbced29cb6a266e4(x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		Shape shape = new Shape(x0f7b23d1c393aed9.x2c8c6741422a1298);
		xfe4f7dca36c0076c(x0f7b23d1c393aed9, shape);
		return shape.xf7125312c7ee115c;
	}

	internal static ShapeBase x06b0e25aa6ad68a9(x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		ShapeBase result = null;
		x3bcd232d01c.x99f8cdb2827fa686();
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			ShapeBase shapeBase = xb9d4bc2d67dd8604(x0f7b23d1c393aed9);
			if (shapeBase != null)
			{
				result = shapeBase;
			}
		}
		return result;
	}

	private static ShapeBase xb9d4bc2d67dd8604(x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		ShapeBase shapeBase = null;
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "shapetype":
		{
			string xeaf1b27180c0557b = x3bcd232d01c.xd68abcd61e368af9("id", null);
			xf7125312c7ee115c xa5e8b8b5991a4e1d = xdbced29cb6a266e4(x0f7b23d1c393aed9);
			x0f7b23d1c393aed9.xedd58b27cf69c58d(xeaf1b27180c0557b, xa5e8b8b5991a4e1d);
			break;
		}
		case "binData":
			x0f7b23d1c393aed9.x2b6e606d842be5f3();
			break;
		case "group":
			shapeBase = new GroupShape(x0f7b23d1c393aed9.x2c8c6741422a1298);
			xfe4f7dca36c0076c(x0f7b23d1c393aed9, shapeBase);
			break;
		case "shape":
		case "polyline":
			shapeBase = new Shape(x0f7b23d1c393aed9.x2c8c6741422a1298);
			xfe4f7dca36c0076c(x0f7b23d1c393aed9, shapeBase);
			break;
		case "rect":
			shapeBase = new Shape(x0f7b23d1c393aed9.x2c8c6741422a1298, ShapeType.Rectangle);
			xfe4f7dca36c0076c(x0f7b23d1c393aed9, shapeBase);
			break;
		case "roundrect":
			shapeBase = new Shape(x0f7b23d1c393aed9.x2c8c6741422a1298, ShapeType.RoundRectangle);
			xfe4f7dca36c0076c(x0f7b23d1c393aed9, shapeBase);
			break;
		case "line":
			shapeBase = new Shape(x0f7b23d1c393aed9.x2c8c6741422a1298, ShapeType.Line);
			xfe4f7dca36c0076c(x0f7b23d1c393aed9, shapeBase);
			break;
		case "oval":
			shapeBase = new Shape(x0f7b23d1c393aed9.x2c8c6741422a1298, ShapeType.Ellipse);
			xfe4f7dca36c0076c(x0f7b23d1c393aed9, shapeBase);
			break;
		case "scriptAnchor":
			shapeBase = x0fc8e823a82068a5(x0f7b23d1c393aed9);
			break;
		case "arc":
		case "image":
		case "curve":
			x3bcd232d01c.IgnoreElement();
			break;
		case "ocx":
			shapeBase = xd344eb866bc83d16.xda2e825e9f754413(x0f7b23d1c393aed9);
			break;
		case "control":
			shapeBase = xd344eb866bc83d16.x2ec78d2303214266(x0f7b23d1c393aed9);
			break;
		case "OLEObject":
			xd344eb866bc83d16.x9df59a055a98eb39(x0f7b23d1c393aed9);
			break;
		default:
			x3bcd232d01c.IgnoreElement();
			break;
		}
		return shapeBase;
	}

	private static Shape x0fc8e823a82068a5(x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		Shape shape = new Shape(x0f7b23d1c393aed9.x2c8c6741422a1298);
		shape.x88d1b78392d1a0ab(ShapeType.Image);
		shape.x0817d5cde9e19bf6(959, false);
		shape.x0817d5cde9e19bf6(508, false);
		shape.x0817d5cde9e19bf6(4097, WrapType.Inline);
		shape.x0817d5cde9e19bf6(127, true);
		shape.x0817d5cde9e19bf6(4096, FlipOrientation.None);
		shape.x0817d5cde9e19bf6(4103, "Normal");
		shape.x0817d5cde9e19bf6(958, true);
		shape.x0817d5cde9e19bf6(951, false);
		shape.x0817d5cde9e19bf6(952, true);
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("scriptAnchor"))
		{
			string xbcea506a33cf = x3bcd232d01c.x2a1ea9d24e62bf84();
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "language":
			{
				shape.x0817d5cde9e19bf6(922, xbcea506a33cf);
				x3f0333644ad9b00c x3f0333644ad9b00c = xf4107e64edda7fac.xff9a01fba7fab4e6(xbcea506a33cf);
				if (x3f0333644ad9b00c != x3f0333644ad9b00c.x4d0b9d4447ba7566)
				{
					shape.x0817d5cde9e19bf6(920, x3f0333644ad9b00c);
				}
				break;
			}
			case "args":
				shape.x0817d5cde9e19bf6(919, xbcea506a33cf);
				break;
			case "scriptText":
				shape.x0817d5cde9e19bf6(910, xbcea506a33cf);
				break;
			}
		}
		return shape;
	}

	private static void x078010062c4a2e1a(x2a3247c644c44cfe x3ed4f4f0195b98d7, ShapeBase x5770cdefd8931aa9)
	{
		if (x3ed4f4f0195b98d7.xbe8d54f88cd64ef4)
		{
			double xbcea506a33cf = x3ed4f4f0195b98d7.x8ff6b239b00e02c3() - x5770cdefd8931aa9.Top;
			if (x5770cdefd8931aa9.Top > x3ed4f4f0195b98d7.x8ff6b239b00e02c3())
			{
				xbcea506a33cf = x5770cdefd8931aa9.Top - x3ed4f4f0195b98d7.x8ff6b239b00e02c3();
				x5770cdefd8931aa9.Top = x3ed4f4f0195b98d7.x8ff6b239b00e02c3();
			}
			x5770cdefd8931aa9.x404ab2fc377ad1ed(xbcea506a33cf);
		}
	}

	private static void xe3979e0ce6bc1754(x2a3247c644c44cfe x3ed4f4f0195b98d7, ShapeBase x5770cdefd8931aa9)
	{
		if (x3ed4f4f0195b98d7.xbe8d54f88cd64ef4)
		{
			double xbcea506a33cf = x3ed4f4f0195b98d7.x8ff6b239b00e02c3() - x5770cdefd8931aa9.Left;
			if (x3ed4f4f0195b98d7.x8ff6b239b00e02c3() < x5770cdefd8931aa9.Left)
			{
				xbcea506a33cf = x5770cdefd8931aa9.Left - x3ed4f4f0195b98d7.x8ff6b239b00e02c3();
				x5770cdefd8931aa9.Left = x3ed4f4f0195b98d7.x8ff6b239b00e02c3();
			}
			x5770cdefd8931aa9.xf524ccc95fe8e714(xbcea506a33cf);
		}
	}

	private static void xfe4f7dca36c0076c(x874ec168cb1feb74 x0f7b23d1c393aed9, ShapeBase x5770cdefd8931aa9)
	{
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		x2a3247c644c44cfe[] array = null;
		x2a3247c644c44cfe[] array2 = null;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = x3bcd232d01c.xd2f68ee6f47e9dfb;
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "id":
				text = xd2f68ee6f47e9dfb;
				break;
			case "spid":
				text2 = xd2f68ee6f47e9dfb;
				break;
			case "spt":
				text3 = xd2f68ee6f47e9dfb;
				break;
			case "type":
				text4 = xd2f68ee6f47e9dfb;
				break;
			case "editas":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1280, xf4107e64edda7fac.x03a69fc19f801c36(xd2f68ee6f47e9dfb));
				break;
			case "alt":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(897, xd2f68ee6f47e9dfb);
				break;
			case "style":
				x0c1288d16c9571df(x5770cdefd8931aa9, xd2f68ee6f47e9dfb, x0f7b23d1c393aed9, x3bcd232d01c);
				break;
			case "bordertopcolor":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4106, x64673dc32ec695f4(xd2f68ee6f47e9dfb));
				break;
			case "borderleftcolor":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4107, x64673dc32ec695f4(xd2f68ee6f47e9dfb));
				break;
			case "borderbottomcolor":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4108, x64673dc32ec695f4(xd2f68ee6f47e9dfb));
				break;
			case "borderrightcolor":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4109, x64673dc32ec695f4(xd2f68ee6f47e9dfb));
				break;
			case "allowincell":
				x9296b3c358fa814f(x5770cdefd8931aa9, 944, xd2f68ee6f47e9dfb);
				break;
			case "allowoverlap":
				x9296b3c358fa814f(x5770cdefd8931aa9, 950, xd2f68ee6f47e9dfb);
				break;
			case "coordorigin":
				if (x0d299f323d241756.x5959bccb67bbf051(xd2f68ee6f47e9dfb))
				{
					int[] array4 = x5d16692b861b7f58(xd2f68ee6f47e9dfb);
					int x = ((array4.Length > 0) ? array4[0] : 0);
					int y = ((array4.Length > 1) ? array4[1] : 0);
					x5770cdefd8931aa9.CoordOrigin = new Point(x, y);
				}
				break;
			case "coordsize":
			{
				Size xbcea506a33cf;
				if (x0d299f323d241756.x5959bccb67bbf051(xd2f68ee6f47e9dfb))
				{
					int[] array3 = x5d16692b861b7f58(xd2f68ee6f47e9dfb);
					int width = ((array3.Length > 0) ? array3[0] : 0);
					int height = ((array3.Length > 1) ? array3[1] : 0);
					xbcea506a33cf = new Size(width, height);
				}
				else
				{
					xbcea506a33cf = new Size(1000, 1000);
				}
				x5770cdefd8931aa9.x0ac950b592cc7720(xbcea506a33cf);
				break;
			}
			case "adj":
				xd148774100fef0df(x5770cdefd8931aa9, xd2f68ee6f47e9dfb);
				break;
			case "path":
				x487cf3476d800366(x5770cdefd8931aa9, xd2f68ee6f47e9dfb);
				break;
			case "points":
				x0360c0152e0fc04b(x5770cdefd8931aa9, xd2f68ee6f47e9dfb);
				break;
			case "preferrelative":
				x9296b3c358fa814f(x5770cdefd8931aa9, 827, xd2f68ee6f47e9dfb);
				break;
			case "fill":
			case "filled":
				x9296b3c358fa814f(x5770cdefd8931aa9, 443, xd2f68ee6f47e9dfb);
				break;
			case "fillcolor":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(385, xd76179d16486fd56.xe74389aafc9d4795(xd2f68ee6f47e9dfb));
				break;
			case "dgmlayout":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(777, (xc586cb26186123d4)x3bcd232d01c.xbba6773b8ce56a01);
				break;
			case "dgmnodekind":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(778, (x76b42e09224005a0)x3bcd232d01c.xbba6773b8ce56a01);
				break;
			case "connectortype":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(771, xf4107e64edda7fac.xe5784f8353b9236e(xd2f68ee6f47e9dfb));
				break;
			case "stroked":
				x9296b3c358fa814f(x5770cdefd8931aa9, 508, xd2f68ee6f47e9dfb);
				break;
			case "strokecolor":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(448, xd76179d16486fd56.xe74389aafc9d4795(xd2f68ee6f47e9dfb));
				break;
			case "strokeweight":
				x509b015aed55247b(x5770cdefd8931aa9, 459, xd2f68ee6f47e9dfb);
				break;
			case "insetpen":
				x9296b3c358fa814f(x5770cdefd8931aa9, 505, xd2f68ee6f47e9dfb);
				break;
			case "href":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(898, xd2f68ee6f47e9dfb);
				break;
			case "target":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4120, xd2f68ee6f47e9dfb);
				break;
			case "title":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(909, xd2f68ee6f47e9dfb);
				break;
			case "bullet":
				x9296b3c358fa814f(x5770cdefd8931aa9, 945, xd2f68ee6f47e9dfb);
				break;
			case "button":
				x9296b3c358fa814f(x5770cdefd8931aa9, 956, xd2f68ee6f47e9dfb);
				break;
			case "oleicon":
				x9296b3c358fa814f(x5770cdefd8931aa9, 826, xd2f68ee6f47e9dfb);
				break;
			case "bwmode":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(772, xf4107e64edda7fac.x3a1493f9aa6ccdc2(xd2f68ee6f47e9dfb));
				break;
			case "bwpure":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(773, xf4107e64edda7fac.x3a1493f9aa6ccdc2(xd2f68ee6f47e9dfb));
				break;
			case "bwnormal":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(774, xf4107e64edda7fac.x3a1493f9aa6ccdc2(xd2f68ee6f47e9dfb));
				break;
			case "hr":
				x9296b3c358fa814f(x5770cdefd8931aa9, 948, xd2f68ee6f47e9dfb);
				break;
			case "hrstd":
				x9296b3c358fa814f(x5770cdefd8931aa9, 946, xd2f68ee6f47e9dfb);
				break;
			case "hrnoshade":
				x9296b3c358fa814f(x5770cdefd8931aa9, 947, xd2f68ee6f47e9dfb);
				break;
			case "hrpct":
				xef25af84d1a59dd8(x5770cdefd8931aa9, 915, xd2f68ee6f47e9dfb);
				break;
			case "hralign":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(916, xf4107e64edda7fac.x4e6f2ed51fdc438c(xd2f68ee6f47e9dfb));
				break;
			case "from":
				if (x5770cdefd8931aa9.ShapeType == ShapeType.Line)
				{
					array = x4df1062cd50b7ee1(xd2f68ee6f47e9dfb);
				}
				break;
			case "to":
				if (x5770cdefd8931aa9.ShapeType == ShapeType.Line)
				{
					array2 = x4df1062cd50b7ee1(xd2f68ee6f47e9dfb);
				}
				break;
			case "arcsize":
				x9bbc387f03a13c9f(x5770cdefd8931aa9, xd2f68ee6f47e9dfb);
				break;
			case "wrapcoords":
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.MajorFormattingLossCategory, WarningSource.Shapes, "Attribute 'wrapcoords' will be lost because polygon wrap points feature is not supported in WordML/Docx format by Aspose.Words.");
				break;
			case "equationxml":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(780, Encoding.UTF8.GetBytes(xd2f68ee6f47e9dfb));
				break;
			case "gfxdata":
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, "Import of element 'gfxdata' is not supported upon VML import by Aspose.Words.");
				break;
			default:
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			case "ole":
				break;
			}
		}
		if (array != null)
		{
			if (array[0].xbe8d54f88cd64ef4)
			{
				x5770cdefd8931aa9.Left = array[0].x8ff6b239b00e02c3();
			}
			if (array[1].xbe8d54f88cd64ef4)
			{
				x5770cdefd8931aa9.Top = array[1].x8ff6b239b00e02c3();
			}
		}
		if (array2 != null)
		{
			xe3979e0ce6bc1754(array2[0], x5770cdefd8931aa9);
			x078010062c4a2e1a(array2[1], x5770cdefd8931aa9);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text3))
		{
			xe0dfc10ade3a30e2(x5770cdefd8931aa9, 4155, text3);
		}
		else if (x0d299f323d241756.x5959bccb67bbf051(text4))
		{
			xf7125312c7ee115c xf7125312c7ee115c = x0f7b23d1c393aed9.xc49bc34e8c134250(text4);
			if (xf7125312c7ee115c != null && xf7125312c7ee115c.x263d579af1d0d43f(4155))
			{
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4155, xf7125312c7ee115c.xf7866f89640a29a3(4155));
			}
			else
			{
				xe0dfc10ade3a30e2(x5770cdefd8931aa9, 4155, text4);
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			xe0dfc10ade3a30e2(x5770cdefd8931aa9, 4124, text2);
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				x5770cdefd8931aa9.Name = text;
			}
		}
		else if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			xe0dfc10ade3a30e2(x5770cdefd8931aa9, 4124, text);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x0f7b23d1c393aed9.xcec152c2d57a278d(text, x5770cdefd8931aa9);
		}
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "ink":
				x5437212f2e13b2b8(x5770cdefd8931aa9, x0f7b23d1c393aed9);
				continue;
			case "binData":
				x0f7b23d1c393aed9.x2b6e606d842be5f3();
				continue;
			case "fill":
				xcd21218c34904d8a(x5770cdefd8931aa9, x0f7b23d1c393aed9);
				continue;
			case "stroke":
				xcd07215bd7734ced(x5770cdefd8931aa9, x0f7b23d1c393aed9);
				continue;
			case "imagedata":
			case "imageData":
				if (!x5770cdefd8931aa9.IsGroup)
				{
					Shape shape = (Shape)x5770cdefd8931aa9;
					x4bdaf4fb513ec0fa(shape, x0f7b23d1c393aed9);
					if (shape.HasImage && x5770cdefd8931aa9.ShapeType == ShapeType.NonPrimitive)
					{
						xe0dfc10ade3a30e2(x5770cdefd8931aa9, 4155, "100");
					}
				}
				continue;
			case "signatureline":
				x7e25ce646ac3d24c(x5770cdefd8931aa9, x3bcd232d01c);
				continue;
			case "shadow":
				x81e7deb9c136b3d7(x5770cdefd8931aa9, x3bcd232d01c);
				continue;
			case "extrusion":
				xb64ffe24e0f73a2a(x5770cdefd8931aa9, x3bcd232d01c);
				continue;
			case "formulas":
				xfaeb87e15cbaa328(x5770cdefd8931aa9, x3bcd232d01c);
				continue;
			case "path":
				xe6dd7bd4e532d8a6(x5770cdefd8931aa9, x3bcd232d01c);
				continue;
			case "textpath":
				x1211e085c2418791(x5770cdefd8931aa9, x3bcd232d01c);
				continue;
			case "handles":
				xc27e8040b86aea45(x5770cdefd8931aa9, x3bcd232d01c);
				continue;
			case "lock":
				x2c914f8215d23cc6(x5770cdefd8931aa9, x3bcd232d01c);
				continue;
			case "textbox":
				x19c67cd0ac63a355(x0f7b23d1c393aed9, x5770cdefd8931aa9);
				continue;
			case "diagram":
				x3337a3b14df78af2(x5770cdefd8931aa9, x3bcd232d01c);
				continue;
			case "callout":
				x8f98f0a173d360f1(x5770cdefd8931aa9, x3bcd232d01c);
				continue;
			case "wrap":
				x4f20d5e30002fcdf(x5770cdefd8931aa9, x3bcd232d01c);
				continue;
			case "anchorlock":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4099, true);
				continue;
			case "bordertop":
				xdeeab4ee20421f7a(x5770cdefd8931aa9, 4106, x3bcd232d01c);
				continue;
			case "borderleft":
				xdeeab4ee20421f7a(x5770cdefd8931aa9, 4107, x3bcd232d01c);
				continue;
			case "borderbottom":
				xdeeab4ee20421f7a(x5770cdefd8931aa9, 4108, x3bcd232d01c);
				continue;
			case "borderright":
				xdeeab4ee20421f7a(x5770cdefd8931aa9, 4109, x3bcd232d01c);
				continue;
			}
			if (x5770cdefd8931aa9.ShapeType == ShapeType.Group)
			{
				ShapeBase shapeBase = xb9d4bc2d67dd8604(x0f7b23d1c393aed9);
				if (shapeBase != null)
				{
					x5770cdefd8931aa9.xdf7453d9fdf3f262(shapeBase);
				}
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
		if (x5770cdefd8931aa9.x345365647af5db37())
		{
			x5770cdefd8931aa9.xdfdf94b7f842e919();
		}
	}

	private static void x7e25ce646ac3d24c(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		x5770cdefd8931aa9.x0817d5cde9e19bf6(1980, true);
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "addlxml":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1927, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "allowcomments":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1981, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "id":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1921, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "issignatureline":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1983, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "provid":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1922, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "showsigndate":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1980, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "signinginstructions":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1926, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "signinginstructionsset":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1982, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "sigprovurl":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1928, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "suggestedsigner":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1923, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "suggestedsigner2":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1924, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "suggestedsigneremail":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1925, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			default:
				xe134235b3526fa75.IgnoreElement();
				break;
			case "ext":
				break;
			}
		}
	}

	private static void xe0dfc10ade3a30e2(ShapeBase x5770cdefd8931aa9, int x01dfff6a67355342, string xeaf1b27180c0557b)
	{
		int num = xc1b08afa36bf580c.xe46f9c7779fac076(xeaf1b27180c0557b);
		if (num != int.MinValue)
		{
			x5770cdefd8931aa9.x0817d5cde9e19bf6(x01dfff6a67355342, num);
		}
	}

	private static void x0c1288d16c9571df(ShapeBase x5770cdefd8931aa9, string x44ecfea61c937b8e, x874ec168cb1feb74 x0f7b23d1c393aed9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		x94f937e2091879d2[] array = x97185e831527a216(x44ecfea61c937b8e);
		bool flag = true;
		for (int i = 0; i < array.Length; i++)
		{
			string x759aa16c2016a = array[i].x759aa16c2016a289;
			string xd2f68ee6f47e9dfb = array[i].xd2f68ee6f47e9dfb;
			if (x759aa16c2016a == "position" && xd2f68ee6f47e9dfb == "absolute")
			{
				flag = false;
			}
			x17a94005f80a66f3(x5770cdefd8931aa9, x759aa16c2016a, xd2f68ee6f47e9dfb, x0f7b23d1c393aed9, xe134235b3526fa75);
		}
		if (flag)
		{
			x5770cdefd8931aa9.x0817d5cde9e19bf6(4097, WrapType.Inline);
		}
	}

	private static void x17a94005f80a66f3(ShapeBase x5770cdefd8931aa9, string xc15bd84e01929885, string xbcea506a33cf9111, x874ec168cb1feb74 x0f7b23d1c393aed9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		switch (xc15bd84e01929885)
		{
		case "top":
		case "margin-top":
			x5770cdefd8931aa9.Top = x1bcdeb5b6eb9fd46(xbcea506a33cf9111, 0.0);
			break;
		case "left":
		case "margin-left":
			x5770cdefd8931aa9.Left = x1bcdeb5b6eb9fd46(xbcea506a33cf9111, 0.0);
			break;
		case "width":
			x5770cdefd8931aa9.xf524ccc95fe8e714(x1bcdeb5b6eb9fd46(xbcea506a33cf9111, 50.25));
			break;
		case "height":
			x5770cdefd8931aa9.x404ab2fc377ad1ed(x1bcdeb5b6eb9fd46(xbcea506a33cf9111, 50.25));
			break;
		case "rotation":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(4, x2b680b3d3cc1ed7a(xbcea506a33cf9111));
			break;
		case "flip":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(4096, xf4107e64edda7fac.xb5b62f8a4c368ce9(xbcea506a33cf9111));
			break;
		case "visibility":
			x9296b3c358fa814f(x5770cdefd8931aa9, 958, "hidden", "visible", xbcea506a33cf9111);
			break;
		case "z-index":
		{
			int num = xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111);
			if (num < 0)
			{
				x5770cdefd8931aa9.x0817d5cde9e19bf6(954, true);
			}
			x5770cdefd8931aa9.ZOrder = num;
			x0f7b23d1c393aed9.xdc421ae00841d163(x5770cdefd8931aa9);
			break;
		}
		case "mso-wrap-edited":
			x9296b3c358fa814f(x5770cdefd8931aa9, 953, xbcea506a33cf9111);
			break;
		case "mso-wrap-distance-left":
			x509b015aed55247b(x5770cdefd8931aa9, 900, xbcea506a33cf9111);
			break;
		case "mso-wrap-distance-top":
			x509b015aed55247b(x5770cdefd8931aa9, 901, xbcea506a33cf9111);
			break;
		case "mso-wrap-distance-right":
			x509b015aed55247b(x5770cdefd8931aa9, 902, xbcea506a33cf9111);
			break;
		case "mso-wrap-distance-bottom":
			x509b015aed55247b(x5770cdefd8931aa9, 903, xbcea506a33cf9111);
			break;
		case "mso-position-horizontal":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(911, x72a0c846678ecaf9.x15b3d0aaa5b4546f(xbcea506a33cf9111));
			break;
		case "mso-position-horizontal-relative":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(912, x72a0c846678ecaf9.xcf7be470fced425c(xbcea506a33cf9111));
			break;
		case "mso-position-vertical":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(913, x72a0c846678ecaf9.x130a3ebac2306cbd(xbcea506a33cf9111));
			break;
		case "mso-position-vertical-relative":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(914, x72a0c846678ecaf9.xb26f8f5e78b630a9(xbcea506a33cf9111, x48f1c6fc66ceb233: false));
			break;
		case "mso-wrap-style":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(133, xf4107e64edda7fac.xa64b5e4d1614865b(xbcea506a33cf9111));
			break;
		case "v-text-anchor":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(135, xf4107e64edda7fac.x5e7b36c6cd456894(xbcea506a33cf9111));
			break;
		case "mso-left-percent":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(1986, xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111));
			break;
		case "mso-top-percent":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(1987, xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111));
			break;
		case "mso-width-percent":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(1984, xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111));
			break;
		case "mso-height-percent":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(1985, xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111));
			break;
		case "mso-width-relative":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(1988, x72a0c846678ecaf9.x6ab7e7d63afae45f(xbcea506a33cf9111));
			break;
		case "mso-height-relative":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(1989, x72a0c846678ecaf9.x4f0b2ccd78a77d6c(xbcea506a33cf9111));
			break;
		default:
			xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{xe134235b3526fa75.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
			break;
		case "text-align":
		case "position":
			break;
		}
	}

	private static void x5437212f2e13b2b8(ShapeBase x5770cdefd8931aa9, x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = x3bcd232d01c.xd2f68ee6f47e9dfb;
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "i":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1792, Convert.FromBase64String(xd2f68ee6f47e9dfb));
				break;
			case "annotation":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1855, xd2f68ee6f47e9dfb == "t");
				break;
			}
		}
	}

	private static void xcd21218c34904d8a(ShapeBase x5770cdefd8931aa9, x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		bool flag = false;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = x3bcd232d01c.xd2f68ee6f47e9dfb;
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "id":
			case "src":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4111, x8e500baeffc6e539.x601e9a2243ca6720(x0f7b23d1c393aed9.x7b29fad09d9101c5(xd2f68ee6f47e9dfb)));
				break;
			case "title":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(391, xd2f68ee6f47e9dfb);
				break;
			case "opacity":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 386, xd2f68ee6f47e9dfb);
				break;
			case "color2":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(387, xd76179d16486fd56.xe74389aafc9d4795(xd2f68ee6f47e9dfb));
				break;
			case "opacity2":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 388, xd2f68ee6f47e9dfb);
				break;
			case "aspect":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(405, xf4107e64edda7fac.xcb49c22ebb0904d7(xd2f68ee6f47e9dfb));
				break;
			case "origin":
				x2d9cfedee1be7521(x5770cdefd8931aa9, 408, 409, xd2f68ee6f47e9dfb);
				break;
			case "position":
				x2d9cfedee1be7521(x5770cdefd8931aa9, 410, 411, xd2f68ee6f47e9dfb);
				break;
			case "recolor":
				x9296b3c358fa814f(x5770cdefd8931aa9, 441, xd2f68ee6f47e9dfb);
				break;
			case "rotate":
				x9296b3c358fa814f(x5770cdefd8931aa9, 442, xd2f68ee6f47e9dfb);
				break;
			case "angle":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 395, xd2f68ee6f47e9dfb);
				break;
			case "colors":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(407, x4ba7b774a02360b9(xd2f68ee6f47e9dfb));
				break;
			case "focusposition":
				x2d9cfedee1be7521(x5770cdefd8931aa9, 397, 398, xd2f68ee6f47e9dfb);
				break;
			case "method":
				if (xd2f68ee6f47e9dfb == "linear sigma")
				{
					x5770cdefd8931aa9.x0817d5cde9e19bf6(412, (xda3162397283dd69)1073741835);
				}
				else
				{
					x5770cdefd8931aa9.x0817d5cde9e19bf6(412, xda3162397283dd69.x4d0b9d4447ba7566);
				}
				break;
			case "focus":
				x0d8d47b01381afd1(x5770cdefd8931aa9, 396, xd2f68ee6f47e9dfb);
				break;
			case "type":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(384, xf4107e64edda7fac.x1e1128f7eab07d3d(xd2f68ee6f47e9dfb));
				if (xd2f68ee6f47e9dfb == "gradientRadial" || xd2f68ee6f47e9dfb == "gradient")
				{
					flag = true;
				}
				break;
			case "detectmouseclick":
				x9296b3c358fa814f(x5770cdefd8931aa9, 447, xd2f68ee6f47e9dfb);
				break;
			case "href":
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.DataLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			case "althref":
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.DataLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			default:
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			case "size":
			case "focussize":
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("fill"))
		{
			switch (x3bcd232d01c.xd68abcd61e368af9("type", ""))
			{
			case "gradientCenter":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(384, xeba92971120d3e5a.xca1af54f5cfd812d);
				break;
			case "gradientUnscaled":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(384, xeba92971120d3e5a.x8ff7966c1e29ad96);
				break;
			}
		}
	}

	private static void xcd07215bd7734ced(ShapeBase x5770cdefd8931aa9, x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = x3bcd232d01c.xd2f68ee6f47e9dfb;
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "id":
			case "src":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4110, x0f7b23d1c393aed9.x7b29fad09d9101c5(xd2f68ee6f47e9dfb));
				break;
			case "title":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(454, xd2f68ee6f47e9dfb);
				break;
			case "joinstyle":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(470, xf4107e64edda7fac.x6057f916da674791(xd2f68ee6f47e9dfb));
				break;
			case "dashstyle":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(462, xf4107e64edda7fac.x528c265eb8b6a325(xd2f68ee6f47e9dfb));
				break;
			case "linestyle":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(461, xf4107e64edda7fac.xb1ae197d60055154(xd2f68ee6f47e9dfb));
				break;
			case "endcap":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(471, xf4107e64edda7fac.xae000cb67a9fd7c6(xd2f68ee6f47e9dfb));
				break;
			case "startarrow":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(464, xf4107e64edda7fac.x949573b08e5782e1(xd2f68ee6f47e9dfb));
				break;
			case "startarrowwidth":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(466, xf4107e64edda7fac.xdf44b89c35cb4259(xd2f68ee6f47e9dfb));
				break;
			case "startarrowlength":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(467, xf4107e64edda7fac.x440e196e8d4eefd9(xd2f68ee6f47e9dfb));
				break;
			case "endarrow":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(465, xf4107e64edda7fac.x949573b08e5782e1(xd2f68ee6f47e9dfb));
				break;
			case "endarrowwidth":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(468, xf4107e64edda7fac.xdf44b89c35cb4259(xd2f68ee6f47e9dfb));
				break;
			case "endarrowlength":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(469, xf4107e64edda7fac.x440e196e8d4eefd9(xd2f68ee6f47e9dfb));
				break;
			case "opacity":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 449, xd2f68ee6f47e9dfb);
				break;
			case "color2":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(450, xd76179d16486fd56.xe74389aafc9d4795(xd2f68ee6f47e9dfb));
				break;
			case "filltype":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(452, xf4107e64edda7fac.x9ed129f07198e28b(xd2f68ee6f47e9dfb));
				break;
			default:
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			}
		}
	}

	private static void x4bdaf4fb513ec0fa(Shape x5770cdefd8931aa9, x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = x3bcd232d01c.xd2f68ee6f47e9dfb;
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "id":
			case "src":
				if (x0f7b23d1c393aed9.x3d21050b1e731250(xd2f68ee6f47e9dfb))
				{
					x5770cdefd8931aa9.x0817d5cde9e19bf6(4104, x0f7b23d1c393aed9.x052a6c2e603b1662(xd2f68ee6f47e9dfb));
				}
				else
				{
					x5770cdefd8931aa9.ImageData.x7a0cb9855dd2eab1(x0f7b23d1c393aed9.x7b29fad09d9101c5(xd2f68ee6f47e9dfb));
				}
				break;
			case "href":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4104, x0f7b23d1c393aed9.x052a6c2e603b1662(xd2f68ee6f47e9dfb));
				break;
			case "title":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4103, xd2f68ee6f47e9dfb);
				break;
			case "croptop":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 256, xd2f68ee6f47e9dfb);
				break;
			case "cropbottom":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 257, xd2f68ee6f47e9dfb);
				break;
			case "cropleft":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 258, xd2f68ee6f47e9dfb);
				break;
			case "cropright":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 259, xd2f68ee6f47e9dfb);
				break;
			case "chromakey":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(263, xd76179d16486fd56.xe74389aafc9d4795(xd2f68ee6f47e9dfb));
				break;
			case "gain":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 264, xd2f68ee6f47e9dfb);
				break;
			case "blacklevel":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 265, xd2f68ee6f47e9dfb);
				break;
			case "gamma":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 266, xd2f68ee6f47e9dfb);
				break;
			case "grayscale":
				x9296b3c358fa814f(x5770cdefd8931aa9, 317, xd2f68ee6f47e9dfb);
				break;
			case "bilevel":
				x9296b3c358fa814f(x5770cdefd8931aa9, 318, xd2f68ee6f47e9dfb);
				break;
			case "embosscolor":
			{
				x26d9ecb4bdf0456d x26d9ecb4bdf0456d2 = xd76179d16486fd56.xe74389aafc9d4795(xd2f68ee6f47e9dfb);
				int num2 = 268435456 + (x26d9ecb4bdf0456d2.x8e8f6cc6a0756b05 << 16) + (x26d9ecb4bdf0456d2.x26463655896fd90a << 8) + x26d9ecb4bdf0456d2.xc613adc4330033f3;
				x5770cdefd8931aa9.x0817d5cde9e19bf6(268, num2);
				break;
			}
			case "recolortarget":
			{
				x26d9ecb4bdf0456d x26d9ecb4bdf0456d = xd76179d16486fd56.xe74389aafc9d4795(xd2f68ee6f47e9dfb);
				int num = (x26d9ecb4bdf0456d.x8e8f6cc6a0756b05 << 16) + (x26d9ecb4bdf0456d.x26463655896fd90a << 8) + x26d9ecb4bdf0456d.xc613adc4330033f3;
				x5770cdefd8931aa9.x0817d5cde9e19bf6(282, num);
				break;
			}
			default:
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			}
		}
	}

	private static void x81e7deb9c136b3d7(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = xe134235b3526fa75.xd2f68ee6f47e9dfb;
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "on":
				x9296b3c358fa814f(x5770cdefd8931aa9, 574, xd2f68ee6f47e9dfb);
				break;
			case "type":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(512, xf4107e64edda7fac.xf79f82d7a7e1f16f(xd2f68ee6f47e9dfb));
				break;
			case "color":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(513, xd76179d16486fd56.xe74389aafc9d4795(xd2f68ee6f47e9dfb));
				break;
			case "color2":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(514, xd76179d16486fd56.xe74389aafc9d4795(xd2f68ee6f47e9dfb));
				break;
			case "opacity":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 516, xd2f68ee6f47e9dfb);
				break;
			case "origin":
				x2d9cfedee1be7521(x5770cdefd8931aa9, 528, 529, xd2f68ee6f47e9dfb);
				break;
			case "offset":
				xa817fbd28158dfcb(x5770cdefd8931aa9, 517, 518, xd2f68ee6f47e9dfb);
				break;
			case "offset2":
				xa817fbd28158dfcb(x5770cdefd8931aa9, 519, 520, xd2f68ee6f47e9dfb);
				break;
			case "matrix":
				xe4616a3e9c60ebde(x5770cdefd8931aa9, xd2f68ee6f47e9dfb);
				break;
			case "obscured":
				x9296b3c358fa814f(x5770cdefd8931aa9, 575, xd2f68ee6f47e9dfb);
				break;
			default:
				xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{xe134235b3526fa75.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			}
		}
	}

	private static void xb64ffe24e0f73a2a(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = xe134235b3526fa75.xd2f68ee6f47e9dfb;
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "specularity":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 640, xd2f68ee6f47e9dfb);
				break;
			case "diffusity":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 641, xd2f68ee6f47e9dfb);
				break;
			case "shininess":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(642, xe134235b3526fa75.xbba6773b8ce56a01);
				break;
			case "edge":
				x509b015aed55247b(x5770cdefd8931aa9, 643, xd2f68ee6f47e9dfb);
				break;
			case "foredepth":
				x509b015aed55247b(x5770cdefd8931aa9, 644, xd2f68ee6f47e9dfb);
				break;
			case "backdepth":
				x509b015aed55247b(x5770cdefd8931aa9, 645, xd2f68ee6f47e9dfb);
				break;
			case "plane":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(646, xf4107e64edda7fac.x9a76ee6bdf85fd80(xd2f68ee6f47e9dfb));
				break;
			case "color":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(647, xd76179d16486fd56.xe74389aafc9d4795(xd2f68ee6f47e9dfb));
				break;
			case "on":
				x9296b3c358fa814f(x5770cdefd8931aa9, 700, xd2f68ee6f47e9dfb);
				break;
			case "metal":
				x9296b3c358fa814f(x5770cdefd8931aa9, 701, xd2f68ee6f47e9dfb);
				break;
			case "lightface":
				x9296b3c358fa814f(x5770cdefd8931aa9, 703, xd2f68ee6f47e9dfb);
				break;
			case "rotationangle":
				x2d9cfedee1be7521(x5770cdefd8931aa9, 705, 704, xd2f68ee6f47e9dfb);
				break;
			case "orientation":
				x3a75cb88c21b34c3(x5770cdefd8931aa9, 706, 707, 708, xd2f68ee6f47e9dfb);
				break;
			case "orientationangle":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 709, xd2f68ee6f47e9dfb);
				break;
			case "rotationcenter":
				x948627a79fa8f0a9(x5770cdefd8931aa9, xd2f68ee6f47e9dfb);
				break;
			case "render":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(713, xf4107e64edda7fac.xbb50fdb543ecb322(xd2f68ee6f47e9dfb));
				break;
			case "facet":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 714, xd2f68ee6f47e9dfb);
				break;
			case "viewpoint":
				x7f722db949bc1545(x5770cdefd8931aa9, 715, 716, 717, xd2f68ee6f47e9dfb);
				break;
			case "viewpointorigin":
				x2d9cfedee1be7521(x5770cdefd8931aa9, 718, 719, xd2f68ee6f47e9dfb);
				break;
			case "skewangle":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 720, xd2f68ee6f47e9dfb);
				break;
			case "skewamt":
				x0d8d47b01381afd1(x5770cdefd8931aa9, 721, xd2f68ee6f47e9dfb);
				break;
			case "brightness":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 722, xd2f68ee6f47e9dfb);
				break;
			case "lightposition":
				x3a75cb88c21b34c3(x5770cdefd8931aa9, 723, 724, 725, xd2f68ee6f47e9dfb);
				break;
			case "lightlevel":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 726, xd2f68ee6f47e9dfb);
				break;
			case "lightposition2":
				x3a75cb88c21b34c3(x5770cdefd8931aa9, 727, 728, 729, xd2f68ee6f47e9dfb);
				break;
			case "lightlevel2":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 730, xd2f68ee6f47e9dfb);
				break;
			case "lockrotationcenter":
				x9296b3c358fa814f(x5770cdefd8931aa9, 763, xd2f68ee6f47e9dfb);
				break;
			case "autorotationcenter":
				x9296b3c358fa814f(x5770cdefd8931aa9, 764, xd2f68ee6f47e9dfb);
				break;
			case "type":
				if (xd2f68ee6f47e9dfb == "perspective")
				{
					x5770cdefd8931aa9.x0817d5cde9e19bf6(765, false);
				}
				break;
			case "lightharsh":
				x9296b3c358fa814f(x5770cdefd8931aa9, 766, xd2f68ee6f47e9dfb);
				break;
			case "lightharsh2":
				x9296b3c358fa814f(x5770cdefd8931aa9, 767, xd2f68ee6f47e9dfb);
				break;
			default:
				xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{xe134235b3526fa75.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			case "ext":
			case "colormode":
				break;
			}
		}
	}

	private static void xfaeb87e15cbaa328(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		ArrayList arrayList = new ArrayList();
		while (xe134235b3526fa75.x152cbadbfa8061b1("formulas"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xe134235b3526fa75.xa66385d80d4d296f) != null && xa66385d80d4d296f == "f")
			{
				string text = xe134235b3526fa75.xd68abcd61e368af9("eqn", "");
				if (x0d299f323d241756.x5959bccb67bbf051(text))
				{
					arrayList.Add(xe4b8047411da015c(text));
				}
			}
			else
			{
				xe134235b3526fa75.IgnoreElement();
			}
		}
		x40937ad35b1cf5f7[] xbcea506a33cf = (x40937ad35b1cf5f7[])arrayList.ToArray(typeof(x40937ad35b1cf5f7));
		x5770cdefd8931aa9.x0817d5cde9e19bf6(342, xbcea506a33cf);
	}

	private static x40937ad35b1cf5f7 xe4b8047411da015c(string x25120d456e8372af)
	{
		string[] array = x25120d456e8372af.Split(' ');
		x40937ad35b1cf5f7 x40937ad35b1cf5f = new x40937ad35b1cf5f7();
		x40937ad35b1cf5f.xca0517fe66f52202 = xf4107e64edda7fac.x68beb416c20d9f9a(array[0]);
		if (array.Length > 1)
		{
			string text = array[1];
			if (!xca004f56614e2431.x44084f078ff0e99c(text))
			{
				x40937ad35b1cf5f.x586b7652ac7cefe0 |= 32;
				x40937ad35b1cf5f.xf63e76e85f8fbc50 = x3120428af9618514(text);
			}
			else
			{
				x40937ad35b1cf5f.xf63e76e85f8fbc50 = xca004f56614e2431.x59884ab46dd0d856(text);
			}
		}
		if (array.Length > 2)
		{
			string text2 = array[2];
			if (!xca004f56614e2431.x44084f078ff0e99c(text2))
			{
				x40937ad35b1cf5f.x586b7652ac7cefe0 |= 64;
				x40937ad35b1cf5f.xe7e30aeba78bbcd2 = x3120428af9618514(text2);
			}
			else
			{
				x40937ad35b1cf5f.xe7e30aeba78bbcd2 = xca004f56614e2431.x59884ab46dd0d856(text2);
			}
		}
		if (array.Length > 3)
		{
			string text3 = array[3];
			if (!xca004f56614e2431.x44084f078ff0e99c(text3))
			{
				x40937ad35b1cf5f.x586b7652ac7cefe0 |= 128;
				x40937ad35b1cf5f.x7cc7f538a3b98861 = x3120428af9618514(text3);
			}
			else
			{
				x40937ad35b1cf5f.x7cc7f538a3b98861 = xca004f56614e2431.x59884ab46dd0d856(text3);
			}
		}
		return x40937ad35b1cf5f;
	}

	private static int x3120428af9618514(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "xcenter":
			return 320;
		case "ycenter":
			return 321;
		case "width":
			return 322;
		case "height":
			return 323;
		case "xlimo":
			return 339;
		case "ylimo":
			return 340;
		case "lineDrawn":
			return 508;
		case "pixelLineWidth":
			return 1271;
		case "pixelWidth":
			return 1272;
		case "pixelHeight":
			return 1273;
		case "emuWidth":
			return 1276;
		case "emuHeight":
			return 1277;
		case "emuWidth2":
			return 1278;
		case "emuHeight2":
			return 1279;
		default:
			if (xbcea506a33cf9111.StartsWith("@"))
			{
				return xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111.TrimStart('@')) + 1024;
			}
			if (xbcea506a33cf9111.StartsWith("#"))
			{
				return xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111.TrimStart('#')) + 327;
			}
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ogbceiicfipcfhgdahndjheeoglechcfkgjfihagaghgmfogfbfhbgmhpfdibfkilfbjheijbfpjeegknpmkafelidllaecmgejmddanlognbdonddfocolodddpeckpobbagnhajbpapbgbpbnbhbecmblcabcdcajdmmpd", 632889625)));
		}
	}

	private static void xe6dd7bd4e532d8a6(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = xe134235b3526fa75.xd2f68ee6f47e9dfb;
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "arrowok":
				x9296b3c358fa814f(x5770cdefd8931aa9, 507, xd2f68ee6f47e9dfb);
				break;
			case "fillok":
				x9296b3c358fa814f(x5770cdefd8931aa9, 383, xd2f68ee6f47e9dfb);
				break;
			case "strokeok":
				x9296b3c358fa814f(x5770cdefd8931aa9, 380, xd2f68ee6f47e9dfb);
				break;
			case "shadowok":
				x9296b3c358fa814f(x5770cdefd8931aa9, 378, xd2f68ee6f47e9dfb);
				break;
			case "extrusionok":
				x9296b3c358fa814f(x5770cdefd8931aa9, 379, xd2f68ee6f47e9dfb);
				break;
			case "gradientshapeok":
				x9296b3c358fa814f(x5770cdefd8931aa9, 382, xd2f68ee6f47e9dfb);
				break;
			case "textpathok":
				x9296b3c358fa814f(x5770cdefd8931aa9, 381, xd2f68ee6f47e9dfb);
				break;
			case "limo":
			{
				int[] array = x5d16692b861b7f58(xd2f68ee6f47e9dfb);
				int num = ((array.Length > 0) ? array[0] : 0);
				int num2 = ((array.Length > 1) ? array[1] : 0);
				x5770cdefd8931aa9.x0817d5cde9e19bf6(339, num);
				x5770cdefd8931aa9.x0817d5cde9e19bf6(340, num2);
				break;
			}
			case "connecttype":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(344, xf4107e64edda7fac.x481eb9ebee62bc69(xd2f68ee6f47e9dfb));
				break;
			case "connectlocs":
				xc82ddcf5b64ccfcb(x5770cdefd8931aa9, xd2f68ee6f47e9dfb);
				break;
			case "connectangles":
				xc53ea6decf3f9952(x5770cdefd8931aa9, xd2f68ee6f47e9dfb);
				break;
			case "textboxrect":
				x107e98ac969b6add(x5770cdefd8931aa9, xd2f68ee6f47e9dfb);
				break;
			default:
				xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{xe134235b3526fa75.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			}
		}
	}

	private static void xc82ddcf5b64ccfcb(ShapeBase x5770cdefd8931aa9, string xbcea506a33cf9111)
	{
		string[] array = xbcea506a33cf9111.Split(xa99d268ef36b300a);
		x08d932077485c285[] array2 = new x08d932077485c285[array.Length / 2];
		for (int i = 0; i < array.Length / 2; i++)
		{
			array2[i] = new x08d932077485c285(x1d9b310dd0ec4d07.x1bce28f95074665d(array[2 * i]), x1d9b310dd0ec4d07.x1bce28f95074665d(array[2 * i + 1]));
		}
		x5770cdefd8931aa9.x0817d5cde9e19bf6(337, array2);
	}

	private static void xc53ea6decf3f9952(ShapeBase x5770cdefd8931aa9, string xbcea506a33cf9111)
	{
		string[] array = xbcea506a33cf9111.Split(',');
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = x2b680b3d3cc1ed7a(array[i]);
		}
		x5770cdefd8931aa9.x0817d5cde9e19bf6(338, array2);
	}

	private static void x107e98ac969b6add(ShapeBase x5770cdefd8931aa9, string xbcea506a33cf9111)
	{
		string[] array = xbcea506a33cf9111.Split(';');
		xbc9979937c838d75[] array2 = new xbc9979937c838d75[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			string[] array3 = array[i].Split(',');
			xbc9979937c838d75 xbc9979937c838d = new xbc9979937c838d75();
			if (array3.Length == 4)
			{
				xbc9979937c838d.x72d92bd1aff02e37 = x1d9b310dd0ec4d07.x1bce28f95074665d(array3[0]);
				xbc9979937c838d.xe360b1885d8d4a41 = x1d9b310dd0ec4d07.x1bce28f95074665d(array3[1]);
				xbc9979937c838d.x419ba17a5322627b = x1d9b310dd0ec4d07.x1bce28f95074665d(array3[2]);
				xbc9979937c838d.x9bcb07e204e30218 = x1d9b310dd0ec4d07.x1bce28f95074665d(array3[3]);
			}
			array2[i] = xbc9979937c838d;
		}
		x5770cdefd8931aa9.x0817d5cde9e19bf6(343, array2);
	}

	private static void x1211e085c2418791(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		x5770cdefd8931aa9.x0817d5cde9e19bf6(241, true);
		x5770cdefd8931aa9.x0817d5cde9e19bf6(245, true);
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = xe134235b3526fa75.xd2f68ee6f47e9dfb;
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "on":
				x9296b3c358fa814f(x5770cdefd8931aa9, 241, xd2f68ee6f47e9dfb);
				break;
			case "style":
				x31ef914d7c91f4db(x5770cdefd8931aa9, xd2f68ee6f47e9dfb);
				break;
			case "fitshape":
				x9296b3c358fa814f(x5770cdefd8931aa9, 245, xd2f68ee6f47e9dfb);
				break;
			case "trim":
				x9296b3c358fa814f(x5770cdefd8931aa9, 246, xd2f68ee6f47e9dfb);
				break;
			case "fitpath":
				x9296b3c358fa814f(x5770cdefd8931aa9, 247, xd2f68ee6f47e9dfb);
				break;
			case "xscale":
				x9296b3c358fa814f(x5770cdefd8931aa9, 249, xd2f68ee6f47e9dfb);
				break;
			case "string":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(192, xd2f68ee6f47e9dfb);
				break;
			default:
				xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{xe134235b3526fa75.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			}
		}
	}

	private static void x31ef914d7c91f4db(ShapeBase x5770cdefd8931aa9, string x44ecfea61c937b8e)
	{
		x94f937e2091879d2[] array = x97185e831527a216(x44ecfea61c937b8e);
		for (int i = 0; i < array.Length; i++)
		{
			string xd2f68ee6f47e9dfb = array[i].xd2f68ee6f47e9dfb;
			switch (array[i].x759aa16c2016a289)
			{
			case "font-family":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(197, xd2f68ee6f47e9dfb.Trim('"', '\''));
				break;
			case "font-size":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(195, x4574ea26106f0edb.x091b250f00534aae(x1bcdeb5b6eb9fd46(xd2f68ee6f47e9dfb, 36.0)));
				break;
			case "font-style":
				x9296b3c358fa814f(x5770cdefd8931aa9, 251, "italic", "normal", xd2f68ee6f47e9dfb);
				break;
			case "font-weight":
				x9296b3c358fa814f(x5770cdefd8931aa9, 250, "bold", "normal", xd2f68ee6f47e9dfb);
				break;
			case "font-variant":
				x9296b3c358fa814f(x5770cdefd8931aa9, 254, "small-caps", "normal", xd2f68ee6f47e9dfb);
				break;
			case "text-decoration":
				switch (xd2f68ee6f47e9dfb)
				{
				case "underline":
					x5770cdefd8931aa9.x0817d5cde9e19bf6(252, true);
					break;
				case "line-through":
					x5770cdefd8931aa9.x0817d5cde9e19bf6(255, true);
					break;
				}
				break;
			case "mso-text-shadow":
				x9296b3c358fa814f(x5770cdefd8931aa9, 253, "auto", "normal", xd2f68ee6f47e9dfb);
				break;
			case "v-text-align":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(194, xf4107e64edda7fac.x353e4e9efdf457bd(xd2f68ee6f47e9dfb));
				break;
			case "v-text-spacing-mode":
				x9296b3c358fa814f(x5770cdefd8931aa9, 244, "tightening", "tracking", xd2f68ee6f47e9dfb);
				break;
			case "v-text-spacing":
				x0ed85147c46f1d47(x5770cdefd8931aa9, 196, xd2f68ee6f47e9dfb);
				break;
			case "v-text-kern":
				x9296b3c358fa814f(x5770cdefd8931aa9, 243, xd2f68ee6f47e9dfb);
				break;
			case "v-text-reverse":
				x9296b3c358fa814f(x5770cdefd8931aa9, 240, xd2f68ee6f47e9dfb);
				break;
			case "v-same-letter-heights":
				x9296b3c358fa814f(x5770cdefd8931aa9, 248, xd2f68ee6f47e9dfb);
				break;
			case "v-rotate-letters":
				x9296b3c358fa814f(x5770cdefd8931aa9, 242, xd2f68ee6f47e9dfb);
				break;
			}
		}
	}

	private static void xc27e8040b86aea45(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		ArrayList arrayList = new ArrayList();
		while (xe134235b3526fa75.x152cbadbfa8061b1("handles"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xe134235b3526fa75.xa66385d80d4d296f) != null && xa66385d80d4d296f == "h")
			{
				arrayList.Add(xead214f628d62a85(xe134235b3526fa75));
			}
			else
			{
				xe134235b3526fa75.IgnoreElement();
			}
		}
		x7efbe0a2dc0d335f[] xbcea506a33cf = (x7efbe0a2dc0d335f[])arrayList.ToArray(typeof(x7efbe0a2dc0d335f));
		x5770cdefd8931aa9.x0817d5cde9e19bf6(341, xbcea506a33cf);
	}

	private static x7efbe0a2dc0d335f xead214f628d62a85(x3c85359e1389ad43 xe134235b3526fa75)
	{
		x7efbe0a2dc0d335f x7efbe0a2dc0d335f = new x7efbe0a2dc0d335f();
		x7efbe0a2dc0d335f.x9462c8df936efa39 = new x06e4f09a90ca939a(int.MinValue);
		x7efbe0a2dc0d335f.x11f73230b9b436a7 = new x06e4f09a90ca939a(int.MaxValue);
		x7efbe0a2dc0d335f.x5b051452efe1bbe3 = new x06e4f09a90ca939a(int.MinValue);
		x7efbe0a2dc0d335f.xbed6b6abe5a7fcce = new x06e4f09a90ca939a(int.MaxValue);
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = xe134235b3526fa75.xd2f68ee6f47e9dfb;
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "position":
			{
				x5a3adc1f3af97e92 x5a3adc1f3af97e = x03db37ec73e96cfc(xd2f68ee6f47e9dfb);
				x7efbe0a2dc0d335f.x3b1bddb38a858693 = x5a3adc1f3af97e.x8df91a2f90079e88;
				x7efbe0a2dc0d335f.x97a3447730c7ceb9 = x5a3adc1f3af97e.xc821290d7ecc08bf;
				break;
			}
			case "switch":
				x7efbe0a2dc0d335f.xcc2d426b867d703d = true;
				break;
			case "polar":
			{
				x7efbe0a2dc0d335f.x7937f9e8f355e258 = true;
				x08d932077485c285 x08d932077485c5 = xe3e4ba9b504f138a(xd2f68ee6f47e9dfb);
				x7efbe0a2dc0d335f.xb6af3939c9fabf06 = x08d932077485c5.x8df91a2f90079e88;
				x7efbe0a2dc0d335f.x8d8e3bafebd1a122 = x08d932077485c5.xc821290d7ecc08bf;
				break;
			}
			case "map":
			{
				x7efbe0a2dc0d335f.x9183a138a4fced5c = true;
				x08d932077485c285 x08d932077485c4 = xe3e4ba9b504f138a(xd2f68ee6f47e9dfb);
				x7efbe0a2dc0d335f.xb6af3939c9fabf06 = x08d932077485c4.x8df91a2f90079e88;
				x7efbe0a2dc0d335f.x8d8e3bafebd1a122 = x08d932077485c4.xc821290d7ecc08bf;
				break;
			}
			case "radiusrange":
			{
				x7efbe0a2dc0d335f.x7ab55132a5c2e47e = true;
				x08d932077485c285 x08d932077485c3 = xe3e4ba9b504f138a(xd2f68ee6f47e9dfb);
				x7efbe0a2dc0d335f.x9462c8df936efa39 = x08d932077485c3.x8df91a2f90079e88;
				x7efbe0a2dc0d335f.x11f73230b9b436a7 = x08d932077485c3.xc821290d7ecc08bf;
				break;
			}
			case "xrange":
			{
				x7efbe0a2dc0d335f.x22dfdc5e2d91486e = true;
				x08d932077485c285 x08d932077485c2 = xe3e4ba9b504f138a(xd2f68ee6f47e9dfb);
				x7efbe0a2dc0d335f.x9462c8df936efa39 = x08d932077485c2.x8df91a2f90079e88;
				x7efbe0a2dc0d335f.x11f73230b9b436a7 = x08d932077485c2.xc821290d7ecc08bf;
				break;
			}
			case "yrange":
			{
				x7efbe0a2dc0d335f.x22dfdc5e2d91486e = true;
				x08d932077485c285 x08d932077485c = xe3e4ba9b504f138a(xd2f68ee6f47e9dfb);
				x7efbe0a2dc0d335f.x5b051452efe1bbe3 = x08d932077485c.x8df91a2f90079e88;
				x7efbe0a2dc0d335f.xbed6b6abe5a7fcce = x08d932077485c.xc821290d7ecc08bf;
				break;
			}
			}
		}
		return x7efbe0a2dc0d335f;
	}

	private static x5a3adc1f3af97e92 x03db37ec73e96cfc(string xbcea506a33cf9111)
	{
		string[] array = xbcea506a33cf9111.Split(',');
		return new x5a3adc1f3af97e92(x0425e61c529b6eff(array[0]), x0425e61c529b6eff(array[1]));
	}

	private static x08d932077485c285 xe3e4ba9b504f138a(string xbcea506a33cf9111)
	{
		string[] array = xbcea506a33cf9111.Split(',');
		return new x08d932077485c285(x96a608c684b18682(array[0]), x96a608c684b18682(array[1]));
	}

	private static x06e4f09a90ca939a x96a608c684b18682(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "topLeft":
			return new x06e4f09a90ca939a(0, isFormula: true);
		case "bottomRight":
			return new x06e4f09a90ca939a(1, isFormula: true);
		case "center":
			return new x06e4f09a90ca939a(2, isFormula: true);
		default:
			if (xbcea506a33cf9111.StartsWith("@"))
			{
				return new x06e4f09a90ca939a(xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111.TrimStart('@')) + 3, isFormula: true);
			}
			if (xbcea506a33cf9111.StartsWith("#"))
			{
				return new x06e4f09a90ca939a(xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111.TrimStart('#')) + 256, isFormula: true);
			}
			return new x06e4f09a90ca939a(xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111), isFormula: false);
		}
	}

	private static x98655ffe05324a50 x0425e61c529b6eff(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "topLeft":
			return new x98655ffe05324a50(xc548449aaa21fea5.xd93f803ca02a4434, 0);
		case "bottomRight":
			return new x98655ffe05324a50(xc548449aaa21fea5.xff654ea4df290dd7, 0);
		case "center":
			return new x98655ffe05324a50(xc548449aaa21fea5.x58d2ccae3c5cfd08, 0);
		default:
			if (xbcea506a33cf9111.StartsWith("@"))
			{
				return new x98655ffe05324a50(xc548449aaa21fea5.x40937ad35b1cf5f7, xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111.TrimStart('@')));
			}
			if (xbcea506a33cf9111.StartsWith("#"))
			{
				return new x98655ffe05324a50(xc548449aaa21fea5.xfaab97dd0218026f, xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111.TrimStart('#')));
			}
			return new x98655ffe05324a50(xc548449aaa21fea5.x82e26649b09596bd, xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111));
		}
	}

	private static void x2c914f8215d23cc6(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = xe134235b3526fa75.xd2f68ee6f47e9dfb;
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "aspectratio":
				x9296b3c358fa814f(x5770cdefd8931aa9, 120, xd2f68ee6f47e9dfb);
				break;
			case "verticies":
				x9296b3c358fa814f(x5770cdefd8931aa9, 124, xd2f68ee6f47e9dfb);
				break;
			case "text":
				x9296b3c358fa814f(x5770cdefd8931aa9, 125, xd2f68ee6f47e9dfb);
				break;
			case "shapetype":
				x9296b3c358fa814f(x5770cdefd8931aa9, 828, xd2f68ee6f47e9dfb);
				break;
			}
		}
	}

	private static void x19c67cd0ac63a355(x874ec168cb1feb74 x0f7b23d1c393aed9, ShapeBase x5770cdefd8931aa9)
	{
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "style":
				x27cf1b85222f7217(x0f7b23d1c393aed9, x5770cdefd8931aa9, x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			case "inset":
				x0c5c352e9e7f5a48(x5770cdefd8931aa9, x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			}
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("textbox"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "txbxContent")
			{
				x0f7b23d1c393aed9.x7a60e084fa9fb0e3(x5770cdefd8931aa9);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	private static void x27cf1b85222f7217(x874ec168cb1feb74 x0f7b23d1c393aed9, ShapeBase x5770cdefd8931aa9, string x44ecfea61c937b8e)
	{
		x94f937e2091879d2[] array = x97185e831527a216(x44ecfea61c937b8e);
		string text = null;
		string text2 = null;
		for (int i = 0; i < array.Length; i++)
		{
			string xd2f68ee6f47e9dfb = array[i].xd2f68ee6f47e9dfb;
			switch (array[i].x759aa16c2016a289)
			{
			case "layout-flow":
				text = xd2f68ee6f47e9dfb;
				break;
			case "mso-layout-flow-alt":
				text2 = xd2f68ee6f47e9dfb;
				break;
			case "mso-fit-shape-to-text":
				x9296b3c358fa814f(x5770cdefd8931aa9, 190, xd2f68ee6f47e9dfb);
				break;
			case "mso-next-textbox":
			{
				ShapeBase shapeBase = x0f7b23d1c393aed9.x5b35a0b873aef5ad(xd2f68ee6f47e9dfb.Trim('#'));
				if (shapeBase != null)
				{
					x5770cdefd8931aa9.x0817d5cde9e19bf6(138, shapeBase.xea1e81378298fa81);
				}
				else
				{
					xe0dfc10ade3a30e2(x5770cdefd8931aa9, 138, xd2f68ee6f47e9dfb);
				}
				break;
			}
			}
		}
		if (text != null)
		{
			if (text == "vertical" && text2 == "bottom-to-top")
			{
				x5770cdefd8931aa9.x0817d5cde9e19bf6(136, LayoutFlow.BottomToTop);
			}
			else
			{
				x5770cdefd8931aa9.x0817d5cde9e19bf6(136, xf4107e64edda7fac.xf50e8ec4ddd88913(text));
			}
		}
	}

	private static void x3337a3b14df78af2(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "dgmstyle":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1281, xe134235b3526fa75.xbba6773b8ce56a01);
				break;
			case "dgmscalex":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1285, xe134235b3526fa75.xbba6773b8ce56a01);
				break;
			case "dgmscaley":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1286, xe134235b3526fa75.xbba6773b8ce56a01);
				break;
			case "dgmfontsize":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1287, xe134235b3526fa75.xbba6773b8ce56a01);
				break;
			case "constrainbounds":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(1288, x5d16692b861b7f58(xe134235b3526fa75.xd2f68ee6f47e9dfb));
				break;
			case "autoformat":
				x9296b3c358fa814f(x5770cdefd8931aa9, 1340, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "reverse":
				x9296b3c358fa814f(x5770cdefd8931aa9, 1341, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			default:
				xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{xe134235b3526fa75.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			case "ext":
				break;
			}
		}
		while (xe134235b3526fa75.x152cbadbfa8061b1("diagram"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xe134235b3526fa75.xa66385d80d4d296f) != null && xa66385d80d4d296f == "relationtable")
			{
				x988e94e1f865d0be(x5770cdefd8931aa9, xe134235b3526fa75);
			}
		}
	}

	private static void x988e94e1f865d0be(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		ArrayList arrayList = new ArrayList();
		while (xe134235b3526fa75.x152cbadbfa8061b1("relationtable"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xe134235b3526fa75.xa66385d80d4d296f) != null && xa66385d80d4d296f == "rel")
			{
				arrayList.Add(x586cf3a739777d74(xe134235b3526fa75));
			}
		}
		x580ae020787e37f2[] xbcea506a33cf = (x580ae020787e37f2[])arrayList.ToArray(typeof(x580ae020787e37f2));
		x5770cdefd8931aa9.x0817d5cde9e19bf6(1284, xbcea506a33cf);
	}

	private static x580ae020787e37f2 x586cf3a739777d74(x3c85359e1389ad43 xe134235b3526fa75)
	{
		x580ae020787e37f2 x580ae020787e37f = new x580ae020787e37f2();
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = xe134235b3526fa75.xd2f68ee6f47e9dfb;
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "idsrc":
				x580ae020787e37f.xda71bf6f7c07c3bc = x64893267b789fd52.x650d90d2e073ca99(xd2f68ee6f47e9dfb);
				break;
			case "iddest":
				x580ae020787e37f.x8e8f6cc6a0756b05 = x64893267b789fd52.x650d90d2e073ca99(xd2f68ee6f47e9dfb);
				break;
			case "idcntr":
				x580ae020787e37f.x857912840ffd015f = x64893267b789fd52.x650d90d2e073ca99(xd2f68ee6f47e9dfb);
				break;
			}
		}
		return x580ae020787e37f;
	}

	private static void x8f98f0a173d360f1(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = xe134235b3526fa75.xd2f68ee6f47e9dfb;
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "type":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(832, xf4107e64edda7fac.x864b3f1174a01cf5(xd2f68ee6f47e9dfb));
				break;
			case "gap":
				x509b015aed55247b(x5770cdefd8931aa9, 833, xd2f68ee6f47e9dfb);
				break;
			case "angle":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(834, xf4107e64edda7fac.x3b14761e6e5d8699(xd2f68ee6f47e9dfb));
				break;
			case "drop":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(835, xf4107e64edda7fac.x54c01892d0a0f2b9(xd2f68ee6f47e9dfb));
				break;
			case "distance":
				x509b015aed55247b(x5770cdefd8931aa9, 836, xd2f68ee6f47e9dfb);
				break;
			case "length":
				x509b015aed55247b(x5770cdefd8931aa9, 837, xd2f68ee6f47e9dfb);
				break;
			case "on":
				x9296b3c358fa814f(x5770cdefd8931aa9, 889, xd2f68ee6f47e9dfb);
				break;
			case "accentbar":
				x9296b3c358fa814f(x5770cdefd8931aa9, 890, xd2f68ee6f47e9dfb);
				break;
			case "textborder":
				x9296b3c358fa814f(x5770cdefd8931aa9, 891, xd2f68ee6f47e9dfb);
				break;
			case "minusx":
				x9296b3c358fa814f(x5770cdefd8931aa9, 892, xd2f68ee6f47e9dfb);
				break;
			case "minusy":
				x9296b3c358fa814f(x5770cdefd8931aa9, 893, xd2f68ee6f47e9dfb);
				break;
			case "dropauto":
				x9296b3c358fa814f(x5770cdefd8931aa9, 894, xd2f68ee6f47e9dfb);
				break;
			case "lengthspecified":
				x9296b3c358fa814f(x5770cdefd8931aa9, 895, xd2f68ee6f47e9dfb);
				break;
			default:
				xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{xe134235b3526fa75.xa66385d80d4d296f}' is not supported upon VML import by Aspose.Words.");
				break;
			case "ext":
				break;
			}
		}
	}

	private static x9fb6ff04f20b10d0[] x4ba7b774a02360b9(string xbcea506a33cf9111)
	{
		string[] array = xbcea506a33cf9111.Split(';');
		x9fb6ff04f20b10d0[] array2 = new x9fb6ff04f20b10d0[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string[] array3 = array[i].Split(' ');
			x2a3247c644c44cfe x2a3247c644c44cfe2 = new x2a3247c644c44cfe(array3[0]);
			if (!x2a3247c644c44cfe2.x08428aa3999da322)
			{
				return null;
			}
			x9fb6ff04f20b10d0 x9fb6ff04f20b10d = new x9fb6ff04f20b10d0();
			x9fb6ff04f20b10d.x12cb12b5d2cad53d = x2a3247c644c44cfe2.x73932d675f106aa4();
			x9fb6ff04f20b10d.x9b41425268471380 = xd76179d16486fd56.xe74389aafc9d4795(array3[1]);
			array2[i] = x9fb6ff04f20b10d;
		}
		return array2;
	}

	private static void x4f20d5e30002fcdf(ShapeBase x5770cdefd8931aa9, x3c85359e1389ad43 xe134235b3526fa75)
	{
		x5770cdefd8931aa9.x0817d5cde9e19bf6(4097, WrapType.None);
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = xe134235b3526fa75.xd2f68ee6f47e9dfb;
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "type":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4097, xf4107e64edda7fac.x0d29c97d8bab7a6f(xd2f68ee6f47e9dfb));
				break;
			case "side":
				x5770cdefd8931aa9.x0817d5cde9e19bf6(4098, xf4107e64edda7fac.xec5e778f3d5c351d(xd2f68ee6f47e9dfb));
				break;
			}
		}
	}

	private static void xdeeab4ee20421f7a(ShapeBase x5770cdefd8931aa9, int x2b4bceeb0893721a, x3c85359e1389ad43 xe134235b3526fa75)
	{
		Border border = (Border)x5770cdefd8931aa9.xf7125312c7ee115c.xfe91eeeafcb3026a(x2b4bceeb0893721a);
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = xe134235b3526fa75.xd2f68ee6f47e9dfb;
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "type":
				border.LineStyle = xf4107e64edda7fac.xa557cb87585a987a(xd2f68ee6f47e9dfb);
				break;
			case "width":
				border.x3b83679cceee1fab(xca004f56614e2431.xec25d08a2af152f0(xd2f68ee6f47e9dfb) / 8.0);
				break;
			case "shadow":
				border.Shadow = xd2f68ee6f47e9dfb == "t";
				break;
			}
		}
	}

	private static void x9296b3c358fa814f(ShapeBase x5770cdefd8931aa9, int x01dfff6a67355342, string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "t":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(x01dfff6a67355342, true);
			break;
		case "f":
			x5770cdefd8931aa9.x0817d5cde9e19bf6(x01dfff6a67355342, false);
			break;
		}
	}

	private static void x9296b3c358fa814f(ShapeBase x5770cdefd8931aa9, int x01dfff6a67355342, string x76e58942e2e976f3, string xa55a65662fed1d4a, string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == x76e58942e2e976f3)
		{
			x5770cdefd8931aa9.x0817d5cde9e19bf6(x01dfff6a67355342, true);
		}
		else if (xbcea506a33cf9111 == xa55a65662fed1d4a)
		{
			x5770cdefd8931aa9.x0817d5cde9e19bf6(x01dfff6a67355342, false);
		}
	}

	private static Border x64673dc32ec695f4(string x21442f26c768a16a)
	{
		Border border = new Border();
		border.x63b1a7c31a962459 = xd76179d16486fd56.xe74389aafc9d4795(x21442f26c768a16a);
		return border;
	}

	private static void x509b015aed55247b(ShapeBase x5770cdefd8931aa9, int x01dfff6a67355342, string xbcea506a33cf9111)
	{
		x509b015aed55247b(x5770cdefd8931aa9, x01dfff6a67355342, new x2a3247c644c44cfe(xbcea506a33cf9111));
	}

	private static void x509b015aed55247b(ShapeBase x5770cdefd8931aa9, int x01dfff6a67355342, x2a3247c644c44cfe x3de09a5460d85315)
	{
		if (x3de09a5460d85315.xbe8d54f88cd64ef4)
		{
			x5770cdefd8931aa9.x0817d5cde9e19bf6(x01dfff6a67355342, x3de09a5460d85315.xb3c6c275892e218c());
		}
	}

	private static void x0ed85147c46f1d47(ShapeBase x5770cdefd8931aa9, int x01dfff6a67355342, string xbcea506a33cf9111)
	{
		x0ed85147c46f1d47(x5770cdefd8931aa9, x01dfff6a67355342, new x2a3247c644c44cfe(xbcea506a33cf9111));
	}

	private static void x0ed85147c46f1d47(ShapeBase x5770cdefd8931aa9, int x01dfff6a67355342, x2a3247c644c44cfe x3de09a5460d85315)
	{
		if (x3de09a5460d85315.x08428aa3999da322)
		{
			x5770cdefd8931aa9.x0817d5cde9e19bf6(x01dfff6a67355342, x3de09a5460d85315.x73932d675f106aa4());
		}
	}

	private static void x0d8d47b01381afd1(ShapeBase x5770cdefd8931aa9, int x01dfff6a67355342, string xbcea506a33cf9111)
	{
		x2a3247c644c44cfe x2a3247c644c44cfe2 = new x2a3247c644c44cfe(xbcea506a33cf9111);
		if (x2a3247c644c44cfe2.x368bd9f7b8c336b4)
		{
			x5770cdefd8931aa9.x0817d5cde9e19bf6(x01dfff6a67355342, x2a3247c644c44cfe2.x3ec8d5faac556b00());
		}
	}

	private static void xef25af84d1a59dd8(ShapeBase x5770cdefd8931aa9, int x01dfff6a67355342, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			x5770cdefd8931aa9.x0817d5cde9e19bf6(x01dfff6a67355342, xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111));
		}
	}

	private static int[] x5d16692b861b7f58(string xbcea506a33cf9111)
	{
		string[] array = xbcea506a33cf9111.Split(',');
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string x37cf7043760b312e = array[i];
			array2[i] = (int)Math.Round(xca004f56614e2431.xec25d08a2af152f0(x37cf7043760b312e));
		}
		return array2;
	}

	private static void xd148774100fef0df(ShapeBase x5770cdefd8931aa9, string x8133181cdc35bc13)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x8133181cdc35bc13))
		{
			return;
		}
		string[] array = x8133181cdc35bc13.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			if (text != "")
			{
				x5770cdefd8931aa9.x0817d5cde9e19bf6(327 + i, xca004f56614e2431.xa93402510be8434e(text));
			}
		}
	}

	private static void x487cf3476d800366(ShapeBase x5770cdefd8931aa9, string xe125219852864557)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xe125219852864557))
		{
			x1d9b310dd0ec4d07 x1d9b310dd0ec4d8 = new x1d9b310dd0ec4d07(xe125219852864557);
			x5770cdefd8931aa9.x0817d5cde9e19bf6(326, x1d9b310dd0ec4d8.x703b3c5072b7f42e);
			x5770cdefd8931aa9.x0817d5cde9e19bf6(325, x1d9b310dd0ec4d8.x4d7474e8f1849803);
		}
	}

	private static void x0360c0152e0fc04b(ShapeBase x5770cdefd8931aa9, string xbcea506a33cf9111)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			return;
		}
		x2a3247c644c44cfe[] array = x4df1062cd50b7ee1(xbcea506a33cf9111);
		x08d932077485c285[] array2 = new x08d932077485c285[array.Length / 2];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = new x08d932077485c285(array[2 * i].xb43972eaeceafe09(), array[2 * i + 1].xb43972eaeceafe09());
		}
		x5770cdefd8931aa9.x0817d5cde9e19bf6(325, array2);
		x44f2b8bf33b16275[] array3 = new x44f2b8bf33b16275[array2.Length * 2 + 1];
		array3[0] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x01b2723108ff3dfe, 0);
		for (int j = 1; j < array3.Length - 1; j++)
		{
			if (x0d299f323d241756.x7e32f71c3f39b6bc(j))
			{
				array3[j] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x972ee352bc10333a, 0);
			}
			else
			{
				array3[j] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xd0baff30d99dc152, 1);
			}
		}
		array3[^1] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x9fd888e65466818c, 0);
		x5770cdefd8931aa9.x0817d5cde9e19bf6(326, array3);
	}

	private static void xe4616a3e9c60ebde(ShapeBase x5770cdefd8931aa9, string xa801ccff44b0c7eb)
	{
		string[] array = xa801ccff44b0c7eb.Split(',');
		int num = 0;
		int num2 = array.Length - 1;
		for (int i = 521; i <= 524; i++)
		{
			x0ed85147c46f1d47(x5770cdefd8931aa9, i, array[num]);
			num++;
			if (num > num2)
			{
				return;
			}
		}
		for (int j = 525; j <= 526; j++)
		{
			string text = array[num];
			if (text != "")
			{
				x5770cdefd8931aa9.x0817d5cde9e19bf6(j, x64893267b789fd52.xaacec4c76837bf85(text));
			}
			num++;
			if (num > num2)
			{
				break;
			}
		}
	}

	private static void x0c5c352e9e7f5a48(ShapeBase x5770cdefd8931aa9, string x2857b11bb8c6b1ae)
	{
		string[] array = x2857b11bb8c6b1ae.Split(',');
		int num = 0;
		int num2 = array.Length - 1;
		for (int i = 129; i <= 132; i++)
		{
			x509b015aed55247b(x5770cdefd8931aa9, i, array[num]);
			num++;
			if (num > num2)
			{
				break;
			}
		}
	}

	private static void x948627a79fa8f0a9(ShapeBase x5770cdefd8931aa9, string xbcea506a33cf9111)
	{
		x2a3247c644c44cfe[] array = x4df1062cd50b7ee1(xbcea506a33cf9111);
		x0ed85147c46f1d47(x5770cdefd8931aa9, 710, array[0]);
		if (array.Length > 1)
		{
			x0ed85147c46f1d47(x5770cdefd8931aa9, 711, array[1]);
		}
		if (array.Length > 2)
		{
			x509b015aed55247b(x5770cdefd8931aa9, 712, array[2]);
		}
	}

	private static void x3a75cb88c21b34c3(ShapeBase x5770cdefd8931aa9, int xa847f083aa700711, int xf0e7c9f14746ee85, int x9de1d53fd86c3e4d, string xbcea506a33cf9111)
	{
		string[] array = xbcea506a33cf9111.Split(',');
		xef25af84d1a59dd8(x5770cdefd8931aa9, xa847f083aa700711, array[0]);
		if (array.Length > 1)
		{
			xef25af84d1a59dd8(x5770cdefd8931aa9, xf0e7c9f14746ee85, array[1]);
		}
		if (array.Length > 2)
		{
			xef25af84d1a59dd8(x5770cdefd8931aa9, x9de1d53fd86c3e4d, array[2]);
		}
	}

	private static void x7f722db949bc1545(ShapeBase x5770cdefd8931aa9, int xa847f083aa700711, int xf0e7c9f14746ee85, int x9de1d53fd86c3e4d, string xbcea506a33cf9111)
	{
		x2a3247c644c44cfe[] array = x4df1062cd50b7ee1(xbcea506a33cf9111);
		x509b015aed55247b(x5770cdefd8931aa9, xa847f083aa700711, array[0]);
		if (array.Length > 1)
		{
			x509b015aed55247b(x5770cdefd8931aa9, xf0e7c9f14746ee85, array[1]);
		}
		if (array.Length > 2)
		{
			x509b015aed55247b(x5770cdefd8931aa9, x9de1d53fd86c3e4d, array[2]);
		}
	}

	private static void xa817fbd28158dfcb(ShapeBase x5770cdefd8931aa9, int xa847f083aa700711, int xf0e7c9f14746ee85, string xbcea506a33cf9111)
	{
		x2a3247c644c44cfe[] array = x4df1062cd50b7ee1(xbcea506a33cf9111);
		x509b015aed55247b(x5770cdefd8931aa9, xa847f083aa700711, array[0]);
		if (array.Length > 1)
		{
			x509b015aed55247b(x5770cdefd8931aa9, xf0e7c9f14746ee85, array[1]);
		}
	}

	private static void x2d9cfedee1be7521(ShapeBase x5770cdefd8931aa9, int xa847f083aa700711, int xf0e7c9f14746ee85, string xbcea506a33cf9111)
	{
		x2a3247c644c44cfe[] array = x4df1062cd50b7ee1(xbcea506a33cf9111);
		x0ed85147c46f1d47(x5770cdefd8931aa9, xa847f083aa700711, array[0]);
		if (array.Length > 1)
		{
			x0ed85147c46f1d47(x5770cdefd8931aa9, xf0e7c9f14746ee85, array[1]);
		}
	}

	private static double x1bcdeb5b6eb9fd46(string xbcea506a33cf9111, double xc6e85c82d0d89508)
	{
		x2a3247c644c44cfe x2a3247c644c44cfe2 = new x2a3247c644c44cfe(xbcea506a33cf9111);
		if (!x2a3247c644c44cfe2.xbe8d54f88cd64ef4)
		{
			return xc6e85c82d0d89508;
		}
		return x2a3247c644c44cfe2.x8ff6b239b00e02c3();
	}

	private static int x2b680b3d3cc1ed7a(string xbcea506a33cf9111)
	{
		x2a3247c644c44cfe x2a3247c644c44cfe2 = new x2a3247c644c44cfe(xbcea506a33cf9111);
		if (!x2a3247c644c44cfe2.xd4a7cc164493a506)
		{
			return 0;
		}
		return x2a3247c644c44cfe2.xb103d12283d985b7();
	}

	private static x2a3247c644c44cfe[] x4df1062cd50b7ee1(string xbcea506a33cf9111)
	{
		string[] array = xbcea506a33cf9111.Split(',');
		x2a3247c644c44cfe[] array2 = new x2a3247c644c44cfe[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = new x2a3247c644c44cfe(array[i]);
		}
		return array2;
	}

	private static x94f937e2091879d2[] x97185e831527a216(string x44ecfea61c937b8e)
	{
		string[] array = x44ecfea61c937b8e.Split(';');
		x94f937e2091879d2[] array2 = new x94f937e2091879d2[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = x94f937e2091879d2.xb0c325557cbfd6d3(array[i]);
		}
		return x17d9ced8f6780250(array2);
	}

	private static x94f937e2091879d2[] x17d9ced8f6780250(x94f937e2091879d2[] xcdaeea7afaf570ff)
	{
		int num = 0;
		for (int i = 0; i < xcdaeea7afaf570ff.Length; i++)
		{
			if (xcdaeea7afaf570ff[i] != null)
			{
				xcdaeea7afaf570ff[num++] = xcdaeea7afaf570ff[i];
			}
		}
		x94f937e2091879d2[] array = new x94f937e2091879d2[num];
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = xcdaeea7afaf570ff[j];
		}
		return array;
	}

	private static void x9bbc387f03a13c9f(ShapeBase x5770cdefd8931aa9, string xbcea506a33cf9111)
	{
		x2a3247c644c44cfe x2a3247c644c44cfe2 = new x2a3247c644c44cfe(xbcea506a33cf9111);
		double num;
		if (x2a3247c644c44cfe2.x368bd9f7b8c336b4)
		{
			num = (double)x2a3247c644c44cfe2.x3ec8d5faac556b00() / 100.0;
		}
		else
		{
			if (!x2a3247c644c44cfe2.x08428aa3999da322)
			{
				return;
			}
			num = x4574ea26106f0edb.x97ab502db0c0e5c2(x2a3247c644c44cfe2.x73932d675f106aa4());
		}
		int num2 = x15e971129fd80714.x43fcc3f62534530b(num * (double)x5770cdefd8931aa9.x133d653c1b9b01f2);
		x5770cdefd8931aa9.x0817d5cde9e19bf6(327, num2);
	}
}
