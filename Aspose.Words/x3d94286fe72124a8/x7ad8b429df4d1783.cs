using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Aspose.Words.Drawing;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x3d94286fe72124a8;

internal class x7ad8b429df4d1783
{
	internal static bool x383bc40a65c287d0(SizeF x6e2d45096e69e5bf)
	{
		if (x6e2d45096e69e5bf.Width != 0f)
		{
			return x6e2d45096e69e5bf.Height == 0f;
		}
		return true;
	}

	internal static bool xbcb10825d2277113(Shape x5770cdefd8931aa9)
	{
		ShapeType shapeType = x5770cdefd8931aa9.ShapeType;
		if (shapeType == ShapeType.OleObject || shapeType == ShapeType.Image || shapeType == ShapeType.OleControl)
		{
			return true;
		}
		return false;
	}

	internal static LineJoin x643f6e244067ba21(JoinStyle xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			JoinStyle.Bevel => LineJoin.Bevel, 
			JoinStyle.Miter => LineJoin.Miter, 
			JoinStyle.Round => LineJoin.Round, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	internal static LineCap x0e0c641273c637f8(EndCap x8d30d34aebf56aa3)
	{
		return x8d30d34aebf56aa3 switch
		{
			EndCap.Flat => LineCap.Flat, 
			EndCap.Round => LineCap.Round, 
			EndCap.Square => LineCap.Square, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	internal static DashCap xea700875cdbbe3e1(EndCap x8d30d34aebf56aa3)
	{
		switch (x8d30d34aebf56aa3)
		{
		case EndCap.Square:
		case EndCap.Flat:
			return DashCap.Flat;
		case EndCap.Round:
			return DashCap.Round;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	internal static byte[] x91d8d16c995a775e(ImageData xf1c258adc3c53c0e)
	{
		byte[] array = xf1c258adc3c53c0e.ToByteArray();
		x24fae39da17573bb x24fae39da17573bb = x6f9d4dc1dd1cae62(xf1c258adc3c53c0e);
		if (x24fae39da17573bb.xf8d5458b61f7fa46())
		{
			return array;
		}
		if (xf1c258adc3c53c0e.xfe2ff3c162b47c70 == xfe2ff3c162b47c70.x26c36dd85013b919 || xf1c258adc3c53c0e.xfe2ff3c162b47c70 == xfe2ff3c162b47c70.xf6c17f648b65c793)
		{
			return array;
		}
		ImageSize imageSize = xf1c258adc3c53c0e.ImageSize;
		if (xdd1b8f14cc8ba86d.x92d069eca6ec3dfb(imageSize.WidthPixels, imageSize.HeightPixels))
		{
			return array;
		}
		xfe2ff3c162b47c70 x0182a6dae298f8a = xf1c258adc3c53c0e.xfe2ff3c162b47c70;
		if (xf1c258adc3c53c0e.ImageType == ImageType.Emf || xf1c258adc3c53c0e.ImageType == ImageType.Wmf)
		{
			array = xaf1d5886bde15736.x9ae3c76542ff5bd7(array, new SizeF((float)imageSize.HorizontalResolution, (float)imageSize.VerticalResolution));
			x0182a6dae298f8a = xfe2ff3c162b47c70.x6339cdb9e2b512c7;
		}
		using x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(array);
		x3cd5d648729cd9b.x729755e64b399531(x24fae39da17573bb);
		using MemoryStream memoryStream = new MemoryStream();
		x3cd5d648729cd9b.x0acd3c2012ea2ee8(memoryStream, x0182a6dae298f8a);
		return x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
	}

	private static x24fae39da17573bb x6f9d4dc1dd1cae62(ImageData xf1c258adc3c53c0e)
	{
		xb56653ec61f2ac36 colorMode = xb56653ec61f2ac36.x4d0b9d4447ba7566;
		if (xf1c258adc3c53c0e.BiLevel)
		{
			colorMode = xb56653ec61f2ac36.x478ac70dbc87f772;
		}
		else if (xf1c258adc3c53c0e.GrayScale)
		{
			colorMode = xb56653ec61f2ac36.x3d4eb3afdab166b1;
		}
		return new x24fae39da17573bb(colorMode, (float)xf1c258adc3c53c0e.Brightness, (float)xf1c258adc3c53c0e.Contrast);
	}
}
