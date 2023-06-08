using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedDirectedCollectionValue<T> : GuardedCollectionValue<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	private IDirectedCollectionValue<T> directedcollection;

	[ComVisible(true)]
	public EnumerationDirection Direction
	{
		[ComVisible(true)]
		get
		{
			return directedcollection.Direction;
		}
	}

	[ComVisible(true)]
	public GuardedDirectedCollectionValue(IDirectedCollectionValue<T> directedcollection)
		: base((ICollectionValue<T>)directedcollection)
	{
		this.directedcollection = directedcollection;
	}

	[ComVisible(true)]
	public virtual IDirectedCollectionValue<T> Backwards()
	{
		return new GuardedDirectedCollectionValue<T>(directedcollection.Backwards());
	}

	[ComVisible(true)]
	public virtual bool FindLast(Fun<T, bool> predicate, out T item)
	{
		return directedcollection.FindLast(predicate, out item);
	}

	IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
	{
		return Backwards();
	}
}
