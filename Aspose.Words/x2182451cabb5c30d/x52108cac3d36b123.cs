using Aspose.Words;
using Aspose.Words.Lists;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using xf989f31a236ff98c;

namespace x2182451cabb5c30d;

internal class x52108cac3d36b123 : x59a1e7b7667e1e09
{
	private readonly xe5e546ef5f0503b2 x8cedcaa9a62c6e39;

	private readonly x52108cac3d36b123 x9da2686459bfa402;

	private readonly xbf575e106f2f2373 x4fa4b8e51b3b2901;

	private readonly x77fb5b1d5c73757b xef5d8b30300e4f23;

	private xeedad81aaed42a76 xd0c44e5ae0011daa;

	private x1a78664fa10a3755 x4379ee33a06c4648;

	private xfc72d4c9b765cad7 x13d0010792219ed4;

	private readonly x1691a621316cdab5 x058ccedcbbd47ccd = new x1691a621316cdab5();

	private int x8520bd59e7159a87 = -1;

	private bool xa33c1ef1c3d4382c;

	internal xbf575e106f2f2373 x1a55de3a01c1c82d => x4fa4b8e51b3b2901;

	internal x77fb5b1d5c73757b x9e0d5f7859d0eba8 => xef5d8b30300e4f23;

	public xeedad81aaed42a76 xeedad81aaed42a76
	{
		get
		{
			if (xd0c44e5ae0011daa == null)
			{
				xeedad81aaed42a76 xeedad81aaed42a = x93140134709b7d89();
				if (xeedad81aaed42a != null)
				{
					xd0c44e5ae0011daa = (xeedad81aaed42a76)xeedad81aaed42a.x8b61531c8ea35b85();
					xd0c44e5ae0011daa.x52b190e626f65140(265);
				}
				else
				{
					xd0c44e5ae0011daa = new xeedad81aaed42a76();
					xd0c44e5ae0011daa.xae20093bed1e48a8(190, 24);
					xd0c44e5ae0011daa.xae20093bed1e48a8(350, 24);
				}
			}
			return xd0c44e5ae0011daa;
		}
	}

	public x1a78664fa10a3755 x1a78664fa10a3755
	{
		get
		{
			if (x4379ee33a06c4648 == null)
			{
				x1a78664fa10a3755 x1a78664fa10a = xbd14065dd4b55775();
				if (x1a78664fa10a != null)
				{
					x4379ee33a06c4648 = (x1a78664fa10a3755)x1a78664fa10a.x8b61531c8ea35b85();
				}
				else
				{
					x4379ee33a06c4648 = new x1a78664fa10a3755();
					xa0d3611565b2a1f2.x339a4889e0bd1111(x4379ee33a06c4648, xbcea506a33cf9111: false);
				}
			}
			return x4379ee33a06c4648;
		}
	}

	internal xfc72d4c9b765cad7 xfc72d4c9b765cad7
	{
		get
		{
			if (x13d0010792219ed4 == null)
			{
				xfc72d4c9b765cad7 xfc72d4c9b765cad = x293ffb4a3dfe704d();
				x13d0010792219ed4 = ((xfc72d4c9b765cad != null) ? ((xfc72d4c9b765cad7)xfc72d4c9b765cad.x8b61531c8ea35b85()) : new xfc72d4c9b765cad7());
			}
			return x13d0010792219ed4;
		}
	}

	internal bool x17e2667b58377368
	{
		get
		{
			if (x9da2686459bfa402 != null && x4fa4b8e51b3b2901 == x9da2686459bfa402.x1a55de3a01c1c82d)
			{
				return xef5d8b30300e4f23 != x9da2686459bfa402.x9e0d5f7859d0eba8;
			}
			return true;
		}
	}

	internal x1691a621316cdab5 xb632b7255fb382c2 => x058ccedcbbd47ccd;

	internal int xad3f7e139bf1b10a
	{
		get
		{
			return x8520bd59e7159a87;
		}
		set
		{
			x8520bd59e7159a87 = value;
		}
	}

	private Document x2c8c6741422a1298 => x8cedcaa9a62c6e39.x2c8c6741422a1298;

