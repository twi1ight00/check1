using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class CircularQueue<T> : SequencedBase<T>, IQueue<T>, IStack<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	private int front;

	private int back;

	private T[] array;

	private bool forwards = true;

	private bool original = true;

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
	public virtual bool AllowsDuplicates
	{
		[ComVisible(true)]
		get
		{
			return true;
		}
	}

	[ComVisible(true)]
	public virtual T this[int i]
	{
		[ComVisible(true)]
		get
		{
			if (i < 0 || i >= size)
			{
				throw new IndexOutOfRangeException();
			}
			i += front;
			return array[(i >= array.Length) ? (i - array.Length) : i];
		}
	}

	private void expand()
	{
		int num = 2 * array.Length;
		T[] destinationArray = new T[num];
		if (front <= back)
		{
			Array.Copy(array, front, destinationArray, 0, size);
		}
		else
		{
			int num2 = array.Length - front;
			Array.Copy(array, front, destinationArray, 0, num2);
			Array.Copy(array, 0, destinationArray, num2, size - num2);
		}
		front = 0;
		back = size;
		array = destinationArray;
	}

	[ComVisible(true)]
	public CircularQueue()
		: this(8)
	{
	}

	[ComVisible(true)]
	public CircularQueue(int capacity)
		: base(EqualityComparer<T>.Default)
	{
		int num;
		for (num = 8; num < capacity; num *= 2)
		{
		}
		array = new T[num];
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Enqueue(T item)
	{
		if (!original)
		{
			throw new ReadOnlyCollectionException();
		}
		stamp++;
		if (size == array.Length - 1)
		{
			expand();
		}
		size++;
		int num = back++;
		if (back == array.Length)
		{
			back = 0;
		}
		array[num] = item;
		if (ActiveEvents != 0)
		{
			raiseForAdd(item);
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual T Dequeue()
	{
		if (!original)
		{
			throw new ReadOnlyCollectionException("Object is a non-updatable clone");
		}
		stamp++;
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		size--;
		int num = front++;
		if (front == array.Length)
		{
			front = 0;
		}
		T val = array[num];
		array[num] = default(T);
		if (ActiveEvents != 0)
		{
			raiseForRemove(val);
		}
		return val;
	}

	[ComVisible(true)]
	public void Push(T item)
	{
		if (!original)
		{
			throw new ReadOnlyCollectionException();
		}
		stamp++;
		if (size == array.Length - 1)
		{
			expand();
		}
		size++;
		int num = back++;
		if (back == array.Length)
		{
			back = 0;
		}
		array[num] = item;
		if (ActiveEvents != 0)
		{
			raiseForAdd(item);
		}
	}

	[ComVisible(true)]
	public T Pop()
	{
		if (!original)
		{
			throw new ReadOnlyCollectionException("Object is a non-updatable clone");
		}
		stamp++;
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		size--;
		back--;
		if (back == -1)
		{
			back = array.Length - 1;
		}
		T val = array[back];
		array[back] = default(T);
		if (ActiveEvents != 0)
		{
			raiseForRemove(val);
		}
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public override T Choose()
	{
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		return array[front];
	}

	[ComVisible(true)]
	public override IEnumerator<T> GetEnumerator()
	{
		int stamp = base.stamp;
		if (forwards)
		{
			int position = front;
			int end = ((front <= back) ? back : array.Length);
			while (position < end)
			{
				if (stamp != base.stamp)
				{
					throw new CollectionModifiedException();
				}
				yield return array[position++];
			}
			if (front <= back)
			{
				yield break;
			}
			position = 0;
			while (position < back)
			{
				if (stamp != base.stamp)
				{
					throw new CollectionModifiedException();
				}
				yield return array[position++];
			}
			yield break;
		}
		int position3 = back - 1;
		int end2 = ((front <= back) ? front : 0);
		while (position3 >= end2)
		{
			if (stamp != base.stamp)
			{
				throw new CollectionModifiedException();
			}
			yield return array[position3--];
		}
		if (front <= back)
		{
			yield break;
		}
		position3 = array.Length - 1;
		while (position3 >= front)
		{
			if (stamp != base.stamp)
			{
				throw new CollectionModifiedException();
			}
			yield return array[position3--];
		}
	}

	[ComVisible(true)]
	public override IDirectedCollectionValue<T> Backwards()
	{
		CircularQueue<T> circularQueue = (CircularQueue<T>)MemberwiseClone();
		circularQueue.original = false;
		circularQueue.forwards = !forwards;
		return circularQueue;
	}

	IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
	{
		return Backwards();
	}

	[ComVisible(true)]
	public virtual bool Check()
	{
		if (front < 0 || front >= array.Length || back < 0 || back >= array.Length || (front <= back && size != back - front) || (front > back && size != array.Length + back - front))
		{
			Console.WriteLine("Bad combination of (front,back,size,array.Length): ({0},{1},{2},{3})", front, back, size, array.Length);
			return false;
		}
		return true;
	}
}
