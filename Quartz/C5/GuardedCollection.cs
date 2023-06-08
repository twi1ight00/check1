using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedCollection<T> : GuardedCollectionValue<T>, ICollection<T>, IExtensible<T>, ICollectionValue<T>, IShowable, IFormattable, ICloneable, System.Collections.Generic.ICollection<T>, IEnumerable<T>, IEnumerable
{
	private ICollection<T> collection;

	[ComVisible(true)]
	public virtual bool IsReadOnly
	{
		[ComVisible(true)]
		get
		{
			return true;
		}
	}

	[ComVisible(true)]
	public virtual Speed ContainsSpeed
	{
		[ComVisible(true)]
		get
		{
			return collection.ContainsSpeed;
		}
	}

	[ComVisible(true)]
	public virtual bool AllowsDuplicates
	{
		[ComVisible(true)]
		get
		{
			return collection.AllowsDuplicates;
		}
	}

	[ComVisible(true)]
	public virtual IEqualityComparer<T> EqualityComparer
	{
		[ComVisible(true)]
		get
		{
			return collection.EqualityComparer;
		}
	}

	[ComVisible(true)]
	public virtual bool DuplicatesByCounting
	{
		[ComVisible(true)]
		get
		{
			return collection.DuplicatesByCounting;
		}
	}

	[ComVisible(true)]
	public override bool IsEmpty
	{
		[ComVisible(true)]
		get
		{
			return collection.IsEmpty;
		}
	}

	[ComVisible(true)]
	public GuardedCollection(ICollection<T> collection)
		: base((ICollectionValue<T>)collection)
	{
		this.collection = collection;
	}

	[ComVisible(true)]
	public virtual int GetUnsequencedHashCode()
	{
		return collection.GetUnsequencedHashCode();
	}

	[ComVisible(true)]
	public virtual bool UnsequencedEquals(ICollection<T> that)
	{
		return collection.UnsequencedEquals(that);
	}

	[ComVisible(true)]
	public virtual bool Contains(T item)
	{
		return collection.Contains(item);
	}

	[ComVisible(true)]
	public virtual int ContainsCount(T item)
	{
		return collection.ContainsCount(item);
	}

	[ComVisible(true)]
	public virtual ICollectionValue<T> UniqueItems()
	{
		return new GuardedCollectionValue<T>(collection.UniqueItems());
	}

	[ComVisible(true)]
	public virtual ICollectionValue<KeyValuePair<T, int>> ItemMultiplicities()
	{
		return new GuardedCollectionValue<KeyValuePair<T, int>>(collection.ItemMultiplicities());
	}

	[ComVisible(true)]
	public virtual bool ContainsAll<U>(IEnumerable<U> items) where U : T
	{
		return collection.ContainsAll(items);
	}

	[ComVisible(true)]
	public virtual bool Find(ref T item)
	{
		return collection.Find(ref item);
	}

	[ComVisible(true)]
	public virtual bool FindOrAdd(ref T item)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public virtual bool Update(T item)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public virtual bool Update(T item, out T olditem)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public virtual bool UpdateOrAdd(T item)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public virtual bool UpdateOrAdd(T item, out T olditem)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public virtual bool Remove(T item)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public virtual bool Remove(T item, out T removeditem)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public virtual void RemoveAllCopies(T item)
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public virtual void RemoveAll<U>(IEnumerable<U> items) where U : T
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public virtual void Clear()
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public virtual void RetainAll<U>(IEnumerable<U> items) where U : T
	{
		throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
	}

	[ComVisible(true)]
	public virtual bool Check()
	{
		return collection.Check();
	}

	[ComVisible(true)]
	public virtual bool Add(T item)
	{
		throw new ReadOnlyCollectionException();
	}

	void System.Collections.Generic.ICollection<T>.Add(T item)
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public virtual void AddAll<U>(IEnumerable<U> items) where U : T
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public virtual object Clone()
	{
		return new GuardedCollection<T>((ICollection<T>)collection.Clone());
	}
}
