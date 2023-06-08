using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface ICollectionValue<T> : IEnumerable<T>, IEnumerable, IShowable, IFormattable
{
	[ComVisible(true)]
	EventTypeEnum ListenableEvents
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	EventTypeEnum ActiveEvents
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	bool IsEmpty
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	int Count
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	Speed CountSpeed
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	event CollectionChangedHandler<T> CollectionChanged;

	[ComVisible(true)]
	event CollectionClearedHandler<T> CollectionCleared;

	[ComVisible(true)]
	event ItemsAddedHandler<T> ItemsAdded;

	[ComVisible(true)]
	event ItemInsertedHandler<T> ItemInserted;

	[ComVisible(true)]
	event ItemsRemovedHandler<T> ItemsRemoved;

	[ComVisible(true)]
	event ItemRemovedAtHandler<T> ItemRemovedAt;

	[ComVisible(true)]
	void CopyTo(T[] array, int index);

	[ComVisible(true)]
	T[] ToArray();

	[ComVisible(true)]
	void Apply(Act<T> action);

	[ComVisible(true)]
	bool Exists(Fun<T, bool> predicate);

	[ComVisible(true)]
	bool Find(Fun<T, bool> predicate, out T item);

	[ComVisible(true)]
	bool All(Fun<T, bool> predicate);

	[ComVisible(true)]
	T Choose();

	[ComVisible(true)]
	IEnumerable<T> Filter(Fun<T, bool> filter);
}
