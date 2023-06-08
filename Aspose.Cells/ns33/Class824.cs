using System.Collections;
using ns3;

namespace ns33;

internal class Class824 : CollectionBase, Interface10
{
	private Class825 class825_0;

	public Interface11 this[int int_0] => (Interface11)base.InnerList[int_0];

	internal Class824(Class825 class825_1)
	{
		class825_0 = class825_1;
	}

	public Interface11 AddLabel(object object_0)
	{
		Class825 @class = new Class825(class825_0, object_0);
		base.InnerList.Add(@class);
		return @class;
	}
}
