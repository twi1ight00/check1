using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class HashBag<T> : CollectionBase<T>, ICollection<T>, IExtensible<T>, ICollectionValue<T>, IShowable, IFormattable, ICloneable, System.Collections.Generic.ICollection<T>, IEnumerable<T>, IEnumerable
{
	private HashSet<KeyValuePair<T, int>> dict;

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
			return true;
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
	public HashBag()
		: this(EqualityComparer<T>.Default)
	{
	}

	[ComVisible(true)]
	public HashBag(IEqualityComparer<T> itemequalityComparer)
		: base(itemequalityComparer)
	{
		dict = new HashSet<KeyValuePair<T, int>>(new KeyValuePairEqualityComparer<T, int>(itemequalityComparer));
	}

	[ComVisible(true)]
	public HashBag(int capacity, IEqualityComparer<T> itemequalityComparer)
		: base(itemequalityComparer)
	{
		dict = new HashSet<KeyValuePair<T, int>>(capacity, new KeyValuePairEqualityComparer<T, int>(itemequalityComparer));
	}

	[ComVisible(true)]
	public HashBag(int capacity, double fill, IEqualityComparer<T> itemequalityComparer)
		: base(itemequalityComparer)
	{
		dict = new HashSet<KeyValuePair<T, int>>(capacity, fill, new KeyValuePairEqualityComparer<T, int>(itemequalityComparer));
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Contains(T item)
	{
		return dict.Contains(new KeyValuePair<T, int>(item, 0));
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Find(ref T item)
	{
		KeyValuePair<T, int> item2 = new KeyValuePair<T, int>(item, 0);
		if (dict.Find(ref item2))
		{
			item = item2.Key;
			return true;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Update(T item)
	{
		T olditem = default(T);
		return Update(item, out olditem);
	}

	[ComVisible(true)]
	public virtual bool Update(T item, out T olditem)
	{
		KeyValuePair<T, int> item2 = new KeyValuePair<T, int>(item, 0);
		updatecheck();
		if (dict.Find(ref item2))
		{
			olditem = item2.Key;
			item2.Key = item;
			dict.Update(item2);
			if (ActiveEvents != 0)
			{
				raiseForUpdate(item, olditem, item2.Value);
			}
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
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Remove(T item)
	{
		KeyValuePair<T, int> item2 = new KeyValuePair<T, int>(item, 0);
		updatecheck();
		if (dict.Find(ref item2))
		{
			size--;
			if (item2.Value == 1)
			{
				dict.Remove(item2);
			}
			else
			{
				item2.Value--;
				dict.Update(item2);
			}
			if (ActiveEvents != 0)
			{
				raiseForRemove(item2.Key);
			}
			return true;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Remove(T item, out T removeditem)
	{
		updatecheck();
		KeyValuePair<T, int> item2 = new KeyValuePair<T, int>(item, 0);
		if (dict.Find(ref item2))
		{
			removeditem = item2.Key;
			size--;
			if (item2.Value == 1)
			{
				dict.Remove(item2);
			}
			else
			{
				item2.Value--;
				dict.Update(item2);
			}
			if (ActiveEvents != 0)
			{
				raiseForRemove(removeditem);
			}
			return true;
		}
		removeditem = default(T);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RemoveAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		bool flag = (ActiveEvents & (EventTypeEnum.Changed | EventTypeEnum.Removed)) != 0;
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = (flag ? new RaiseForRemoveAllHandler(this) : null);
		foreach (U item2 in items)
		{
			KeyValuePair<T, int> item = new KeyValuePair<T, int>((T)(object)item2, 0);
			if (dict.Find(ref item))
			{
				size--;
				if (item.Value == 1)
				{
					dict.Remove(item);
				}
				else
				{
					item.Value--;
					dict.Update(item);
				}
				if (flag)
				{
					raiseForRemoveAllHandler.Remove(item.Key);
				}
			}
		}
		if (flag)
		{
			raiseForRemoveAllHandler.Raise();
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Clear()
	{
		updatecheck();
		if (size != 0)
		{
			dict.Clear();
			int count = size;
			size = 0;
			if ((ActiveEvents & EventTypeEnum.Cleared) != 0)
			{
				raiseCollectionCleared(full: true, count);
			}
			if ((ActiveEvents & EventTypeEnum.Changed) != 0)
			{
				raiseCollectionChanged();
			}
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RetainAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		foreach (U item3 in items)
		{
			KeyValuePair<T, int> item = new KeyValuePair<T, int>((T)(object)item3);
			if (!dict.Find(ref item))
			{
				continue;
			}
			KeyValuePair<T, int> item2 = item;
			if (hashBag.dict.Find(ref item2))
			{
				if (item2.Value < item.Value)
				{
					item2.Value++;
					hashBag.dict.Update(item2);
					hashBag.size++;
				}
			}
			else
			{
				item2.Value = 1;
				hashBag.dict.Add(item2);
				hashBag.size++;
			}
		}
		if (size == hashBag.size)
		{
			return;
		}
		CircularQueue<T> circularQueue = null;
		if ((ActiveEvents & EventTypeEnum.Removed) != 0)
		{
			circularQueue = new CircularQueue<T>();
			foreach (KeyValuePair<T, int> item4 in dict)
			{
				int num = item4.Value - hashBag.ContainsCount(item4.Key);
				if (num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						circularQueue.Enqueue(item4.Key);
					}
				}
			}
		}
		dict = hashBag.dict;
		size = hashBag.size;
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
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		foreach (U item2 in items)
		{
			T item = (T)(object)item2;
			if (hashBag.ContainsCount(item) < ContainsCount(item))
			{
				hashBag.Add(item);
				continue;
			}
			return false;
		}
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public override T[] ToArray()
	{
		T[] array = new T[size];
		int num = 0;
		foreach (KeyValuePair<T, int> item in dict)
		{
			for (int i = 0; i < item.Value; i++)
			{
				array[num++] = item.Key;
			}
		}
		return array;
	}

	[Tested]
	[ComVisible(true)]
	public virtual int ContainsCount(T item)
	{
		KeyValuePair<T, int> item2 = new KeyValuePair<T, int>(item, 0);
		if (dict.Find(ref item2))
		{
			return item2.Value;
		}
		return 0;
	}

	[ComVisible(true)]
	public virtual ICollectionValue<T> UniqueItems()
	{
		return new DropMultiplicity<T>(dict);
	}

	[ComVisible(true)]
	public virtual ICollectionValue<KeyValuePair<T, int>> ItemMultiplicities()
	{
		return new GuardedCollectionValue<KeyValuePair<T, int>>(dict);
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RemoveAllCopies(T item)
	{
		updatecheck();
		KeyValuePair<T, int> item2 = new KeyValuePair<T, int>(item, 0);
		if (dict.Find(ref item2))
		{
			size -= item2.Value;
			dict.Remove(item2);
			if ((ActiveEvents & EventTypeEnum.Removed) != 0)
			{
				raiseItemsRemoved(item2.Key, item2.Value);
			}
			if ((ActiveEvents & EventTypeEnum.Changed) != 0)
			{
				raiseCollectionChanged();
			}
		}
	}

	[Tested]
	[ComVisible(true)]
	public override void CopyTo(T[] array, int index)
	{
		if (index < 0 || index + Count > array.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		foreach (KeyValuePair<T, int> item in dict)
		{
			for (int i = 0; i < item.Value; i++)
			{
				array[index++] = item.Key;
			}
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Add(T item)
	{
		updatecheck();
		add(ref item);
		if (ActiveEvents != 0)
		{
			raiseForAdd(item);
		}
		return true;
	}

	[Tested]
	void System.Collections.Generic.ICollection<T>.Add(T item)
	{
		Add(item);
	}

	private void add(ref T item)
	{
		KeyValuePair<T, int> item2 = new KeyValuePair<T, int>(item, 1);
		if (dict.Find(ref item2))
		{
			item2.Value++;
			dict.Update(item2);
			item = item2.Key;
		}
		else
		{
			dict.Add(item2);
		}
		size++;
	}

	[ComVisible(true)]
	public virtual void AddAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		bool flag = (ActiveEvents & EventTypeEnum.Added) != 0;
		CircularQueue<T> circularQueue = (flag ? new CircularQueue<T>() : null);
		bool flag2 = false;
		foreach (U item2 in items)
		{
			T val = (T)(object)item2;
			T item = val;
			add(ref item);
			flag2 = true;
			if (flag)
			{
				circularQueue.Enqueue(item);
			}
		}
		if (!flag2)
		{
			return;
		}
		if (flag)
		{
			foreach (T item3 in circularQueue)
			{
				raiseItemsAdded(item3, 1);
			}
		}
		if ((ActiveEvents & EventTypeEnum.Changed) != 0)
		{
			raiseCollectionChanged();
		}
	}

	[ComVisible(true)]
	public override T Choose()
	{
		return dict.Choose().Key;
	}

	[Tested]
	[ComVisible(true)]
	public override IEnumerator<T> GetEnumerator()
	{
		int mystamp = stamp;
		foreach (KeyValuePair<T, int> p in dict)
		{
			int left = p.Value;
			while (left > 0)
			{
				if (mystamp != stamp)
				{
					throw new CollectionModifiedException();
				}
				left--;
				yield return p.Key;
			}
		}
	}

	[ComVisible(true)]
	public virtual object Clone()
	{
		HashBag<T> hashBag = new HashBag<T>((dict.Count <= 0) ? 1 : dict.Count, itemequalityComparer);
		hashBag.AddAll(this);
		return hashBag;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Check()
	{
		bool result = dict.Check();
		int num = 0;
		foreach (KeyValuePair<T, int> item in dict)
		{
			num += item.Value;
		}
		if (num != size)
		{
			Console.WriteLine("count({0}) != size({1})", num, size);
			result = false;
		}
		return result;
	}
}
