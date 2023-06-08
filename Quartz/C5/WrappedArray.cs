using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace C5;

internal class WrappedArray<T> : IList<T>, IIndexed<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IDisposable, IList, ICollection, System.Collections.Generic.IList<T>, System.Collections.Generic.ICollection<T>, IEnumerable<T>, IEnumerable
{
	private class InnerList : ArrayList<T>
	{
		internal InnerList(T[] array)
		{
			base.array = array;
			size = array.Length;
		}
	}

	private ArrayList<T> innerlist;

	private WrappedArray<T> underlying;

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
	public T this[int index]
	{
		[ComVisible(true)]
		get
		{
			return innerlist[index];
		}
		[ComVisible(true)]
		set
		{
			innerlist[index] = value;
		}
	}

	[ComVisible(true)]
	public bool FIFO
	{
		[ComVisible(true)]
		get
		{
			throw new FixedSizeCollectionException();
		}
		[ComVisible(true)]
		set
		{
			throw new FixedSizeCollectionException();
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
	public bool IsValid
	{
		[ComVisible(true)]
		get
		{
			return innerlist.IsValid;
		}
	}

	[ComVisible(true)]
	public Speed IndexingSpeed
	{
		[ComVisible(true)]
		get
		{
			return Speed.Constant;
		}
	}

	[ComVisible(true)]
	public IDirectedCollectionValue<T> this[int start, int count]
	{
		[ComVisible(true)]
		get
		{
			return innerlist[start, count];
		}
	}

	[ComVisible(true)]
	public Speed ContainsSpeed
	{
		[ComVisible(true)]
		get
		{
			return Speed.Linear;
		}
	}

	[ComVisible(true)]
	public bool IsReadOnly
	{
		[ComVisible(true)]
		get
		{
			return true;
		}
	}

	[ComVisible(true)]
	public bool AllowsDuplicates
	{
		[ComVisible(true)]
		get
		{
			return true;
		}
	}

	[ComVisible(true)]
	public IEqualityComparer<T> EqualityComparer
	{
		[ComVisible(true)]
		get
		{
			return innerlist.EqualityComparer;
		}
	}

	[ComVisible(true)]
	public bool DuplicatesByCounting
	{
		[ComVisible(true)]
		get
		{
			return false;
		}
	}

	[ComVisible(true)]
	public virtual EventTypeEnum ListenableEvents
	{
		[ComVisible(true)]
		get
		{
			return EventTypeEnum.None;
		}
	}

	[ComVisible(true)]
	public virtual EventTypeEnum ActiveEvents
	{
		[ComVisible(true)]
		get
		{
			return EventTypeEnum.None;
		}
	}

	[ComVisible(true)]
	public bool IsEmpty
	{
		[ComVisible(true)]
		get
		{
			return innerlist.IsEmpty;
		}
	}

	[ComVisible(true)]
	public int Count
	{
		[ComVisible(true)]
		get
		{
			return innerlist.Count;
		}
	}

	[ComVisible(true)]
	public Speed CountSpeed
	{
		[ComVisible(true)]
		get
		{
			return innerlist.CountSpeed;
		}
	}

	[ComVisible(true)]
	public EnumerationDirection Direction
	{
		[ComVisible(true)]
		get
		{
			return EnumerationDirection.Forwards;
		}
	}

	bool ICollection.IsSynchronized => false;

	[Obsolete]
	object ICollection.SyncRoot => ((ICollection)innerlist).SyncRoot;

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			this[index] = (T)value;
		}
	}

	[ComVisible(true)]
	public event CollectionChangedHandler<T> CollectionChanged
	{
		[ComVisible(true)]
		add
		{
			throw new UnlistenableEventException();
		}
		[ComVisible(true)]
		remove
		{
			throw new UnlistenableEventException();
		}
	}

	[ComVisible(true)]
	public event CollectionClearedHandler<T> CollectionCleared
	{
		[ComVisible(true)]
		add
		{
			throw new UnlistenableEventException();
		}
		[ComVisible(true)]
		remove
		{
			throw new UnlistenableEventException();
		}
	}

	[ComVisible(true)]
	public event ItemsAddedHandler<T> ItemsAdded
	{
		[ComVisible(true)]
		add
		{
			throw new UnlistenableEventException();
		}
		[ComVisible(true)]
		remove
		{
			throw new UnlistenableEventException();
		}
	}

	[ComVisible(true)]
	public event ItemInsertedHandler<T> ItemInserted
	{
		[ComVisible(true)]
		add
		{
			throw new UnlistenableEventException();
		}
		[ComVisible(true)]
		remove
		{
			throw new UnlistenableEventException();
		}
	}

