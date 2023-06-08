using System;
using Aspose.Words;
using Aspose.Words.Tables;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xd9db44bb47d1be90 : IComparable
{
	internal readonly int x59bc0096de497989;

	internal readonly int x6e1eb96b81362ebc;

	internal PreferredWidth x9962ec7871050cbf = PreferredWidth.Auto;

	internal readonly bool x45b7703476a8d6f3;

	internal int x1fb2a875e6411ef2;

	internal int x1e5325ab72cf7ec9;

	internal int xdc1bf80853046136;

	internal readonly int x92e7e5f35452590d;

	internal readonly int x0924cade9dc2d296;

	internal readonly int xcad2e59522947ede;

	internal readonly int x41c99cca24bc80be;

	private readonly int x9b1baea4e485d168;

	internal xd9db44bb47d1be90(x56b4eac69b5fa65b cellLayout, int columnIndex, int rowIndex, int dummy)
	{
		x59bc0096de497989 = columnIndex;
		x9b1baea4e485d168 = rowIndex;
		x45b7703476a8d6f3 = null != cellLayout.x0c713faf001cb195;
		x71a4a9bfdf7899a6 xdfd0c9de0b4aa96a = cellLayout.xdfd0c9de0b4aa96a;
		if (dummy == 0)
		{
			x6e1eb96b81362ebc = xdfd0c9de0b4aa96a.x6e1eb96b81362ebc;
			x9962ec7871050cbf = xdfd0c9de0b4aa96a.x9962ec7871050cbf;
			xcad2e59522947ede = x4574ea26106f0edb.x5df565b312141b2b(xdfd0c9de0b4aa96a.xcad2e59522947ede);
			x41c99cca24bc80be = x4574ea26106f0edb.x5df565b312141b2b(xdfd0c9de0b4aa96a.x41c99cca24bc80be);
			x92e7e5f35452590d = x4574ea26106f0edb.x5df565b312141b2b(xdfd0c9de0b4aa96a.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Left).x0b5855089a074d93) / 2;
			x0924cade9dc2d296 = x4574ea26106f0edb.x5df565b312141b2b(xdfd0c9de0b4aa96a.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Right).x0b5855089a074d93) / 2;
		}
		else if (0 > dummy)
		{
			x6e1eb96b81362ebc = cellLayout.x838c6c67b5953bb0.x768f9befb545345a.x0364c07ad4dcfe0c;
			x9962ec7871050cbf = PreferredWidth.Auto;
			xcad2e59522947ede = 0;
			x41c99cca24bc80be = 0;
			x92e7e5f35452590d = 0;
			x0924cade9dc2d296 = x4574ea26106f0edb.x5df565b312141b2b(xdfd0c9de0b4aa96a.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Left).x0b5855089a074d93) / 2;
		}
		else
		{
			x6e1eb96b81362ebc = cellLayout.x838c6c67b5953bb0.x768f9befb545345a.x851fcfc17df82b1b;
			x9962ec7871050cbf = PreferredWidth.Auto;
			xcad2e59522947ede = 0;
			x41c99cca24bc80be = 0;
			x92e7e5f35452590d = x4574ea26106f0edb.x5df565b312141b2b(xdfd0c9de0b4aa96a.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Right).x0b5855089a074d93) / 2;
			x0924cade9dc2d296 = 0;
		}
	}

	public int CompareTo(object obj)
	{
		if (!(obj is xd9db44bb47d1be90))
		{
			return -1;
		}
		xd9db44bb47d1be90 xd9db44bb47d1be91 = (xd9db44bb47d1be90)obj;
		if (x6e1eb96b81362ebc != xd9db44bb47d1be91.x6e1eb96b81362ebc)
		{
			return x6e1eb96b81362ebc.CompareTo(xd9db44bb47d1be91.x6e1eb96b81362ebc);
		}
		if (x9b1baea4e485d168 != xd9db44bb47d1be91.x9b1baea4e485d168)
		{
			return x9b1baea4e485d168.CompareTo(xd9db44bb47d1be91.x9b1baea4e485d168);
		}
		return x59bc0096de497989.CompareTo(xd9db44bb47d1be91.x59bc0096de497989);
	}
}
