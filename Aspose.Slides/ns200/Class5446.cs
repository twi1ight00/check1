using System;
using System.Collections;
using System.Reflection;

namespace ns200;

internal class Class5446
{
	private Hashtable hashtable_0 = new Hashtable();

	public Class5446()
	{
		method_5();
	}

	private void method_0(Interface190 handler)
	{
		method_3("*", handler);
	}

	public void method_1(string classname)
	{
		try
		{
			Type type = Type.GetType(classname);
			_ = (Interface190)type.GetConstructor(Type.EmptyTypes).Invoke(null);
		}
		catch (Exception)
		{
			throw new ArgumentException(classname + " is not an " + typeof(Interface190).FullName);
		}
	}

	public void method_2(Interface190 handler)
	{
		string text = handler.imethod_2();
		if (text == null)
		{
			method_0(handler);
		}
		else
		{
			method_3(text, handler);
		}
	}

	private void method_3(string ns, Interface190 handler)
	{
		ArrayList arrayList = (ArrayList)hashtable_0[ns];
		if (arrayList == null)
		{
			arrayList = new ArrayList();
			hashtable_0.Add(ns, arrayList);
		}
		arrayList.Add(handler);
	}

	public Interface190 method_4(Interface177 renderer, string ns)
	{
		ArrayList lst = (ArrayList)hashtable_0[ns];
		Interface190 @interface = smethod_0(renderer, lst);
		if (@interface == null)
		{
			lst = (ArrayList)hashtable_0["*"];
			@interface = smethod_0(renderer, lst);
		}
		return @interface;
	}

	private static Interface190 smethod_0(Interface177 renderer, ArrayList lst)
	{
		if (lst != null)
		{
			int i = 0;
			for (int count = lst.Count; i < count; i++)
			{
				Interface190 @interface = (Interface190)lst[i];
				if (@interface.imethod_1(renderer))
				{
					return @interface;
				}
			}
		}
		return null;
	}

	private void method_5()
	{
		Type[] types = Assembly.GetExecutingAssembly().GetTypes();
		Type[] array = types;
		foreach (Type type in array)
		{
			if (type.IsSubclassOf(typeof(Interface190)))
			{
				Interface190 handler = (Interface190)type.GetConstructor(Type.EmptyTypes).Invoke(null);
				method_2(handler);
			}
		}
	}
}
