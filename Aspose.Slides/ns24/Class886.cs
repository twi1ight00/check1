using System.Collections.Generic;

namespace ns24;

internal class Class886
{
	public bool bool_0;

	public long long_0;

	public long long_1;

	public long long_2;

	public long long_3;

	public long long_4;

	public long long_5;

	public Class887 class887_0;

	public Class886(bool polar, long u, long minU, long maxU, long v, long minV, long maxV, long posX, long posY)
	{
		bool_0 = polar;
		long_0 = u;
		long_1 = minU;
		long_2 = maxU;
		long_3 = v;
		long_4 = minV;
		long_5 = maxV;
		class887_0 = new Class887(posX, posY);
	}

	public Class886(bool polar, string u, string minU, string maxU, string v, string minV, string maxV, string posX, string posY, Dictionary<string, int> nameToIndex, List<Class541> geomGuides)
	{
		bool_0 = polar;
		long_0 = Class342.smethod_0(u, nameToIndex, geomGuides);
		long_1 = Class342.smethod_0(minU, nameToIndex, geomGuides);
		long_2 = Class342.smethod_0(maxU, nameToIndex, geomGuides);
		long_3 = Class342.smethod_0(v, nameToIndex, geomGuides);
		long_4 = Class342.smethod_0(minV, nameToIndex, geomGuides);
		long_5 = Class342.smethod_0(maxV, nameToIndex, geomGuides);
		class887_0 = new Class887(posX, posY, nameToIndex, geomGuides);
	}
}
