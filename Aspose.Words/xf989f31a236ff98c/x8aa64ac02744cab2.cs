using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Saving;
using x011d489fb9df7027;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using xe9865c3fb834da49;
using xf9a9481c3f63a419;

namespace xf989f31a236ff98c;

internal class x8aa64ac02744cab2 : x6585e25befaba8c8
{
	private const int xb850d14a2556f7da = 85;

	private const int x7e4ee22d1934ca96 = 100;

	private readonly bool xbeef786b8bbfd295;

	private int x16f4a000974df955;

	private readonly Hashtable x8b143a79a2043e70;

	private ShapeBase xc9e8f593f801ffa5;

	private ShapeBase xa07c9a8f392ce811;

	private Shape xd5476886e05c3d6e;

	private bool x912ee37509b04eb8;

	private bool x90ddc8763f1645bb;

	private xcd1c64d43058619d x83d0f75f3858e3a4;

	private SizeF xa65844a46ecb71e7 = SizeF.Empty;

	private readonly xcca9b9b2025d882d xc7c56394e1860ffc;

	private StringBuilder x350f0aba79dc6228;

	internal xcca9b9b2025d882d xdbc86bd624bac965 => xc7c56394e1860ffc;

	internal x8aa64ac02744cab2(string fileName, xc1973d08dacd6dfc subsidiaryContentPartHandler, string exportImagesFolder, string exportImagesFolderAlias, string messageWhenNoResourceFolder, bool storeRemoteImages)
		: base(fileName, subsidiaryContentPartHandler, exportImagesFolder, exportImagesFolderAlias, messageWhenNoResourceFolder)
	{
		xbeef786b8bbfd295 = storeRemoteImages;
		x8b143a79a2043e70 = new Hashtable();
		xc7c56394e1860ffc = new xcca9b9b2025d882d();
		if (x89e7ffdaa1e0fd25 != null)
		{
			x9f6db1997310ea42 = "image";
		}
	}

	private void xfe89c9f0756a06e3()
	{
		xc7c56394e1860ffc.xb1de1ba20faeeff8(xa07c9a8f392ce811, xd5476886e05c3d6e, xa65844a46ecb71e7);
	}

	internal string xfb1931cb210293d9(ShapeBase x366fc53c4dda2594, ShapeBase x5db468777219ec4d, xcd1c64d43058619d xdfde339da46db651, SizeF x0ceec69a97f73617)
	{
		xc9e8f593f801ffa5 = x366fc53c4dda2594;
		xa07c9a8f392ce811 = x5db468777219ec4d;
		xd5476886e05c3d6e = null;
		x912ee37509b04eb8 = x73082c75f5b38659(x366fc53c4dda2594);
		x90ddc8763f1645bb = true;
		x83d0f75f3858e3a4 = xdfde339da46db651;
		xa65844a46ecb71e7 = x0ceec69a97f73617;
		xfe89c9f0756a06e3();
		return xbde19bf3ea0915ae(x047979bcfe41b5d7: true, xfe2ff3c162b47c70.x6339cdb9e2b512c7);
	}

	private static bool x73082c75f5b38659(CompositeNode x908338b83832d1aa)
	{
		bool flag = false;
		Node node = x908338b83832d1aa.FirstChild;
		while (!flag && node != null)
		{
			switch (node.NodeType)
			{
			case NodeType.Shape:
				flag = ((CompositeNode)node).HasChildNodes;
				break;
			case NodeType.GroupShape:
				flag = x73082c75f5b38659((CompositeNode)node);
				break;
			}
			node = node.NextSibling;
		}
		return flag;
	}

	internal string x69e367df6bceb25b(ShapeBase x10e3e3c2d91f0950, Shape xc9919d3e593d69ed, xcd1c64d43058619d xdfde339da46db651, SizeF x0ceec69a97f73617)
	{
		xc9e8f593f801ffa5 = x10e3e3c2d91f0950;
		xa07c9a8f392ce811 = xc9919d3e593d69ed;
		xd5476886e05c3d6e = xc9919d3e593d69ed;
		x912ee37509b04eb8 = x10e3e3c2d91f0950.HasChildNodes;
		x90ddc8763f1645bb = x912ee37509b04eb8;
		x83d0f75f3858e3a4 = xdfde339da46db651;
		xa65844a46ecb71e7 = x0ceec69a97f73617;
		xfe89c9f0756a06e3();
		string text = null;
		object obj = (x912ee37509b04eb8 ? null : x8b143a79a2043e70[text = xe61a0be5249feb49()]);
		string text2;
		if (obj != null)
		{
			text2 = (string)obj;
		}
		else
		{
			text2 = xde9333630a439a3b();
			if (text != null)
			{
				x8b143a79a2043e70.Add(text, text2);
			}
		}
		return text2;
	}