	[ComVisible(true)]
	public event ItemsRemovedHandler<T> ItemsRemoved
	{
		[ComVisible(true)]
		add
		{
			throw new UnlistenableEventException();
		}
		[ComVisible(true)]
		remove
		{
			throw new UnlistenableEventException();
		}
	}

	[ComVisible(true)]
	public event ItemRemovedAtHandler<T> ItemRemovedAt
	{
		[ComVisible(true)]
		add
		{
			throw new UnlistenableEventException();
		}
		[ComVisible(true)]
		remove
		{
			throw new UnlistenableEventException();
		}
	}

	[ComVisible(true)]
	public WrappedArray(T[] wrappedarray)
	{
		innerlist = new InnerList(wrappedarray);
	}

	private WrappedArray(ArrayList<T> arraylist, WrappedArray<T> underlying)
	{
		innerlist = arraylist;
		this.underlying = underlying;
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
	public IList<V> Map<V>(Fun<T, V> mapper, IEqualityComparer<V> equalityComparer)
	{
		return innerlist.Map(mapper, equalityComparer);
	}

	[ComVisible(true)]
	public void Insert(int index, T item)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public void Insert(IList<T> pointer, T item)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public void InsertFirst(T item)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public void InsertLast(T item)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public void InsertAll<U>(int i, IEnumerable<U> items) where U : T
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public T Remove()
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public T RemoveFirst()
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public T RemoveLast()
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public IList<T> View(int start, int count)
	{
		return new WrappedArray<T>((ArrayList<T>)innerlist.View(start, count), underlying ?? this);
	}

	[ComVisible(true)]
	public IList<T> ViewOf(T item)
	{
		return new WrappedArray<T>((ArrayList<T>)innerlist.ViewOf(item), underlying ?? this);
	}

	[ComVisible(true)]
	public IList<T> LastViewOf(T item)
	{
		return new WrappedArray<T>((ArrayList<T>)innerlist.LastViewOf(item), underlying ?? this);
	}

	[ComVisible(true)]
	public IList<T> Slide(int offset)
	{
		return innerlist.Slide(offset);
	}

	[ComVisible(true)]
	public IList<T> Slide(int offset, int size)
	{
		return innerlist.Slide(offset, size);
	}

	[ComVisible(true)]
	public bool TrySlide(int offset)
	{
		return innerlist.TrySlide(offset);
	}

	[ComVisible(true)]
	public bool TrySlide(int offset, int size)
	{
		return innerlist.TrySlide(offset, size);
	}

	[ComVisible(true)]
	public IList<T> Span(IList<T> otherView)
	{
		return innerlist.Span(((WrappedArray<T>)otherView).innerlist);
	}

	[ComVisible(true)]
	public void Reverse()
	{
		innerlist.Reverse();
	}

	[ComVisible(true)]
	public bool IsSorted()
	{
		return innerlist.IsSorted();
	}

	[ComVisible(true)]
	public bool IsSorted(IComparer<T> comparer)
	{
		return innerlist.IsSorted(comparer);
	}

	[ComVisible(true)]
	public void Sort()
	{
		innerlist.Sort();
	}

	[ComVisible(true)]
	public void Sort(IComparer<T> comparer)
	{
		innerlist.Sort(comparer);
	}

	[ComVisible(true)]
	public void Shuffle()
	{
		innerlist.Shuffle();
	}

	[ComVisible(true)]
	public void Shuffle(Random rnd)
	{
		innerlist.Shuffle(rnd);
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
	public int FindIndex(Fun<T, bool> predicate)
	{
		return innerlist.FindIndex(predicate);
	}

	[ComVisible(true)]
	public int FindLastIndex(Fun<T, bool> predicate)
	{
		return innerlist.FindLastIndex(predicate);
	}

	[ComVisible(true)]
	public T RemoveAt(int i)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public void RemoveInterval(int start, int count)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public int GetSequencedHashCode()
	{
		return innerlist.GetSequencedHashCode();
	}

	[ComVisible(true)]
	public bool SequencedEquals(ISequenced<T> that)
	{
		return innerlist.SequencedEquals(that);
	}

	[ComVisible(true)]
	public int GetUnsequencedHashCode()
	{
		return innerlist.GetUnsequencedHashCode();
	}

	[ComVisible(true)]
	public bool UnsequencedEquals(ICollection<T> that)
	{
		return innerlist.UnsequencedEquals(that);
	}

	[ComVisible(true)]
	public bool Contains(T item)
	{
		return innerlist.Contains(item);
	}

	[ComVisible(true)]
	public int ContainsCount(T item)
	{
		return innerlist.ContainsCount(item);
	}

	[ComVisible(true)]
	public ICollectionValue<T> UniqueItems()
	{
		return innerlist.UniqueItems();
	}

	[ComVisible(true)]
	public ICollectionValue<KeyValuePair<T, int>> ItemMultiplicities()
	{
		return innerlist.ItemMultiplicities();
	}

	[ComVisible(true)]
	public bool ContainsAll<U>(IEnumerable<U> items) where U : T
	{
		return innerlist.ContainsAll(items);
	}

	[ComVisible(true)]
	public bool Find(ref T item)
	{
		return innerlist.Find(ref item);
	}

	[ComVisible(true)]
	public bool FindOrAdd(ref T item)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public bool Update(T item)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public bool Update(T item, out T olditem)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public bool UpdateOrAdd(T item)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public bool UpdateOrAdd(T item, out T olditem)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public bool Remove(T item)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public bool Remove(T item, out T removeditem)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public void RemoveAllCopies(T item)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public void RemoveAll<U>(IEnumerable<U> items) where U : T
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public void Clear()
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public void RetainAll<U>(IEnumerable<U> items) where U : T
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public bool Add(T item)
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public void AddAll<U>(IEnumerable<U> items) where U : T
	{
		throw new FixedSizeCollectionException();
	}

	[ComVisible(true)]
	public bool Check()
	{
		if (innerlist.Check())
		{
			if (underlying != null)
			{
				return underlying.innerlist == innerlist.Underlying;
			}
			return true;
		}
		return false;
	}

	[ComVisible(true)]
	public void CopyTo(T[] array, int index)
	{
		innerlist.CopyTo(array, index);
	}

	[ComVisible(true)]
	public T[] ToArray()
	{
		return innerlist.ToArray();
	}

	[ComVisible(true)]
	public void Apply(Act<T> action)
	{
		innerlist.Apply(action);
	}

	[ComVisible(true)]
	public bool Exists(Fun<T, bool> predicate)
	{
		return innerlist.Exists(predicate);
	}

	[ComVisible(true)]
	public bool Find(Fun<T, bool> predicate, out T item)
	{
		return innerlist.Find(predicate, out item);
	}

	[ComVisible(true)]
	public bool All(Fun<T, bool> predicate)
	{
		return innerlist.All(predicate);
	}

	[ComVisible(true)]
	public T Choose()
	{
		return innerlist.Choose();
	}

	[ComVisible(true)]
	public IEnumerable<T> Filter(Fun<T, bool> filter)
	{
		return innerlist.Filter(filter);
	}

	[ComVisible(true)]
	public IEnumerator<T> GetEnumerator()
	{
		return innerlist.GetEnumerator();
	}

	[ComVisible(true)]
	public bool Show(StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		return innerlist.Show(stringbuilder, ref rest, formatProvider);
	}

	[ComVisible(true)]
	public override string ToString()
	{
		return innerlist.ToString();
	}

	[ComVisible(true)]
	public virtual string ToString(string format, IFormatProvider formatProvider)
	{
		return innerlist.ToString(format, formatProvider);
	}

	[ComVisible(true)]
	public IDirectedCollectionValue<T> Backwards()
	{
		return innerlist.Backwards();
	}

	[ComVisible(true)]
	public bool FindLast(Fun<T, bool> predicate, out T item)
	{
		return innerlist.FindLast(predicate, out item);
	}

	IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
	{
		return Backwards();
	}

	[ComVisible(true)]
	public void Dispose()
	{
		if (underlying == null)
		{
			throw new FixedSizeCollectionException();
		}
		innerlist.Dispose();
	}

	[ComVisible(true)]
	public virtual object Clone()
	{
		return new WrappedArray<T>(innerlist.ToArray());
	}

	void System.Collections.Generic.IList<T>.RemoveAt(int index)
	{
		throw new FixedSizeCollectionException();
	}

	void System.Collections.Generic.ICollection<T>.Add(T item)
	{
		throw new FixedSizeCollectionException();
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
		if (!Add((T)o))
		{
			return -1;
		}
		return Count - 1;
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
		Insert(index, (T)o);
	}

	void IList.Remove(object o)
	{
		Remove((T)o);
	}

	void IList.RemoveAt(int index)
	{
		RemoveAt(index);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new Exception("The method or operation is not implemented.");
	}
}
