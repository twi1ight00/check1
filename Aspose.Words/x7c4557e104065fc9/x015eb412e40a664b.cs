using Aspose.Words;
using Aspose.Words.Lists;
using Aspose.Words.Saving;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace x7c4557e104065fc9;

internal class x015eb412e40a664b
{
	internal static string xee9c65145be54ec5(HtmlSaveOptions x2dfefe41d2b74035, ListLevel x0fe7a8514e20eb94, string x8dcfbf7b6ef33595)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		xa3fc7dcdc8182ff.xd6d0700e6673d965("margin-top", 0.0, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		xa3fc7dcdc8182ff.xd6d0700e6673d965("margin-bottom", 0.0, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		if (x2dfefe41d2b74035.x4e3c1d16eaf20ef3)
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("list-style-type", x3d37aefb6cbd0186(x0fe7a8514e20eb94));
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x8dcfbf7b6ef33595))
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("list-style-image", $"url('{x8dcfbf7b6ef33595}')");
		}
		return xa3fc7dcdc8182ff.x9a706f5d15bd6d95(xb39cf349cb3e0d91: false);
	}

	internal static string x142e13c6dfd73e82(TextOrientation xf65758d54b79fc7a)
	{
		if (xf65758d54b79fc7a == TextOrientation.Downward || xf65758d54b79fc7a == TextOrientation.VerticalFarEast)
		{
			return "tb-rl";
		}
		return "lr-tb";
	}

	internal static TextOrientation xca7f875a1e6fc583(string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x90637a473b1ceaaa(xbcea506a33cf9111, "tb-rl"))
		{
			return TextOrientation.VerticalFarEast;
		}
		return TextOrientation.Horizontal;
	}

	internal static void xa19e6d20b842efde(PageSetup xaa066f9e98b59c33, xa3fc7dcdc8182ff6 x44ecfea61c937b8e, bool x876ebcdcf54ae861)
	{
		if (xaa066f9e98b59c33.x6d434087bc06a37d != 0)
		{
			x44ecfea61c937b8e.xf0ca15702ca7498c("writing-mode", x44a449bf1c6ab3fd(xaa066f9e98b59c33.x6d434087bc06a37d));
		}
		if (x876ebcdcf54ae861)
		{
			x1932c9c786040b85(xaa066f9e98b59c33.SectionStart, x44ecfea61c937b8e);
		}
	}

	private static string x44a449bf1c6ab3fd(x6d434087bc06a37d xee0aaeab57df8a67)
	{
		if (xee0aaeab57df8a67 == x6d434087bc06a37d.x61c108cc44ef385a)
		{
			return "tb-rl";
		}
		return "lr-tb";
	}

	private static x6d434087bc06a37d xc7a720fb41bdd3fc(string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x90637a473b1ceaaa(xbcea506a33cf9111, "tb-rl"))
		{
			return x6d434087bc06a37d.x61c108cc44ef385a;
		}
		return x6d434087bc06a37d.x3bce7c87328df8da;
	}

	internal static void x1932c9c786040b85(SectionStart x62be4371a2e08894, xa3fc7dcdc8182ff6 x36c843bef78b260f)
	{
		switch (x62be4371a2e08894)
		{
		case SectionStart.Continuous:
			x36c843bef78b260f.xf0ca15702ca7498c("page-break-before", "auto");
			break;
		case SectionStart.NewColumn:
			x36c843bef78b260f.xf0ca15702ca7498c("mso-column-break-before", "always");
			break;
		case SectionStart.EvenPage:
			x36c843bef78b260f.xf0ca15702ca7498c("page-break-before", "left");
			break;
		case SectionStart.OddPage:
			x36c843bef78b260f.xf0ca15702ca7498c("page-break-before", "right");
			break;
		default:
			x36c843bef78b260f.xf0ca15702ca7498c("page-break-before", "always");
			break;
		}
		x36c843bef78b260f.xf0ca15702ca7498c("mso-break-type", "section-break");
		x36c843bef78b260f.xf0ca15702ca7498c("clear", "both");
	}

	internal static void x4d70d8740f6f39fa(PageSetup xaa066f9e98b59c33, xa3fc7dcdc8182ff6 x36c843bef78b260f)
	{
		x0a4437fb7b6e1adb x0a4437fb7b6e1adb = new x0a4437fb7b6e1adb();
		x0a4437fb7b6e1adb.Add(xedac08b4826d3056.x87b271b2896f9b89(xaa066f9e98b59c33.PageWidth, x0ec035c4a2d07fb6.x560cf35c28bc5a84));
		x0a4437fb7b6e1adb.Add(xedac08b4826d3056.x87b271b2896f9b89(xaa066f9e98b59c33.PageHeight, x0ec035c4a2d07fb6.x560cf35c28bc5a84));
		x36c843bef78b260f.x5ae72a407a137e0b("size", x0a4437fb7b6e1adb);
		x36c843bef78b260f.xfd7a4669c14e659a("margin", xaa066f9e98b59c33.TopMargin, xaa066f9e98b59c33.RightMargin, xaa066f9e98b59c33.BottomMargin, xaa066f9e98b59c33.LeftMargin, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
	}

	internal static void xd5bbd6a43704bfde(xa3fc7dcdc8182ff6 x36c843bef78b260f, PageSetup xaa066f9e98b59c33)
	{
		xedac08b4826d3056 xedac08b4826d = x36c843bef78b260f.get_xe6d4b1b411ed94b5("size");
		if (xedac08b4826d != null)
		{
			x1b6387a950897d7f(xedac08b4826d, xaa066f9e98b59c33);
		}
		for (int i = 0; i < x36c843bef78b260f.xd44988f225497f3a; i++)
		{
			string x250224921a47c2f = x36c843bef78b260f.xf15263674eb297bb(i);
			xedac08b4826d3056 xedac08b4826d2 = x36c843bef78b260f.get_xe6d4b1b411ed94b5(i);
			if (!object.ReferenceEquals(xedac08b4826d2, xedac08b4826d))
			{
				xbee0f5dc7c99c71e(x250224921a47c2f, xedac08b4826d2, xaa066f9e98b59c33);
			}
		}
	}

	private static void xbee0f5dc7c99c71e(string x250224921a47c2f5, xedac08b4826d3056 xf9eaf76facf8149b, PageSetup xaa066f9e98b59c33)
	{
		if (x0d299f323d241756.x90637a473b1ceaaa(x250224921a47c2f5, "margin"))
		{
			x60b7a505461a80e7 x60b7a505461a80e = new x60b7a505461a80e7(xf9eaf76facf8149b);
			xbee0f5dc7c99c71e("margin-left", x60b7a505461a80e.x72d92bd1aff02e37, xaa066f9e98b59c33);
			xbee0f5dc7c99c71e("margin-right", x60b7a505461a80e.x419ba17a5322627b, xaa066f9e98b59c33);
			xbee0f5dc7c99c71e("margin-top", x60b7a505461a80e.xe360b1885d8d4a41, xaa066f9e98b59c33);
			xbee0f5dc7c99c71e("margin-bottom", x60b7a505461a80e.x9bcb07e204e30218, xaa066f9e98b59c33);
		}
		else if (x0d299f323d241756.x90637a473b1ceaaa(x250224921a47c2f5, "margin-left"))
		{
			if (xf9eaf76facf8149b.x441975e8629f5bf8)
			{
				xaa066f9e98b59c33.LeftMargin = xf9eaf76facf8149b.xc3b6cb7f017ad49a(x0ec035c4a2d07fb6.x560cf35c28bc5a84, xaa066f9e98b59c33.PageWidth);
			}
		}
		else if (x0d299f323d241756.x90637a473b1ceaaa(x250224921a47c2f5, "margin-right"))
		{
			if (xf9eaf76facf8149b.x441975e8629f5bf8)
			{
				xaa066f9e98b59c33.RightMargin = xf9eaf76facf8149b.xc3b6cb7f017ad49a(x0ec035c4a2d07fb6.x560cf35c28bc5a84, xaa066f9e98b59c33.PageWidth);
			}
		}
		else if (x0d299f323d241756.x90637a473b1ceaaa(x250224921a47c2f5, "margin-top"))
		{
			if (xf9eaf76facf8149b.x441975e8629f5bf8)
			{
				xaa066f9e98b59c33.TopMargin = xf9eaf76facf8149b.xc3b6cb7f017ad49a(x0ec035c4a2d07fb6.x560cf35c28bc5a84, xaa066f9e98b59c33.PageHeight);
			}
		}
		else if (x0d299f323d241756.x90637a473b1ceaaa(x250224921a47c2f5, "margin-bottom") && xf9eaf76facf8149b.x441975e8629f5bf8)
		{
			xaa066f9e98b59c33.BottomMargin = xf9eaf76facf8149b.xc3b6cb7f017ad49a(x0ec035c4a2d07fb6.x560cf35c28bc5a84, xaa066f9e98b59c33.PageHeight);
		}
	}

	private static void x1b6387a950897d7f(xedac08b4826d3056 x0ceec69a97f73617, PageSetup xaa066f9e98b59c33)
	{
		x82d05ad67b4d4fc1 x82d05ad67b4d4fc = new x82d05ad67b4d4fc1(x0ceec69a97f73617);
		string text = x82d05ad67b4d4fc.xdc1bf80853046136.x48112399d54b30c7();
		if (text.Length != 0)
		{
			x1cbb4b76c0f5d2be(text, xaa066f9e98b59c33);
			return;
		}
		xaa066f9e98b59c33.PageWidth = x82d05ad67b4d4fc.xdc1bf80853046136.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		xaa066f9e98b59c33.PageHeight = x82d05ad67b4d4fc.xb0f146032f47c24e.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
	}

	private static void x1cbb4b76c0f5d2be(string xf65758d54b79fc7a, PageSetup xaa066f9e98b59c33)
	{
		if (x0d299f323d241756.x90637a473b1ceaaa(xf65758d54b79fc7a, "portrait") || x0d299f323d241756.x90637a473b1ceaaa(xf65758d54b79fc7a, "auto"))
		{
			xaa066f9e98b59c33.Orientation = Orientation.Portrait;
		}
		else if (x0d299f323d241756.x90637a473b1ceaaa(xf65758d54b79fc7a, "landscape"))
		{
			xaa066f9e98b59c33.Orientation = Orientation.Landscape;
		}
	}

	private static string x3d37aefb6cbd0186(ListLevel x66bbd7ed8c65740d)
	{
		string text = x495fdb45f3d92b70.x75e0857b98f68f5f(x66bbd7ed8c65740d);
		if (text != null)
		{
			return text;
		}
		return x66bbd7ed8c65740d.NumberStyle switch
		{
			NumberStyle.Arabic => "decimal", 
			NumberStyle.LeadingZero => "decimal-leading-zero", 
			NumberStyle.LowercaseLetter => "lower-latin", 
			NumberStyle.LowercaseRoman => "lower-roman", 
			NumberStyle.Number => "decimal", 
			NumberStyle.Ordinal => "decimal", 
			NumberStyle.OrdinalText => "decimal", 
			NumberStyle.UppercaseLetter => "upper-latin", 
			NumberStyle.UppercaseRoman => "upper-roman", 
			_ => "decimal", 
		};
	}
}
