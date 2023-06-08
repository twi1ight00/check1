using System.Collections;
using ns19;

namespace ns6;

internal class Class911 : CollectionBase
{
	private object object_0;

	public Class913 this[int int_0] => (Class913)base.InnerList[int_0];

	internal Class911(object object_1)
	{
		object_0 = object_1;
	}

	public Class913 Add(Enum121 enum121_0)
	{
		Class913 @class = new Class913(this, enum121_0);
		base.InnerList.Add(@class);
		return @class;
	}

	public void method_0(Interface42 interface42_0)
	{
		foreach (Class913 inner in base.InnerList)
		{
			inner.vmethod_0(interface42_0, bool_8: false);
		}
	}
}