	internal x52108cac3d36b123 xcfc42ef22e03d2ce => x9da2686459bfa402;

	internal bool xa6aa08c98104c3ae
	{
		get
		{
			return xa33c1ef1c3d4382c;
		}
		set
		{
			xa33c1ef1c3d4382c = value;
		}
	}

	internal x52108cac3d36b123(xe5e546ef5f0503b2 context)
	{
		x8cedcaa9a62c6e39 = context;
		x4fa4b8e51b3b2901 = x8f29675e2802bda2.xa068edde3a4fac55("\\rtf");
		xef5d8b30300e4f23 = new x066f9243a946f443(context);
	}

	internal x52108cac3d36b123(xe5e546ef5f0503b2 context, x52108cac3d36b123 previousState, xbf575e106f2f2373 destinationInfo)
	{
		x8cedcaa9a62c6e39 = context;
		x9da2686459bfa402 = previousState;
		x8520bd59e7159a87 = previousState.xad3f7e139bf1b10a;
		if (x08ecbecb149f6607(destinationInfo))
		{
			x4fa4b8e51b3b2901 = destinationInfo;
			xef5d8b30300e4f23 = x9da2686459bfa402.x9e0d5f7859d0eba8.x3e0bce851c12a688(x4fa4b8e51b3b2901);
		}
		else
		{
			x4fa4b8e51b3b2901 = x9da2686459bfa402.x1a55de3a01c1c82d;
			xef5d8b30300e4f23 = x9da2686459bfa402.x9e0d5f7859d0eba8;
		}
	}

	private static bool x08ecbecb149f6607(xbf575e106f2f2373 x86e1db1b4028be8b)
	{
		if (x86e1db1b4028be8b == null)
		{
			return false;
		}
		switch (x86e1db1b4028be8b.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x25abc19257451256:
		case x25099a8bbbd55d1c.x026b175db0b397b2:
			return false;
		default:
			return true;
		}
	}

	internal void x2ddab4ad01316604()
	{
		x8520bd59e7159a87 = x8cedcaa9a62c6e39.x1ea60bde2b5d0d28.x2ddab4ad01316604;
		xeedad81aaed42a76.x759aa16c2016a289 = x8cedcaa9a62c6e39.x241e429ca27700bc(x8520bd59e7159a87);
	}

	internal void x8fa87c02bfc6a890()
	{
		x8520bd59e7159a87 = -1;
	}

	internal xeedad81aaed42a76 x5f35c5e3977af81d()
	{
		xeedad81aaed42a76 xeedad81aaed42a = (xeedad81aaed42a76)xeedad81aaed42a76.x8b61531c8ea35b85();
		Style style = x2c8c6741422a1298.Styles.xf194004582627ed5(xeedad81aaed42a76.x8301ab10c226b0c2, 10);
		xeedad81aaed42a.x968eca275aff04e3(style.xeedad81aaed42a76, 50);
		return xeedad81aaed42a;
	}

	internal xeedad81aaed42a76 x08c0c7cb41c44cfd()
	{
		xeedad81aaed42a76 xeedad81aaed42a = (xeedad81aaed42a76)xeedad81aaed42a76.x8b61531c8ea35b85();
		Style style = x2c8c6741422a1298.Styles.xf194004582627ed5(xeedad81aaed42a76.x8301ab10c226b0c2, 10);
		xeedad81aaed42a.x968eca275aff04e3(style.xeedad81aaed42a76, 50);
		Style style2 = x2c8c6741422a1298.Styles.xf194004582627ed5(x1a78664fa10a3755.x8301ab10c226b0c2, 0);
		xeedad81aaed42a.x968eca275aff04e3(style2.xeedad81aaed42a76, 50);
		return xeedad81aaed42a;
	}

