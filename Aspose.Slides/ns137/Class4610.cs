using System.Collections;

namespace ns137;

internal class Class4610 : CollectionBase
{
	public Class4609 this[int index] => (Class4609)base.List[index];

	public void Add(Class4609 hintCollection)
	{
		base.List.Add(hintCollection);
	}
}
