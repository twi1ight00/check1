using System.Collections;
using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class795 : CollectionBase, Interface15
{
	private Class810 class810_0;

	private Class787 class787_0;

	public Interface16 this[int int_0]
	{
		get
		{
			if (int_0 >= 0 && int_0 <= base.Count - 1)
			{
				return (Class796)base.InnerList[int_0];
			}
			return null;
		}
	}

	public Class787 Chart => class787_0;

	internal Class795(Class787 class787_1, Class810 class810_1)
	{
		class787_0 = class787_1;
		class810_0 = class810_1;
	}

	[SpecialName]
	public Class810 method_0()
	{
		return class810_0;
	}

	public Class796 method_1(int int_0)
	{
		if (int_0 >= 0 && int_0 <= base.Count - 1)
		{
			return (Class796)base.InnerList[int_0];
		}
		return null;
	}

	private int Add(Class796 class796_0)
	{
		int result = base.InnerList.Add(class796_0);
		class796_0.method_2(this);
		class796_0.method_0();
		return result;
	}

	public Interface16 Add(double double_0)
	{
		Class796 @class = new Class796(class787_0, double_0);
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
			Class796 @class = method_1(i);
			if (i == 0)
			{
				arrayList.Add(@class);
				continue;
			}
			bool flag = false;
			for (int j = 0; j < arrayList.Count; j++)
			{
				Class796 class2 = (Class796)arrayList[j];
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
