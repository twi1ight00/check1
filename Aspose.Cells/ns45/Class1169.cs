using System.Collections;

namespace ns45;

internal class Class1169 : CollectionBase
{
	public Class1166 this[int int_0] => (Class1166)base.InnerList[int_0];

	internal void Add(Class1166 class1166_0)
	{
		base.InnerList.Add(class1166_0);
	}
}