	private string xde9333630a439a3b()
	{
		ShapeType shapeType = xa07c9a8f392ce811.ShapeType;
		bool flag = shapeType == ShapeType.Image || shapeType == ShapeType.OleObject || shapeType == ShapeType.OleControl;
		x90ddc8763f1645bb = x90ddc8763f1645bb || !flag;
		bool flag2 = true;
		bool flag3 = true;
		xfe2ff3c162b47c70 x0182a6dae298f8a = xfe2ff3c162b47c70.x6339cdb9e2b512c7;
		byte[] array = null;
		if (flag)
		{
			ImageData imageData = xd5476886e05c3d6e.ImageData;
			array = imageData.ImageBytes;
			if (!xcd4bd3abd72ff2da.x57a8965bf85f0d71(array))
			{
				string sourceFullName = imageData.SourceFullName;
				if (sourceFullName.Length == 0)
				{
					x90ddc8763f1645bb = true;
				}
				else
				{
					if (!x90ddc8763f1645bb && !xbeef786b8bbfd295 && x0d4d45882065c63e.xe06270bc72b12369(sourceFullName))
					{
						return sourceFullName;
					}
					array = imageData.x096dc407252fbea0();
					flag3 = xcd4bd3abd72ff2da.x57a8965bf85f0d71(array);
					if (!flag3)
					{
						array = x0d299f323d241756.xcd6c2a9742c9220a();
					}
					flag2 = false;
				}
			}
			if (xcd4bd3abd72ff2da.x57a8965bf85f0d71(array))
			{
				x0182a6dae298f8a = xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(array);
				if (flag3 && !x798360f2e0cd0117(x0182a6dae298f8a))
				{
					array = x0d299f323d241756.xcd6c2a9742c9220a();
					x0182a6dae298f8a = xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(array);
					flag2 = false;
					flag3 = false;
				}
				if (!x90ddc8763f1645bb)
				{
					if (xdd1b8f14cc8ba86d.x94d6c004900d4806(x0182a6dae298f8a))
					{
						x90ddc8763f1645bb = x83d0f75f3858e3a4.x2de5889cbc39c38e;
					}
					else if (x83d0f75f3858e3a4.x9411afdd2481f8e3)
					{
						xa2745adfabe0c674 xa2745adfabe0c = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(array, x0182a6dae298f8a);
						x90ddc8763f1645bb = xa2745adfabe0c.xdc1bf80853046136 != x4574ea26106f0edb.x4bec21b1de9d1b5b(xa65844a46ecb71e7.Width, x83d0f75f3858e3a4.xfb7a4eb022a84f48) || xa2745adfabe0c.xb0f146032f47c24e != x4574ea26106f0edb.x4bec21b1de9d1b5b(xa65844a46ecb71e7.Height, x83d0f75f3858e3a4.xfb7a4eb022a84f48);
					}
				}
			}
		}
		if (x90ddc8763f1645bb)
		{
			if (!flag2)
			{
				xbe881e10447652b9();
				xa07c9a8f392ce811.x0817d5cde9e19bf6(4102, array);
			}
			return xbde19bf3ea0915ae(flag3, x0182a6dae298f8a);
		}
		return x389b7f057b1aab05(flag3, array, x0182a6dae298f8a);
	}

	private static bool x798360f2e0cd0117(xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		switch (x0182a6dae298f8a4)
		{
		case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
		case xfe2ff3c162b47c70.xb5fe04c34562f438:
		case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
		case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
		case xfe2ff3c162b47c70.xc2746d872ce402e9:
			return true;
		default:
			return false;
		}
	}

