using System.Collections;
using System.Text;
using Aspose.Words;
using Aspose.Words.Lists;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x1a3e96f4b89a7a77;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x381fb081d11d6275;
using x38d3ef1c1d247e82;
using x461bbf0a821e3c87;
using x6c95d9cf46ff5f25;
using x7c4557e104065fc9;

namespace xce0136f05681c5e9;

internal class x26a1fc363fa95c48 : x202941c978357b4f
{
	private readonly xbb6564a24d4c901a xbc33695753285351;

	private double xd4de89d413110426;

	private static readonly int[] x3d18b2d2cfc86d35 = new int[4] { 1150, 1160, 1200, 1220 };

	private static readonly int[] x14b79ae1a1bf1af3 = new int[2] { 1200, 1220 };

	private static readonly int[] xabb74b07e5e3d4e2 = new int[2] { 190, 60 };

	private readonly Document xd1424e1a0bb4a72b;

	private readonly x9df536d98415d2d0 xa737d500a7554634;

	internal x26a1fc363fa95c48(Document document, bool documentFragmentSaving, HtmlSaveOptions htmlSaveOptions, x9df536d98415d2d0 fontColorResolver, xe2ff3c3cd396cfd9 htmlWriterCommon, x0ce95024f2f68661 shapeResourceWriter, x68331b8428496f91 warningCallback)
		: base(document, documentFragmentSaving, htmlSaveOptions, htmlWriterCommon, shapeResourceWriter, warningCallback)
	{
		xd1424e1a0bb4a72b = document;
		xa737d500a7554634 = fontColorResolver;
		xbc33695753285351 = new xbb6564a24d4c901a(xd1424e1a0bb4a72b.Styles);
	}

	internal override void xf567f5aadd93f9a8(Section xb32f8dd719a105db)
	{
		base.xf567f5aadd93f9a8(xb32f8dd719a105db);
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		x015eb412e40a664b.xa19e6d20b842efde(xb32f8dd719a105db.PageSetup, xa3fc7dcdc8182ff, !xb32f8dd719a105db.x65c77554c620f590 && base.xf57de0fd37d5e97d.x4e3c1d16eaf20ef3);
		x314725af01129cb4(xa3fc7dcdc8182ff.x9a706f5d15bd6d95(base.x8d3e55aac9030e70));
	}

