using System;
using x13f1efc79617a47b;

namespace x4adf554d20d941a6;

internal class x591c1d6e66408377
{
	private x591c1d6e66408377 xc454c03c23d4b4d9;

	private x591c1d6e66408377 xec4a853eacf32e8a;

	private x591c1d6e66408377 x32f0db08170326ed;

	private x591c1d6e66408377 x49ee6444b46ca8a5;

	private x591c1d6e66408377 xc07b917d45d2aa0c;

	private int x823c6b25cc2689d8;

	private int x8918dc7c534575e5;

	private int x35a5073ffeb125c5 = 1;

	private readonly x3923a5fd933905d6 xc7d28a9d010ccced;

	private bool x9b7e7308f431fe78;

	private object x90ad4aa1e463a664;

	internal int x1be93eed8950d961 => x823c6b25cc2689d8;

	internal int xd44988f225497f3a => x35a5073ffeb125c5;

	internal int xf1d9b91c9700c401
	{
		get
		{
			int num = 0;
			x591c1d6e66408377 x591c1d6e66408378 = this;
			for (x591c1d6e66408377 x591c1d6e66408379 = x332a8eedb847940d; x591c1d6e66408379 != null; x591c1d6e66408379 = x591c1d6e66408378.x332a8eedb847940d)
			{
				if (x591c1d6e66408378 == x591c1d6e66408379.x32f0db08170326ed)
				{
					num += x591c1d6e66408379.xec4a853eacf32e8a.x823c6b25cc2689d8;
				}
				x591c1d6e66408378 = x591c1d6e66408379;
			}
			return num;
		}
	}

	internal bool xf065f1542d0d16e9 => xec4a853eacf32e8a == null;

	internal x591c1d6e66408377 x782bb6538e64cacf
	{
		get
		{
			return xec4a853eacf32e8a;
		}
		set
		{
			if (value != null)
			{
				value.x332a8eedb847940d = this;
			}
			xec4a853eacf32e8a = value;
		}
	}

	internal x591c1d6e66408377 x0ea8d41798209f7f
	{
		get
		{
			return x32f0db08170326ed;
		}
		set
		{
			if (value != null)
			{
				value.x332a8eedb847940d = this;
			}
			x32f0db08170326ed = value;
		}
	}

	internal x591c1d6e66408377 x29e7ace4c90f74cd
	{
		get
		{
			x591c1d6e66408377 x591c1d6e66408378 = this;
			while (x591c1d6e66408378.x332a8eedb847940d != null)
			{
				x591c1d6e66408378 = x591c1d6e66408378.x332a8eedb847940d;
			}
			return x591c1d6e66408378;
		}
	}

	internal int x82d11e864c924b7d
	{
		get
		{
			int num = 0;
			if (xec4a853eacf32e8a != null)
			{
				num -= xec4a853eacf32e8a.x8918dc7c534575e5;
			}
			if (x32f0db08170326ed != null)
			{
				num += x32f0db08170326ed.x8918dc7c534575e5;
			}
			return num;
		}
	}

	internal int xb0f146032f47c24e => x8918dc7c534575e5;

	internal x591c1d6e66408377 x6e64c31f094eb1d7 => xc07b917d45d2aa0c;

	internal x591c1d6e66408377 xe660eb6ec8beb0b4 => x49ee6444b46ca8a5;

	internal x591c1d6e66408377 x332a8eedb847940d
	{
		get
		{
			return xc454c03c23d4b4d9;
		}
		set
		{
			xe88ab84767e8fb69();
			xc454c03c23d4b4d9 = value;
		}
	}

	internal bool x7149c962c02931b3
	{
		get
		{
			if (xf065f1542d0d16e9)
			{
				return null == x90ad4aa1e463a664;
			}
			return false;
		}
	}

	internal bool x65fd966a6b330c28 => x9b7e7308f431fe78;

	internal object x02ebdc12ebf86805
	{
		get
		{
			return x90ad4aa1e463a664;
		}
		set
		{
			x9b7e7308f431fe78 = false;
			x90ad4aa1e463a664 = value;
		}
	}

	internal x591c1d6e66408377(x3923a5fd933905d6 collection)
	{
		xc7d28a9d010ccced = collection;
	}

