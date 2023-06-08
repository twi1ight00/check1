using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedIndexedSorted<T> : GuardedSorted<T>, IIndexedSorted<T>, ISorted<T>, IIndexed<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, System.Collections.Generic.ICollection<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	private IIndexedSorted<T> indexedsorted;

	[ComVisible(true)]
	public T this[int i]
	{
		[ComVisible(true)]
		get
		{
			return indexedsorted[i];
		}
	}

	[ComVisible(true)]
	public virtual Speed IndexingSpeed
	{
		[ComVisible(true)]
		get
		{
			return indexedsorted.IndexingSpeed;
		}
	}

	[ComVisible(true)]
	public IDirectedCollectionValue<T> this[int start, int end]
	{
		[ComVisible(true)]
		get
		{
			return new GuardedDirectedCollectionValue<T>(indexedsorted[start, end]);
		}
	}

	[ComVisible(true)]
	public GuardedIndexedSorted(IIndexedSorted<T> list)
		: base((ISorted<T>)list)
	{
		indexedsorted = list;
	}

	[ComVisible(true)]
	public new IDirectedCollectionValue<T> RangeFrom(T bot)
	{
		return indexedsorted.RangeFrom(bot);
	}

	[ComVisible(true)]
	public new IDirectedCollectionValue<T> RangeFromTo(T bot, T top)
	{
		return indexedsorted.RangeFromTo(bot, top);
	}

	[ComVisible(true)]
	public new IDirectedCollectionValue<T> RangeTo(T top)
	{
		return indexedsorted.RangeTo(top);
	}

	[ComVisible(true)]
	public int CountFrom(T bot)
	{
		return indexedsorted.CountFrom(bot);
	}

	[ComVisible(true)]
	public int CountFromTo(T bot, T top)
	{
		return indexedsorted.CountFromTo(bot, top);
	}

	[ComVisible(true)]
	public int CountTo(T top)
	{
		return indexedsorted.CountTo(top);
	}

	[ComVisible(true)]
	public IIndexedSorted<T> FindAll(Fun<T, bool> f)
	{
		return indexedsorted.FindAll(f);
	}

	[ComVisible(true)]
	public IIndexedSorted<V> Map<V>(Fun<T, V> m, IComparer<V> c)
	{
		return indexedsorted.Map(m, c);
	}

	[ComVisible(true)]
	public int IndexOf(T item)
	{
		return indexedsorted.IndexOf(item);
	}

	[ComVisible(true)]
	public int LastIndexOf(T item)
	{
		return indexedsorted.LastIndexOf(item);
	}

	[ComVisible(true)]
	public T RemoveAt(int i)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public void RemoveInterval(int start, int count)
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
		return new GuardedIndexedSorted<T>((IIndexedSorted<T>)indexedsorted.Clone());
	}
}
