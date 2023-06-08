using System.Collections;
using ns3;

namespace ns31;

internal class Class790 : CollectionBase, Interface10
{
	private Class791 class791_0;

	public Interface11 this[int int_0] => (Interface11)base.InnerList[int_0];

	internal Class790(Class791 class791_1)
	{
		class791_0 = class791_1;
	}

	public Interface11 AddLabel(object object_0)
	{
		Class791 @class = new Class791(class791_0, object_0);
		base.InnerList.Add(@class);
		return @class;
	}
}
