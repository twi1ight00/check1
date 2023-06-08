using System;
using System.Collections;
using Aspose;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x461bbf0a821e3c87;

namespace x381fb081d11d6275;

internal abstract class x404be4b8fc06bce3
{
	private readonly Stack x27b42f375c6ab29f;

	private readonly bool xb42f2f2b9987ee29;

	internal bool xf7499ae99c6308ad => x27b42f375c6ab29f.Count != 0;

	protected x9c0f421e2823a37c xa977a609842fa6d2 => (x9c0f421e2823a37c)x27b42f375c6ab29f.Peek();

	protected x404be4b8fc06bce3(bool documentFragmentSaving)
	{
		xb42f2f2b9987ee29 = documentFragmentSaving;
		x27b42f375c6ab29f = new Stack();
	}

	internal void xe717a5a4daba5191(Table x1ec770899c98a268)
	{
		x3da965c717d88445(x1ec770899c98a268);
		WriteTableStartCore(x1ec770899c98a268);
	}

	internal void xcaecd61600966f36(Table x1ec770899c98a268)
	{
		WriteTableEndCore(x1ec770899c98a268);
		x27b42f375c6ab29f.Pop();
	}

	internal void x48610c3e5cca6f3e(Row xa806b754814b9ae0)
	{
		if (x5d6b45b799d3b998(xa806b754814b9ae0))
		{
			x06cd654cc97ff192(xa806b754814b9ae0);
		}
		WirteRowStartCore(xa806b754814b9ae0);
		xa977a609842fa6d2.xbeec4ad54bcadf05();
		bool xfb66190d5f2f66ce = xa806b754814b9ae0.xedb0eb766e25e0c9.xfb66190d5f2f66ce;
		while (xa977a609842fa6d2.x1d23559baf0e4415 != null && xa977a609842fa6d2.x1d23559baf0e4415.xccc3088817e63d2c)
		{
			WriteCellStartCore(xfb66190d5f2f66ce);
			WriteCellEndCore();
			xa977a609842fa6d2.x5d8b5df141c961ba();
		}
	}

	internal void xd507f724ce92c500(Row xa806b754814b9ae0)
	{
		bool xfb66190d5f2f66ce = xa806b754814b9ae0.xedb0eb766e25e0c9.xfb66190d5f2f66ce;
		while (xa977a609842fa6d2.x1d23559baf0e4415 != null)
		{
			if (!xa977a609842fa6d2.x1d23559baf0e4415.xccc3088817e63d2c)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ooblobjldbamfahmaaomoafnmplnipcobljoopapmohpmoopfkfafomaeodbiokbfobcjoicdjpcpngdlnndgneeaolecjcf", 1852027305)));
			}
			WriteCellStartCore(xfb66190d5f2f66ce);
			WriteCellEndCore();
			xa977a609842fa6d2.x5d8b5df141c961ba();
		}
		WriteRowEndCore(xa806b754814b9ae0);
		xa977a609842fa6d2.xc42fc0160c161943();
	}

	internal void x30a57b87f2670c44(Cell xe6de5e5fa2d44af5)
	{
		if (xbd606b290349b4f1(xe6de5e5fa2d44af5))
		{
			xcf42c46a06c9d54f(xe6de5e5fa2d44af5);
		}
		WriteCellStartCore(xe6de5e5fa2d44af5.ParentRow.xedb0eb766e25e0c9.xfb66190d5f2f66ce);
	}

	internal void x191c57b612fc7df5()
	{
		WriteCellEndCore();
		xa977a609842fa6d2.x5d8b5df141c961ba();
	}

	[JavaThrows(true)]
	protected abstract void WriteTableStartCore(Table table);

	[JavaThrows(true)]
	protected abstract void WirteRowStartCore(Row row);

	[JavaThrows(true)]
	protected abstract void WriteRowEndCore(Row row);

	[JavaThrows(true)]
	protected abstract void WriteTableEndCore(Table table);

	[JavaThrows(true)]
	protected abstract void WriteCellEndCore();

	[JavaThrows(true)]
	protected abstract void WriteCellStartCore(bool isHeadingRow);

	private bool x5d6b45b799d3b998(Row xa806b754814b9ae0)
	{
		if (xb42f2f2b9987ee29)
		{
			if (xf7499ae99c6308ad)
			{
				return xa977a609842fa6d2.x3aafce4bafb29dc2 != xa806b754814b9ae0.ParentTable;
			}
			return true;
		}
		return false;
	}

	private void x06cd654cc97ff192(Row xa806b754814b9ae0)
	{
		x9c0f421e2823a37c x9c0f421e2823a37c = x3da965c717d88445(xa806b754814b9ae0.ParentTable);
		while (x9c0f421e2823a37c.x39c11fce0571e063 != null && x9c0f421e2823a37c.x39c11fce0571e063.x888f9f147ebe6b41 != xa806b754814b9ae0)
		{
			x9c0f421e2823a37c.xc42fc0160c161943();
		}
	}

	private bool xbd606b290349b4f1(Cell xe6de5e5fa2d44af5)
	{
		if (xb42f2f2b9987ee29)
		{
			if (xf7499ae99c6308ad)
			{
				return xa977a609842fa6d2.x3aafce4bafb29dc2 != xe6de5e5fa2d44af5.x133f2db9e5b5690d;
			}
			return true;
		}
		return false;
	}

	private void xcf42c46a06c9d54f(Cell xe6de5e5fa2d44af5)
	{
		x06cd654cc97ff192(xe6de5e5fa2d44af5.ParentRow);
		xa977a609842fa6d2.xbeec4ad54bcadf05();
		while (xa977a609842fa6d2.x1d23559baf0e4415 != null && xa977a609842fa6d2.x1d23559baf0e4415.x82d4d8bcc20a864f != xe6de5e5fa2d44af5)
		{
			xa977a609842fa6d2.x5d8b5df141c961ba();
		}
	}

	private x9c0f421e2823a37c x3da965c717d88445(Table x1ec770899c98a268)
	{
		x9c0f421e2823a37c x9c0f421e2823a37c = new x9c0f421e2823a37c(x1ec770899c98a268, resolveInheritedBorders: true, populateEmptyPadBorders: false, resolveInheritedPaddings: true);
		x27b42f375c6ab29f.Push(x9c0f421e2823a37c);
		x9c0f421e2823a37c.x550f875a2eea9b05();
		return x9c0f421e2823a37c;
	}
}
