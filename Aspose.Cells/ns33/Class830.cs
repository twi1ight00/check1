using System.Collections;
using System.Runtime.CompilerServices;
using ns3;

namespace ns33;

internal class Class830 : CollectionBase, Interface15
{
	private Class844 class844_0;

	private Class821 class821_0;

	public Interface16 this[int int_0]
	{
		get
		{
			if (int_0 >= 0 && int_0 <= base.Count - 1)
			{
				return (Interface16)base.InnerList[int_0];
			}
			return null;
		}
	}

	internal Class821 Chart => class821_0;

	internal Class830(Class821 class821_1, Class844 class844_1)
	{
		class821_0 = class821_1;
		class844_0 = class844_1;
	}

	[SpecialName]
	internal Class844 method_0()
	{
		return class844_0;
	}

	public Class831 method_1(int int_0)
	{
		if (int_0 >= 0 && int_0 <= base.Count - 1)
		{
			return (Class831)base.InnerList[int_0];
		}
		return null;
	}

	private int Add(Class831 class831_0)
	{
		int result = base.InnerList.Add(class831_0);
		class831_0.method_2(this);
		class831_0.method_0();
		return result;
	}

	public Interface16 Add(double double_0)
	{
		Class831 @class = new Class831(class821_0, double_0);
		Add(@class);
		return @class;
	}

	[SpecialName]
	internal IList method_2()
	{
		return base.InnerList;
	}

	internal ArrayList method_3()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Class831 @class = method_1(i);
			if (i == 0)
			{
				arrayList.Add(@class);
				continue;
			}
			bool flag = false;
			for (int j = 0; j < arrayList.Count; j++)
			{
				Class831 class2 = (Class831)arrayList[j];
				if (!(class2.XValue <= @class.XValue))
				{
					arrayList.Insert(j, @class);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				arrayList.Add(@class);
			}
		}
		return arrayList;
	}
}
