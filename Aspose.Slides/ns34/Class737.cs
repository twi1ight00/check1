using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.Charts;
using ns42;
using ns43;

namespace ns34;

internal class Class737 : ICollection, IEnumerable, IEnumerable<Class736>
{
	private List<Class736> list_0;

	private ChartDataWorkbook chartDataWorkbook_0;

	public int Count => list_0.Count;

	public Class736 this[int index] => list_0[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal Class737(ChartDataWorkbook parent)
	{
		list_0 = new List<Class736>();
		chartDataWorkbook_0 = parent;
	}

	public void Clear()
	{
		list_0.Clear();
	}

	internal int Add(Class736 value)
	{
		list_0.Add(value);
		return list_0.IndexOf(value);
	}

	internal void method_0(Class810 cellXfsElement)
	{
		if (cellXfsElement != null)
		{
			Class810[] array = cellXfsElement.method_56(Class820.string_1, Class824.string_12);
			Class810[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Class820 xfElement = (Class820)array2[i];
				Class736 @class = new Class736();
				@class.method_0(xfElement);
				list_0.Add(@class);
			}
		}
	}

	internal void Save(Class810 target)
	{
		foreach (Class736 item in list_0)
		{
			Class810 @class = target.method_0(Class820.string_1, Class824.string_12);
			@class.Prefix = "";
			item.Save((Class820)@class);
		}
	}

	IEnumerator<Class736> IEnumerable<Class736>.GetEnumerator()
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
