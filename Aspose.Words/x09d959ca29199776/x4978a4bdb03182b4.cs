using System.Collections;
using x6c95d9cf46ff5f25;

namespace x09d959ca29199776;

internal class x4978a4bdb03182b4
{
	private readonly x6d7e3670c019f432[] xc7d5d28b3f8072cd;

	private readonly Hashtable x5be6c60f43c6fb45 = new Hashtable();

	private readonly x6d7e3670c019f432 xb98a60faee9bf68f;

	public x4978a4bdb03182b4(int symbolsCount)
	{
		int num = 2 * symbolsCount;
		xc7d5d28b3f8072cd = new x6d7e3670c019f432[num];
		for (int i = 1; i < num; i++)
		{
			x6d7e3670c019f432 x6d7e3670c019f433 = new x6d7e3670c019f432
			{
				xd1bdf42207dd3638 = i
			};
			xc7d5d28b3f8072cd[i] = x6d7e3670c019f433;
		}
		for (int j = 1; j < num; j++)
		{
			x6d7e3670c019f432 x6d7e3670c019f434 = xc7d5d28b3f8072cd[j];
			if (j > 1)
			{
				x6d7e3670c019f434.x332a8eedb847940d = xc7d5d28b3f8072cd[j / 2];
			}
			if (j < symbolsCount)
			{
				x6d7e3670c019f434.x782bb6538e64cacf = xc7d5d28b3f8072cd[2 * j];
				x6d7e3670c019f434.x0ea8d41798209f7f = xc7d5d28b3f8072cd[2 * j + 1];
			}
			if (j >= symbolsCount)
			{
				x6d7e3670c019f434.xe59d6d35c76d70aa = j - symbolsCount;
				x6d7e3670c019f434.x64e2a404bc6b1659 = 1L;
				x5be6c60f43c6fb45.Add(x6d7e3670c019f434.xe59d6d35c76d70aa, x6d7e3670c019f434);
			}
		}
		xb98a60faee9bf68f = xc7d5d28b3f8072cd[1];
		xb98a60faee9bf68f.x3296bf00bdec7b24();
	}

	public void x42237e0547d7298c(int xc1db5dbaf009ebd2)
	{
		x6d7e3670c019f432 x6d7e3670c019f433 = (x6d7e3670c019f432)x5be6c60f43c6fb45[xc1db5dbaf009ebd2];
		while (true)
		{
			x6d7e3670c019f433.x64e2a404bc6b1659++;
			if (x6d7e3670c019f433 == xb98a60faee9bf68f)
			{
				break;
			}
			if (xc7d5d28b3f8072cd[x6d7e3670c019f433.xd1bdf42207dd3638 - 1].x64e2a404bc6b1659 == x6d7e3670c019f433.x64e2a404bc6b1659 - 1)
			{
				int num = x6d7e3670c019f433.xd1bdf42207dd3638 - 1;
				while (xc7d5d28b3f8072cd[num - 1].x64e2a404bc6b1659 < x6d7e3670c019f433.x64e2a404bc6b1659)
				{
					num--;
				}
				xbe910a46297b5f08(x6d7e3670c019f433.xd1bdf42207dd3638, num);
			}
			x6d7e3670c019f433 = x6d7e3670c019f433.x332a8eedb847940d;
		}
	}

	private void xbe910a46297b5f08(int xf7e215e1838896a3, int xe06991c4ef8a1732)
	{
		x6d7e3670c019f432 x6d7e3670c019f433 = xc7d5d28b3f8072cd[xf7e215e1838896a3];
		x6d7e3670c019f432 x6d7e3670c019f434 = xc7d5d28b3f8072cd[xe06991c4ef8a1732];
		xc7d5d28b3f8072cd[xf7e215e1838896a3] = x6d7e3670c019f434;
		xc7d5d28b3f8072cd[xe06991c4ef8a1732] = x6d7e3670c019f433;
		xc7d5d28b3f8072cd[xf7e215e1838896a3].xd1bdf42207dd3638 = xf7e215e1838896a3;
		xc7d5d28b3f8072cd[xe06991c4ef8a1732].xd1bdf42207dd3638 = xe06991c4ef8a1732;
		x3b2aa7dafaf77180(x6d7e3670c019f433, x6d7e3670c019f434);
	}

	private void x3b2aa7dafaf77180(x6d7e3670c019f432 x54357f622b23380b, x6d7e3670c019f432 x59951c70187d7fc5)
	{
		x6d7e3670c019f432 x332a8eedb847940d = x54357f622b23380b.x332a8eedb847940d;
		x6d7e3670c019f432 x332a8eedb847940d2 = x59951c70187d7fc5.x332a8eedb847940d;
		if (x332a8eedb847940d.x782bb6538e64cacf == x54357f622b23380b)
		{
			x332a8eedb847940d.x5ab1a812e30d95b7(x59951c70187d7fc5);
		}
		else
		{
			x332a8eedb847940d.xee40d78258778168(x59951c70187d7fc5);
		}
		if (x332a8eedb847940d2.x782bb6538e64cacf == x59951c70187d7fc5)
		{
			x332a8eedb847940d2.x5ab1a812e30d95b7(x54357f622b23380b);
		}
		else
		{
			x332a8eedb847940d2.xee40d78258778168(x54357f622b23380b);
		}
	}

	public int xe692a3d77ab7e374(x05cddb129b0360cd xe134235b3526fa75)
	{
		int num = x50a0aa193f9f43f8(xe134235b3526fa75);
		x42237e0547d7298c(num);
		return num;
	}

	public int x50a0aa193f9f43f8(x05cddb129b0360cd xe134235b3526fa75)
	{
		x6d7e3670c019f432 x6d7e3670c019f433 = xb98a60faee9bf68f;
		while (!x6d7e3670c019f433.xf065f1542d0d16e9)
		{
			x6d7e3670c019f433 = (xe134235b3526fa75.xa1e7dc86736d5ffd() ? x6d7e3670c019f433.x0ea8d41798209f7f : x6d7e3670c019f433.x782bb6538e64cacf);
		}
		return x6d7e3670c019f433.xe59d6d35c76d70aa;
	}
}
