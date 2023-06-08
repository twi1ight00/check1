using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedDirectedEnumerable<T> : GuardedEnumerable<T>, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	private IDirectedEnumerable<T> directedenumerable;

	[ComVisible(true)]
	public EnumerationDirection Direction
	{
		[ComVisible(true)]
		get
		{
			return directedenumerable.Direction;
		}
	}

	[ComVisible(true)]
	public GuardedDirectedEnumerable(IDirectedEnumerable<T> directedenumerable)
		: base((IEnumerable<T>)directedenumerable)
	{
		this.directedenumerable = directedenumerable;
	}

	[ComVisible(true)]
	public IDirectedEnumerable<T> Backwards()
	{
		return new GuardedDirectedEnumerable<T>(directedenumerable.Backwards());
	}
}
