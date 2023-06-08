using System;
using System.Collections;
using System.Collections.Generic;

namespace ns48;

internal class Class1127<T> : ICollection, IEnumerable, IList, IEnumerable<T>, IList<T>, ICollection<T>
{
	private readonly List<T> list_0;

	public int Count => list_0.Count;

	public bool IsFixedSize => true;

	public bool IsReadOnly => true;

	public bool IsSynchronized
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public object SyncRoot
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public T this[int index]
	{
		get
		{
			return list_0[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	object IList.this[int index]
	{
		get
		{
			return list_0[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public Class1127(List<T> sourceList)
	{
		if (sourceList == null)
		{
			throw new ArgumentNullException();
		}
		list_0 = sourceList;
	}

	public void Add(T item)
	{
		throw new NotSupportedException();
	}

	public int Add(object value)
	{
		throw new NotSupportedException();
	}

	public void Clear()
	{
		throw new NotSupportedException();
	}

	public bool Contains(object value)
	{
		if (value is T)
		{
			return list_0.Contains((T)value);
		}
		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		list_0.CopyTo(array, arrayIndex);
	}

	public void CopyTo(Array array, int index)
	{
		throw new NotSupportedException();
	}

	public bool Contains(T item)
	{
		return list_0.Contains(item);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public int IndexOf(T item)
	{
		return list_0.IndexOf(item);
	}

	public int IndexOf(object value)
	{
		if (!(value is T))
		{
			return -1;
		}
		return list_0.IndexOf((T)value);
	}

	public void Insert(int index, T item)
	{
		throw new NotSupportedException();
	}

	public void Insert(int index, object value)
	{
		throw new NotSupportedException();
	}

	public bool Remove(T item)
	{
		throw new NotSupportedException();
	}

	public void Remove(object value)
	{
		throw new NotSupportedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotSupportedException();
	}
}
