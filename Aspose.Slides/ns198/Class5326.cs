using System;
using System.Collections.Generic;
using ns196;
using ns197;

namespace ns198;

internal class Class5326
{
	[ThreadStatic]
	private static Class5326 class5326_0;

	private bool bool_0;

	private Class5297 class5297_0;

	private bool bool_1;

	private List<Class5282> list_0 = new List<Class5282>();

	private Dictionary<object, List<Class5298>> dictionary_0 = new Dictionary<object, List<Class5298>>();

	internal bool ResetArea
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

	internal static Class5326 Instance
	{
		get
		{
			if (class5326_0 == null)
			{
				class5326_0 = new Class5326();
			}
			return class5326_0;
		}
	}

	internal bool InsideFloat
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal Class5297 CurrentFlowLayoutManager
	{
		get
		{
			return class5297_0;
		}
		set
		{
			class5297_0 = value;
		}
	}

	internal List<Class5282> CurrentFloatBodyLayoutManagers
	{
		get
		{
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	private Class5326()
	{
	}

	internal void method_0(Class5296 cellLayoutManager, Class5298 floatLayoutManager)
	{
		if (!dictionary_0.ContainsKey(cellLayoutManager.imethod_21()))
		{
			dictionary_0[cellLayoutManager.imethod_21()] = new List<Class5298>();
		}
		List<Class5298> list = dictionary_0[cellLayoutManager.imethod_21()];
		foreach (Class5298 item in list)
		{
			if (item.imethod_21() == floatLayoutManager.imethod_21())
			{
				return;
			}
		}
		floatLayoutManager.IsInsideTableCell = true;
		list.Add(floatLayoutManager);
	}

	internal List<Class5298> method_1(Class5296 cellLayoutManager)
	{
		if (!dictionary_0.ContainsKey(cellLayoutManager.imethod_21()))
		{
			return null;
		}
		return dictionary_0[cellLayoutManager.imethod_21()];
	}

	internal void Clear()
	{
		list_0.Clear();
	}

	public void Dispose()
	{
		Clear();
		class5326_0 = null;
	}
}
