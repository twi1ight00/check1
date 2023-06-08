using System;
using System.Collections;
using Aspose.Words.Fields;
using xfbd1009a0cbb9842;

namespace x4adf554d20d941a6;

internal sealed class x9b9129deff8239b5 : xdac068096ca09318
{
	private readonly Hashtable xf4534a93f13f6ff3;

	internal override int x5f21ccf084377ea8(FieldStart x10aaa7cdfa38f254)
	{
		return ((x5c28fdcd27dee7d9)xf4534a93f13f6ff3[x10aaa7cdfa38f254])?.x9ec60fbbaa3117a2() ?? (-1);
	}

	internal x9b9129deff8239b5(x5c28fdcd27dee7d9 root)
	{
		xf4534a93f13f6ff3 = new Hashtable();
		x5c28fdcd27dee7d9 x70ff891026cb = root.x70ff891026cb8704;
		xf3f447691ab38eee xf3f447691ab38eee2 = root.x53111d6596d16a99.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
		xf3f447691ab38eee2.xd8b11076ff837685(root);
		x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
		while (xf3f447691ab38eee2.x35cfcea4890f4e7d != x70ff891026cb)
		{
			if (x56410a8dd70087c6 is x5c28fdcd27dee7d9 && x56410a8dd70087c6.x6e414db5d060a816 == x6e414db5d060a816.x12cb12b5d2cad53d)
			{
				xf4534a93f13f6ff3[((x5c28fdcd27dee7d9)x56410a8dd70087c6).xb7c4cf9f30ad5f2a] = x56410a8dd70087c6;
			}
			if (!xf3f447691ab38eee2.x47f176deff0d42e2())
			{
				throw new InvalidOperationException();
			}
			x56410a8dd70087c6 = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
		}
	}

	internal override int x39cb3bc7700d4896(FieldStart xa6315bf377f6364c)
	{
		x5c28fdcd27dee7d9 x5c28fdcd27dee7d10 = (x5c28fdcd27dee7d9)xf4534a93f13f6ff3[xa6315bf377f6364c];
		if (x5c28fdcd27dee7d10 == null)
		{
			return -1;
		}
		xc7f90d9c7c51cede xc7f90d9c7c51cede2 = x5c28fdcd27dee7d10.x776fd7c2f7270172();
		if (xc7f90d9c7c51cede2 == null)
		{
			return -1;
		}
		return xd0d1750eb1650d8f(xc7f90d9c7c51cede2.x3c1c340351d94fbd);
	}

	private static int xd0d1750eb1650d8f(xf6689e0eed33812c xb32f8dd719a105db)
	{
		int num = 0;
		for (xf6689e0eed33812c x488a096134880397 = xb32f8dd719a105db.x488a096134880397; x488a096134880397 != null; x488a096134880397 = x488a096134880397.x488a096134880397)
		{
			num++;
		}
		return num;
	}
}