	private string xe61a0be5249feb49()
	{
		if (x350f0aba79dc6228 == null)
		{
			x350f0aba79dc6228 = new StringBuilder(1024);
		}
		else
		{
			x350f0aba79dc6228.Length = 0;
		}
		xf7125312c7ee115c xf7125312c7ee115c = xa07c9a8f392ce811.xf7125312c7ee115c;
		for (int i = 0; i < xf7125312c7ee115c.xd44988f225497f3a; i++)
		{
			int num = xf7125312c7ee115c.xf15263674eb297bb(i);
			if (x1851b5a5400b86a0(num))
			{
				continue;
			}
			object obj = xf7125312c7ee115c.x6d3720b962bd3112(i);
			switch (num)
			{
			case 4106:
			case 4107:
			case 4108:
			case 4109:
			{
				Border border = (Border)obj;
				if (border.IsVisible)
				{
					x350f0aba79dc6228.AppendFormat("{0}={{{1},{2},{3},{4},{5},{6},{7},{8},{9}}} ", num, border.LineStyle, border.xab266ea415f07c09, border.x63b1a7c31a962459, border.x1f2d5df87a5c4f81, border.Shadow, border.x227665e444fb500a, border.x19119439284aead2, border.x545df332a972f97f, border.xc7a5a1bef7198132);
					x90ddc8763f1645bb = true;
				}
				continue;
			}
			case 317:
			case 318:
			case 441:
			case 442:
			case 443:
			case 508:
				if ((bool)obj)
				{
					x350f0aba79dc6228.AppendFormat("{0} ", num);
					x90ddc8763f1645bb = true;
				}
				continue;
			case 4096:
			{
				FlipOrientation flipOrientation = (FlipOrientation)obj;
				if (flipOrientation != 0)
				{
					x350f0aba79dc6228.AppendFormat("{0}={1} ", num, flipOrientation);
					x90ddc8763f1645bb = true;
				}
				continue;
			}
			default:
				x90ddc8763f1645bb = true;
				break;
			case 260:
			case 261:
			case 446:
			case 4102:
			case 4104:
			case 4155:
				break;
			}
			object arg = ((num == 4102) ? ((object)obj.GetHashCode()) : obj);
			x350f0aba79dc6228.AppendFormat("{0}={1} ", num, arg);
		}
		x350f0aba79dc6228.AppendFormat("{0} {1}", xa65844a46ecb71e7.Width, xa65844a46ecb71e7.Height);
		return x350f0aba79dc6228.ToString();
	}

	private static bool x1851b5a5400b86a0(int xba08ce632055a1d9)
	{
		if (xba08ce632055a1d9 < 64 || xba08ce632055a1d9 > 127)
		{
			switch (xba08ce632055a1d9)
			{
			default:
				if ((xba08ce632055a1d9 < 919 || xba08ce632055a1d9 > 922) && (xba08ce632055a1d9 < 937 || xba08ce632055a1d9 > 945) && (xba08ce632055a1d9 < 949 || xba08ce632055a1d9 > 959) && xba08ce632055a1d9 != 4097 && xba08ce632055a1d9 != 4098 && xba08ce632055a1d9 != 4099 && xba08ce632055a1d9 != 4103 && xba08ce632055a1d9 != 4112 && xba08ce632055a1d9 != 4113 && xba08ce632055a1d9 != 4114 && xba08ce632055a1d9 != 4115 && xba08ce632055a1d9 != 4116 && xba08ce632055a1d9 != 4117 && xba08ce632055a1d9 != 4118 && xba08ce632055a1d9 != 4119 && xba08ce632055a1d9 != 4120 && xba08ce632055a1d9 != 4123 && xba08ce632055a1d9 != 4124 && xba08ce632055a1d9 != 4129 && xba08ce632055a1d9 != 4130 && xba08ce632055a1d9 != 4131 && xba08ce632055a1d9 != 4132 && xba08ce632055a1d9 != 4154 && xba08ce632055a1d9 != 4155)
				{
					if (xba08ce632055a1d9 >= 4140)
					{
						return xba08ce632055a1d9 <= 4146;
					}
					return false;
				}
				break;
			case 128:
			case 267:
			case 319:
			case 509:
			case 827:
			case 828:
			case 829:
			case 830:
			case 896:
			case 897:
			case 898:
			case 899:
			case 900:
			case 901:
			case 902:
			case 903:
			case 904:
			case 905:
			case 906:
			case 907:
			case 908:
			case 909:
			case 910:
			case 911:
			case 912:
			case 913:
			case 914:
				break;
			}
		}
		return true;
	}

