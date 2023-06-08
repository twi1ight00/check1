using x1c8faa688b1f0b0c;
using x5794c252ba25e723;

namespace x4f4df92b75ba3b67;

internal class x79e4013ca0fc082a
{
	private const float x5f61c943c95dc59a = 0.5f;

	private readonly x4882ae789be6e2ef x8cedcaa9a62c6e39;

	private readonly x4d8917c8186e8cb2 xa49cef274042e702;

	private bool x0360888c15e78f9c;

	private float x180e232dfe6ec40e;

	private float x5f947342fbde9157;

	private x54366fa5f75a02f7 x905e747c6f0070c4;

	private string xeab191bfbb9ed8d4;

	internal x79e4013ca0fc082a(x4882ae789be6e2ef context, x4d8917c8186e8cb2 stream)
	{
		x8cedcaa9a62c6e39 = context;
		xa49cef274042e702 = stream;
	}

	internal void xd6b2549ca8b77560(xcc8c7739d82c63ba x199c511544621683)
	{
		x094ce9ef76b93f5f();
		xe39d06eee35dd23d xc2d4efc42998d87b = x199c511544621683.xc2d4efc42998d87b;
		xba2f911354958a68 xba2f911354958a69 = x8cedcaa9a62c6e39.x2107de3fc2a21893.x9059a3203c8fc855(xc2d4efc42998d87b, x199c511544621683.Text);
		x8cedcaa9a62c6e39.x147e079aca56accb.x2126b815e845382d(xba2f911354958a69, xc2d4efc42998d87b.x53531537bb3331e6, xa49cef274042e702);
		x8cedcaa9a62c6e39.x147e079aca56accb.xe98c0b45f0df18ad(x199c511544621683.x1ba361c106a805aa, xa49cef274042e702);
		x448446a83c061d4b(xba2f911354958a69, x199c511544621683);
		if (!(x199c511544621683.xf09329ffe2ab2695 != x26d9ecb4bdf0456d.x45260ad4b94166f2) && !xba2f911354958a69.x30c7b3201d032345)
		{
			xe79fe499dd1b75b3(0);
			x8cedcaa9a62c6e39.x147e079aca56accb.x2a037b343bdac965(x199c511544621683.x9b41425268471380, x577adbf0cae935c5: false, xa49cef274042e702);
		}
		else
		{
			if (x199c511544621683.x9b41425268471380 != x26d9ecb4bdf0456d.x45260ad4b94166f2)
			{
				xe79fe499dd1b75b3(2);
				x8cedcaa9a62c6e39.x147e079aca56accb.x2a037b343bdac965(x199c511544621683.x9b41425268471380, x577adbf0cae935c5: false, xa49cef274042e702);
			}
			else
			{
				xe79fe499dd1b75b3(1);
			}
			if (xba2f911354958a69.x30c7b3201d032345)
			{
				float xbcea506a33cf = x199c511544621683.xc2d4efc42998d87b.x53531537bb3331e6 / 30f;
				xa49cef274042e702.x241b3c2e8c3aaa86("{0} w", xcd769e39c0788209.x355581fe14891d82(xbcea506a33cf));
				x26d9ecb4bdf0456d x6c50a99faab7d = ((x199c511544621683.x9b41425268471380 != x26d9ecb4bdf0456d.x45260ad4b94166f2) ? x199c511544621683.x9b41425268471380 : x199c511544621683.xf09329ffe2ab2695);
				x8cedcaa9a62c6e39.x147e079aca56accb.x2a037b343bdac965(x6c50a99faab7d, x577adbf0cae935c5: true, xa49cef274042e702);
			}
			else
			{
				xa49cef274042e702.x241b3c2e8c3aaa86("{0} w", xcd769e39c0788209.x355581fe14891d82(0.5f));
				x8cedcaa9a62c6e39.x147e079aca56accb.x2a037b343bdac965(x199c511544621683.xf09329ffe2ab2695, x577adbf0cae935c5: true, xa49cef274042e702);
			}
		}
		bool flag = xd0e5bb3ded9994f0(x199c511544621683, xba2f911354958a69);
		bool flag2 = x199c511544621683.x1ba361c106a805aa != 0f;
		if (!flag && !flag2)
		{
			x180e232dfe6ec40e += x199c511544621683.x437e3b626c0fdd43.Width;
		}
	}

	internal void x094ce9ef76b93f5f()
	{
		if (!x0360888c15e78f9c)
		{
			xa49cef274042e702.x241b3c2e8c3aaa86("BT");
			x0360888c15e78f9c = true;
			xeab191bfbb9ed8d4 = "Tj";
			x905e747c6f0070c4 = new x54366fa5f75a02f7();
		}
	}

