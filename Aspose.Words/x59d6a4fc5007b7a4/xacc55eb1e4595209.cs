using System;
using System.Collections;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fonts;
using Aspose.Words.Lists;
using Aspose.Words.Math;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x4adf554d20d941a6;
using x5794c252ba25e723;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;
using x9db5f2e5af3d596e;
using xeb665d1aeef09d64;

namespace x59d6a4fc5007b7a4;

internal class xacc55eb1e4595209
{
	private readonly Document xd1424e1a0bb4a72b;

	private readonly x17dcbf5fe3c0d2d2 x3d3ebc31b37b2a88;

	private Hashtable xe9bfb15c0a9a15ab;

	private bool x8098990de281ebb5;

	internal bool x46db7b5e43464144
	{
		get
		{
			return x8098990de281ebb5;
		}
		set
		{
			x8098990de281ebb5 = value;
		}
	}

	private Hashtable x8827bdf0b91a759c
	{
		get
		{
			if (xe9bfb15c0a9a15ab == null)
			{
				xe9bfb15c0a9a15ab = new Hashtable();
				foreach (FontInfo fontInfo in xd1424e1a0bb4a72b.FontInfos)
				{
					if (x0d299f323d241756.x5959bccb67bbf051(fontInfo.Name) && x0d299f323d241756.x5959bccb67bbf051(fontInfo.AltName))
					{
						xe9bfb15c0a9a15ab[fontInfo.Name] = fontInfo.AltName;
					}
				}
			}
			return xe9bfb15c0a9a15ab;
		}
	}

	internal xacc55eb1e4595209(Document document, x17dcbf5fe3c0d2d2 context)
	{
		xd1424e1a0bb4a72b = document;
		x3d3ebc31b37b2a88 = context;
	}

	internal x6b1a899052c71a60 xfeeb3de36742543a(x1d1dd20018fcde10 x26094932cf7a9139, x000f21cbda739311 x6f02b6a80bf6b36f, bool x4aad51c9bc3ee0f3)
	{
		string text = x26094932cf7a9139.xaf95fb496eb25433(x6f02b6a80bf6b36f);
		return xd1424e1a0bb4a72b.FontInfos.x26ee10d60756aeab.FetchTTFont(text, x659bc4263aa7ef66(x26094932cf7a9139, x6f02b6a80bf6b36f, x4aad51c9bc3ee0f3), x72079054369f6e84(text));
	}

	internal x396b77a306f83da6 x8b0f145539d078d0(Node xda5bf54deb817e37)
	{
		x396b77a306f83da6 x396b77a306f83da = x8b0f145539d078d0(xda5bf54deb817e37, 0, x8098990de281ebb5, x3d3ebc31b37b2a88);
		x396b77a306f83da.x622e47c05b903ad2 = x72079054369f6e84(x396b77a306f83da.x759aa16c2016a289);
		if (xda5bf54deb817e37 is ShapeBase && ((ShapeBase)xda5bf54deb817e37).WrapType != 0)
		{
			x396b77a306f83da.xabb599f76795ecaf = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		}
		if (xda5bf54deb817e37.NodeType == NodeType.Paragraph)
		{
			x396b77a306f83da.x4dcd0de8fd7fe251 = x396b77a306f83da.x4dcd0de8fd7fe251 || ((Paragraph)xda5bf54deb817e37).ParagraphFormat.Bidi;
			x396b77a306f83da.x7727f8ae3791a45c = x769ea5e930af2cbc.x4c57b971f1a8d64d(((Paragraph)xda5bf54deb817e37).ParagraphBreakFont.LocaleIdBi);
		}
		return x396b77a306f83da;
	}

	internal x396b77a306f83da6 x8b0f145539d078d0(Node xda5bf54deb817e37, x4f38812d0d5e7231 xd3bc67d2ec0a768b, bool x9faa7f8a5d7090ee)
	{
		x396b77a306f83da6 x396b77a306f83da = x8b0f145539d078d0(xf9e671be87a829f7(xda5bf54deb817e37, x8098990de281ebb5), xd3bc67d2ec0a768b.x9ee8adcec1e2f351, xd3bc67d2ec0a768b.x8c7546b3f6a0da68, x3d3ebc31b37b2a88, xda5bf54deb817e37.Document.FontInfos.x26ee10d60756aeab);
		if (xd3bc67d2ec0a768b.x759aa16c2016a289 != null)
		{
			x396b77a306f83da.x759aa16c2016a289 = xd3bc67d2ec0a768b.x759aa16c2016a289;
		}
		x396b77a306f83da.x622e47c05b903ad2 = x72079054369f6e84(x396b77a306f83da.x759aa16c2016a289);
		x396b77a306f83da.x7727f8ae3791a45c = x9faa7f8a5d7090ee;
		x396b77a306f83da.x3a7473f820dd300b = xd3bc67d2ec0a768b.x3a7473f820dd300b;
		if (xd3bc67d2ec0a768b.x5566e2d2acbd1fbe == 12803)
		{
			x396b77a306f83da.x3a7473f820dd300b = ((Inline)xda5bf54deb817e37).ParentParagraph.ParagraphFormat.Bidi;
		}
		return x396b77a306f83da;
	}

	internal static x396b77a306f83da6 x8b0f145539d078d0(Node xda5bf54deb817e37, int x10aaa7cdfa38f254, bool x739ade918e4c3a5d, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		xeedad81aaed42a76 xeedad81aaed42a = xf9e671be87a829f7(xda5bf54deb817e37, x739ade918e4c3a5d);
		char c = ((NodeType.Run == xda5bf54deb817e37.NodeType || NodeType.SpecialChar == xda5bf54deb817e37.NodeType) ? xda5bf54deb817e37.GetText()[x10aaa7cdfa38f254] : 'A');
		x000f21cbda739311 x6f02b6a80bf6b36f = xb7dbd7bb3ed97d5b.xc0f0857806be03ff(c);
		if (xda5bf54deb817e37.NodeType == NodeType.Paragraph && (xeedad81aaed42a.xcedf9c82728ad579.x4e98cd0cf854343f() || xeedad81aaed42a.xd4e922ceeed89b74.x4e98cd0cf854343f()))
		{
			x6f02b6a80bf6b36f = x000f21cbda739311.xd4e922ceeed89b74;
		}
		return x8b0f145539d078d0(xeedad81aaed42a, x6f02b6a80bf6b36f, ' ' == c || char.IsLower(c), x40c630e0786922f0, xda5bf54deb817e37.Document.FontInfos.x26ee10d60756aeab);
	}

	internal static x396b77a306f83da6 x36f681ceb5afa4e0(Paragraph x31e6518f5e08db6c, x000f21cbda739311 x21a91e2ac6ef5338, bool xfd54855e4993adef, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		xeedad81aaed42a76 xeedad81aaed42a = x31e6518f5e08db6c.ListLabel.x856218fd0771d379();
		bool bidi = x31e6518f5e08db6c.ParagraphFormat.Bidi;
		if (x21a91e2ac6ef5338 != 0 && bidi && x769ea5e930af2cbc.x68e6a98ab5d29468(xeedad81aaed42a.xa59ac2c936c6b7bd))
		{
			x21a91e2ac6ef5338 = x000f21cbda739311.xd4e922ceeed89b74;
		}
		if (x21a91e2ac6ef5338 == x000f21cbda739311.x22a0fbb9469b35e1)
		{
			x21a91e2ac6ef5338 = x000f21cbda739311.x175297738c8b8d1e;
		}
		x396b77a306f83da6 x396b77a306f83da = x8b0f145539d078d0(xeedad81aaed42a, x21a91e2ac6ef5338, xa07e86c08c3543c6: false, x40c630e0786922f0, x31e6518f5e08db6c.Document.FontInfos.x26ee10d60756aeab);
		x396b77a306f83da.x3a7473f820dd300b = bidi;
		if (!bidi && x21a91e2ac6ef5338 == x000f21cbda739311.xd4e922ceeed89b74)
		{
			x396b77a306f83da.x4dcd0de8fd7fe251 = true;
		}
		if (bidi && xfd54855e4993adef)
		{
			x396b77a306f83da.x4dcd0de8fd7fe251 = false;
			x396b77a306f83da.x3a7473f820dd300b = false;
		}
		x396b77a306f83da.x554aca059bdf6d48 = x5709acc7200773ff.x45260ad4b94166f2;
		return x396b77a306f83da6.x38758cbbee49e4cb(x396b77a306f83da);
	}

