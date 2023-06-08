using System.Collections;
using System.Reflection;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

[DefaultMember("Item")]
internal class x2a59e7d832edc719
{
	private int x7cf290e345b9b3cf;

	private int x7b7c4bf07166b4da;

	private readonly ArrayList xc72926de6b6361e2;

	private readonly float x53f147a75a984b21;

	public xf50d3346568ee59f xe6d4b1b411ed94b5
	{
		get
		{
			if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= xc72926de6b6361e2.Count)
			{
				return null;
			}
			return (xf50d3346568ee59f)xc72926de6b6361e2[xc0c4c459c6ccbd00];
		}
	}

	public int xd44988f225497f3a => xc72926de6b6361e2.Count;

	private xf50d3346568ee59f x4d182cac3db00a2e => this.get_xe6d4b1b411ed94b5(xc72926de6b6361e2.Count - 1);

	public x2a59e7d832edc719()
		: this(1f)
	{
	}

	public x2a59e7d832edc719(float scale)
	{
		xc72926de6b6361e2 = new ArrayList();
		x53f147a75a984b21 = scale;
	}

	public void xd6b6ed77479ef68c(int xb73c4e7368f9939f, int xd143f88fddaa10ad, bool x952b94cb9d4a3dce, bool x87e40bdd8460b23f, bool x44c75ba56852f87a)
	{
		int num;
		int num2;
		if (!x44c75ba56852f87a)
		{
			num = x4574ea26106f0edb.x88bf16f2386d633e((float)xb73c4e7368f9939f * x53f147a75a984b21);
			num2 = x4574ea26106f0edb.x88bf16f2386d633e((float)xd143f88fddaa10ad * x53f147a75a984b21);
		}
		else
		{
			num = x4574ea26106f0edb.x88bf16f2386d633e((float)xb73c4e7368f9939f * x53f147a75a984b21) - x7cf290e345b9b3cf;
			num2 = x4574ea26106f0edb.x88bf16f2386d633e((float)xd143f88fddaa10ad * x53f147a75a984b21) - x7b7c4bf07166b4da;
		}
		x7cf290e345b9b3cf += num;
		x7b7c4bf07166b4da += num2;
		xf50d3346568ee59f xf50d3346568ee59f2 = new xf50d3346568ee59f(num, num2, x7cf290e345b9b3cf, x7b7c4bf07166b4da, x952b94cb9d4a3dce, x87e40bdd8460b23f);
		if (x4d182cac3db00a2e == null || !x4d182cac3db00a2e.x4792a30c8e2cad0a || !xf50d3346568ee59f2.x4792a30c8e2cad0a)
		{
			xc72926de6b6361e2.Add(xf50d3346568ee59f2);
		}
	}
}
