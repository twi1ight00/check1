using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using x461bbf0a821e3c87;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xa2462df43988ffad;

internal class xb445834e58f7e37d
{
	private int xc4a92ea4e5bf9008;

	private readonly Stack x20797511428da916 = new Stack();

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private readonly Stack x27b42f375c6ab29f = new Stack();

	private readonly x560f0e9efcf5b9b1 x6962cbeae4129aa3;

	private x9c0f421e2823a37c xa977a609842fa6d2 => x27b42f375c6ab29f.Peek() as x9c0f421e2823a37c;

	internal xb445834e58f7e37d(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x6962cbeae4129aa3 = new x560f0e9efcf5b9b1(x9b287b671d592594);
	}

	internal VisitorAction xe35e18fbd2d5ad9e(Table x1ec770899c98a268)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (!x1ec770899c98a268.HasChildNodes)
		{
			x9b287b671d592594.x3460ec740e098e72(x1ec770899c98a268, null);
			return VisitorAction.SkipThisNode;
		}
		x27b42f375c6ab29f.Push(new x9c0f421e2823a37c(x1ec770899c98a268, resolveInheritedBorders: true, populateEmptyPadBorders: false, resolveInheritedPaddings: false));
		if (x876ab05b0e88fa26(x1ec770899c98a268))
		{
			return VisitorAction.Continue;
		}
		xa977a609842fa6d2.x550f875a2eea9b05();
		int[] array = xa977a609842fa6d2.x65afe16d1469539e();
		string xbcea506a33cf = xbb857c9fc36f5054.xf7c347cb12d2a63f(xa977a609842fa6d2.xa672f280367330ca);
		if (x9b287b671d592594.xb872fbc83a2cb9a6)
		{
			x6962cbeae4129aa3.x7836b37ea6311ff0(x220451a363c96b06(), "table");
			x6962cbeae4129aa3.xae77568195671cdc(x04e94399655d8f62: false, x4520f9b08f5a50d7: true);
			xe1410f585439c7d.x2307058321cdb62f("style:table-properties");
			xe1410f585439c7d.x943f6be3acf634db("table:align", x0eb9a864413f34de.x06fbbca8012f5070(x1ec770899c98a268.Alignment));
			xe1410f585439c7d.x943f6be3acf634db("style:width", xbcea506a33cf);
			xe1410f585439c7d.x943f6be3acf634db("fo:margin-left", x86721851b92a2dca());
			object obj = x1ec770899c98a268.FirstRow.xedb0eb766e25e0c9.xf7866f89640a29a3(4380);
			if (obj != null)
			{
				xe1410f585439c7d.x943f6be3acf634db("style:writing-mode", ((bool)obj) ? "rl-tb" : "lr-tb");
			}
			xe1410f585439c7d.x2dfde153f4ef96d0("style:table-properties");
			xe1410f585439c7d.x2dfde153f4ef96d0("style:style");
			for (int i = 0; i < array.Length; i++)
			{
				x6962cbeae4129aa3.x7836b37ea6311ff0(xf20386baf8f7504e(), "table-column");
				xe1410f585439c7d.xc049ea80ee267201("style:table-column-properties", "style:column-width", xbb857c9fc36f5054.xf7c347cb12d2a63f(array[i]));
				xe1410f585439c7d.x2dfde153f4ef96d0("style:style");
			}
		}
		if (x9b287b671d592594.x6c4e1bc3d49e75d1)
		{
			if (x1ec770899c98a268.x752cfab9af626fd5)
			{
				x20797511428da916.Push(xc4a92ea4e5bf9008);
			}
			xe1410f585439c7d.x2307058321cdb62f("table:table");
			xe1410f585439c7d.x943f6be3acf634db("table:style-name", x220451a363c96b06());
			for (int j = 0; j < array.Length; j++)
			{
				xe1410f585439c7d.xc049ea80ee267201("table:table-column", "table:style-name", xf20386baf8f7504e());
			}
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction x49cd8bac108971e1(Table x1ec770899c98a268)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		if (!x876ab05b0e88fa26(x1ec770899c98a268) && x9b287b671d592594.x6c4e1bc3d49e75d1)
		{
			x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0("table:table");
			if (x1ec770899c98a268.x752cfab9af626fd5)
			{
				xc4a92ea4e5bf9008 = (int)x20797511428da916.Pop();
			}
		}
		x27b42f375c6ab29f.Pop();
		x9b287b671d592594.x3460ec740e098e72(x1ec770899c98a268, null);
		return VisitorAction.Continue;
	}

