using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x2697283ff424107e;
using x461bbf0a821e3c87;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;

namespace x7c4557e104065fc9;

internal class xbb04898cf6b5ed4f
{
	private xbb04898cf6b5ed4f()
	{
	}

	internal static void xc8a57043e4e79a44(string xa7505a15e36bfe1e, string xa96955581c5ee331, string x3a0bcc98e1d2f7c5, Cell xe6de5e5fa2d44af5)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = null;
		CellFormat cellFormat = xe6de5e5fa2d44af5.CellFormat;
		if (x0d299f323d241756.x5959bccb67bbf051(xa7505a15e36bfe1e))
		{
			xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6(xa7505a15e36bfe1e);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(xa96955581c5ee331) && xa96955581c5ee331 != xa7505a15e36bfe1e)
		{
			if (xa3fc7dcdc8182ff == null)
			{
				xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
			}
			x875d3ff2b165c336(xa3fc7dcdc8182ff, xa96955581c5ee331);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x3a0bcc98e1d2f7c5))
		{
			if (xa3fc7dcdc8182ff == null)
			{
				xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
			}
			x875d3ff2b165c336(xa3fc7dcdc8182ff, x3a0bcc98e1d2f7c5);
		}
		if (xa3fc7dcdc8182ff != null)
		{
			x30ff4cedcf2b2374.x1227cb7b82063569(xa3fc7dcdc8182ff, cellFormat.Borders);
			for (int i = 0; i < xa3fc7dcdc8182ff.xd44988f225497f3a; i++)
			{
				string x250224921a47c2f = xa3fc7dcdc8182ff.xf15263674eb297bb(i);
				xedac08b4826d3056 xf9eaf76facf8149b = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5(i);
				x7c4437f3bfddbe81(x250224921a47c2f, xf9eaf76facf8149b, xe6de5e5fa2d44af5);
			}
		}
	}

	private static void x875d3ff2b165c336(xa3fc7dcdc8182ff6 x6b8e154b42d5c1e3, string x337e217cb3ba0627)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6(x337e217cb3ba0627);
		for (int i = 0; i < xa3fc7dcdc8182ff.xd44988f225497f3a; i++)
		{
			string text = xa3fc7dcdc8182ff.xf15263674eb297bb(i).ToLower();
			xedac08b4826d3056 xbcea506a33cf = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5(i);
			if (text.StartsWith("border"))
			{
				x6b8e154b42d5c1e3.set_xe6d4b1b411ed94b5(text, xbcea506a33cf);
			}
		}
	}

	private static void x7c4437f3bfddbe81(string x250224921a47c2f5, xedac08b4826d3056 xf9eaf76facf8149b, Cell xe6de5e5fa2d44af5)
	{
		CellFormat cellFormat = xe6de5e5fa2d44af5.CellFormat;
		switch (x250224921a47c2f5)
		{
		case "width":
		{
			PreferredWidth preferredWidth = xa4ddfbb651452693(xf9eaf76facf8149b);
			if (preferredWidth != null)
			{
				cellFormat.PreferredWidth = preferredWidth;
			}
			break;
		}
		case "vertical-align":
			cellFormat.VerticalAlignment = x495fdb45f3d92b70.xc6376d756fb42f0f(xf9eaf76facf8149b.x48112399d54b30c7());
			break;
		case "padding":
		{
			x60b7a505461a80e7 x60b7a505461a80e = new x60b7a505461a80e7(xf9eaf76facf8149b);
			x7c4437f3bfddbe81("padding-left", x60b7a505461a80e.x72d92bd1aff02e37, xe6de5e5fa2d44af5);
			x7c4437f3bfddbe81("padding-right", x60b7a505461a80e.x419ba17a5322627b, xe6de5e5fa2d44af5);
			x7c4437f3bfddbe81("padding-top", x60b7a505461a80e.xe360b1885d8d4a41, xe6de5e5fa2d44af5);
			x7c4437f3bfddbe81("padding-bottom", x60b7a505461a80e.x9bcb07e204e30218, xe6de5e5fa2d44af5);
			break;
		}
		case "padding-left":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				cellFormat.LeftPadding = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			break;
		case "padding-right":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				cellFormat.RightPadding = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			break;
		case "padding-top":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				cellFormat.TopPadding = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			break;
		case "padding-bottom":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				cellFormat.BottomPadding = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			break;
		case "writing-mode":
			cellFormat.Orientation = x015eb412e40a664b.xca7f875a1e6fc583(xf9eaf76facf8149b.x48112399d54b30c7());
			break;
		default:
		{
			Shading shading = new Shading();
			x4ce5248b91d2fbf7.x6392b9ac6bc562f4(x250224921a47c2f5, xf9eaf76facf8149b, shading);
			if (shading.xa853df7acdb217c8)
			{
				xe6de5e5fa2d44af5.xf8cef531dae89ea3.x554aca059bdf6d48 = shading;
			}
			break;
		}
		}
	}

	internal static string x2f927a70e85f8dee(x9546c9d5ffe8dc51 xe6de5e5fa2d44af5, HtmlElementSizeOutputMode xb2ee1bebf5111a7c)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		xf8cef531dae89ea3 xf8cef531dae89ea = xe6de5e5fa2d44af5.xf8cef531dae89ea3;
		if (xe6de5e5fa2d44af5.x2f4795c5e4c1617e == 1)
		{
			xacc1cfb5517e4dab(xa3fc7dcdc8182ff, "width", xf8cef531dae89ea.xce5b83b714f11fba, xb2ee1bebf5111a7c);
		}
		xa3fc7dcdc8182ff.xf0ca15702ca7498c("vertical-align", x495fdb45f3d92b70.x4c48d7d9054ce462(xf8cef531dae89ea.xf6ce0e8106e6a1d8));
		x6f3c598e0f11fab2(x4574ea26106f0edb.x0e1fdb362561ddb2(xf8cef531dae89ea.xdf2361611d684889), x4574ea26106f0edb.x0e1fdb362561ddb2(xf8cef531dae89ea.x41c99cca24bc80be), x4574ea26106f0edb.x0e1fdb362561ddb2(xf8cef531dae89ea.x425c70a737882333), x4574ea26106f0edb.x0e1fdb362561ddb2(xf8cef531dae89ea.xcad2e59522947ede), xa3fc7dcdc8182ff);
		x4ce5248b91d2fbf7.xdd58192800f83cee(xf8cef531dae89ea.x554aca059bdf6d48, xa3fc7dcdc8182ff);
		x30ff4cedcf2b2374.xa95bac7421a1a927(xa3fc7dcdc8182ff, xf8cef531dae89ea.xa8c2637cc4888928, xf8cef531dae89ea.xaea087ab32102492, xf8cef531dae89ea.x79d902473861f242, xf8cef531dae89ea.xd7a21e27974f626c, x82fdb3b4231a1374: false);
		if (xf8cef531dae89ea.x2c5926113e101674 != 0)
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("writing-mode", x015eb412e40a664b.x142e13c6dfd73e82(xf8cef531dae89ea.x2c5926113e101674));
		}
		return xa3fc7dcdc8182ff.x9a706f5d15bd6d95(xb39cf349cb3e0d91: false);
	}

	internal static void xf2f6387c918f554c(string xa7505a15e36bfe1e, Row xa806b754814b9ae0)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xa7505a15e36bfe1e))
		{
			xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6(xa7505a15e36bfe1e);
			for (int i = 0; i < xa3fc7dcdc8182ff.xd44988f225497f3a; i++)
			{
				string x250224921a47c2f = xa3fc7dcdc8182ff.xf15263674eb297bb(i);
				xedac08b4826d3056 xf9eaf76facf8149b = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5(i);
				xc483dcc0d7f80f3c(x250224921a47c2f, xf9eaf76facf8149b, xa806b754814b9ae0);
			}
		}
	}

	private static void xc483dcc0d7f80f3c(string x250224921a47c2f5, xedac08b4826d3056 xf9eaf76facf8149b, Row xa806b754814b9ae0)
	{
		RowFormat rowFormat = xa806b754814b9ae0.RowFormat;
		switch (x250224921a47c2f5)
		{
		case "height":
			if (xf9eaf76facf8149b.xf0505571a3039b0a)
			{
				rowFormat.Height = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
				rowFormat.HeightRule = HeightRule.AtLeast;
			}
			break;
		case "background":
		{
			Shading shading = new Shading();
			x4ce5248b91d2fbf7.x6392b9ac6bc562f4(x250224921a47c2f5, xf9eaf76facf8149b, shading);
			if (!shading.xa853df7acdb217c8)
			{
				break;
			}
			{
				foreach (Cell cell in xa806b754814b9ae0.Cells)
				{
					if (!cell.xf8cef531dae89ea3.x263d579af1d0d43f(3170))
					{
						cell.xf8cef531dae89ea3.x554aca059bdf6d48 = shading.x8b61531c8ea35b85();
					}
				}
				break;
			}
		}
		}
	}

	internal static string x86e41577fe04ea49(RowFormat x5786461d089b10a0)
	{
		if (x5786461d089b10a0.HeightRule == HeightRule.Auto)
		{
			return string.Empty;
		}
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		xa3fc7dcdc8182ff.xd6d0700e6673d965("height", x5786461d089b10a0.Height, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		return xa3fc7dcdc8182ff.x9a706f5d15bd6d95(xb39cf349cb3e0d91: false);
	}

	internal static void xd630de9b41e9eba0(string xa7505a15e36bfe1e, Table x1ec770899c98a268)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xa7505a15e36bfe1e))
		{
			return;
		}
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6(xa7505a15e36bfe1e);
		for (int i = 0; i < xa3fc7dcdc8182ff.xd44988f225497f3a; i++)
		{
			string text = xa3fc7dcdc8182ff.xf15263674eb297bb(i);
			xedac08b4826d3056 xedac08b4826d = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5(i);
			switch (text)
			{
			case "width":
			{
				PreferredWidth preferredWidth = xa4ddfbb651452693(xedac08b4826d);
				if (preferredWidth != null)
				{
					x1ec770899c98a268.PreferredWidth = preferredWidth;
				}
				break;
			}
			case "margin-left":
				xedac08b4826d.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
				x1ec770899c98a268.LeftIndent = xedac08b4826d.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
				break;
			case "background":
			{
				Shading shading = new Shading();
				x4ce5248b91d2fbf7.x6392b9ac6bc562f4(text, xedac08b4826d, shading);
				if (!shading.xa853df7acdb217c8)
				{
					break;
				}
				foreach (Row row in x1ec770899c98a268.Rows)
				{
					row.xedb0eb766e25e0c9.x554aca059bdf6d48 = shading.x8b61531c8ea35b85();
					foreach (Cell cell in row.Cells)
					{
						if (!cell.xf8cef531dae89ea3.x263d579af1d0d43f(3170))
						{
							cell.xf8cef531dae89ea3.x554aca059bdf6d48 = shading.x8b61531c8ea35b85();
						}
					}
				}
				break;
			}
			}
		}
	}

	internal static string x0453fd62c41d85e6(Table x1ec770899c98a268, double xc790aa4ad151a9a1, HtmlElementSizeOutputMode xb2ee1bebf5111a7c)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		xacc1cfb5517e4dab(xa3fc7dcdc8182ff, "width", x1ec770899c98a268.PreferredWidth, xb2ee1bebf5111a7c);
		xedb0eb766e25e0c9 xedb0eb766e25e0c = x1ec770899c98a268.FirstRow.xedb0eb766e25e0c9;
		if (xedb0eb766e25e0c.xef633558eb57057f || xedb0eb766e25e0c.xee8dbcbd77a95107)
		{
			bool flag = xedb0eb766e25e0c.xab67cb9464a3325b == HorizontalAlignment.Right;
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("float", flag ? "right" : "left");
			double xa447fc54e41dfe = x4574ea26106f0edb.x0e1fdb362561ddb2(xedb0eb766e25e0c.xa969046621885079);
			double xfc2074a859a5db8c = x4574ea26106f0edb.x0e1fdb362561ddb2(xedb0eb766e25e0c.xed2cdaa11f36a285);
			double xc941868c59399d3e = x4574ea26106f0edb.x0e1fdb362561ddb2(xedb0eb766e25e0c.x6cfd6e2112311aa3);
			double xaf9a0436a70689de = x4574ea26106f0edb.x0e1fdb362561ddb2(xedb0eb766e25e0c.x48c52a4f08a214a2);
			xa3fc7dcdc8182ff.xfd7a4669c14e659a("margin", xc941868c59399d3e, xfc2074a859a5db8c, xaf9a0436a70689de, xa447fc54e41dfe, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
		else
		{
			switch (xedb0eb766e25e0c.x9ba359ff37a3a63b)
			{
			case TableAlignment.Left:
				xa3fc7dcdc8182ff.xd6d0700e6673d965("margin-left", xc790aa4ad151a9a1, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
				break;
			case TableAlignment.Center:
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("margin", "0 auto");
				break;
			case TableAlignment.Right:
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("margin", "0 0 0 auto");
				break;
			}
		}
		xa3fc7dcdc8182ff.xf0ca15702ca7498c("border-collapse", "collapse");
		return xa3fc7dcdc8182ff.x9a706f5d15bd6d95(xb39cf349cb3e0d91: false);
	}

	private static void xacc1cfb5517e4dab(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, string xc15bd84e01929885, PreferredWidth x961016a387451f05, HtmlElementSizeOutputMode xb2ee1bebf5111a7c)
	{
		switch (x961016a387451f05.Type)
		{
		case PreferredWidthType.Points:
			if (xb2ee1bebf5111a7c == HtmlElementSizeOutputMode.All)
			{
				x44ecfea61c937b8e.xd6d0700e6673d965(xc15bd84e01929885, x961016a387451f05.Value, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			break;
		case PreferredWidthType.Percent:
			if (xb2ee1bebf5111a7c != HtmlElementSizeOutputMode.None)
			{
				x44ecfea61c937b8e.xb2275198aa955331(xc15bd84e01929885, x961016a387451f05.Value);
			}
			break;
		}
	}

	private static PreferredWidth xa4ddfbb651452693(xedac08b4826d3056 xf9eaf76facf8149b)
	{
		PreferredWidth result = null;
		switch (xf9eaf76facf8149b.x73cad9ab753bf0fa)
		{
		case x1e40528755c1f053.x8c0d22e4c133799d:
		case x1e40528755c1f053.x1be93eed8950d961:
		{
			double num2 = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			if (num2 >= 0.0)
			{
				result = PreferredWidth.xb6bb25492776965a(num2);
			}
			break;
		}
		case x1e40528755c1f053.x2f7951fa0946af7e:
		{
			double num = xf9eaf76facf8149b.x043aafba68f5c559();
			if (num >= 0.0)
			{
				result = PreferredWidth.xb4e521ca3a7fd077(num);
			}
			break;
		}
		}
		return result;
	}

	private static void x6f3c598e0f11fab2(double xc941868c59399d3e, double xfc2074a859a5db8c, double xaf9a0436a70689de, double xa447fc54e41dfe06, xa3fc7dcdc8182ff6 x36c843bef78b260f)
	{
		bool flag = xc941868c59399d3e != 0.0;
		bool flag2 = xfc2074a859a5db8c != 0.0;
		bool flag3 = xaf9a0436a70689de != 0.0;
		bool flag4 = xa447fc54e41dfe06 != 0.0;
		if (flag && flag2 && flag3 && flag4)
		{
			x36c843bef78b260f.xfd7a4669c14e659a("padding", xc941868c59399d3e, xfc2074a859a5db8c, xaf9a0436a70689de, xa447fc54e41dfe06, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			return;
		}
		if (flag)
		{
			x36c843bef78b260f.xd6d0700e6673d965("padding-top", xc941868c59399d3e, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
		if (flag2)
		{
			x36c843bef78b260f.xd6d0700e6673d965("padding-right", xfc2074a859a5db8c, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
		if (flag3)
		{
			x36c843bef78b260f.xd6d0700e6673d965("padding-bottom", xaf9a0436a70689de, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
		if (flag4)
		{
			x36c843bef78b260f.xd6d0700e6673d965("padding-left", xa447fc54e41dfe06, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
	}
}
