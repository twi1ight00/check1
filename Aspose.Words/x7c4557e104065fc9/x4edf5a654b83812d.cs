using System;
using Aspose.Words;
using x13f1efc79617a47b;
using x2697283ff424107e;
using x6c95d9cf46ff5f25;
using xce0136f05681c5e9;

namespace x7c4557e104065fc9;

internal class x4edf5a654b83812d
{
	private x4edf5a654b83812d()
	{
	}

	internal static void xe7ce6487f5f217d1(string xa7505a15e36bfe1e, ParagraphFormat xefceefc9504671df)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xa7505a15e36bfe1e))
		{
			xe7ce6487f5f217d1(new xa3fc7dcdc8182ff6(xa7505a15e36bfe1e), xefceefc9504671df);
		}
	}

	internal static void xe7ce6487f5f217d1(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, ParagraphFormat xefceefc9504671df)
	{
		x30ff4cedcf2b2374.x1227cb7b82063569(x44ecfea61c937b8e, xefceefc9504671df.Borders);
		for (int i = 0; i < x44ecfea61c937b8e.xd44988f225497f3a; i++)
		{
			string x250224921a47c2f = x44ecfea61c937b8e.xf15263674eb297bb(i);
			xedac08b4826d3056 xf9eaf76facf8149b = x44ecfea61c937b8e.get_xe6d4b1b411ed94b5(i);
			xffb3709381da9af8(x250224921a47c2f, xf9eaf76facf8149b, xefceefc9504671df);
		}
	}

	private static void xffb3709381da9af8(string x250224921a47c2f5, xedac08b4826d3056 xf9eaf76facf8149b, ParagraphFormat xefceefc9504671df)
	{
		switch (x250224921a47c2f5)
		{
		case "direction":
			xefceefc9504671df.Bidi = x495fdb45f3d92b70.x3732023a3d3acbf8(xf9eaf76facf8149b.x48112399d54b30c7(), xf0e1f8c39ee2c6f7: false);
			break;
		case "margin":
		{
			x60b7a505461a80e7 x60b7a505461a80e2 = new x60b7a505461a80e7(xf9eaf76facf8149b);
			xffb3709381da9af8("margin-left", x60b7a505461a80e2.x72d92bd1aff02e37, xefceefc9504671df);
			xffb3709381da9af8("margin-right", x60b7a505461a80e2.x419ba17a5322627b, xefceefc9504671df);
			xffb3709381da9af8("margin-top", x60b7a505461a80e2.xe360b1885d8d4a41, xefceefc9504671df);
			xffb3709381da9af8("margin-bottom", x60b7a505461a80e2.x9bcb07e204e30218, xefceefc9504671df);
			break;
		}
		case "margin-left":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				xefceefc9504671df.LeftIndent = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			break;
		case "margin-right":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				xefceefc9504671df.RightIndent = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			break;
		case "margin-top":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				xefceefc9504671df.SpaceBeforeAuto = false;
				xefceefc9504671df.SpaceBefore = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			break;
		case "margin-bottom":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				xefceefc9504671df.SpaceAfterAuto = false;
				xefceefc9504671df.SpaceAfter = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			break;
		case "text-indent":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				xefceefc9504671df.FirstLineIndent = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			break;
		case "text-align":
			xefceefc9504671df.Alignment = x495fdb45f3d92b70.xa9a738046a9a4faa(xf9eaf76facf8149b.x48112399d54b30c7());
			break;
		case "page-break-inside":
			xefceefc9504671df.KeepTogether = xf9eaf76facf8149b.x48112399d54b30c7().ToLower() == "avoid";
			break;
		case "page-break-after":
			xefceefc9504671df.KeepWithNext = xf9eaf76facf8149b.x48112399d54b30c7().ToLower() == "avoid";
			break;
		case "page-break-before":
			xefceefc9504671df.PageBreakBefore = xf9eaf76facf8149b.x48112399d54b30c7().ToLower() == "always";
			break;
		case "widows":
		case "orphans":
			xefceefc9504671df.WidowControl = xf9eaf76facf8149b.x043aafba68f5c559() > 0.0;
			break;
		case "line-height":
			switch (xf9eaf76facf8149b.x73cad9ab753bf0fa)
			{
			case x1e40528755c1f053.x2f7951fa0946af7e:
			{
				xefceefc9504671df.LineSpacingRule = LineSpacingRule.Multiple;
				double x0383ec486664fa = xf9eaf76facf8149b.x043aafba68f5c559() / 100.0;
				xefceefc9504671df.LineSpacing = x4574ea26106f0edb.xefebf4e0a5cd9e91(x0383ec486664fa);
				break;
			}
			case x1e40528755c1f053.x1be93eed8950d961:
				xefceefc9504671df.LineSpacingRule = LineSpacingRule.AtLeast;
				xefceefc9504671df.LineSpacing = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
				break;
			}
			break;
		case "padding":
		{
			x60b7a505461a80e7 x60b7a505461a80e = new x60b7a505461a80e7(xf9eaf76facf8149b);
			xffb3709381da9af8("padding-left", x60b7a505461a80e.x72d92bd1aff02e37, xefceefc9504671df);
			xffb3709381da9af8("padding-right", x60b7a505461a80e.x419ba17a5322627b, xefceefc9504671df);
			xffb3709381da9af8("padding-top", x60b7a505461a80e.xe360b1885d8d4a41, xefceefc9504671df);
			xffb3709381da9af8("padding-bottom", x60b7a505461a80e.x9bcb07e204e30218, xefceefc9504671df);
			break;
		}
		case "padding-left":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				xefceefc9504671df.Borders.Left.xd0ddb5dfe7e0d9df(xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84));
			}
			break;
		case "padding-right":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				xefceefc9504671df.Borders.Right.xd0ddb5dfe7e0d9df(xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84));
			}
			break;
		case "padding-top":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				xefceefc9504671df.Borders.Top.xd0ddb5dfe7e0d9df(xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84));
			}
			break;
		case "padding-bottom":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				xefceefc9504671df.Borders.Bottom.xd0ddb5dfe7e0d9df(xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84));
			}
			break;
		case "writing-mode":
			xefceefc9504671df.xeeb818f91e3131df = x015eb412e40a664b.xca7f875a1e6fc583(xf9eaf76facf8149b.x48112399d54b30c7());
			break;
		default:
			x4ce5248b91d2fbf7.x6392b9ac6bc562f4(x250224921a47c2f5, xf9eaf76facf8149b, xefceefc9504671df.Shading);
			break;
		}
	}

	internal static xa3fc7dcdc8182ff6 x893948bf4ed8e702(ParagraphFormat xefceefc9504671df, double x966a98c86f220d2e, bool x1ebf5501f9a725fb, x4ef6b4f19b033b48 x1458787a87172e23, bool x37964b8beac948a3, IWarningCallback x57fef5933b41d0c2)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		bool flag = x1458787a87172e23 != x4ef6b4f19b033b48.x526d6c6f824cda87;
		if (x1ebf5501f9a725fb)
		{
			if (xefceefc9504671df.SpaceBefore != 0.0)
			{
				xa3fc7dcdc8182ff.xd6d0700e6673d965("margin-top", xefceefc9504671df.SpaceBefore, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			if (xefceefc9504671df.SpaceAfter != 0.0)
			{
				xa3fc7dcdc8182ff.xd6d0700e6673d965("margin-bottom", xefceefc9504671df.SpaceAfter, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
		}
		else
		{
			double num = (xefceefc9504671df.Bidi ? xefceefc9504671df.RightIndent : xefceefc9504671df.LeftIndent);
			double num2 = (xefceefc9504671df.Bidi ? xefceefc9504671df.LeftIndent : xefceefc9504671df.RightIndent);
			if (!x37964b8beac948a3)
			{
				double num3 = num;
				double num4 = num2;
				num = Math.Max(0.0, num);
				num2 = Math.Max(0.0, num2);
				if (xefceefc9504671df.Bidi)
				{
					double num5 = num2 + xefceefc9504671df.FirstLineIndent;
					if (num5 < 0.0)
					{
						num2 -= num5;
					}
				}
				else
				{
					double num6 = num + xefceefc9504671df.FirstLineIndent;
					if (num6 < 0.0)
					{
						num -= num6;
					}
				}
				if (num != num3)
				{
					xa3193a56fd4c92e5(x57fef5933b41d0c2, x8c927810a5dc8895: true, num3);
				}
				if (num2 != num4)
				{
					xa3193a56fd4c92e5(x57fef5933b41d0c2, x8c927810a5dc8895: false, num4);
				}
			}
			double xc941868c59399d3e = xefceefc9504671df.SpaceBefore;
			double num7 = xefceefc9504671df.SpaceAfter;
			if (flag)
			{
				num2 -= xefceefc9504671df.RightIndent;
				num -= xefceefc9504671df.LeftIndent;
				xc941868c59399d3e = 0.0;
				if (x1458787a87172e23 == x4ef6b4f19b033b48.x89f4b67282edaf4a)
				{
					num7 = 0.0;
				}
				if (xefceefc9504671df.Borders.Horizontal.IsVisible || x1458787a87172e23 == x4ef6b4f19b033b48.x89f4b67282edaf4a)
				{
					num7 += xefceefc9504671df.Borders.Bottom.DistanceFromText;
				}
				if (num7 > 0.0)
				{
					xa3fc7dcdc8182ff.xd6d0700e6673d965("padding-bottom", num7, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
				}
				num7 = 0.0;
			}
			xa3fc7dcdc8182ff.xfd7a4669c14e659a("margin", xc941868c59399d3e, num2, num7, num, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			if (xefceefc9504671df.FirstLineIndent != 0.0)
			{
				xa3fc7dcdc8182ff.xd6d0700e6673d965("text-indent", xefceefc9504671df.FirstLineIndent, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
		}
		if (xefceefc9504671df.Alignment != 0)
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("text-align", x495fdb45f3d92b70.x7f90501c33a75aa6(xefceefc9504671df.Alignment));
		}
		if (xefceefc9504671df.KeepTogether)
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("page-break-inside", "avoid");
		}
		if (xefceefc9504671df.KeepWithNext)
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("page-break-after", "avoid");
		}
		if (xefceefc9504671df.PageBreakBefore)
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("page-break-before", "always");
		}
		if (!xefceefc9504671df.WidowControl)
		{
			xa3fc7dcdc8182ff.x0973ec6da4c01c5e("widows", 0.0);
			xa3fc7dcdc8182ff.x0973ec6da4c01c5e("orphans", 0.0);
		}
		switch (xefceefc9504671df.LineSpacingRule)
		{
		case LineSpacingRule.Multiple:
		{
			double num8 = Math.Round(xefceefc9504671df.x4e22f2855b31a5f0 * 100.0);
			if (num8 != 100.0)
			{
				xa3fc7dcdc8182ff.xb2275198aa955331("line-height", num8);
				xa3fc7dcdc8182ff.xd6d0700e6673d965("font-size", x966a98c86f220d2e, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			break;
		}
		case LineSpacingRule.AtLeast:
		{
			double xbcea506a33cf = Math.Max(xefceefc9504671df.LineSpacing, x966a98c86f220d2e);
			xa3fc7dcdc8182ff.xd6d0700e6673d965("line-height", xbcea506a33cf, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			break;
		}
		case LineSpacingRule.Exactly:
			xa3fc7dcdc8182ff.xd6d0700e6673d965("line-height", xefceefc9504671df.LineSpacing, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("adpigegjaenjaeekodlkdeclhdjlgoplpchmjcomlcfnpbmnhncohckobcbppaipoappbbgadbnajaebplkboaccoajccaadipgdolnd", 1927253723)));
		}
		if (flag)
		{
			bool xc1f791c0da7d5aa = x1458787a87172e23 == x4ef6b4f19b033b48.x853425d3a03042f1 || xefceefc9504671df.Borders.Horizontal.IsVisible;
			x30ff4cedcf2b2374.x9a036a30e27cef5e(xa3fc7dcdc8182ff, xefceefc9504671df.Borders, xc1f791c0da7d5aa, xafe24d0ee7944d28: false);
		}
		else
		{
			x30ff4cedcf2b2374.xa95bac7421a1a927(xa3fc7dcdc8182ff, xefceefc9504671df.Borders, x82fdb3b4231a1374: true);
		}
		x4ce5248b91d2fbf7.xdd58192800f83cee(xefceefc9504671df.Shading, xa3fc7dcdc8182ff);
		if (xefceefc9504671df.Borders.Horizontal.IsVisible && (x1458787a87172e23 == x4ef6b4f19b033b48.x763219a89d453f55 || x1458787a87172e23 == x4ef6b4f19b033b48.x853425d3a03042f1))
		{
			x30ff4cedcf2b2374.xad56ef88b1fac115(xa3fc7dcdc8182ff, xefceefc9504671df.Borders.Horizontal, BorderType.Bottom, x82fdb3b4231a1374: false);
		}
		string text = x015eb412e40a664b.x142e13c6dfd73e82(xefceefc9504671df.xeeb818f91e3131df);
		if (text != "lr-tb")
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("writing-mode", text);
		}
		Style style = xefceefc9504671df.Style;
		if (style != null && style.IsHeading && !style.Font.Bold)
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("font-weight", "normal");
		}
		return xa3fc7dcdc8182ff;
	}

	internal static void xa3193a56fd4c92e5(IWarningCallback x57fef5933b41d0c2, bool x8c927810a5dc8895, double x26fe992a63937e13)
	{
		if (x57fef5933b41d0c2 != null)
		{
			string description = string.Format("{0} margin of a paragraph was trimmed, the original value was {1}", x8c927810a5dc8895 ? "Left" : "Right", x26fe992a63937e13);
			x57fef5933b41d0c2.Warning(new WarningInfo(WarningType.MinorFormattingLoss, WarningSource.Html, description));
		}
	}
}