	internal x591c1d6e66408377 xef23aa45e7612fdd(object xccb63ca5f63dc470, int x961016a387451f05)
	{
		if (!xf065f1542d0d16e9)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("koejiamjkpckeakkapalaailcpolfpfmbpmmakdngoknnobohjiokopocngpknnpeneammlaficbimjbomacomhcjhoccmfdilmdbldedlkekgbfflifdlpffkggdkngokehiflhekciakjiljajfkhjhfoj", 1792840859)));
		}
		x591c1d6e66408377 x591c1d6e66408378 = new x591c1d6e66408377(xc7d28a9d010ccced);
		x591c1d6e66408378.x823c6b25cc2689d8 = x823c6b25cc2689d8;
		x591c1d6e66408377 x591c1d6e66408379 = new x591c1d6e66408377(xc7d28a9d010ccced);
		x591c1d6e66408379.x823c6b25cc2689d8 = x961016a387451f05;
		x591c1d6e66408379.xc07b917d45d2aa0c = x591c1d6e66408378;
		x591c1d6e66408378.x49ee6444b46ca8a5 = x591c1d6e66408379;
		xd9cef63050b88d56(this, x591c1d6e66408378);
		x591c1d6e66408379.x02ebdc12ebf86805 = xccb63ca5f63dc470;
		if (x49ee6444b46ca8a5 != null)
		{
			x49ee6444b46ca8a5.xc07b917d45d2aa0c = x591c1d6e66408379;
			x591c1d6e66408379.x49ee6444b46ca8a5 = x49ee6444b46ca8a5;
			x49ee6444b46ca8a5 = null;
		}
		if (xc07b917d45d2aa0c != null)
		{
			xc07b917d45d2aa0c.x49ee6444b46ca8a5 = x591c1d6e66408378;
			x591c1d6e66408378.xc07b917d45d2aa0c = xc07b917d45d2aa0c;
			xc07b917d45d2aa0c = null;
		}
		x782bb6538e64cacf = x591c1d6e66408379;
		x0ea8d41798209f7f = x591c1d6e66408378;
		x35a5073ffeb125c5 = 2;
		x295cb4a1df7a5add();
		xc7d28a9d010ccced.x29e7ace4c90f74cd = xc7d28a9d010ccced.x29e7ace4c90f74cd.x29e7ace4c90f74cd;
		return x591c1d6e66408378;
	}

	internal x591c1d6e66408377 x917b69030691beda(object xccb63ca5f63dc470, int x961016a387451f05)
	{
		if (!xf065f1542d0d16e9)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ekblcmilelplolgmkknmklenmklnpkcolkjokfapakhphkopbffaekmamidbejkboibcgiicpdpccigdiindiieeddlemhcfchjflgagnghgecogpgfhngmhpfdinfkiigbjcbijofpjkfgkffnkpfelbbll", 269791573)));
		}
		x591c1d6e66408377 x591c1d6e66408378 = new x591c1d6e66408377(xc7d28a9d010ccced);
		x591c1d6e66408378.x823c6b25cc2689d8 = x961016a387451f05;
		x591c1d6e66408377 x591c1d6e66408379 = new x591c1d6e66408377(xc7d28a9d010ccced);
		x591c1d6e66408379.x823c6b25cc2689d8 = x823c6b25cc2689d8;
		x591c1d6e66408379.xc07b917d45d2aa0c = x591c1d6e66408378;
		x591c1d6e66408378.x49ee6444b46ca8a5 = x591c1d6e66408379;
		xd9cef63050b88d56(this, x591c1d6e66408379);
		x591c1d6e66408378.x02ebdc12ebf86805 = xccb63ca5f63dc470;
		if (x49ee6444b46ca8a5 != null)
		{
			x49ee6444b46ca8a5.xc07b917d45d2aa0c = x591c1d6e66408379;
			x591c1d6e66408379.x49ee6444b46ca8a5 = x49ee6444b46ca8a5;
			x49ee6444b46ca8a5 = null;
		}
		if (xc07b917d45d2aa0c != null)
		{
			xc07b917d45d2aa0c.x49ee6444b46ca8a5 = x591c1d6e66408378;
			x591c1d6e66408378.xc07b917d45d2aa0c = xc07b917d45d2aa0c;
			xc07b917d45d2aa0c = null;
		}
		x782bb6538e64cacf = x591c1d6e66408379;
		x0ea8d41798209f7f = x591c1d6e66408378;
		x35a5073ffeb125c5 = 2;
		x295cb4a1df7a5add();
		xc7d28a9d010ccced.x29e7ace4c90f74cd = xc7d28a9d010ccced.x29e7ace4c90f74cd.x29e7ace4c90f74cd;
		return x591c1d6e66408379;
	}

	internal void x3df13c9311a0ba9b(int x374ea4fe62468d0f)
	{
		if (!xf065f1542d0d16e9)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("obggmdngocehidlhecciedjigcajjchjfcojenekkbmkbcdllmjlobbmgaimoapmiagnaannjldompkocacpcajpnkppgpgamonafoebholbojccjojchoadjnhdhnodcofemimeindfenkfpmbgjniglipg", 447309263)));
		}
		if (x374ea4fe62468d0f != 0 && x374ea4fe62468d0f != x1be93eed8950d961)
		{
			x591c1d6e66408377 x591c1d6e66408378 = new x591c1d6e66408377(xc7d28a9d010ccced);
			x591c1d6e66408378.x823c6b25cc2689d8 = x823c6b25cc2689d8 - x374ea4fe62468d0f;
			x591c1d6e66408377 x591c1d6e66408379 = new x591c1d6e66408377(xc7d28a9d010ccced);
			x591c1d6e66408379.x823c6b25cc2689d8 = x374ea4fe62468d0f;
			x591c1d6e66408379.xc07b917d45d2aa0c = x591c1d6e66408378;
			x591c1d6e66408378.x49ee6444b46ca8a5 = x591c1d6e66408379;
			if (x49ee6444b46ca8a5 != null)
			{
				x49ee6444b46ca8a5.xc07b917d45d2aa0c = x591c1d6e66408379;
				x591c1d6e66408379.x49ee6444b46ca8a5 = x49ee6444b46ca8a5;
				x49ee6444b46ca8a5 = null;
			}
			if (xc07b917d45d2aa0c != null)
			{
				xc07b917d45d2aa0c.x49ee6444b46ca8a5 = x591c1d6e66408378;
				x591c1d6e66408378.xc07b917d45d2aa0c = xc07b917d45d2aa0c;
				xc07b917d45d2aa0c = null;
			}
			x782bb6538e64cacf = x591c1d6e66408379;
			x0ea8d41798209f7f = x591c1d6e66408378;
			x35a5073ffeb125c5 = 2;
			x295cb4a1df7a5add();
			xc7d28a9d010ccced.x29e7ace4c90f74cd = xc7d28a9d010ccced.x29e7ace4c90f74cd.x29e7ace4c90f74cd;
		}
	}

	internal void x295cb4a1df7a5add()
	{
		xe88ab84767e8fb69();
		x591c1d6e66408377 x591c1d6e66408378 = null;
		if (xf065f1542d0d16e9)
		{
			x8918dc7c534575e5 = 0;
		}
		for (x591c1d6e66408377 x591c1d6e66408379 = (xf065f1542d0d16e9 ? x332a8eedb847940d : this); x591c1d6e66408379 != null; x591c1d6e66408379 = x591c1d6e66408379.x332a8eedb847940d)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if (x591c1d6e66408379.xec4a853eacf32e8a != null)
			{
				num = x591c1d6e66408379.xec4a853eacf32e8a.x8918dc7c534575e5;
				num2 = x591c1d6e66408379.xec4a853eacf32e8a.x823c6b25cc2689d8;
				num3 = x591c1d6e66408379.xec4a853eacf32e8a.x35a5073ffeb125c5;
			}
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			if (x591c1d6e66408379.x32f0db08170326ed != null)
			{
				num4 = x591c1d6e66408379.x32f0db08170326ed.x8918dc7c534575e5;
				num5 = x591c1d6e66408379.x32f0db08170326ed.x823c6b25cc2689d8;
				num6 = x591c1d6e66408379.x32f0db08170326ed.x35a5073ffeb125c5;
			}
			x591c1d6e66408379.x8918dc7c534575e5 = ((num > num4) ? num : num4);
			x591c1d6e66408379.x8918dc7c534575e5++;
			if (x591c1d6e66408378 == null)
			{
				int num7 = x591c1d6e66408379.x82d11e864c924b7d;
				if (num7 < -1 || num7 > 1)
				{
					x591c1d6e66408378 = x591c1d6e66408379;
				}
			}
			x591c1d6e66408379.x823c6b25cc2689d8 = num2 + num5;
			x591c1d6e66408379.x35a5073ffeb125c5 = num3 + num6;
		}
		x591c1d6e66408378?.x09f226e4d8831bca();
	}

	private void x09f226e4d8831bca()
	{
		int num = x82d11e864c924b7d;
		if (num != 0)
		{
			if (num < 0)
			{
				x5ac23a4534882dc2();
			}
			else
			{
				x2694f4042a33a325();
			}
		}
	}

	internal void x5ac23a4534882dc2()
	{
		x591c1d6e66408377 x591c1d6e66408378 = xec4a853eacf32e8a;
		if (x591c1d6e66408378 == null)
		{
			return;
		}
		if (x591c1d6e66408378.x82d11e864c924b7d > 0)
		{
			x591c1d6e66408378.x332a8eedb847940d = null;
			x591c1d6e66408378.x2694f4042a33a325();
			x591c1d6e66408378 = (x782bb6538e64cacf = x591c1d6e66408378.x29e7ace4c90f74cd);
		}
		if (x332a8eedb847940d != null)
		{
			if (x332a8eedb847940d.xec4a853eacf32e8a == this)
			{
				x332a8eedb847940d.x782bb6538e64cacf = x591c1d6e66408378;
			}
			else
			{
				x332a8eedb847940d.x0ea8d41798209f7f = x591c1d6e66408378;
			}
		}
		x591c1d6e66408378.x332a8eedb847940d = x332a8eedb847940d;
		x782bb6538e64cacf = x591c1d6e66408378.x32f0db08170326ed;
		x591c1d6e66408378.x0ea8d41798209f7f = this;
		x295cb4a1df7a5add();
	}

	internal void x2694f4042a33a325()
	{
		x591c1d6e66408377 x591c1d6e66408378 = x32f0db08170326ed;
		if (x591c1d6e66408378 == null)
		{
			return;
		}
		if (x591c1d6e66408378.x82d11e864c924b7d < 0)
		{
			x591c1d6e66408378.x332a8eedb847940d = null;
			x591c1d6e66408378.x5ac23a4534882dc2();
			x591c1d6e66408378 = (x0ea8d41798209f7f = x591c1d6e66408378.x29e7ace4c90f74cd);
		}
		if (x332a8eedb847940d != null)
		{
			if (x332a8eedb847940d.xec4a853eacf32e8a == this)
			{
				x332a8eedb847940d.x782bb6538e64cacf = x591c1d6e66408378;
			}
			else
			{
				x332a8eedb847940d.x0ea8d41798209f7f = x591c1d6e66408378;
			}
		}
		x591c1d6e66408378.x332a8eedb847940d = x332a8eedb847940d;
		x0ea8d41798209f7f = x591c1d6e66408378.xec4a853eacf32e8a;
		x591c1d6e66408378.x782bb6538e64cacf = this;
		x295cb4a1df7a5add();
	}

	internal x591c1d6e66408377 x3efec13832c2e10f(int x961016a387451f05)
	{
		if (!xf065f1542d0d16e9)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("enpjcpgkeonkooelknllkocmmnjmpnanlnhnkionanfohnmobidpenkpmlbaemiaolpaglgbpgnbclecillcilcddgjdmkaeckheljoenjffefmfpjdgnjkgpibhniihijphcegioinikiejfiljpickbejk", 1386717061)));
		}
		if (x961016a387451f05 < 0 || x961016a387451f05 > x823c6b25cc2689d8)
		{
			throw new ArgumentOutOfRangeException();
		}
		xe88ab84767e8fb69();
		if (x823c6b25cc2689d8 == x961016a387451f05)
		{
			return xddae736767606eb7();
		}
		x823c6b25cc2689d8 -= x961016a387451f05;
		if (x332a8eedb847940d != null)
		{
			x332a8eedb847940d.xdbb373baee16915b();
		}
		return xc07b917d45d2aa0c;
	}

	internal x591c1d6e66408377 xddae736767606eb7()
	{
		xe88ab84767e8fb69();
		x9b7e7308f431fe78 = true;
		if (x332a8eedb847940d == null)
		{
			x823c6b25cc2689d8 = -1;
			x90ad4aa1e463a664 = null;
			return null;
		}
		x591c1d6e66408377 result;
		if (x332a8eedb847940d.x32f0db08170326ed == this)
		{
			xd9cef63050b88d56(x49ee6444b46ca8a5, x332a8eedb847940d);
			if (x332a8eedb847940d.x82d11e864c924b7d < 0)
			{
				x332a8eedb847940d.x5ac23a4534882dc2();
			}
			result = xc07b917d45d2aa0c;
		}
		else
		{
			xd9cef63050b88d56(xc07b917d45d2aa0c, x332a8eedb847940d);
			if (x332a8eedb847940d.x82d11e864c924b7d > 0)
			{
				x332a8eedb847940d.x2694f4042a33a325();
			}
			result = x332a8eedb847940d;
		}
		x332a8eedb847940d.x49ee6444b46ca8a5 = x332a8eedb847940d.xec4a853eacf32e8a.x49ee6444b46ca8a5;
		x332a8eedb847940d.xc07b917d45d2aa0c = x332a8eedb847940d.x32f0db08170326ed.xc07b917d45d2aa0c;
		if (x332a8eedb847940d.x49ee6444b46ca8a5 != null)
		{
			x332a8eedb847940d.x49ee6444b46ca8a5.xc07b917d45d2aa0c = x332a8eedb847940d;
		}
		if (x332a8eedb847940d.xc07b917d45d2aa0c != null)
		{
			x332a8eedb847940d.xc07b917d45d2aa0c.x49ee6444b46ca8a5 = x332a8eedb847940d;
		}
		x332a8eedb847940d.xec4a853eacf32e8a = null;
		x332a8eedb847940d.x32f0db08170326ed = null;
		x332a8eedb847940d.x823c6b25cc2689d8 -= x823c6b25cc2689d8;
		x332a8eedb847940d.x35a5073ffeb125c5--;
		x823c6b25cc2689d8 = -1;
		x332a8eedb847940d.x295cb4a1df7a5add();
		xc7d28a9d010ccced.x29e7ace4c90f74cd = xc7d28a9d010ccced.x29e7ace4c90f74cd.x29e7ace4c90f74cd;
		x332a8eedb847940d = null;
		x90ad4aa1e463a664 = null;
		x49ee6444b46ca8a5 = null;
		xc07b917d45d2aa0c = null;
		x9b7e7308f431fe78 = true;
		return result;
	}

	internal void xd5da23b762ce52a2()
	{
		if (!xf065f1542d0d16e9)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("aphmmapmhagnbbnnfldoopkoepbpnoippppplogagpnaakebkolblnccapjcejaddnhddnodlifefnmekmdfenkfgmbgbmignlpgeigh", 1940309921)));
		}
		if (x49ee6444b46ca8a5 == null)
		{
			return;
		}
		if (x332a8eedb847940d.x32f0db08170326ed == this)
		{
			if (x332a8eedb847940d.x82d11e864c924b7d < 0)
			{
				x332a8eedb847940d.x5ac23a4534882dc2();
			}
			x332a8eedb847940d.x49ee6444b46ca8a5 = x49ee6444b46ca8a5.x49ee6444b46ca8a5;
			x332a8eedb847940d.xc07b917d45d2aa0c = xc07b917d45d2aa0c;
			if (x332a8eedb847940d.x49ee6444b46ca8a5 != null)
			{
				x332a8eedb847940d.x49ee6444b46ca8a5.xc07b917d45d2aa0c = x332a8eedb847940d;
			}
			if (x332a8eedb847940d.xc07b917d45d2aa0c != null)
			{
				x332a8eedb847940d.xc07b917d45d2aa0c.x49ee6444b46ca8a5 = x332a8eedb847940d;
			}
			x332a8eedb847940d.xec4a853eacf32e8a = null;
			x332a8eedb847940d.x32f0db08170326ed = null;
			x332a8eedb847940d.x295cb4a1df7a5add();
			xc7d28a9d010ccced.x29e7ace4c90f74cd = xc7d28a9d010ccced.x29e7ace4c90f74cd.x29e7ace4c90f74cd;
			return;
		}
		if (x332a8eedb847940d.xec4a853eacf32e8a == this)
		{
			if (x332a8eedb847940d.x82d11e864c924b7d > 0)
			{
				x332a8eedb847940d.x2694f4042a33a325();
			}
			x49ee6444b46ca8a5.x823c6b25cc2689d8 += x823c6b25cc2689d8;
			x332a8eedb847940d.x49ee6444b46ca8a5 = x49ee6444b46ca8a5;
			x332a8eedb847940d.xc07b917d45d2aa0c = xc07b917d45d2aa0c.xc07b917d45d2aa0c;
			if (x332a8eedb847940d.x49ee6444b46ca8a5 != null)
			{
				x332a8eedb847940d.x49ee6444b46ca8a5.xc07b917d45d2aa0c = x332a8eedb847940d;
			}
			if (x332a8eedb847940d.xc07b917d45d2aa0c != null)
			{
				x332a8eedb847940d.xc07b917d45d2aa0c.x49ee6444b46ca8a5 = x332a8eedb847940d;
			}
			x332a8eedb847940d.x823c6b25cc2689d8 -= x823c6b25cc2689d8;
			x332a8eedb847940d.xec4a853eacf32e8a = null;
			x332a8eedb847940d.x32f0db08170326ed = null;
			x49ee6444b46ca8a5.x295cb4a1df7a5add();
			x332a8eedb847940d.x295cb4a1df7a5add();
			x332a8eedb847940d.xd5da23b762ce52a2();
			xc7d28a9d010ccced.x29e7ace4c90f74cd = xc7d28a9d010ccced.x29e7ace4c90f74cd.x29e7ace4c90f74cd;
			return;
		}
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mplgkadhibkhiabioaiibbpiklfjfanjdaekfpkkdpbllkilapplgogmfpnmpjenfolnhocojnjocoapcohppnoppmfakmmaindbbikbbmbcdmicbmpcbmgdglndbmeebllehlcfggjfflagfkhgdkogpjfhjkmhjjdipjkibjbjajijljpjdfgk", 357198764)));
	}

	internal void xd6d0700e6673d965(int xbcea506a33cf9111)
	{
		if (!xf065f1542d0d16e9)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cgpgaighchnhmheiigliihcjkgjjngakjghkibokofflfgmlpadmcgkmkebncfinmepneegonpmoaeepgelpgecabpiakdabadhbjcoblcfccolcncddlckdnbbelbiegcpeanffmbnfibegdblgnbchpmih", 320171795)));
		}
		xe88ab84767e8fb69();
		if (xbcea506a33cf9111 < 0)
		{
			xddae736767606eb7();
			return;
		}
		x823c6b25cc2689d8 = xbcea506a33cf9111;
		if (x332a8eedb847940d != null)
		{
			x332a8eedb847940d.xdbb373baee16915b();
		}
	}

	internal void xd9cef63050b88d56(x591c1d6e66408377 x7f8a886f51b477eb, x591c1d6e66408377 x3ed4f4f0195b98d7)
	{
		xc7d28a9d010ccced.xde11bc5d740d3ee3(x7f8a886f51b477eb);
		x3ed4f4f0195b98d7.x02ebdc12ebf86805 = x7f8a886f51b477eb.x02ebdc12ebf86805;
		xc7d28a9d010ccced.x2a0cb95ab84ba877(x3ed4f4f0195b98d7);
	}

	internal void xe88ab84767e8fb69()
	{
		xc7d28a9d010ccced.xe88ab84767e8fb69();
	}

	private void xdbb373baee16915b()
	{
		for (x591c1d6e66408377 x591c1d6e66408378 = (xf065f1542d0d16e9 ? x332a8eedb847940d : this); x591c1d6e66408378 != null; x591c1d6e66408378 = x591c1d6e66408378.x332a8eedb847940d)
		{
			int num = 0;
			if (x591c1d6e66408378.xec4a853eacf32e8a != null)
			{
				num = x591c1d6e66408378.xec4a853eacf32e8a.x823c6b25cc2689d8;
			}
			int num2 = 0;
			if (x591c1d6e66408378.x32f0db08170326ed != null)
			{
				num2 = x591c1d6e66408378.x32f0db08170326ed.x823c6b25cc2689d8;
			}
			x591c1d6e66408378.x823c6b25cc2689d8 = num + num2;
		}
	}
}
