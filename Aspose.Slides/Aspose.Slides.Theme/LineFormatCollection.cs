using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides.Theme;

public sealed class LineFormatCollection : ICollection, IEnumerable<ILineFormat>, IEnumerable, ILineFormatCollection
{
	private FormatScheme formatScheme_0;

	private uint uint_0;

	internal List<ILineFormat> list_0 = new List<ILineFormat>();

	public int Count => list_0.Count;

	public ILineFormat this[int index] => list_0[index];

	internal uint Version
	{
		get
		{
			uint num = uint_0;
			foreach (LineFormat item in list_0)
			{
				num += item.Version;
			}
			return num;
		}
	}

	IEnumerable ILineFormatCollection.AsIEnumerable => this;

	ICollection ILineFormatCollection.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal void Add(ILineFormat item)
	{
		list_0.Add(item);
		method_1();
	}

	internal ILineFormat Add()
	{
		LineFormat lineFormat = new LineFormat(formatScheme_0);
		list_0.Add(lineFormat);
		method_1();
		return lineFormat;
	}

	internal void Insert(int index, ILineFormat item)
	{
		list_0.Insert(index, item);
		method_1();
	}

	internal void Remove(ILineFormat item)
	{
		uint_0 = Version;
		method_1();
		list_0.Remove(item);
	}

	internal void RemoveAt(int index)
	{
		uint_0 = Version;
		method_1();
		list_0.RemoveAt(index);
	}

	internal void Clear()
	{
		uint_0 = Version;
		method_1();
		list_0.Clear();
	}

	internal LineFormatCollection(FormatScheme parent)
	{
		formatScheme_0 = parent;
	}

	internal void method_0(LineFormatCollection lineFormatCollection)
	{
		uint_0 = Version;
		method_1();
		formatScheme_0 = lineFormatCollection.formatScheme_0;
		list_0.Clear();
		foreach (LineFormat item in lineFormatCollection.list_0)
		{
			LineFormat lineFormat = new LineFormat(formatScheme_0);
			list_0.Add(lineFormat);
			lineFormat.method_0(item);
		}
	}

	private void method_1()
	{
		uint_0++;
	}

	IEnumerator<ILineFormat> IEnumerable<ILineFormat>.GetEnumerator()
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
