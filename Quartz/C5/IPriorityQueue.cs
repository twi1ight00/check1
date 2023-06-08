using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface IPriorityQueue<T> : IExtensible<T>, ICollectionValue<T>, IEnumerable<T>, IEnumerable, IShowable, IFormattable, ICloneable
{
	[ComVisible(true)]
	IComparer<T> Comparer
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	T this[IPriorityQueueHandle<T> handle]
	{
		[ComVisible(true)]
		get;
		[ComVisible(true)]
		set;
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
	bool Find(IPriorityQueueHandle<T> handle, out T item);

	[ComVisible(true)]
	bool Add(ref IPriorityQueueHandle<T> handle, T item);

	[ComVisible(true)]
	T Delete(IPriorityQueueHandle<T> handle);

	[ComVisible(true)]
	T Replace(IPriorityQueueHandle<T> handle, T item);

	[ComVisible(true)]
	T FindMin(out IPriorityQueueHandle<T> handle);

	[ComVisible(true)]
	T FindMax(out IPriorityQueueHandle<T> handle);

	[ComVisible(true)]
	T DeleteMin(out IPriorityQueueHandle<T> handle);

	[ComVisible(true)]
	T DeleteMax(out IPriorityQueueHandle<T> handle);
}
