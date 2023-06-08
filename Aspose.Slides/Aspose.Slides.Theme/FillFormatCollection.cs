using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides.Theme;

public sealed class FillFormatCollection : IEnumerable<IFillFormat>, ICollection, IEnumerable, IFillFormatCollection
{
	internal List<IFillFormat> list_0 = new List<IFillFormat>();

	private FormatScheme formatScheme_0;

	private uint uint_0;

	public int Count => list_0.Count;

	public IFillFormat this[int index] => list_0[index];

	internal uint Version
	{
		get
		{
			uint num = uint_0;
			foreach (FillFormat item in list_0)
			{
				num += item.Version;
			}
			return num;
		}
	}

	IEnumerable IFillFormatCollection.AsIEnumerable => this;

	ICollection IFillFormatCollection.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal FillFormatCollection(FormatScheme parent)
	{
		formatScheme_0 = parent;
	}

	internal void method_0(FillFormatCollection fillFormatCollection)
	{
		uint_0 = Version;
		method_1();
		formatScheme_0 = fillFormatCollection.formatScheme_0;
		list_0.Clear();
		foreach (FillFormat item in fillFormatCollection.list_0)
		{
			FillFormat fillFormat = new FillFormat(formatScheme_0);
			list_0.Add(fillFormat);
			fillFormat.method_0(item);
		}
	}

	internal IFillFormat Add()
	{
		FillFormat fillFormat = new FillFormat(formatScheme_0);
		list_0.Add(fillFormat);
		method_1();
		return fillFormat;
	}

	private void method_1()
	{
		uint_0++;
	}

	IEnumerator<IFillFormat> IEnumerable<IFillFormat>.GetEnumerator()
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