	private string xbde19bf3ea0915ae(bool x047979bcfe41b5d7, xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		if (!xa65844a46ecb71e7.Equals(xa07c9a8f392ce811.SizeInPoints))
		{
			xbe881e10447652b9();
			xa07c9a8f392ce811.Width = xa65844a46ecb71e7.Width;
			xa07c9a8f392ce811.Height = xa65844a46ecb71e7.Height;
		}
		xfe2ff3c162b47c70 xfe2ff3c162b47c = (xdd1b8f14cc8ba86d.x94d6c004900d4806(x0182a6dae298f8a4) ? xfe2ff3c162b47c70.x6339cdb9e2b512c7 : x0182a6dae298f8a4);
		string x0182a6dae298f8a5 = xb9015fe823e7e228.xac88cb4f794761a9(xfe2ff3c162b47c);
		string text = x34e37d8ea1cb8515(x0182a6dae298f8a5);
		string text2 = Path.Combine(x68ad5cedc00f38e6, text);
		PointF pointF = new PointF(x83d0f75f3858e3a4.xfb7a4eb022a84f48, x83d0f75f3858e3a4.xfb7a4eb022a84f48);
		if (x89e7ffdaa1e0fd25 != null && !x83d0f75f3858e3a4.x5835d7994902857b)
		{
			x00e0b1d9cd99a947 transform = new x00e0b1d9cd99a947(xa07c9a8f392ce811, pointF, x912ee37509b04eb8, xc7c56394e1860ffc.x8b61531c8ea35b85());
			x89e7ffdaa1e0fd25.xbc4db1b9481c1d31(new x31e602c0108f40dc(xb9015fe823e7e228.x0ad80fdc3fba643e(xfe2ff3c162b47c), text, xfe2ff3c162b47c, transform));
		}
		else
		{
			ImageSavingArgs imageSavingArgs = null;
			if (x83d0f75f3858e3a4.x16f7934b184a9d0a != null)
			{
				imageSavingArgs = new ImageSavingArgs(xc9e8f593f801ffa5, x047979bcfe41b5d7, text);
				x83d0f75f3858e3a4.x16f7934b184a9d0a.ImageSaving(imageSavingArgs);
				text = imageSavingArgs.ImageFileName;
				text2 = Path.Combine(x68ad5cedc00f38e6, text);
			}
			using x3cd5d648729cd9b6 xe058541ca798c = x00e0b1d9cd99a947.x063e61b390371e67(xa07c9a8f392ce811, pointF, x912ee37509b04eb8, xc7c56394e1860ffc);
			if (x83d0f75f3858e3a4.x5835d7994902857b)
			{
				using MemoryStream memoryStream = new MemoryStream();
				xe0b2c139dfb583c9(xe058541ca798c, memoryStream, xfe2ff3c162b47c);
				text2 = x78d51cddbe03c08c(memoryStream.ToArray(), xfe2ff3c162b47c);
			}
			else if (imageSavingArgs != null && imageSavingArgs.x3477a684b2bbe7b0)
			{
				x3d213ffad4d30370 x3d213ffad4d = imageSavingArgs.xd9984d5750dc6ac8();
				xe0b2c139dfb583c9(xe058541ca798c, x3d213ffad4d.x59aa197935be8c77(), xfe2ff3c162b47c);
				x3d213ffad4d.x14e5354973c7740e();
			}
			else
			{
				x099b711ff05e633b();
				using FileStream x0afafccb090df46c = File.Create(text2);
				xe0b2c139dfb583c9(xe058541ca798c, x0afafccb090df46c, xfe2ff3c162b47c);
			}
		}
		return text2;
	}

	internal static void xe0b2c139dfb583c9(x3cd5d648729cd9b6 xe058541ca798c059, Stream x0afafccb090df46c, xfe2ff3c162b47c70 x4475a8a9e6988e62)
	{
		if (x4475a8a9e6988e62 == xfe2ff3c162b47c70.x796ab23ce57ee1e0)
		{
			xe058541ca798c059.x2746a43e49feca2f(x0afafccb090df46c, (xe058541ca798c059.xdc1bf80853046136 < 256 || xe058541ca798c059.xb0f146032f47c24e < 256) ? 100 : 85);
		}
		else
		{
			xe058541ca798c059.x0acd3c2012ea2ee8(x0afafccb090df46c, x4475a8a9e6988e62);
		}
	}

