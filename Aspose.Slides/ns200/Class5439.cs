using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace ns200;

internal class Class5439 : IComparer
{
	private Hashtable hashtable_0 = new Hashtable();

	private ArrayList arrayList_0 = new ArrayList();

	private int int_0;

	public int Compare(object x, object y)
	{
		Interface188 @interface = (Interface188)x;
		Interface188 interface2 = (Interface188)y;
		if (@interface.imethod_0() < interface2.imethod_0())
		{
			return 1;
		}
		if (@interface.imethod_0() > interface2.imethod_0())
		{
			return -1;
		}
		return 0;
	}

	public Class5439()
	{
		method_3();
	}

	public void method_0(string classname)
	{
		try
		{
			Interface188 handler = (Interface188)Type.GetType(classname).GetConstructor(Type.EmptyTypes).Invoke(null);
			method_1(handler);
		}
		catch (Exception)
		{
			throw new ArgumentException(classname + " is not an ImageHandler");
		}
	}

	public void method_1(Interface188 handler)
	{
		Type key = handler.imethod_1();
		hashtable_0.Add(key, handler);
		arrayList_0.Add(handler);
		arrayList_0.Sort(this);
		int_0++;
	}

	public Interface188 method_2(Interface189 targetContext, Image image)
	{
		foreach (Interface188 item in arrayList_0)
		{
			if (item.imethod_2(targetContext, image))
			{
				return item;
			}
		}
		return null;
	}

	private void method_3()
	{
		Type[] types = Assembly.GetExecutingAssembly().GetTypes();
		Type[] array = types;
		foreach (Type type in array)
		{
			if (type.IsSubclassOf(typeof(Interface188)))
			{
				Interface188 handler = (Interface188)type.GetConstructor(Type.EmptyTypes).Invoke(null);
				method_1(handler);
			}
		}
	}
}
