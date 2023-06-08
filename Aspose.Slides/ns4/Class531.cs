using System;
using System.Collections;
using System.Collections.Generic;

namespace ns4;

internal class Class531<T> : ICollection, IEnumerable, IEnumerable<T>
{
	private List<T> list_0 = new List<T>();

	public int Count => list_0.Count;

	public T this[int index] => list_0[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal Class531()
	{
	}

	internal void Add(T item)
	{
		list_0.Add(item);
	}

	internal void Insert(int index, T item)
	{
		list_0.Insert(index, item);
	}

	internal void Remove(T item)
	{
		list_0.Remove(item);
	}

	internal void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	internal void Clear()
	{
		list_0.Clear();
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}
}