	private string x389b7f057b1aab05(bool x047979bcfe41b5d7, byte[] x43e181e083db6cdf, xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		object obj = x8b143a79a2043e70[x43e181e083db6cdf];
		if (obj != null)
		{
			return (string)obj;
		}
		string x0182a6dae298f8a5 = xb9015fe823e7e228.xac88cb4f794761a9(x0182a6dae298f8a4);
		string text = x34e37d8ea1cb8515(x0182a6dae298f8a5);
		string text2 = Path.Combine(x68ad5cedc00f38e6, text);
		if (x89e7ffdaa1e0fd25 != null && !x83d0f75f3858e3a4.x5835d7994902857b)
		{
			x89e7ffdaa1e0fd25.xbc4db1b9481c1d31(new x32626c54bb4e8c9e(xb9015fe823e7e228.x0ad80fdc3fba643e(x0182a6dae298f8a4), text, x43e181e083db6cdf));
		}
		else
		{
			ImageSavingArgs imageSavingArgs = null;
			if (x83d0f75f3858e3a4.x16f7934b184a9d0a != null)
			{
				imageSavingArgs = new ImageSavingArgs(xc9e8f593f801ffa5, x047979bcfe41b5d7, text);
				x83d0f75f3858e3a4.x16f7934b184a9d0a.ImageSaving(imageSavingArgs);
				text = imageSavingArgs.ImageFileName;
				text2 = Path.Combine(x68ad5cedc00f38e6, text);
			}
			if (x83d0f75f3858e3a4.x5835d7994902857b)
			{
				text2 = x78d51cddbe03c08c(x43e181e083db6cdf, x0182a6dae298f8a4);
			}
			else if (imageSavingArgs != null && imageSavingArgs.x3477a684b2bbe7b0)
			{
				x3d213ffad4d30370 x3d213ffad4d = imageSavingArgs.xd9984d5750dc6ac8();
				Stream stream = x3d213ffad4d.x59aa197935be8c77();
				stream.Write(x43e181e083db6cdf, 0, x43e181e083db6cdf.Length);
				x3d213ffad4d.x14e5354973c7740e();
			}
			else
			{
				x099b711ff05e633b();
				using Stream stream2 = File.Open(text2, FileMode.Create);
				stream2.Write(x43e181e083db6cdf, 0, x43e181e083db6cdf.Length);
			}
			x8b143a79a2043e70[x43e181e083db6cdf] = text2;
		}
		return text2;
	}

	private static string x78d51cddbe03c08c(byte[] x43e181e083db6cdf, xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		return $"data:{xb9015fe823e7e228.x0ad80fdc3fba643e(x0182a6dae298f8a4)};base64,{Convert.ToBase64String(x43e181e083db6cdf)}";
	}

	private void xbe881e10447652b9()
	{
		if (object.ReferenceEquals(xc9e8f593f801ffa5, xa07c9a8f392ce811))
		{
			if (xd5476886e05c3d6e != null)
			{
				xa07c9a8f392ce811 = (xd5476886e05c3d6e = (Shape)xd5476886e05c3d6e.Clone(isCloneChildren: false));
			}
			else
			{
				xa07c9a8f392ce811 = (ShapeBase)xa07c9a8f392ce811.Clone(isCloneChildren: false);
			}
		}
	}

	private string x34e37d8ea1cb8515(string x0182a6dae298f8a4)
	{
		return $"{x9f6db1997310ea42}.{xca004f56614e2431.x1da955c8970871e3(++x16f4a000974df955)}.{x0182a6dae298f8a4}";
	}

	internal static LineStyle xe9bc0b2ab2d85b2f(DashStyle x0bde43e8666e4580)
	{
		return x0bde43e8666e4580 switch
		{
			DashStyle.Solid => LineStyle.Single, 
			DashStyle.ShortDash => LineStyle.DashSmallGap, 
			DashStyle.ShortDot => LineStyle.Dot, 
			DashStyle.ShortDashDot => LineStyle.DotDash, 
			DashStyle.ShortDashDotDot => LineStyle.DotDotDash, 
			DashStyle.Dot => LineStyle.Dot, 
			DashStyle.Dash => LineStyle.DashLargeGap, 
			DashStyle.LongDash => LineStyle.DashLargeGap, 
			DashStyle.DashDot => LineStyle.DotDash, 
			DashStyle.LongDashDot => LineStyle.DotDash, 
			DashStyle.LongDashDotDot => LineStyle.DotDotDash, 
			_ => LineStyle.Single, 
		};
	}

	internal static bool xf053cfa2478ebf73(ShapeType xb49a990fe73b42a0)
	{
		if (xb49a990fe73b42a0 != ShapeType.Image && xb49a990fe73b42a0 != ShapeType.OleObject)
		{
			return xb49a990fe73b42a0 == ShapeType.OleControl;
		}
		return true;
	}
}
