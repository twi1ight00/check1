using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal abstract class SequencedBase<T> : DirectedCollectionBase<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	private const int HASHFACTOR = 31;

	private int iSequencedHashCode;

	private int iSequencedHashCodeStamp = -1;

	[Tested]
	[ComVisible(true)]
	public override EnumerationDirection Direction
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return EnumerationDirection.Forwards;
		}
	}

	protected SequencedBase(IEqualityComparer<T> itemequalityComparer)
		: base(itemequalityComparer)
	{
	}

	[Tested]
	[ComVisible(true)]
	public static int ComputeHashCode(ISequenced<T> items, IEqualityComparer<T> itemequalityComparer)
	{
		int num = 0;
		foreach (T item in items)
		{
			num = num * 31 + itemequalityComparer.GetHashCode(item);
		}
		return num;
	}

	[Tested]
	[ComVisible(true)]
	public static bool StaticEquals(ISequenced<T> collection1, ISequenced<T> collection2, IEqualityComparer<T> itemequalityComparer)
	{
		if (object.ReferenceEquals(collection1, collection2))
		{
			return true;
		}
		if (collection1.Count != collection2.Count)
		{
			return false;
		}
		if (collection1.GetSequencedHashCode() != collection2.GetSequencedHashCode())
		{
			return false;
		}
		using (IEnumerator<T> enumerator2 = collection2.GetEnumerator())
		{
			using IEnumerator<T> enumerator = collection1.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator2.MoveNext();
				if (!itemequalityComparer.Equals(enumerator.Current, enumerator2.Current))
				{
					return false;
				}
			}
		}
		return true;
	}

	[ComVisible(true)]
	public virtual int GetSequencedHashCode()
	{
		if (iSequencedHashCodeStamp == stamp)
		{
			return iSequencedHashCode;
		}
		iSequencedHashCode = ComputeHashCode((ISequenced<T>)this, itemequalityComparer);
		iSequencedHashCodeStamp = stamp;
		return iSequencedHashCode;
	}

	[ComVisible(true)]
	public virtual bool SequencedEquals(ISequenced<T> otherCollection)
	{
		return StaticEquals((ISequenced<T>)this, otherCollection, itemequalityComparer);
	}

	[ComVisible(true)]
	public abstract override IEnumerator<T> GetEnumerator();

	[ComVisible(true)]
	public int FindIndex(Fun<T, bool> predicate)
	{
		int num = 0;
		using (IEnumerator<T> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				if (predicate(current))
				{
					return num;
				}
				num++;
			}
		}
		return -1;
	}

	[ComVisible(true)]
	public int FindLastIndex(Fun<T, bool> predicate)
	{
		int num = Count - 1;
		foreach (T item in Backwards())
		{
			if (predicate(item))
			{
				return num;
			}
			num--;
		}
		return -1;
	}
}
