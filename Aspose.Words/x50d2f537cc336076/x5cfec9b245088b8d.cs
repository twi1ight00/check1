using System.Collections;
using Aspose.Words.Math;
using xe5b37aee2c2a4d4e;

namespace x50d2f537cc336076;

internal class x5cfec9b245088b8d : x57df270da83ea6de
{
	private int x06f4a124e58376d4;

	private x8f75f1da124d37a8 xa9ae918fb5ed0d69;

	private x57df270da83ea6de xe7c75d2092b26d96;

	private x57df270da83ea6de x1ba1bb1699678a28;

	private ArrayList x75bb31fb722ac943 = new ArrayList();

	internal x5cfec9b245088b8d(OfficeMath officeMath)
		: base(officeMath)
	{
		xa9ae918fb5ed0d69 = (x8f75f1da124d37a8)base.xc48e358ce4f81353.x52642f91ccdeeb35;
	}

	internal override void x1fa9148f6731ff24(x57df270da83ea6de x4bbc2c453c470189)
	{
		if (x06f4a124e58376d4 == 0)
		{
			xe7c75d2092b26d96 = new xc1e7448c64b3a897(xa9ae918fb5ed0d69.x074be147c1a0278b.ToString(), base.xc48e358ce4f81353.xeedad81aaed42a76, isArgument: false);
			base.x1fa9148f6731ff24(xe7c75d2092b26d96);
		}
		else
		{
			xc1e7448c64b3a897 xc1e7448c64b3a898 = new xc1e7448c64b3a897(xa9ae918fb5ed0d69.x49b37abfabd470d8.ToString(), base.xc48e358ce4f81353.xeedad81aaed42a76, isArgument: false);
			x75bb31fb722ac943.Add(xc1e7448c64b3a898);
			base.x1fa9148f6731ff24(xc1e7448c64b3a898);
		}
		base.x1fa9148f6731ff24(x4bbc2c453c470189);
		x06f4a124e58376d4++;
	}

	internal override void x62084450a0785b90()
	{
		x1ba1bb1699678a28 = new xc1e7448c64b3a897(xa9ae918fb5ed0d69.x8af0582bac09cece.ToString(), base.xc48e358ce4f81353.xeedad81aaed42a76, isArgument: false);
		base.x1fa9148f6731ff24(x1ba1bb1699678a28);
		base.x62084450a0785b90();
		xee530c57ce448597();
	}

	private void xee530c57ce448597()
	{
		float num = 0f;
		foreach (x57df270da83ea6de item in base.xf2453c298c5de6f5)
		{
			num = ((num > item.x6ae4612a8469678e.Height) ? num : item.x6ae4612a8469678e.Height);
		}
		float x9b8af180a4e21ec = num / xe7c75d2092b26d96.x6ae4612a8469678e.Height;
		xe7c75d2092b26d96.x5152a5707921c783(1f, x9b8af180a4e21ec);
		x1ba1bb1699678a28.x5152a5707921c783(1f, x9b8af180a4e21ec);
		foreach (x57df270da83ea6de item2 in x75bb31fb722ac943)
		{
			item2.x5152a5707921c783(1f, x9b8af180a4e21ec);
		}
	}
}
