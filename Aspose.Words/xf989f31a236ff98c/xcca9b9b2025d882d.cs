using System;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x6c95d9cf46ff5f25;

namespace xf989f31a236ff98c;

internal class xcca9b9b2025d882d
{
	internal double xdc1bf80853046136;

	internal double xb0f146032f47c24e;

	internal double xc8ade15cdad91446;

	internal double xeeb8cbdf228a17cc;

	internal double xb2d2dfd6ea1a3481;

	internal double xd797697fceef84f3;

	internal xcca9b9b2025d882d x8b61531c8ea35b85()
	{
		return (xcca9b9b2025d882d)MemberwiseClone();
	}

	internal void xb1de1ba20faeeff8(ShapeBase x8739b0dd3627f37e, Shape x5770cdefd8931aa9, SizeF xcb8a322601031231)
	{
		x851ecb505ffcd2c6(xcb8a322601031231);
		if (!x8739b0dd3627f37e.IsTopLevel)
		{
			return;
		}
		if (x5770cdefd8931aa9 != null)
		{
			if (!x7f83adc1f00f6c47(x5770cdefd8931aa9) && x8739b0dd3627f37e.WrapType == WrapType.Inline)
			{
				ImageData imageData = x5770cdefd8931aa9.ImageData;
				if (imageData != null)
				{
					xb7a177c3c9bc9c68(imageData);
				}
			}
		}
		else
		{
			x07fc7f90b6602f91(x8739b0dd3627f37e);
		}
		xdb732ce813502f81(x8739b0dd3627f37e);
		if (x5770cdefd8931aa9 != null && x5770cdefd8931aa9.xc764a1afacb94b7e && x5770cdefd8931aa9.x1f468b359604fb97 && x5770cdefd8931aa9.xc6152e5b7b3767b6 == xb156f8ae92094cbb.x1d03f9dbb48b31c4)
		{
			x6bb42c3b0f289d6b(x5770cdefd8931aa9);
		}
	}

	private void x07fc7f90b6602f91(ShapeBase x8739b0dd3627f37e)
	{
		for (Node node = x8739b0dd3627f37e.FirstChild; node != null; node = node.NextSibling)
		{
			if (node is Shape shape && shape.Left == (double)x8739b0dd3627f37e.x06c65daad0c0656c && shape.Top == (double)x8739b0dd3627f37e.x399bb78ac51a4081 && (shape.Width == (double)x8739b0dd3627f37e.x133d653c1b9b01f2 || shape.Height == (double)x8739b0dd3627f37e.xc97e136f0019c237))
			{
				x7f83adc1f00f6c47(shape);
				break;
			}
		}
	}

	private void xb7a177c3c9bc9c68(ImageData xe058541ca798c059)
	{
		BorderCollection borders = xe058541ca798c059.Borders;
		double num = x81439a87fc59aecc(borders.Left);
		double num2 = x81439a87fc59aecc(borders.Right);
		double num3 = x81439a87fc59aecc(borders.Top);
		double num4 = x81439a87fc59aecc(borders.Bottom);
		xdc1bf80853046136 += num + num2;
		xb0f146032f47c24e += num3 + num4;
		xc8ade15cdad91446 += num / 2.0;
		xeeb8cbdf228a17cc += num3 / 2.0;
		xb2d2dfd6ea1a3481 += num;
		xd797697fceef84f3 += num3;
	}

	private void x6bb42c3b0f289d6b(Shape x5770cdefd8931aa9)
	{
		float num = (float)(Math.PI - x15e971129fd80714.xcdc7b29a812dd7df(x4574ea26106f0edb.x97ab502db0c0e5c2(x5770cdefd8931aa9.xc99301776bd4ba37)));
		float num2 = (float)x4574ea26106f0edb.xa23e6b6c3169521d(x5770cdefd8931aa9.x3a3b8d7bf035e50d) / 2f;
		float num3 = (float)x4574ea26106f0edb.xa23e6b6c3169521d(x5770cdefd8931aa9.x31d3d3644e2e74e9) / 2f;
		double num4 = Math.Cos(num);
		double num5 = Math.Sin(num);
		double num6 = ((num4 > 0.0) ? (num4 * (double)num3) : (num4 * (double)(0f - num2)));
		double num7 = ((num5 > 0.0) ? (num5 * (double)num3) : (num5 * (double)(0f - num2)));
		xdc1bf80853046136 += Math.Abs(num4 * (double)(num3 + num2));
		xb0f146032f47c24e += Math.Abs(num5 * (double)(num3 + num2));
		xb2d2dfd6ea1a3481 += num6;
		xd797697fceef84f3 += num7;
		xc8ade15cdad91446 += num6;
		xeeb8cbdf228a17cc += num7;
	}

