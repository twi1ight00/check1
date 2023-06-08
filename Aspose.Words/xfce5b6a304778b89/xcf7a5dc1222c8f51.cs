using Aspose.Words;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xfce5b6a304778b89;

internal class xcf7a5dc1222c8f51
{
	private xcf7a5dc1222c8f51()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf)
	{
		x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf, null);
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, xc559a3dd8354bcaa xe3b41c7c24db27bf)
	{
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
		xf55f5943200bd313(xe134235b3526fa75);
		xc559a3dd8354bcaa xc559a3dd8354bcaa2 = (xc559a3dd8354bcaa)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, "table", xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
		if (xc559a3dd8354bcaa2 == null)
		{
			xc559a3dd8354bcaa2 = xe3b41c7c24db27bf;
		}
		if (xc559a3dd8354bcaa2 == null)
		{
			xc559a3dd8354bcaa2 = new xc559a3dd8354bcaa();
		}
		x30d3766026a936d9 x30d3766026a936d10 = new x30d3766026a936d9();
		x1b38a0318d41d5d8(xe134235b3526fa75, xc559a3dd8354bcaa2, x30d3766026a936d10);
		x30d3766026a936d10.x1a1dda35b3ae703d();
		Table newChild = x1b9e7889d151bfc2(xe134235b3526fa75, xc559a3dd8354bcaa2, x30d3766026a936d10);
		if (x8b2c3c076d5a7daf.LastChild is Table)
		{
			x8b2c3c076d5a7daf.AppendChild(x52c356300fe97d22(xe134235b3526fa75.x2c8c6741422a1298));
		}
		x8b2c3c076d5a7daf.AppendChild(newChild);
	}

	private static Paragraph x52c356300fe97d22(DocumentBase x6beba47238e0ade6)
	{
		Paragraph paragraph = new Paragraph(x6beba47238e0ade6);
		paragraph.x344511c4e4ce09da.x96e55b5d052d1279 = x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
		return paragraph;
	}

	private static Table x1b9e7889d151bfc2(xf871da68decec406 xe134235b3526fa75, xc559a3dd8354bcaa x44ecfea61c937b8e, x30d3766026a936d9 x1a3e1a5d7fe6a20f)
	{
		Table table = new Table(xe134235b3526fa75.x2c8c6741422a1298);
		int num = xcf07032d01046819(xe134235b3526fa75, x44ecfea61c937b8e, x1a3e1a5d7fe6a20f);
		foreach (xc54ca6df458adfc5 item in x1a3e1a5d7fe6a20f)
		{
			Cell cell = new Cell(xe134235b3526fa75.x2c8c6741422a1298);
			Row row = null;
			if (table.FirstRow != null)
			{
				row = table.LastRow;
				cell = row.FirstCell;
			}
			table.AppendChild(new Row(xe134235b3526fa75.x2c8c6741422a1298, item.xedb0eb766e25e0c9));
			for (int i = 0; i < item.Count; i++)
			{
				xcb27402694ec8794 xcb27402694ec8795 = item.get_xe6d4b1b411ed94b5(i);
				if (xcb27402694ec8795.x11db8fc7f469a2fc == null)
				{
					xcb27402694ec8795.x11db8fc7f469a2fc = (Cell)cell.Clone(isCloneChildren: false);
					if (xcb27402694ec8795.x1a1dda35b3ae703d == CellMerge.Previous && row != null && row.Cells[i] != null)
					{
						xcb27402694ec8795.x11db8fc7f469a2fc.xf8cef531dae89ea3.x921a6336ff3c4dd3(PreferredWidth.xf6bcf515ffcb5cc9(row.Cells[i].xf8cef531dae89ea3.xdc1bf80853046136));
					}
					if (xcb27402694ec8795.x338a5e6ab7c5595e == CellMerge.Previous)
					{
						xcb27402694ec8795.x11db8fc7f469a2fc.xf8cef531dae89ea3.x921a6336ff3c4dd3(PreferredWidth.xf6bcf515ffcb5cc9(0));
					}
				}
				else if (xcb27402694ec8795.x338a5e6ab7c5595e != CellMerge.Previous)
				{
					int num2 = 0;
					for (int j = 0; j < xcb27402694ec8795.x2f4795c5e4c1617e; j++)
					{
						if (x44ecfea61c937b8e != null && i + j < x44ecfea61c937b8e.xc3f79a5f92dfdcee.Count)
						{
							x68feb341faa622d7 x68feb341faa622d8 = x44ecfea61c937b8e.xc3f79a5f92dfdcee.get_xe6d4b1b411ed94b5(i + j);
							if (x68feb341faa622d8 != null)
							{
								num2 += ((x68feb341faa622d8.x884d3da464d53ce7 == int.MinValue) ? num : x68feb341faa622d8.x884d3da464d53ce7);
							}
						}
					}
					xcb27402694ec8795.x11db8fc7f469a2fc.xf8cef531dae89ea3.x921a6336ff3c4dd3(PreferredWidth.xf6bcf515ffcb5cc9(num2));
				}
				xcb27402694ec8795.x11db8fc7f469a2fc.xf8cef531dae89ea3.x338a5e6ab7c5595e = xcb27402694ec8795.x338a5e6ab7c5595e;
				xcb27402694ec8795.x11db8fc7f469a2fc.xf8cef531dae89ea3.x1a1dda35b3ae703d = xcb27402694ec8795.x1a1dda35b3ae703d;
				table.LastRow.Cells.Add(xcb27402694ec8795.x11db8fc7f469a2fc);
				cell = xcb27402694ec8795.x11db8fc7f469a2fc;
			}
			if (item.get_xe6d4b1b411ed94b5(0).x1a1dda35b3ae703d == CellMerge.Previous && row != null)
			{
				table.LastRow.xedb0eb766e25e0c9.xc0741c7ff92cf1aa = row.xedb0eb766e25e0c9.xc0741c7ff92cf1aa;
			}
			for (int k = 1; k < item.x01e90984b4ad143d; k++)
			{
				table.AppendChild(table.LastRow.Clone(isCloneChildren: true));
			}
		}
		if (x44ecfea61c937b8e != null)
		{
			switch (x44ecfea61c937b8e.x28e5011224ac892b)
			{
			case "rl-tb":
				table.Bidi = true;
				break;
			case "lr-tb":
				table.Bidi = false;
				break;
			}
			table.Alignment = x44ecfea61c937b8e.x458cae322037b237;
		}
		if (x44ecfea61c937b8e != null && x44ecfea61c937b8e.xdc1bf80853046136 != int.MinValue)
		{
			table.PreferredWidth = PreferredWidth.xf6bcf515ffcb5cc9(x44ecfea61c937b8e.xdc1bf80853046136);
		}
		return table;
	}

	private static int xcf07032d01046819(xf871da68decec406 xe134235b3526fa75, xc559a3dd8354bcaa x44ecfea61c937b8e, x30d3766026a936d9 x1a3e1a5d7fe6a20f)
	{
		int result = 0;
		x899ab188166aec2d x899ab188166aec2d2 = x78ad567c64a94dad.x4098110b0f5e24b2(xe134235b3526fa75, xe134235b3526fa75.x071d9b5ee3757e23, xe134235b3526fa75.xcf39848e8372bf94);
		if (x899ab188166aec2d2 != null)
		{
			int num = x4574ea26106f0edb.x88bf16f2386d633e(x899ab188166aec2d2.x10d7a1cae426b158.PageSetup.x887b872a95caaab5);
			int num2 = 0;
			int num3 = 0;
			if (x44ecfea61c937b8e != null)
			{
				int num4 = ((x44ecfea61c937b8e.xdc1bf80853046136 == int.MinValue) ? num : x44ecfea61c937b8e.xdc1bf80853046136);
				foreach (x68feb341faa622d7 item in x44ecfea61c937b8e.xc3f79a5f92dfdcee)
				{
					if (item.x884d3da464d53ce7 == int.MinValue)
					{
						num2++;
					}
					else
					{
						num3 += item.x884d3da464d53ce7;
					}
				}
				if (x1a3e1a5d7fe6a20f.x5840ec53f70adb17 > x44ecfea61c937b8e.xc3f79a5f92dfdcee.Count)
				{
					num2 += x1a3e1a5d7fe6a20f.x5840ec53f70adb17 - x44ecfea61c937b8e.xc3f79a5f92dfdcee.Count;
				}
				if (num2 > 0)
				{
					result = (num4 - num3) / num2;
				}
			}
		}
		return result;
	}

	private static void xf55f5943200bd313(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			xe134235b3526fa75.x81c468031b83f5fc(xca994afbcb9073a);
		}
	}

	private static void x1b38a0318d41d5d8(xf871da68decec406 xe134235b3526fa75, xc559a3dd8354bcaa x44ecfea61c937b8e, x30d3766026a936d9 x1a3e1a5d7fe6a20f)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("table"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "table-column":
				x77975c78df984015.x06b0e25aa6ad68a9(xe134235b3526fa75, x44ecfea61c937b8e);
				break;
			case "table-columns":
				x03b6e1ba6b924b9b(xe134235b3526fa75, x44ecfea61c937b8e);
				break;
			case "table-row":
				xbcc3bb514122311a.x06b0e25aa6ad68a9(xe134235b3526fa75, x1a3e1a5d7fe6a20f, x44ecfea61c937b8e);
				break;
			case "table-rows":
				x832e947614b5353a(xe134235b3526fa75, x1a3e1a5d7fe6a20f, x44ecfea61c937b8e);
				break;
			case "table-header-rows":
				x3b8e0b4460d55405(xe134235b3526fa75, x44ecfea61c937b8e, x1a3e1a5d7fe6a20f);
				break;
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
	}

	private static void x03b6e1ba6b924b9b(xf871da68decec406 xe134235b3526fa75, xc559a3dd8354bcaa x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("table-columns"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "table-column")
			{
				x77975c78df984015.x06b0e25aa6ad68a9(xe134235b3526fa75, x44ecfea61c937b8e);
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}

	private static void x832e947614b5353a(xf871da68decec406 xe134235b3526fa75, x30d3766026a936d9 x1a3e1a5d7fe6a20f, xc559a3dd8354bcaa x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("table-rows"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "table-row")
			{
				xbcc3bb514122311a.x06b0e25aa6ad68a9(xe134235b3526fa75, x1a3e1a5d7fe6a20f, x44ecfea61c937b8e);
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}

	private static void x3b8e0b4460d55405(xf871da68decec406 xe134235b3526fa75, xc559a3dd8354bcaa x44ecfea61c937b8e, x30d3766026a936d9 x1a3e1a5d7fe6a20f)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("table-header-rows"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "table-row")
			{
				xbcc3bb514122311a.x06b0e25aa6ad68a9(xe134235b3526fa75, x1a3e1a5d7fe6a20f, x44ecfea61c937b8e, x59c6d00e0898f6b8: true);
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}
}