	internal VisitorAction xf7a3d740c38d9959(Row xa806b754814b9ae0)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		xc4a92ea4e5bf9008 = 0;
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (x876ab05b0e88fa26(xa806b754814b9ae0.ParentTable))
		{
			return VisitorAction.Continue;
		}
		xa977a609842fa6d2.xbeec4ad54bcadf05();
		if (x9b287b671d592594.xb872fbc83a2cb9a6)
		{
			x6962cbeae4129aa3.x7836b37ea6311ff0(x9d3ac365c75d17f8(), "table-row");
			if ((xa806b754814b9ae0.xedb0eb766e25e0c9.xdc39376725eb2ee7(4120) != null && xa806b754814b9ae0.xedb0eb766e25e0c9.x85e9ab4255d7e70c != HeightRule.Auto) || !xa806b754814b9ae0.xedb0eb766e25e0c9.xe794ac9dda37b8a8)
			{
				xe1410f585439c7d.x2307058321cdb62f("style:table-row-properties");
				if (xa806b754814b9ae0.xedb0eb766e25e0c9.xdc39376725eb2ee7(4120) != null)
				{
					if (xa806b754814b9ae0.xedb0eb766e25e0c9.x85e9ab4255d7e70c == HeightRule.Exactly)
					{
						xe1410f585439c7d.x943f6be3acf634db("style:row-height", xbb857c9fc36f5054.xf7c347cb12d2a63f(xa806b754814b9ae0.xedb0eb766e25e0c9.xb0f146032f47c24e));
					}
					else if (xa806b754814b9ae0.xedb0eb766e25e0c9.x85e9ab4255d7e70c == HeightRule.AtLeast)
					{
						xe1410f585439c7d.x943f6be3acf634db("style:min-row-height", xbb857c9fc36f5054.xf7c347cb12d2a63f(xa806b754814b9ae0.xedb0eb766e25e0c9.xb0f146032f47c24e));
					}
				}
				if (!xa806b754814b9ae0.xedb0eb766e25e0c9.xe794ac9dda37b8a8)
				{
					xe1410f585439c7d.x943f6be3acf634db("fo:keep-together", "always");
				}
				xe1410f585439c7d.x2dfde153f4ef96d0("style:table-row-properties");
			}
			xe1410f585439c7d.x2dfde153f4ef96d0("style:style");
		}
		if (x9b287b671d592594.x6c4e1bc3d49e75d1)
		{
			if (xa806b754814b9ae0.xedb0eb766e25e0c9.xfb66190d5f2f66ce)
			{
				xe1410f585439c7d.x2307058321cdb62f("table:table-header-rows");
			}
			xe1410f585439c7d.x2307058321cdb62f("table:table-row");
			xe1410f585439c7d.x943f6be3acf634db("table:style-name", x9d3ac365c75d17f8());
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction x73486983017b4ba2(Row xa806b754814b9ae0)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (!x876ab05b0e88fa26(xa806b754814b9ae0.ParentTable) && x9b287b671d592594.x6c4e1bc3d49e75d1)
		{
			if (xc4a92ea4e5bf9008 == 0)
			{
				for (int i = 0; i < xa977a609842fa6d2.x5840ec53f70adb17; i++)
				{
					xe1410f585439c7d.xf68f9c3818e1f4b1("table:covered-table-cell");
				}
			}
			xe1410f585439c7d.x2dfde153f4ef96d0("table:table-row");
			if (xa806b754814b9ae0.xedb0eb766e25e0c9.xfb66190d5f2f66ce)
			{
				xe1410f585439c7d.x2dfde153f4ef96d0("table:table-header-rows");
			}
		}
		xa977a609842fa6d2.xc42fc0160c161943();
		x9b287b671d592594.x3460ec740e098e72(xa806b754814b9ae0, null);
		return VisitorAction.Continue;
	}

	internal VisitorAction x37f46648998425f0(Cell xe6de5e5fa2d44af5)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (x876ab05b0e88fa26(xe6de5e5fa2d44af5.x133f2db9e5b5690d))
		{
			return VisitorAction.Continue;
		}
		if (xe6de5e5fa2d44af5.xf8cef531dae89ea3.x61127d98597c4898)
		{
			return VisitorAction.SkipThisNode;
		}
		if (x9b287b671d592594.xb872fbc83a2cb9a6)
		{
			x6962cbeae4129aa3.x7836b37ea6311ff0(xfc81eea47b09fb45(), "table-cell");
			xd270c0d0dc0624b8 xd270c0d0dc0624b9 = new xd270c0d0dc0624b8(x9b287b671d592594);
			xd270c0d0dc0624b9.x6210059f049f0d48(xe6de5e5fa2d44af5);
			xe1410f585439c7d.x2dfde153f4ef96d0("style:style");
		}
		if (x9b287b671d592594.x6c4e1bc3d49e75d1 && xa977a609842fa6d2.x1d23559baf0e4415 != null)
		{
			xe1410f585439c7d.x2307058321cdb62f("table:table-cell");
			xc4a92ea4e5bf9008++;
			string xbcea506a33cf = xfc81eea47b09fb45();
			xe1410f585439c7d.x943f6be3acf634db("table:style-name", xbcea506a33cf);
			if (xa977a609842fa6d2.x1d23559baf0e4415.x2f4795c5e4c1617e > 1)
			{
				xe1410f585439c7d.x943f6be3acf634db("table:number-columns-spanned", xa977a609842fa6d2.x1d23559baf0e4415.x2f4795c5e4c1617e);
			}
			if (xa977a609842fa6d2.x1d23559baf0e4415.xe9fd99df52338f59 > 1)
			{
				xe1410f585439c7d.x943f6be3acf634db("table:number-rows-spanned", xa977a609842fa6d2.x1d23559baf0e4415.xe9fd99df52338f59);
			}
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction x60d13e8235b3d083(Cell xe6de5e5fa2d44af5)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (!x876ab05b0e88fa26(xe6de5e5fa2d44af5.x133f2db9e5b5690d) && x9b287b671d592594.x6c4e1bc3d49e75d1 && xa977a609842fa6d2.x1d23559baf0e4415 != null)
		{
			xe1410f585439c7d.x2dfde153f4ef96d0("table:table-cell");
		}
		xa977a609842fa6d2.x5d8b5df141c961ba();
		x9b287b671d592594.x3460ec740e098e72(xe6de5e5fa2d44af5, null);
		return VisitorAction.Continue;
	}

