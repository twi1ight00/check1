using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface IList<T> : IIndexed<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IDisposable, System.Collections.Generic.IList<T>, System.Collections.Generic.ICollection<T>, IEnumerable<T>, IList, ICollection, IEnumerable
{
	[ComVisible(true)]
	T First
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	T Last
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	bool FIFO
	{
		[ComVisible(true)]
		get;
		[ComVisible(true)]
		set;
	}

	[ComVisible(true)]
	new bool IsFixedSize
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	new T this[int index]
	{
		[ComVisible(true)]
		get;
		[ComVisible(true)]
		set;
	}

	[ComVisible(true)]
	new int Count
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	new bool IsReadOnly
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	IList<T> Underlying
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	int Offset
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	bool IsValid
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	new bool Add(T item);

	[ComVisible(true)]
	new void Clear();

	[ComVisible(true)]
	new bool Contains(T item);

	[ComVisible(true)]
	new void CopyTo(T[] array, int index);

	[ComVisible(true)]
	new bool Remove(T item);

	[ComVisible(true)]
	new int IndexOf(T item);

	[ComVisible(true)]
	new T RemoveAt(int index);

	[ComVisible(true)]
	void Insert(IList<T> pointer, T item);

	[ComVisible(true)]
	void InsertFirst(T item);

	[ComVisible(true)]
	void InsertLast(T item);

	[ComVisible(true)]
	void InsertAll<U>(int index, IEnumerable<U> items) where U : T;

	[ComVisible(true)]
	IList<T> FindAll(Fun<T, bool> filter);

	[ComVisible(true)]
	IList<V> Map<V>(Fun<T, V> mapper);

	[ComVisible(true)]
	IList<V> Map<V>(Fun<T, V> mapper, IEqualityComparer<V> equalityComparer);

	[ComVisible(true)]
	T Remove();

	[ComVisible(true)]
	T RemoveFirst();

	[ComVisible(true)]
	T RemoveLast();

	[ComVisible(true)]
	IList<T> View(int start, int count);

	[ComVisible(true)]
	IList<T> ViewOf(T item);

	[ComVisible(true)]
	IList<T> LastViewOf(T item);

	[ComVisible(true)]
	IList<T> Slide(int offset);

	[ComVisible(true)]
	IList<T> Slide(int offset, int size);

	[ComVisible(true)]
	bool TrySlide(int offset);

	[ComVisible(true)]
	bool TrySlide(int offset, int size);

	[ComVisible(true)]
	IList<T> Span(IList<T> otherView);

	[ComVisible(true)]
	void Reverse();

	[ComVisible(true)]
	bool IsSorted();

	[ComVisible(true)]
	bool IsSorted(IComparer<T> comparer);

	[ComVisible(true)]
	void Sort();

	[ComVisible(true)]
	void Sort(IComparer<T> comparer);

	[ComVisible(true)]
	void Shuffle();

	[ComVisible(true)]
	void Shuffle(Random rnd);
}
