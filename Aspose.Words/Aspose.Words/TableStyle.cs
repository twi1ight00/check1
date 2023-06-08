using System;
using System.Collections;
using x28925c9b27b37a46;
using x9db5f2e5af3d596e;

namespace Aspose.Words;

public class TableStyle : Style
{
	private xedb0eb766e25e0c9 xe661c29834d8220f = new xedb0eb766e25e0c9();

	private xedb0eb766e25e0c9 x90bc32e7ee1a7dc3 = new xedb0eb766e25e0c9();

	private xf8cef531dae89ea3 xede608e9bc344cf9 = new xf8cef531dae89ea3();

	private ArrayList x07cb456fd10c5320 = new ArrayList();

	internal xedb0eb766e25e0c9 xedb0eb766e25e0c9
	{
		get
		{
			return xe661c29834d8220f;
		}
		set
		{
			xe661c29834d8220f = value;
		}
	}

	internal xedb0eb766e25e0c9 x511a581657d77f2b
	{
		get
		{
			return x90bc32e7ee1a7dc3;
		}
		set
		{
			x90bc32e7ee1a7dc3 = value;
		}
	}

	internal xf8cef531dae89ea3 xf8cef531dae89ea3
	{
		get
		{
			return xede608e9bc344cf9;
		}
		set
		{
			xede608e9bc344cf9 = value;
		}
	}

	internal ArrayList x7205cb42c2f994a4 => x07cb456fd10c5320;

	internal TableStyle()
		: base(StyleType.Table)
	{
	}

	internal override Style x8b61531c8ea35b85()
	{
		TableStyle tableStyle = (TableStyle)base.x8b61531c8ea35b85();
		if (xe661c29834d8220f != null)
		{
			tableStyle.xe661c29834d8220f = (xedb0eb766e25e0c9)xe661c29834d8220f.x8b61531c8ea35b85();
		}
		if (x90bc32e7ee1a7dc3 != null)
		{
			tableStyle.x90bc32e7ee1a7dc3 = (xedb0eb766e25e0c9)x90bc32e7ee1a7dc3.x8b61531c8ea35b85();
		}
		if (xede608e9bc344cf9 != null)
		{
			tableStyle.xede608e9bc344cf9 = (xf8cef531dae89ea3)xede608e9bc344cf9.x8b61531c8ea35b85();
		}
		if (x07cb456fd10c5320 != null)
		{
			tableStyle.x07cb456fd10c5320 = new ArrayList();
			foreach (xe12ab2f55355c7f0 item in x07cb456fd10c5320)
			{
				tableStyle.x07cb456fd10c5320.Add(item.x8b61531c8ea35b85());
			}
		}
		return tableStyle;
	}

