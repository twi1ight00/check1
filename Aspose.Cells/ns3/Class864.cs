using System.Collections;
using System.Drawing;

namespace ns3;

internal class Class864 : CollectionBase, Interface38
{
	public Interface39 this[int int_0]
	{
		get
		{
			if (int_0 >= base.InnerList.Count)
			{
				return null;
			}
			return (Interface39)base.InnerList[int_0];
		}
	}

	internal Class865 method_0(int int_0)
	{
		if (int_0 >= base.InnerList.Count)
		{
			return null;
		}
		return (Class865)base.InnerList[int_0];
	}

	public Interface39 Add(string string_0, Font font_0, Color color_0, Enum81 enum81_0)
	{
		Class865 @class = new Class865(string_0, font_0, color_0, enum81_0);
		base.InnerList.Add(@class);
		return @class;
	}
}
