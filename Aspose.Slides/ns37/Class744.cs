using System.Collections;
using ns36;

namespace ns37;

internal class Class744 : CollectionBase, Interface9
{
	public Interface5 this[int index] => (Interface5)base.InnerList[index];

	internal Class740 method_0(int index)
	{
		return (Class740)base.InnerList[index];
	}

	public void Add(Interface5 chart)
	{
		base.InnerList.Add(chart);
	}
}