	internal xedb0eb766e25e0c9 x43aa3065eb22eea2()
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = new xedb0eb766e25e0c9();
		x5620e925d7850624(xedb0eb766e25e0c);
		return xedb0eb766e25e0c;
	}

	private void x5620e925d7850624(xedb0eb766e25e0c9 x891f111d7bfa98a4)
	{
		((TableStyle)xea729b8c7bbb5bb0())?.x5620e925d7850624(x891f111d7bfa98a4);
		if (xe661c29834d8220f != null)
		{
			xe661c29834d8220f.xab3af626b1405ee8(x891f111d7bfa98a4);
		}
	}

	internal xedb0eb766e25e0c9 xaa572f7df92ef004()
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = new xedb0eb766e25e0c9();
		xe87599ad36506f53(xedb0eb766e25e0c);
		return xedb0eb766e25e0c;
	}

	private void xe87599ad36506f53(xedb0eb766e25e0c9 x759f40360baebeb4)
	{
		((TableStyle)xea729b8c7bbb5bb0())?.xe87599ad36506f53(x759f40360baebeb4);
		if (x90bc32e7ee1a7dc3 != null)
		{
			x90bc32e7ee1a7dc3.xab3af626b1405ee8(x759f40360baebeb4);
		}
	}

	internal xf8cef531dae89ea3 x0974156b728aa5fc()
	{
		xf8cef531dae89ea3 xf8cef531dae89ea = new xf8cef531dae89ea3();
		x41c979be9a82e12f(xf8cef531dae89ea);
		return xf8cef531dae89ea;
	}

	private void x41c979be9a82e12f(xf8cef531dae89ea3 x189ab8fa97bda223)
	{
		((TableStyle)xea729b8c7bbb5bb0())?.x41c979be9a82e12f(x189ab8fa97bda223);
		if (xede608e9bc344cf9 != null)
		{
			xede608e9bc344cf9.xab3af626b1405ee8(x189ab8fa97bda223);
		}
	}

	internal xe12ab2f55355c7f0 x67983e0dd0a90e0a(x1b1ec609e70eb086 x43163d22e8cd5a71)
	{
		foreach (xe12ab2f55355c7f0 item in x07cb456fd10c5320)
		{
			if (item.x3146d638ec378671 == x43163d22e8cd5a71)
			{
				return item;
			}
		}
		return null;
	}

	private xe12ab2f55355c7f0 x2b4acb141af0994e(x1b1ec609e70eb086 x43163d22e8cd5a71)
	{
		xe12ab2f55355c7f0 xe12ab2f55355c7f = x67983e0dd0a90e0a(x43163d22e8cd5a71);
		if (xe12ab2f55355c7f == null)
		{
			xe12ab2f55355c7f = new xe12ab2f55355c7f0();
			xe12ab2f55355c7f.x3146d638ec378671 = x43163d22e8cd5a71;
			x07cb456fd10c5320.Add(xe12ab2f55355c7f);
		}
		return xe12ab2f55355c7f;
	}

	internal x7f77ea92be0d9042 xbb34992bd03b3875(x1b1ec609e70eb086 x43163d22e8cd5a71, x70d40b77e7fb14d0 xd515847b862b6b66)
	{
		xe12ab2f55355c7f0 xe12ab2f55355c7f = x2b4acb141af0994e(x43163d22e8cd5a71);
		switch (xd515847b862b6b66)
		{
		case x70d40b77e7fb14d0.x11db8fc7f469a2fc:
			if (xe12ab2f55355c7f.xf8cef531dae89ea3 == null)
			{
				xe12ab2f55355c7f.xf8cef531dae89ea3 = new xf8cef531dae89ea3();
			}
			return xe12ab2f55355c7f.xf8cef531dae89ea3;
		case x70d40b77e7fb14d0.xb0d0149484e84c46:
			if (xe12ab2f55355c7f.x1a78664fa10a3755 == null)
			{
				xe12ab2f55355c7f.x1a78664fa10a3755 = new x1a78664fa10a3755();
			}
			return xe12ab2f55355c7f.x1a78664fa10a3755;
		case x70d40b77e7fb14d0.x160a0bf4de8f6bd0:
			if (xe12ab2f55355c7f.xeedad81aaed42a76 == null)
			{
				xe12ab2f55355c7f.xeedad81aaed42a76 = new xeedad81aaed42a76();
			}
			return xe12ab2f55355c7f.xeedad81aaed42a76;
		default:
			throw new InvalidOperationException("Unknown prType value.");
		}
	}

	internal override bool x4a6c2b56be2364cf()
	{
		if (base.x4a6c2b56be2364cf())
		{
			return true;
		}
		if (xe661c29834d8220f.xd44988f225497f3a > 0)
		{
			return true;
		}
		if (x90bc32e7ee1a7dc3.xd44988f225497f3a > 0)
		{
			return true;
		}
		if (xede608e9bc344cf9.xd44988f225497f3a > 0)
		{
			return true;
		}
		foreach (xe12ab2f55355c7f0 item in x07cb456fd10c5320)
		{
			if (!x39e63a0c97e00b40(item.xedb0eb766e25e0c9))
			{
				return true;
			}
			if (!x39e63a0c97e00b40(item.x511a581657d77f2b))
			{
				return true;
			}
			if (!x39e63a0c97e00b40(item.xf8cef531dae89ea3))
			{
				return true;
			}
			if (!x39e63a0c97e00b40(item.x1a78664fa10a3755))
			{
				return true;
			}
			if (!x39e63a0c97e00b40(item.xeedad81aaed42a76))
			{
				return true;
			}
		}
		return false;
	}

	private static bool x39e63a0c97e00b40(x7f77ea92be0d9042 x94aec03cf2ae750b)
	{
		if (x94aec03cf2ae750b == null)
		{
			return true;
		}
		return x94aec03cf2ae750b.xd44988f225497f3a == 0;
	}
}
