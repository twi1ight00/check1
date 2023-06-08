using System.Collections;
using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class813 : CollectionBase, Interface31
{
	private Class810 class810_0;

	private Class787 class787_0;

	public Interface32 this[int int_0] => (Interface32)base.InnerList[int_0];

	internal Class813(Class787 class787_1, Class810 class810_1)
	{
		class787_0 = class787_1;
		class810_0 = class810_1;
	}

	[SpecialName]
	public Class810 method_0()
	{
		return class810_0;
	}

	internal Class815 method_1(int int_0)
	{
		return (Class815)base.InnerList[int_0];
	}

	public int Add(Enum88 enum88_0)
	{
		Class815 @class = new Class815(class787_0, this);
		@class.Type = enum88_0;
		return base.InnerList.Add(@class);
	}

	[SpecialName]
	internal IList method_2()
	{
		return base.InnerList;
	}

	public ArrayList method_3()
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(base.InnerList);
		Class814 comparer = new Class814();
		arrayList.Sort(comparer);
		return arrayList;
	}
}
