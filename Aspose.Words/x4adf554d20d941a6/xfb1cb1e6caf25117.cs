using System;
using System.Collections;
using x59d6a4fc5007b7a4;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xfb1cb1e6caf25117
{
	private x56410a8dd70087c5 x54fbb9744a146a49;

	private x56410a8dd70087c5 x379a91e1325faf94;

	private bool x12e4d8adb24eab18;

	private bool x07b5a5e21d727f5d;

	private bool x8e3f43d7b5c2a04b;

	internal x56410a8dd70087c5 xdc3f248db6e996ed => x54fbb9744a146a49;

	internal x56410a8dd70087c5 xeb32eef76de0526d => x379a91e1325faf94;

	internal void xf7390e8e427dfeb0(x56410a8dd70087c5 x62584df2cb5d40dd, x56410a8dd70087c5 x2aa5114a5da7d6c8)
	{
		x56410a8dd70087c5 x56410a8dd70087c6 = null;
		x56410a8dd70087c5 x56410a8dd70087c7 = x62584df2cb5d40dd;
		xf6937c72cebe4ad1 x5a7799e1836857e = x62584df2cb5d40dd.x5a7799e1836857e3;
		x07b5a5e21d727f5d = x5a7799e1836857e.x8786efe6471e0521;
		x8e3f43d7b5c2a04b = true;
		ArrayList arrayList = new ArrayList();
		while (x56410a8dd70087c7 != x2aa5114a5da7d6c8)
		{
			if (!x56410a8dd70087c7.x3a7473f820dd300b)
			{
				x8e3f43d7b5c2a04b = false;
			}
			if (x54c2198eca0de00a(x56410a8dd70087c7))
			{
				x12e4d8adb24eab18 = true;
			}
			arrayList.Add(x56410a8dd70087c7);
			x56410a8dd70087c7 = x56410a8dd70087c7.x61712f0b4f5455af;
		}
		if (x5566e2d2acbd1fbe.x6634ed9c1dfbdfce(x56410a8dd70087c7.x5566e2d2acbd1fbe))
		{
			x56410a8dd70087c6 = x56410a8dd70087c7;
		}
		else
		{
			arrayList.Add(x56410a8dd70087c7);
		}
		ArrayList arrayList2;
		if (arrayList.Count > 0)
		{
			x56410a8dd70087c5[] xf394610890661b = (x56410a8dd70087c5[])arrayList.ToArray(typeof(x56410a8dd70087c5));
			arrayList2 = new ArrayList(xad4507dbaa6d986b(xf394610890661b));
		}
		else
		{
			arrayList2 = arrayList;
		}
		if (x56410a8dd70087c6 != null)
		{
			arrayList2.Add(x56410a8dd70087c6);
		}
		x3eed0d01b2ed281e((x56410a8dd70087c5[])arrayList2.ToArray(typeof(x56410a8dd70087c5)), x5a7799e1836857e, x2aa5114a5da7d6c8);
		x54fbb9744a146a49 = (x56410a8dd70087c5)arrayList2[0];
		x379a91e1325faf94 = (x56410a8dd70087c5)arrayList2[arrayList2.Count - 1];
	}

	private static void x3eed0d01b2ed281e(x56410a8dd70087c5[] x598af49f12083ede, xf6937c72cebe4ad1 x311e7a92306d7199, x56410a8dd70087c5 x2aa5114a5da7d6c8)
	{
		x311e7a92306d7199.xdc3f248db6e996ed = x598af49f12083ede[0];
		x311e7a92306d7199.xeb32eef76de0526d = x598af49f12083ede[^1];
		if (x2aa5114a5da7d6c8 != null && x2aa5114a5da7d6c8.x61712f0b4f5455af != null)
		{
			x311e7a92306d7199.xeb32eef76de0526d.x89e5ac7f37777759 = x2aa5114a5da7d6c8.x61712f0b4f5455af;
		}
		for (int i = 0; i < x598af49f12083ede.Length; i++)
		{
			x598af49f12083ede[i].x89e5ac7f37777759 = ((i < x598af49f12083ede.Length - 1) ? x598af49f12083ede[i + 1] : null);
			x598af49f12083ede[i].x6b19f5555751d451 = ((i > 0) ? x598af49f12083ede[i - 1] : null);
		}
		if (x311e7a92306d7199.xa573efc4845474fe != null)
		{
			xf6937c72cebe4ad1 xa573efc4845474fe = x311e7a92306d7199.xa573efc4845474fe;
			xa573efc4845474fe.xeb32eef76de0526d.x89e5ac7f37777759 = x311e7a92306d7199.xdc3f248db6e996ed;
			x311e7a92306d7199.xdc3f248db6e996ed.x6b19f5555751d451 = xa573efc4845474fe.xeb32eef76de0526d;
		}
	}

	private static bool x54c2198eca0de00a(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x4a1a6d8b0aafa0fe == x4a1a6d8b0aafa0fe.x0b228ef3d2b6a257)
		{
			return !x5906905c888d3d98.x3a7473f820dd300b;
		}
		return false;
	}

	private x56410a8dd70087c5[] xad4507dbaa6d986b(x56410a8dd70087c5[] xf394610890661b74)
	{
		if (x12e4d8adb24eab18)
		{
			x5a30de40811ce006.x6a00974ede739608(xf394610890661b74);
		}
		int[][] xa5357d961b = x16e6ddccbd6090b2(xf394610890661b74);
		x56410a8dd70087c5[] array = ((!x07b5a5e21d727f5d && x12e4d8adb24eab18) ? xf394610890661b74 : xb90c6679384a1b77(xf394610890661b74, xa5357d961b));
		if (x07b5a5e21d727f5d || x8e3f43d7b5c2a04b)
		{
			array = xce81e0b70849d151(array, xa5357d961b);
		}
		return array;
	}

	private int[][] x16e6ddccbd6090b2(x56410a8dd70087c5[] xf394610890661b74)
	{
		x56410a8dd70087c5 xfe76f101e948db = null;
		ArrayList arrayList = new ArrayList();
		if (!x12e4d8adb24eab18)
		{
			x05005184be56f1e6(xf394610890661b74[0]);
		}
		int x3a03159a374ab4fd = xf394610890661b74[0].x3a03159a374ab4fd;
		bool x3a7473f820dd300b = xf394610890661b74[0].x3a7473f820dd300b;
		arrayList.Add(new int[2] { 0, x3a03159a374ab4fd });
		int i;
		for (i = 0; i < xf394610890661b74.Length; i++)
		{
			x56410a8dd70087c5 x56410a8dd70087c6 = xf394610890661b74[i];
			if (!x12e4d8adb24eab18)
			{
				x05005184be56f1e6(x56410a8dd70087c6);
			}
			xde90838569682efc(x56410a8dd70087c6, xfe76f101e948db);
			if (xa355288d7f02ee12(x56410a8dd70087c6))
			{
				xfe76f101e948db = (x5423e00c3f9b1b98(x56410a8dd70087c6) ? x56410a8dd70087c6 : null);
			}
			if (x5e86fccc8604e844(x56410a8dd70087c6, x3a03159a374ab4fd, x3a7473f820dd300b))
			{
				arrayList.Add(new int[2] { i, x56410a8dd70087c6.x3a03159a374ab4fd });
				x3a03159a374ab4fd = x56410a8dd70087c6.x3a03159a374ab4fd;
				x3a7473f820dd300b = x56410a8dd70087c6.x3a7473f820dd300b;
			}
		}
		arrayList.Add(new int[2] { i, x3a03159a374ab4fd });
		return (int[][])arrayList.ToArray(typeof(int[]));
	}

	private bool x5e86fccc8604e844(x56410a8dd70087c5 x5906905c888d3d98, int x889011be42abb339, bool xd1d8b24dea84dd13)
	{
		if (!x07b5a5e21d727f5d && x0d299f323d241756.x5959bccb67bbf051(x5906905c888d3d98.xf9ad6fb78355fe13) && x34a37b5a89c466fd.x6657b4a72cfac626(x5906905c888d3d98.xf9ad6fb78355fe13[0]))
		{
			return false;
		}
		if (x5906905c888d3d98.x3a03159a374ab4fd != x889011be42abb339 || x5906905c888d3d98.x3a7473f820dd300b != xd1d8b24dea84dd13)
		{
			return xa355288d7f02ee12(x5906905c888d3d98);
		}
		return false;
	}

	private static bool xa355288d7f02ee12(x56410a8dd70087c5 x5906905c888d3d98)
	{
		return x5906905c888d3d98.x5566e2d2acbd1fbe != 0;
	}

	private static void x05005184be56f1e6(x56410a8dd70087c5 x5906905c888d3d98)
	{
		bool flag = x5906905c888d3d98.x3a7473f820dd300b;
		if (x7dbc071259fb713c(x5906905c888d3d98))
		{
			flag = true;
		}
		x5906905c888d3d98.x3a03159a374ab4fd = (flag ? 1 : 0);
	}

	private static void xde90838569682efc(x56410a8dd70087c5 x5906905c888d3d98, x56410a8dd70087c5 xfe76f101e948db67)
	{
		if (x5973284cfbef2665(x5906905c888d3d98, xfe76f101e948db67) && x34a37b5a89c466fd.x230a8c5c1df6b703(x5906905c888d3d98.xf9ad6fb78355fe13[0], x769ea5e930af2cbc.x68e6a98ab5d29468(x5906905c888d3d98.x626efc37c410c502)))
		{
			x5906905c888d3d98.x3a03159a374ab4fd = 0;
			if (xfe76f101e948db67.x705ed5f9769744e5.x33b9d351396f0e2f == x5906905c888d3d98.x705ed5f9769744e5.x33b9d351396f0e2f && xfe76f101e948db67.x705ed5f9769744e5 != x5906905c888d3d98.x705ed5f9769744e5)
			{
				x5906905c888d3d98.x705ed5f9769744e5 = x396b77a306f83da6.x38758cbbee49e4cb(xfe76f101e948db67.x705ed5f9769744e5);
			}
		}
		if (x5423e00c3f9b1b98(x5906905c888d3d98))
		{
			x5906905c888d3d98.x3a03159a374ab4fd = 0;
		}
	}

	private static bool x7dbc071259fb713c(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x5566e2d2acbd1fbe == 10754)
		{
			if (x5906905c888d3d98.xbd2e6df53b2331ee == null || x5906905c888d3d98.x12e57449accbce52 == null || !x5906905c888d3d98.x12e57449accbce52.x3a7473f820dd300b || !x5906905c888d3d98.xbd2e6df53b2331ee.x3a7473f820dd300b)
			{
				if (x5906905c888d3d98.xbd2e6df53b2331ee == null && x5906905c888d3d98.x12e57449accbce52 != null)
				{
					return x5906905c888d3d98.x12e57449accbce52.x3a7473f820dd300b;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private static bool x5973284cfbef2665(x56410a8dd70087c5 x5906905c888d3d98, x56410a8dd70087c5 xfe76f101e948db67)
	{
		if (x5906905c888d3d98.x5566e2d2acbd1fbe == 9217 && xfe76f101e948db67 != null && !x5423e00c3f9b1b98(x5906905c888d3d98) && x5906905c888d3d98.xf9ad6fb78355fe13.Length == 1)
		{
			return xf164e4512fd7a467(x5906905c888d3d98);
		}
		return false;
	}

	private static bool xf164e4512fd7a467(x56410a8dd70087c5 x5906905c888d3d98)
	{
		x5906905c888d3d98 = x5906905c888d3d98.xbd2e6df53b2331ee;
		while (x5906905c888d3d98 != null && x5906905c888d3d98.x5566e2d2acbd1fbe == 0)
		{
			x5906905c888d3d98 = x5906905c888d3d98.xbd2e6df53b2331ee;
		}
		if (x5906905c888d3d98 != null && x5906905c888d3d98.x5566e2d2acbd1fbe == 9217)
		{
			return x5423e00c3f9b1b98(x5906905c888d3d98);
		}
		return false;
	}

	private static bool x5423e00c3f9b1b98(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x5566e2d2acbd1fbe == 9217)
		{
			return x34a37b5a89c466fd.x6657b4a72cfac626(x5906905c888d3d98.xf9ad6fb78355fe13[0]);
		}
		return false;
	}

	private static x56410a8dd70087c5[] xb90c6679384a1b77(x56410a8dd70087c5[] x6d394cddc56557db, int[][] xa5357d961b197342)
	{
		x56410a8dd70087c5[] array = new x56410a8dd70087c5[x6d394cddc56557db.Length];
		x6d394cddc56557db.CopyTo(array, 0);
		for (int i = 0; i < xa5357d961b197342.Length - 1; i++)
		{
			if (xa5357d961b197342[i][1] == 1)
			{
				int index = xa5357d961b197342[i][0];
				int length = xa5357d961b197342[i + 1][0] - xa5357d961b197342[i][0];
				Array.Reverse(array, index, length);
			}
		}
		return array;
	}

	private x56410a8dd70087c5[] xce81e0b70849d151(x56410a8dd70087c5[] x6d394cddc56557db, int[][] xa5357d961b197342)
	{
		x56410a8dd70087c5[] array = new x56410a8dd70087c5[x6d394cddc56557db.Length];
		Array.Reverse(xa5357d961b197342);
		int num = 0;
		for (int i = 0; i < xa5357d961b197342.Length - 1; i++)
		{
			int num2 = xa5357d961b197342[i + 1][0];
			int num3 = xa5357d961b197342[i][0] - num2;
			Array.Copy(x6d394cddc56557db, num2, array, num, num3);
			num += num3;
		}
		if (x07b5a5e21d727f5d)
		{
			Array.Reverse(array);
		}
		return array;
	}
}
