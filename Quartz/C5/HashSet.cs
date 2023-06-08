using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class HashSet<T> : CollectionBase<T>, ICollection<T>, IExtensible<T>, ICollectionValue<T>, IShowable, IFormattable, ICloneable, System.Collections.Generic.ICollection<T>, IEnumerable<T>, IEnumerable
{
	[Flags]
	[ComVisible(true)]
	public enum Feature : short
	{
		[ComVisible(true)]
		Dummy = 0,
		[ComVisible(true)]
		RefTypeBucket = 1,
		[ComVisible(true)]
		ValueTypeBucket = 2,
		[ComVisible(true)]
		LinearProbing = 4,
		[ComVisible(true)]
		ShrinkTable = 8,
		[ComVisible(true)]
		Chaining = 0x10,
		[ComVisible(true)]
		InterHashing = 0x20,
		[ComVisible(true)]
		RandomInterHashing = 0x40
	}

	[Serializable]
	private class Bucket
	{
		internal T item;

		internal int hashval;

		internal Bucket overflow;

		internal Bucket(T item, int hashval, Bucket overflow)
		{
			this.item = item;
			this.hashval = hashval;
			this.overflow = overflow;
		}
	}

	private static Feature features = Feature.RefTypeBucket | Feature.Chaining | Feature.RandomInterHashing;

	private int indexmask;

	private int bits;

	private int bitsc;

	private int origbits;

	private int lastchosen;

	private Bucket[] table;

	private double fillfactor = 0.66;

	private int resizethreshhold;

	private uint randomhashfactor = (uint)((2 * new Random().Next() + 1) * 1529784659);

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
	public virtual Speed ContainsSpeed
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return Speed.Constant;
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

	private bool equals(T i1, T i2)
	{
		return itemequalityComparer.Equals(i1, i2);
	}

	private int gethashcode(T item)
	{
		return itemequalityComparer.GetHashCode(item);
	}

	private int hv2i(int hashval)
	{
		return (int)((uint)(hashval * (int)randomhashfactor) >> bitsc);
	}

	private void expand()
	{
		resize(bits + 1);
	}

	private void shrink()
	{
		if (bits > 3)
		{
			resize(bits - 1);
		}
	}

	private void resize(int bits)
	{
		this.bits = bits;
		bitsc = 32 - bits;
		indexmask = (1 << bits) - 1;
		Bucket[] array = new Bucket[indexmask + 1];
		int i = 0;
		for (int num = table.Length; i < num; i++)
		{
			for (Bucket bucket = table[i]; bucket != null; bucket = bucket.overflow)
			{
				int num2 = hv2i(bucket.hashval);
				array[num2] = new Bucket(bucket.item, bucket.hashval, array[num2]);
			}
		}
		table = array;
		resizethreshhold = (int)((double)table.Length * fillfactor);
	}

	private bool searchoradd(ref T item, bool add, bool update, bool raise)
	{
		int hashval = gethashcode(item);
		int num = hv2i(hashval);
		Bucket bucket = table[num];
		Bucket bucket2 = null;
		if (bucket != null)
		{
			while (bucket != null)
			{
				T item2 = bucket.item;
				if (equals(item2, item))
				{
					if (update)
					{
						bucket.item = item;
					}
					if (raise && update)
					{
						raiseForUpdate(item, item2);
					}
					item = item2;
					return true;
				}
				bucket2 = bucket;
				bucket = bucket.overflow;
			}
			if (add)
			{
				bucket2.overflow = new Bucket(item, hashval, null);
				goto IL_00ca;
			}
		}
		else if (add)
		{
			table[num] = new Bucket(item, hashval, null);
			goto IL_00ca;
		}
		goto IL_00ef;
		IL_00ef:
		if (raise && add)
		{
			raiseForAdd(item);
		}
		if (update)
		{
			item = default(T);
		}
		return false;
		IL_00ca:
		size++;
		if (size > resizethreshhold)
		{
			expand();
		}
		goto IL_00ef;
	}

	private bool remove(ref T item)
	{
		if (size == 0)
		{
			return false;
		}
		int hashval = gethashcode(item);
		int num = hv2i(hashval);
		Bucket bucket = table[num];
		if (bucket == null)
		{
			return false;
		}
		if (equals(item, bucket.item))
		{
			item = bucket.item;
			table[num] = bucket.overflow;
		}
		else
		{
			Bucket bucket2 = bucket;
			bucket = bucket.overflow;
			while (bucket != null && !equals(item, bucket.item))
			{
				bucket2 = bucket;
				bucket = bucket.overflow;
			}
			if (bucket == null)
			{
				return false;
			}
			item = bucket.item;
			bucket2.overflow = bucket.overflow;
		}
		size--;
		return true;
	}

	private void clear()
	{
		bits = origbits;
		bitsc = 32 - bits;
		indexmask = (1 << bits) - 1;
		size = 0;
		table = new Bucket[indexmask + 1];
		resizethreshhold = (int)((double)table.Length * fillfactor);
	}

	[ComVisible(true)]
	public HashSet()
		: this(EqualityComparer<T>.Default)
	{
	}

	[ComVisible(true)]
	public HashSet(IEqualityComparer<T> itemequalityComparer)
		: this(16, itemequalityComparer)
	{
	}

	[ComVisible(true)]
	public HashSet(int capacity, IEqualityComparer<T> itemequalityComparer)
		: this(capacity, 0.66, itemequalityComparer)
	{
	}

	[ComVisible(true)]
	public HashSet(int capacity, double fill, IEqualityComparer<T> itemequalityComparer)
		: base(itemequalityComparer)
	{
		if (fill < 0.1 || fill > 0.9)
		{
			throw new ArgumentException("Fill outside valid range [0.1, 0.9]");
		}
		if (capacity <= 0)
		{
			throw new ArgumentException("Capacity must be non-negative");
		}
		origbits = 4;
		while (capacity - 1 >> origbits > 0)
		{
			origbits++;
		}
		clear();
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Contains(T item)
	{
		return searchoradd(ref item, add: false, update: false, raise: false);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Find(ref T item)
	{
		return searchoradd(ref item, add: false, update: false, raise: false);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Update(T item)
	{
		updatecheck();
		return searchoradd(ref item, add: false, update: true, raise: true);
	}

	[ComVisible(true)]
	public virtual bool Update(T item, out T olditem)
	{
		updatecheck();
		olditem = item;
		return searchoradd(ref olditem, add: false, update: true, raise: true);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool FindOrAdd(ref T item)
	{
		updatecheck();
		return searchoradd(ref item, add: true, update: false, raise: true);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool UpdateOrAdd(T item)
	{
		updatecheck();
		return searchoradd(ref item, add: true, update: true, raise: true);
	}

	[ComVisible(true)]
	public virtual bool UpdateOrAdd(T item, out T olditem)
	{
		updatecheck();
		olditem = item;
		return searchoradd(ref olditem, add: true, update: true, raise: true);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Remove(T item)
	{
		updatecheck();
		if (remove(ref item))
		{
			raiseForRemove(item);
			return true;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Remove(T item, out T removeditem)
	{
		updatecheck();
		removeditem = item;
		if (remove(ref removeditem))
		{
			raiseForRemove(removeditem);
			return true;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RemoveAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		foreach (U item2 in items)
		{
			T item = (T)(object)item2;
			if (remove(ref item) && mustFire)
			{
				raiseForRemoveAllHandler.Remove(item);
			}
		}
		if (mustFire)
		{
			raiseForRemoveAllHandler.Raise();
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Clear()
	{
		updatecheck();
		int num = size;
		clear();
		if (ActiveEvents != 0 && num > 0)
		{
			raiseCollectionCleared(full: true, num);
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RetainAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		HashSet<T> hashSet = new HashSet<T>(EqualityComparer);
		foreach (U item2 in items)
		{
			if (Contains((T)(object)item2))
			{
				T item = (T)(object)item2;
				hashSet.searchoradd(ref item, add: true, update: false, raise: false);
			}
		}
		if (size == hashSet.size)
		{
			return;
		}
		CircularQueue<T> circularQueue = null;
		if ((ActiveEvents & EventTypeEnum.Removed) != 0)
		{
			circularQueue = new CircularQueue<T>();
			using IEnumerator<T> enumerator2 = GetEnumerator();
			while (enumerator2.MoveNext())
			{
				T current2 = enumerator2.Current;
				if (!hashSet.Contains(current2))
				{
					circularQueue.Enqueue(current2);
				}
			}
		}
		table = hashSet.table;
		size = hashSet.size;
		indexmask = hashSet.indexmask;
		resizethreshhold = hashSet.resizethreshhold;
		bits = hashSet.bits;
		bitsc = hashSet.bitsc;
		randomhashfactor = hashSet.randomhashfactor;
		if ((ActiveEvents & EventTypeEnum.Removed) != 0)
		{
			raiseForRemoveAll(circularQueue);
		}
		else if ((ActiveEvents & EventTypeEnum.Changed) != 0)
		{
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool ContainsAll<U>(IEnumerable<U> items) where U : T
	{
		foreach (U item in items)
		{
			if (!Contains((T)(object)item))
			{
				return false;
			}
		}
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public override T[] ToArray()
	{
		T[] array = new T[size];
		int num = 0;
		for (int i = 0; i < table.Length; i++)
		{
			for (Bucket bucket = table[i]; bucket != null; bucket = bucket.overflow)
			{
				array[num++] = bucket.item;
			}
		}
		return array;
	}

	[Tested]
	[ComVisible(true)]
	public virtual int ContainsCount(T item)
	{
		if (!Contains(item))
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
	public virtual void RemoveAllCopies(T item)
	{
		Remove(item);
	}

	[Tested]
	[ComVisible(true)]
	public override T Choose()
	{
		int num = table.Length;
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		do
		{
			if (++lastchosen >= num)
			{
				lastchosen = 0;
			}
		}
		while (table[lastchosen] == null);
		return table[lastchosen].item;
	}

	[Tested]
	[ComVisible(true)]
	public override IEnumerator<T> GetEnumerator()
	{
		int index = -1;
		int mystamp = stamp;
		int len = table.Length;
		Bucket b = null;
		while (mystamp == stamp)
		{
			if (b == null || b.overflow == null)
			{
				do
				{
					int num;
					index = (num = index + 1);
					if (num >= len)
					{
						yield break;
					}
				}
				while (table[index] == null);
				b = table[index];
				yield return b.item;
			}
			else
			{
				b = b.overflow;
				yield return b.item;
			}
		}
		throw new CollectionModifiedException();
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Add(T item)
	{
		updatecheck();
		return !searchoradd(ref item, add: true, update: false, raise: true);
	}

	[Tested]
	void System.Collections.Generic.ICollection<T>.Add(T item)
	{
		Add(item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual void AddAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		bool flag = false;
		bool flag2 = (ActiveEvents & EventTypeEnum.Added) != 0;
		CircularQueue<T> circularQueue = (flag2 ? new CircularQueue<T>() : null);
		foreach (U item2 in items)
		{
			T val = (T)(object)item2;
			T item = val;
			if (!searchoradd(ref item, add: true, update: false, raise: false))
			{
				flag = true;
				if (flag2)
				{
					circularQueue.Enqueue(val);
				}
			}
		}
		if (flag2 && flag)
		{
			foreach (T item3 in circularQueue)
			{
				raiseItemsAdded(item3, 1);
			}
		}
		if ((ActiveEvents & EventTypeEnum.Changed) != 0 && flag)
		{
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Check()
	{
		int num = 0;
		bool result = true;
		if (bitsc != 32 - bits)
		{
			Console.WriteLine("bitsc != 32 - bits ({0}, {1})", bitsc, bits);
			result = false;
		}
		if (indexmask != (1 << bits) - 1)
		{
			Console.WriteLine("indexmask != (1 << bits) - 1 ({0}, {1})", indexmask, bits);
			result = false;
		}
		if (table.Length != indexmask + 1)
		{
			Console.WriteLine("table.Length != indexmask + 1 ({0}, {1})", table.Length, indexmask);
			result = false;
		}
		if (bitsc != 32 - bits)
		{
			Console.WriteLine("resizethreshhold != (int)(table.Length * fillfactor) ({0}, {1}, {2})", resizethreshhold, table.Length, fillfactor);
			result = false;
		}
		int i = 0;
		for (int num2 = table.Length; i < num2; i++)
		{
			int num3 = 0;
			for (Bucket bucket = table[i]; bucket != null; bucket = bucket.overflow)
			{
				if (i != hv2i(bucket.hashval))
				{
					Console.WriteLine("Bad cell item={0}, hashval={1}, index={2}, level={3}", bucket.item, bucket.hashval, i, num3);
					result = false;
				}
				num++;
				num3++;
			}
		}
		if (num != size)
		{
			Console.WriteLine("size({0}) != count({1})", size, num);
			result = false;
		}
		return result;
	}

	[Tested(via = "Manually")]
	[ComVisible(true)]
	public ISortedDictionary<int, int> BucketCostDistribution()
	{
		TreeDictionary<int, int> treeDictionary = new TreeDictionary<int, int>();
		int i = 0;
		for (int num = table.Length; i < num; i++)
		{
			int num2 = 0;
			for (Bucket bucket = table[i]; bucket != null; bucket = bucket.overflow)
			{
				num2++;
			}
			if (treeDictionary.Contains(num2))
			{
				treeDictionary[num2]++;
			}
			else
			{
				treeDictionary[num2] = 1;
			}
		}
		return treeDictionary;
	}

	[ComVisible(true)]
	public virtual object Clone()
	{
		HashSet<T> hashSet = new HashSet<T>((size <= 0) ? 1 : size, itemequalityComparer);
		hashSet.AddAll(this);
		return hashSet;
	}
}
