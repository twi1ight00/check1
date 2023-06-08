using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal abstract class ArrayBase<T> : SequencedBase<T>
{
	protected class Range : DirectedCollectionValueBase<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
	{
		private int start;

		private int count;

		private int delta;

		private int stamp;

		private ArrayBase<T> thebase;

		[ComVisible(true)]
		public override bool IsEmpty
		{
			[ComVisible(true)]
			get
			{
				thebase.modifycheck(stamp);
				return count == 0;
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
				thebase.modifycheck(stamp);
				return count;
			}
		}

		[ComVisible(true)]
		public override Speed CountSpeed
		{
			[ComVisible(true)]
			get
			{
				thebase.modifycheck(stamp);
				return Speed.Constant;
			}
		}

		[Tested]
		[ComVisible(true)]
		public override EnumerationDirection Direction
		{
			[Tested]
			[ComVisible(true)]
			get
			{
				thebase.modifycheck(stamp);
				if (delta <= 0)
				{
					return EnumerationDirection.Backwards;
				}
				return EnumerationDirection.Forwards;
			}
		}

		internal Range(ArrayBase<T> thebase, int start, int count, bool forwards)
		{
			this.thebase = thebase;
			stamp = thebase.stamp;
			delta = (forwards ? 1 : (-1));
			this.start = start + thebase.offset;
			this.count = count;
		}

		[ComVisible(true)]
		public override T Choose()
		{
			thebase.modifycheck(stamp);
			if (count == 0)
			{
				throw new NoSuchItemException();
			}
			return thebase.array[start];
		}

		[Tested]
		[ComVisible(true)]
		public override IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < count; i++)
			{
				thebase.modifycheck(stamp);
				yield return thebase.array[start + delta * i];
			}
		}

		[Tested]
		[ComVisible(true)]
		public override IDirectedCollectionValue<T> Backwards()
		{
			thebase.modifycheck(stamp);
			Range range = (Range)MemberwiseClone();
			range.delta = -delta;
			range.start = start + (count - 1) * delta;
			return range;
		}

		IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
		{
			return Backwards();
		}
	}

	protected T[] array;

	protected int offset;

	[Tested]
	[ComVisible(true)]
	public virtual IDirectedCollectionValue<T> this[int start, int count]
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			checkRange(start, count);
			return new Range(this, start, count, forwards: true);
		}
	}

	protected virtual void expand()
	{
		expand(2 * array.Length, size);
	}

	protected virtual void expand(int newcapacity, int newsize)
	{
		int num;
		for (num = array.Length; num < newcapacity; num *= 2)
		{
		}
		T[] destinationArray = new T[num];
		Array.Copy(array, destinationArray, newsize);
		array = destinationArray;
	}

	protected virtual void insert(int i, T item)
	{
		if (size == array.Length)
		{
			expand();
		}
		if (i < size)
		{
			Array.Copy(array, i, array, i + 1, size - i);
		}
		array[i] = item;
		size++;
	}

	protected ArrayBase(int capacity, IEqualityComparer<T> itemequalityComparer)
		: base(itemequalityComparer)
	{
		int num;
		for (num = 8; num < capacity; num *= 2)
		{
		}
		array = new T[num];
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Clear()
	{
		updatecheck();
		array = new T[8];
		size = 0;
	}

	[Tested]
	[ComVisible(true)]
	public override T[] ToArray()
	{
		T[] array = new T[size];
		Array.Copy(this.array, offset, array, 0, size);
		return array;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Check()
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
		}
		return result;
	}

	[Tested]
	[ComVisible(true)]
	public override IDirectedCollectionValue<T> Backwards()
	{
		return this[0, size].Backwards();
	}

	[ComVisible(true)]
	public override T Choose()
	{
		if (size > 0)
		{
			return array[size - 1];
		}
		throw new NoSuchItemException();
	}

	[Tested]
	[ComVisible(true)]
	public override IEnumerator<T> GetEnumerator()
	{
		int thestamp = stamp;
		int theend = size + offset;
		int thestart = offset;
		for (int i = thestart; i < theend; i++)
		{
			modifycheck(thestamp);
			yield return array[i];
		}
	}
}