	private static x396b77a306f83da6 x8b0f145539d078d0(xeedad81aaed42a76 x50a18ad2656e7181, x000f21cbda739311 x6f02b6a80bf6b36f, bool xa07e86c08c3543c6, x17dcbf5fe3c0d2d2 x40c630e0786922f0, x29ade4ed2382a039 x3c756aba143a9e3e)
	{
		x5709acc7200773ff x5709acc7200773ff = new x5709acc7200773ff(x40c630e0786922f0, initKey: false);
		xc8e01097217ac9d2 xc8e01097217ac9d = new xc8e01097217ac9d2(x40c630e0786922f0, initKey: false);
		x396b77a306f83da6 x396b77a306f83da = new x396b77a306f83da6(x40c630e0786922f0);
		FontStyle fontStyle = FontStyle.Regular;
		FontStyle fontStyle2 = FontStyle.Regular;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		bool flag8 = false;
		string x23baa165bca7b6ef = null;
		string x9765a88832769f = null;
		string x4681a4352e687cd = null;
		string xe1755e6a97c = null;
		for (int i = 0; i < x50a18ad2656e7181.xd44988f225497f3a; i++)
		{
			int num = x50a18ad2656e7181.xf15263674eb297bb(i);
			object obj = x50a18ad2656e7181.x6d3720b962bd3112(i);
			if (obj == null)
			{
				continue;
			}
			switch (num)
			{
			case 370:
			{
				Shading shading = (Shading)obj;
				x5709acc7200773ff.x8fdbd80e8da6b0e6 = x0956727ba1bf0544(shading.xc290f60df004e384);
				x5709acc7200773ff.x83729c7ebf48ae24 = x0956727ba1bf0544(shading.x0e18178ac4b2272f);
				x5709acc7200773ff.x7b6a6d281546db99 = shading.Texture;
				break;
			}
			case 360:
			{
				Border border = (Border)obj;
				xc8e01097217ac9d.xffa1fc725bf36690 = (float)border.x32e26c85d00febce;
				xc8e01097217ac9d.x3d0571719b5893b4 = border.LineStyle;
				xc8e01097217ac9d.x9b41425268471380 = x0956727ba1bf0544(border.x63b1a7c31a962459);
				xc8e01097217ac9d.x58316dde3396e982 = (float)border.DistanceFromText;
				xc8e01097217ac9d.x0214605434693fc1 = border.Shadow;
				xc8e01097217ac9d.x75c2a4a522094a98 = border.x227665e444fb500a;
				break;
			}
			case 70:
				if (obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc)
				{
					fontStyle |= FontStyle.Italic;
				}
				break;
			case 260:
				if (obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc)
				{
					fontStyle2 |= FontStyle.Italic;
				}
				break;
			case 60:
				if (obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc)
				{
					fontStyle |= FontStyle.Bold;
				}
				break;
			case 250:
				if (obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc)
				{
					fontStyle2 |= FontStyle.Bold;
				}
				break;
			case 120:
				flag = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			case 110:
				flag2 = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			case 210:
				x396b77a306f83da.x838b2dfd1391264c = (x7af53bbecc5ccdd5)obj;
				break;
			case 170:
				flag3 = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			case 180:
				flag4 = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			case 90:
				flag5 = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			case 100:
				flag6 = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			case 80:
				flag7 = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			case 300:
				flag8 = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			case 230:
				x23baa165bca7b6ef = (string)obj;
				break;
			case 270:
				x9765a88832769f = (string)obj;
				break;
			case 235:
				x4681a4352e687cd = (string)obj;
				break;
			case 240:
				xe1755e6a97c = (string)obj;
				break;
			case 190:
				x396b77a306f83da.x437e3b626c0fdd43 = x4574ea26106f0edb.x9e20b93bb584bff2((int)obj);
				break;
			case 350:
				x396b77a306f83da.xa7229a54449aaf49 = x4574ea26106f0edb.x9e20b93bb584bff2((int)obj);
				break;
			case 200:
				x396b77a306f83da.xbe1e23e7d5b43370 = -x4574ea26106f0edb.x9e20b93bb584bff2((int)obj);
				break;
			case 160:
				x396b77a306f83da.x9b41425268471380 = x0956727ba1bf0544((x26d9ecb4bdf0456d)obj);
				break;
			case 140:
				x396b77a306f83da.x2588d8c20c42e232 = (Underline)obj;
				break;
			case 450:
				x396b77a306f83da.x36197c67d114da57 = x0956727ba1bf0544((x26d9ecb4bdf0456d)obj);
				break;
			case 130:
				x396b77a306f83da.x24385217e0d88ab8 = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			case 20:
				x396b77a306f83da.xabb599f76795ecaf = x0956727ba1bf0544((x26d9ecb4bdf0456d)obj);
				break;
			case 290:
				x396b77a306f83da.x5152a5707921c783 = xc70b6f4d051f8af4((int)obj);
				break;
			case 150:
				x396b77a306f83da.x9ba60a33bc3988dc = x4574ea26106f0edb.x370502bb60141209((int)obj);
				break;
			case 10:
				x396b77a306f83da.x17c40acbe47f16cc = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			case 265:
				x396b77a306f83da.x3a7473f820dd300b = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			case 268:
				x396b77a306f83da.x4dcd0de8fd7fe251 = obj == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
				break;
			}
		}
		xa79d032ee44aba11 xa6417f0b = (flag ? xa79d032ee44aba11.xa6417f0b87702333 : ((flag2 && xa07e86c08c3543c6) ? xa79d032ee44aba11.x3225daf421fc5451 : xa79d032ee44aba11.x4d0b9d4447ba7566));
		xc92cdbffb9d00ef3 x2fb115b47db0d = (flag3 ? xc92cdbffb9d00ef3.x8a8280480a77bc88 : (flag4 ? xc92cdbffb9d00ef3.x3db6b9a9a976176a : ((flag5 && flag6) ? xc92cdbffb9d00ef3.x80311f214b796fbe : (flag5 ? xc92cdbffb9d00ef3.x93e68a44438355fd : (flag6 ? xc92cdbffb9d00ef3.xf398ffaf32ffe055 : xc92cdbffb9d00ef3.x4d0b9d4447ba7566)))));
		x0ae5fe02c6cbfde7 xfedaa23df = (flag7 ? x0ae5fe02c6cbfde7.x63374d6ffed4adeb : (flag8 ? x0ae5fe02c6cbfde7.x94c083f2813272f4 : x0ae5fe02c6cbfde7.x4d0b9d4447ba7566));
		x396b77a306f83da.x759aa16c2016a289 = xb7dbd7bb3ed97d5b.x4a59367ba6527b94(x6f02b6a80bf6b36f, x23baa165bca7b6ef, x9765a88832769f, x4681a4352e687cd, xe1755e6a97c);
		if (!x0d299f323d241756.x5959bccb67bbf051(x396b77a306f83da.x759aa16c2016a289))
		{
			x396b77a306f83da.x759aa16c2016a289 = (string)xeedad81aaed42a76.x0095b789d636f3ae(230);
		}
		x396b77a306f83da.xfe2178c1f916f36c = fontStyle;
		x396b77a306f83da.x94a199d827e52b9b = fontStyle2;
		x396b77a306f83da.xa6417f0b87702333 = xa6417f0b;
		x396b77a306f83da.x2fb115b47db0d216 = x2fb115b47db0d;
		x396b77a306f83da.xfedaa23df3912116 = xfedaa23df;
		x396b77a306f83da.xfe2178c1f916f36c = fontStyle;
		x396b77a306f83da.x554aca059bdf6d48 = x5709acc7200773ff.x38758cbbee49e4cb(x5709acc7200773ff);
		x396b77a306f83da.x51d60f077c5fc6e0 = xc8e01097217ac9d2.x38758cbbee49e4cb(xc8e01097217ac9d);
		x396b77a306f83da.x76cdec455967c074 = x3c756aba143a9e3e;
		return x396b77a306f83da;
	}

	internal x396b77a306f83da6 x3fe6eca125045a42(Paragraph x31e6518f5e08db6c)
	{
		return x3fe6eca125045a42(x31e6518f5e08db6c, x3d3ebc31b37b2a88);
	}

