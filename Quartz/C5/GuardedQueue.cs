using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedQueue<T> : GuardedDirectedCollectionValue<T>, IQueue<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	private IQueue<T> queue;

	[ComVisible(true)]
	public bool AllowsDuplicates
	{
		[ComVisible(true)]
		get
		{
			return queue.AllowsDuplicates;
		}
	}

	[ComVisible(true)]
	public T this[int i]
	{
		[ComVisible(true)]
		get
		{
			return queue[i];
		}
	}

	[ComVisible(true)]
	public GuardedQueue(IQueue<T> queue)
		: base((IDirectedCollectionValue<T>)queue)
	{
		this.queue = queue;
	}

	[ComVisible(true)]
	public void Enqueue(T item)
	{
		throw new ReadOnlyCollectionException("Queue cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public T Dequeue()
	{
		throw new ReadOnlyCollectionException("Queue cannot be modified through this guard object");
	}
}
