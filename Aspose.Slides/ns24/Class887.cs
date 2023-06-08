using System.Collections.Generic;

namespace ns24;

internal class Class887
{
	private long long_0;

	private long long_1;

	public long X
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	public long Y
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
		}
	}

	public Class887(long x, long y)
	{
		long_0 = x;
		long_1 = y;
	}

	public Class887(string x, string y, Dictionary<string, int> nameToIndex, List<Class541> geomGuides)
	{
		long_0 = Class342.smethod_0(x, nameToIndex, geomGuides);
		long_1 = Class342.smethod_0(y, nameToIndex, geomGuides);
	}
}
