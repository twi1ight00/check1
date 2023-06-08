using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class SortedArray<T> : ArrayBase<T>, IIndexedSorted<T>, ISorted<T>, IIndexed<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, System.Collections.Generic.ICollection<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	[Flags]
	[ComVisible(true)]
	public enum Feature : short
	{
		[ComVisible(true)]
		Standard = 0
	}

	private static Feature features;

	private IComparer<T> comparer;

	[ComVisible(true)]
	public static Feature Features
	{
		[ComVisible(true)]
		get
		{
			return features;
		}
	}

	[ComVisible(true)]
	public override EventTypeEnum ListenableEvents
	{
		[ComVisible(true)]
		get
		{
			return EventTypeEnum.Basic;
		}
	}

	[Tested]
	[ComVisible(true)]
	public Speed ContainsSpeed
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return Speed.Log;
		}
	}

	[Tested]
	[ComVisible(true)]
	public bool AllowsDuplicates
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return false;
		}
	}

	[ComVisible(true)]
	public virtual bool DuplicatesByCounting
	{
		[ComVisible(true)]
		get
		{
			return true;
		}
	}

	[ComVisible(true)]
	public IComparer<T> Comparer
	{
		[ComVisible(true)]
		get
		{
			return comparer;
		}
	}

	[Tested]
	[ComVisible(true)]
	public T this[int i]
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			if (i < 0 || i >= size)
			{
				throw new IndexOutOfRangeException();
			}
			return array[i];
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

	private bool binarySearch(T item, out int mid)
	{
		int num = 0;
		int num2 = size;
		mid = num2 / 2;
		while (num2 > num)
		{
			int num3;
			if ((num3 = comparer.Compare(array[mid], item)) == 0)
			{
				return true;
			}
			if (num3 > 0)
			{
				num2 = mid;
			}
			else
			{
				num = mid + 1;
			}
			mid = (num + num2) / 2;
		}
		return false;
	}

	private int indexOf(T item)
	{
		if (binarySearch(item, out var mid))
		{
			return mid;
		}
		return ~mid;
	}

	[ComVisible(true)]
	public SortedArray()
		: this(8)
	{
	}

	[ComVisible(true)]
	public SortedArray(int capacity)
		: this(capacity, Comparer<T>.Default, EqualityComparer<T>.Default)
	{
	}

	[ComVisible(true)]
	public SortedArray(IComparer<T> comparer)
		: this(8, comparer)
	{
	}

	[ComVisible(true)]
	public SortedArray(int capacity, IComparer<T> comparer)
		: this(capacity, comparer, (IEqualityComparer<T>)new ComparerZeroHashCodeEqualityComparer<T>(comparer))
	{
	}

	[ComVisible(true)]
	public SortedArray(int capacity, IComparer<T> comparer, IEqualityComparer<T> equalityComparer)
		: base(capacity, equalityComparer)
	{
		if (comparer == null)
		{
			throw new NullReferenceException("Comparer cannot be null");
		}
		this.comparer = comparer;
	}

	[Tested]
	[ComVisible(true)]
	public int CountFrom(T bot)
	{
		binarySearch(bot, out var mid);
		return size - mid;
	}

	[Tested]
	[ComVisible(true)]
	public int CountFromTo(T bot, T top)
	{
		binarySearch(bot, out var mid);
		binarySearch(top, out var mid2);
		if (mid2 <= mid)
		{
			return 0;
		}
		return mid2 - mid;
	}

	[Tested]
	[ComVisible(true)]
	public int CountTo(T top)
	{
		binarySearch(top, out var mid);
		return mid;
	}

	[Tested]
	[ComVisible(true)]
	public IDirectedCollectionValue<T> RangeFrom(T bot)
	{
		binarySearch(bot, out var mid);
		return new Range(this, mid, size - mid, forwards: true);
	}

	[Tested]
	[ComVisible(true)]
	public IDirectedCollectionValue<T> RangeFromTo(T bot, T top)
	{
		binarySearch(bot, out var mid);
		binarySearch(top, out var mid2);
		int count = mid2 - mid;
		return new Range(this, mid, count, forwards: true);
	}

	[Tested]
	[ComVisible(true)]
	public IDirectedCollectionValue<T> RangeTo(T top)
	{
		binarySearch(top, out var mid);
		return new Range(this, 0, mid, forwards: true);
	}

	[Tested]
	[ComVisible(true)]
	public IIndexedSorted<T> FindAll(Fun<T, bool> f)
	{
		SortedArray<T> sortedArray = new SortedArray<T>(comparer);
		int num = 0;
		int num2 = sortedArray.array.Length;
		for (int i = 0; i < size; i++)
		{
			T val = array[i];
			if (f(val))
			{
				if (num == num2)
				{
					sortedArray.expand(num2 = 2 * num2, num);
				}
				sortedArray.array[num++] = val;
			}
		}
		sortedArray.size = num;
		return sortedArray;
	}

	[Tested]
	[ComVisible(true)]
	public IIndexedSorted<V> Map<V>(Fun<T, V> m, IComparer<V> c)
	{
		SortedArray<V> sortedArray = new SortedArray<V>(size, c);
		if (size > 0)
		{
			V x = (sortedArray.array[0] = m(array[0]));
			for (int i = 1; i < size; i++)
			{
				V val;
				if (c.Compare(x, val = (sortedArray.array[i] = m(array[i]))) >= 0)
				{
					throw new ArgumentException("mapper not monotonic");
				}
				x = val;
			}
		}
		sortedArray.size = size;
		return sortedArray;
	}

	[ComVisible(true)]
	public bool TryPredecessor(T item, out T res)
	{
		binarySearch(item, out var mid);
		if (mid == 0)
		{
			res = default(T);
			return false;
		}
		res = array[mid - 1];
		return true;
	}

	[ComVisible(true)]
	public bool TrySuccessor(T item, out T res)
	{
		if (binarySearch(item, out var mid))
		{
			mid++;
		}
		if (mid >= size)
		{
			res = default(T);
			return false;
		}
		res = array[mid];
		return true;
	}

	[ComVisible(true)]
	public bool TryWeakPredecessor(T item, out T res)
	{
		if (!binarySearch(item, out var mid))
		{
			mid--;
		}
		if (mid < 0)
		{
			res = default(T);
			return false;
		}
		res = array[mid];
		return true;
	}

	[ComVisible(true)]
	public bool TryWeakSuccessor(T item, out T res)
	{
		binarySearch(item, out var mid);
		if (mid >= size)
		{
			res = default(T);
			return false;
		}
		res = array[mid];
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public T Predecessor(T item)
	{
		binarySearch(item, out var mid);
		if (mid == 0)
		{
			throw new NoSuchItemException();
		}
		return array[mid - 1];
	}

	[Tested]
	[ComVisible(true)]
	public T Successor(T item)
	{
		if (binarySearch(item, out var mid))
		{
			mid++;
		}
		if (mid >= size)
		{
			throw new NoSuchItemException();
		}
		return array[mid];
	}

	[Tested]
	[ComVisible(true)]
	public T WeakPredecessor(T item)
	{
		if (!binarySearch(item, out var mid))
		{
			mid--;
		}
		if (mid < 0)
		{
			throw new NoSuchItemException();
		}
		return array[mid];
	}

	[Tested]
	[ComVisible(true)]
	public T WeakSuccessor(T item)
	{
		binarySearch(item, out var mid);
		if (mid >= size)
		{
			throw new NoSuchItemException();
		}
		return array[mid];
	}

	[Tested]
	[ComVisible(true)]
	public bool Cut(IComparable<T> c, out T low, out bool lowIsValid, out T high, out bool highIsValid)
	{
		int num = -1;
		int num2 = size;
		low = default(T);
		lowIsValid = false;
		high = default(T);
		highIsValid = false;
		int num3 = 0;
		int num4 = size;
		int num5 = -1;
		int num6 = num4 / 2;
		while (num4 > num3 && (num5 = c.CompareTo(array[num6])) != 0)
		{
			if (num5 < 0)
			{
				num2 = (num4 = num6);
			}
			else
			{
				num = num6;
				num3 = num6 + 1;
			}
			num6 = (num3 + num4) / 2;
		}
		if (num5 != 0)
		{
			if (num >= 0)
			{
				lowIsValid = true;
				low = array[num];
			}
			if (num2 < size)
			{
				highIsValid = true;
				high = array[num2];
			}
			return false;
		}
		int num7 = num6;
		num3 = num7 - 1;
		while (num2 > num3)
		{
			num6 = (num3 + num2) / 2;
			if (c.CompareTo(array[num6]) < 0)
			{
				num2 = num6;
			}
			else
			{
				num3 = num6 + 1;
			}
		}
		if (num2 < size)
		{
			highIsValid = true;
			high = array[num2];
		}
		num4 = num7 + 1;
		while (num4 > num)
		{
			num6 = (num + num4 + 1) / 2;
			if (c.CompareTo(array[num6]) > 0)
			{
				num = num6;
			}
			else
			{
				num4 = num6 - 1;
			}
		}
		if (num >= 0)
		{
			lowIsValid = true;
			low = array[num];
		}
		return true;
	}

	IDirectedEnumerable<T> ISorted<T>.RangeFrom(T bot)
	{
		return RangeFrom(bot);
	}

	IDirectedEnumerable<T> ISorted<T>.RangeFromTo(T bot, T top)
	{
		return RangeFromTo(bot, top);
	}

	IDirectedEnumerable<T> ISorted<T>.RangeTo(T top)
	{
		return RangeTo(top);
	}

	[Tested]
	[ComVisible(true)]
	public IDirectedCollectionValue<T> RangeAll()
	{
		return new Range(this, 0, size, forwards: true);
	}

	[Tested]
	[ComVisible(true)]
	public void AddSorted<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		int num = 0;
		int num2 = 0;
		int num3 = -1;
		int num4 = EnumerableBase<U>.countItems(items);
		int numAdded = 0;
		SortedArray<T> sortedArray = new SortedArray<T>(size + num4, comparer);
		T x = default(T);
		T[] array = new T[num4];
		foreach (U item in items)
		{
			T val = (T)(object)item;
			do
			{
				if (num2 < size && (num3 = comparer.Compare(base.array[num2], val)) <= 0)
				{
					x = (sortedArray.array[num++] = base.array[num2++]);
					continue;
				}
				if (num <= 0 || comparer.Compare(x, val) < 0)
				{
					x = (array[numAdded++] = (sortedArray.array[num++] = val));
					break;
				}
				throw new ArgumentException("Argument not sorted");
			}
			while (num3 != 0);
			num3 = -1;
		}
		while (num2 < size)
		{
			sortedArray.array[num++] = base.array[num2++];
		}
		size = num;
		base.array = sortedArray.array;
		raiseForAddAll(array, numAdded);
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveRangeFrom(T low)
	{
		binarySearch(low, out var mid);
		if (mid != size)
		{
			T[] array = new T[size - mid];
			Array.Copy(base.array, mid, array, 0, array.Length);
			Array.Reverse(array);
			Array.Clear(base.array, mid, size - mid);
			size = mid;
			raiseForRemoveRange(array);
		}
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveRangeFromTo(T low, T hi)
	{
		binarySearch(low, out var mid);
		binarySearch(hi, out var mid2);
		if (mid2 > mid)
		{
			T[] array = new T[mid2 - mid];
			Array.Copy(base.array, mid, array, 0, array.Length);
			Array.Reverse(array);
			Array.Copy(base.array, mid2, base.array, mid, size - mid2);
			Array.Clear(base.array, size - mid2 + mid, mid2 - mid);
			size -= mid2 - mid;
			raiseForRemoveRange(array);
		}
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveRangeTo(T hi)
	{
		binarySearch(hi, out var mid);
		if (mid != 0)
		{
			T[] array = new T[mid];
			Array.Copy(base.array, 0, array, 0, array.Length);
			Array.Copy(base.array, mid, base.array, 0, size - mid);
			Array.Clear(base.array, size - mid, mid);
			size -= mid;
			raiseForRemoveRange(array);
		}
	}

	private void raiseForRemoveRange(T[] removed)
	{
		foreach (T item in removed)
		{
			raiseItemsRemoved(item, 1);
		}
		if (removed.Length > 0)
		{
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public override void Clear()
	{
		int num = size;
		base.Clear();
		if (num > 0)
		{
			raiseCollectionCleared(full: true, num);
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public bool Contains(T item)
	{
		int mid;
		return binarySearch(item, out mid);
	}

	[Tested]
	[ComVisible(true)]
	public bool Find(ref T item)
	{
		if (binarySearch(item, out var mid))
		{
			item = array[mid];
			return true;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public bool FindOrAdd(ref T item)
	{
		updatecheck();
		if (binarySearch(item, out var mid))
		{
			item = array[mid];
			return true;
		}
		if (size == array.Length)
		{
			expand();
		}
		Array.Copy(array, mid, array, mid + 1, size - mid);
		array[mid] = item;
		size++;
		raiseForAdd(item);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public bool Update(T item)
	{
		T olditem;
		return Update(item, out olditem);
	}

	[ComVisible(true)]
	public bool Update(T item, out T olditem)
	{
		updatecheck();
		if (binarySearch(item, out var mid))
		{
			olditem = array[mid];
			array[mid] = item;
			raiseForUpdate(item, olditem);
			return true;
		}
		olditem = default(T);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public bool UpdateOrAdd(T item)
	{
		T olditem;
		return UpdateOrAdd(item, out olditem);
	}

	[ComVisible(true)]
	public bool UpdateOrAdd(T item, out T olditem)
	{
		updatecheck();
		if (binarySearch(item, out var mid))
		{
			olditem = array[mid];
			array[mid] = item;
			raiseForUpdate(item, olditem);
			return true;
		}
		if (size == array.Length)
		{
			expand();
		}
		Array.Copy(array, mid, array, mid + 1, size - mid);
		array[mid] = item;
		size++;
		olditem = default(T);
		raiseForAdd(item);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public bool Remove(T item)
	{
		updatecheck();
		if (binarySearch(item, out var mid))
		{
			T item2 = array[mid];
			Array.Copy(array, mid + 1, array, mid, size - mid - 1);
			array[--size] = default(T);
			raiseForRemove(item2);
			return true;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public bool Remove(T item, out T removeditem)
	{
		updatecheck();
		if (binarySearch(item, out var mid))
		{
			removeditem = array[mid];
			Array.Copy(array, mid + 1, array, mid, size - mid - 1);
			array[--size] = default(T);
			raiseForRemove(removeditem);
			return true;
		}
		removeditem = default(T);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		int[] array = new int[(size >> 5) + 1];
		int num = 0;
		foreach (U item2 in items)
		{
			T item = (T)(object)item2;
			if (binarySearch(item, out var mid))
			{
				array[mid >> 5] |= 1 << mid;
			}
		}
		for (int i = 0; i < size; i++)
		{
			if ((array[i >> 5] & (1 << i)) == 0)
			{
				base.array[num++] = base.array[i];
			}
			else if (mustFire)
			{
				raiseForRemoveAllHandler.Remove(base.array[i]);
			}
		}
		Array.Clear(base.array, num, size - num);
		size = num;
		if (mustFire)
		{
			raiseForRemoveAllHandler.Raise();
		}
	}

	[Tested]
	[ComVisible(true)]
	public void RetainAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		int[] array = new int[(size >> 5) + 1];
		int num = 0;
		foreach (U item2 in items)
		{
			T item = (T)(object)item2;
			if (binarySearch(item, out var mid))
			{
				array[mid >> 5] |= 1 << mid;
			}
		}
		for (int i = 0; i < size; i++)
		{
			if ((array[i >> 5] & (1 << i)) != 0)
			{
				base.array[num++] = base.array[i];
			}
			else if (mustFire)
			{
				raiseForRemoveAllHandler.Remove(base.array[i]);
			}
		}
		Array.Clear(base.array, num, size - num);
		size = num;
		if (mustFire)
		{
			raiseForRemoveAllHandler.Raise();
		}
	}

	[Tested]
	[ComVisible(true)]
	public bool ContainsAll<U>(IEnumerable<U> items) where U : T
	{
		foreach (U item2 in items)
		{
			T item = (T)(object)item2;
			if (!binarySearch(item, out var _))
			{
				return false;
			}
		}
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public int ContainsCount(T item)
	{
		if (!binarySearch(item, out var _))
		{
			return 0;
		}
		return 1;
	}

	[ComVisible(true)]
	public virtual ICollectionValue<T> UniqueItems()
	{
		return this;
	}

	[ComVisible(true)]
	public virtual ICollectionValue<KeyValuePair<T, int>> ItemMultiplicities()
	{
		return new MultiplicityOne<T>(this);
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveAllCopies(T item)
	{
		Remove(item);
	}

	[Tested]
	[ComVisible(true)]
	public override bool Check()
	{
		bool result = true;
		if (size > array.Length)
		{
			Console.WriteLine("Bad size ({0}) > array.Length ({1})", size, array.Length);
			return false;
		}
		for (int i = 0; i < size; i++)
		{
			if (array[i] == null)
			{
				Console.WriteLine("Bad element: null at index {0}", i);
				return false;
			}
			if (i > 0 && comparer.Compare(array[i], array[i - 1]) <= 0)
			{
				Console.WriteLine("Inversion at index {0}", i);
				result = false;
			}
		}
		return result;
	}

	[Tested]
	[ComVisible(true)]
	public bool Add(T item)
	{
		updatecheck();
		if (binarySearch(item, out var mid))
		{
			return false;
		}
		insert(mid, item);
		raiseForAdd(item);
		return true;
	}

	[Tested]
	void System.Collections.Generic.ICollection<T>.Add(T item)
	{
		Add(item);
	}

	[Tested]
	[ComVisible(true)]
	public void AddAll<U>(IEnumerable<U> items) where U : T
	{
		int num = EnumerableBase<U>.countItems(items);
		int num2;
		for (num2 = base.array.Length; num2 < size + num; num2 *= 2)
		{
		}
		T[] array = new T[num2];
		num = 0;
		foreach (U item in items)
		{
			T val = (T)(object)item;
			array[size + num++] = val;
		}
		Sorting.IntroSort(array, size, num, comparer);
		int num3 = 0;
		int num4 = 0;
		int numAdded = 0;
		T x = default(T);
		T[] array2 = new T[num];
		int i = size;
		for (int num5 = size + num; i < num5; i++)
		{
			while (num4 < size && comparer.Compare(base.array[num4], array[i]) <= 0)
			{
				x = (array[num3++] = base.array[num4++]);
			}
			if (num3 == 0 || comparer.Compare(x, array[i]) < 0)
			{
				x = (array2[numAdded++] = (array[num3++] = array[i]));
			}
		}
		while (num4 < size)
		{
			array[num3++] = base.array[num4++];
		}
		Array.Clear(array, num3, size + num - num3);
		size = num3;
		base.array = array;
		raiseForAddAll(array2, numAdded);
	}

	private void raiseForAddAll(T[] addedItems, int numAdded)
	{
		if ((ActiveEvents & EventTypeEnum.Added) != 0)
		{
			for (int i = 0; i < numAdded; i++)
			{
				raiseItemsAdded(addedItems[i], 1);
			}
		}
		if (numAdded > 0)
		{
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public T FindMin()
	{
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		return array[0];
	}

	[Tested]
	[ComVisible(true)]
	public T DeleteMin()
	{
		updatecheck();
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		T val = array[0];
		size--;
		Array.Copy(array, 1, array, 0, size);
		array[size] = default(T);
		raiseForRemove(val);
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public T FindMax()
	{
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		return array[size - 1];
	}

	[Tested]
	[ComVisible(true)]
	public T DeleteMax()
	{
		updatecheck();
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		T val = array[size - 1];
		size--;
		array[size] = default(T);
		raiseForRemove(val);
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public int IndexOf(T item)
	{
		return indexOf(item);
	}

	[Tested]
	[ComVisible(true)]
	public int LastIndexOf(T item)
	{
		return indexOf(item);
	}

	[Tested]
	[ComVisible(true)]
	public T RemoveAt(int i)
	{
		if (i < 0 || i >= size)
		{
			throw new IndexOutOfRangeException("Index out of range for sequenced collectionvalue");
		}
		updatecheck();
		T val = array[i];
		size--;
		Array.Copy(array, i + 1, array, i, size - i);
		array[size] = default(T);
		raiseForRemoveAt(i, val);
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveInterval(int start, int count)
	{
		updatecheck();
		checkRange(start, count);
		Array.Copy(array, start + count, array, start, size - start - count);
		size -= count;
		Array.Clear(array, size, count);
		raiseForRemoveInterval(start, count);
	}

	private void raiseForRemoveInterval(int start, int count)
	{
		if (ActiveEvents != 0 && count > 0)
		{
			raiseCollectionCleared(size == 0, count);
			raiseCollectionChanged();
		}
	}

	[Tested]
	IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
	{
		return Backwards();
	}

	[ComVisible(true)]
	public virtual object Clone()
	{
		SortedArray<T> sortedArray = new SortedArray<T>(size, comparer, itemequalityComparer);
		sortedArray.AddSorted(this);
		return sortedArray;
	}
}
