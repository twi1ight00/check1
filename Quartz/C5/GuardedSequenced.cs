using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedSequenced<T> : GuardedCollection<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, System.Collections.Generic.ICollection<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	private ISequenced<T> sequenced;

	[ComVisible(true)]
	public EnumerationDirection Direction
	{
		[ComVisible(true)]
		get
		{
			return EnumerationDirection.Forwards;
		}
	}

	[ComVisible(true)]
	public GuardedSequenced(ISequenced<T> sorted)
		: base((ICollection<T>)sorted)
	{
		sequenced = sorted;
	}

	[ComVisible(true)]
	public int FindIndex(Fun<T, bool> predicate)
	{
		if (sequenced is IIndexed<T> indexed)
		{
			return indexed.FindIndex(predicate);
		}
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
		if (sequenced is IIndexed<T> indexed)
		{
			return indexed.FindLastIndex(predicate);
		}
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

	[ComVisible(true)]
	public int GetSequencedHashCode()
	{
		return sequenced.GetSequencedHashCode();
	}

	[ComVisible(true)]
	public bool SequencedEquals(ISequenced<T> that)
	{
		return sequenced.SequencedEquals(that);
	}

	[ComVisible(true)]
	public virtual IDirectedCollectionValue<T> Backwards()
	{
		return new GuardedDirectedCollectionValue<T>(sequenced.Backwards());
	}

	[ComVisible(true)]
	public virtual bool FindLast(Fun<T, bool> predicate, out T item)
	{
		return sequenced.FindLast(predicate, out item);
	}

	IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
	{
		return Backwards();
	}

	[ComVisible(true)]
	public override object Clone()
	{
		return new GuardedCollection<T>((ISequenced<T>)sequenced.Clone());
	}
}
