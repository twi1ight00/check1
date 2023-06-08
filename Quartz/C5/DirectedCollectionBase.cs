using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal abstract class DirectedCollectionBase<T> : CollectionBase<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	[ComVisible(true)]
	public virtual EnumerationDirection Direction
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return EnumerationDirection.Forwards;
		}
	}

	protected DirectedCollectionBase(IEqualityComparer<T> itemequalityComparer)
		: base(itemequalityComparer)
	{
	}

	[ComVisible(true)]
	public abstract IDirectedCollectionValue<T> Backwards();

	IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
	{
		return Backwards();
	}

	[ComVisible(true)]
	public virtual bool FindLast(Fun<T, bool> predicate, out T item)
	{
		foreach (T item2 in Backwards())
		{
			if (predicate(item2))
			{
				item = item2;
				return true;
			}
		}
		item = default(T);
		return false;
	}
}
