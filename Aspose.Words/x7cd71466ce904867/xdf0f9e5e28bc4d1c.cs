using System.Collections;
using System.Drawing;
using x4dc96876c552a593;
using x5794c252ba25e723;
using x996431aaaaf00543;

namespace x7cd71466ce904867;

internal class xdf0f9e5e28bc4d1c : x2280a05d939c907e
{
	private readonly x1709225c4bd1ed83 x21328b445a743482;

	private Hashtable x154caea24cfa721a = new Hashtable();

	public xdf0f9e5e28bc4d1c(x1709225c4bd1ed83 dataProvider)
	{
		x21328b445a743482 = dataProvider;
	}

	public xe39d06eee35dd23d xef51a39b06006bb9(x7423ef514d81c23e xe11545499171cc05)
	{
		xe39d06eee35dd23d xe39d06eee35dd23d = (xe39d06eee35dd23d)x154caea24cfa721a[xe11545499171cc05];
		if (xe39d06eee35dd23d == null)
		{
			x34b039801e93e11a x6d528e2b40b8fe2b = xe11545499171cc05.x6d528e2b40b8fe2b;
			string xeed997b9da = x6d528e2b40b8fe2b.xeed997b9da346323;
			double x5842b5fc61b80e = xe11545499171cc05.x70c328f6f2e77d76.x5842b5fc61b80e47;
			FontStyle x44ecfea61c937b8e = xe11545499171cc05.x659bc4263aa7ef66();
			xe39d06eee35dd23d = x21328b445a743482.xdc2247c8d4648ae8(xeed997b9da, (float)x5842b5fc61b80e, x44ecfea61c937b8e);
			x154caea24cfa721a[xe11545499171cc05] = xe39d06eee35dd23d;
		}
		return xe39d06eee35dd23d;
	}
}
