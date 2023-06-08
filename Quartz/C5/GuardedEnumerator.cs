using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
{
	private IEnumerator<T> enumerator;

	[ComVisible(true)]
	public T Current
	{
		[ComVisible(true)]
		get
		{
			return enumerator.Current;
		}
	}

	object IEnumerator.Current => enumerator.Current;

	[ComVisible(true)]
	public GuardedEnumerator(IEnumerator<T> enumerator)
	{
		this.enumerator = enumerator;
	}

	[ComVisible(true)]
	public bool MoveNext()
	{
		return enumerator.MoveNext();
	}

	[ComVisible(true)]
	public void Dispose()
	{
		enumerator.Dispose();
	}

	void IEnumerator.Reset()
	{
		enumerator.Reset();
	}
}
