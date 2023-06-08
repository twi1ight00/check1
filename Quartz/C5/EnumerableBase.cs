using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal abstract class EnumerableBase<T> : IEnumerable<T>, IEnumerable
{
	[ComVisible(true)]
	public abstract IEnumerator<T> GetEnumerator();

	[Tested]
	protected static int countItems(IEnumerable<T> items)
	{
		if (items is ICollectionValue<T> collectionValue)
		{
			return collectionValue.Count;
		}
		int num = 0;
		using IEnumerator<T> enumerator = items.GetEnumerator();
		while (enumerator.MoveNext())
		{
			num++;
		}
		return num;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
