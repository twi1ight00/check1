using System;
using System.Collections;
using Aspose.Words;
using x13f1efc79617a47b;
using x28925c9b27b37a46;

namespace xce0136f05681c5e9;

internal class x5b7780c99f08ae18
{
	private readonly Document xd1424e1a0bb4a72b;

	private readonly xe2ff3c3cd396cfd9 x18ddd758cd8495e3;

	private readonly x9e83e90818260fa5 x230c333abfdbfccd;

	private readonly xae2987b4c36ffe56 x91c6898086a7eed1;

	private readonly x0de10523530ef89b x4af07f520b56f886;

	private readonly xc58be79b37b0a64e x256d4e1f98680cc0 = new xc58be79b37b0a64e();

	private readonly xc58be79b37b0a64e x19d1c2a90f9b01e7 = new xc58be79b37b0a64e();

	private int xcb985104aace38af;

	private int xcbab0262b9b3a975;

	private bool x667015e93cd25af1;

	private x646705b5eaaf7b45 x305260994b345465;

	private bool xd77d14b665d85ede;

	private Run x65e7b7fd76194343;

	internal x5b7780c99f08ae18(Document document, xe2ff3c3cd396cfd9 writerCommon, x9e83e90818260fa5 hyperlinkWriter, xae2987b4c36ffe56 horizontalLineWriter, x0de10523530ef89b bookmarkWriter)
	{
		xd1424e1a0bb4a72b = document;
		x18ddd758cd8495e3 = writerCommon;
		x230c333abfdbfccd = hyperlinkWriter;
		x91c6898086a7eed1 = horizontalLineWriter;
		x4af07f520b56f886 = bookmarkWriter;
		xcb985104aace38af = document.FootnoteOptions.StartNumber;
		xcbab0262b9b3a975 = document.EndnoteOptions.StartNumber;
	}

	internal void xcc50320bd895cb0a()
	{
		x667015e93cd25af1 = true;
		xa782456e09202e0b(x256d4e1f98680cc0);
		xa782456e09202e0b(x19d1c2a90f9b01e7);
		x667015e93cd25af1 = false;
	}

	internal VisitorAction x1b12ad7e0ad0df34(Footnote xa374c2b6b8c56b41)
	{
		if (!x667015e93cd25af1)
		{
			return x5d3872098449d524(xa374c2b6b8c56b41);
		}
		return x9bd03cfbd8951cb1(xa374c2b6b8c56b41);
	}

	internal VisitorAction xee9310aa5d10b7e3(Footnote xa374c2b6b8c56b41)
	{
		if (!x667015e93cd25af1 && x65e7b7fd76194343 != null)
		{
			xa374c2b6b8c56b41.FirstParagraph.InsertBefore(x65e7b7fd76194343, xa374c2b6b8c56b41.FirstParagraph.x38453dde2dc1ee92);
			x65e7b7fd76194343 = null;
		}
		return VisitorAction.Continue;
	}

	internal void x57a5d79d9b9d67f5()
	{
		if (xd77d14b665d85ede)
		{
			x4af07f520b56f886.x334f73a0b642051d(x305260994b345465.x6624b07f4ed29060);
			x230c333abfdbfccd.xc2550bde00ba6ebf(x305260994b345465.xf68faba5342fa96e, "#" + x305260994b345465.x0d9baf24fe287e09, xe389b456117f37b2: true);
			xd77d14b665d85ede = false;
		}
	}

	private void xa782456e09202e0b(ArrayList x4257b4219a4ce3bc)
	{
		if (x4257b4219a4ce3bc.Count == 0)
		{
			return;
		}
		x91c6898086a7eed1.xa5ecb8c0239203e4();
		foreach (x646705b5eaaf7b45 item in x4257b4219a4ce3bc)
		{
			x646705b5eaaf7b45 x646705b5eaaf7b46 = (x305260994b345465 = item);
			xd77d14b665d85ede = true;
			x18ddd758cd8495e3.xc93e761169bf41b6(x646705b5eaaf7b46.x96dcc45ba76df2e1);
		}
		x4257b4219a4ce3bc.Clear();
	}

