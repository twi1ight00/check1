using System.Collections.Generic;

namespace ns24;

internal class Class888
{
	private Class887 class887_0;

	private long long_0;

	public Class887 Pos => class887_0;

	public long Direction
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

	public Class888(string posX, string posY, string direction, Dictionary<string, int> nameToIndex, List<Class541> geomGuides)
	{
		class887_0 = new Class887(posX, posY, nameToIndex, geomGuides);
		long_0 = Class342.smethod_0(direction, nameToIndex, geomGuides);
	}

	public Class888(long posX, long posY, long direction)
	{
		class887_0 = new Class887(posX, posY);
		long_0 = direction;
	}
}