	internal xdeab92faa2eb558b x654ab3515de7db76(Node xda5bf54deb817e37)
	{
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.GroupShape:
		case NodeType.Shape:
			return xbadee38b469f3633((ShapeBase)xda5bf54deb817e37, x3d3ebc31b37b2a88);
		case NodeType.DrawingML:
			return x7f9e1f83d24fd809((DrawingML)xda5bf54deb817e37, x3d3ebc31b37b2a88);
		case NodeType.OfficeMath:
			return x9b27924c34e000e5((OfficeMath)xda5bf54deb817e37, x3d3ebc31b37b2a88);
		default:
			return new xdeab92faa2eb558b(x3d3ebc31b37b2a88);
		}
	}

	internal x41ccdd7753312e4f xa238485187cc1afe(Node xda5bf54deb817e37)
	{
		return xa238485187cc1afe(xda5bf54deb817e37, x3d3ebc31b37b2a88);
	}

	internal x71a4a9bfdf7899a6 x7f16e49c9b5b8c38(Node xda5bf54deb817e37)
	{
		return x7f16e49c9b5b8c38(xda5bf54deb817e37, x3d3ebc31b37b2a88);
	}

	internal xe20e20657f464768 x52548ab50cc290b7(Row xda5bf54deb817e37)
	{
		return x52548ab50cc290b7(xda5bf54deb817e37, x3d3ebc31b37b2a88);
	}

	internal x8f0e2f0364ae18aa xc5a510a39e9d580f(Table xda5bf54deb817e37)
	{
		return xc5a510a39e9d580f(xda5bf54deb817e37, x3d3ebc31b37b2a88);
	}

	internal xacf1bb6be5092987 x9a1aaa840ab94f2c(Section xda5bf54deb817e37)
	{
		return x9a1aaa840ab94f2c(xda5bf54deb817e37, x3d3ebc31b37b2a88);
	}

	internal x5d30045af3da9a92 x6ff815c88c784807(Document xda5bf54deb817e37)
	{
		x5d30045af3da9a92 x5d30045af3da9a = x6ff815c88c784807(xda5bf54deb817e37, x3d3ebc31b37b2a88);
		x5d30045af3da9a.x16f7f1497a3e7638 = xad6d5dad910b3134();
		return x5d30045af3da9a;
	}

	private static FontStyle x659bc4263aa7ef66(x1d1dd20018fcde10 x26094932cf7a9139, x000f21cbda739311 x21a91e2ac6ef5338, bool x4aad51c9bc3ee0f3)
	{
		bool xe8c0bbd4d = !x4aad51c9bc3ee0f3 && x26094932cf7a9139.xab4229188249d97a;
		if (x21a91e2ac6ef5338 != x000f21cbda739311.xd4e922ceeed89b74)
		{
			return xa431ba72a317d707(x26094932cf7a9139.x4e1d3347e7864b81, x26094932cf7a9139.x00d0ae795109fe11);
		}
		return xa431ba72a317d707(x26094932cf7a9139.x3312403c03667693, xe8c0bbd4d);
	}

	private static FontStyle xa431ba72a317d707(bool xfb7d9aaaa3bb766b, bool xe8c0bbd4d5297920)
	{
		FontStyle fontStyle = FontStyle.Regular;
		if (xfb7d9aaaa3bb766b)
		{
			fontStyle |= FontStyle.Bold;
		}
		if (xe8c0bbd4d5297920)
		{
			fontStyle |= FontStyle.Italic;
		}
		return fontStyle;
	}

	private static x396b77a306f83da6 x3fe6eca125045a42(Paragraph x31e6518f5e08db6c, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		x396b77a306f83da6 x396b77a306f83da = new x396b77a306f83da6(x40c630e0786922f0);
		Aspose.Words.Font font = x31e6518f5e08db6c.ListLabel.Font;
		x396b77a306f83da.x759aa16c2016a289 = font.Name;
		x396b77a306f83da.x437e3b626c0fdd43 = x4574ea26106f0edb.x8d50b8a62ba1cd84(font.Size);
		x396b77a306f83da.xfe2178c1f916f36c = font.xfa47517dba72fd20;
		x396b77a306f83da.x9b41425268471380 = font.x63b1a7c31a962459;
		x396b77a306f83da.xabb599f76795ecaf = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		x396b77a306f83da.x2fb115b47db0d216 = (font.Emboss ? xc92cdbffb9d00ef3.x8a8280480a77bc88 : (font.Engrave ? xc92cdbffb9d00ef3.x3db6b9a9a976176a : xc92cdbffb9d00ef3.x4d0b9d4447ba7566));
		x396b77a306f83da.x838b2dfd1391264c = font.xf6ce0e8106e6a1d8;
		x396b77a306f83da.x2588d8c20c42e232 = font.Underline;
		x396b77a306f83da.x3a7473f820dd300b = x31e6518f5e08db6c.ParagraphFormat.Bidi;
		return x396b77a306f83da;
	}

	private static xdeab92faa2eb558b xbadee38b469f3633(ShapeBase xda5bf54deb817e37, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		xdeab92faa2eb558b xdeab92faa2eb558b = new xdeab92faa2eb558b(x40c630e0786922f0);
		xdeab92faa2eb558b.x87119342b85a2a43 = xda5bf54deb817e37.x87119342b85a2a43;
		xdeab92faa2eb558b.x2ac6c66ecbcafe54 = (bool)xda5bf54deb817e37.xf7125312c7ee115c.xfe91eeeafcb3026a(948);
		xdeab92faa2eb558b.x39043a80f49a07e2 = xdeab92faa2eb558b.x31ae04883db2d985(xda5bf54deb817e37.WrapType, xda5bf54deb817e37.ZOrder, xda5bf54deb817e37.BehindText);
		xdeab92faa2eb558b.x109e3389933c23a8 = null;
		xdeab92faa2eb558b.x109e3389933c23a8.x400dff62c6cef57f = xda5bf54deb817e37.WrapSide;
		xdeab92faa2eb558b.x109e3389933c23a8.xab6edfb47ff0b74c = xda5bf54deb817e37.WrapType;
		xdeab92faa2eb558b.x109e3389933c23a8.xab67cb9464a3325b = xda5bf54deb817e37.HorizontalAlignment;
		xdeab92faa2eb558b.x109e3389933c23a8.xf6ce0e8106e6a1d8 = xda5bf54deb817e37.VerticalAlignment;
		xdeab92faa2eb558b.x109e3389933c23a8.x0fcdf9c7f9f2eb9e = xda5bf54deb817e37.RelativeHorizontalPosition;
		xdeab92faa2eb558b.x109e3389933c23a8.x5d0ebb82ae68cc43 = xda5bf54deb817e37.RelativeVerticalPosition;
		xdeab92faa2eb558b.x109e3389933c23a8.x72d92bd1aff02e37 = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.Left);
		xdeab92faa2eb558b.x109e3389933c23a8.xe360b1885d8d4a41 = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.Top);
		xdeab92faa2eb558b.x109e3389933c23a8.xc9ee264fd8d7484e = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.DistanceLeft);
		xdeab92faa2eb558b.x109e3389933c23a8.x027754ea63804113 = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.DistanceTop);
		xdeab92faa2eb558b.x109e3389933c23a8.xb5465b18223f6375 = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.DistanceRight);
		xdeab92faa2eb558b.x109e3389933c23a8.x4dc0360afcf78834 = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.DistanceBottom);
		xdeab92faa2eb558b.x109e3389933c23a8.xed344a170caf7ac3 = xda5bf54deb817e37.AllowOverlap;
		xdeab92faa2eb558b.x109e3389933c23a8 = x8e3db3d2a7fdbd41.x38758cbbee49e4cb(xdeab92faa2eb558b.x109e3389933c23a8);
		return xdeab92faa2eb558b;
	}

	private static xdeab92faa2eb558b x7f9e1f83d24fd809(DrawingML xda5bf54deb817e37, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		xdeab92faa2eb558b xdeab92faa2eb558b = new xdeab92faa2eb558b(x40c630e0786922f0);
		xdeab92faa2eb558b.x87119342b85a2a43 = xda5bf54deb817e37.xf7125312c7ee115c.x87119342b85a2a43;
		xdeab92faa2eb558b.x39043a80f49a07e2 = xdeab92faa2eb558b.x31ae04883db2d985(xda5bf54deb817e37.xf7125312c7ee115c.xab6edfb47ff0b74c, xda5bf54deb817e37.xf7125312c7ee115c.x39043a80f49a07e2, xda5bf54deb817e37.xf7125312c7ee115c.x1242ade9edf65711);
		xdeab92faa2eb558b.x2ac6c66ecbcafe54 = false;
		xdeab92faa2eb558b.x109e3389933c23a8 = null;
		xdeab92faa2eb558b.x109e3389933c23a8.x400dff62c6cef57f = xda5bf54deb817e37.xf7125312c7ee115c.x400dff62c6cef57f;
		xdeab92faa2eb558b.x109e3389933c23a8.xab6edfb47ff0b74c = xda5bf54deb817e37.xf7125312c7ee115c.xab6edfb47ff0b74c;
		xdeab92faa2eb558b.x109e3389933c23a8.xab67cb9464a3325b = xda5bf54deb817e37.xf7125312c7ee115c.xab67cb9464a3325b;
		xdeab92faa2eb558b.x109e3389933c23a8.xf6ce0e8106e6a1d8 = xda5bf54deb817e37.xf7125312c7ee115c.xf6ce0e8106e6a1d8;
		xdeab92faa2eb558b.x109e3389933c23a8.x0fcdf9c7f9f2eb9e = xda5bf54deb817e37.xf7125312c7ee115c.x06372ab09e719f75;
		xdeab92faa2eb558b.x109e3389933c23a8.x5d0ebb82ae68cc43 = xda5bf54deb817e37.xf7125312c7ee115c.xb6a90a3cd96dc205;
		xdeab92faa2eb558b.x109e3389933c23a8.x72d92bd1aff02e37 = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.xf7125312c7ee115c.x72d92bd1aff02e37);
		xdeab92faa2eb558b.x109e3389933c23a8.xe360b1885d8d4a41 = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.xf7125312c7ee115c.xe360b1885d8d4a41);
		xdeab92faa2eb558b.x109e3389933c23a8.xc9ee264fd8d7484e = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.xc9ee264fd8d7484e);
		xdeab92faa2eb558b.x109e3389933c23a8.x027754ea63804113 = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.x027754ea63804113);
		xdeab92faa2eb558b.x109e3389933c23a8.xb5465b18223f6375 = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.xb5465b18223f6375);
		xdeab92faa2eb558b.x109e3389933c23a8.x4dc0360afcf78834 = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.x4dc0360afcf78834);
		xdeab92faa2eb558b.x109e3389933c23a8.xed344a170caf7ac3 = xda5bf54deb817e37.xed344a170caf7ac3;
		xdeab92faa2eb558b.x109e3389933c23a8 = x8e3db3d2a7fdbd41.x38758cbbee49e4cb(xdeab92faa2eb558b.x109e3389933c23a8);
		return xdeab92faa2eb558b;
	}

	private static xdeab92faa2eb558b x9b27924c34e000e5(OfficeMath xda5bf54deb817e37, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		xdeab92faa2eb558b xdeab92faa2eb558b = new xdeab92faa2eb558b(x40c630e0786922f0);
		xdeab92faa2eb558b.x109e3389933c23a8 = null;
		xdeab92faa2eb558b.x109e3389933c23a8.x400dff62c6cef57f = WrapSide.Both;
		xdeab92faa2eb558b.x109e3389933c23a8.xab6edfb47ff0b74c = WrapType.Inline;
		xdeab92faa2eb558b.x109e3389933c23a8.xab67cb9464a3325b = HorizontalAlignment.Inside;
		xdeab92faa2eb558b.x109e3389933c23a8.xf6ce0e8106e6a1d8 = VerticalAlignment.Inside;
		xdeab92faa2eb558b.x109e3389933c23a8.x0fcdf9c7f9f2eb9e = RelativeHorizontalPosition.Character;
		xdeab92faa2eb558b.x109e3389933c23a8.x5d0ebb82ae68cc43 = RelativeVerticalPosition.Line;
		xdeab92faa2eb558b.x109e3389933c23a8.x72d92bd1aff02e37 = 0;
		xdeab92faa2eb558b.x109e3389933c23a8.xe360b1885d8d4a41 = 0;
		xdeab92faa2eb558b.x109e3389933c23a8.xc9ee264fd8d7484e = 0;
		xdeab92faa2eb558b.x109e3389933c23a8.x027754ea63804113 = 0;
		xdeab92faa2eb558b.x109e3389933c23a8.xb5465b18223f6375 = 0;
		xdeab92faa2eb558b.x109e3389933c23a8.x4dc0360afcf78834 = 0;
		xdeab92faa2eb558b.x109e3389933c23a8.xed344a170caf7ac3 = false;
		return xdeab92faa2eb558b;
	}

	private static x41ccdd7753312e4f xa238485187cc1afe(Node xda5bf54deb817e37, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		x1a78664fa10a3755 x1a78664fa10a = x8474c0bc1bee33ae(xda5bf54deb817e37);
		x41ccdd7753312e4f x41ccdd7753312e4f = new x41ccdd7753312e4f(x40c630e0786922f0);
		x5709acc7200773ff x5709acc7200773ff = new x5709acc7200773ff(x40c630e0786922f0, initKey: false);
		xf2fec9a4212c9f90 xf2fec9a4212c9f = new xf2fec9a4212c9f90(x40c630e0786922f0, initKey: false);
		x41ccdd7753312e4f.x109e3389933c23a8 = null;
		int num = 0;
		int num2 = 0;
		int x66bbd7ed8c65740d = 0;
		bool flag = false;
		bool flag2 = false;
		int x4d5aabc7a55b12ba = x4574ea26106f0edb.x370502bb60141209((int)x1a78664fa10a3755.x0095b789d636f3ae(1420));
		HeightRule xe529c1588eada8b = (HeightRule)x1a78664fa10a3755.x0095b789d636f3ae(1430);
		x7f77ea92be0d9042 x7f77ea92be0d = x1a78664fa10a;
		for (int i = 0; i < x7f77ea92be0d.xd44988f225497f3a; i++)
		{
			int num3 = x7f77ea92be0d.xf15263674eb297bb(i);
			object obj = x7f77ea92be0d.x6d3720b962bd3112(i);
			if (obj == null)
			{
				continue;
			}
			switch (num3)
			{
			case 1460:
			{
				Shading shading = (Shading)obj;
				x5709acc7200773ff.x8fdbd80e8da6b0e6 = x0956727ba1bf0544(shading.xc290f60df004e384);
				x5709acc7200773ff.x83729c7ebf48ae24 = x0956727ba1bf0544(shading.x0e18178ac4b2272f);
				x5709acc7200773ff.x7b6a6d281546db99 = shading.Texture;
				x41ccdd7753312e4f.x554aca059bdf6d48 = x5709acc7200773ff.x38758cbbee49e4cb(x5709acc7200773ff);
				break;
			}
			case 1350:
			{
				Border border = (Border)obj;
				xf2fec9a4212c9f.set_xe6d4b1b411ed94b5(BorderType.Top, xc8e01097217ac9d2.x38758cbbee49e4cb(x40c630e0786922f0, (float)border.LineWidth, border.LineStyle, border.x63b1a7c31a962459, (float)border.DistanceFromText, border.Shadow, border.x227665e444fb500a));
				break;
			}
			case 1360:
			{
				Border border = (Border)obj;
				xf2fec9a4212c9f.set_xe6d4b1b411ed94b5(BorderType.Left, xc8e01097217ac9d2.x38758cbbee49e4cb(x40c630e0786922f0, (float)border.LineWidth, border.LineStyle, border.x63b1a7c31a962459, (float)border.DistanceFromText, border.Shadow, border.x227665e444fb500a));
				break;
			}
			case 1380:
			{
				Border border = (Border)obj;
				xf2fec9a4212c9f.set_xe6d4b1b411ed94b5(BorderType.Right, xc8e01097217ac9d2.x38758cbbee49e4cb(x40c630e0786922f0, (float)border.LineWidth, border.LineStyle, border.x63b1a7c31a962459, (float)border.DistanceFromText, border.Shadow, border.x227665e444fb500a));
				break;
			}
			case 1370:
			{
				Border border = (Border)obj;
				xf2fec9a4212c9f.set_xe6d4b1b411ed94b5(BorderType.Bottom, xc8e01097217ac9d2.x38758cbbee49e4cb(x40c630e0786922f0, (float)border.LineWidth, border.LineStyle, border.x63b1a7c31a962459, (float)border.DistanceFromText, border.Shadow, border.x227665e444fb500a));
				break;
			}
			case 1390:
			{
				Border border = (Border)obj;
				xf2fec9a4212c9f.set_xe6d4b1b411ed94b5(BorderType.Horizontal, xc8e01097217ac9d2.x38758cbbee49e4cb(x40c630e0786922f0, (float)border.LineWidth, border.LineStyle, border.x63b1a7c31a962459, (float)border.DistanceFromText, border.Shadow, border.x227665e444fb500a));
				break;
			}
			case 1140:
			{
				TabStopCollection tabStopCollection = (TabStopCollection)obj;
				int num6 = 0;
				for (int j = 0; j < tabStopCollection.Count; j++)
				{
					if (!tabStopCollection[j].IsClear)
					{
						num6++;
					}
				}
				int[] array = new int[num6];
				TabAlignment[] array2 = new TabAlignment[num6];
				TabLeader[] array3 = new TabLeader[num6];
				int num7 = 0;
				for (int k = 0; k < tabStopCollection.Count; k++)
				{
					TabStop tabStop = tabStopCollection[k];
					if (!tabStop.IsClear)
					{
						array[num7] = x4574ea26106f0edb.x370502bb60141209(tabStop.PositionTwips);
						array2[num7] = tabStop.Alignment;
						array3[num7] = tabStop.Leader;
						num7++;
					}
				}
				x41ccdd7753312e4f.xcda2d9a027b80cd0 = array;
				x41ccdd7753312e4f.xb367d01ee0a9434c = array2;
				x41ccdd7753312e4f.x3f2d62428d975f86 = array3;
				break;
			}
			case 1160:
				num = x4574ea26106f0edb.x370502bb60141209((int)obj);
				break;
			case 1170:
				num2 = x4574ea26106f0edb.x370502bb60141209((int)obj);
				break;
			case 1150:
				x41ccdd7753312e4f.x91e854e77522d9eb = x4574ea26106f0edb.x370502bb60141209((int)obj);
				break;
			case 1200:
				x41ccdd7753312e4f.xce7d39f89d44bc2a = x4574ea26106f0edb.x370502bb60141209((int)obj);
				break;
			case 1210:
				flag = (bool)obj;
				break;
			case 1220:
				x41ccdd7753312e4f.xdc88f9287c50d24f = x4574ea26106f0edb.x370502bb60141209((int)obj);
				break;
			case 1230:
				flag2 = (bool)obj;
				break;
			case 1650:
			{
				x84bbacdc1fc0efd2 x84bbacdc1fc0efd = (x84bbacdc1fc0efd2)obj;
				x41ccdd7753312e4f.x84bbacdc1fc0efd2 = x4574ea26106f0edb.x370502bb60141209(x84bbacdc1fc0efd.xd2f68ee6f47e9dfb);
				x41ccdd7753312e4f.x6ecc1a11cfc2c359 = x84bbacdc1fc0efd.xea9485ec61071863;
				break;
			}
			case 1020:
				x41ccdd7753312e4f.x9ba359ff37a3a63b = (ParagraphAlignment)obj;
				break;
			case 1130:
				x41ccdd7753312e4f.x7acd3f5a41203a98 = (bool)obj;
				break;
			case 1040:
				x41ccdd7753312e4f.x1534142faaf03859 = (bool)obj;
				break;
			case 1050:
				x41ccdd7753312e4f.x00a3b7ca8cc4ec27 = (bool)obj;
				break;
			case 1060:
				x41ccdd7753312e4f.xbed6d6330712f0f2 = (bool)obj;
				break;
			case 1470:
				x41ccdd7753312e4f.x6fc1588fe3156b3b = (bool)obj;
				break;
			case 1022:
				x41ccdd7753312e4f.x468afe29e35fc291 = (bool)obj;
				break;
			case 1000:
				x41ccdd7753312e4f.xf659f5b0523b44bc = (int)obj;
				break;
			case 1120:
				x41ccdd7753312e4f.x71c63f7e57f7ede5 = (int)obj;
				break;
			case 1280:
				x41ccdd7753312e4f.xdd05b9fa0fd72684 = (OutlineLevel)obj;
				break;
			case 1110:
				x66bbd7ed8c65740d = (int)obj;
				break;
			case 1292:
				x41ccdd7753312e4f.x109e3389933c23a8.x72d92bd1aff02e37 = x4574ea26106f0edb.x370502bb60141209((int)obj);
				break;
			case 1302:
				x41ccdd7753312e4f.x109e3389933c23a8.xe360b1885d8d4a41 = x4574ea26106f0edb.x370502bb60141209((int)obj);
				break;
			case 1480:
				x41ccdd7753312e4f.x109e3389933c23a8.x2c5926113e101674 = (TextOrientation)obj;
				break;
			case 1310:
				if ((int)obj <= 0)
				{
					obj = int.MinValue;
				}
				x41ccdd7753312e4f.x109e3389933c23a8.xdc1bf80853046136 = x4574ea26106f0edb.x370502bb60141209((int)obj);
				break;
			case 1420:
				x4d5aabc7a55b12ba = (int)obj;
				break;
			case 1430:
				xe529c1588eada8b = (HeightRule)obj;
				break;
			case 1500:
			{
				int num5 = x4574ea26106f0edb.x370502bb60141209((int)obj);
				x41ccdd7753312e4f.x109e3389933c23a8.xc9ee264fd8d7484e = num5;
				x41ccdd7753312e4f.x109e3389933c23a8.xb5465b18223f6375 = num5;
				break;
			}
			case 1490:
			{
				int num4 = x4574ea26106f0edb.x370502bb60141209((int)obj);
				x41ccdd7753312e4f.x109e3389933c23a8.x027754ea63804113 = num4;
				x41ccdd7753312e4f.x109e3389933c23a8.x4dc0360afcf78834 = num4;
				break;
			}
			case 1340:
				x41ccdd7753312e4f.x109e3389933c23a8.xab6edfb47ff0b74c = (WrapType)obj;
				break;
			case 1290:
				x41ccdd7753312e4f.x109e3389933c23a8.xab67cb9464a3325b = (HorizontalAlignment)obj;
				break;
			case 1320:
				x41ccdd7753312e4f.x109e3389933c23a8.x0fcdf9c7f9f2eb9e = (RelativeHorizontalPosition)obj;
				break;
			case 1300:
				x41ccdd7753312e4f.x109e3389933c23a8.xf6ce0e8106e6a1d8 = (VerticalAlignment)obj;
				break;
			case 1330:
				x41ccdd7753312e4f.x109e3389933c23a8.x5d0ebb82ae68cc43 = (RelativeVerticalPosition)obj;
				break;
			case 1070:
				x41ccdd7753312e4f.xdd32fdd03429962e = (bool)obj;
				break;
			case 1090:
				x41ccdd7753312e4f.x3e3ede4be0e2161e = (bool)obj;
				break;
			case 1080:
				x41ccdd7753312e4f.x4cd8dfaddfd72f3c = (bool)obj;
				break;
			case 1240:
				x41ccdd7753312e4f.xfa3f9506eeba503d = (bool)obj;
				break;
			case 1250:
				x41ccdd7753312e4f.x4ffde28f0399ee1b = (bool)obj;
				break;
			case 1560:
				x41ccdd7753312e4f.x3a7473f820dd300b = (bool)obj;
				break;
			case 1260:
				x41ccdd7753312e4f.x22273356df6e5e2e = (bool)obj;
				break;
			}
		}
		if (0 > num2)
		{
			num += num2;
		}
		x41ccdd7753312e4f.xc0741c7ff92cf1aa = num;
		x41ccdd7753312e4f.xc7d7e186f0ace1e0 = num2;
		if (x41ccdd7753312e4f.x71c63f7e57f7ede5 != 0)
		{
			List list = xda5bf54deb817e37.Document.Lists.x6c3daa8c787e54bf(x41ccdd7753312e4f.x71c63f7e57f7ede5);
			x41ccdd7753312e4f.x15d92fa10049d163 = list.ListLevels.x90a164d2f15bfc09(x66bbd7ed8c65740d).Alignment;
		}
		if (!xda5bf54deb817e37.x357c90b33d6bb8e6().CompatibilityOptions.DoNotUseHTMLParagraphAutoSpacing)
		{
			if (flag)
			{
				x41ccdd7753312e4f.xce7d39f89d44bc2a = -1;
			}
			if (flag2)
			{
				x41ccdd7753312e4f.xdc88f9287c50d24f = -1;
			}
		}
		x41ccdd7753312e4f.xb70a9d14469748bf = xf2fec9a4212c9f90.x38758cbbee49e4cb(xf2fec9a4212c9f);
		if (x41ccdd7753312e4f.xaadb22af27962896(x5aa7d09b258e0f23: false) != null)
		{
			if (x1a78664fa10a.x6f6877b222ed4153)
			{
				xe453cc55f3979294(x1a78664fa10a.x4b68432ebf5d5dd0, x41ccdd7753312e4f.x109e3389933c23a8);
				xc4ddc7c2f54f22c5(x41ccdd7753312e4f.x109e3389933c23a8);
				x41ccdd7753312e4f.x109e3389933c23a8.xb0f146032f47c24e = x8e3db3d2a7fdbd41.x6be2ce937644ef37(x4d5aabc7a55b12ba, xe529c1588eada8b);
				x41ccdd7753312e4f.x109e3389933c23a8.xed344a170caf7ac3 = !x1a78664fa10a.xb5e4f9909e721350;
				x41ccdd7753312e4f.x109e3389933c23a8 = x8e3db3d2a7fdbd41.x38758cbbee49e4cb(x41ccdd7753312e4f.x109e3389933c23a8);
			}
			else
			{
				x41ccdd7753312e4f.x109e3389933c23a8 = x41ccdd7753312e4f.x017043e01a3905d0;
			}
		}
		x41ccdd7753312e4f.xbe4c965c6b6ff99d = x9025ec14e6c83eaf(xda5bf54deb817e37);
		x41ccdd7753312e4f.x7fc015364b8e5a44 = x90054d933b98c606(xda5bf54deb817e37);
		return x41ccdd7753312e4f;
	}

	private static bool x90054d933b98c606(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37.NodeType != NodeType.Paragraph)
		{
			return false;
		}
		Paragraph paragraph = (Paragraph)xda5bf54deb817e37;
		for (Node node = paragraph.xfe93db1ba6e25886; node != null; node = node.xa6890a1cb2b8896e)
		{
			if (node is Inline)
			{
				xeedad81aaed42a76 xeedad81aaed42a = ((Inline)node).xeedad81aaed42a76;
				x9b28b1f7f0cc963f x9b28b1f7f0cc963f = (x9b28b1f7f0cc963f)xeedad81aaed42a.xfe91eeeafcb3026a(130);
				if (x9b28b1f7f0cc963f != x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc)
				{
					return false;
				}
			}
		}
		return true;
	}

	private static bool x9025ec14e6c83eaf(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37.ParentNode.NodeType == NodeType.StructuredDocumentTag)
		{
			return true;
		}
		if (xda5bf54deb817e37.ParentNode.NodeType != NodeType.Cell)
		{
			return false;
		}
		Cell cell = (Cell)xda5bf54deb817e37.ParentNode;
		if (cell.ParentNode.NodeType != NodeType.StructuredDocumentTag)
		{
			return cell.ParentRow.ParentNode.NodeType == NodeType.StructuredDocumentTag;
		}
		return true;
	}

	private static void xe453cc55f3979294(DropCapPosition x92de5d5c62545ff0, x8e3db3d2a7fdbd41 xdcf7b74ddd6caa25)
	{
		if (x92de5d5c62545ff0 != 0)
		{
			xdcf7b74ddd6caa25.xab67cb9464a3325b = (HorizontalAlignment)(0 - x92de5d5c62545ff0);
			xdcf7b74ddd6caa25.x0fcdf9c7f9f2eb9e = RelativeHorizontalPosition.Column;
			xdcf7b74ddd6caa25.xf6ce0e8106e6a1d8 = VerticalAlignment.None;
			xdcf7b74ddd6caa25.x5d0ebb82ae68cc43 = RelativeVerticalPosition.Paragraph;
			xdcf7b74ddd6caa25.xab6edfb47ff0b74c = WrapType.Square;
		}
	}

	private static x1a78664fa10a3755 x8474c0bc1bee33ae(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37.NodeType == NodeType.Paragraph && xda5bf54deb817e37.GetAncestor(NodeType.Comment) != null)
		{
			return new x1a78664fa10a3755();
		}
		if (xda5bf54deb817e37.NodeType != NodeType.Paragraph)
		{
			return ((Row)xda5bf54deb817e37).LastCell.LastParagraph.x2e12c5f9278ae233(xd9bc7f7e70d71e14.x2be08ba736aa04f0);
		}
		return ((Paragraph)xda5bf54deb817e37).x2e12c5f9278ae233(xd9bc7f7e70d71e14.x2be08ba736aa04f0);
	}

	private static x71a4a9bfdf7899a6 x7f16e49c9b5b8c38(Node xda5bf54deb817e37, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		Cell xc5464084edc8e = ((Paragraph)xda5bf54deb817e37).xc5464084edc8e226;
		xf8cef531dae89ea3 xf8cef531dae89ea = xc5464084edc8e.xf8cef531dae89ea3;
		x71a4a9bfdf7899a6 x71a4a9bfdf7899a = new x71a4a9bfdf7899a6(x40c630e0786922f0);
		xf2fec9a4212c9f90 xf2fec9a4212c9f = new xf2fec9a4212c9f90(x40c630e0786922f0, initKey: false);
		xedb0eb766e25e0c9 xedb0eb766e25e0c = ((Row)xda5bf54deb817e37.GetAncestor(NodeType.Row)).xedb0eb766e25e0c9;
		x7f77ea92be0d9042 x7f77ea92be0d = xf8cef531dae89ea;
		x2178f96fd84f742c(x7f77ea92be0d, 3110, xf2fec9a4212c9f, xc5464084edc8e, xedb0eb766e25e0c, new xc8e01097217ac9d2(x40c630e0786922f0, initKey: false));
		x2178f96fd84f742c(x7f77ea92be0d, 3120, xf2fec9a4212c9f, xc5464084edc8e, xedb0eb766e25e0c, new xc8e01097217ac9d2(x40c630e0786922f0, initKey: false));
		x2178f96fd84f742c(x7f77ea92be0d, 3130, xf2fec9a4212c9f, xc5464084edc8e, xedb0eb766e25e0c, new xc8e01097217ac9d2(x40c630e0786922f0, initKey: false));
		x2178f96fd84f742c(x7f77ea92be0d, 3140, xf2fec9a4212c9f, xc5464084edc8e, xedb0eb766e25e0c, new xc8e01097217ac9d2(x40c630e0786922f0, initKey: false));
		x2178f96fd84f742c(x7f77ea92be0d, 3160, xf2fec9a4212c9f, xc5464084edc8e, xedb0eb766e25e0c, new xc8e01097217ac9d2(x40c630e0786922f0, initKey: false));
		x2178f96fd84f742c(x7f77ea92be0d, 3150, xf2fec9a4212c9f, xc5464084edc8e, xedb0eb766e25e0c, new xc8e01097217ac9d2(x40c630e0786922f0, initKey: false));
		x4f8dfb2a23697573(x7f77ea92be0d, 3080, x71a4a9bfdf7899a, xedb0eb766e25e0c);
		x4f8dfb2a23697573(x7f77ea92be0d, 3070, x71a4a9bfdf7899a, xedb0eb766e25e0c);
		x4f8dfb2a23697573(x7f77ea92be0d, 3090, x71a4a9bfdf7899a, xedb0eb766e25e0c);
		x4f8dfb2a23697573(x7f77ea92be0d, 3100, x71a4a9bfdf7899a, xedb0eb766e25e0c);
		for (int i = 0; i < x7f77ea92be0d.xd44988f225497f3a; i++)
		{
			int num = x7f77ea92be0d.xf15263674eb297bb(i);
			object obj = x7f77ea92be0d.x6d3720b962bd3112(i);
			if (obj != null)
			{
				switch (num)
				{
				case 3170:
				{
					Shading shading = (Shading)obj;
					x5709acc7200773ff x5709acc7200773ff = new x5709acc7200773ff(x40c630e0786922f0, initKey: false);
					x5709acc7200773ff.x8fdbd80e8da6b0e6 = x0956727ba1bf0544(shading.xc290f60df004e384);
					x5709acc7200773ff.x83729c7ebf48ae24 = x0956727ba1bf0544(shading.x0e18178ac4b2272f);
					x5709acc7200773ff.x7b6a6d281546db99 = shading.Texture;
					x71a4a9bfdf7899a.x554aca059bdf6d48 = x5709acc7200773ff.x38758cbbee49e4cb(x5709acc7200773ff);
					break;
				}
				case 3030:
					x71a4a9bfdf7899a.xeb2fe20268ee2817 = (CellMerge)obj == CellMerge.Previous;
					break;
				case 3060:
					x71a4a9bfdf7899a.xf6ce0e8106e6a1d8 = (CellVerticalAlignment)obj;
					break;
				case 3020:
					x71a4a9bfdf7899a.x9962ec7871050cbf = xf8cef531dae89ea.xce5b83b714f11fba;
					x82c03f190fc2d649(xda5bf54deb817e37, xf8cef531dae89ea, x71a4a9bfdf7899a);
					break;
				case 3050:
					x71a4a9bfdf7899a.x2c5926113e101674 = (TextOrientation)obj;
					break;
				case 3180:
					x71a4a9bfdf7899a.xdef4a637b40503dc = (bool)obj;
					break;
				case 3220:
					x71a4a9bfdf7899a.xb95bfd90edcd1f61 = (bool)obj;
					break;
				}
			}
		}
		x71a4a9bfdf7899a.xb70a9d14469748bf = xf2fec9a4212c9f90.x38758cbbee49e4cb(xf2fec9a4212c9f);
		return x71a4a9bfdf7899a;
	}

	private static void x4f8dfb2a23697573(x7f77ea92be0d9042 xe9707cb1ec88db49, int x6a25c2c73b067e40, x71a4a9bfdf7899a6 x7d95d971d8923f4c, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		object obj = xe9707cb1ec88db49.xf7866f89640a29a3(x6a25c2c73b067e40);
		if (obj == null)
		{
			obj = xe193ceb565ecaa0a.xf7866f89640a29a3(x9b770cc931426375(x6a25c2c73b067e40));
		}
		if (obj == null)
		{
			return;
		}
		if (xe193ceb565ecaa0a.xcedf9c82728ad579)
		{
			switch (x6a25c2c73b067e40)
			{
			case 3090:
				x6a25c2c73b067e40 = 3100;
				break;
			case 3100:
				x6a25c2c73b067e40 = 3090;
				break;
			}
		}
		switch (x6a25c2c73b067e40)
		{
		case 3070:
			x7d95d971d8923f4c.xdf2361611d684889 = x4574ea26106f0edb.x370502bb60141209((int)obj);
			break;
		case 3080:
			x7d95d971d8923f4c.x425c70a737882333 = x4574ea26106f0edb.x370502bb60141209((int)obj);
			break;
		case 3090:
			x7d95d971d8923f4c.xcad2e59522947ede = x4574ea26106f0edb.x370502bb60141209((int)obj);
			break;
		case 3100:
			x7d95d971d8923f4c.x41c99cca24bc80be = x4574ea26106f0edb.x370502bb60141209((int)obj);
			break;
		}
	}

	private static void x2178f96fd84f742c(x7f77ea92be0d9042 xe9707cb1ec88db49, int x6a25c2c73b067e40, xf2fec9a4212c9f90 x7d95d971d8923f4c, Cell xe6de5e5fa2d44af5, xedb0eb766e25e0c9 xe193ceb565ecaa0a, xc8e01097217ac9d2 x5c42f375e42eecf1)
	{
		object obj = xe9707cb1ec88db49.xf7866f89640a29a3(x6a25c2c73b067e40);
		if (obj == null)
		{
			x5c42f375e42eecf1.x151ac08c86e712bc = true;
			switch (x6a25c2c73b067e40)
			{
			case 3110:
				obj = xe193ceb565ecaa0a.xfe91eeeafcb3026a(xe6de5e5fa2d44af5.ParentRow.IsFirstRow ? 4050 : 4090);
				break;
			case 3120:
				obj = xe193ceb565ecaa0a.xfe91eeeafcb3026a(xe6de5e5fa2d44af5.IsFirstCell ? 4060 : 4100);
				break;
			case 3140:
				obj = xe193ceb565ecaa0a.xfe91eeeafcb3026a(xe6de5e5fa2d44af5.IsLastCell ? 4080 : 4100);
				break;
			case 3130:
				obj = xe193ceb565ecaa0a.xfe91eeeafcb3026a(xe6de5e5fa2d44af5.ParentRow.IsLastRow ? 4070 : 4090);
				break;
			case 3200:
			case 3210:
				obj = xe193ceb565ecaa0a.xfe91eeeafcb3026a(x9b770cc931426375(x6a25c2c73b067e40));
				break;
			case 3150:
			case 3160:
				obj = xe6de5e5fa2d44af5.xf8cef531dae89ea3.xdafa1f94b023b665(x6a25c2c73b067e40);
				break;
			default:
				throw new InvalidOperationException("Unexpected cell attribute.");
			}
		}
		Border border = (Border)obj;
		x5c42f375e42eecf1.xffa1fc725bf36690 = (float)border.LineWidth;
		x5c42f375e42eecf1.x3d0571719b5893b4 = (border.x27d7528a28faeec8() ? border.LineStyle : LineStyle.None);
		x5c42f375e42eecf1.x9b41425268471380 = border.x63b1a7c31a962459;
		x5c42f375e42eecf1.x58316dde3396e982 = (float)border.DistanceFromText;
		x5c42f375e42eecf1.x0214605434693fc1 = border.Shadow;
		x5c42f375e42eecf1.x75c2a4a522094a98 = border.x227665e444fb500a;
		x7d95d971d8923f4c.set_xe6d4b1b411ed94b5(x7ef92c841286e118(x6a25c2c73b067e40, xe193ceb565ecaa0a.xcedf9c82728ad579), xc8e01097217ac9d2.x38758cbbee49e4cb(x5c42f375e42eecf1));
	}

	private static xe20e20657f464768 x52548ab50cc290b7(Row xda5bf54deb817e37, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = xda5bf54deb817e37.xedb0eb766e25e0c9;
		xe20e20657f464768 xe20e20657f = new xe20e20657f464768(x40c630e0786922f0);
		x7f77ea92be0d9042 x7f77ea92be0d = xedb0eb766e25e0c;
		xf2fec9a4212c9f90 xf2fec9a4212c9f = new xf2fec9a4212c9f90(x40c630e0786922f0, initKey: false);
		for (int i = 0; i < x7f77ea92be0d.xd44988f225497f3a; i++)
		{
			int num = x7f77ea92be0d.xf15263674eb297bb(i);
			object obj = x7f77ea92be0d.x6d3720b962bd3112(i);
			if (obj == null)
			{
				continue;
			}
			switch (num)
			{
			case 4110:
				xe20e20657f.x85e9ab4255d7e70c = (HeightRule)obj;
				break;
			case 4120:
				xe20e20657f.xb0f146032f47c24e = x4574ea26106f0edb.x370502bb60141209(xedb0eb766e25e0c.xb0f146032f47c24e);
				if (xe20e20657f.x85e9ab4255d7e70c == HeightRule.Auto)
				{
					xe20e20657f.x85e9ab4255d7e70c = HeightRule.AtLeast;
				}
				break;
			case 4010:
				xe20e20657f.x9ba359ff37a3a63b = (TableAlignment)obj;
				break;
			case 4040:
				xe20e20657f.x0f709e8a26f5dccd = (bool)obj && !xda5bf54deb817e37.ParentTable.x752cfab9af626fd5;
				break;
			case 4360:
				xe20e20657f.xdb098cac1f1c19f8 = (bool)obj && !xe20e20657f.x0f709e8a26f5dccd;
				break;
			case 4340:
				xe20e20657f.xc0741c7ff92cf1aa = x4574ea26106f0edb.x370502bb60141209((int)obj);
				break;
			case 4050:
			case 4060:
			case 4070:
			case 4080:
			case 4090:
			case 4100:
			{
				Border border = (Border)obj;
				xf2fec9a4212c9f.set_xe6d4b1b411ed94b5(x3a935b8853140ebe(num), xc8e01097217ac9d2.x38758cbbee49e4cb(x40c630e0786922f0, (float)border.LineWidth, border.LineStyle, border.x63b1a7c31a962459, (float)border.DistanceFromText, border.Shadow, border.x227665e444fb500a));
				break;
			}
			case 4520:
				xe20e20657f.x730e1848968e9290 = (bool)obj;
				break;
			}
		}
		xe20e20657f.xb70a9d14469748bf = xf2fec9a4212c9f90.x38758cbbee49e4cb(xf2fec9a4212c9f);
		return xe20e20657f;
	}

	private static x8f0e2f0364ae18aa xc5a510a39e9d580f(Table xda5bf54deb817e37, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = xda5bf54deb817e37.FirstRow.xedb0eb766e25e0c9;
		x8f0e2f0364ae18aa x8f0e2f0364ae18aa = new x8f0e2f0364ae18aa(x40c630e0786922f0);
		x8f0e2f0364ae18aa.x109e3389933c23a8 = null;
		x8f0e2f0364ae18aa.x78427d61ba29da6a = new int[0];
		x7f77ea92be0d9042 x7f77ea92be0d = xedb0eb766e25e0c;
		for (int i = 0; i < x7f77ea92be0d.xd44988f225497f3a; i++)
		{
			int num = x7f77ea92be0d.xf15263674eb297bb(i);
			object obj = x7f77ea92be0d.x6d3720b962bd3112(i);
			if (obj != null)
			{
				switch (num)
				{
				case 4340:
					x8f0e2f0364ae18aa.xc0741c7ff92cf1aa = x4574ea26106f0edb.x370502bb60141209((int)obj);
					break;
				case 4240:
					x8f0e2f0364ae18aa.xc61c6fcfb0c6e3c3 = (bool)obj;
					break;
				case 4230:
					x8f0e2f0364ae18aa.x9962ec7871050cbf = (PreferredWidth)obj;
					break;
				case 4210:
					x8f0e2f0364ae18aa.x109e3389933c23a8.xc9ee264fd8d7484e = x4574ea26106f0edb.x370502bb60141209((int)obj);
					break;
				case 4220:
					x8f0e2f0364ae18aa.x109e3389933c23a8.x027754ea63804113 = x4574ea26106f0edb.x370502bb60141209((int)obj);
					break;
				case 4270:
					x8f0e2f0364ae18aa.x109e3389933c23a8.xb5465b18223f6375 = x4574ea26106f0edb.x370502bb60141209((int)obj);
					break;
				case 4280:
					x8f0e2f0364ae18aa.x109e3389933c23a8.x4dc0360afcf78834 = x4574ea26106f0edb.x370502bb60141209((int)obj);
					break;
				case 4350:
					x8f0e2f0364ae18aa.x109e3389933c23a8.xed344a170caf7ac3 = (bool)obj;
					break;
				case 4170:
					x8f0e2f0364ae18aa.x109e3389933c23a8.x72d92bd1aff02e37 = x4574ea26106f0edb.x370502bb60141209((int)obj);
					break;
				case 4190:
					x8f0e2f0364ae18aa.x109e3389933c23a8.xe360b1885d8d4a41 = x4574ea26106f0edb.x370502bb60141209((int)obj);
					break;
				case 4180:
					x8f0e2f0364ae18aa.x109e3389933c23a8.xab67cb9464a3325b = (HorizontalAlignment)obj;
					break;
				case 4150:
					x8f0e2f0364ae18aa.x109e3389933c23a8.x0fcdf9c7f9f2eb9e = (RelativeHorizontalPosition)obj;
					break;
				case 4200:
					x8f0e2f0364ae18aa.x109e3389933c23a8.xf6ce0e8106e6a1d8 = (VerticalAlignment)obj;
					break;
				case 4160:
					x8f0e2f0364ae18aa.x109e3389933c23a8.x5d0ebb82ae68cc43 = (RelativeVerticalPosition)obj;
					break;
				case 4380:
					x8f0e2f0364ae18aa.x3a7473f820dd300b = (bool)obj;
					break;
				}
			}
		}
		x8e3db3d2a7fdbd41 x8e3db3d2a7fdbd = x8f0e2f0364ae18aa.xaadb22af27962896(x5aa7d09b258e0f23: false);
		if (x8e3db3d2a7fdbd != null)
		{
			xc4ddc7c2f54f22c5(x8e3db3d2a7fdbd);
			x8f0e2f0364ae18aa.x109e3389933c23a8 = x8e3db3d2a7fdbd41.x38758cbbee49e4cb(x8f0e2f0364ae18aa.x109e3389933c23a8);
		}
		return x8f0e2f0364ae18aa;
	}

	private static void xc4ddc7c2f54f22c5(x8e3db3d2a7fdbd41 xdcf7b74ddd6caa25)
	{
		if (xdcf7b74ddd6caa25 != null)
		{
			switch (xdcf7b74ddd6caa25.xab6edfb47ff0b74c)
			{
			case WrapType.None:
				xdcf7b74ddd6caa25.xab6edfb47ff0b74c = WrapType.TopBottom;
				break;
			case WrapType.Inline:
				xdcf7b74ddd6caa25.xab6edfb47ff0b74c = WrapType.Square;
				break;
			}
		}
	}

	private static xacf1bb6be5092987 x9a1aaa840ab94f2c(Section xda5bf54deb817e37, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		xdade2366eaa6f915 xdade2366eaa6f = xda5bf54deb817e37.Document.xdade2366eaa6f915;
		xfc72d4c9b765cad7 xfc72d4c9b765cad = xda5bf54deb817e37.xfc72d4c9b765cad7;
		xacf1bb6be5092987 xacf1bb6be = new xacf1bb6be5092987(x40c630e0786922f0);
		int num = xfc72d4c9b765cad.x6e1eb96b81362ebc;
		if (num == 0)
		{
			num = 1;
		}
		int[] array = new int[num];
		int[] array2 = new int[num];
		if (xfc72d4c9b765cad.x49ddd5238a18b5b1)
		{
			for (int i = 0; i < num; i++)
			{
				array2[i] = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.xa79be739e56e9dde);
			}
			int num2 = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.x3114e27f80122981 - xfc72d4c9b765cad.xc8a7b7ce5c5279ee - xfc72d4c9b765cad.x3fa6fa3075fd558f - (xdade2366eaa6f.xee2d3f1f4ca2502d ? xfc72d4c9b765cad.x22f21a828a652fc4 : 0) - (num - 1) * xfc72d4c9b765cad.xa79be739e56e9dde);
			int num3 = num2 / num;
			for (int j = 0; j < num; j++)
			{
				array[j] = num3;
			}
			num3 = num2 - num3 * num;
			for (int k = 0; k < num3; k++)
			{
				array[k]++;
			}
		}
		else
		{
			for (int l = 0; l < num; l++)
			{
				array2[l] = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.xbd7bb54d8760ed0a.get_xe6d4b1b411ed94b5(l).xbe8b68828bd16a4b);
			}
			for (int m = 0; m < num; m++)
			{
				array[m] = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.xbd7bb54d8760ed0a.get_xe6d4b1b411ed94b5(m).x7219de950d4b708a);
			}
		}
		xacf1bb6be.xe95664527db59e6e = xfc72d4c9b765cad.xe95664527db59e6e;
		xacf1bb6be.x3114e27f80122981 = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.x3114e27f80122981);
		xacf1bb6be.x995a78d99ada0d0c = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.x995a78d99ada0d0c);
		xacf1bb6be.xb81f492cce31314c = xda5bf54deb817e37.PageSetup.xb81f492cce31314c;
		xacf1bb6be.xc8a7b7ce5c5279ee = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.xc8a7b7ce5c5279ee);
		xacf1bb6be.x3fa6fa3075fd558f = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.x3fa6fa3075fd558f);
		xacf1bb6be.xc07fe3840d9e6d76 = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.xc07fe3840d9e6d76);
		xacf1bb6be.x65011a5ae8c64a43 = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.x65011a5ae8c64a43);
		xacf1bb6be.x2cdd18500759ef24 = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.x2cdd18500759ef24);
		xacf1bb6be.x9c94a32b8fac5210 = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.x9c94a32b8fac5210);
		xacf1bb6be.xdd217215207b7605 = xfc72d4c9b765cad.x49ddd5238a18b5b1;
		xacf1bb6be.x978429452a26becd = xfc72d4c9b765cad.xa7b942134f68467f;
		xacf1bb6be.x78427d61ba29da6a = array;
		xacf1bb6be.x0d71ce357d91dc77 = array2;
		xacf1bb6be.xa46d60033c09b60d = xfc72d4c9b765cad.x3e6533cdb8036bea;
		xacf1bb6be.x22f21a828a652fc4 = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.x22f21a828a652fc4);
		xacf1bb6be.xf85b71efe0848609 = xfc72d4c9b765cad.xf85b71efe0848609;
		xacf1bb6be.x5ce93b65ae6f48bb = xfc72d4c9b765cad.x5ce93b65ae6f48bb;
		xacf1bb6be.x49d44bef63eee32a = xfc72d4c9b765cad.x3872b32c0b6be65a;
		xacf1bb6be.xea80bd18e8a43904 = x931c6a21da3871e7(xfc72d4c9b765cad.xea80bd18e8a43904, xfc72d4c9b765cad.x464e144455d016ba, xfc72d4c9b765cad.xe95664527db59e6e);
		xacf1bb6be.xd8dd413f3526822a = xfc72d4c9b765cad.xd8dd413f3526822a;
		xacf1bb6be.x781c87b545573ab1 = xfc72d4c9b765cad.x781c87b545573ab1;
		xacf1bb6be.x2c5926113e101674 = xfc72d4c9b765cad.x2c5926113e101674;
		xacf1bb6be.x68f66930d0ba42cc = xfc72d4c9b765cad.x68f66930d0ba42cc;
		xacf1bb6be.x5c85cf93a4f7077b = xfc72d4c9b765cad.x5c85cf93a4f7077b;
		xacf1bb6be.x33683704df16e3dc = xfc72d4c9b765cad.x33683704df16e3dc;
		xacf1bb6be.xf6ce0e8106e6a1d8 = xfc72d4c9b765cad.xf6ce0e8106e6a1d8;
		xacf1bb6be.xdc363bd6e5544a03 = xfc72d4c9b765cad.xdc363bd6e5544a03;
		xacf1bb6be.x33678aed4fb5e764 = x4574ea26106f0edb.x370502bb60141209(xfc72d4c9b765cad.x33678aed4fb5e764);
		xacf1bb6be.xd9248a16053b5d85 = xfc72d4c9b765cad.xd9248a16053b5d85;
		xacf1bb6be.x2d48be5358bac023 = xfc72d4c9b765cad.x7b797cd6c7127c37;
		xacf1bb6be.x670f34a544b33166 = xfc72d4c9b765cad.xa2d3a159a0662e16;
		xacf1bb6be.x1f4dededb9314c98 = xfc72d4c9b765cad.x991da6939dc12ae1;
		FootnoteOptions endnoteOptions = xda5bf54deb817e37.PageSetup.EndnoteOptions;
		xacf1bb6be.x94dc95e25ff99314 = endnoteOptions.Location;
		xacf1bb6be.x0b588f8c055fc2c0 = endnoteOptions.RestartRule;
		xacf1bb6be.x668b67a105558a3f = endnoteOptions.NumberStyle;
		xacf1bb6be.x7a473c50b490c1c8 = endnoteOptions.StartNumber;
		int xeae841520367cd = xfc72d4c9b765cad.xeae841520367cd95;
		xacf1bb6be.xeae841520367cd95 = ((xeae841520367cd == 0) ? x4574ea26106f0edb.x8d50b8a62ba1cd84(9.0) : x4574ea26106f0edb.x370502bb60141209(xeae841520367cd));
		xf2fec9a4212c9f90 xf2fec9a4212c9f = new xf2fec9a4212c9f90(x40c630e0786922f0, initKey: false);
		if (xfc72d4c9b765cad.xaea087ab32102492 != null)
		{
			xf2fec9a4212c9f.set_xe6d4b1b411ed94b5(BorderType.Left, xc8e01097217ac9d2.x38758cbbee49e4cb(x40c630e0786922f0, (float)xfc72d4c9b765cad.xaea087ab32102492.LineWidth, xfc72d4c9b765cad.xaea087ab32102492.LineStyle, xfc72d4c9b765cad.xaea087ab32102492.x63b1a7c31a962459, (float)xfc72d4c9b765cad.xaea087ab32102492.DistanceFromText, xfc72d4c9b765cad.xaea087ab32102492.Shadow, xfc72d4c9b765cad.xaea087ab32102492.x227665e444fb500a));
		}
		if (xfc72d4c9b765cad.xa8c2637cc4888928 != null)
		{
			xf2fec9a4212c9f.set_xe6d4b1b411ed94b5(BorderType.Top, xc8e01097217ac9d2.x38758cbbee49e4cb(x40c630e0786922f0, (float)xfc72d4c9b765cad.xa8c2637cc4888928.LineWidth, xfc72d4c9b765cad.xa8c2637cc4888928.LineStyle, xfc72d4c9b765cad.xa8c2637cc4888928.x63b1a7c31a962459, (float)xfc72d4c9b765cad.xa8c2637cc4888928.DistanceFromText, xfc72d4c9b765cad.xa8c2637cc4888928.Shadow, xfc72d4c9b765cad.xa8c2637cc4888928.x227665e444fb500a));
		}
		if (xfc72d4c9b765cad.xd7a21e27974f626c != null)
		{
			xf2fec9a4212c9f.set_xe6d4b1b411ed94b5(BorderType.Right, xc8e01097217ac9d2.x38758cbbee49e4cb(x40c630e0786922f0, (float)xfc72d4c9b765cad.xd7a21e27974f626c.LineWidth, xfc72d4c9b765cad.xd7a21e27974f626c.LineStyle, xfc72d4c9b765cad.xd7a21e27974f626c.x63b1a7c31a962459, (float)xfc72d4c9b765cad.xd7a21e27974f626c.DistanceFromText, xfc72d4c9b765cad.xd7a21e27974f626c.Shadow, xfc72d4c9b765cad.xd7a21e27974f626c.x227665e444fb500a));
		}
		if (xfc72d4c9b765cad.x79d902473861f242 != null)
		{
			xf2fec9a4212c9f.set_xe6d4b1b411ed94b5(BorderType.Bottom, xc8e01097217ac9d2.x38758cbbee49e4cb(x40c630e0786922f0, (float)xfc72d4c9b765cad.x79d902473861f242.LineWidth, xfc72d4c9b765cad.x79d902473861f242.LineStyle, xfc72d4c9b765cad.x79d902473861f242.x63b1a7c31a962459, (float)xfc72d4c9b765cad.x79d902473861f242.DistanceFromText, xfc72d4c9b765cad.x79d902473861f242.Shadow, xfc72d4c9b765cad.x79d902473861f242.x227665e444fb500a));
		}
		xacf1bb6be.xb70a9d14469748bf = xf2fec9a4212c9f90.x38758cbbee49e4cb(xf2fec9a4212c9f);
		xacf1bb6be.x3a7473f820dd300b = xfc72d4c9b765cad.xcedf9c82728ad579;
		xacf1bb6be.x279db1ca1dc68028 = xfc72d4c9b765cad.xb75aad590c480869;
		return xacf1bb6be;
	}

	private static int x931c6a21da3871e7(int x7f30cdb912c8b96d, bool x05d386c08f786ef6, SectionStart x87221e340ea6bd08)
	{
		int num = (x05d386c08f786ef6 ? x7f30cdb912c8b96d : (-1));
		if (x05d386c08f786ef6 && ((x87221e340ea6bd08 == SectionStart.OddPage && !x0d299f323d241756.x7e32f71c3f39b6bc(x7f30cdb912c8b96d)) || (x87221e340ea6bd08 == SectionStart.EvenPage && x0d299f323d241756.x7e32f71c3f39b6bc(x7f30cdb912c8b96d))))
		{
			num++;
		}
		return num;
	}

	private static x5d30045af3da9a92 x6ff815c88c784807(Document xda5bf54deb817e37, x17dcbf5fe3c0d2d2 x40c630e0786922f0)
	{
		x5d30045af3da9a92 x5d30045af3da9a = new x5d30045af3da9a92(x40c630e0786922f0);
		x5d30045af3da9a.x4955f22a507bfed8 = x4574ea26106f0edb.x8d50b8a62ba1cd84(xda5bf54deb817e37.DefaultTabStop);
		x5d30045af3da9a.x346862da73e345ee = !xda5bf54deb817e37.CompatibilityOptions.NoColumnBalance;
		x5d30045af3da9a.x560b84280898ddf3 = !xda5bf54deb817e37.xdade2366eaa6f915.x636013cbf60f10b8;
		x5d30045af3da9a.xd14b1d79b2ed7c17 = !xda5bf54deb817e37.xdade2366eaa6f915.x8af0b297a9d474ad;
		x5d30045af3da9a.x1b0b470b47c0d859 = xda5bf54deb817e37.xdade2366eaa6f915.x5ac0ad056c3fce83;
		x5d30045af3da9a.xed289fa06fb7362c = xda5bf54deb817e37.xdade2366eaa6f915.xee2d3f1f4ca2502d;
		x5d30045af3da9a.x43c3a2f12150cda0 = xda5bf54deb817e37.xdade2366eaa6f915.xd02fc99dc9c3221e;
		x5d30045af3da9a.xe282e10565485d24 = xda5bf54deb817e37.xdade2366eaa6f915.xe322902ca0e695f5.SplitPgBreakAndParaMark;
		x5d30045af3da9a.x14dac37d0479fbd0 = xda5bf54deb817e37.xdade2366eaa6f915.xe322902ca0e695f5.DoNotUseIndentAsNumberingTabStop;
		x5d30045af3da9a.x6ec2044f6ed20a6b = !xda5bf54deb817e37.CompatibilityOptions.DoNotUseHTMLParagraphAutoSpacing;
		x5d30045af3da9a.x0a9d561d243e8484 = xda5bf54deb817e37.CompatibilityOptions.FootnoteLayoutLikeWW8;
		x5d30045af3da9a.xe3317f2b441ead28 = xda5bf54deb817e37.CompatibilityOptions.UlTrailSpace;
		x5d30045af3da9a.xfc71ac47a3606511 = xda5bf54deb817e37.xdade2366eaa6f915.xfc71ac47a3606511;
		x5d30045af3da9a.x466141be69711980 = xda5bf54deb817e37.xdade2366eaa6f915.x466141be69711980;
		x5d30045af3da9a.x5478764877a094bc = xda5bf54deb817e37.xdade2366eaa6f915.x5478764877a094bc;
		x5d30045af3da9a.xc3f1f7f38873ce2d = xda5bf54deb817e37.CompatibilityOptions.AdjustLineHeightInTable;
		x5d30045af3da9a.xbc841acfecc8b0b8 = xda5bf54deb817e37.CompatibilityOptions.UICompat97To2003 || x61115af0e2fd71d4(xda5bf54deb817e37.OriginalLoadFormat);
		x5d30045af3da9a.xbdfb47a8b2b25dd9 = xda5bf54deb817e37.CompatibilityOptions.AlignTablesRowByRow;
		x5d30045af3da9a.x015616f0fde5275b = xda5bf54deb817e37.CompatibilityOptions.NoLeading;
		x5d30045af3da9a.x43adcc355245fa8f = xda5bf54deb817e37.CompatibilityOptions.DoNotVertAlignCellWithSp;
		x5d30045af3da9a.x2693e486caf7aab3 = xda5bf54deb817e37.CompatibilityOptions.DoNotExpandShiftReturn;
		x5d30045af3da9a.x2108b2852d4611f3 = xda5bf54deb817e37.CompatibilityOptions.DoNotBreakWrappedTables;
		return x5d30045af3da9a;
	}

	private static bool x61115af0e2fd71d4(LoadFormat x5786461d089b10a0)
	{
		switch (x5786461d089b10a0)
		{
		case LoadFormat.Doc:
		case LoadFormat.Dot:
		case LoadFormat.DocPreWord97:
		case LoadFormat.WordML:
			return true;
		default:
			return false;
		}
	}

	private x396b77a306f83da6 xad6d5dad910b3134()
	{
		xeedad81aaed42a76 x50a18ad2656e = xd1424e1a0bb4a72b.Styles[StyleIdentifier.Normal].x856218fd0771d379(xecac24b19ed3a2b7.x87415330d9d0754a);
		return x8b0f145539d078d0(x50a18ad2656e, x000f21cbda739311.x175297738c8b8d1e, xa07e86c08c3543c6: false, x3d3ebc31b37b2a88, xd1424e1a0bb4a72b.FontInfos.x26ee10d60756aeab);
	}

	private string x72079054369f6e84(string x9e9070c6c983bbc0)
	{
		object obj = x8827bdf0b91a759c[x9e9070c6c983bbc0];
		if (obj != null)
		{
			return (string)obj;
		}
		return "";
	}

	private static x26d9ecb4bdf0456d x0956727ba1bf0544(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		if (x6c50a99faab7d741.x7149c962c02931b3)
		{
			return x6c50a99faab7d741;
		}
		if (x6c50a99faab7d741.xda71bf6f7c07c3bc == 0)
		{
			return new x26d9ecb4bdf0456d(255, x6c50a99faab7d741.xc613adc4330033f3, x6c50a99faab7d741.x26463655896fd90a, x6c50a99faab7d741.x8e8f6cc6a0756b05);
		}
		return x6c50a99faab7d741;
	}

	private static int xc70b6f4d051f8af4(int x03075be1e62b75bf)
	{
		if (x03075be1e62b75bf > 0 && x03075be1e62b75bf <= 600)
		{
			return x03075be1e62b75bf;
		}
		return 100;
	}

	private static xeedad81aaed42a76 xf9e671be87a829f7(Node xda5bf54deb817e37, bool x739ade918e4c3a5d)
	{
		xecac24b19ed3a2b7 xecac24b19ed3a2b = xecac24b19ed3a2b7.xb7ae55095fddecd9;
		if (x739ade918e4c3a5d)
		{
			xecac24b19ed3a2b |= xecac24b19ed3a2b7.xe66fef78f14a2a91;
		}
		xeedad81aaed42a76 xeedad81aaed42a = null;
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.Paragraph:
		{
			Paragraph paragraph = (Paragraph)xda5bf54deb817e37;
			xeedad81aaed42a = paragraph.x3a7e67268c1cb407(xecac24b19ed3a2b);
			break;
		}
		case NodeType.Row:
		{
			Row row = (Row)xda5bf54deb817e37;
			xeedad81aaed42a = row.LastCell.LastParagraph.x3a7e67268c1cb407(xecac24b19ed3a2b);
			break;
		}
		case NodeType.GroupShape:
		case NodeType.Shape:
		{
			ShapeBase xda5bf54deb817e38 = (ShapeBase)xda5bf54deb817e37;
			xeedad81aaed42a = x684b09378db148f4.x856218fd0771d379(xda5bf54deb817e38, xecac24b19ed3a2b);
			break;
		}
		default:
			if (xda5bf54deb817e37 is Footnote)
			{
				xeedad81aaed42a = x684b09378db148f4.x856218fd0771d379((Footnote)xda5bf54deb817e37, xecac24b19ed3a2b);
			}
			else if (xda5bf54deb817e37 is Inline)
			{
				xeedad81aaed42a = x684b09378db148f4.x856218fd0771d379((Inline)xda5bf54deb817e37, xecac24b19ed3a2b);
			}
			break;
		}
		if (xeedad81aaed42a == null)
		{
			xeedad81aaed42a = new xeedad81aaed42a76();
		}
		return xeedad81aaed42a;
	}

	private static void x82c03f190fc2d649(Node xda5bf54deb817e37, xf8cef531dae89ea3 x50a18ad2656e7181, x71a4a9bfdf7899a6 x94aec03cf2ae750b)
	{
		if (x94aec03cf2ae750b.x9962ec7871050cbf.xa72bf798a679c0aa)
		{
			Row row = null;
			switch (xda5bf54deb817e37.NodeType)
			{
			case NodeType.Row:
				row = (Row)xda5bf54deb817e37.xdfa6ecc6f742f086.xfe93db1ba6e25886;
				break;
			case NodeType.Paragraph:
				row = (Row)xda5bf54deb817e37.xdfa6ecc6f742f086.xdfa6ecc6f742f086.xdfa6ecc6f742f086.xfe93db1ba6e25886;
				break;
			}
			if (!row.xedb0eb766e25e0c9.x292ab95da92a6344 && 0 < x50a18ad2656e7181.xdc1bf80853046136)
			{
				x94aec03cf2ae750b.x9962ec7871050cbf = PreferredWidth.xf6bcf515ffcb5cc9(x50a18ad2656e7181.xdc1bf80853046136);
			}
		}
	}

	private static int x9b770cc931426375(int x6a25c2c73b067e40)
	{
		return x6a25c2c73b067e40 switch
		{
			3070 => 4300, 
			3080 => 4310, 
			3090 => 4020, 
			3100 => 4320, 
			3110 => 4050, 
			3120 => 4060, 
			3130 => 4070, 
			3140 => 4080, 
			3200 => 4090, 
			3210 => 4100, 
			_ => throw new InvalidOperationException("Unexpected cell attribute."), 
		};
	}

	private static BorderType x7ef92c841286e118(int x6a25c2c73b067e40, bool x66dea64b67a0bcb8)
	{
		switch (x6a25c2c73b067e40)
		{
		case 3110:
			return BorderType.Top;
		case 3120:
			if (!x66dea64b67a0bcb8)
			{
				return BorderType.Left;
			}
			return BorderType.Right;
		case 3140:
			if (!x66dea64b67a0bcb8)
			{
				return BorderType.Right;
			}
			return BorderType.Left;
		case 3130:
			return BorderType.Bottom;
		case 3200:
			return BorderType.Horizontal;
		case 3210:
			return BorderType.Vertical;
		case 3160:
			return BorderType.DiagonalUp;
		case 3150:
			return BorderType.DiagonalDown;
		default:
			throw new InvalidOperationException("Unexpected cell attribute.");
		}
	}

	private static BorderType x3a935b8853140ebe(int x8a876f92eb7549b4)
	{
		return x8a876f92eb7549b4 switch
		{
			4060 => BorderType.Left, 
			4050 => BorderType.Top, 
			4080 => BorderType.Right, 
			4070 => BorderType.Bottom, 
			4090 => BorderType.Horizontal, 
			4100 => BorderType.Vertical, 
			_ => throw new InvalidOperationException("Unexpected table attribute."), 
		};
	}
}
