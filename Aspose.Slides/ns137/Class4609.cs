using System;
using System.Collections;

namespace ns137;

internal class Class4609 : CollectionBase
{
	public Interface140 this[int index] => (Interface140)base.List[index];

	public void Add(Interface140 hint)
	{
		base.List.Add(hint);
	}

	public bool method_0(Type hintType)
	{
		foreach (Interface140 item in base.List)
		{
			if (item.GetType() == hintType)
			{
				return true;
			}
		}
		return false;
	}
}
