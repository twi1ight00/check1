using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ns83;

internal class Class4376 : Class4374<object>
{
	private delegate object Delegate2776(object o);

	public Class4376(Interface106 adaptor, string elementDescription)
		: base(adaptor, elementDescription)
	{
	}

	public Class4376(Interface106 adaptor, string elementDescription, object oneElement)
		: base(adaptor, elementDescription, oneElement)
	{
	}

	public Class4376(Interface106 adaptor, string elementDescription, IList<object> elements)
		: base(adaptor, elementDescription, elements)
	{
	}

	[Obsolete("This constructor is for internal use only and might be phased out soon. Use instead the one with IList<T>.")]
	public Class4376(Interface106 adaptor, string elementDescription, IList elements)
		: base(adaptor, elementDescription, elements)
	{
	}

	public object method_3()
	{
		return method_4((object o) => interface106_0.imethod_1(o));
	}

	private object method_4(Delegate2776 ph)
	{
		if (method_5())
		{
			return ph(method_1());
		}
		return method_1();
	}

	private bool method_5()
	{
		int num = method_2();
		if (!bool_0)
		{
			if (int_0 >= num)
			{
				return num == 1;
			}
			return false;
		}
		return true;
	}

	public override object vmethod_0()
	{
		return method_4((object o) => method_6(o));
	}

	private object method_6(object el)
	{
		return interface106_0.imethod_2(el);
	}

	[CompilerGenerated]
	private object method_7(object o)
	{
		return interface106_0.imethod_1(o);
	}

	[CompilerGenerated]
	private object method_8(object o)
	{
		return method_6(o);
	}
}
