using System;
using System.Collections;
using System.Drawing;
using Aspose.Words;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class xdcf47a8f1807f37c : xb850ecb8335a2e09
{
	internal readonly Document x2c8c6741422a1298;

	private x1740478edaeaa566 x3befc831c712898b;

	internal x1740478edaeaa566 xde931fb7c0e6373a
	{
		get
		{
			if (x3befc831c712898b == null)
			{
				x3befc831c712898b = x3557aa8566455ba9.xa86006fbc4aa4bd7(xa65184d44a47025b);
			}
			return x3befc831c712898b;
		}
	}

	internal int xef64f56541986736
	{
		get
		{
			xacf1bb6be5092987 xf48cd6e82340ac = xa65184d44a47025b.x3c1c340351d94fbd.xf48cd6e82340ac70;
			if (!xa65184d44a47025b.xc0e56f2fca892328)
			{
				return xf48cd6e82340ac.x781c87b545573ab1;
			}
			return xf48cd6e82340ac.xd8dd413f3526822a;
		}
	}

	internal override float x72d92bd1aff02e37 => 0f;

	internal override float xe360b1885d8d4a41 => 0f;

	internal xc7f90d9c7c51cede xa65184d44a47025b => (xc7f90d9c7c51cede)x9fb0e9c0b1bdc4b3;

	private ArrayList x4e020dae918bd2ce => (ArrayList)x9fb0e9c0b1bdc4b3.x2c8c6741422a1298.x62463f2402f0120e[x9fb0e9c0b1bdc4b3];

	internal bool x53a759df62a20324
	{
		get
		{
			if (x2c8c6741422a1298.xdade2366eaa6f915.x445faafef4d65da6 && x4e020dae918bd2ce != null)
			{
				return x4e020dae918bd2ce.Count > 0;
			}
			return false;
		}
	}

	internal xdcf47a8f1807f37c(Document document, x398b3bd0acd94b61 part)
		: base(part)
	{
		x2c8c6741422a1298 = document;
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		x672ff13faf031f3d.xb657ee9ee2ce188a(this);
		foreach (xa67197c42bddc7dc item in xa65184d44a47025b.xe42bd130f1e95570[0])
		{
			new xa7492065dee59ad0(item).x7012609bcdb39574(x672ff13faf031f3d);
		}
		if (xa65184d44a47025b.x1ea60bde2b5d0d28 != null)
		{
			x24007e5c985fb52a x24007e5c985fb52a2 = new x24007e5c985fb52a(xa65184d44a47025b.x1ea60bde2b5d0d28, xa65184d44a47025b);
			x24007e5c985fb52a2.x7012609bcdb39574(x672ff13faf031f3d);
		}
		if (xa65184d44a47025b.x1d7b771e95a9abb5 != null)
		{
			x24007e5c985fb52a x24007e5c985fb52a3 = new x24007e5c985fb52a(xa65184d44a47025b.x1d7b771e95a9abb5, xa65184d44a47025b);
			x24007e5c985fb52a3.x7012609bcdb39574(x672ff13faf031f3d);
		}
		foreach (xa67197c42bddc7dc item2 in xa65184d44a47025b.xe42bd130f1e95570[1])
		{
			new xa7492065dee59ad0(item2).x7012609bcdb39574(x672ff13faf031f3d);
		}
		x852fe8bb5ac31098[] array = xa65184d44a47025b.x217b15e880e7d6ac(null, null);
		x852fe8bb5ac31098[] array2 = array;
		foreach (x852fe8bb5ac31098 part3 in array2)
		{
			new x512b9a381ad7cd9c(part3, xa65184d44a47025b).x7012609bcdb39574(x672ff13faf031f3d);
		}
		xb850ecb8335a2e09.xa0d387f9dc55e84f(x672ff13faf031f3d, xa65184d44a47025b.xf9d5944b191eb276(x5aa7d09b258e0f23: false));
		foreach (xa67197c42bddc7dc item3 in xa65184d44a47025b.xe42bd130f1e95570[2])
		{
			new xa7492065dee59ad0(item3).x7012609bcdb39574(x672ff13faf031f3d);
		}
		x672ff13faf031f3d.x0d9fe863128f7451(this);
	}

	internal void x4dac52894f72430e(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		if (x53a759df62a20324)
		{
			ArrayList x540a9eb552a13d7b = x4e020dae918bd2ce;
			x1da20d2d919943e0(x540a9eb552a13d7b);
			int xf174fd389542c5d = x3c05b736ab632d2d(x540a9eb552a13d7b);
			x2e75f59e11648e0a(x540a9eb552a13d7b, xf174fd389542c5d, xa65184d44a47025b.xd7fab63fabd0a319 - xa65184d44a47025b.xd985b37e5f570f69);
			x34b1fb867f24b846(x540a9eb552a13d7b);
		}
	}

	internal ArrayList x008093d2a2c25e80()
	{
		if (!x53a759df62a20324)
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = x4e020dae918bd2ce;
		for (int i = 0; i < arrayList2.Count; i++)
		{
			arrayList.Add(new xbe34d29d368fc922((xe66ac07cc471e42e)arrayList2[i]));
		}
		return arrayList;
	}

	internal RectangleF xd39e4a5fb49400d6()
	{
		int x = xa65184d44a47025b.x5f6c85e261732738 + xe66ac07cc471e42e.x617b879dd287c1b8;
		int y = 0;
		int x6545d1f2c1b = xe66ac07cc471e42e.x6545d1f2c1b77773;
		int height = x9fb0e9c0b1bdc4b3.xb0f146032f47c24e;
		return x4574ea26106f0edb.xc96d70553223ee04(new Rectangle(x, y, x6545d1f2c1b, height));
	}

	private void x34b1fb867f24b846(ArrayList x540a9eb552a13d7b)
	{
		xe66ac07cc471e42e xe66ac07cc471e42e = null;
		for (int i = 0; i < x540a9eb552a13d7b.Count; i++)
		{
			xe66ac07cc471e42e xe66ac07cc471e42e2 = (xe66ac07cc471e42e)x540a9eb552a13d7b[i];
			xe66ac07cc471e42e2.xc821290d7ecc08bf = ((xe66ac07cc471e42e != null) ? (xe66ac07cc471e42e.x9bcb07e204e30218 + xe66ac07cc471e42e.x9ba60a33bc3988dc) : xa65184d44a47025b.xd985b37e5f570f69);
			xe66ac07cc471e42e2.x8df91a2f90079e88 = xa65184d44a47025b.x5f6c85e261732738 + xe66ac07cc471e42e.x617b879dd287c1b8 + xe66ac07cc471e42e.x7a74dd0377a52fcb;
			xe66ac07cc471e42e = xe66ac07cc471e42e2;
		}
	}

	private static void x1da20d2d919943e0(ArrayList x540a9eb552a13d7b)
	{
		x4ddd0723770f9758 x4ddd0723770f = new x4ddd0723770f9758();
		for (int i = 0; i < x540a9eb552a13d7b.Count; i++)
		{
			xe66ac07cc471e42e xe66ac07cc471e42e = (xe66ac07cc471e42e)x540a9eb552a13d7b[i];
			x4ddd0723770f.xc3819e13f60dd8e6(xe66ac07cc471e42e, 1073741823, x3175070523842c98: true, x4097fa47409be495: false);
			xe66ac07cc471e42e.xb0f146032f47c24e = x4ddd0723770f.x851c2023f5f1cc29;
		}
	}

	private static int x3c05b736ab632d2d(ArrayList x540a9eb552a13d7b)
	{
		int num = xe66ac07cc471e42e.x9ba60a33bc3988dc;
		for (int i = 0; i < x540a9eb552a13d7b.Count; i++)
		{
			xe66ac07cc471e42e xe66ac07cc471e42e = (xe66ac07cc471e42e)x540a9eb552a13d7b[i];
			for (x398b3bd0acd94b61 x398b3bd0acd94b = xe66ac07cc471e42e.x8b8a0a04b3aeaf3a; x398b3bd0acd94b != null; x398b3bd0acd94b = x398b3bd0acd94b.xf34a54c031e96d83())
			{
				if (x398b3bd0acd94b.x954503abc583f675 == x954503abc583f675.xa19781cfbe8b4961)
				{
					xe66ac07cc471e42e.xb0f146032f47c24e = x398b3bd0acd94b.xc821290d7ecc08bf + xe66ac07cc471e42e.x169ccf570c1dc425;
					break;
				}
			}
			num += xe66ac07cc471e42e.xb0f146032f47c24e + xe66ac07cc471e42e.x9ba60a33bc3988dc;
		}
		return num;
	}

	private static void x2e75f59e11648e0a(ArrayList x540a9eb552a13d7b, int xf174fd389542c5d3, int x4cdec2a216023640)
	{
		if (xf174fd389542c5d3 > x4cdec2a216023640)
		{
			int x0544ac0ec01356ec = (x4cdec2a216023640 - (x540a9eb552a13d7b.Count + 1) * xe66ac07cc471e42e.x9ba60a33bc3988dc) / x540a9eb552a13d7b.Count;
			xf174fd389542c5d3 = xa757e9918b158a1e(x540a9eb552a13d7b, xf174fd389542c5d3, x4cdec2a216023640, x0544ac0ec01356ec);
			xa757e9918b158a1e(x540a9eb552a13d7b, xf174fd389542c5d3, x4cdec2a216023640, 0);
		}
	}

	private static int xa757e9918b158a1e(ArrayList x540a9eb552a13d7b, int xf174fd389542c5d3, int x4cdec2a216023640, int x0544ac0ec01356ec)
	{
		int num = x540a9eb552a13d7b.Count - 1;
		while (num >= 0 && xf174fd389542c5d3 > x4cdec2a216023640)
		{
			xe66ac07cc471e42e xe66ac07cc471e42e = (xe66ac07cc471e42e)x540a9eb552a13d7b[num];
			int val = xe66ac07cc471e42e.x8b8a0a04b3aeaf3a.x9bcb07e204e30218 + xe66ac07cc471e42e.x169ccf570c1dc425;
			int num2 = xe66ac07cc471e42e.xb0f146032f47c24e - Math.Max(val, x0544ac0ec01356ec);
			if (num2 > 0)
			{
				xf174fd389542c5d3 -= num2;
				xe66ac07cc471e42e.xb0f146032f47c24e -= num2;
			}
			num--;
		}
		return xf174fd389542c5d3;
	}
}