	internal string x220451a363c96b06()
	{
		x9b287b671d592594.xf6985ded5d8720ef++;
		return $"Table{x9b287b671d592594.xf6985ded5d8720ef}";
	}

	internal string xf20386baf8f7504e()
	{
		x9b287b671d592594.x59bc0096de497989++;
		return $"Column{x9b287b671d592594.x59bc0096de497989}";
	}

	internal string x9d3ac365c75d17f8()
	{
		x9b287b671d592594.x9b1baea4e485d168++;
		return $"Row{x9b287b671d592594.x9b1baea4e485d168}";
	}

	internal string xfc81eea47b09fb45()
	{
		x9b287b671d592594.xc4cd358aeebe0ff5++;
		return $"Cell{x9b287b671d592594.xc4cd358aeebe0ff5}";
	}

	private string x86721851b92a2dca()
	{
		switch (xa977a609842fa6d2.x3aafce4bafb29dc2.Alignment)
		{
		case TableAlignment.Center:
			return xbb857c9fc36f5054.xf7c347cb12d2a63f((x4574ea26106f0edb.x88bf16f2386d633e(xe839e5e4a4273bbe()) - xa977a609842fa6d2.xa672f280367330ca) / 2);
		case TableAlignment.Right:
			return xbb857c9fc36f5054.xf7c347cb12d2a63f(x4574ea26106f0edb.x88bf16f2386d633e(xe839e5e4a4273bbe()) - xa977a609842fa6d2.xa672f280367330ca);
		default:
		{
			Table x3aafce4bafb29dc = xa977a609842fa6d2.x3aafce4bafb29dc2;
			int num = int.MaxValue;
			for (Row row = x3aafce4bafb29dc.FirstRow; row != null; row = row.xebb8ac1152da9a1f)
			{
				num = Math.Min(row.xedb0eb766e25e0c9.xc0741c7ff92cf1aa, num);
			}
			return xbb857c9fc36f5054.xf7c347cb12d2a63f(num);
		}
		}
	}

	private double xe839e5e4a4273bbe()
	{
		Table x3aafce4bafb29dc = xa977a609842fa6d2.x3aafce4bafb29dc2;
		if (x3aafce4bafb29dc.xdfa6ecc6f742f086.NodeType == NodeType.Cell)
		{
			Cell cell = (Cell)xa977a609842fa6d2.x3aafce4bafb29dc2.xdfa6ecc6f742f086;
			CellFormat cellFormat = cell.CellFormat;
			return cellFormat.Width - cellFormat.LeftPadding - cellFormat.RightPadding;
		}
		Section section = (Section)x3aafce4bafb29dc.GetAncestor(NodeType.Section);
		while (section.PageSetup.SectionStart != SectionStart.NewPage && !section.x65c77554c620f590)
		{
			Node previousSibling = section.PreviousSibling;
			if (previousSibling != null && previousSibling is Section)
			{
				section = (Section)previousSibling;
			}
		}
		PageSetup pageSetup = section.PageSetup;
		double num = xbb857c9fc36f5054.x7ee6ab51d3d84831(3.0);
		if (section.xfc72d4c9b765cad7.x263d579af1d0d43f(2280))
		{
			num = pageSetup.LeftMargin;
		}
		double num2 = xbb857c9fc36f5054.x7ee6ab51d3d84831(1.499);
		if (section.xfc72d4c9b765cad7.x263d579af1d0d43f(2290))
		{
			num2 = pageSetup.RightMargin;
		}
		return pageSetup.PageWidth - num - num2;
	}

	private bool x876ab05b0e88fa26(Table x1ec770899c98a268)
	{
		bool flag = xdb0bf9f81de4b38c.xc8d1bb1390d5266d(x1ec770899c98a268);
		if (!x9b287b671d592594.x2b4379ecf88129a1 && ((x9b287b671d592594.x68e1404b914783c1 && flag) || ((x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x05a725d9893e5a35 || x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62af77d3c3af0871) && !flag)))
		{
			if (x1ec770899c98a268.ParentNode is Shape)
			{
				return x00718c1b6df413d3.xa3bfa3d00a716e76(x1ec770899c98a268.ParentNode as Shape);
			}
			return false;
		}
		return true;
	}
}
