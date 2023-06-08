using ns34;
using ns56;

namespace ns20;

internal class Class252
{
	public static void smethod_0(Class737 cellFormats, Class1405 cellXfsElementData)
	{
		if (cellXfsElementData != null)
		{
			Class1750[] xfList = cellXfsElementData.XfList;
			foreach (Class1750 cellXfsElementData2 in xfList)
			{
				Class736 @class = new Class736();
				Class253.smethod_0(@class, cellXfsElementData2);
				cellFormats.Add(@class);
			}
		}
	}

	public static void smethod_1(Class737 cellFormats, Class1405 cellXfsElementData)
	{
		if (cellFormats == null)
		{
			return;
		}
		cellXfsElementData.Count = (uint)cellFormats.Count;
		foreach (Class736 cellFormat in cellFormats)
		{
			Class253.smethod_1(cellFormat, cellXfsElementData.delegate1129_0());
		}
	}
}
