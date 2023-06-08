using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface IQueue<T> : IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	[ComVisible(true)]
	bool AllowsDuplicates
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	T this[int index]
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	void Enqueue(T item);

	[ComVisible(true)]
	T Dequeue();
}
