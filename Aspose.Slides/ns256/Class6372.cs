using System;
using System.Collections;
using System.Collections.Generic;

namespace ns256;

internal class Class6372 : Interface288
{
	private IList<Class6370> ilist_0 = new List<Class6370>();

	private IList<Class6370> ilist_1;

	private Interface287 interface287_0 = new Class6371();

	private Hashtable hashtable_0 = new Hashtable();

	private IList<Class6370> ilist_2 = new List<Class6370>();

	internal IList<Class6370> AdjustableValues => ilist_0;

	internal IList<Class6370> Guides => ilist_2;

	public Interface287 GuideFactory
	{
		get
		{
			return interface287_0;
		}
		set
		{
			interface287_0 = value;
		}
	}

	public double imethod_0(string guideName)
	{
		object obj = hashtable_0[guideName];
		if (obj == null)
		{
			throw new ArgumentOutOfRangeException(guideName, $"Guide with name '{guideName}' not found.");
		}
		return (double)obj;
	}

	internal void method_0(string name, string formula)
	{
		Class6370 item = GuideFactory.imethod_0(formula, name);
		ilist_0.Add(item);
	}

	internal void method_1(string name, string formula)
	{
		Class6370 item = GuideFactory.imethod_0(formula, name);
		ilist_2.Add(item);
	}

	internal void method_2(double width, double height)
	{
		hashtable_0.Clear();
		hashtable_0["w"] = width;
		hashtable_0["h"] = height;
		ilist_1 = GuideFactory.imethod_1();
		method_3(ilist_1);
		method_3(ilist_0);
		method_3(ilist_2);
	}

	private void method_3(IList<Class6370> guides)
	{
		foreach (Class6370 guide in guides)
		{
			hashtable_0[guide.Name] = guide.Formula.imethod_0(this);
		}
	}
}
