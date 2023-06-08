using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.Charts;
using ns42;
using ns43;

namespace ns34;

internal class Class805 : ICollection, IEnumerable, IEnumerable<Class804>
{
	private List<Class804> list_0;

	private ChartDataWorkbook chartDataWorkbook_0;

	public int Count => list_0.Count;

	public Class804 this[int index] => list_0[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal Class805(ChartDataWorkbook parent)
	{
		list_0 = new List<Class804>();
		chartDataWorkbook_0 = parent;
	}

	public void Clear()
	{
		list_0.Clear();
	}

	internal void Add(Class804 value)
	{
		list_0.Add(value);
	}

	internal void method_0(Class810 numFmts)
	{
		if (numFmts != null)
		{
			Class810[] array = numFmts.method_56(Class814.string_1, Class824.string_12);
			Class810[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Class814 numFmtElem = (Class814)array2[i];
				Class804 @class = new Class804();
				@class.method_0(numFmtElem);
				list_0.Add(@class);
			}
		}
	}

	internal void Save(Class810 target)
	{
		foreach (Class804 item in list_0)
		{
			Class810 @class = target.method_0(Class814.string_1, Class824.string_12);
			@class.Prefix = "";
			item.Save((Class814)@class);
		}
	}

	IEnumerator<Class804> IEnumerable<Class804>.GetEnumerator()
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
