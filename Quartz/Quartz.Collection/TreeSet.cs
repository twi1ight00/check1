using System;
using System.Collections;
using System.Collections.Generic;
using C5;

namespace Quartz.Collection;

/// <summary>
/// Simple C5 wrapper for common interface.
/// </summary>
/// <typeparam name="T"></typeparam>
[Serializable]
public class TreeSet<T> : C5.TreeSet<T>, ISortedSet<T>, ISet<T>, System.Collections.Generic.ICollection<T>, IEnumerable<T>, IEnumerable
{
	/// <summary>
	/// Indexer.
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	T ISortedSet<T>.this[int index] => base[index];

	/// <summary>
	/// Default constructor.
	/// </summary>
	public TreeSet()
	{
	}

	/// <summary>
	/// Constructor that accepts comparer.
	/// </summary>
	/// <param name="comparer">Comparer to use.</param>
	public TreeSet(IComparer<T> comparer)
		: base(comparer)
	{
	}

	/// <summary>
	/// Constructor that prepolutates.
	/// </summary>
	/// <param name="items"></param>
	public TreeSet(IEnumerable<T> items)
	{
		AddAll(items);
	}

	/// <summary>
	/// Returns the first element.
	/// </summary>
	/// <returns></returns>
	public T First()
	{
		if (Count <= 0)
		{
			return default(T);
		}
		return base[0];
	}

	/// <summary>
	/// Return items from given range.
	/// </summary>
	/// <param name="limit"></param>
	/// <returns></returns>
	public ISortedSet<T> TailSet(T limit)
	{
		TreeSet<T> retValue = new TreeSet<T>(base.Comparer);
		IDirectedCollectionValue<T> directedCollectionValue = RangeFrom(limit);
		retValue.AddAll(directedCollectionValue);
		return retValue;
	}
}
/// <summary>
/// Only for backwards compatibility with serialization!
/// </summary>
[Serializable]
public class TreeSet : ArrayList
{
}
