using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedList<T> : GuardedSequenced<T>, IList<T>, IIndexed<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IDisposable, IList, ICollection, System.Collections.Generic.IList<T>, System.Collections.Generic.ICollection<T>, IEnumerable<T>, IEnumerable
{
	private IList<T> innerlist;

	private GuardedList<T> underlying;

	private bool slidableView;

	[ComVisible(true)]
	public T First
	{
		[ComVisible(true)]
		get
		{
			return innerlist.First;
		}
	}

	[ComVisible(true)]
	public T Last
	{
		[ComVisible(true)]
		get
		{
			return innerlist.Last;
		}
	}

	[ComVisible(true)]
	public bool FIFO
	{
		[ComVisible(true)]
		get
		{
			return innerlist.FIFO;
		}
		[ComVisible(true)]
		set
		{
			throw new ReadOnlyCollectionException("List is read only");
		}
	}

	[ComVisible(true)]
	public virtual bool IsFixedSize
	{
		[ComVisible(true)]
		get
		{
			return true;
		}
	}

	[ComVisible(true)]
	public T this[int i]
	{
		[ComVisible(true)]
		get
		{
			return innerlist[i];
		}
		[ComVisible(true)]
		set
		{
			throw new ReadOnlyCollectionException("List is read only");
		}
	}

	[ComVisible(true)]
	public virtual Speed IndexingSpeed
	{
		[ComVisible(true)]
		get
		{
			return innerlist.IndexingSpeed;
		}
	}

	[ComVisible(true)]
	public IList<T> Underlying
	{
		[ComVisible(true)]
		get
		{
			return underlying;
		}
	}

	[ComVisible(true)]
	public int Offset
	{
		[ComVisible(true)]
		get
		{
			return innerlist.Offset;
		}
	}

	[ComVisible(true)]
	public virtual bool IsValid
	{
		[ComVisible(true)]
		get
		{
			return innerlist.IsValid;
		}
	}

	[ComVisible(true)]
	public IDirectedCollectionValue<T> this[int start, int end]
	{
		[ComVisible(true)]
		get
		{
			return new GuardedDirectedCollectionValue<T>(innerlist[start, end]);
		}
	}

	bool ICollection.IsSynchronized => false;

	[Obsolete]
	object ICollection.SyncRoot => innerlist.SyncRoot;

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
		}
	}

	[ComVisible(true)]
	public GuardedList(IList<T> list)
		: base((ISequenced<T>)list)
	{
		innerlist = list;
		if (list.Underlying != null)
		{
			underlying = new GuardedList<T>(list.Underlying, null, slidableView: false);
		}
	}

	private GuardedList(IList<T> list, GuardedList<T> underlying, bool slidableView)
		: base((ISequenced<T>)list)
	{
		innerlist = list;
		this.underlying = underlying;
		this.slidableView = slidableView;
	}

	[ComVisible(true)]
	public void Insert(int index, T item)
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public void Insert(IList<T> pointer, T item)
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public void InsertFirst(T item)
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public void InsertLast(T item)
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public void InsertBefore(T item, T target)
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public void InsertAfter(T item, T target)
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public void InsertAll<U>(int i, IEnumerable<U> items) where U : T
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public IList<T> FindAll(Fun<T, bool> filter)
	{
		return innerlist.FindAll(filter);
	}

	[ComVisible(true)]
	public IList<V> Map<V>(Fun<T, V> mapper)
	{
		return innerlist.Map(mapper);
	}

	[ComVisible(true)]
	public IList<V> Map<V>(Fun<T, V> mapper, IEqualityComparer<V> itemequalityComparer)
	{
		return innerlist.Map(mapper, itemequalityComparer);
	}

	[ComVisible(true)]
	public T Remove()
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public T RemoveFirst()
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public T RemoveLast()
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public IList<T> View(int start, int count)
	{
		IList<T> list = innerlist.View(start, count);
		if (list != null)
		{
			return new GuardedList<T>(list, underlying ?? this, slidableView: true);
		}
		return null;
	}

	[ComVisible(true)]
	public IList<T> ViewOf(T item)
	{
		IList<T> list = innerlist.ViewOf(item);
		if (list != null)
		{
			return new GuardedList<T>(list, underlying ?? this, slidableView: true);
		}
		return null;
	}

	[ComVisible(true)]
	public IList<T> LastViewOf(T item)
	{
		IList<T> list = innerlist.LastViewOf(item);
		if (list != null)
		{
			return new GuardedList<T>(list, underlying ?? this, slidableView: true);
		}
		return null;
	}

	[ComVisible(true)]
	public IList<T> Slide(int offset)
	{
		if (slidableView)
		{
			innerlist.Slide(offset);
			return this;
		}
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public IList<T> Slide(int offset, int size)
	{
		if (slidableView)
		{
			innerlist.Slide(offset, size);
			return this;
		}
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public bool TrySlide(int offset)
	{
		if (slidableView)
		{
			return innerlist.TrySlide(offset);
		}
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public bool TrySlide(int offset, int size)
	{
		if (slidableView)
		{
			return innerlist.TrySlide(offset, size);
		}
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public IList<T> Span(IList<T> otherView)
	{
		if (!(otherView is GuardedList<T> guardedList))
		{
			throw new IncompatibleViewException();
		}
		IList<T> list = innerlist.Span(guardedList.innerlist);
		if (list == null)
		{
			return null;
		}
		return new GuardedList<T>(list, underlying ?? guardedList.underlying ?? this, slidableView: true);
	}

	[ComVisible(true)]
	public void Reverse()
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public void Reverse(int start, int count)
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public bool IsSorted()
	{
		return innerlist.IsSorted(Comparer<T>.Default);
	}

	[ComVisible(true)]
	public bool IsSorted(IComparer<T> c)
	{
		return innerlist.IsSorted(c);
	}

	[ComVisible(true)]
	public void Sort()
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public void Sort(IComparer<T> c)
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public void Shuffle()
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public void Shuffle(Random rnd)
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public int IndexOf(T item)
	{
		return innerlist.IndexOf(item);
	}

	[ComVisible(true)]
	public int LastIndexOf(T item)
	{
		return innerlist.LastIndexOf(item);
	}

	[ComVisible(true)]
	public T RemoveAt(int i)
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	[ComVisible(true)]
	public void RemoveInterval(int start, int count)
	{
		throw new ReadOnlyCollectionException("List is read only");
	}

	IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
	{
		return Backwards();
	}

	[ComVisible(true)]
	public void Push(T item)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public T Pop()
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public void Enqueue(T item)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public T Dequeue()
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public void Dispose()
	{
	}

	[ComVisible(true)]
	public override object Clone()
	{
		return new GuardedList<T>((IList<T>)innerlist.Clone());
	}

	void System.Collections.Generic.IList<T>.RemoveAt(int index)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	void System.Collections.Generic.ICollection<T>.Add(T item)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	void ICollection.CopyTo(Array arr, int index)
	{
		if (index < 0 || index + Count > arr.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		using IEnumerator<T> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			arr.SetValue(current, index++);
		}
	}

	int IList.Add(object o)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	bool IList.Contains(object o)
	{
		return Contains((T)o);
	}

	int IList.IndexOf(object o)
	{
		return Math.Max(-1, IndexOf((T)o));
	}

	void IList.Insert(int index, object o)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	void IList.Remove(object o)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	void IList.RemoveAt(int index)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}
}