	internal void x508e8f685c66ed54()
	{
		if (x0360888c15e78f9c)
		{
			xa49cef274042e702.x241b3c2e8c3aaa86("ET");
			x0360888c15e78f9c = false;
		}
	}

	private void x448446a83c061d4b(xba2f911354958a68 x26094932cf7a9139, xcc8c7739d82c63ba x199c511544621683)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = x06e6003560667c05(x26094932cf7a9139, x199c511544621683);
		if (!xaee8153665a614ca(x54366fa5f75a02f) || !xaee8153665a614ca(x905e747c6f0070c4))
		{
			x39605bb716707926(x54366fa5f75a02f);
			x42dfe9319622a277(x54366fa5f75a02f);
			x905e747c6f0070c4 = x54366fa5f75a02f;
		}
		else
		{
			if (x54366fa5f75a02f.x35fa2f38e277fdee == x180e232dfe6ec40e && x54366fa5f75a02f.x93f6f49bd53e2628 == x5f947342fbde9157)
			{
				return;
			}
			float num = x54366fa5f75a02f.x35fa2f38e277fdee - x905e747c6f0070c4.x35fa2f38e277fdee;
			float num2 = x54366fa5f75a02f.x93f6f49bd53e2628 - x905e747c6f0070c4.x93f6f49bd53e2628;
			if (num == 0f)
			{
				if (num2 != x8cedcaa9a62c6e39.x147e079aca56accb.xb6d990994f0cea33.x54d212b412ca54d5)
				{
					x8cedcaa9a62c6e39.x147e079aca56accb.xf74dabb52ecdb397(num2, xa49cef274042e702);
				}
				xeab191bfbb9ed8d4 = "'";
			}
			else if (num2 == x8cedcaa9a62c6e39.x147e079aca56accb.xb6d990994f0cea33.x54d212b412ca54d5)
			{
				xa49cef274042e702.x241b3c2e8c3aaa86("{0} {1} Td", xcd769e39c0788209.x355581fe14891d82(num), xcd769e39c0788209.x355581fe14891d82(0f - num2));
			}
			else
			{
				xa49cef274042e702.x241b3c2e8c3aaa86("{0} {1} TD", xcd769e39c0788209.x355581fe14891d82(num), xcd769e39c0788209.x355581fe14891d82(0f - num2));
				x8cedcaa9a62c6e39.x147e079aca56accb.xb6d990994f0cea33.x54d212b412ca54d5 = num2;
			}
			x42dfe9319622a277(x54366fa5f75a02f);
			x905e747c6f0070c4 = x54366fa5f75a02f;
		}
	}

	private void x39605bb716707926(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		xa49cef274042e702.x1f64811c8bfde335(xa801ccff44b0c7eb, "Tm");
	}

	private static bool xaee8153665a614ca(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		if (xa801ccff44b0c7eb.xb4f54e8f080ddae5 == 1f && xa801ccff44b0c7eb.xdde8182ef4f9942b == 0f && xa801ccff44b0c7eb.xa71255917a9143ca == 0f && xa801ccff44b0c7eb.xcd7062a84a8f3162 == -1f)
		{
			return true;
		}
		return false;
	}

	private static x54366fa5f75a02f7 x06e6003560667c05(xba2f911354958a68 x26094932cf7a9139, xcc8c7739d82c63ba x199c511544621683)
	{
		return new x54366fa5f75a02f7(1f, 0f, x26094932cf7a9139.xda4c813a32b9109b ? 0.34906584f : 0f, -1f, x199c511544621683.xc22eade24b085d91.X, x199c511544621683.xc22eade24b085d91.Y);
	}

	private void x42dfe9319622a277(x54366fa5f75a02f7 x921f73e1838bea64)
	{
		x180e232dfe6ec40e = x921f73e1838bea64.x35fa2f38e277fdee;
		x5f947342fbde9157 = x921f73e1838bea64.x93f6f49bd53e2628;
	}

	private void xe79fe499dd1b75b3(int xa4aa8b4150b11435)
	{
		x8cedcaa9a62c6e39.x147e079aca56accb.x61980db65496bed2(xa4aa8b4150b11435, xa49cef274042e702);
	}

	private bool xd0e5bb3ded9994f0(xcc8c7739d82c63ba x199c511544621683, xba2f911354958a68 x26094932cf7a9139)
	{
		bool result = x26094932cf7a9139.WriteText(x199c511544621683.Text, xa49cef274042e702.x5aa326f374b3d0ef);
		xa49cef274042e702.x241b3c2e8c3aaa86(xeab191bfbb9ed8d4);
		xeab191bfbb9ed8d4 = "Tj";
		return result;
	}
}
