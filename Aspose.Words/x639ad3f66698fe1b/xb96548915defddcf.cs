using System.IO;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x38a89dee67fc7a16;
using x5af3f327d745698a;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;
using xfbd1009a0cbb9842;

namespace x639ad3f66698fe1b;

internal class xb96548915defddcf
{
	private xb96548915defddcf()
	{
	}

	internal static void xa2764f0584a83dc0(x21f0d20d41203be1 x0f7b23d1c393aed9, string x0e59413709b18038, x71d39fdf56861cca x317fc54d326ef25b)
	{
		xbfd162a6d47f59a4 xe1410f585439c7d = x0f7b23d1c393aed9.xe1410f585439c7d4;
		xe1410f585439c7d.xee60bff2900a72f2("\\object");
		xcae1c68ad9da73de xcae1c68ad9da73de = xcae1c68ad9da73de.x1f490eac106aee12(x0e59413709b18038);
		xe1410f585439c7d.x4d14ee33f46b5913(xcae1c68ad9da73de.xe8ae08e6819999f9 ? "\\objautlink" : "\\objlink");
		if (xcae1c68ad9da73de.x2e7d767f7d782a7a != 0 || x0d299f323d241756.x263d579af1d0d43f(x0e59413709b18038, " \\p ", x8b05b1454697839b: false))
		{
			xf100495b2c6b2074(xe1410f585439c7d, xcae1c68ad9da73de.x2e7d767f7d782a7a);
		}
		xe1410f585439c7d.xf55384516c165731("\\*\\objclass", xcae1c68ad9da73de.xe5d13ccbc3df998a);
		if (x317fc54d326ef25b.x6b73aa01aa019d3a != null)
		{
			x60934c0586e98487(xe1410f585439c7d, new xfa9b77033f6e5e27(xcae1c68ad9da73de.xe5d13ccbc3df998a, x317fc54d326ef25b.x6b73aa01aa019d3a, null));
		}
		xe1410f585439c7d.xee60bff2900a72f2("\\result");
	}

	internal static void xfa1528be622d4031(x21f0d20d41203be1 x0f7b23d1c393aed9)
	{
		x0f7b23d1c393aed9.xe1410f585439c7d4.xc8a13a52db0580ae();
		x0f7b23d1c393aed9.xe1410f585439c7d4.xc8a13a52db0580ae();
	}

	internal static void xde8e4a77c0ba56cc(x21f0d20d41203be1 x0f7b23d1c393aed9, Shape x5770cdefd8931aa9)
	{
		OleFormat oleFormat = x5770cdefd8931aa9.OleFormat;
		xbfd162a6d47f59a4 xe1410f585439c7d = x0f7b23d1c393aed9.xe1410f585439c7d4;
		xe1410f585439c7d.xee60bff2900a72f2("\\object");
		if (x5770cdefd8931aa9.xa8228c6215bc2643)
		{
			xe1410f585439c7d.x4d14ee33f46b5913("\\objocx");
		}
		else if (oleFormat.IsLink)
		{
			xe1410f585439c7d.x4d14ee33f46b5913(oleFormat.AutoUpdate ? "\\objautlink" : "\\objlink");
		}
		else
		{
			xe1410f585439c7d.x4d14ee33f46b5913("\\objemb");
		}
		if (oleFormat.IsLink)
		{
			xf100495b2c6b2074(xe1410f585439c7d, oleFormat.x2e7d767f7d782a7a);
		}
		xe1410f585439c7d.x4d14ee33f46b5913("\\objw", x4574ea26106f0edb.x88bf16f2386d633e(x5770cdefd8931aa9.Width));
		xe1410f585439c7d.x4d14ee33f46b5913("\\objh", x4574ea26106f0edb.x88bf16f2386d633e(x5770cdefd8931aa9.Height));
		xe1410f585439c7d.xf55384516c165731("\\*\\objclass", oleFormat.ProgId);
		if (oleFormat.x58932c7e6fa3b905 != null && !x5770cdefd8931aa9.x2e3d2d1def6f4dad)
		{
			xe7be411416cfcd54 embeddedData = (xe7be411416cfcd54)x0f7b23d1c393aed9.x8556eed81191af11.x7c3f3666365efbc6[oleFormat.x58932c7e6fa3b905.x85c663cff7276f51];
			x60934c0586e98487(xe1410f585439c7d, new xfa9b77033f6e5e27(oleFormat.ProgId, embeddedData, xcb1e79d9dd5a13f0(x5770cdefd8931aa9)));
		}
		else if (oleFormat.IsLink)
		{
			x60934c0586e98487(xe1410f585439c7d, new x8844513eda0a5d2e(oleFormat, xcb1e79d9dd5a13f0(x5770cdefd8931aa9)));
		}
		xe1410f585439c7d.xee60bff2900a72f2("\\result");
		if (x5770cdefd8931aa9.xeedad81aaed42a76.x96e55b5d052d1279.x4e98cd0cf854343f())
		{
			xe1410f585439c7d.xee60bff2900a72f2("\\rtlch");
			x0f7b23d1c393aed9.x6fca94e50472ae68.x6210059f049f0d48(x5770cdefd8931aa9.xeedad81aaed42a76, x00ce61b8358bb4cc: false);
		}
		x4cefe4b20532460c x4cefe4b20532460c2 = new x4cefe4b20532460c(x0f7b23d1c393aed9, x5770cdefd8931aa9);
		x4cefe4b20532460c2.x6210059f049f0d48(x0efda03510113407: true, x87e9ac2885e28700: false, x10884bb8036bcee0.x1a23317d325de634);
		if (x5770cdefd8931aa9.xeedad81aaed42a76.x96e55b5d052d1279.x4e98cd0cf854343f())
		{
			xe1410f585439c7d.xc8a13a52db0580ae();
		}
		xe1410f585439c7d.xc8a13a52db0580ae();
		xe1410f585439c7d.xc8a13a52db0580ae();
	}

