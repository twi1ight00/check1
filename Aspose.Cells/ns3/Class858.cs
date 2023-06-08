using System.Collections;
using System.Drawing;

namespace ns3;

internal class Class858 : CollectionBase, Interface36
{
	public Interface37 this[int int_0] => (Interface37)base.InnerList[int_0];

	public void Add(Color color_0, float float_0)
	{
		Class860 @class = new Class860();
		@class.Color = color_0;
		@class.Position = float_0;
		base.InnerList.Add(@class);
	}

	internal Class860 method_0(int int_0)
	{
		return (Class860)base.InnerList[int_0];
	}

	internal bool method_1(Class858 class858_0)
	{
		if (base.Count != class858_0.Count)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				if (!method_0(num).method_0(class858_0.method_0(num)))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}
}
