using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Quartz.Collection;

public class ReadOnlySet<T> : ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private readonly ISet<T> internalSet;

	public int Count => internalSet.Count;

	public bool IsReadOnly => true;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Collection.ReadOnlySet`1" /> class.
	/// </summary>
	/// <param name="internalSet">The internal set to wrap.</param>
	/// <exception cref="T:System.ArgumentNullException">internalSet</exception>
	public ReadOnlySet(ISet<T> internalSet)
	{
		if (internalSet == null)
		{
			throw new ArgumentNullException("internalSet");
		}
		this.internalSet = internalSet;
	}

	public void Add(T item)
	{
		throw new ReadOnlyException();
	}

	public void Clear()
	{
		throw new ReadOnlyException();
	}

	public bool Contains(T item)
	{
		return internalSet.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		internalSet.CopyTo(array, arrayIndex);
	}

	public bool Remove(T item)
	{
		throw new ReadOnlyException();
	}

	public IEnumerator<T> GetEnumerator()
	{
		return internalSet.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return internalSet.GetEnumerator();
	}
}