	private static void xf100495b2c6b2074(xbfd162a6d47f59a4 xd07ce4b74c5774a7, x2e7d767f7d782a7a xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case x2e7d767f7d782a7a.x1351df7d00b0ea53:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\rsltbmp");
			break;
		case x2e7d767f7d782a7a.xf9ad6fb78355fe13:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\rslttxt");
			break;
		case x2e7d767f7d782a7a.xc6077c9598837311:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\rsltmerge");
			break;
		case x2e7d767f7d782a7a.x4bc88de02db3a00d:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\rslthtml");
			break;
		case x2e7d767f7d782a7a.x5896ed36f2cf9162:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\rsltrtf");
			break;
		case x2e7d767f7d782a7a.x7f4d496937f8c24c:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\rsltpict");
			break;
		}
	}

	private static void x60934c0586e98487(xbfd162a6d47f59a4 xd07ce4b74c5774a7, x320b28ae68e47317 x8b0a2a3ecbe641c9)
	{
		if (x8b0a2a3ecbe641c9 != null)
		{
			xd07ce4b74c5774a7.xee60bff2900a72f2("\\*\\objdata");
			xd07ce4b74c5774a7.xe7b920de107da0c7();
			MemoryStream memoryStream = new MemoryStream();
			x8b0a2a3ecbe641c9.x6210059f049f0d48(new BinaryWriter(memoryStream));
			xd07ce4b74c5774a7.xf7f536bd531211e3(memoryStream.ToArray());
			xd07ce4b74c5774a7.xc8a13a52db0580ae();
		}
	}

	private static byte[] xcb1e79d9dd5a13f0(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9 == null)
		{
			return null;
		}
		ImageData imageData = x5770cdefd8931aa9.ImageData;
		if (imageData == null || !imageData.x169baa05e57bf312)
		{
			return null;
		}
		if (imageData.ImageType == ImageType.Wmf)
		{
			return xdd1b8f14cc8ba86d.x36948be2ab2261b1(imageData.ImageBytes);
		}
		if (x5770cdefd8931aa9.OleFormat.x31d18bbaf493b1b0 && imageData.ImageType == ImageType.Emf)
		{
			return xdd1b8f14cc8ba86d.x8d9c7de3ed8f8607(imageData.ImageSize.WidthPixels, imageData.ImageSize.HeightPixels);
		}
		return null;
	}
}