	internal override void x23c8b7ad9bfc5719(Paragraph x41baca1d6c0c2e8e, x1a78664fa10a3755 x9e5248b49f0df7e8, bool x1ebf5501f9a725fb, x4ef6b4f19b033b48 x1458787a87172e23)
	{
		Paragraph x43004763abb6b2ac = null;
		int x8301ab10c226b0c = x41baca1d6c0c2e8e.x1a78664fa10a3755.x8301ab10c226b0c2;
		if (x8301ab10c226b0c != 0)
		{
			if (x8301ab10c226b0c > 6)
			{
				base.xe1410f585439c7d4.xff520a0047c27122("class", xbc33695753285351.x7af082eaf8e0caa4(x8301ab10c226b0c));
			}
			x43004763abb6b2ac = x41baca1d6c0c2e8e;
		}
		x41baca1d6c0c2e8e.xdf27503bc6a15f75(out var _, out var x966a98c86f220d2e, out var x1cdce3c10464e54e);
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = x4bff9bc5b8587d95.x6ac3f9aa1b303bd0(x41baca1d6c0c2e8e, xa4427eaecb321cf4: true, x966a98c86f220d2e, x1cdce3c10464e54e, x1ebf5501f9a725fb, x1458787a87172e23, base.xf57de0fd37d5e97d.AllowNegativeIndent, base.xf57de0fd37d5e97d.WarningCallback);
		xd4de89d413110426 = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5("font-size")?.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84) ?? 0.0;
		xbb2a2396386bdb03(xa3fc7dcdc8182ff, x43004763abb6b2ac, xbab733ddfd26bc0a: false);
		x314725af01129cb4(xa3fc7dcdc8182ff.x9a706f5d15bd6d95(base.x8d3e55aac9030e70));
	}

	internal override void xabeba2b272a12ca7(Font x26094932cf7a9139, x000f21cbda739311 xcb075c7088c3b520, bool xf544375d86767c28)
	{
		int x8301ab10c226b0c = x26094932cf7a9139.x8301ab10c226b0c2;
		if (x8301ab10c226b0c != 10)
		{
			base.xe1410f585439c7d4.xd52401bdf5aacef6(" class=\"");
			base.xe1410f585439c7d4.x3d1be38abe5723e3(xbc33695753285351.x7af082eaf8e0caa4(x8301ab10c226b0c));
			base.xe1410f585439c7d4.xd52401bdf5aacef6("\"");
		}
		xf5ecf429e74b1c04 x332a8eedb847940d = x26094932cf7a9139.x332a8eedb847940d;
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		x4bff9bc5b8587d95.xcf7d87ab57988c1a(x332a8eedb847940d, xa3fc7dcdc8182ff, xcb075c7088c3b520, xa4427eaecb321cf4: true, xb644687d42b4cb50: true, xf544375d86767c28, base.x0f1c1b952997f672, xa737d500a7554634);
		if (xd4de89d413110426 != 0.0)
		{
			xedac08b4826d3056 xedac08b4826d = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5("font-size");
			if (xedac08b4826d == null)
			{
				double size = x26094932cf7a9139.Size;
				if (size != xd4de89d413110426)
				{
					xa3fc7dcdc8182ff.set_xe6d4b1b411ed94b5("font-size", xedac08b4826d3056.x87b271b2896f9b89(size, x0ec035c4a2d07fb6.x560cf35c28bc5a84));
				}
			}
		}
		x6e55fba257b87843(xa3fc7dcdc8182ff);
		xd349b7f1296c4aca(xa3fc7dcdc8182ff.x9a706f5d15bd6d95(base.x8d3e55aac9030e70));
	}

	internal override void x746ca66f5c31e314(Table x1ec770899c98a268, double x072a638ef82da903)
	{
		string xa7505a15e36bfe1e = xbb04898cf6b5ed4f.x0453fd62c41d85e6(x1ec770899c98a268, x072a638ef82da903, base.xf57de0fd37d5e97d.TableWidthOutputMode);
		x314725af01129cb4(xa7505a15e36bfe1e);
	}

	internal override void x47fedfe9a943719d(Row xa806b754814b9ae0)
	{
		string xa7505a15e36bfe1e = xbb04898cf6b5ed4f.x86e41577fe04ea49(xa806b754814b9ae0.RowFormat);
		x314725af01129cb4(xa7505a15e36bfe1e);
	}

	internal override void x1b6c90c46e2852e3(x9546c9d5ffe8dc51 xe6de5e5fa2d44af5)
	{
		string xa7505a15e36bfe1e = xbb04898cf6b5ed4f.x2f927a70e85f8dee(xe6de5e5fa2d44af5, base.xf57de0fd37d5e97d.TableWidthOutputMode);
		x314725af01129cb4(xa7505a15e36bfe1e);
	}

	internal override ArrayList xdbfcc0f818df30a4()
	{
		StyleCollection styles = xd1424e1a0bb4a72b.Styles;
		x1a78664fa10a3755 x1a78664fa10a = new x1a78664fa10a3755();
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		styles.xf4eb04b8b9073eeb.xab3af626b1405ee8(x1a78664fa10a, x9ee6c2f047893ddc: true);
		styles.x27096df7ca0cfe2e.xab3af626b1405ee8(xeedad81aaed42a, x9ee6c2f047893ddc: true);
		Style style = styles.xf21e14e2c9db279a(StyleIdentifier.Normal, x988fcf605f8efa7e: true);
		style.x7dbbdff0e18dae2c(x1a78664fa10a, xd9bc7f7e70d71e14.x3968babb3b57e478);
		style.x5f851b1938defe5f(xeedad81aaed42a, xecac24b19ed3a2b7.xe9e531d1a6725226);
		xeedad81aaed42a76 xeedad81aaed42a2 = new xeedad81aaed42a76();
		x1d3bbc13bf0cb53f(xabb74b07e5e3d4e2, xeedad81aaed42a, xeedad81aaed42a2);
		x1a78664fa10a3755 x1a78664fa10a2 = null;
		x1a78664fa10a3755 x1a78664fa10a3 = null;
		if (x1a78664fa10a.xd44988f225497f3a > 0)
		{
			x1a78664fa10a2 = new x1a78664fa10a3755();
			x1a78664fa10a3 = new x1a78664fa10a3755();
			x1d3bbc13bf0cb53f(x14b79ae1a1bf1af3, x1a78664fa10a, x1a78664fa10a3);
			x19a8d64625efc935(x3d18b2d2cfc86d35, x1a78664fa10a, x1a78664fa10a2);
		}
		ArrayList arrayList = new ArrayList();
		bool xa4427eaecb321cf = x47798ba9018585c5(arrayList, "body", x1a78664fa10a, xeedad81aaed42a, xa4427eaecb321cf4: false);
		x47798ba9018585c5(arrayList, xfe6ae0ce0ff2621a(styles), x1a78664fa10a2, null, xa4427eaecb321cf);
		string text = x9089495a2c622400(xd1424e1a0bb4a72b);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x47798ba9018585c5(arrayList, text, x1a78664fa10a3, null, xa4427eaecb321cf);
		}
		ArrayList arrayList2 = xfca06121a3f925c8(styles);
		foreach (Style item in arrayList2)
		{
			if (x1a78664fa10a.xd44988f225497f3a != 0)
			{
				x1a78664fa10a.ClearAttrs();
			}
			if (xeedad81aaed42a.xd44988f225497f3a != 0)
			{
				xeedad81aaed42a.ClearAttrs();
			}
			if (item.IsHeading)
			{
				xeedad81aaed42a2.xab3af626b1405ee8(xeedad81aaed42a);
			}
			item.x7dbbdff0e18dae2c(x1a78664fa10a, xd9bc7f7e70d71e14.x3968babb3b57e478);
			item.x5f851b1938defe5f(xeedad81aaed42a, xecac24b19ed3a2b7.xe9e531d1a6725226);
			x47798ba9018585c5(arrayList, x141d732c719bce2f(item), x1a78664fa10a, xeedad81aaed42a, xa4427eaecb321cf4: true);
		}
		return arrayList;
	}

	private bool x47798ba9018585c5(ArrayList xa35f58bbe907c740, string xf1e808d2f36e0fd2, x1a78664fa10a3755 x062aae8c9613eeaa, xeedad81aaed42a76 x789564759d365819, bool xa4427eaecb321cf4)
	{
		bool flag = x062aae8c9613eeaa != null && x062aae8c9613eeaa.xd44988f225497f3a > 0 && (x062aae8c9613eeaa.xd44988f225497f3a != 1 || x062aae8c9613eeaa.xf15263674eb297bb(0) != 1000);
		bool flag2 = x789564759d365819 != null && x789564759d365819.xd44988f225497f3a > 0;
		if (!flag && !flag2)
		{
			return false;
		}
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff;
		if (flag)
		{
			bool x1ebf5501f9a725fb = false;
			if (x062aae8c9613eeaa.x71c63f7e57f7ede5 != 0 && !x495fdb45f3d92b70.x451aaae1babb8e57(x062aae8c9613eeaa))
			{
				ListLevel listLevel = new ListFormat(x062aae8c9613eeaa, xd1424e1a0bb4a72b.Lists).ListLevel;
				x1ebf5501f9a725fb = listLevel.x44b52529222cea8a || (x495fdb45f3d92b70.x903af03e39bcd255(listLevel, base.xf57de0fd37d5e97d.x4e3c1d16eaf20ef3) && !ListLabel.xc0242e835a99b224(listLevel));
			}
			xa3fc7dcdc8182ff = x4bff9bc5b8587d95.x6ac3f9aa1b303bd0(x062aae8c9613eeaa, xa4427eaecb321cf4, 0.0, x09585c411b119c0d: false, x1ebf5501f9a725fb, x4ef6b4f19b033b48.x526d6c6f824cda87, base.xf57de0fd37d5e97d.AllowNegativeIndent, base.xf57de0fd37d5e97d.WarningCallback);
		}
		else
		{
			xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		}
		if (flag2)
		{
			x4bff9bc5b8587d95.xcf7d87ab57988c1a(x789564759d365819, xa3fc7dcdc8182ff, x000f21cbda739311.x175297738c8b8d1e, xa4427eaecb321cf4, xb644687d42b4cb50: false, xf544375d86767c28: true, base.x0f1c1b952997f672, xa737d500a7554634);
		}
		x6e55fba257b87843(xa3fc7dcdc8182ff);
		if (xa3fc7dcdc8182ff.xd44988f225497f3a == 0)
		{
			return false;
		}
		xa35f58bbe907c740.Add(new x63101ab0f6a74e8f(xf1e808d2f36e0fd2, xa3fc7dcdc8182ff));
		return true;
	}

	private static void x19a8d64625efc935(int[] x83f3ea1d0a03c7e1, x4c1e058c67948d6a x37075ef5c9a19c89, x4c1e058c67948d6a x6f2341a442a8d008)
	{
		foreach (int xba08ce632055a1d in x83f3ea1d0a03c7e1)
		{
			int num = x37075ef5c9a19c89.xf8af57cefd692401(xba08ce632055a1d);
			if (num >= 0)
			{
				x6f2341a442a8d008.xd6b6ed77479ef68c(xba08ce632055a1d, x37075ef5c9a19c89.x6d3720b962bd3112(num));
				x37075ef5c9a19c89.x7121e9e177952651(num);
			}
		}
	}

	private static void x1d3bbc13bf0cb53f(int[] x83f3ea1d0a03c7e1, x4c1e058c67948d6a x37075ef5c9a19c89, x4c1e058c67948d6a x6f2341a442a8d008)
	{
		foreach (int xba08ce632055a1d in x83f3ea1d0a03c7e1)
		{
			int num = x37075ef5c9a19c89.xf8af57cefd692401(xba08ce632055a1d);
			if (num >= 0)
			{
				x6f2341a442a8d008.xd6b6ed77479ef68c(xba08ce632055a1d, x37075ef5c9a19c89.x6d3720b962bd3112(num));
			}
		}
	}

	private static ArrayList xfca06121a3f925c8(StyleCollection x3fa6ecdd18b2ff6e)
	{
		int count = x3fa6ecdd18b2ff6e.Count;
		x94c83b1ca7961561 x94c83b1ca = new x94c83b1ca7961561(count);
		ArrayList arrayList = new ArrayList(count);
		int[] array = new int[5];
		foreach (Style item in x3fa6ecdd18b2ff6e)
		{
			int x8301ab10c226b0c = item.x8301ab10c226b0c2;
			if (x94c83b1ca.x263d579af1d0d43f(x8301ab10c226b0c))
			{
				continue;
			}
			x94c83b1ca.xd6b6ed77479ef68c(x8301ab10c226b0c);
			int num = -1;
			switch (item.Type)
			{
			case StyleType.Paragraph:
				if (item.IsHeading)
				{
					num = 0;
				}
				else if (item.StyleIdentifier != 0)
				{
					num = 1;
				}
				break;
			case StyleType.Character:
				num = 2;
				break;
			case StyleType.List:
				num = 3;
				break;
			case StyleType.Table:
				num = 4;
				break;
			}
			if (num < 0)
			{
				continue;
			}
			int num2 = array[num];
			if (num == 0)
			{
				while (num2 > 0 && x8301ab10c226b0c < ((Style)arrayList[num2 - 1]).x8301ab10c226b0c2)
				{
					num2--;
				}
			}
			arrayList.Insert(num2, item);
			for (int i = num; i < 5; i++)
			{
				array[i]++;
			}
		}
		return arrayList;
	}

	private string xfe6ae0ce0ff2621a(StyleCollection x3fa6ecdd18b2ff6e)
	{
		x6519502b0e34e920 x6519502b0e34e = x6519502b0e34e920.x820665812c4c07a7();
		foreach (Style item in x3fa6ecdd18b2ff6e)
		{
			x6519502b0e34e.xd6b6ed77479ef68c(x754017e579b6a8ff.x6f4063730e81a2f6(item.x8301ab10c226b0c2));
		}
		StringBuilder stringBuilder = new StringBuilder(x6519502b0e34e.xd44988f225497f3a * 5);
		string format = "{0}";
		foreach (string item2 in x6519502b0e34e)
		{
			stringBuilder.AppendFormat(format, item2);
			format = ", {0}";
		}
		return stringBuilder.ToString();
	}

	private static string x9089495a2c622400(Document x5ad5b049b85f7326)
	{
		ListCollection lists = x5ad5b049b85f7326.Lists;
		bool flag = lists != null && lists.Count != 0;
		bool flag2 = x5ad5b049b85f7326.SelectSingleNode("//Table") != null;
		if (!flag)
		{
			if (!flag2)
			{
				return "";
			}
			return "table";
		}
		if (!flag2)
		{
			return "li";
		}
		return "li, table";
	}

	private string x141d732c719bce2f(Style x44ecfea61c937b8e)
	{
		int x8301ab10c226b0c = x44ecfea61c937b8e.x8301ab10c226b0c2;
		StyleType type = x44ecfea61c937b8e.Type;
		string text = xce50306da44d0aca(type);
		string text2 = "";
		if (type == StyleType.Paragraph)
		{
			string text3 = x754017e579b6a8ff.x6f4063730e81a2f6(x8301ab10c226b0c);
			if (x8301ab10c226b0c == 0 || text3 != "p")
			{
				text2 = text3;
			}
		}
		if (!x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			text2 = text + xbc33695753285351.x7af082eaf8e0caa4(x8301ab10c226b0c);
		}
		string[] array = xbc33695753285351.xb6b0362f2c000366(x8301ab10c226b0c);
		if (array != null)
		{
			string[] array2 = array;
			foreach (string arg in array2)
			{
				text2 = $"{text2}, {text}{arg}";
			}
		}
		return text2;
	}

	private static string xce50306da44d0aca(StyleType x43163d22e8cd5a71)
	{
		return x43163d22e8cd5a71 switch
		{
			StyleType.Paragraph => ".", 
			StyleType.Character => "span.", 
			_ => ".", 
		};
	}
}