	private VisitorAction x9bd03cfbd8951cb1(Footnote xa374c2b6b8c56b41)
	{
		if (!xa374c2b6b8c56b41.xa72bf798a679c0aa)
		{
			Paragraph firstParagraph = xa374c2b6b8c56b41.FirstParagraph;
			if (firstParagraph.x38453dde2dc1ee92 != null && firstParagraph.x38453dde2dc1ee92.Text == xa374c2b6b8c56b41.x715a8c5c33fdc1a6)
			{
				x65e7b7fd76194343 = firstParagraph.x38453dde2dc1ee92;
				firstParagraph.x38453dde2dc1ee92.Remove();
			}
		}
		return VisitorAction.Continue;
	}

	private VisitorAction x5d3872098449d524(Footnote xa374c2b6b8c56b41)
	{
		NumberStyle x3f5f7cef69e188c = NumberStyle.Arabic;
		int xbcea506a33cf = 0;
		ArrayList arrayList;
		string arg;
		switch (xa374c2b6b8c56b41.FootnoteType)
		{
		case FootnoteType.Footnote:
			arrayList = x256d4e1f98680cc0;
			arg = "ftn";
			if (xa374c2b6b8c56b41.xa72bf798a679c0aa)
			{
				x3f5f7cef69e188c = xd1424e1a0bb4a72b.FootnoteOptions.NumberStyle;
				xbcea506a33cf = xcb985104aace38af++;
			}
			break;
		case FootnoteType.Endnote:
			arrayList = x19d1c2a90f9b01e7;
			arg = "edn";
			if (xa374c2b6b8c56b41.xa72bf798a679c0aa)
			{
				x3f5f7cef69e188c = xd1424e1a0bb4a72b.EndnoteOptions.NumberStyle;
				xbcea506a33cf = xcbab0262b9b3a975++;
			}
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("llmobndplmkplmbajmiaompacmgbbhnbeleckllchlcdjljdalaeokhealoeojfffgmfijdgojkgbjbhijihgjphijgiginiodejpiljbjckfijkhhalndhl", 871885926)));
		}
		x646705b5eaaf7b45 x646705b5eaaf7b46 = new x646705b5eaaf7b45();
		x646705b5eaaf7b46.x96dcc45ba76df2e1 = xa374c2b6b8c56b41;
		if (xa374c2b6b8c56b41.xa72bf798a679c0aa)
		{
			x646705b5eaaf7b46.xfbec4f3e7e2238a8 = x00b47748a95c9437.x19fa8583862b446b(xbcea506a33cf, x3f5f7cef69e188c, x3b747bc7816d8768: true);
		}
		else
		{
			x646705b5eaaf7b46.xfbec4f3e7e2238a8 = xa374c2b6b8c56b41.x715a8c5c33fdc1a6;
		}
		x646705b5eaaf7b46.xf68faba5342fa96e = $"[{x646705b5eaaf7b46.xfbec4f3e7e2238a8}]";
		int num = arrayList.Count + 1;
		x646705b5eaaf7b46.x6624b07f4ed29060 = $"_{arg}{num}";
		x646705b5eaaf7b46.x0d9baf24fe287e09 = $"_{arg}ref{num}";
		arrayList.Add(x646705b5eaaf7b46);
		x4af07f520b56f886.x334f73a0b642051d(x646705b5eaaf7b46.x0d9baf24fe287e09);
		x230c333abfdbfccd.xc2550bde00ba6ebf(x646705b5eaaf7b46.xf68faba5342fa96e, "#" + x646705b5eaaf7b46.x6624b07f4ed29060, xe389b456117f37b2: true);
		return VisitorAction.SkipThisNode;
	}
}
