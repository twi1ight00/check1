using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface IDirectedCollectionValue<T> : ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	[ComVisible(true)]
	new IDirectedCollectionValue<T> Backwards();

	[ComVisible(true)]
	bool FindLast(Fun<T, bool> predicate, out T item);
}