	private void x851ecb505ffcd2c6(SizeF xcb8a322601031231)
	{
		xdc1bf80853046136 = xcb8a322601031231.Width;
		xb0f146032f47c24e = xcb8a322601031231.Height;
		xc8ade15cdad91446 = 0.0;
		xeeb8cbdf228a17cc = 0.0;
		xb2d2dfd6ea1a3481 = 0.0;
		xd797697fceef84f3 = 0.0;
	}

	private void xdb732ce813502f81(ShapeBase x8739b0dd3627f37e)
	{
		double rotation = x8739b0dd3627f37e.Rotation;
		if (rotation != 0.0)
		{
			rotation = x15e971129fd80714.xcdc7b29a812dd7df(rotation);
			double num = Math.Abs(Math.Cos(rotation));
			double num2 = Math.Abs(Math.Sin(rotation));
			double num3 = xdc1bf80853046136 * num + xb0f146032f47c24e * num2;
			double num4 = xb0f146032f47c24e * num + xdc1bf80853046136 * num2;
			double num5 = xc8ade15cdad91446 * num + xeeb8cbdf228a17cc * num2 + (num3 - xdc1bf80853046136) / 2.0;
			double num6 = xeeb8cbdf228a17cc * num + xc8ade15cdad91446 * num2 + (num4 - xb0f146032f47c24e) / 2.0;
			double num7 = xb2d2dfd6ea1a3481 * num + xd797697fceef84f3 * num2 + (num3 - xdc1bf80853046136) / 2.0;
			double num8 = xd797697fceef84f3 * num + xb2d2dfd6ea1a3481 * num2 + (num4 - xb0f146032f47c24e) / 2.0;
			xdc1bf80853046136 = num3;
			xb0f146032f47c24e = num4;
			xc8ade15cdad91446 = num5;
			xeeb8cbdf228a17cc = num6;
			xb2d2dfd6ea1a3481 = num7;
			xd797697fceef84f3 = num8;
		}
	}

	internal void x5152a5707921c783(double x13e7d17d2c3d925b, double x1bd0774d7f67269d)
	{
		xdc1bf80853046136 *= x13e7d17d2c3d925b;
		xb0f146032f47c24e *= x1bd0774d7f67269d;
		xc8ade15cdad91446 *= x13e7d17d2c3d925b;
		xeeb8cbdf228a17cc *= x1bd0774d7f67269d;
		xb2d2dfd6ea1a3481 *= x13e7d17d2c3d925b;
		xd797697fceef84f3 *= x1bd0774d7f67269d;
	}

	private bool x7f83adc1f00f6c47(Shape x5770cdefd8931aa9)
	{
		Stroke stroke = x5770cdefd8931aa9.Stroke;
		bool flag = stroke.On && stroke.x63b1a7c31a962459.xda71bf6f7c07c3bc > 0;
		if (flag)
		{
			double weight = stroke.Weight;
			double num = weight * 2.0;
			xdc1bf80853046136 += num;
			xb0f146032f47c24e += num;
			xc8ade15cdad91446 += weight / 2.0;
			xeeb8cbdf228a17cc += weight / 2.0;
			xb2d2dfd6ea1a3481 += weight / 2.0;
			xd797697fceef84f3 += weight / 2.0;
		}
		return flag;
	}

	private static double x81439a87fc59aecc(Border xe7ebe10fa44d8d49)
	{
		double result = 0.0;
		if (xe7ebe10fa44d8d49.IsVisible)
		{
			result = xe7ebe10fa44d8d49.xeae235558dc44397;
		}
		return result;
	}
}
