using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface IIndexed<T> : ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, System.Collections.Generic.ICollection<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	[ComVisible(true)]
	T this[int index]
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	Speed IndexingSpeed
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	IDirectedCollectionValue<T> this[int start, int count]
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	int IndexOf(T item);

	[ComVisible(true)]
	int LastIndexOf(T item);

	[ComVisible(true)]
	int FindIndex(Fun<T, bool> predicate);

	[ComVisible(true)]
	int FindLastIndex(Fun<T, bool> predicate);

	[ComVisible(true)]
	T RemoveAt(int index);

	[ComVisible(true)]
	void RemoveInterval(int start, int count);
}
