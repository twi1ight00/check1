using Aspose.Words;
using Aspose.Words.Fonts;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x7c4557e104065fc9;

internal class x69e8b423c22edb61
{
	internal const double x08b900d130c504be = 2.0 / 3.0;

	private x69e8b423c22edb61()
	{
	}

	internal static void xff280c75a0537411(string xa7505a15e36bfe1e, Font x26094932cf7a9139, bool x032ab0a06188d97e)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xa7505a15e36bfe1e))
		{
			xff280c75a0537411(new xa3fc7dcdc8182ff6(xa7505a15e36bfe1e), x26094932cf7a9139, x032ab0a06188d97e);
		}
	}

	internal static void xff280c75a0537411(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, Font x26094932cf7a9139, bool x032ab0a06188d97e)
	{
		x30ff4cedcf2b2374.xc97a923bf27b32e0(x44ecfea61c937b8e, x26094932cf7a9139.Border);
		for (int i = 0; i < x44ecfea61c937b8e.xd44988f225497f3a; i++)
		{
			string x250224921a47c2f = x44ecfea61c937b8e.xf15263674eb297bb(i);
			xedac08b4826d3056 xf9eaf76facf8149b = x44ecfea61c937b8e.get_xe6d4b1b411ed94b5(i);
			x5a52fedde6c0a805(x250224921a47c2f, xf9eaf76facf8149b, x26094932cf7a9139);
		}
		if (!x032ab0a06188d97e || x26094932cf7a9139.xf6ce0e8106e6a1d8 == x7af53bbecc5ccdd5.x139412b8dea2f02b)
		{
			return;
		}
		xedac08b4826d3056 xedac08b4826d = x44ecfea61c937b8e.get_xe6d4b1b411ed94b5("font-size");
		if (xedac08b4826d != null)
		{
			double num = xedac08b4826d.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			if (num != 0.0)
			{
				x26094932cf7a9139.Size = num / (2.0 / 3.0) + 0.25;
			}
		}
	}

	private static void x5a52fedde6c0a805(string x250224921a47c2f5, xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		switch (x250224921a47c2f5)
		{
		case "direction":
			x26094932cf7a9139.Bidi = x495fdb45f3d92b70.x3732023a3d3acbf8(xf9eaf76facf8149b.x48112399d54b30c7(), xf0e1f8c39ee2c6f7: false);
			break;
		case "font":
			xb7278dbedcad6899(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		case "font-family":
			x0686eeaf57d74e7e(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		case "font-size":
			x4a55db781eefbdfe(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		case "font-weight":
			x37a87a122f09995e(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		case "font-style":
			x6c7fb3c9938f17fa(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		case "font-variant":
			x37929821ed8cb563(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		case "text-transform":
			x243aa55d33568610(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		case "text-decoration":
			x0112a2627fa988ac(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		case "letter-spacing":
			x634a4d5dbd242f31(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		case "vertical-align":
			xf85831351d8da5b6(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		case "color":
			x722b70a5a6410b8c(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		case "display":
			x306843c4a5fd8f34(xf9eaf76facf8149b, x26094932cf7a9139);
			break;
		default:
			x4ce5248b91d2fbf7.x6392b9ac6bc562f4(x250224921a47c2f5, xf9eaf76facf8149b, x26094932cf7a9139.Shading);
			break;
		}
	}

	private static void xb7278dbedcad6899(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		x0a4437fb7b6e1adb x0a4437fb7b6e1adb = xf9eaf76facf8149b.xae38dac157c088d7();
		if (x46cd1c4c3eb50955(x0a4437fb7b6e1adb.get_xe6d4b1b411ed94b5(0), x26094932cf7a9139))
		{
			return;
		}
		int num = 0;
		while (num < x0a4437fb7b6e1adb.Count)
		{
			xedac08b4826d3056 xf9eaf76facf8149b2 = x0a4437fb7b6e1adb.get_xe6d4b1b411ed94b5(num);
			num++;
			if (!x6c7fb3c9938f17fa(xf9eaf76facf8149b2, x26094932cf7a9139) && !x37929821ed8cb563(xf9eaf76facf8149b2, x26094932cf7a9139) && !x37a87a122f09995e(xf9eaf76facf8149b2, x26094932cf7a9139))
			{
				x4a55db781eefbdfe(xf9eaf76facf8149b2, x26094932cf7a9139);
				break;
			}
		}
		if (num < x0a4437fb7b6e1adb.Count && x731c65aac93be017(x0a4437fb7b6e1adb.get_xe6d4b1b411ed94b5(num), x26094932cf7a9139))
		{
			num++;
		}
		if (num < x0a4437fb7b6e1adb.Count)
		{
			x0686eeaf57d74e7e(x0a4437fb7b6e1adb.get_xe6d4b1b411ed94b5(num), x26094932cf7a9139);
		}
	}

	private static bool x46cd1c4c3eb50955(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		if (xf9eaf76facf8149b.x73cad9ab753bf0fa == x1e40528755c1f053.x1dd2250c6e384ef7)
		{
			string x19218ffab70283ef = xf9eaf76facf8149b.x48112399d54b30c7();
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "caption"))
			{
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "icon"))
			{
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "menu"))
			{
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "message-box"))
			{
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "small-caption"))
			{
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "status-bar"))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool x6c7fb3c9938f17fa(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		if (xf9eaf76facf8149b.x73cad9ab753bf0fa == x1e40528755c1f053.x1dd2250c6e384ef7)
		{
			string x19218ffab70283ef = xf9eaf76facf8149b.x48112399d54b30c7();
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "normal"))
			{
				x26094932cf7a9139.Italic = false;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "italic"))
			{
				x26094932cf7a9139.Italic = true;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "oblique"))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool x37929821ed8cb563(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		if (xf9eaf76facf8149b.x73cad9ab753bf0fa == x1e40528755c1f053.x1dd2250c6e384ef7)
		{
			string x19218ffab70283ef = xf9eaf76facf8149b.x48112399d54b30c7();
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "normal"))
			{
				x26094932cf7a9139.SmallCaps = false;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "small-caps"))
			{
				x26094932cf7a9139.SmallCaps = true;
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool x37a87a122f09995e(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		switch (xf9eaf76facf8149b.x73cad9ab753bf0fa)
		{
		case x1e40528755c1f053.x1dd2250c6e384ef7:
		{
			string x19218ffab70283ef = xf9eaf76facf8149b.x48112399d54b30c7();
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "normal"))
			{
				x26094932cf7a9139.Bold = false;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "bold"))
			{
				x26094932cf7a9139.Bold = true;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "bolder"))
			{
				x26094932cf7a9139.Bold = true;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "lighter"))
			{
				x26094932cf7a9139.Bold = false;
				return true;
			}
			return false;
		}
		case x1e40528755c1f053.x8c0d22e4c133799d:
		{
			int num = (int)xf9eaf76facf8149b.x043aafba68f5c559();
			if (num >= 100 && num <= 900 && num / 100 * 100 == num)
			{
				x26094932cf7a9139.Bold = num >= 700;
				return true;
			}
			return false;
		}
		default:
			return false;
		}
	}

	private static bool x4a55db781eefbdfe(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		switch (xf9eaf76facf8149b.x73cad9ab753bf0fa)
		{
		case x1e40528755c1f053.x8c0d22e4c133799d:
		case x1e40528755c1f053.x1be93eed8950d961:
		{
			double num = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			if (num >= 0.0)
			{
				x26094932cf7a9139.Size = num;
			}
			return true;
		}
		case x1e40528755c1f053.x2f7951fa0946af7e:
			return true;
		case x1e40528755c1f053.x1dd2250c6e384ef7:
		case x1e40528755c1f053.x4a498a651d07aefe:
		{
			string x19218ffab70283ef = xf9eaf76facf8149b.x48112399d54b30c7();
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "xx-small"))
			{
				x26094932cf7a9139.Size = 7.5;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "x-small"))
			{
				x26094932cf7a9139.Size = 10.0;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "small"))
			{
				x26094932cf7a9139.Size = 12.0;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "medium"))
			{
				x26094932cf7a9139.Size = 13.5;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "large"))
			{
				x26094932cf7a9139.Size = 18.0;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "x-large"))
			{
				x26094932cf7a9139.Size = 24.0;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "xx-large"))
			{
				x26094932cf7a9139.Size = 36.0;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "larger"))
			{
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "smaller"))
			{
				return true;
			}
			return false;
		}
		default:
			return false;
		}
	}

	private static bool x731c65aac93be017(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		switch (xf9eaf76facf8149b.x73cad9ab753bf0fa)
		{
		case x1e40528755c1f053.x1dd2250c6e384ef7:
			return x0d299f323d241756.x90637a473b1ceaaa(xf9eaf76facf8149b.x48112399d54b30c7(), "normal");
		case x1e40528755c1f053.x8c0d22e4c133799d:
		case x1e40528755c1f053.x1be93eed8950d961:
		case x1e40528755c1f053.x2f7951fa0946af7e:
			return true;
		default:
			return false;
		}
	}

	private static void x0686eeaf57d74e7e(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		switch (xf9eaf76facf8149b.x73cad9ab753bf0fa)
		{
		case x1e40528755c1f053.xf8569aac1192e1a0:
		case x1e40528755c1f053.xe50ab9ba6636a13d:
		{
			x0a4437fb7b6e1adb x0a4437fb7b6e1adb = xf9eaf76facf8149b.xae38dac157c088d7();
			x0686eeaf57d74e7e(x0a4437fb7b6e1adb.get_xe6d4b1b411ed94b5(0), x26094932cf7a9139);
			break;
		}
		case x1e40528755c1f053.x1dd2250c6e384ef7:
		case x1e40528755c1f053.x4a498a651d07aefe:
		{
			string text = xf9eaf76facf8149b.x48112399d54b30c7();
			if (text.Length != 0)
			{
				x26094932cf7a9139.Name = x7d93453c3bc8679b(text);
			}
			break;
		}
		}
	}

	private static string x7d93453c3bc8679b(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111.ToLower() switch
		{
			"serif" => "Times New Roman", 
			"sans-serif" => "Arial", 
			"cursive" => "Comic Sans MS", 
			"fantasy" => "Arial", 
			"monospace" => "Courier New", 
			_ => xbcea506a33cf9111, 
		};
	}

	private static void x0112a2627fa988ac(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		x0a4437fb7b6e1adb x0a4437fb7b6e1adb = xf9eaf76facf8149b.xae38dac157c088d7();
		foreach (xedac08b4826d3056 item in x0a4437fb7b6e1adb)
		{
			string x19218ffab70283ef = item.x48112399d54b30c7();
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "underline"))
			{
				x26094932cf7a9139.Underline = Underline.Single;
			}
			else if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "overline"))
			{
				x26094932cf7a9139.Underline = Underline.Single;
			}
			else if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "line-through"))
			{
				x26094932cf7a9139.StrikeThrough = true;
			}
			else if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "none"))
			{
				x26094932cf7a9139.Underline = Underline.None;
				x26094932cf7a9139.StrikeThrough = false;
				break;
			}
		}
	}

	private static void x243aa55d33568610(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		x26094932cf7a9139.AllCaps = x0d299f323d241756.x90637a473b1ceaaa(xf9eaf76facf8149b.x48112399d54b30c7(), "uppercase");
	}

	private static void x634a4d5dbd242f31(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		switch (xf9eaf76facf8149b.x73cad9ab753bf0fa)
		{
		case x1e40528755c1f053.x8c0d22e4c133799d:
		case x1e40528755c1f053.x1be93eed8950d961:
			x26094932cf7a9139.Spacing = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			break;
		case x1e40528755c1f053.x1dd2250c6e384ef7:
			if (x0d299f323d241756.x90637a473b1ceaaa(xf9eaf76facf8149b.x48112399d54b30c7(), "normal"))
			{
				x26094932cf7a9139.Spacing = 0.0;
			}
			break;
		}
	}

	private static void xf85831351d8da5b6(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		switch (xf9eaf76facf8149b.x73cad9ab753bf0fa)
		{
		case x1e40528755c1f053.x8c0d22e4c133799d:
		case x1e40528755c1f053.x1be93eed8950d961:
			x26094932cf7a9139.Position = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			break;
		case x1e40528755c1f053.x1dd2250c6e384ef7:
		{
			string x19218ffab70283ef = xf9eaf76facf8149b.x48112399d54b30c7();
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "sub"))
			{
				x26094932cf7a9139.Subscript = true;
			}
			else if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "super"))
			{
				x26094932cf7a9139.Superscript = true;
			}
			else if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "baseline"))
			{
				x26094932cf7a9139.Subscript = false;
			}
			break;
		}
		}
	}

	private static void x722b70a5a6410b8c(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		x1e40528755c1f053 x73cad9ab753bf0fa = xf9eaf76facf8149b.x73cad9ab753bf0fa;
		if (x73cad9ab753bf0fa == x1e40528755c1f053.x9b41425268471380)
		{
			x26094932cf7a9139.x63b1a7c31a962459 = xf9eaf76facf8149b.xef50a938c8b9c7fd();
		}
	}

	private static void x306843c4a5fd8f34(xedac08b4826d3056 xf9eaf76facf8149b, Font x26094932cf7a9139)
	{
		if (xf9eaf76facf8149b.x73cad9ab753bf0fa == x1e40528755c1f053.x1dd2250c6e384ef7)
		{
			string x19218ffab70283ef = xf9eaf76facf8149b.x48112399d54b30c7();
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "none"))
			{
				x26094932cf7a9139.Hidden = true;
			}
		}
	}

	internal static void x626fe6c256bd3933(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, Font x26094932cf7a9139, x000f21cbda739311 xcb075c7088c3b520, bool xf544375d86767c28, FontInfoCollection x4c33abf651adeb81, x9df536d98415d2d0 x8b1a40fd1ddfa567)
	{
		string text = x26094932cf7a9139.xaf95fb496eb25433(xcb075c7088c3b520);
		if (x4c33abf651adeb81 != null)
		{
			string xbcea506a33cf = x9a25366b9d393820(text, x4c33abf651adeb81);
			x0a4437fb7b6e1adb x0a4437fb7b6e1adb = new x0a4437fb7b6e1adb();
			x0a4437fb7b6e1adb.Add(xedac08b4826d3056.x94f5da15b32c4a50(text));
			x0a4437fb7b6e1adb.Add(xedac08b4826d3056.xe6e56b57a990d08c(xbcea506a33cf));
			x44ecfea61c937b8e.x19f4b30676d8bb52("font-family", x0a4437fb7b6e1adb);
		}
		else
		{
			x44ecfea61c937b8e.x566936ceeb951bac("font-family", text);
		}
		double num = x26094932cf7a9139.Size;
		if (x26094932cf7a9139.xf6ce0e8106e6a1d8 != 0)
		{
			num *= 2.0 / 3.0;
		}
		x44ecfea61c937b8e.xd6d0700e6673d965("font-size", num, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		if (x26094932cf7a9139.Bold || x26094932cf7a9139.Outline || x26094932cf7a9139.Emboss || x26094932cf7a9139.Engrave)
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("font-weight", "bold");
		}
		else if (x26094932cf7a9139.xd538fa592193218b(60) || x26094932cf7a9139.xd538fa592193218b(90) || x26094932cf7a9139.xd538fa592193218b(170) || x26094932cf7a9139.xd538fa592193218b(180))
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("font-weight", "normal");
		}
		if (x26094932cf7a9139.Italic)
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("font-style", "italic");
		}
		else if (x26094932cf7a9139.xd538fa592193218b(70))
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("font-style", "normal");
		}
		if (x26094932cf7a9139.SmallCaps)
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("font-variant", "small-caps");
		}
		else if (x26094932cf7a9139.xd538fa592193218b(110))
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("font-variant", "normal");
		}
		if (x26094932cf7a9139.AllCaps)
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("text-transform", "uppercase");
		}
		else if (x26094932cf7a9139.xd538fa592193218b(120))
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("text-transform", "none");
		}
		if (xf544375d86767c28)
		{
			x0a4437fb7b6e1adb x0a4437fb7b6e1adb2 = new x0a4437fb7b6e1adb();
			if (x26094932cf7a9139.StrikeThrough || x26094932cf7a9139.DoubleStrikeThrough)
			{
				x0a4437fb7b6e1adb2.Add(xedac08b4826d3056.xe6e56b57a990d08c("line-through"));
			}
			if (x26094932cf7a9139.Underline != 0)
			{
				x0a4437fb7b6e1adb2.Add(xedac08b4826d3056.xe6e56b57a990d08c("underline"));
			}
			if (x0a4437fb7b6e1adb2.Count == 0 && (x26094932cf7a9139.xd538fa592193218b(80) || x26094932cf7a9139.xd538fa592193218b(300) || x26094932cf7a9139.xd538fa592193218b(140)))
			{
				x0a4437fb7b6e1adb2.Add(xedac08b4826d3056.xe6e56b57a990d08c("none"));
			}
			x44ecfea61c937b8e.x5ae72a407a137e0b("text-decoration", x0a4437fb7b6e1adb2);
		}
		if (x26094932cf7a9139.Spacing != 0.0)
		{
			x44ecfea61c937b8e.xd6d0700e6673d965("letter-spacing", x26094932cf7a9139.Spacing, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
		if (x26094932cf7a9139.Position != 0.0)
		{
			x44ecfea61c937b8e.xd6d0700e6673d965("vertical-align", x26094932cf7a9139.Position, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
		else if (x26094932cf7a9139.Subscript)
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("vertical-align", "sub");
		}
		else if (x26094932cf7a9139.Superscript)
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("vertical-align", "super");
		}
		else if (x26094932cf7a9139.xd538fa592193218b(210))
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("vertical-align", "baseline");
		}
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = x8b1a40fd1ddfa567.xa6dfa2703204e9f0(x26094932cf7a9139.x63b1a7c31a962459);
		if (x26d9ecb4bdf0456d != x26d9ecb4bdf0456d.x89fffa2751fdecbe)
		{
			x44ecfea61c937b8e.xf4868abd18f579a7("color", x26d9ecb4bdf0456d);
		}
		if (x26094932cf7a9139.Hidden)
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("display", "none");
		}
		else if (x26094932cf7a9139.xd538fa592193218b(130))
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("display", "inline");
		}
		if (!x26094932cf7a9139.xff8cd6f1d57322e6.x7149c962c02931b3)
		{
			x44ecfea61c937b8e.xf4868abd18f579a7("background-color", x26094932cf7a9139.xff8cd6f1d57322e6);
		}
		else
		{
			x4ce5248b91d2fbf7.xdd58192800f83cee(x26094932cf7a9139.Shading, x44ecfea61c937b8e);
		}
		x30ff4cedcf2b2374.xad56ef88b1fac115(x26094932cf7a9139.Border, x44ecfea61c937b8e);
	}

	internal static string x9a25366b9d393820(string xdeb9b8034c9e8cc2, FontInfoCollection x4ea5c100b613db8e)
	{
		string text = null;
		FontInfo fontInfo = x4ea5c100b613db8e[xdeb9b8034c9e8cc2];
		if (fontInfo != null)
		{
			switch (fontInfo.Family)
			{
			case FontFamily.Roman:
				text = "serif";
				break;
			case FontFamily.Swiss:
				text = "sans-serif";
				break;
			case FontFamily.Modern:
				text = "monospace";
				break;
			case FontFamily.Script:
				text = "cursive";
				break;
			case FontFamily.Decorative:
				text = "fantasy";
				break;
			}
		}
		if (text == null)
		{
			text = x116c8d451bdca7af.xc4ae649c0fe7bc8a(xdeb9b8034c9e8cc2);
		}
		if (text == null)
		{
			return xdeb9b8034c9e8cc2;
		}
		return text;
	}
}
