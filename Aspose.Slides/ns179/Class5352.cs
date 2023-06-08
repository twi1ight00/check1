using System;
using System.Collections;

namespace ns179;

internal class Class5352
{
	private int int_0;

	private Hashtable hashtable_0 = new Hashtable();

	public string method_0(Class5349 action)
	{
		int_0++;
		string text = action.vmethod_1();
		if (text == null)
		{
			throw new Exception("Action class is not compatible");
		}
		return text + int_0;
	}

	public Class5349 method_1(string id)
	{
		return (Class5349)hashtable_0[id];
	}

	public Class5349 method_2(Class5349 action)
	{
		if (!action.method_4())
		{
			action.method_0(method_0(action));
		}
		Class5349 @class = method_4(action);
		if (@class == action)
		{
			hashtable_0[action.method_1()] = action;
		}
		return @class;
	}

	public void method_3()
	{
		hashtable_0.Clear();
	}

	private Class5349 method_4(Class5349 action)
	{
		foreach (Class5349 value in hashtable_0.Values)
		{
			if (value.vmethod_0(action))
			{
				return value;
			}
		}
		return action;
	}
}
