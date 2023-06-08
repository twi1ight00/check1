using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal abstract class CollectionBase<T> : CollectionValueBase<T>
{
	protected bool isReadOnlyBase;

	protected int stamp;

	protected int size;

	protected readonly IEqualityComparer<T> itemequalityComparer;

	private int iUnSequencedHashCode;

	private int iUnSequencedHashCodeStamp = -1;

	private static Type isortedtype = typeof(ISorted<T>);

	[Tested]
	[ComVisible(true)]
	public virtual bool IsReadOnly
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return isReadOnlyBase;
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
			return size;
		}
	}

	[ComVisible(true)]
	public override Speed CountSpeed
	{
		[ComVisible(true)]
		get
		{
			return Speed.Constant;
		}
	}

	[ComVisible(true)]
	public virtual IEqualityComparer<T> EqualityComparer
	{
		[ComVisible(true)]
		get
		{
			return itemequalityComparer;
		}
	}

	[Tested]
	[ComVisible(true)]
	public override bool IsEmpty
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return size == 0;
		}
	}

	protected CollectionBase(IEqualityComparer<T> itemequalityComparer)
	{
		if (itemequalityComparer == null)
		{
			throw new NullReferenceException("Item EqualityComparer cannot be null.");
		}
		this.itemequalityComparer = itemequalityComparer;
	}

	[Tested]
	protected void checkRange(int start, int count)
	{
		if (start < 0 || count < 0 || start + count > size)
		{
			throw new ArgumentOutOfRangeException();
		}
	}

	[Tested]
	[ComVisible(true)]
	public static int ComputeHashCode(ICollectionValue<T> items, IEqualityComparer<T> itemequalityComparer)
	{
		int num = 0;
		foreach (T item in items)
		{
			uint hashCode = (uint)itemequalityComparer.GetHashCode(item);
			num += (int)((hashCode * 1529784657 + 1) ^ (uint)((int)hashCode * -1382135419) ^ (hashCode * 1118771817 + 2));
		}
		return num;
	}

	[Tested]
	[ComVisible(true)]
	public static bool StaticEquals(ICollection<T> collection1, ICollection<T> collection2, IEqualityComparer<T> itemequalityComparer)
	{
		if (object.ReferenceEquals(collection1, collection2))
		{
			return true;
		}
		if (collection1 == null || collection2 == null)
		{
			return false;
		}
		if (collection1.Count != collection2.Count)
		{
			return false;
		}
		if (collection1.GetUnsequencedHashCode() != collection2.GetUnsequencedHashCode())
		{
			return false;
		}
		if (collection1 is ISorted<T> sorted && collection2 is ISorted<T> sorted2 && sorted.Comparer == sorted2.Comparer)
		{
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
				return true;
			}
		}
		if (!collection1.AllowsDuplicates && (collection2.AllowsDuplicates || collection2.ContainsSpeed >= collection1.ContainsSpeed))
		{
			foreach (T item in collection1)
			{
				if (!collection2.Contains(item))
				{
					return false;
				}
			}
		}
		else if (!collection2.AllowsDuplicates)
		{
			foreach (T item2 in collection2)
			{
				if (!collection1.Contains(item2))
				{
					return false;
				}
			}
		}
		else
		{
			if (!collection1.DuplicatesByCounting || !collection2.DuplicatesByCounting)
			{
				HashDictionary<T, int> hashDictionary = new HashDictionary<T, int>();
				foreach (T item3 in collection2)
				{
					int value = 1;
					if (hashDictionary.FindOrAdd(item3, ref value))
					{
						hashDictionary[item3] = value + 1;
					}
				}
				foreach (T item4 in collection1)
				{
					if (hashDictionary.Find(item4, out var value2) && value2 > 0)
					{
						hashDictionary[item4] = value2 - 1;
						continue;
					}
					return false;
				}
				return true;
			}
			foreach (T item5 in collection2)
			{
				if (collection1.ContainsCount(item5) != collection2.ContainsCount(item5))
				{
					return false;
				}
			}
		}
		return true;
	}

	[ComVisible(true)]
	public virtual int GetUnsequencedHashCode()
	{
		if (iUnSequencedHashCodeStamp == stamp)
		{
			return iUnSequencedHashCode;
		}
		iUnSequencedHashCode = ComputeHashCode(this, itemequalityComparer);
		iUnSequencedHashCodeStamp = stamp;
		return iUnSequencedHashCode;
	}

	[ComVisible(true)]
	public virtual bool UnsequencedEquals(ICollection<T> otherCollection)
	{
		if (otherCollection != null)
		{
			return StaticEquals((ICollection<T>)this, otherCollection, itemequalityComparer);
		}
		return false;
	}

	protected virtual void modifycheck(int thestamp)
	{
		if (stamp != thestamp)
		{
			throw new CollectionModifiedException();
		}
	}

	protected virtual void updatecheck()
	{
		if (isReadOnlyBase)
		{
			throw new ReadOnlyCollectionException();
		}
		stamp++;
	}

	[ComVisible(true)]
	public abstract override IEnumerator<T> GetEnumerator();
}
