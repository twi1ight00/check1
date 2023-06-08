using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Aspose.Slides;

public sealed class TabCollection : ICollection, IEnumerable, IEnumerable<ITab>, ITabCollection
{
	internal SortedList<double, ITab> sortedList_0;

	internal uint uint_0;

	public int Count => sortedList_0.Count;

	public ITab this[int index] => sortedList_0.Values[index];

	internal uint Version => uint_0;

	ICollection ITabCollection.AsICollection => this;

	IEnumerable ITabCollection.AsIEnumerable => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal TabCollection()
	{
		sortedList_0 = new SortedList<double, ITab>();
	}

	public ITab Add(double position, TabAlignment align)
	{
		Tab tab = new Tab(position, align);
		Add(tab);
		return tab;
	}

	public int Add(ITab value)
	{
		if (((Tab)value).tabCollection_0 != null)
		{
			throw new PptxEditException("Can't add already used tab");
		}
		((Tab)value).tabCollection_0 = this;
		if (sortedList_0.ContainsKey(value.Position))
		{
			if (((Tab)sortedList_0[value.Position]).Alignment == TabAlignment.Left)
			{
				sortedList_0[value.Position] = value;
			}
		}
		else
		{
			sortedList_0[value.Position] = value;
		}
		method_1();
		return sortedList_0.IndexOfKey(value.Position);
	}

	public void Clear()
	{
		foreach (Tab value in sortedList_0.Values)
		{
			value.tabCollection_0 = null;
		}
		sortedList_0.Clear();
		method_1();
	}

	public void RemoveAt(int index)
	{
		((Tab)sortedList_0.Values[index]).tabCollection_0 = null;
		sortedList_0.RemoveAt(index);
		method_1();
	}

	internal void method_0(double position)
	{
		int num = sortedList_0.IndexOfKey(position);
		if (num >= 0)
		{
			RemoveAt(num);
		}
	}

	internal void method_1()
	{
		uint_0++;
	}

	IEnumerator<ITab> IEnumerable<ITab>.GetEnumerator()
	{
		return sortedList_0.Values.GetEnumerator();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is TabCollection tabCollection))
		{
			return base.Equals(obj);
		}
		int count = Count;
		if (count != tabCollection.Count)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < count)
			{
				ITab tab = sortedList_0.Values[num];
				ITab tab2 = tabCollection.sortedList_0.Values[num];
				if (tab.Position != tab2.Position || tab.Alignment != tab2.Alignment)
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return RuntimeHelpers.GetHashCode(this);
	}

	internal void method_2(TabCollection tabs)
	{
		Clear();
		int count = tabs.Count;
		for (int i = 0; i < count; i++)
		{
			ITab tab = tabs.sortedList_0.Values[i];
			Add(new Tab(tab.Position, tab.Alignment));
		}
	}

	public IEnumerator GetEnumerator()
	{
		return sortedList_0.Values.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)sortedList_0).CopyTo(array, index);
	}
}
