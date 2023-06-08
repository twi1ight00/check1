using System;
using System.Collections.Generic;
using System.Drawing;
using ns216;

namespace ns215;

internal class Class5910
{
	private List<Class5919> list_0 = new List<Class5919>();

	private List<Class5834> list_1 = new List<Class5834>();

	private int int_0;

	private List<SizeF> list_2 = new List<SizeF>();

	private Dictionary<Interface252, List<int>> dictionary_0 = new Dictionary<Interface252, List<int>>();

	private bool bool_0;

	private int int_1;

	private Class5784 class5784_0;

	public int PageCount
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public List<SizeF> PageSizes => list_2;

	public List<Class5834> PageAreas => list_1;

	public List<Class5919> Layouts => list_0;

	public bool IsReady
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class5910(Class5784 xfa)
	{
		class5784_0 = xfa;
		class5784_0.LayoutModel = this;
	}

	private void method_0(Class5916 layout, int pageNumber)
	{
		int_0 = Math.Max(pageNumber, int_0);
		if (!dictionary_0.ContainsKey(layout.NativeObj))
		{
			dictionary_0[layout.NativeObj] = new List<int>();
		}
		dictionary_0[layout.NativeObj].Add(pageNumber);
		foreach (Class5914 item in layout.arrayList_0)
		{
			if (item is Class5915)
			{
				continue;
			}
			if (item is Class5916 layout2)
			{
				method_0(layout2, pageNumber);
				continue;
			}
			if (!dictionary_0.ContainsKey(item.NativeObj))
			{
				dictionary_0[item.NativeObj] = new List<int>();
			}
			dictionary_0[item.NativeObj].Add(pageNumber);
		}
	}

	public void method_1(Class5919 layout, Class5834 pageArea, SizeF pageSize)
	{
		list_0.Add(layout);
		list_1.Add(pageArea);
		list_2.Add(pageSize);
		method_0(layout, ++int_1);
	}

	public void method_2(Class5848 root)
	{
		List<int> list = new List<int>();
		for (int i = 1; i <= int_1; i++)
		{
			list.Add(i);
		}
		dictionary_0.Add(root, list);
	}

	public int method_3(Interface252 element)
	{
		return dictionary_0[element][0];
	}

	public int method_4(Interface252 element)
	{
		return dictionary_0[element].Count;
	}
}
