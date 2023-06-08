using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedSorted<T> : GuardedSequenced<T>, ISorted<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, System.Collections.Generic.ICollection<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	private ISorted<T> sorted;

	[ComVisible(true)]
	public IComparer<T> Comparer
	{
		[ComVisible(true)]
		get
		{
			return sorted.Comparer;
		}
	}

	[ComVisible(true)]
	public GuardedSorted(ISorted<T> sorted)
		: base((ISequenced<T>)sorted)
	{
		this.sorted = sorted;
	}

	[ComVisible(true)]
	public bool TryPredecessor(T item, out T res)
	{
		return sorted.TryPredecessor(item, out res);
	}

	[ComVisible(true)]
	public bool TrySuccessor(T item, out T res)
	{
		return sorted.TrySuccessor(item, out res);
	}

	[ComVisible(true)]
	public bool TryWeakPredecessor(T item, out T res)
	{
		return sorted.TryWeakPredecessor(item, out res);
	}

	[ComVisible(true)]
	public bool TryWeakSuccessor(T item, out T res)
	{
		return sorted.TryWeakSuccessor(item, out res);
	}

	[ComVisible(true)]
	public T Predecessor(T item)
	{
		return sorted.Predecessor(item);
	}

	[ComVisible(true)]
	public T Successor(T item)
	{
		return sorted.Successor(item);
	}

	[ComVisible(true)]
	public T WeakPredecessor(T item)
	{
		return sorted.WeakPredecessor(item);
	}

	[ComVisible(true)]
	public T WeakSuccessor(T item)
	{
		return sorted.WeakSuccessor(item);
	}

	[ComVisible(true)]
	public bool Cut(IComparable<T> c, out T low, out bool lval, out T high, out bool hval)
	{
		return sorted.Cut(c, out low, out lval, out high, out hval);
	}

	[ComVisible(true)]
	public IDirectedEnumerable<T> RangeFrom(T bot)
	{
		return sorted.RangeFrom(bot);
	}

	[ComVisible(true)]
	public IDirectedEnumerable<T> RangeFromTo(T bot, T top)
	{
		return sorted.RangeFromTo(bot, top);
	}

	[ComVisible(true)]
	public IDirectedEnumerable<T> RangeTo(T top)
	{
		return sorted.RangeTo(top);
	}

	[ComVisible(true)]
	public IDirectedCollectionValue<T> RangeAll()
	{
		return sorted.RangeAll();
	}

	[ComVisible(true)]
	public void AddSorted<U>(IEnumerable<U> items) where U : T
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public void RemoveRangeFrom(T low)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public void RemoveRangeFromTo(T low, T hi)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public void RemoveRangeTo(T hi)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public T FindMin()
	{
		return sorted.FindMin();
	}

	[ComVisible(true)]
	public T DeleteMin()
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public T FindMax()
	{
		return sorted.FindMax();
	}

	[ComVisible(true)]
	public T DeleteMax()
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
	{
		return Backwards();
	}

	[ComVisible(true)]
	public override object Clone()
	{
		return new GuardedSorted<T>((ISorted<T>)sorted.Clone());
	}
}
