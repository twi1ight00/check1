using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedEnumerable<T> : IEnumerable<T>, IEnumerable
{
	private IEnumerable<T> enumerable;

	[ComVisible(true)]
	public GuardedEnumerable(IEnumerable<T> enumerable)
	{
		this.enumerable = enumerable;
	}

	[ComVisible(true)]
	public IEnumerator<T> GetEnumerator()
	{
		return new GuardedEnumerator<T>(enumerable.GetEnumerator());
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
