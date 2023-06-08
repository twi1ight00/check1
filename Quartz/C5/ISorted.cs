using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface ISorted<T> : ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, System.Collections.Generic.ICollection<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	[ComVisible(true)]
	IComparer<T> Comparer
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	T FindMin();

	[ComVisible(true)]
	T DeleteMin();

	[ComVisible(true)]
	T FindMax();

	[ComVisible(true)]
	T DeleteMax();

	[ComVisible(true)]
	bool TryPredecessor(T item, out T res);

	[ComVisible(true)]
	bool TrySuccessor(T item, out T res);

	[ComVisible(true)]
	bool TryWeakPredecessor(T item, out T res);

	[ComVisible(true)]
	bool TryWeakSuccessor(T item, out T res);

	[ComVisible(true)]
	T Predecessor(T item);

	[ComVisible(true)]
	T Successor(T item);

	[ComVisible(true)]
	T WeakPredecessor(T item);

	[ComVisible(true)]
	T WeakSuccessor(T item);

	[ComVisible(true)]
	bool Cut(IComparable<T> cutFunction, out T low, out bool lowIsValid, out T high, out bool highIsValid);

	[ComVisible(true)]
	IDirectedEnumerable<T> RangeFrom(T bot);

	[ComVisible(true)]
	IDirectedEnumerable<T> RangeFromTo(T bot, T top);

	[ComVisible(true)]
	IDirectedEnumerable<T> RangeTo(T top);

	[ComVisible(true)]
	IDirectedCollectionValue<T> RangeAll();

	[ComVisible(true)]
	void AddSorted<U>(IEnumerable<U> items) where U : T;

	[ComVisible(true)]
	void RemoveRangeFrom(T low);

	[ComVisible(true)]
	void RemoveRangeFromTo(T low, T hi);

	[ComVisible(true)]
	void RemoveRangeTo(T hi);
}
