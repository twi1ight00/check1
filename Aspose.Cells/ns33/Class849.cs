using System.Collections;
using System.Runtime.CompilerServices;
using ns3;

namespace ns33;

internal class Class849 : CollectionBase, Interface31
{
	private Class844 class844_0;

	private Class821 class821_0;

	public Interface32 this[int int_0] => (Class850)base.InnerList[int_0];

	internal Class849(Class821 class821_1, Class844 class844_1)
	{
		class821_0 = class821_1;
		class844_0 = class844_1;
	}

	[SpecialName]
	public Class844 method_0()
	{
		return class844_0;
	}

	internal Class850 method_1(int int_0)
	{
		return (Class850)base.InnerList[int_0];
	}

	public int Add(Enum88 enum88_0)
	{
		Class850 @class = new Class850(class821_0, this);
		@class.Type = enum88_0;
		return base.InnerList.Add(@class);
	}
}
