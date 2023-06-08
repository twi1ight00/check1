using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides;

public sealed class ColorOperationCollection : ICollection, IEnumerable, ICloneable, IEnumerable<IColorOperation>, IColorOperationCollection
{
	internal List<IColorOperation> list_0;

	private uint uint_0;

	public int Count => list_0.Count;

	public IColorOperation this[int index]
	{
		get
		{
			return list_0[index];
		}
		set
		{
			list_0[index] = value;
		}
	}

	IEnumerable IColorOperationCollection.AsIEnumerable => this;

	ICollection IColorOperationCollection.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	ICloneable IColorOperationCollection.AsICloneable => this;

	internal uint Version => uint_0;

	internal ColorOperationCollection()
	{
		list_0 = new List<IColorOperation>();
	}

	public IColorOperation Add(ColorTransformOperation operation, float parameter)
	{
		ColorOperation colorOperation = new ColorOperation(operation, parameter);
		list_0.Add(colorOperation);
		method_1();
		return colorOperation;
	}

	public IColorOperation Add(ColorTransformOperation operation)
	{
		return Add(operation, 0f);
	}

	public IColorOperation Insert(int position, ColorTransformOperation operation, float parameter)
	{
		ColorOperation colorOperation = new ColorOperation(operation, parameter);
		list_0.Insert(position, colorOperation);
		method_1();
		return colorOperation;
	}

	public IColorOperation Insert(int position, ColorTransformOperation operation)
	{
		return Insert(position, operation, 0f);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
		method_1();
	}

	public void Clear()
	{
		list_0.Clear();
		method_1();
	}

	internal void method_0(FloatColor color)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			((ColorOperation)list_0[i]).method_0(color);
		}
	}

	public IEnumerator<IColorOperation> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}

	public object Clone()
	{
		ColorOperationCollection colorOperationCollection = new ColorOperationCollection();
		foreach (ColorOperation item in list_0)
		{
			colorOperationCollection.Add(item.OperationType, item.Parameter);
		}
		return colorOperationCollection;
	}

	private void method_1()
	{
		uint_0++;
	}
}
