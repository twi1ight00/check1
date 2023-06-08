using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class x253dc1c25dfd49a2
{
	private x253dc1c25dfd49a2()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, xeedad81aaed42a76 x789564759d365819)
	{
		Shape shape = new Shape(xe134235b3526fa75.x2c8c6741422a1298);
		shape.xf7125312c7ee115c.xae20093bed1e48a8(508, false);
		shape.xf7125312c7ee115c.x52b190e626f65140(459);
		if (x0d299f323d241756.x5959bccb67bbf051(xe134235b3526fa75.x58c712b0d1d1c39b))
		{
			shape.HRef = xe134235b3526fa75.x58c712b0d1d1c39b;
		}
		if (x0d299f323d241756.x5959bccb67bbf051(xe134235b3526fa75.x42f4c234c9358072))
		{
			shape.Target = xe134235b3526fa75.x42f4c234c9358072;
		}
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
		xf7125312c7ee115c xf7125312c7ee115c = x16d251a5397fc7c8(xe134235b3526fa75);
		x1ba13e535f55aa54 x44ecfea61c937b8e = (x1ba13e535f55aa54)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, "graphic", xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
		x0c1288d16c9571df(xe134235b3526fa75, shape.xf7125312c7ee115c);
		x789564759d365819?.xab3af626b1405ee8(shape.xeedad81aaed42a76);
		double num = x9b7166a30e8f5c4f(xe134235b3526fa75, x8b2c3c076d5a7daf, shape, xf7125312c7ee115c);
		if (double.IsNaN(num) && shape.xf7125312c7ee115c.xf7866f89640a29a3(4132) == null)
		{
			shape.xf7125312c7ee115c.xae20093bed1e48a8(4132, xbb857c9fc36f5054.xc42baa2576960ea5("2.54cm"));
		}
		if (!double.IsNaN(num) && shape.xf7125312c7ee115c.xf7866f89640a29a3(4132) == null)
		{
			shape.xf7125312c7ee115c.xae20093bed1e48a8(4132, num);
			shape.xf7125312c7ee115c.xae20093bed1e48a8(190, true);
		}
		xf7125312c7ee115c.xab3af626b1405ee8(shape.xf7125312c7ee115c);
		xc6b4c0fd353e4c10(shape, x44ecfea61c937b8e);
	}

	internal static void x0c1288d16c9571df(xf871da68decec406 xe134235b3526fa75, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		x1ba13e535f55aa54 x1ba13e535f55aa55 = (x1ba13e535f55aa54)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, "graphic", xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
		if (x1ba13e535f55aa55 != null && x1ba13e535f55aa55.xf7125312c7ee115c != null)
		{
			x1ba13e535f55aa55.xf7125312c7ee115c.xab3af626b1405ee8(xa5e8b8b5991a4e1d);
		}
	}

	internal static void xc6b4c0fd353e4c10(Shape x5770cdefd8931aa9, x1ba13e535f55aa54 x44ecfea61c937b8e)
	{
		if (x5770cdefd8931aa9.xf7125312c7ee115c.xf7866f89640a29a3(4) == null)
		{
			if (x5770cdefd8931aa9.RelativeVerticalPosition == RelativeVerticalPosition.Line)
			{
				x5770cdefd8931aa9.Top = 0.0 - x5770cdefd8931aa9.Top;
			}
			if (x5770cdefd8931aa9.Stroked)
			{
				x5770cdefd8931aa9.Left += x5770cdefd8931aa9.StrokeWeight;
				x5770cdefd8931aa9.Top += x5770cdefd8931aa9.StrokeWeight;
				x5770cdefd8931aa9.Width = ((x5770cdefd8931aa9.Width < x5770cdefd8931aa9.StrokeWeight * 2.0) ? 0.0 : (x5770cdefd8931aa9.Width - x5770cdefd8931aa9.StrokeWeight * 2.0));
				x5770cdefd8931aa9.Height = ((x5770cdefd8931aa9.Height < x5770cdefd8931aa9.StrokeWeight * 2.0) ? 0.0 : (x5770cdefd8931aa9.Height - x5770cdefd8931aa9.StrokeWeight * 2.0));
			}
			if ((x5770cdefd8931aa9.Height == 0.0 || x5770cdefd8931aa9.Width == 0.0) && x5770cdefd8931aa9.xf7125312c7ee115c.xf7866f89640a29a3(190) == null)
			{
				x5770cdefd8931aa9.xf7125312c7ee115c.xae20093bed1e48a8(190, true);
			}
			x5846084bb3a596db(x5770cdefd8931aa9, x44ecfea61c937b8e);
		}
	}

	private static void x5846084bb3a596db(Shape x5770cdefd8931aa9, x1ba13e535f55aa54 x44ecfea61c937b8e)
	{
		if (x5770cdefd8931aa9.Height != 0.0 && x5770cdefd8931aa9.Width != 0.0 && x44ecfea61c937b8e != null && (x44ecfea61c937b8e.x911fb1cc904ad8ee != 0.0 || x44ecfea61c937b8e.xda8d5e2df97ef739 != 0.0 || x44ecfea61c937b8e.xd7776f52196e7855 != 0.0 || x44ecfea61c937b8e.x332a4841aef33498 != 0.0) && x5770cdefd8931aa9.x169baa05e57bf312)
		{
			ImageSize imageSize = x5770cdefd8931aa9.ImageData.ImageSize;
			if (imageSize.x22ab5dfa6f12e902)
			{
				x5770cdefd8931aa9.xf7125312c7ee115c.xae20093bed1e48a8(259, x4574ea26106f0edb.x091b250f00534aae(x44ecfea61c937b8e.x911fb1cc904ad8ee / imageSize.WidthPoints));
				x5770cdefd8931aa9.xf7125312c7ee115c.xae20093bed1e48a8(256, x4574ea26106f0edb.x091b250f00534aae(x44ecfea61c937b8e.xda8d5e2df97ef739 / imageSize.HeightPoints));
				x5770cdefd8931aa9.xf7125312c7ee115c.xae20093bed1e48a8(258, x4574ea26106f0edb.x091b250f00534aae(x44ecfea61c937b8e.x332a4841aef33498 / imageSize.WidthPoints));
				x5770cdefd8931aa9.xf7125312c7ee115c.xae20093bed1e48a8(257, x4574ea26106f0edb.x091b250f00534aae(x44ecfea61c937b8e.xd7776f52196e7855 / imageSize.HeightPoints));
			}
		}
	}

	private static xf7125312c7ee115c x16d251a5397fc7c8(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xf7125312c7ee115c xf7125312c7ee115c = new xf7125312c7ee115c();
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xf871da68decec406.x46e6752379e6650e(xe134235b3526fa75, xf7125312c7ee115c) && !xf871da68decec406.xec2649804854d946(xe134235b3526fa75, xf7125312c7ee115c) && !xf871da68decec406.x082ded0c9904f37b(xca994afbcb9073a, xf7125312c7ee115c) && !xe134235b3526fa75.x42e780a8d918ac91(xca994afbcb9073a, xf7125312c7ee115c))
			{
				string xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f;
				switch (xa66385d80d4d296f)
				{
				case null:
				case "min-height":
				case "min-width":
				case "max-height":
					continue;
				}
				_ = xa66385d80d4d296f == "max-width";
			}
		}
		return xf7125312c7ee115c;
	}

	internal static double x9b7166a30e8f5c4f(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, Shape x5770cdefd8931aa9, xf7125312c7ee115c x9eb32c5411e3ab87)
	{
		if (x8b2c3c076d5a7daf is Shape || x8b2c3c076d5a7daf is Cell)
		{
			return double.NaN;
		}
		double result = double.NaN;
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("frame"))
		{
			if (xe134235b3526fa75.xb18e918c8e329f66(x9eb32c5411e3ab87))
			{
				continue;
			}
			switch (xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f)
			{
			case "text-box":
				if (xe134235b3526fa75.x51811c878dba9ce3)
				{
					xca994afbcb9073a.IgnoreElement();
					break;
				}
				xe134235b3526fa75.x51811c878dba9ce3 = true;
				x5770cdefd8931aa9.x88d1b78392d1a0ab(ShapeType.TextBox);
				result = x451afc3a84b05bf5.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf, x5770cdefd8931aa9);
				xe134235b3526fa75.x51811c878dba9ce3 = false;
				break;
			case "image":
				x5770cdefd8931aa9.x88d1b78392d1a0ab(ShapeType.Image);
				x0ab4ab4e1edb4c1e.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf, x5770cdefd8931aa9);
				break;
			case "object":
			{
				x2eb18b9edfaafee3 x2eb18b9edfaafee4 = new x2eb18b9edfaafee3(xe134235b3526fa75);
				x2eb18b9edfaafee4.x06b0e25aa6ad68a9(x8b2c3c076d5a7daf);
				break;
			}
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
		return result;
	}
}
