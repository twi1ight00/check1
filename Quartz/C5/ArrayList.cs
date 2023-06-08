using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class ArrayList<T> : ArrayBase<T>, IList<T>, IIndexed<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, IDisposable, IList, ICollection, System.Collections.Generic.IList<T>, System.Collections.Generic.ICollection<T>, IStack<T>, IQueue<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	private class PositionComparer : IComparer<Position>
	{
		[ComVisible(true)]
		public int Compare(Position a, Position b)
		{
			return a.index.CompareTo(b.index);
		}

		[ComVisible(true)]
		public PositionComparer()
		{
		}
	}

	private struct Position
	{
		[ComVisible(true)]
		public readonly ArrayList<T> view;

		[ComVisible(true)]
		public readonly int index;

		[ComVisible(true)]
		public Position(ArrayList<T> view, bool left)
		{
			this.view = view;
			index = (left ? view.offset : (view.offset + view.size - 1));
		}

		[ComVisible(true)]
		public Position(int index)
		{
			this.index = index;
			view = null;
		}
	}

	private struct ViewHandler
	{
		private ArrayList<Position> leftEnds;

		private ArrayList<Position> rightEnds;

		private int leftEndIndex;

		private int rightEndIndex;

		internal readonly int viewCount;

		internal ViewHandler(ArrayList<T> list)
		{
			leftEndIndex = (rightEndIndex = (viewCount = 0));
			leftEnds = (rightEnds = null);
			if (list.views != null)
			{
				foreach (ArrayList<T> view in list.views)
				{
					if (view != list)
					{
						if (leftEnds == null)
						{
							leftEnds = new ArrayList<Position>();
							rightEnds = new ArrayList<Position>();
						}
						leftEnds.Add(new Position(view, left: true));
						rightEnds.Add(new Position(view, left: false));
					}
				}
			}
			if (leftEnds != null)
			{
				viewCount = leftEnds.Count;
				leftEnds.Sort(new PositionComparer());
				rightEnds.Sort(new PositionComparer());
			}
		}

		internal void skipEndpoints(int removed, int realindex)
		{
			if (viewCount <= 0)
			{
				return;
			}
			while (leftEndIndex < viewCount)
			{
				Position position;
				Position position2 = (position = leftEnds[leftEndIndex]);
				if (position2.index <= realindex)
				{
					ArrayList<T> view = position.view;
					view.offset -= removed;
					view.size += removed;
					leftEndIndex++;
					continue;
				}
				break;
			}
			while (rightEndIndex < viewCount)
			{
				Position position;
				Position position3 = (position = rightEnds[rightEndIndex]);
				if (position3.index < realindex)
				{
					position.view.size -= removed;
					rightEndIndex++;
					continue;
				}
				break;
			}
		}

		internal void updateViewSizesAndCounts(int removed, int realindex)
		{
			if (viewCount <= 0)
			{
				return;
			}
			while (leftEndIndex < viewCount)
			{
				Position position;
				Position position2 = (position = leftEnds[leftEndIndex]);
				if (position2.index <= realindex)
				{
					ArrayList<T> view = position.view;
					view.offset = view.Offset - removed;
					view.size += removed;
					leftEndIndex++;
					continue;
				}
				break;
			}
			while (rightEndIndex < viewCount)
			{
				Position position;
				Position position3 = (position = rightEnds[rightEndIndex]);
				if (position3.index < realindex)
				{
					position.view.size -= removed;
					rightEndIndex++;
					continue;
				}
				break;
			}
		}
	}

	private bool isValid = true;

	private ArrayList<T> underlying;

	private WeakViewList<ArrayList<T>> views;

	private WeakViewList<ArrayList<T>>.Node myWeakReference;

	private bool fIFO;

	private int underlyingsize => (underlying ?? this).size;

	[ComVisible(true)]
	public override EventTypeEnum ListenableEvents
	{
		[ComVisible(true)]
		get
		{
			if (underlying != null)
			{
				return EventTypeEnum.None;
			}
			return EventTypeEnum.All;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual T First
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			if (size == 0)
			{
				throw new NoSuchItemException();
			}
			return array[offset];
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual T Last
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			if (size == 0)
			{
				throw new NoSuchItemException();
			}
			return array[offset + size - 1];
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool FIFO
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			return fIFO;
		}
		[Tested]
		[ComVisible(true)]
		set
		{
			updatecheck();
			fIFO = value;
		}
	}

	[ComVisible(true)]
	public virtual bool IsFixedSize
	{
		[ComVisible(true)]
		get
		{
			validitycheck();
			return false;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual T this[int index]
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			if (index < 0 || index >= size)
			{
				throw new IndexOutOfRangeException();
			}
			return array[offset + index];
		}
		[Tested]
		[ComVisible(true)]
		set
		{
			updatecheck();
			if (index < 0 || index >= size)
			{
				throw new IndexOutOfRangeException();
			}
			index += offset;
			T item = array[index];
			array[index] = value;
			(underlying ?? this).raiseForSetThis(index, value, item);
		}
	}

	[ComVisible(true)]
	public virtual Speed IndexingSpeed
	{
		[ComVisible(true)]
		get
		{
			return Speed.Constant;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual IList<T> Underlying
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return underlying;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual int Offset
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return offset;
		}
	}

	[ComVisible(true)]
	public virtual bool IsValid
	{
		[ComVisible(true)]
		get
		{
			return isValid;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual Speed ContainsSpeed
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return Speed.Linear;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool AllowsDuplicates
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return true;
		}
	}

	[ComVisible(true)]
	public virtual bool DuplicatesByCounting
	{
		[ComVisible(true)]
		get
		{
			return false;
		}
	}

	[Tested]
	[ComVisible(true)]
	public override int Count
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			return size;
		}
	}

	bool ICollection.IsSynchronized => false;

	[Obsolete]
	object ICollection.SyncRoot
	{
		get
		{
			if (underlying == null)
			{
				return array;
			}
			return ((ICollection)underlying).SyncRoot;
		}
	}

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

	private bool equals(T i1, T i2)
	{
		return itemequalityComparer.Equals(i1, i2);
	}

	private void addtosize(int delta)
	{
		size += delta;
		if (underlying != null)
		{
			underlying.size += delta;
		}
	}

	protected override void expand()
	{
		expand(2 * array.Length, underlyingsize);
	}

	protected override void expand(int newcapacity, int newsize)
	{
		if (underlying != null)
		{
			underlying.expand(newcapacity, newsize);
			return;
		}
		base.expand(newcapacity, newsize);
		if (views == null)
		{
			return;
		}
		foreach (ArrayList<T> view in views)
		{
			view.array = array;
		}
	}

	protected override void updatecheck()
	{
		validitycheck();
		base.updatecheck();
		if (underlying != null)
		{
			underlying.stamp++;
		}
	}

	private void validitycheck()
	{
		if (!isValid)
		{
			throw new ViewDisposedException();
		}
	}

	protected override void modifycheck(int stamp)
	{
		validitycheck();
		if (base.stamp != stamp)
		{
			throw new CollectionModifiedException();
		}
	}

	private int indexOf(T item)
	{
		for (int i = 0; i < size; i++)
		{
			if (equals(item, array[offset + i]))
			{
				return i;
			}
		}
		return ~size;
	}

	private int lastIndexOf(T item)
	{
		for (int num = size - 1; num >= 0; num--)
		{
			if (equals(item, array[offset + num]))
			{
				return num;
			}
		}
		return ~size;
	}

	protected override void insert(int i, T item)
	{
		baseinsert(i, item);
	}

	private void baseinsert(int i, T item)
	{
		if (underlyingsize == array.Length)
		{
			expand();
		}
		i += offset;
		if (i < underlyingsize)
		{
			Array.Copy(array, i, array, i + 1, underlyingsize - i);
		}
		array[i] = item;
		addtosize(1);
		fixViewsAfterInsert(1, i);
	}

	private T removeAt(int i)
	{
		i += offset;
		fixViewsBeforeSingleRemove(i);
		T result = array[i];
		addtosize(-1);
		if (underlyingsize > i)
		{
			Array.Copy(array, i + 1, array, i, underlyingsize - i);
		}
		array[underlyingsize] = default(T);
		return result;
	}

	private void fixViewsAfterInsert(int added, int realInsertionIndex)
	{
		if (views == null)
		{
			return;
		}
		foreach (ArrayList<T> view in views)
		{
			if (view != this)
			{
				if (view.offset < realInsertionIndex && view.offset + view.size > realInsertionIndex)
				{
					view.size += added;
				}
				if (view.offset > realInsertionIndex || (view.offset == realInsertionIndex && view.size > 0))
				{
					view.offset += added;
				}
			}
		}
	}

	private void fixViewsBeforeSingleRemove(int realRemovalIndex)
	{
		if (views == null)
		{
			return;
		}
		foreach (ArrayList<T> view in views)
		{
			if (view != this)
			{
				if (view.offset <= realRemovalIndex && view.offset + view.size > realRemovalIndex)
				{
					view.size--;
				}
				if (view.offset > realRemovalIndex)
				{
					view.offset--;
				}
			}
		}
	}

	private void fixViewsBeforeRemove(int start, int count)
	{
		int num = start + count - 1;
		if (views == null)
		{
			return;
		}
		foreach (ArrayList<T> view in views)
		{
			if (view == this)
			{
				continue;
			}
			int num2 = view.offset;
			int num3 = num2 + view.size - 1;
			if (start < num2)
			{
				if (num < num2)
				{
					view.offset = num2 - count;
					continue;
				}
				view.offset = start;
				view.size = ((num < num3) ? (num3 - num) : 0);
			}
			else if (start <= num3)
			{
				view.size = ((num <= num3) ? (view.size - count) : (start - num2));
			}
		}
	}

	private MutualViewPosition viewPosition(int otherOffset, int otherSize)
	{
		int num = offset + size;
		int num2 = otherOffset + otherSize;
		if (otherOffset >= num || num2 <= offset)
		{
			return MutualViewPosition.NonOverlapping;
		}
		if (size == 0 || (otherOffset <= offset && num <= num2))
		{
			return MutualViewPosition.Contains;
		}
		if (otherSize == 0 || (offset <= otherOffset && num2 <= num))
		{
			return MutualViewPosition.ContainedIn;
		}
		return MutualViewPosition.Overlapping;
	}

	private void disposeOverlappingViews(bool reverse)
	{
		if (views == null)
		{
			return;
		}
		foreach (ArrayList<T> view in views)
		{
			if (view == this)
			{
				continue;
			}
			switch (viewPosition(view.offset, view.size))
			{
			case MutualViewPosition.ContainedIn:
				if (reverse)
				{
					view.offset = 2 * offset + size - view.size - view.offset;
				}
				else
				{
					view.Dispose();
				}
				break;
			case MutualViewPosition.Overlapping:
				view.Dispose();
				break;
			}
		}
	}

	[ComVisible(true)]
	public ArrayList()
		: this(8)
	{
	}

	[ComVisible(true)]
	public ArrayList(IEqualityComparer<T> itemequalityComparer)
		: this(8, itemequalityComparer)
	{
	}

	[ComVisible(true)]
	public ArrayList(int capacity)
		: this(capacity, EqualityComparer<T>.Default)
	{
	}

	[ComVisible(true)]
	public ArrayList(int capacity, IEqualityComparer<T> itemequalityComparer)
		: base(capacity, itemequalityComparer)
	{
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Insert(int index, T item)
	{
		updatecheck();
		if (index < 0 || index > size)
		{
			throw new IndexOutOfRangeException();
		}
		insert(index, item);
		(underlying ?? this).raiseForInsert(index + offset, item);
	}

	[ComVisible(true)]
	public void Insert(IList<T> pointer, T item)
	{
		if (pointer == null || (pointer.Underlying ?? pointer) != (underlying ?? this))
		{
			throw new IncompatibleViewException();
		}
		Insert(pointer.Offset + pointer.Count - Offset, item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual void InsertAll<U>(int index, IEnumerable<U> items) where U : T
	{
		updatecheck();
		if (index < 0 || index > size)
		{
			throw new IndexOutOfRangeException();
		}
		index += offset;
		int num = EnumerableBase<U>.countItems(items);
		if (num == 0)
		{
			return;
		}
		if (num + underlyingsize > array.Length)
		{
			expand(num + underlyingsize, underlyingsize);
		}
		if (underlyingsize > index)
		{
			Array.Copy(array, index, array, index + num, underlyingsize - index);
		}
		int num2 = index;
		try
		{
			foreach (U item in items)
			{
				T val = (T)(object)item;
				array[num2++] = val;
			}
		}
		finally
		{
			int num3 = num2 - index;
			if (num3 < num)
			{
				Array.Copy(array, index + num, array, num2, underlyingsize - index);
				Array.Clear(array, underlyingsize + num3, num - num3);
			}
			if (num3 > 0)
			{
				addtosize(num3);
				fixViewsAfterInsert(num3, index);
				(underlying ?? this).raiseForInsertAll(index, num3);
			}
		}
	}

	private void raiseForInsertAll(int index, int added)
	{
		if (ActiveEvents == EventTypeEnum.None)
		{
			return;
		}
		if ((ActiveEvents & (EventTypeEnum.Added | EventTypeEnum.Inserted)) != 0)
		{
			for (int i = index; i < index + added; i++)
			{
				raiseItemInserted(array[i], i);
				raiseItemsAdded(array[i], 1);
			}
		}
		raiseCollectionChanged();
	}

	[Tested]
	[ComVisible(true)]
	public virtual void InsertFirst(T item)
	{
		updatecheck();
		insert(0, item);
		(underlying ?? this).raiseForInsert(offset, item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual void InsertLast(T item)
	{
		updatecheck();
		insert(size, item);
		(underlying ?? this).raiseForInsert(size - 1 + offset, item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual IList<T> FindAll(Fun<T, bool> filter)
	{
		validitycheck();
		int thestamp = stamp;
		ArrayList<T> arrayList = new ArrayList<T>(itemequalityComparer);
		int num = 0;
		int num2 = arrayList.array.Length;
		for (int i = 0; i < size; i++)
		{
			T val = array[offset + i];
			bool flag = filter(val);
			modifycheck(thestamp);
			if (flag)
			{
				if (num == num2)
				{
					arrayList.expand(num2 = 2 * num2, num);
				}
				arrayList.array[num++] = val;
			}
		}
		arrayList.size = num;
		return arrayList;
	}

	[Tested]
	[ComVisible(true)]
	public virtual IList<V> Map<V>(Fun<T, V> mapper)
	{
		validitycheck();
		ArrayList<V> res = new ArrayList<V>(size);
		return map(mapper, res);
	}

	[ComVisible(true)]
	public virtual IList<V> Map<V>(Fun<T, V> mapper, IEqualityComparer<V> itemequalityComparer)
	{
		validitycheck();
		ArrayList<V> res = new ArrayList<V>(size, itemequalityComparer);
		return map(mapper, res);
	}

	private IList<V> map<V>(Fun<T, V> mapper, ArrayList<V> res)
	{
		int thestamp = stamp;
		if (size > 0)
		{
			for (int i = 0; i < size; i++)
			{
				V val = mapper(array[offset + i]);
				modifycheck(thestamp);
				res.array[i] = val;
			}
		}
		res.size = size;
		return res;
	}

	[Tested]
	[ComVisible(true)]
	public virtual T Remove()
	{
		updatecheck();
		if (size == 0)
		{
			throw new NoSuchItemException("List is empty");
		}
		T val = removeAt((!fIFO) ? (size - 1) : 0);
		(underlying ?? this).raiseForRemove(val);
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public virtual T RemoveFirst()
	{
		updatecheck();
		if (size == 0)
		{
			throw new NoSuchItemException("List is empty");
		}
		T val = removeAt(0);
		(underlying ?? this).raiseForRemoveAt(offset, val);
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public virtual T RemoveLast()
	{
		updatecheck();
		if (size == 0)
		{
			throw new NoSuchItemException("List is empty");
		}
		T val = removeAt(size - 1);
		(underlying ?? this).raiseForRemoveAt(size + offset, val);
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public virtual IList<T> View(int start, int count)
	{
		validitycheck();
		checkRange(start, count);
		if (views == null)
		{
			views = new WeakViewList<ArrayList<T>>();
		}
		ArrayList<T> arrayList = (ArrayList<T>)MemberwiseClone();
		arrayList.underlying = ((underlying != null) ? underlying : this);
		arrayList.offset = start + offset;
		arrayList.size = count;
		arrayList.myWeakReference = views.Add(arrayList);
		return arrayList;
	}

	[Tested]
	[ComVisible(true)]
	public virtual IList<T> ViewOf(T item)
	{
		int num = indexOf(item);
		if (num < 0)
		{
			return null;
		}
		return View(num, 1);
	}

	[Tested]
	[ComVisible(true)]
	public virtual IList<T> LastViewOf(T item)
	{
		int num = lastIndexOf(item);
		if (num < 0)
		{
			return null;
		}
		return View(num, 1);
	}

	[Tested]
	[ComVisible(true)]
	public virtual IList<T> Slide(int offset)
	{
		if (!TrySlide(offset, size))
		{
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}

	[Tested]
	[ComVisible(true)]
	public virtual IList<T> Slide(int offset, int size)
	{
		if (!TrySlide(offset, size))
		{
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool TrySlide(int offset)
	{
		return TrySlide(offset, size);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool TrySlide(int offset, int size)
	{
		updatecheck();
		if (underlying == null)
		{
			throw new NotAViewException("Not a view");
		}
		int num = base.offset + offset;
		if (num < 0 || size < 0 || num + size > underlyingsize)
		{
			return false;
		}
		base.offset = num;
		base.size = size;
		return true;
	}

	[ComVisible(true)]
	public virtual IList<T> Span(IList<T> otherView)
	{
		if (otherView == null || (otherView.Underlying ?? otherView) != (underlying ?? this))
		{
			throw new IncompatibleViewException();
		}
		if (otherView.Offset + otherView.Count - Offset < 0)
		{
			return null;
		}
		return (underlying ?? this).View(Offset, otherView.Offset + otherView.Count - Offset);
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Reverse()
	{
		updatecheck();
		if (size != 0)
		{
			int i = 0;
			int num = size / 2;
			int num2 = offset + size - 1;
			for (; i < num; i++)
			{
				T val = array[offset + i];
				array[offset + i] = array[num2 - i];
				array[num2 - i] = val;
			}
			disposeOverlappingViews(reverse: true);
			(underlying ?? this).raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public bool IsSorted()
	{
		return IsSorted(Comparer<T>.Default);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool IsSorted(IComparer<T> c)
	{
		validitycheck();
		int i = offset + 1;
		for (int num = offset + size; i < num; i++)
		{
			if (c.Compare(array[i - 1], array[i]) > 0)
			{
				return false;
			}
		}
		return true;
	}

	[ComVisible(true)]
	public virtual void Sort()
	{
		Sort(Comparer<T>.Default);
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Sort(IComparer<T> comparer)
	{
		updatecheck();
		if (size != 0)
		{
			Sorting.IntroSort(array, offset, size, comparer);
			disposeOverlappingViews(reverse: false);
			(underlying ?? this).raiseCollectionChanged();
		}
	}

	[ComVisible(true)]
	public virtual void Shuffle()
	{
		Shuffle(new C5Random());
	}

	[ComVisible(true)]
	public virtual void Shuffle(Random rnd)
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		int i = offset;
		int num = offset + size;
		for (int num2 = num - 1; i < num2; i++)
		{
			int num3 = rnd.Next(i, num);
			if (num3 != i)
			{
				T val = array[i];
				array[i] = array[num3];
				array[num3] = val;
			}
		}
		disposeOverlappingViews(reverse: false);
		(underlying ?? this).raiseCollectionChanged();
	}

	[Tested]
	[ComVisible(true)]
	public virtual int IndexOf(T item)
	{
		validitycheck();
		return indexOf(item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual int LastIndexOf(T item)
	{
		validitycheck();
		return lastIndexOf(item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual T RemoveAt(int index)
	{
		updatecheck();
		if (index < 0 || index >= size)
		{
			throw new IndexOutOfRangeException("Index out of range for sequenced collection");
		}
		T val = removeAt(index);
		(underlying ?? this).raiseForRemoveAt(offset + index, val);
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RemoveInterval(int start, int count)
	{
		updatecheck();
		if (count != 0)
		{
			checkRange(start, count);
			start += offset;
			fixViewsBeforeRemove(start, count);
			Array.Copy(array, start + count, array, start, underlyingsize - start - count);
			addtosize(-count);
			Array.Clear(array, underlyingsize, count);
			(underlying ?? this).raiseForRemoveInterval(start, count);
		}
	}

	private void raiseForRemoveInterval(int start, int count)
	{
		if (ActiveEvents != 0)
		{
			raiseCollectionCleared(size == 0, count, start);
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public override int GetUnsequencedHashCode()
	{
		validitycheck();
		return base.GetUnsequencedHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public override bool UnsequencedEquals(ICollection<T> that)
	{
		validitycheck();
		return base.UnsequencedEquals(that);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Contains(T item)
	{
		validitycheck();
		return indexOf(item) >= 0;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Find(ref T item)
	{
		validitycheck();
		int num;
		if ((num = indexOf(item)) >= 0)
		{
			item = array[offset + num];
			return true;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Update(T item)
	{
		T olditem;
		return Update(item, out olditem);
	}

	[ComVisible(true)]
	public virtual bool Update(T item, out T olditem)
	{
		updatecheck();
		int num;
		if ((num = indexOf(item)) >= 0)
		{
			olditem = array[offset + num];
			array[offset + num] = item;
			(underlying ?? this).raiseForUpdate(item, olditem);
			return true;
		}
		olditem = default(T);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool FindOrAdd(ref T item)
	{
		updatecheck();
		if (Find(ref item))
		{
			return true;
		}
		Add(item);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool UpdateOrAdd(T item)
	{
		updatecheck();
		if (Update(item))
		{
			return true;
		}
		Add(item);
		return false;
	}

	[ComVisible(true)]
	public virtual bool UpdateOrAdd(T item, out T olditem)
	{
		updatecheck();
		if (Update(item, out olditem))
		{
			return true;
		}
		Add(item);
		olditem = default(T);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Remove(T item)
	{
		updatecheck();
		int num = (fIFO ? indexOf(item) : lastIndexOf(item));
		if (num < 0)
		{
			return false;
		}
		T item2 = removeAt(num);
		(underlying ?? this).raiseForRemove(item2);
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Remove(T item, out T removeditem)
	{
		updatecheck();
		int num = (fIFO ? indexOf(item) : lastIndexOf(item));
		if (num < 0)
		{
			removeditem = default(T);
			return false;
		}
		removeditem = removeAt(num);
		(underlying ?? this).raiseForRemove(removeditem);
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RemoveAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		hashBag.AddAll(items);
		if (hashBag.Count == 0)
		{
			return;
		}
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(underlying ?? this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		ViewHandler viewHandler = new ViewHandler(this);
		int num = offset;
		int num2 = 0;
		int num3 = offset;
		int num4 = offset + size;
		while (num3 < num4)
		{
			T val;
			while (num3 < num4 && !hashBag.Contains(val = array[num3]))
			{
				array[num] = val;
				num3++;
				num++;
			}
			viewHandler.skipEndpoints(num2, num3);
			while (num3 < num4 && hashBag.Remove(val = array[num3]))
			{
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(val);
				}
				num2++;
				num3++;
				viewHandler.updateViewSizesAndCounts(num2, num3);
			}
		}
		if (num2 != 0)
		{
			viewHandler.updateViewSizesAndCounts(num2, underlyingsize);
			Array.Copy(array, offset + size, array, num, underlyingsize - offset - size);
			addtosize(-num2);
			Array.Clear(array, underlyingsize, num2);
			if (mustFire)
			{
				raiseForRemoveAllHandler.Raise();
			}
		}
	}

	private void RemoveAll(Fun<T, bool> predicate)
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(underlying ?? this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		ViewHandler viewHandler = new ViewHandler(this);
		int num = offset;
		int num2 = 0;
		int num3 = offset;
		int num4 = offset + size;
		while (num3 < num4)
		{
			T val;
			while (num3 < num4 && !predicate(val = array[num3]))
			{
				updatecheck();
				array[num] = val;
				num3++;
				num++;
			}
			updatecheck();
			viewHandler.skipEndpoints(num2, num3);
			while (num3 < num4 && predicate(val = array[num3]))
			{
				updatecheck();
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(val);
				}
				num2++;
				num3++;
				viewHandler.updateViewSizesAndCounts(num2, num3);
			}
			updatecheck();
		}
		if (num2 != 0)
		{
			viewHandler.updateViewSizesAndCounts(num2, underlyingsize);
			Array.Copy(array, offset + size, array, num, underlyingsize - offset - size);
			addtosize(-num2);
			Array.Clear(array, underlyingsize, num2);
			if (mustFire)
			{
				raiseForRemoveAllHandler.Raise();
			}
		}
	}

	[Tested]
	[ComVisible(true)]
	public override void Clear()
	{
		if (underlying == null)
		{
			updatecheck();
			if (size != 0)
			{
				int count = size;
				fixViewsBeforeRemove(0, size);
				array = new T[8];
				size = 0;
				(underlying ?? this).raiseForRemoveInterval(offset, count);
			}
		}
		else
		{
			RemoveInterval(0, size);
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RetainAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		hashBag.AddAll(items);
		if (hashBag.Count == 0)
		{
			Clear();
			return;
		}
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(underlying ?? this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		ViewHandler viewHandler = new ViewHandler(this);
		int num = offset;
		int num2 = 0;
		int num3 = offset;
		int num4 = offset + size;
		while (num3 < num4)
		{
			T val;
			while (num3 < num4 && hashBag.Remove(val = array[num3]))
			{
				array[num] = val;
				num3++;
				num++;
			}
			viewHandler.skipEndpoints(num2, num3);
			while (num3 < num4 && !hashBag.Contains(val = array[num3]))
			{
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(val);
				}
				num2++;
				num3++;
				viewHandler.updateViewSizesAndCounts(num2, num3);
			}
		}
		if (num2 != 0)
		{
			viewHandler.updateViewSizesAndCounts(num2, underlyingsize);
			Array.Copy(array, offset + size, array, num, underlyingsize - offset - size);
			addtosize(-num2);
			Array.Clear(array, underlyingsize, num2);
			raiseForRemoveAllHandler.Raise();
		}
	}

	private void RetainAll(Fun<T, bool> predicate)
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(underlying ?? this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		ViewHandler viewHandler = new ViewHandler(this);
		int num = offset;
		int num2 = 0;
		int num3 = offset;
		int num4 = offset + size;
		while (num3 < num4)
		{
			T val;
			while (num3 < num4 && predicate(val = array[num3]))
			{
				updatecheck();
				array[num] = val;
				num3++;
				num++;
			}
			updatecheck();
			viewHandler.skipEndpoints(num2, num3);
			while (num3 < num4 && !predicate(val = array[num3]))
			{
				updatecheck();
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(val);
				}
				num2++;
				num3++;
				viewHandler.updateViewSizesAndCounts(num2, num3);
			}
			updatecheck();
		}
		if (num2 != 0)
		{
			viewHandler.updateViewSizesAndCounts(num2, underlyingsize);
			Array.Copy(array, offset + size, array, num, underlyingsize - offset - size);
			addtosize(-num2);
			Array.Clear(array, underlyingsize, num2);
			raiseForRemoveAllHandler.Raise();
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool ContainsAll<U>(IEnumerable<U> items) where U : T
	{
		validitycheck();
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		hashBag.AddAll(items);
		if (hashBag.Count == 0)
		{
			return true;
		}
		int i = offset;
		for (int num = offset + size; i < num; i++)
		{
			hashBag.Remove(array[i]);
			if (hashBag.Count == 0)
			{
				return true;
			}
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual int ContainsCount(T item)
	{
		validitycheck();
		int num = 0;
		for (int i = 0; i < size; i++)
		{
			if (equals(item, array[offset + i]))
			{
				num++;
			}
		}
		return num;
	}

	[ComVisible(true)]
	public virtual ICollectionValue<T> UniqueItems()
	{
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		hashBag.AddAll(this);
		return hashBag.UniqueItems();
	}

	[ComVisible(true)]
	public virtual ICollectionValue<KeyValuePair<T, int>> ItemMultiplicities()
	{
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		hashBag.AddAll(this);
		return hashBag.ItemMultiplicities();
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RemoveAllCopies(T item)
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(underlying ?? this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		ViewHandler viewHandler = new ViewHandler(this);
		int destinationIndex = offset;
		int num = 0;
		int num2 = offset;
		int num3 = offset + size;
		while (num2 < num3)
		{
			while (num2 < num3 && !equals(item, array[num2]))
			{
				array[destinationIndex++] = array[num2++];
			}
			viewHandler.skipEndpoints(num, num2);
			while (num2 < num3 && equals(item, array[num2]))
			{
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(array[num2]);
				}
				num++;
				num2++;
				viewHandler.updateViewSizesAndCounts(num, num2);
			}
		}
		if (num != 0)
		{
			viewHandler.updateViewSizesAndCounts(num, underlyingsize);
			Array.Copy(array, offset + size, array, destinationIndex, underlyingsize - offset - size);
			addtosize(-num);
			Array.Clear(array, underlyingsize, num);
			raiseForRemoveAllHandler.Raise();
		}
	}

	[Tested]
	[ComVisible(true)]
	public override bool Check()
	{
		bool result = true;
		if (underlyingsize > array.Length)
		{
			Console.WriteLine("underlyingsize ({0}) > array.Length ({1})", size, array.Length);
			return false;
		}
		if (offset + size > underlyingsize)
		{
			Console.WriteLine("offset({0})+size({1}) > underlyingsize ({2})", offset, size, underlyingsize);
			return false;
		}
		if (offset < 0)
		{
			Console.WriteLine("offset({0}) < 0", offset);
			return false;
		}
		for (int i = 0; i < underlyingsize; i++)
		{
			if (array[i] == null)
			{
				Console.WriteLine("Bad element: null at (base)index {0}", i);
				result = false;
			}
		}
		int j = underlyingsize;
		for (int num = array.Length; j < num; j++)
		{
			if (!equals(array[j], default(T)))
			{
				Console.WriteLine("Bad element: != default(T) at (base)index {0}", j);
				result = false;
			}
		}
		ArrayList<T> arrayList = underlying ?? this;
		if (arrayList.views != null)
		{
			foreach (ArrayList<T> view in arrayList.views)
			{
				if (arrayList.array != view.array)
				{
					Console.WriteLine("View from {0} of length has different base array than the underlying list", view.offset, view.size);
					result = false;
				}
			}
		}
		return result;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Add(T item)
	{
		updatecheck();
		baseinsert(size, item);
		(underlying ?? this).raiseForAdd(item);
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void AddAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		int num = EnumerableBase<U>.countItems(items);
		if (num == 0)
		{
			return;
		}
		if (num + underlyingsize > array.Length)
		{
			expand(num + underlyingsize, underlyingsize);
		}
		int num2 = size + offset;
		if (underlyingsize > num2)
		{
			Array.Copy(array, num2, array, num2 + num, underlyingsize - num2);
		}
		try
		{
			foreach (U item in items)
			{
				T val = (T)(object)item;
				array[num2++] = val;
			}
		}
		finally
		{
			int num3 = num2 - size - offset;
			if (num3 < num)
			{
				Array.Copy(array, size + offset + num, array, num2, underlyingsize - size - offset);
				Array.Clear(array, underlyingsize + num3, num - num3);
			}
			if (num3 > 0)
			{
				addtosize(num3);
				fixViewsAfterInsert(num3, num2 - num3);
				(underlying ?? this).raiseForAddAll(num2 - num3, num3);
			}
		}
	}

	private void raiseForAddAll(int start, int added)
	{
		if ((ActiveEvents & EventTypeEnum.Added) != 0)
		{
			int i = start;
			for (int num = start + added; i < num; i++)
			{
				raiseItemsAdded(array[i], 1);
			}
		}
		raiseCollectionChanged();
	}

	[Tested]
	IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
	{
		return Backwards();
	}

	[Tested]
	[ComVisible(true)]
	public override IEnumerator<T> GetEnumerator()
	{
		validitycheck();
		return base.GetEnumerator();
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Push(T item)
	{
		InsertLast(item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual T Pop()
	{
		return RemoveLast();
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Enqueue(T item)
	{
		InsertLast(item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual T Dequeue()
	{
		return RemoveFirst();
	}

	[ComVisible(true)]
	public virtual void Dispose()
	{
		Dispose(disposingUnderlying: false);
	}

	private void Dispose(bool disposingUnderlying)
	{
		if (!isValid)
		{
			return;
		}
		if (underlying != null)
		{
			isValid = false;
			if (!disposingUnderlying && views != null)
			{
				views.Remove(myWeakReference);
			}
			underlying = null;
			views = null;
			myWeakReference = null;
			return;
		}
		if (views != null)
		{
			foreach (ArrayList<T> view in views)
			{
				view.Dispose(disposingUnderlying: true);
			}
		}
		Clear();
	}

	[ComVisible(true)]
	public virtual object Clone()
	{
		ArrayList<T> arrayList = new ArrayList<T>(size, itemequalityComparer);
		arrayList.AddAll(this);
		return arrayList;
	}

	void System.Collections.Generic.IList<T>.RemoveAt(int index)
	{
		RemoveAt(index);
	}

	void System.Collections.Generic.ICollection<T>.Add(T item)
	{
		Add(item);
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
}
