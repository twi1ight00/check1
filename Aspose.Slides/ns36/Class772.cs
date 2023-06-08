using System.Collections;
using System.Drawing;

namespace ns36;

internal class Class772 : CollectionBase, Interface27
{
	public Interface28 this[int i] => (Interface28)base.InnerList[i];

	public void Add(Color color, float position)
	{
		Class774 @class = new Class774();
		@class.Color = color;
		@class.Position = position;
		base.InnerList.Add(@class);
	}

	internal Class774 method_0(int i)
	{
		return (Class774)base.InnerList[i];
	}

	internal bool method_1(Class772 other)
	{
		if (base.Count != other.Count)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				if (!method_0(num).method_0(other.method_0(num)))
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
