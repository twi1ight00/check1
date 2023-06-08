using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface IDirectedEnumerable<T> : IEnumerable<T>, IEnumerable
{
	[ComVisible(true)]
	EnumerationDirection Direction
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	IDirectedEnumerable<T> Backwards();
}
