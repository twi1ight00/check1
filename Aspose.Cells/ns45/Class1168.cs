using System.Collections;

namespace ns45;

internal class Class1168 : CollectionBase
{
	public Class1167 this[int int_0] => (Class1167)base.InnerList[int_0];

	internal void Add(Class1167 class1167_0)
	{
		base.InnerList.Add(class1167_0);
	}
}
