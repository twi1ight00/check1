using System.Collections;
using ns19;

namespace ns5;

internal class Class895 : CollectionBase
{
	private object object_0;

	public Class898 this[int int_0] => (Class898)base.InnerList[int_0];

	internal Class895(object object_1)
	{
		object_0 = object_1;
	}

	public Class898 Add(Enum103 enum103_0)
	{
		Class898 @class = new Class898(this, enum103_0);
		base.InnerList.Add(@class);
		return @class;
	}

	public void method_0(Interface42 interface42_0)
	{
		foreach (Class898 inner in base.InnerList)
		{
			inner.vmethod_0(interface42_0, bool_7: false);
		}
	}
}
