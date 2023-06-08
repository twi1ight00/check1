using System;
using System.Collections;

namespace Aspose.Slides;

public sealed class AdjustValueCollection : ICollection, IEnumerable, IAdjustValueCollection
{
	internal GeometryShape geometryShape_0;

	public int Count => geometryShape_0.Geometry.Adjustments.Length;

	public IAdjustValue this[int index] => new AdjustValue(geometryShape_0.Geometry.Adjustments[index]);

	ICollection IAdjustValueCollection.AsICollection => this;

	IEnumerable IAdjustValueCollection.AsIEnumerable => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal AdjustValueCollection()
	{
	}

	internal AdjustValueCollection(GeometryShape parent)
	{
		geometryShape_0 = parent;
	}

	public void CopyTo(Array array, int index)
	{
		geometryShape_0.Geometry.Adjustments.CopyTo(array, index);
	}

	public IEnumerator GetEnumerator()
	{
		return geometryShape_0.Geometry.Adjustments.GetEnumerator();
	}
}
