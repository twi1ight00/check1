using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class IntervalHeap<T> : CollectionValueBase<T>, IPriorityQueue<T>, IExtensible<T>, ICollectionValue<T>, IEnumerable<T>, IEnumerable, IShowable, IFormattable, ICloneable
{
	[Serializable]
	private struct Interval
	{
		internal T first;

		internal T last;

		internal Handle firsthandle;

		internal Handle lasthandle;

		[ComVisible(true)]
		public override string ToString()
		{
			return $"[{first}; {last}]";
		}
	}

	[Serializable]
	private class Handle : IPriorityQueueHandle<T>
	{
		internal int index = -1;

		[ComVisible(true)]
		public override string ToString()
		{
			return $"[{index}]";
		}

		[ComVisible(true)]
		public Handle()
		{
		}
	}

	private int stamp;

	private IComparer<T> comparer;

	private IEqualityComparer<T> itemequalityComparer;

	private Interval[] heap;

	private int size;

	[ComVisible(true)]
	public override EventTypeEnum ListenableEvents
	{
		[ComVisible(true)]
		get
		{
			return EventTypeEnum.Basic;
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

	[ComVisible(true)]
	public bool IsReadOnly
	{
		[ComVisible(true)]
		get
		{
			return false;
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
			return true;
		}
	}

	[ComVisible(true)]
	public virtual IEqualityComparer<T> EqualityComparer
	{
		[ComVisible(true)]
		get
		{
			return itemequalityComparer;
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
	public override bool IsEmpty
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return size == 0;
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
			return size;
		}
	}

	[ComVisible(true)]
	public override Speed CountSpeed
	{
		[ComVisible(true)]
		get
		{
			return Speed.Constant;
		}
	}

	[Tested]
	[ComVisible(true)]
	public T this[IPriorityQueueHandle<T> handle]
	{
		[ComVisible(true)]
		get
		{
			checkHandle(handle, out var cell, out var isfirst);
			if (!isfirst)
			{
				return heap[cell].last;
			}
			return heap[cell].first;
		}
		[ComVisible(true)]
		set
		{
			Replace(handle, value);
		}
	}

	private bool heapifyMin(int i)
	{
		bool flag = false;
		int num = i;
		int num2 = num;
		T val = heap[num].first;
		Handle handle = heap[num].firsthandle;
		if (i > 0)
		{
			T last = heap[num].last;
			if (2 * num + 1 < size && comparer.Compare(val, last) > 0)
			{
				flag = true;
				Handle lasthandle = heap[num].lasthandle;
				updateLast(num, val, handle);
				val = last;
				handle = lasthandle;
			}
		}
		T val2 = val;
		Handle handle2 = handle;
		while (true)
		{
			int num3 = 2 * num + 1;
			int num4 = num3 + 1;
			T first;
			if (2 * num3 < size && comparer.Compare(first = heap[num3].first, val2) < 0)
			{
				num2 = num3;
				val2 = first;
			}
			T first2;
			if (2 * num4 < size && comparer.Compare(first2 = heap[num4].first, val2) < 0)
			{
				num2 = num4;
				val2 = first2;
			}
			if (num2 == num)
			{
				break;
			}
			handle2 = heap[num2].firsthandle;
			updateFirst(num, val2, handle2);
			num = num2;
			T last2 = heap[num].last;
			if (2 * num2 + 1 < size && comparer.Compare(val, last2) > 0)
			{
				Handle lasthandle2 = heap[num].lasthandle;
				updateLast(num, val, handle);
				val = last2;
				handle = lasthandle2;
			}
			val2 = val;
			handle2 = handle;
		}
		if (num != i || flag)
		{
			updateFirst(num, val2, handle2);
		}
		return flag;
	}

	private bool heapifyMax(int i)
	{
		bool flag = false;
		int num = i;
		int num2 = num;
		T val = heap[num].last;
		Handle handle = heap[num].lasthandle;
		if (i > 0)
		{
			T first = heap[num].first;
			if (comparer.Compare(val, first) < 0)
			{
				flag = true;
				Handle firsthandle = heap[num].firsthandle;
				updateFirst(num, val, handle);
				val = first;
				handle = firsthandle;
			}
		}
		T val2 = val;
		Handle handle2 = handle;
		while (true)
		{
			int num3 = 2 * num + 1;
			int num4 = num3 + 1;
			T last;
			if (2 * num3 + 1 < size && comparer.Compare(last = heap[num3].last, val2) > 0)
			{
				num2 = num3;
				val2 = last;
			}
			T last2;
			if (2 * num4 + 1 < size && comparer.Compare(last2 = heap[num4].last, val2) > 0)
			{
				num2 = num4;
				val2 = last2;
			}
			if (num2 == num)
			{
				break;
			}
			handle2 = heap[num2].lasthandle;
			updateLast(num, val2, handle2);
			num = num2;
			T first2 = heap[num].first;
			if (comparer.Compare(val, first2) < 0)
			{
				Handle firsthandle2 = heap[num].firsthandle;
				updateFirst(num, val, handle);
				val = first2;
				handle = firsthandle2;
			}
			val2 = val;
			handle2 = handle;
		}
		if (num != i || flag)
		{
			updateLast(num, val2, handle2);
		}
		return flag;
	}

	private void bubbleUpMin(int i)
	{
		if (i > 0)
		{
			T first = heap[i].first;
			T val = first;
			Handle firsthandle = heap[i].firsthandle;
			int num = (i + 1) / 2 - 1;
			while (i > 0 && comparer.Compare(val, first = heap[num = (i + 1) / 2 - 1].first) < 0)
			{
				updateFirst(i, first, heap[num].firsthandle);
				first = val;
				i = num;
			}
			updateFirst(i, val, firsthandle);
		}
	}

	private void bubbleUpMax(int i)
	{
		if (i > 0)
		{
			T last = heap[i].last;
			T val = last;
			Handle lasthandle = heap[i].lasthandle;
			int num = (i + 1) / 2 - 1;
			while (i > 0 && comparer.Compare(val, last = heap[num = (i + 1) / 2 - 1].last) > 0)
			{
				updateLast(i, last, heap[num].lasthandle);
				last = val;
				i = num;
			}
			updateLast(i, val, lasthandle);
		}
	}

	[ComVisible(true)]
	public IntervalHeap()
		: this(16)
	{
	}

	[ComVisible(true)]
	public IntervalHeap(IComparer<T> comparer)
		: this(16, comparer)
	{
	}

	[ComVisible(true)]
	public IntervalHeap(int capacity)
		: this(capacity, Comparer<T>.Default, EqualityComparer<T>.Default)
	{
	}

	[ComVisible(true)]
	public IntervalHeap(int capacity, IComparer<T> comparer)
		: this(capacity, comparer, (IEqualityComparer<T>)new ComparerZeroHashCodeEqualityComparer<T>(comparer))
	{
	}

	private IntervalHeap(int capacity, IComparer<T> comparer, IEqualityComparer<T> itemequalityComparer)
	{
		if (comparer == null)
		{
			throw new NullReferenceException("Item comparer cannot be null");
		}
		if (itemequalityComparer == null)
		{
			throw new NullReferenceException("Item equality comparer cannot be null");
		}
		this.comparer = comparer;
		this.itemequalityComparer = itemequalityComparer;
		int num;
		for (num = 1; num < capacity; num <<= 1)
		{
		}
		heap = new Interval[num];
	}

	[Tested]
	[ComVisible(true)]
	public T FindMin()
	{
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		return heap[0].first;
	}

	[Tested]
	[ComVisible(true)]
	public T DeleteMin()
	{
		IPriorityQueueHandle<T> handle = null;
		return DeleteMin(out handle);
	}

	[Tested]
	[ComVisible(true)]
	public T FindMax()
	{
		if (size == 0)
		{
			throw new NoSuchItemException("Heap is empty");
		}
		if (size == 1)
		{
			return heap[0].first;
		}
		return heap[0].last;
	}

	[Tested]
	[ComVisible(true)]
	public T DeleteMax()
	{
		IPriorityQueueHandle<T> handle = null;
		return DeleteMax(out handle);
	}

	[Tested]
	[ComVisible(true)]
	public bool Add(T item)
	{
		stamp++;
		if (add(null, item))
		{
			raiseItemsAdded(item, 1);
			raiseCollectionChanged();
			return true;
		}
		return false;
	}

	private bool add(Handle itemhandle, T item)
	{
		if (size == 0)
		{
			size = 1;
			updateFirst(0, item, itemhandle);
			return true;
		}
		if (size == 2 * heap.Length)
		{
			Interval[] destinationArray = new Interval[2 * heap.Length];
			Array.Copy(heap, destinationArray, heap.Length);
			heap = destinationArray;
		}
		if (size % 2 == 0)
		{
			int num = size / 2;
			int num2 = (num + 1) / 2 - 1;
			T last = heap[num2].last;
			if (comparer.Compare(item, last) > 0)
			{
				updateFirst(num, last, heap[num2].lasthandle);
				updateLast(num2, item, itemhandle);
				bubbleUpMax(num2);
			}
			else
			{
				updateFirst(num, item, itemhandle);
				if (comparer.Compare(item, heap[num2].first) < 0)
				{
					bubbleUpMin(num);
				}
			}
		}
		else
		{
			int num3 = size / 2;
			T first = heap[num3].first;
			if (comparer.Compare(item, first) < 0)
			{
				updateLast(num3, first, heap[num3].firsthandle);
				updateFirst(num3, item, itemhandle);
				bubbleUpMin(num3);
			}
			else
			{
				updateLast(num3, item, itemhandle);
				bubbleUpMax(num3);
			}
		}
		size++;
		return true;
	}

	private void updateLast(int cell, T item, Handle handle)
	{
		heap[cell].last = item;
		if (handle != null)
		{
			handle.index = 2 * cell + 1;
		}
		heap[cell].lasthandle = handle;
	}

	private void updateFirst(int cell, T item, Handle handle)
	{
		heap[cell].first = item;
		if (handle != null)
		{
			handle.index = 2 * cell;
		}
		heap[cell].firsthandle = handle;
	}

	[Tested]
	[ComVisible(true)]
	public void AddAll<U>(IEnumerable<U> items) where U : T
	{
		stamp++;
		int num = size;
		foreach (U item3 in items)
		{
			T item = (T)(object)item3;
			add(null, item);
		}
		if (size == num)
		{
			return;
		}
		if ((ActiveEvents & EventTypeEnum.Added) != 0)
		{
			foreach (U item4 in items)
			{
				T item2 = (T)(object)item4;
				raiseItemsAdded(item2, 1);
			}
		}
		raiseCollectionChanged();
	}

	[ComVisible(true)]
	public override T Choose()
	{
		if (size == 0)
		{
			throw new NoSuchItemException("Collection is empty");
		}
		return heap[0].first;
	}

	[Tested]
	[ComVisible(true)]
	public override IEnumerator<T> GetEnumerator()
	{
		int mystamp = stamp;
		for (int i = 0; i < size; i++)
		{
			if (mystamp != stamp)
			{
				throw new CollectionModifiedException();
			}
			yield return (i % 2 == 0) ? heap[i >> 1].first : heap[i >> 1].last;
		}
	}

	private bool check(int i, T min, T max)
	{
		bool flag = true;
		Interval interval = heap[i];
		T first = interval.first;
		T last = interval.last;
		if (2 * i + 1 == size)
		{
			if (comparer.Compare(min, first) > 0)
			{
				Console.WriteLine("Cell {0}: parent.first({1}) > first({2})  [size={3}]", i, min, first, size);
				flag = false;
			}
			if (comparer.Compare(first, max) > 0)
			{
				Console.WriteLine("Cell {0}: first({1}) > parent.last({2})  [size={3}]", i, first, max, size);
				flag = false;
			}
			if (interval.firsthandle != null && interval.firsthandle.index != 2 * i)
			{
				Console.WriteLine("Cell {0}: firsthandle.index({1}) != 2*cell({2})  [size={3}]", i, interval.firsthandle.index, 2 * i, size);
				flag = false;
			}
			return flag;
		}
		if (comparer.Compare(min, first) > 0)
		{
			Console.WriteLine("Cell {0}: parent.first({1}) > first({2})  [size={3}]", i, min, first, size);
			flag = false;
		}
		if (comparer.Compare(first, last) > 0)
		{
			Console.WriteLine("Cell {0}: first({1}) > last({2})  [size={3}]", i, first, last, size);
			flag = false;
		}
		if (comparer.Compare(last, max) > 0)
		{
			Console.WriteLine("Cell {0}: last({1}) > parent.last({2})  [size={3}]", i, last, max, size);
			flag = false;
		}
		if (interval.firsthandle != null && interval.firsthandle.index != 2 * i)
		{
			Console.WriteLine("Cell {0}: firsthandle.index({1}) != 2*cell({2})  [size={3}]", i, interval.firsthandle.index, 2 * i, size);
			flag = false;
		}
		if (interval.lasthandle != null && interval.lasthandle.index != 2 * i + 1)
		{
			Console.WriteLine("Cell {0}: lasthandle.index({1}) != 2*cell+1({2})  [size={3}]", i, interval.lasthandle.index, 2 * i + 1, size);
			flag = false;
		}
		int num = 2 * i + 1;
		int num2 = num + 1;
		if (2 * num < size)
		{
			flag = flag && check(num, first, last);
		}
		if (2 * num2 < size)
		{
			flag = flag && check(num2, first, last);
		}
		return flag;
	}

	[Tested]
	[ComVisible(true)]
	public bool Check()
	{
		if (size == 0)
		{
			return true;
		}
		if (size == 1)
		{
			return heap[0].first != null;
		}
		return check(0, heap[0].first, heap[0].last);
	}

	[ComVisible(true)]
	public bool Find(IPriorityQueueHandle<T> handle, out T item)
	{
		if (!(handle is Handle handle2))
		{
			item = default(T);
			return false;
		}
		int index = handle2.index;
		int num = index / 2;
		bool flag = index % 2 == 0;
		if (index == -1 || index >= size)
		{
			item = default(T);
			return false;
		}
		Handle handle3 = (flag ? heap[num].firsthandle : heap[num].lasthandle);
		if (handle3 != handle2)
		{
			item = default(T);
			return false;
		}
		item = (flag ? heap[num].first : heap[num].last);
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public bool Add(ref IPriorityQueueHandle<T> handle, T item)
	{
		stamp++;
		Handle handle2 = (Handle)handle;
		if (handle2 == null)
		{
			handle2 = (Handle)(handle = new Handle());
		}
		else if (handle2.index != -1)
		{
			throw new InvalidPriorityQueueHandleException("Handle not valid for reuse");
		}
		if (add(handle2, item))
		{
			raiseItemsAdded(item, 1);
			raiseCollectionChanged();
			return true;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public T Delete(IPriorityQueueHandle<T> handle)
	{
		stamp++;
		int cell;
		bool isfirst;
		Handle handle2 = checkHandle(handle, out cell, out isfirst);
		handle2.index = -1;
		int num = (size - 1) / 2;
		T val;
		if (cell == num)
		{
			if (isfirst)
			{
				val = heap[cell].first;
				if (size % 2 == 0)
				{
					updateFirst(cell, heap[cell].last, heap[cell].lasthandle);
					heap[cell].last = default(T);
					heap[cell].lasthandle = null;
				}
				else
				{
					heap[cell].first = default(T);
					heap[cell].firsthandle = null;
				}
			}
			else
			{
				val = heap[cell].last;
				heap[cell].last = default(T);
				heap[cell].lasthandle = null;
			}
			size--;
		}
		else if (isfirst)
		{
			val = heap[cell].first;
			if (size % 2 == 0)
			{
				updateFirst(cell, heap[num].last, heap[num].lasthandle);
				heap[num].last = default(T);
				heap[num].lasthandle = null;
			}
			else
			{
				updateFirst(cell, heap[num].first, heap[num].firsthandle);
				heap[num].first = default(T);
				heap[num].firsthandle = null;
			}
			size--;
			if (heapifyMin(cell))
			{
				bubbleUpMax(cell);
			}
			else
			{
				bubbleUpMin(cell);
			}
		}
		else
		{
			val = heap[cell].last;
			if (size % 2 == 0)
			{
				updateLast(cell, heap[num].last, heap[num].lasthandle);
				heap[num].last = default(T);
				heap[num].lasthandle = null;
			}
			else
			{
				updateLast(cell, heap[num].first, heap[num].firsthandle);
				heap[num].first = default(T);
				heap[num].firsthandle = null;
			}
			size--;
			if (heapifyMax(cell))
			{
				bubbleUpMin(cell);
			}
			else
			{
				bubbleUpMax(cell);
			}
		}
		raiseItemsRemoved(val, 1);
		raiseCollectionChanged();
		return val;
	}

	private Handle checkHandle(IPriorityQueueHandle<T> handle, out int cell, out bool isfirst)
	{
		Handle handle2 = (Handle)handle;
		int index = handle2.index;
		cell = index / 2;
		isfirst = index % 2 == 0;
		if (index == -1 || index >= size)
		{
			throw new InvalidPriorityQueueHandleException("Invalid handle, index out of range");
		}
		Handle handle3 = (isfirst ? heap[cell].firsthandle : heap[cell].lasthandle);
		if (handle3 != handle2)
		{
			throw new InvalidPriorityQueueHandleException("Invalid handle, doesn't match queue");
		}
		return handle2;
	}

	[Tested]
	[ComVisible(true)]
	public T Replace(IPriorityQueueHandle<T> handle, T item)
	{
		stamp++;
		checkHandle(handle, out var cell, out var isfirst);
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		T val;
		if (isfirst)
		{
			val = heap[cell].first;
			heap[cell].first = item;
			if (size != 1)
			{
				if (size == 2 * cell + 1)
				{
					int num = (cell + 1) / 2 - 1;
					if (comparer.Compare(item, heap[num].last) > 0)
					{
						Handle firsthandle = heap[cell].firsthandle;
						updateFirst(cell, heap[num].last, heap[num].lasthandle);
						updateLast(num, item, firsthandle);
						bubbleUpMax(num);
					}
					else
					{
						bubbleUpMin(cell);
					}
				}
				else if (heapifyMin(cell))
				{
					bubbleUpMax(cell);
				}
				else
				{
					bubbleUpMin(cell);
				}
			}
		}
		else
		{
			val = heap[cell].last;
			heap[cell].last = item;
			if (heapifyMax(cell))
			{
				bubbleUpMin(cell);
			}
			else
			{
				bubbleUpMax(cell);
			}
		}
		raiseItemsRemoved(val, 1);
		raiseItemsAdded(item, 1);
		raiseCollectionChanged();
		return val;
	}

	[ComVisible(true)]
	public T FindMin(out IPriorityQueueHandle<T> handle)
	{
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		handle = heap[0].firsthandle;
		return heap[0].first;
	}

	[ComVisible(true)]
	public T FindMax(out IPriorityQueueHandle<T> handle)
	{
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		if (size == 1)
		{
			handle = heap[0].firsthandle;
			return heap[0].first;
		}
		handle = heap[0].lasthandle;
		return heap[0].last;
	}

	[ComVisible(true)]
	public T DeleteMin(out IPriorityQueueHandle<T> handle)
	{
		stamp++;
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		T first = heap[0].first;
		Handle handle2 = (Handle)(handle = heap[0].firsthandle);
		if (handle2 != null)
		{
			handle2.index = -1;
		}
		if (size == 1)
		{
			size = 0;
			heap[0].first = default(T);
			heap[0].firsthandle = null;
		}
		else
		{
			int num = (size - 1) / 2;
			if (size % 2 == 0)
			{
				updateFirst(0, heap[num].last, heap[num].lasthandle);
				heap[num].last = default(T);
				heap[num].lasthandle = null;
			}
			else
			{
				updateFirst(0, heap[num].first, heap[num].firsthandle);
				heap[num].first = default(T);
				heap[num].firsthandle = null;
			}
			size--;
			heapifyMin(0);
		}
		raiseItemsRemoved(first, 1);
		raiseCollectionChanged();
		return first;
	}

	[ComVisible(true)]
	public T DeleteMax(out IPriorityQueueHandle<T> handle)
	{
		stamp++;
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		T val;
		Handle handle2;
		if (size == 1)
		{
			size = 0;
			val = heap[0].first;
			handle2 = heap[0].firsthandle;
			if (handle2 != null)
			{
				handle2.index = -1;
			}
			heap[0].first = default(T);
			heap[0].firsthandle = null;
		}
		else
		{
			val = heap[0].last;
			handle2 = heap[0].lasthandle;
			if (handle2 != null)
			{
				handle2.index = -1;
			}
			int num = (size - 1) / 2;
			if (size % 2 == 0)
			{
				updateLast(0, heap[num].last, heap[num].lasthandle);
				heap[num].last = default(T);
				heap[num].lasthandle = null;
			}
			else
			{
				updateLast(0, heap[num].first, heap[num].firsthandle);
				heap[num].first = default(T);
				heap[num].firsthandle = null;
			}
			size--;
			heapifyMax(0);
		}
		raiseItemsRemoved(val, 1);
		raiseCollectionChanged();
		handle = handle2;
		return val;
	}

	[ComVisible(true)]
	public virtual object Clone()
	{
		IntervalHeap<T> intervalHeap = new IntervalHeap<T>(size, comparer, itemequalityComparer);
		intervalHeap.AddAll(this);
		return intervalHeap;
	}
}
