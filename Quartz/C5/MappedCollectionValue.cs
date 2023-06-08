using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal abstract class MappedCollectionValue<T, V> : CollectionValueBase<V>, ICollectionValue<V>, IEnumerable<V>, IEnumerable, IShowable, IFormattable
{
	private ICollectionValue<T> collectionvalue;

	[ComVisible(true)]
	public override bool IsEmpty
	{
		[ComVisible(true)]
		get
		{
			return collectionvalue.IsEmpty;
		}
	}

	[ComVisible(true)]
	public override int Count
	{
		[ComVisible(true)]
		get
		{
			return collectionvalue.Count;
		}
	}

	[ComVisible(true)]
	public override Speed CountSpeed
	{
		[ComVisible(true)]
		get
		{
			return collectionvalue.CountSpeed;
		}
	}

	[ComVisible(true)]
	public abstract V Map(T item);

	[ComVisible(true)]
	public MappedCollectionValue(ICollectionValue<T> collectionvalue)
	{
		this.collectionvalue = collectionvalue;
	}

	[ComVisible(true)]
	public override V Choose()
	{
		return Map(collectionvalue.Choose());
	}

	[ComVisible(true)]
	public override IEnumerator<V> GetEnumerator()
	{
		foreach (T item in collectionvalue)
		{
			yield return Map(item);
		}
	}
}
