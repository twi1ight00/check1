using Aspose.Words.Tables;
using x1a3e96f4b89a7a77;
using x381fb081d11d6275;
using x461bbf0a821e3c87;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xdbe3cd173bd00464;

internal class xfdd04628da146b1d : x404be4b8fc06bce3
{
	private readonly x873451caae5ad4ae x800085dd555f7711;

	internal xfdd04628da146b1d(x873451caae5ad4ae builder)
		: base(documentFragmentSaving: false)
	{
		x800085dd555f7711 = builder;
	}

	protected override void WriteTableStartCore(Table table)
	{
		x800085dd555f7711.x2307058321cdb62f("Table");
		xc946ba15e395060e.xf36e6c2240ea983f(x800085dd555f7711, table);
		x910bdb0434a66722();
		x800085dd555f7711.x2307058321cdb62f("TableRowGroup");
	}

	protected override void WriteTableEndCore(Table table)
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	protected override void WirteRowStartCore(Row row)
	{
		x800085dd555f7711.x2307058321cdb62f("TableRow");
	}

	protected override void WriteRowEndCore(Row row)
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	protected override void WriteCellStartCore(bool isHeadingRow)
	{
		x800085dd555f7711.x2307058321cdb62f("TableCell");
		x9546c9d5ffe8dc51 x1d23559baf0e = base.xa977a609842fa6d2.x1d23559baf0e4415;
		if (x1d23559baf0e.x2f4795c5e4c1617e > 1)
		{
			x800085dd555f7711.x943f6be3acf634db("ColumnSpan", x1d23559baf0e.x2f4795c5e4c1617e);
		}
		if (x1d23559baf0e.xe9fd99df52338f59 > 1)
		{
			x800085dd555f7711.x943f6be3acf634db("RowSpan", x1d23559baf0e.xe9fd99df52338f59);
		}
		xc946ba15e395060e.xf9cf13cc959f2cbb(x800085dd555f7711, x1d23559baf0e.xf8cef531dae89ea3);
	}

	protected override void WriteCellEndCore()
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void x910bdb0434a66722()
	{
		x800085dd555f7711.x2307058321cdb62f("Table.Columns");
		for (int i = 0; i < base.xa977a609842fa6d2.x5840ec53f70adb17; i++)
		{
			x800085dd555f7711.x2307058321cdb62f("TableColumn");
			x800085dd555f7711.x943f6be3acf634db("Width", $"{xca004f56614e2431.xdbca7a004e2d3753(x4574ea26106f0edb.x0e1fdb362561ddb2(base.xa977a609842fa6d2.x3a2949e4f384d864(i)))}pt");
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
	}
}
