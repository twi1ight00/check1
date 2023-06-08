using System;

namespace x4adf554d20d941a6;

internal class x8da06d2b7dd8e7d9
{
	internal static int xa8e1cf14e7fe26fe(x3d1ad8ce75f0db3a xd3311d815ca25f02, bool xffd6352b2e5d70e3)
	{
		if (xd3311d815ca25f02.x954503abc583f675 != x954503abc583f675.x4c38e800e85b21ad)
		{
			return xd94ec9f87d904760(xd3311d815ca25f02, xffd6352b2e5d70e3);
		}
		return x4a06a168e6728f60((x852fe8bb5ac31098)xd3311d815ca25f02, xffd6352b2e5d70e3);
	}

	internal static int x99c80529a1c59616(x53cb1139c5c64ee6 xd7e5673853e47af4, bool xffd6352b2e5d70e3)
	{
		if (!xffd6352b2e5d70e3)
		{
			return xd7e5673853e47af4.x851c2023f5f1cc29;
		}
		return Math.Max(xd7e5673853e47af4.xb0f146032f47c24e, xd7e5673853e47af4.x851c2023f5f1cc29);
	}

	private static int x4a06a168e6728f60(x852fe8bb5ac31098 xe3e287548b3d01f5, bool xffd6352b2e5d70e3)
	{
		return xd94ec9f87d904760(xe3e287548b3d01f5, xffd6352b2e5d70e3) + xd94ec9f87d904760(xe3e287548b3d01f5.x69d28a4aeef83a6f, xffd6352b2e5d70e3) + xd94ec9f87d904760(xe3e287548b3d01f5.xd90ac7fcbe961761, xffd6352b2e5d70e3);
	}

	private static int xd94ec9f87d904760(x3d1ad8ce75f0db3a xd3311d815ca25f02, bool xffd6352b2e5d70e3)
	{
		int num = 0;
		if (xd3311d815ca25f02 == null)
		{
			return num;
		}
		if (!xd3311d815ca25f02.x7149c962c02931b3)
		{
			x398b3bd0acd94b61 x398b3bd0acd94b62 = xd3311d815ca25f02.xe0a65b356d2eb477(null);
			if (x398b3bd0acd94b62 != null)
			{
				num += x398b3bd0acd94b62.xc821290d7ecc08bf + x99c80529a1c59616((x53cb1139c5c64ee6)x398b3bd0acd94b62, xffd6352b2e5d70e3);
			}
		}
		switch (xd3311d815ca25f02.x954503abc583f675)
		{
		case x954503abc583f675.x4c38e800e85b21ad:
			num += xdf2d453305f060f8(xd3311d815ca25f02, xffd6352b2e5d70e3);
			break;
		case x954503abc583f675.x69d28a4aeef83a6f:
		case x954503abc583f675.xd90ac7fcbe961761:
		{
			x78752dd11b777af5 x78752dd11b777af6 = (x78752dd11b777af5)xd3311d815ca25f02;
			num += x78752dd11b777af6.x43604484a3deae4f.xb0f146032f47c24e + x78752dd11b777af6.xcb6bfda2755bdd2d.xb0f146032f47c24e;
			break;
		}
		}
		return num;
	}

	private static int xdf2d453305f060f8(x3d1ad8ce75f0db3a xd3311d815ca25f02, bool xffd6352b2e5d70e3)
	{
		if (xd3311d815ca25f02.x7149c962c02931b3)
		{
			return 0;
		}
		x53cb1139c5c64ee6 x3bb03ef6449f277f = xd3311d815ca25f02.x3bb03ef6449f277f;
		if (x3bb03ef6449f277f == xd3311d815ca25f02.x8b8a0a04b3aeaf3a)
		{
			return 0;
		}
		if (x3bb03ef6449f277f.x954503abc583f675 != x954503abc583f675.x48cc0c3eaf9f5f05)
		{
			return 0;
		}
		xf6937c72cebe4ad1 xf6937c72cebe4ad2 = (xf6937c72cebe4ad1)x3bb03ef6449f277f;
		if (!xf6937c72cebe4ad2.xe1a70206fe31f495())
		{
			return 0;
		}
		if (xf6937c72cebe4ad2.x8abe500f4ab5050d())
		{
			return 0;
		}
		int num = x3bb03ef6449f277f.xc821290d7ecc08bf + x99c80529a1c59616(x3bb03ef6449f277f, xffd6352b2e5d70e3);
		x398b3bd0acd94b61 x398b3bd0acd94b62 = x3bb03ef6449f277f.x9b2bbd3d05bf558b();
		num -= x398b3bd0acd94b62.xc821290d7ecc08bf + x99c80529a1c59616((x53cb1139c5c64ee6)x398b3bd0acd94b62, xffd6352b2e5d70e3);
		return -num;
	}
}
