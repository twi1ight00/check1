using System;
using Aspose.Words.Tables;
using x381fb081d11d6275;
using x461bbf0a821e3c87;
using x6c95d9cf46ff5f25;
using x7c4557e104065fc9;
using xf9a9481c3f63a419;

namespace xce0136f05681c5e9;

internal class x934b8a992f1985f7 : x404be4b8fc06bce3
{
	private readonly xe2ff3c3cd396cfd9 x18ddd758cd8495e3;

	private readonly x202941c978357b4f x7e0bc249ae734293;

	private readonly xe98f79ab11a30ea7 xbf77f1b25eb10db0;

	private readonly bool x35924913756fcc9e;

	private x515d2f71e3e1988e xe1410f585439c7d4 => x18ddd758cd8495e3.xe1410f585439c7d4;

	internal x934b8a992f1985f7(xe2ff3c3cd396cfd9 writerCommon, x202941c978357b4f styleWriter, xe98f79ab11a30ea7 i18nWriter, bool exportXhtmlTransitional, bool documentFragmentSaving)
		: base(documentFragmentSaving)
	{
		x18ddd758cd8495e3 = writerCommon;
		x7e0bc249ae734293 = styleWriter;
		xbf77f1b25eb10db0 = i18nWriter;
		x35924913756fcc9e = exportXhtmlTransitional;
	}

	protected override void WriteTableStartCore(Table table)
	{
		if (table.Alignment != 0 && !x35924913756fcc9e)
		{
			xe1410f585439c7d4.x2307058321cdb62f("div");
			xe1410f585439c7d4.x943f6be3acf634db("style", "text-align:" + x495fdb45f3d92b70.xf8b46c270d89b1c8(table.FirstRow.xedb0eb766e25e0c9.x9ba359ff37a3a63b));
		}
		xe1410f585439c7d4.x2307058321cdb62f("table");
		xe1410f585439c7d4.x55b893148f746a6f("cellspacing", 0);
		xe1410f585439c7d4.x55b893148f746a6f("cellpadding", 0);
		double x072a638ef82da = x4574ea26106f0edb.x0e1fdb362561ddb2(Math.Max(base.xa977a609842fa6d2.x10f006c778799280(0), 0));
		x7e0bc249ae734293.x746ca66f5c31e314(table, x072a638ef82da);
		xbf77f1b25eb10db0.xb63df339721c535a(table);
	}

	protected override void WriteTableEndCore(Table table)
	{
		xfab05c045fc0e8ac();
		xe1410f585439c7d4.x538f0e0fb2bf15ab();
		if (table.Alignment != 0 && !x35924913756fcc9e)
		{
			xe1410f585439c7d4.x538f0e0fb2bf15ab();
		}
	}

	protected override void WirteRowStartCore(Row row)
	{
		bool xfb66190d5f2f66ce = row.xedb0eb766e25e0c9.xfb66190d5f2f66ce;
		Row xc22e54d85f137f3e = row.xc22e54d85f137f3e;
		if (xfb66190d5f2f66ce)
		{
			if (xc22e54d85f137f3e == null)
			{
				xe1410f585439c7d4.x2307058321cdb62f("thead");
			}
			else if (!xc22e54d85f137f3e.xedb0eb766e25e0c9.xfb66190d5f2f66ce)
			{
				xfab05c045fc0e8ac();
				if (base.xa977a609842fa6d2.x0208a1cf186bdfeb)
				{
					xe1410f585439c7d4.x538f0e0fb2bf15ab();
				}
				xe1410f585439c7d4.x538f0e0fb2bf15ab();
				xe717a5a4daba5191(row.ParentTable);
				xe1410f585439c7d4.x2307058321cdb62f("thead");
			}
			base.xa977a609842fa6d2.x0208a1cf186bdfeb = true;
		}
		else if (base.xa977a609842fa6d2.x0208a1cf186bdfeb && xc22e54d85f137f3e != null && xc22e54d85f137f3e.xedb0eb766e25e0c9.xfb66190d5f2f66ce)
		{
			xe1410f585439c7d4.x2307058321cdb62f("tbody");
		}
		xe1410f585439c7d4.x2307058321cdb62f("tr");
		x7e0bc249ae734293.x47fedfe9a943719d(row);
	}

	protected override void WriteRowEndCore(Row row)
	{
		bool xfb66190d5f2f66ce = row.xedb0eb766e25e0c9.xfb66190d5f2f66ce;
		xe1410f585439c7d4.x538f0e0fb2bf15ab();
		Row xebb8ac1152da9a1f = row.xebb8ac1152da9a1f;
		if (xfb66190d5f2f66ce)
		{
			if (xebb8ac1152da9a1f == null || !xebb8ac1152da9a1f.xedb0eb766e25e0c9.xfb66190d5f2f66ce)
			{
				xe1410f585439c7d4.x538f0e0fb2bf15ab();
			}
		}
		else if (xebb8ac1152da9a1f == null && base.xa977a609842fa6d2.x0208a1cf186bdfeb)
		{
			xe1410f585439c7d4.x538f0e0fb2bf15ab();
		}
	}

	protected override void WriteCellStartCore(bool isHeadingRow)
	{
		xe1410f585439c7d4.x2307058321cdb62f(isHeadingRow ? "th" : "td");
		x9546c9d5ffe8dc51 x1d23559baf0e = base.xa977a609842fa6d2.x1d23559baf0e4415;
		xb308f607600a77ea("colspan", x1d23559baf0e.x2f4795c5e4c1617e);
		xb308f607600a77ea("rowspan", x1d23559baf0e.xe9fd99df52338f59);
		x7e0bc249ae734293.x1b6c90c46e2852e3(x1d23559baf0e);
	}

	protected override void WriteCellEndCore()
	{
		xe1410f585439c7d4.x538f0e0fb2bf15ab();
	}

	private void xb308f607600a77ea(string xb591dc602a67d872, int x929df9c320a602bc)
	{
		if (x929df9c320a602bc > 1)
		{
			xe1410f585439c7d4.x55b893148f746a6f(xb591dc602a67d872, x929df9c320a602bc);
		}
	}

	private void xfab05c045fc0e8ac()
	{
		if (base.xa977a609842fa6d2.x7e7b36d274a1403e)
		{
			xe1410f585439c7d4.xd52401bdf5aacef6("<!--[if !supportMisalignedColumns]>");
			xe1410f585439c7d4.x2307058321cdb62f("tr");
			xe1410f585439c7d4.xff520a0047c27122("style", "height:0pt");
			for (int i = 0; i < base.xa977a609842fa6d2.x5840ec53f70adb17; i++)
			{
				xe1410f585439c7d4.x2307058321cdb62f("td");
				xe1410f585439c7d4.xff520a0047c27122("style", $"width:{xca004f56614e2431.xdbca7a004e2d3753(x4574ea26106f0edb.x0e1fdb362561ddb2(base.xa977a609842fa6d2.x3a2949e4f384d864(i)))}pt; border:none");
				xe1410f585439c7d4.x538f0e0fb2bf15ab();
			}
			xe1410f585439c7d4.x538f0e0fb2bf15ab();
			xe1410f585439c7d4.xd52401bdf5aacef6("<![endif]-->");
		}
	}
}
