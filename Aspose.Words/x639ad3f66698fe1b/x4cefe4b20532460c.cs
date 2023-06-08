using System.Drawing;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x38a89dee67fc7a16;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x639ad3f66698fe1b;

internal class x4cefe4b20532460c
{
	private readonly x21f0d20d41203be1 x8cedcaa9a62c6e39;

	private readonly ShapeBase x317be79405176667;

	private bool x1e5cb3af00660a31;

	private byte[] xd08494dce3b2b550;

	private xfe2ff3c162b47c70 xedcf13d9a3fd42bd;

	private xa2745adfabe0c674 xbfcb11d1f4e5d8ba;

	private readonly int x44dc753af59322b0;

	private readonly int x111981fd37d65307;

	private readonly int x8da4227161459355;

	private readonly int x324a4d4da800de4a;

	private int x0532dd7a0f7d0d7f;

	private int xda3af8c49890009d;

	private readonly BorderCollection xac8df3ffedaa82be;

	private x4cefe4b20532460c(x21f0d20d41203be1 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal x4cefe4b20532460c(x21f0d20d41203be1 context, ShapeBase shape)
		: this(context)
	{
		x317be79405176667 = shape;
		if (x317be79405176667 is Shape shape2 && shape2.x169baa05e57bf312)
		{
			ImageData imageData = shape2.ImageData;
			xb7c4369fea92f2a5(imageData.ImageBytes);
			xac8df3ffedaa82be = imageData.Borders;
			x8da4227161459355 = x15e971129fd80714.x43fcc3f62534530b((double)xbfcb11d1f4e5d8ba.x2293d3e399e86e50 * imageData.CropLeft);
			x324a4d4da800de4a = x15e971129fd80714.x43fcc3f62534530b((double)xbfcb11d1f4e5d8ba.x2293d3e399e86e50 * imageData.CropRight);
			x0532dd7a0f7d0d7f = x15e971129fd80714.x43fcc3f62534530b((double)xbfcb11d1f4e5d8ba.x2a8c8b799b415917 * imageData.CropTop);
			xda3af8c49890009d = x15e971129fd80714.x43fcc3f62534530b((double)xbfcb11d1f4e5d8ba.x2a8c8b799b415917 * imageData.CropBottom);
		}
		SizeF sizeInPoints = x317be79405176667.SizeInPoints;
		x44dc753af59322b0 = x4574ea26106f0edb.x88bf16f2386d633e(sizeInPoints.Width);
		x111981fd37d65307 = x4574ea26106f0edb.x88bf16f2386d633e(sizeInPoints.Height);
	}

	internal x4cefe4b20532460c(x21f0d20d41203be1 context, byte[] imageBytes)
		: this(context)
	{
		xb7c4369fea92f2a5(imageBytes);
		x44dc753af59322b0 = xbfcb11d1f4e5d8ba.x2293d3e399e86e50;
		x111981fd37d65307 = xbfcb11d1f4e5d8ba.x2a8c8b799b415917;
	}

	private void xb7c4369fea92f2a5(byte[] x43e181e083db6cdf)
	{
		xd08494dce3b2b550 = x43e181e083db6cdf;
		xedcf13d9a3fd42bd = xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(xd08494dce3b2b550);
		xbfcb11d1f4e5d8ba = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(xd08494dce3b2b550);
	}

	internal static x4cefe4b20532460c x07aec41b62646646(x21f0d20d41203be1 x0f7b23d1c393aed9, ShapeBase x5770cdefd8931aa9)
	{
		x4cefe4b20532460c x4cefe4b20532460c2 = new x4cefe4b20532460c(x0f7b23d1c393aed9, x5770cdefd8931aa9);
		x4cefe4b20532460c2.x1e5cb3af00660a31 = true;
		x4cefe4b20532460c2.x0532dd7a0f7d0d7f = -x4cefe4b20532460c2.x111981fd37d65307;
		x4cefe4b20532460c2.xda3af8c49890009d = x4cefe4b20532460c2.x111981fd37d65307;
		return x4cefe4b20532460c2;
	}

	private bool x1513c4b020c80f4d(int xb5c369f64ea369e5, int x9b8af180a4e21ec1)
	{
		if (xedcf13d9a3fd42bd != xfe2ff3c162b47c70.xd69df86e2a88ddb2 && xb5c369f64ea369e5 <= 6553 && x9b8af180a4e21ec1 <= 6553 && x9b8af180a4e21ec1 >= 10)
		{
			return xb5c369f64ea369e5 < 10;
		}
		return true;
	}

	internal void x6210059f049f0d48(bool x0efda03510113407, bool x87e9ac2885e28700, x10884bb8036bcee0 x29d5ed4aec3de9b7)
	{
		xbfd162a6d47f59a4 xe1410f585439c7d = x8cedcaa9a62c6e39.xe1410f585439c7d4;
		xe1410f585439c7d.xee60bff2900a72f2("\\pict");
		if (x0efda03510113407 && x317be79405176667 != null)
		{
			xe1410f585439c7d.xee60bff2900a72f2("\\*\\picprop");
			x5fbed40a77205d71 x5fbed40a77205d72 = new x5fbed40a77205d71(x8cedcaa9a62c6e39);
			if (x1e5cb3af00660a31)
			{
				x5fbed40a77205d72.x3b286c2f991fe9df(x317be79405176667);
			}
			else
			{
				x5fbed40a77205d72.x6210059f049f0d48(x317be79405176667);
			}
			xe1410f585439c7d.xc8a13a52db0580ae();
		}
		if (x87e9ac2885e28700)
		{
			x452ab02b4a0f0342();
		}
		if (xedcf13d9a3fd42bd == xfe2ff3c162b47c70.xc2746d872ce402e9)
		{
			xd08494dce3b2b550 = xdd1b8f14cc8ba86d.x9e116920a3e699d8(xd08494dce3b2b550);
			xedcf13d9a3fd42bd = xfe2ff3c162b47c70.xb5fe04c34562f438;
		}
		if (xac8df3ffedaa82be != null)
		{
			xa653462abd146df5();
		}
		xe1410f585439c7d.xb8aea59edd4060ce("\\defshp", x317be79405176667 != null && x317be79405176667.IsWordArt);
		if (xd08494dce3b2b550 != null)
		{
			xf46df138b7f266b7(xedcf13d9a3fd42bd);
			int xb5c369f64ea369e = x15e971129fd80714.x43fcc3f62534530b(100.0 * (double)x44dc753af59322b0 / (double)(xbfcb11d1f4e5d8ba.x2293d3e399e86e50 - x8da4227161459355 - x324a4d4da800de4a));
			int x9b8af180a4e21ec = x15e971129fd80714.x43fcc3f62534530b(100.0 * (double)x111981fd37d65307 / (double)(xbfcb11d1f4e5d8ba.x2a8c8b799b415917 - x0532dd7a0f7d0d7f - xda3af8c49890009d));
			if (x1513c4b020c80f4d(xb5c369f64ea369e, x9b8af180a4e21ec))
			{
				xf05acfb4934c77d9(x44dc753af59322b0, x111981fd37d65307, 100, 100);
			}
			else
			{
				xf05acfb4934c77d9(xbfcb11d1f4e5d8ba.x2293d3e399e86e50, xbfcb11d1f4e5d8ba.x2a8c8b799b415917, xb5c369f64ea369e, x9b8af180a4e21ec);
			}
			xe1410f585439c7d.x4d14ee33f46b5913("\\piccropl", x8da4227161459355);
			xe1410f585439c7d.x4d14ee33f46b5913("\\piccropr", x324a4d4da800de4a);
			xe1410f585439c7d.x4d14ee33f46b5913("\\piccropt", x0532dd7a0f7d0d7f);
			xe1410f585439c7d.x4d14ee33f46b5913("\\piccropb", xda3af8c49890009d);
			x283d2b8b16fdc457 x283d2b8b16fdc = new x283d2b8b16fdc457();
			byte[] array = x283d2b8b16fdc.xc6df3c48d7ea1182(xd08494dce3b2b550, 0, xd08494dce3b2b550.Length);
			int xbcea506a33cf = ((x29d5ed4aec3de9b7 != x10884bb8036bcee0.x1a23317d325de634) ? ((int)x29d5ed4aec3de9b7) : x725adb9cedbc15fa(array));
			xe1410f585439c7d.x4d14ee33f46b5913("\\bliptag", xbcea506a33cf);
			if (xedcf13d9a3fd42bd == xfe2ff3c162b47c70.xb5fe04c34562f438)
			{
				xe1410f585439c7d.x4d14ee33f46b5913("\\blipupi", (int)xbfcb11d1f4e5d8ba.xf2b3620f7bfc9ed5);
			}
			xe1410f585439c7d.xee60bff2900a72f2("\\*\\blipuid");
			xe1410f585439c7d.xf7f536bd531211e3(array);
			xe1410f585439c7d.xc8a13a52db0580ae();
			byte[] xbcea506a33cf2 = xdd1b8f14cc8ba86d.x36948be2ab2261b1(xd08494dce3b2b550);
			xe1410f585439c7d.xf7f536bd531211e3(xbcea506a33cf2);
		}
		else if (x44dc753af59322b0 > 0 && x111981fd37d65307 > 0)
		{
			xf46df138b7f266b7(xfe2ff3c162b47c70.xb5fe04c34562f438);
			xe1410f585439c7d.x4d14ee33f46b5913("\\picwgoal", x44dc753af59322b0);
			xe1410f585439c7d.x4d14ee33f46b5913("\\pichgoal", x111981fd37d65307);
			xe1410f585439c7d.xf7f536bd531211e3(xdd1b8f14cc8ba86d.x8d9c7de3ed8f8607(x44dc753af59322b0, x111981fd37d65307));
		}
		else
		{
			xf46df138b7f266b7(xfe2ff3c162b47c70.x796ab23ce57ee1e0);
		}
		xe1410f585439c7d.xc8a13a52db0580ae();
	}

	private void x452ab02b4a0f0342()
	{
		switch (xedcf13d9a3fd42bd)
		{
		case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
		case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
		case xfe2ff3c162b47c70.x15c106572f1e1fbf:
		case xfe2ff3c162b47c70.x8e716ec1cb703e9f:
		{
			using x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(xd08494dce3b2b550);
			MemoryStream memoryStream = new MemoryStream();
			x3cd5d648729cd9b.x0acd3c2012ea2ee8(memoryStream, xfe2ff3c162b47c70.xc2746d872ce402e9);
			xd08494dce3b2b550 = memoryStream.ToArray();
			xedcf13d9a3fd42bd = xfe2ff3c162b47c70.xc2746d872ce402e9;
			break;
		}
		case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
		case xfe2ff3c162b47c70.xb5fe04c34562f438:
		case xfe2ff3c162b47c70.x26c36dd85013b919:
		case xfe2ff3c162b47c70.xc2746d872ce402e9:
			break;
		}
	}

	private void xf05acfb4934c77d9(int x7af6f1d9dffe750c, int xa1f2a58cfff04246, int xb5c369f64ea369e5, int x9b8af180a4e21ec1)
	{
		xbfd162a6d47f59a4 xe1410f585439c7d = x8cedcaa9a62c6e39.xe1410f585439c7d4;
		xe1410f585439c7d.x4d14ee33f46b5913("\\picw", xd9352874083961b1(x7af6f1d9dffe750c));
		xe1410f585439c7d.x4d14ee33f46b5913("\\pich", xd9352874083961b1(xa1f2a58cfff04246));
		xe1410f585439c7d.x4d14ee33f46b5913("\\picwgoal", x7af6f1d9dffe750c);
		xe1410f585439c7d.x4d14ee33f46b5913("\\pichgoal", xa1f2a58cfff04246);
		xe1410f585439c7d.x4d14ee33f46b5913("\\picscalex", xb5c369f64ea369e5);
		xe1410f585439c7d.x4d14ee33f46b5913("\\picscaley", x9b8af180a4e21ec1);
	}

	private static int xd9352874083961b1(int xf6495da3f9ed2d9c)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x4574ea26106f0edb.xd0c830d607c0b179(xf6495da3f9ed2d9c) * 100.0);
	}

	private static int x725adb9cedbc15fa(byte[] x9d5750eb2d6373bc)
	{
		return (x9d5750eb2d6373bc[0] << 24) | (x9d5750eb2d6373bc[1] << 16) | (x9d5750eb2d6373bc[2] << 8) | x9d5750eb2d6373bc[3];
	}

	private void xa653462abd146df5()
	{
		xc0ea91a4fb0e17d9(BorderType.Left, "\\brdrl");
		xc0ea91a4fb0e17d9(BorderType.Right, "\\brdrr");
		xc0ea91a4fb0e17d9(BorderType.Top, "\\brdrt");
		xc0ea91a4fb0e17d9(BorderType.Bottom, "\\brdrb");
	}

	private void xc0ea91a4fb0e17d9(BorderType xe6e655492739f7d2, string x1c4259f170c30c43)
	{
		Border border = xac8df3ffedaa82be[xe6e655492739f7d2];
		if (border.IsVisible)
		{
			x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913(x1c4259f170c30c43);
			x4bf0725a1c29dbf0.xf3de23fd492ab916(x8cedcaa9a62c6e39, border);
		}
	}

	private void xf46df138b7f266b7(xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		switch (x0182a6dae298f8a4)
		{
		case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
			x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\emfblip");
			break;
		case xfe2ff3c162b47c70.xb5fe04c34562f438:
			x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\wmetafile8");
			break;
		case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
			x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\pngblip");
			break;
		case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
			x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\jpegblip");
			break;
		case xfe2ff3c162b47c70.x26c36dd85013b919:
			x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\macpict");
			break;
		case xfe2ff3c162b47c70.xf6c17f648b65c793:
		case xfe2ff3c162b47c70.x34639b140e83dce7:
		case xfe2ff3c162b47c70.xc2746d872ce402e9:
			break;
		}
	}
}
