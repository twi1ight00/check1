using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface IExtensible<T> : ICollectionValue<T>, IEnumerable<T>, IEnumerable, IShowable, IFormattable, ICloneable
{
	[ComVisible(true)]
	bool IsReadOnly
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	bool AllowsDuplicates
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	IEqualityComparer<T> EqualityComparer
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	bool DuplicatesByCounting
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	bool Add(T item);

	[ComVisible(true)]
	void AddAll<U>(IEnumerable<U> items) where U : T;

	[ComVisible(true)]
	bool Check();
}
