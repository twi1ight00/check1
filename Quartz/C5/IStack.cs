using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface IStack<T> : IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
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
	void Push(T item);

	[ComVisible(true)]
	T Pop();
}