	internal x1a78664fa10a3755 x365c2d2e4d9ee5fe(bool x643abad651a649d3)
	{
		Style style = x2c8c6741422a1298.Styles.xf194004582627ed5(x1a78664fa10a3755.x8301ab10c226b0c2, 0);
		x20eec3666a2dc8d0.xb07a1ad51e61e4f3(x1a78664fa10a3755);
		x1a78664fa10a3755 x1a78664fa10a = (x1a78664fa10a3755)x1a78664fa10a3755.x8b61531c8ea35b85();
		x1a78664fa10a3755 x1a78664fa10a2 = new x1a78664fa10a3755();
		if (x643abad651a649d3)
		{
			int x8301ab10c226b0c = x8cedcaa9a62c6e39.xde27e91a248c4c90.xedb0eb766e25e0c9.x8301ab10c226b0c2;
			if (x8cedcaa9a62c6e39.x2c8c6741422a1298.Styles.x1976fb6958cf7237(x8301ab10c226b0c, x988fcf605f8efa7e: false) is TableStyle tableStyle)
			{
				tableStyle.x1a78664fa10a3755.xab3af626b1405ee8(x1a78664fa10a2);
			}
		}
		style.x1a78664fa10a3755.xab3af626b1405ee8(x1a78664fa10a2);
		if (x1a78664fa10a.x71c63f7e57f7ede5 == 0)
		{
			x1a78664fa10a.x968eca275aff04e3(x1a78664fa10a2, 1000);
		}
		else
		{
			x1914b17baa0913d7(x1a78664fa10a2, x1a78664fa10a);
		}
		x1a78664fa10a.x52b190e626f65140(1620);
		x1a78664fa10a.x52b190e626f65140(1630);
		x1a78664fa10a.x52b190e626f65140(1610);
		return x1a78664fa10a;
	}

	private void x1914b17baa0913d7(x1a78664fa10a3755 x619b553723c93f86, x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		x1a78664fa10a3755 x1a78664fa10a = new x1a78664fa10a3755();
		List list = x2c8c6741422a1298.Lists.x6c3daa8c787e54bf(x062aae8c9613eeaa.x71c63f7e57f7ede5);
		if (x062aae8c9613eeaa.xf13a626e550cef8f >= list.ListLevels.Count)
		{
			return;
		}
		x1a78664fa10a3755 x1a78664fa10a2 = (x1a78664fa10a3755)x619b553723c93f86.x8b61531c8ea35b85();
		ListLevel listLevel = list.ListLevels[x062aae8c9613eeaa.xf13a626e550cef8f];
		x1a78664fa10a2.x968eca275aff04e3(listLevel.x1a78664fa10a3755);
		for (int i = 0; i < x1a78664fa10a2.xd44988f225497f3a; i++)
		{
			int xba08ce632055a1d = x1a78664fa10a2.xf15263674eb297bb(i);
			object obj = x1a78664fa10a2.xb86fdbeadec3b75c(xba08ce632055a1d);
			object obj2 = x062aae8c9613eeaa.xb86fdbeadec3b75c(xba08ce632055a1d);
			if (obj2 == null || !obj.Equals(obj2))
			{
				x1a78664fa10a.xb6157b6da9895c0d(xba08ce632055a1d, obj);
			}
		}
		x062aae8c9613eeaa.x968eca275aff04e3(x1a78664fa10a, 1000);
	}

	private xeedad81aaed42a76 x93140134709b7d89()
	{
		if (xd0c44e5ae0011daa != null)
		{
			return xd0c44e5ae0011daa;
		}
		if (x9da2686459bfa402 == null)
		{
			return null;
		}
		return x9da2686459bfa402.x93140134709b7d89();
	}

	private x1a78664fa10a3755 xbd14065dd4b55775()
	{
		if (x4379ee33a06c4648 != null)
		{
			return x4379ee33a06c4648;
		}
		if (x9da2686459bfa402 == null)
		{
			return null;
		}
		return x9da2686459bfa402.xbd14065dd4b55775();
	}

	private xfc72d4c9b765cad7 x293ffb4a3dfe704d()
	{
		if (x13d0010792219ed4 != null)
		{
			return x13d0010792219ed4;
		}
		if (x9da2686459bfa402 == null)
		{
			return null;
		}
		return x9da2686459bfa402.x293ffb4a3dfe704d();
	}
}
