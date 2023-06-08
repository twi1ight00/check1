using System;
using System.Collections;
using System.Reflection;

namespace ns203;

internal class Class5372
{
	private static Hashtable hashtable_0 = new Hashtable();

	private Class5372()
	{
	}

	public static void Add(Type interfaceType)
	{
		if (!(interfaceType != null))
		{
			return;
		}
		lock (hashtable_0.SyncRoot)
		{
			if (!hashtable_0.ContainsKey(interfaceType.FullName))
			{
				hashtable_0.Add(interfaceType.FullName, interfaceType);
			}
		}
	}

	public static MethodInfo smethod_0(string name, int i)
	{
		Type type = null;
		lock (hashtable_0.SyncRoot)
		{
			type = (Type)hashtable_0[name];
		}
		MethodInfo[] methods = type.GetMethods();
		if (i < methods.Length)
		{
			return methods[i];
		}
		return null;
	}
}
