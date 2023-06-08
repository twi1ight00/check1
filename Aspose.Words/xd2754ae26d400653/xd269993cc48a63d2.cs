using Aspose.Words.Lists;
using x38d3ef1c1d247e82;

namespace xd2754ae26d400653;

internal class xd269993cc48a63d2
{
	private readonly x178ff6dcbf808c38 xc1e8aac83e2f5781;

	private List x870980ad82373217;

	private readonly x1e9b3e0e8864e135 x965194be84c7d941;

	private int xaabccab0c06d038b;

	private readonly int[] xe5c119bbf35c0d0b;

	internal int x51e5bb947db89a97 => xaabccab0c06d038b;

	internal xd269993cc48a63d2(List list)
	{
		xc1e8aac83e2f5781 = list.x178ff6dcbf808c38;
		x870980ad82373217 = list;
		x965194be84c7d941 = new x6519502b0e34e920();
		xaabccab0c06d038b = -1;
		xe5c119bbf35c0d0b = new int[x870980ad82373217.ListLevels.Count];
		for (int i = 0; i < xe5c119bbf35c0d0b.Length; i++)
		{
			xe5c119bbf35c0d0b[i] = list.xc6c2afc83ab5edd9(i) - 1;
		}
	}

	private xd269993cc48a63d2(xd269993cc48a63d2 source)
	{
		x870980ad82373217 = source.x870980ad82373217;
		xaabccab0c06d038b = source.xaabccab0c06d038b;
		xe5c119bbf35c0d0b = (int[])source.xe5c119bbf35c0d0b.Clone();
	}

	internal xd269993cc48a63d2 xbd5d3ef61ea2956f()
	{
		return new xd269993cc48a63d2(this);
	}

	internal void xd83d8153333670e0(List x8a0b266419f09a55, int x9602b08e2ac63422)
	{
		x870980ad82373217 = x8a0b266419f09a55;
		x9602b08e2ac63422 = x870980ad82373217.ListLevels.x278f2422762a97e9(x9602b08e2ac63422);
		if (!x965194be84c7d941.x263d579af1d0d43f(x8a0b266419f09a55.ListId) && x8a0b266419f09a55.xe736f89697fc827f(x9602b08e2ac63422))
		{
			x965194be84c7d941.xd6b6ed77479ef68c(x8a0b266419f09a55.ListId);
			xe5c119bbf35c0d0b[x9602b08e2ac63422] = x8a0b266419f09a55.xc6c2afc83ab5edd9(x9602b08e2ac63422) - 1;
		}
		xe5c119bbf35c0d0b[x9602b08e2ac63422]++;
		for (int i = xaabccab0c06d038b + 1; i < x9602b08e2ac63422; i++)
		{
			xe5c119bbf35c0d0b[i]++;
		}
		if (x9602b08e2ac63422 < xaabccab0c06d038b)
		{
			for (int j = x9602b08e2ac63422 + 1; j < xe5c119bbf35c0d0b.Length; j++)
			{
				if (x1b66e22d28c087af(j).RestartAfterLevel >= x9602b08e2ac63422)
				{
					xe5c119bbf35c0d0b[j] = x8a0b266419f09a55.xc6c2afc83ab5edd9(j) - 1;
				}
			}
		}
		xaabccab0c06d038b = x9602b08e2ac63422;
	}

	internal int x043aafba68f5c559()
	{
		return xe5c119bbf35c0d0b[x870980ad82373217.ListLevels.x278f2422762a97e9(xaabccab0c06d038b)];
	}

	internal int x043aafba68f5c559(int x66bbd7ed8c65740d)
	{
		return xe5c119bbf35c0d0b[x870980ad82373217.ListLevels.x278f2422762a97e9(x66bbd7ed8c65740d)];
	}

	internal ListLevel x1b66e22d28c087af()
	{
		return x870980ad82373217.x1fc16b41653eb571(xaabccab0c06d038b);
	}

	internal ListLevel x1b66e22d28c087af(int x66bbd7ed8c65740d)
	{
		return x870980ad82373217.x1fc16b41653eb571(x66bbd7ed8c65740d);
	}
}
