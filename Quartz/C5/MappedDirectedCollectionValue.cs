using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal abstract class MappedDirectedCollectionValue<T, V> : DirectedCollectionValueBase<V>, IDirectedCollectionValue<V>, ICollectionValue<V>, IShowable, IFormattable, IDirectedEnumerable<V>, IEnumerable<V>, IEnumerable
{
	private IDirectedCollectionValue<T> directedcollectionvalue;

	[ComVisible(true)]
	public override bool IsEmpty
	{
		[ComVisible(true)]
		get
		{
			return directedcollectionvalue.IsEmpty;
		}
	}

	[ComVisible(true)]
	public override int Count
	{
		[ComVisible(true)]
		get
		{
			return directedcollectionvalue.Count;
		}
	}

	[ComVisible(true)]
	public override Speed CountSpeed
	{
		[ComVisible(true)]
		get
		{
			return directedcollectionvalue.CountSpeed;
		}
	}

	[ComVisible(true)]
	public override EnumerationDirection Direction
	{
		[ComVisible(true)]
		get
		{
			return directedcollectionvalue.Direction;
		}
	}

	[ComVisible(true)]
	public abstract V Map(T item);

	[ComVisible(true)]
	public MappedDirectedCollectionValue(IDirectedCollectionValue<T> directedcollectionvalue)
	{
		this.directedcollectionvalue = directedcollectionvalue;
	}

	[ComVisible(true)]
	public override V Choose()
	{
		return Map(directedcollectionvalue.Choose());
	}

	[ComVisible(true)]
	public override IDirectedCollectionValue<V> Backwards()
	{
		MappedDirectedCollectionValue<T, V> mappedDirectedCollectionValue = (MappedDirectedCollectionValue<T, V>)MemberwiseClone();
		mappedDirectedCollectionValue.directedcollectionvalue = directedcollectionvalue.Backwards();
		return mappedDirectedCollectionValue;
	}

	[ComVisible(true)]
	public override IEnumerator<V> GetEnumerator()
	{
		foreach (T item in directedcollectionvalue)
		{
			yield return Map(item);
		}
	}

	IDirectedEnumerable<V> IDirectedEnumerable<V>.Backwards()
	{
		return Backwards();
	}
}
