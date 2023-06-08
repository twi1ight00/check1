using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface IIndexedSorted<T> : ISorted<T>, IIndexed<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, System.Collections.Generic.ICollection<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	[ComVisible(true)]
	int CountFrom(T bot);

	[ComVisible(true)]
	int CountFromTo(T bot, T top);

	[ComVisible(true)]
	int CountTo(T top);

	[ComVisible(true)]
	new IDirectedCollectionValue<T> RangeFrom(T bot);

	[ComVisible(true)]
	new IDirectedCollectionValue<T> RangeFromTo(T bot, T top);

	[ComVisible(true)]
	new IDirectedCollectionValue<T> RangeTo(T top);

	[ComVisible(true)]
	IIndexedSorted<T> FindAll(Fun<T, bool> predicate);

	[ComVisible(true)]
	IIndexedSorted<V> Map<V>(Fun<T, V> mapper, IComparer<V> comparer);
}
